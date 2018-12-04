//******************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd.
// All Rights Reserved.
//
// DISCUSSION
//  Provides the nightly backup routine, calls SQL procedues to:
//  Backup DBs, copy backup files from D: to C:, and delete old ones,
//  delete old history info, re-organise indexes,
//  also deletes old Scanner Debug Log data form [Data].DebugLog
//
// MODIFICATION HISTORY
// Version  Project/CR      Date        By                  References
//    1.00  702678          04Apr2017   Martin Cox 
//          Initial Creation
//
//******************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExwoldPcInterface
{
    /// <summary>
    /// Generates nightly backups 
    /// </summary>
    class DbNightlyBackup
    {

        static private int day = DateTime.Now.Day;

        public static string dbConnStr = "";
        public static string DatabaseBackupsDaysToKeep = "";
        public static string DatabaseBackupPath = "";

        // instanciate the timer, setting it for every 10 minutes
        System.Threading.Timer Backup_timer = new System.Threading.Timer(TimerCallback, null, 600000, 600000);

        public DbNightlyBackup(string dbConectionString, string DatabaseBackupsDaysToKeep, string databaseBackupPath)
        {
            DbNightlyBackup.dbConnStr = dbConectionString;
            DbNightlyBackup.DatabaseBackupPath = databaseBackupPath;
        }

        // handle messages returned from SQL Server
        private static List<string> sqlMessages = new List<string>();
        /// <summary>
        /// Handler for the InfoMessage event of the SQL Client Connection to captire messages returned by Stored Procedures, etc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void InfoMessageHandler(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
        {
            sqlMessages.Add(e.Message);
        }


        /// <summary>
        /// Timer Handler.   On change of day, backup all the databases.
        /// </summary>
        /// <param name="stateObject"></param>
        private async static void TimerCallback(object stateObject)
        {
            try
            {
                if (day != DateTime.Now.Day)
                {
                    // a change of day has occurred (so midnight has just happened)
                    day = DateTime.Now.Day;

                    int result = 0;
                    if (DatabaseBackupsDaysToKeep == null || DatabaseBackupsDaysToKeep == "" || !int.TryParse(DatabaseBackupsDaysToKeep, out result))
                        DatabaseBackupsDaysToKeep = "15";

                    Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, "BACKUP: Starting");
                    DateTime processStartDT = DateTime.Now;

                    // get DB Conection
                    Database db;
                    db = new Database(dbConnStr);
                    db.CommandTimeout = 3600000;
                    // register for events
                    db.dbConn.InfoMessage += new System.Data.SqlClient.SqlInfoMessageEventHandler(InfoMessageHandler);

                    // Backup DB
                    sqlMessages.Clear();
                    string sql = "EXEC Maint_BackupDatabases @path='" + DatabaseBackupPath +"' ";
                    await AsyncExecuteNonQuery(db, sql);
                    foreach (string message in sqlMessages)
                        foreach (string s in message.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, "BACKUP: " + s);

                    Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, "BACKUP: Finished, elapsed time: " + DateTime.Now.Subtract(processStartDT).Duration().ToString("hh\\:mm\\:ss\\.fff"));

                    // Copy/Delete DB
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, "Copy Backups, Delete Old backups: Starting");
                    sqlMessages.Clear();
                    processStartDT = DateTime.Now;
                    sql = "EXEC Maint_CopyDeleteBackups " + DatabaseBackupsDaysToKeep;
                    await AsyncExecuteNonQuery(db, sql);
                    foreach (string message in sqlMessages)
                        foreach (string s in message.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, "BACKUP: " + s);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, "Copy Backups, Delete Old backups: Finished, elapsed time: " + DateTime.Now.Subtract(processStartDT).Duration().ToString("hh\\:mm\\:ss\\.fff"));

                    // Maintenance - delete old history info (not needed for manual restore
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, "Copy Backups, Delete Old backups: Starting");
                    sqlMessages.Clear();
                    processStartDT = DateTime.Now;
                    sql = "EXEC Maint_CleanupHistory " + DatabaseBackupsDaysToKeep;
                    await AsyncExecuteNonQuery(db, sql);
                    foreach (string message in sqlMessages)
                        foreach (string s in message.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, "BACKUP: " + s);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, "Copy Backups, Delete Old backups: Finished, elapsed time: " + DateTime.Now.Subtract(processStartDT).Duration().ToString("hh\\:mm\\:ss\\.fff"));

                    // Maintenance - Re-organise Indexes
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, "Copy Backups, Delete Old backups: Starting");
                    sqlMessages.Clear();
                    processStartDT = DateTime.Now;
                    sql = "EXEC Maint_ReorganiseIndexes ";
                    await AsyncExecuteNonQuery(db, sql);
                    foreach (string message in sqlMessages)
                        foreach (string s in message.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, "BACKUP: " + s);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, "Copy Backups, Delete Old backups: Finished, elapsed time: " + DateTime.Now.Subtract(processStartDT).Duration().ToString("hh\\:mm\\:ss\\.fff"));
                    
                    // Delete old Scanner Debug Log data form [Data].DebugLog
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, "Delete old DebugLogs: Starting");
                    sqlMessages.Clear();
                    processStartDT = DateTime.Now;
                    sql = "DELETE FROM ExwoldTracking.[Data].DebugLog WHERE DT < DATEADD(DAY, " + DatabaseBackupsDaysToKeep + ", GETDATE() )";
                    await AsyncExecuteNonQuery(db, sql);
                    foreach (string message in sqlMessages)
                        foreach (string s in message.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, "BACKUP: " + s);
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, "Delete old DebugLogs: Finished, elapsed time: " + DateTime.Now.Subtract(processStartDT).Duration().ToString("hh\\:mm\\:ss\\.fff"));

                    // de-register for events
                    db.dbConn.InfoMessage -= new System.Data.SqlClient.SqlInfoMessageEventHandler(InfoMessageHandler);

                }
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, "BACKUP: EXCEPTION: " + ex.ToString());
            }
        }

        /// <summary>
        /// Async wrapper for the database.ExecuteNonQuery() calls
        /// </summary>
        /// <param name="database">Database object to use</param>
        /// <param name="sql">SQL to run</param>
        /// <returns></returns>
        private static Task<int> AsyncExecuteNonQuery(Database database, string sql)
        {
            return Task.Run(() => database.ExecuteNonQuery(sql));
        }

    }
}
