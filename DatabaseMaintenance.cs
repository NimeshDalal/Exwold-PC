//******************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd.
// All Rights Reserved.
//
// DISCUSSION
// Provides an interface to run the Arcive processes:
//  1)  Archive the Live DB, delete ld data from Live, delete current data from Archive.
//  2)  Set Archive Off-line
//  3)  Set Archive On-line again
//
// MODIFICATION HISTORY
// Version  Project/CR      Date        By                  References
//    1.00  702678          04Apr2017   Martin Cox 
//          Initial Creation
//
//******************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExwoldPcInterface
{

    /// <summary>
    /// Database Maintenance form.
    /// </summary>
    public partial class DatabaseMaintenance : Form
    {

        Database db;
        public string dbConnStr = "";
        private string username = "";
        /// <summary>
        ///  the base name for the family of databases
        /// </summary>
        private string databaseName = "ExwoldTracking";

        /// <summary>
        /// List of Views to update
        /// </summary>
        private List<string> viewsToUpdate = new List<string>(new string[] { "View_Audits_Config_PalletBatch",
                                                                             "View_Report_Genealogy",
                                                                             "View_Report_PalletBatch" } );
        
        /// <summary>
        /// Constructor
        /// </summary>
        public DatabaseMaintenance()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbConnectionString">Database Connection string to use.</param>
        public DatabaseMaintenance(string dbConnectionString, string username)
        {
            InitializeComponent();
            this.dbConnStr = dbConnectionString;
            this.username = username;
        }

        List<string> sqlMessages = new List<string>();
        /// <summary>
        /// Handler for the InfoMessage event of the SQL Client Connection to captire messages returned by Stored Procedures, etc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void InfoMessageHandler(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
        {
            sqlMessages.Add(e.Message);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Form-load event.   Populates the DateTime-picker and list-boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DatabaseMaintenance_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                db = new Database(dbConnStr);
                db.CommandTimeout = 3600000;
                db.dbConn.InfoMessage += new System.Data.SqlClient.SqlInfoMessageEventHandler(InfoMessageHandler);


                // Get the oldest data in the PalletBatch table
                // Set the limits for the DateTimePicker oldest data to yesterday
                // Disable the controls if dates not valid
                DateTime Oldest = DateTime.Now;
                DateTime Newest = DateTime.Now;
                sql = "SELECT COALESCE(MIN(StartDT),GETDATE()) MinDate, COALESCE(MAX(StartDT),GETDATE()) MaxDate FROM " + databaseName + ".Data.PalletBatch";
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, sql);
                // Async call
                DataTable OldestDataTable = await AsyncExecQuery(db, sql);
                Thread.Sleep(250);
                if (OldestDataTable.Rows.Count > 0
                     && OldestDataTable.Rows[0].Field<DateTime>(0) != null
                     && OldestDataTable.Rows[0].Field<DateTime>(1) != null  
                     && OldestDataTable.Rows[0].Field<DateTime>(0) < OldestDataTable.Rows[0].Field<DateTime>(1) )
                {
                    Oldest = OldestDataTable.Rows[0].Field<DateTime>(0);
                    Newest = OldestDataTable.Rows[0].Field<DateTime>(1);
                    if (Oldest < DateTime.Now.AddDays(-1))
                    {
                        ArchiveCutOffDate.MaxDate = DateTime.Now.AddDays(-1);
                        ArchiveCutOffDate.MinDate = Oldest;
                        ArchiveProgressListBox.Items.Add("Ready");
                        ArchiveGroupBox.Enabled = true;
                    }
                    else
                    {
                        ArchiveProgressListBox.Items.Add("No data available to Archive");
                        ArchiveGroupBox.Enabled = false;
                    }
                }
                else
                {
                    ArchiveProgressListBox.Items.Add("No data available to Archive");
                    ArchiveGroupBox.Enabled = false;
                }

                // Get the list of On-line-Archives that we can Detach
                sql = "SELECT DbName FROM " + databaseName + ".Config.ArchiveDBs ORDER BY DbName ASC";
                // Async Call
                DataTable OnLineArchivesDataTable = await AsyncExecQuery(db, sql);
                Thread.Sleep(250);
                if (OnLineArchivesDataTable.Rows.Count > 0)
                {
                    OnLineArchivesListBox.Items.Clear();
                    OnLineArchivesListBox.DataSource = OnLineArchivesDataTable;
                    OnLineArchivesListBox.DisplayMember = "DbName";
                    OnLineArchivesListBox.ValueMember = "DbName";
                    SetOffLineProgressListBox.Items.Add("Ready");
                    SetOffLineGroupBox.Enabled = true;
                }
                else
                {
                    OnLineArchivesListBox.Items.Add("No On-line Archives available");
                    SetOffLineGroupBox.Enabled = false;
                }

                // Get the list of Off-line-Archives that we can Attach
                sql = "EXEC " + databaseName + ".dbo.Archive_GetOffLineArchives 'ExwoldTracking' ";
                // Async Call
                DataTable OffLineArchivesDataTable = await AsyncExecQuery(db, sql);
                Thread.Sleep(250);
                if (OffLineArchivesDataTable.Rows.Count > 0)
                {
                    OffLineArchivesListBox.Items.Clear();
                    OffLineArchivesListBox.DataSource = OffLineArchivesDataTable;
                    OffLineArchivesListBox.DisplayMember = "DbName";
                    OffLineArchivesListBox.ValueMember = "DbName";
                    SetOnLineProgressListBox.Items.Add("Ready");
                    SetOnLineGroupBox.Enabled = true;
                }
                else
                {
                    OffLineArchivesListBox.Items.Add("No Off-line Archives available");
                    SetOnLineGroupBox.Enabled = false;
                }

                // set form maximised
                this.WindowState = FormWindowState.Maximized;
                this.MinimumSize = this.Size;
                this.MaximumSize = this.Size;
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, "EXCEPTION: " + ex.ToString());
            }

        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Handler for the ArchiveButton, runs the process:
        /// Backup live DB, restore as Archive, delete old data rom Live,
        /// delete new data from Archive, update Views
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ArchiveButton_Click(object sender, EventArgs e)
        {
            CloseButton.Enabled = false;
            try
            {
                string sql = "";
                string lastString = "";
                DateTime processStartDT = DateTime.Now;

                EnableDisableControls(false);
                ArchiveProgressListBox.Items.Clear();

                // Log ArchiveStart to Audit
                sql = "INSERT INTO " + databaseName + ".Audits.OperatorActions VALUES ( '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "', 'Database Archive starting, CutoffDate=" + ArchiveCutOffDate.Value.ToString("yyyy-MM-dd") + ", User=" + username + "' ) ";
                //### Async Call
                await AsyncExecuteNonQuery(db, sql);
                //db.ExecuteNonQuery(sql);

                // New Database Name
                string archiveDbName = "ExwoldTracking_" + ArchiveCutOffDate.Value.ToString("yyyyMMdd");

                // Does the selected New DB Name already exist?
                sql = "SELECT DbName FROM " + databaseName + ".Config.ArchiveDBs WHERE DbName = '" + archiveDbName + "' ";
                // Async Call
                DataTable dbNameDataTable = await AsyncExecQuery(db, sql);
                if (   dbNameDataTable != null
                    && dbNameDataTable.Rows.Count > 0)
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, "An archive for the selected date already exists:\r\n" + archiveDbName);
                    MessageBox.Show("An archive for the selected date already exists:\r\n" + archiveDbName, "Can't create archive");
                    ListBoxAddItemScrollDown(ArchiveProgressListBox, "An archive for the selected date already exists:" + archiveDbName);
                    EnableDisableControls(true);
                    CloseButton.Enabled = true;
                    return;
                }

                // Backup DB
                sqlMessages.Clear();
                lastString = "";
                ListBoxAddItemScrollDown(ArchiveProgressListBox, "Backing-up Live database");
                sql = "EXEC " + databaseName + ".dbo.Archive_BackupDatabase 'C:\\Temp\\', '" + databaseName + "', '" + ArchiveCutOffDate.Value.ToString("yyyy-MM-dd") + "' ";
                //### Async Call
                await AsyncExecuteNonQuery(db, sql);
                Thread.Sleep(500);
                //db.ExecuteNonQuery(sql);
                foreach (string message in sqlMessages)
                {
                    foreach (string s in message.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                    {
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, s);
                        lastString = s;
                    }
                }
                if (   sqlMessages.Count == 0
                    || (    sqlMessages.Count > 0
                        && !sqlMessages.Last<string>().ToUpper().Contains("SUCCESS"))
                    || !lastString.ToUpper().Contains("SUCCESS"))
                {
                    MessageBox.Show("Back-up failed, cannot continue.", "Can't create archive");
                    ListBoxAddItemScrollDown(ArchiveProgressListBox, "Back-up failed, cannot continue.");
                    EnableDisableControls(true);
                    CloseButton.Enabled = true;
                    return;
                }
                else
                {
                    ListBoxAddItemScrollDown(ArchiveProgressListBox, lastString);
                }

                // Restore the DB
                sqlMessages.Clear();
                lastString = "";
                ListBoxAddItemScrollDown(ArchiveProgressListBox, "Restoring database as Archive");
                sql = "EXEC " + databaseName + ".dbo.Archive_RestoreDatabase 'C:\\Temp\\', '" + databaseName + "', '" + ArchiveCutOffDate.Value.ToString("yyyy-MM-dd") + "' ";
                //### Async Call
                await AsyncExecuteNonQuery(db, sql);
                Thread.Sleep(500);
                //db.ExecuteNonQuery(sql);
                foreach (string message in sqlMessages)
                {
                    foreach (string s in message.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                    {
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, s);
                        lastString = s;
                    }
                }
                if (sqlMessages.Count == 0
                    || (sqlMessages.Count > 0
                        && !sqlMessages.Last<string>().ToUpper().Contains("SUCCESS"))
                    || !lastString.ToUpper().Contains("SUCCESS"))
                {
                    MessageBox.Show("Restore failed, cannot continue.", "Can't create archive");
                    ListBoxAddItemScrollDown(ArchiveProgressListBox, "Restore failed, cannot continue.");
                    EnableDisableControls(true);
                    CloseButton.Enabled = true;
                    return;
                }
                else
                {
                    ListBoxAddItemScrollDown(ArchiveProgressListBox, lastString);
                }

                // Get a connection to the new database
                Database newDb = new Database(dbConnStr.Replace(databaseName, archiveDbName));
                newDb.CommandTimeout = 3600000;
                newDb.dbConn.InfoMessage += new System.Data.SqlClient.SqlInfoMessageEventHandler(InfoMessageHandler);

                // Delete Current Data from the Archive DB
                sqlMessages.Clear();
                lastString = "";
                ListBoxAddItemScrollDown(ArchiveProgressListBox, "Deleting current (live) data from the archive database");
                sql = "EXEC " + databaseName + ".dbo.Archive_DeleteCurrentDataFromArchiveDB '" + databaseName + "', '" + ArchiveCutOffDate.Value.ToString("yyyy-MM-dd") + "' ";
                //### Async Call
                await AsyncExecuteNonQuery(db, sql);
                Thread.Sleep(500);
                //newDb.ExecuteNonQuery(sql);
                foreach (string message in sqlMessages)
                {
                    foreach (string s in message.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                    {
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, s);
                        lastString = s;
                    }
                }
                if (sqlMessages.Count == 0
                    || (sqlMessages.Count > 0
                        && !sqlMessages.Last<string>().ToUpper().Contains("SUCCESS"))
                    || !lastString.ToUpper().Contains("SUCCESS"))
                {

                    MessageBox.Show("Delete failed, cannot continue.", "Can't create archive");
                    ListBoxAddItemScrollDown(ArchiveProgressListBox, "Delete failed, cannot continue.");
                    EnableDisableControls(true);
                    CloseButton.Enabled = true;
                    return;
                }
                else
                {
                    ListBoxAddItemScrollDown(ArchiveProgressListBox, lastString);
                }

                // Deleting old (archived) data from Current Database
                sqlMessages.Clear();
                lastString = "";
                ListBoxAddItemScrollDown(ArchiveProgressListBox, "Deleting old (archived) data from Current Database");
                sql = "EXEC " + databaseName + ".dbo.Archive_DeleteOldDataFromCurrentDB '" + databaseName + "', '" + ArchiveCutOffDate.Value.ToString("yyyy-MM-dd") + "' ";
                //### Async Call
                await AsyncExecuteNonQuery(db, sql);
                Thread.Sleep(500);
                //db.ExecuteNonQuery(sql);
                foreach (string message in sqlMessages)
                {
                    foreach (string s in message.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                    {
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, s);
                        lastString = s;
                    }
                }
                if (sqlMessages.Count == 0
                    || (sqlMessages.Count > 0
                        && !sqlMessages.Last<string>().ToUpper().Contains("SUCCESS"))
                    || !lastString.ToUpper().Contains("SUCCESS"))
                {

                    MessageBox.Show("Delete failed, cannot continue.", "Can't create archive");
                    ListBoxAddItemScrollDown(ArchiveProgressListBox, "Delete failed, cannot continue.");
                    EnableDisableControls(true);
                    CloseButton.Enabled = true;
                    return;
                }
                else
                {
                    ArchiveProgressListBox.Items.Add(lastString);
                }

                // Update Views
                foreach (string viewName in viewsToUpdate)
                {
                    sqlMessages.Clear();
                    lastString = "";
                    ListBoxAddItemScrollDown(ArchiveProgressListBox, "Updating View: " + viewName);
                    sql = "EXEC " + databaseName + ".dbo.Archive_UpdateViews '" + databaseName + "', '" + viewName + "' ";
                    //### Async Call
                    await AsyncExecuteNonQuery(db, sql);
                    Thread.Sleep(500);
                    //db.ExecuteNonQuery(sql);
                    foreach (string message in sqlMessages)
                    {
                        foreach (string s in message.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                        {
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, s);
                            lastString = s;
                        }
                    }
                    if (sqlMessages.Count == 0
                        || (sqlMessages.Count > 0
                            && !sqlMessages.Last<string>().ToUpper().Contains("SUCCESS"))
                        || !lastString.ToUpper().Contains("SUCCESS"))
                    {
                        MessageBox.Show("Re-writing Views failed, cannot continue.", "Can't create archive");
                        ListBoxAddItemScrollDown(ArchiveProgressListBox, "Re-writing Views failed, cannot continue.");
                        EnableDisableControls(true);
                        CloseButton.Enabled = true;
                        return;
                    }
                    else
                    {
                        ListBoxAddItemScrollDown(ArchiveProgressListBox, lastString);
                    }
                }

                // Log Archive end to Audit
                sql = "INSERT INTO " + databaseName + ".Audits.OperatorActions VALUES ( '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "', 'Database Archive finished.' ) ";
                //### Async Call
                await AsyncExecuteNonQuery(db, sql);
                //db.ExecuteNonQuery(sql);

                ListBoxAddItemScrollDown(ArchiveProgressListBox, "Process started " + processStartDT.ToString("hh:mm:ss") + ", finished " + DateTime.Now.ToString("hh:mm:ss") + ", elapsed: " + DateTime.Now.Subtract(processStartDT).Duration().ToString("hh\\:mm\\:ss\\.fff"));
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, "EXCEPTION: " + ex.ToString());
            }
            CloseButton.Enabled = true;

        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Handles the SetOffLineButton, runs the process:
        /// Backup Archive, detach, Update Views
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SetOffLineButton_Click(object sender, EventArgs e)
        {
            CloseButton.Enabled = false;
            try
            {
                string sql = "";
                string lastString = "";
                DateTime processStartDT = DateTime.Now;

                // disable controls so nothing else can be done whilst this is running.
                EnableDisableControls(false);
                SetOffLineProgressListBox.Items.Clear();

                if (OnLineArchivesListBox.SelectedIndex >= 0)
                {
                    string onlineArchive = OnLineArchivesListBox.SelectedValue.ToString();

                    // Log ArchiveStart to Audit
                    sql = "INSERT INTO " + databaseName + ".Audits.OperatorActions VALUES ( '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "', 'Set Archive Offline starting for: " + onlineArchive + ", User=" + username +"' )";
                    //### Async Call
                    await AsyncExecuteNonQuery(db, sql);
                    //db.ExecuteNonQuery(sql);

                    // Backup DB
                    sqlMessages.Clear();
                    lastString = "";
                    ListBoxAddItemScrollDown(SetOffLineProgressListBox, "Backing-up Live database");
                    sql = "EXEC " + databaseName + ".dbo.Archive_BackupDatabase 'C:\\Temp\\', '" + onlineArchive + "', '" + ArchiveCutOffDate.Value.ToString("yyyy-MM-dd") + "' ";
                    //### Async Call
                    await AsyncExecuteNonQuery(db, sql);
                    Thread.Sleep(500);
                    //db.ExecuteNonQuery(sql);
                    foreach (string message in sqlMessages)
                    {
                        foreach (string s in message.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                        {
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, s);
                            lastString = s;
                        }
                    }
                    if (sqlMessages.Count == 0
                        || (sqlMessages.Count > 0
                            && !sqlMessages.Last<string>().ToUpper().Contains("SUCCESS"))
                        || !lastString.ToUpper().Contains("SUCCESS"))
                    {
                        MessageBox.Show("Back-up failed, cannot continue.", "Can't create archive");
                        ListBoxAddItemScrollDown(SetOffLineProgressListBox, "Back-up failed, cannot continue.");
                        EnableDisableControls(true);
                        CloseButton.Enabled = true;
                        return;
                    }
                    else
                    {
                        ListBoxAddItemScrollDown(SetOffLineProgressListBox, lastString);
                    }

                    // Detatching Database Old Data from the Current DB
                    sqlMessages.Clear();
                    lastString = "";
                    ListBoxAddItemScrollDown(SetOffLineProgressListBox, "Detaching database: " + onlineArchive);
                    sql = "Archive_DetachDatabase '" + onlineArchive + "' ";
                    //### Async Call
                    await AsyncExecuteNonQuery(db, sql);
                    Thread.Sleep(500);
                    //db.ExecuteNonQuery(sql);
                    foreach (string message in sqlMessages)
                    {
                        foreach (string s in message.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                        {
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, s);
                            lastString = s;
                        }
                    }
                    if (sqlMessages.Count == 0
                        || (sqlMessages.Count > 0
                            && !sqlMessages.Last<string>().ToUpper().Contains("SUCCESS"))
                        || !lastString.ToUpper().Contains("SUCCESS"))
                    {
                        MessageBox.Show("Back-up failed, cannot continue.", "Can't create archive");
                        ListBoxAddItemScrollDown(SetOffLineProgressListBox, "Back-up failed, cannot continue.");
                        EnableDisableControls(true);
                        CloseButton.Enabled = true;
                        return;
                    }
                    else
                    {
                        ListBoxAddItemScrollDown(SetOffLineProgressListBox, lastString);
                    }

                    // Update Views
                    foreach (string viewName in viewsToUpdate)
                    {
                        sqlMessages.Clear();
                        lastString = "";
                        ListBoxAddItemScrollDown(SetOffLineProgressListBox, "Updating View: " + viewName);
                        sql = "EXEC " + databaseName + ".dbo.Archive_UpdateViews '" + databaseName + "g', '" + viewName + "' ";
                        //### Async Call
                        await AsyncExecuteNonQuery(db, sql);
                        Thread.Sleep(500);
                        //db.ExecuteNonQuery(sql);
                        foreach (string message in sqlMessages)
                        {
                            foreach (string s in message.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                            {
                                Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, s);
                                lastString = s;
                            }
                        }
                        if (sqlMessages.Count == 0
                            || (sqlMessages.Count > 0
                                && !sqlMessages.Last<string>().ToUpper().Contains("SUCCESS"))
                            || !lastString.ToUpper().Contains("SUCCESS"))
                        {
                            MessageBox.Show("Re-writing Views failed, cannot continue.", "Can't create archive");
                            ListBoxAddItemScrollDown(SetOffLineProgressListBox, "Re-writing Views failed, cannot continue.");
                            EnableDisableControls(true);
                            CloseButton.Enabled = true;
                            return;
                        }
                        else
                        {
                            ListBoxAddItemScrollDown(SetOffLineProgressListBox, lastString);
                        }
                    }

                    // Log ArchiveStart to Audit
                    sql = "INSERT INTO " + databaseName + ".Audits.OperatorActions VALUES ( '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "', 'Set Archive Offline finished for: '" + onlineArchive + "' ) ";
                    //### Async Call
                    await AsyncExecuteNonQuery(db, sql);
                    //db.ExecuteNonQuery(sql);

                    ListBoxAddItemScrollDown(SetOffLineProgressListBox, "Success.");
                    ListBoxAddItemScrollDown(SetOffLineProgressListBox, "The backup:");
                    ListBoxAddItemScrollDown(SetOffLineProgressListBox, "     C:\\Temp\\" + onlineArchive + ".bkf");
                    ListBoxAddItemScrollDown(SetOffLineProgressListBox, "and the detached database files");
                    ListBoxAddItemScrollDown(SetOffLineProgressListBox, "     " + onlineArchive + ".mdf");
                    ListBoxAddItemScrollDown(SetOffLineProgressListBox, "     " + onlineArchive + "_log.ldf");
                    ListBoxAddItemScrollDown(SetOffLineProgressListBox, "may now be copied from the server");
                    ListBoxAddItemScrollDown(SetOffLineProgressListBox, "to DVD or similar");
                }
                ListBoxAddItemScrollDown(SetOffLineProgressListBox, "Process started " + processStartDT.ToString("hh:mm:ss") + ", finished " + DateTime.Now.ToString("hh:mm:ss") + ", elapsed: " + DateTime.Now.Subtract(processStartDT).Duration().ToString("hh\\:mm\\:ss\\.fff"));

            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, "EXCEPTION: " + ex.ToString());
            }
            CloseButton.Enabled = true;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Handles the SetOnLineButton, runs the process:
        /// Attach DB, Update Views
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SetOnLineButton_Click(object sender, EventArgs e)
        {
            CloseButton.Enabled = false;
            try
            {
                string sql = "";
                string lastString = "";
                DateTime processStartDT = DateTime.Now;

                // disable controls so nothing else can be done whilst this is running.
                EnableDisableControls(false);

                if (OffLineArchivesListBox.SelectedIndex >= 0)
                {
                    string offlineArchive = OffLineArchivesListBox.SelectedValue.ToString();

                    // Log ArchiveStart to Audit
                    sql = "INSERT INTO " + databaseName + ".Audits.OperatorActions VALUES ( '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "', 'Set Archive Online starting for: " + offlineArchive + ", User=" + username + "' ) ";
                    //### Async Call
                    await AsyncExecuteNonQuery(db, sql);
                    Thread.Sleep(500);
                    //db.ExecuteNonQuery(sql);

                    // so we have DB to attach...
                    // Does the selected New DB Name already exist?
                    sql = "SELECT DbName FROM Config.ArchiveDBs WHERE DbName = '" + offlineArchive + "' ";
                    DataTable dbNameDataTable = db.ExecuteQuery(sql);
                    if (dbNameDataTable.Rows.Count > 0)
                    {
                        MessageBox.Show("An archive for the selected file already exists:\r\n" + offlineArchive, "Can't create archive");
                        ListBoxAddItemScrollDown(SetOnLineProgressListBox, "An archive for the selected file already exists:" + offlineArchive);
                        EnableDisableControls(true);
                        CloseButton.Enabled = true;
                        return;
                    }

                    // Attach
                    sqlMessages.Clear();
                    lastString = "";
                    ListBoxAddItemScrollDown(SetOnLineProgressListBox, "Attaching Database " + offlineArchive);
                    sql = "Archive_AttachDatabase '" + offlineArchive + "' ";
                    //### Async Call
                    await AsyncExecuteNonQuery(db, sql);
                    Thread.Sleep(500);
                    //db.ExecuteNonQuery(sql);
                    foreach (string message in sqlMessages)
                    {
                        foreach (string s in message.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                        {
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, s);
                            lastString = s;
                        }
                    }
                    if (sqlMessages.Count == 0
                        || (sqlMessages.Count > 0
                            && !sqlMessages.Last<string>().ToUpper().Contains("SUCCESS"))
                        || !lastString.ToUpper().Contains("SUCCESS"))
                    {
                        MessageBox.Show("Attach failed, cannot continue.", "Can't create archive");
                        ListBoxAddItemScrollDown(SetOnLineProgressListBox, "Attach failed, cannot continue.");
                        EnableDisableControls(true);
                        CloseButton.Enabled = true;
                        return;
                    }
                    else
                    {
                        ListBoxAddItemScrollDown(SetOnLineProgressListBox, lastString);
                    }

                    // Update Views
                    foreach (string viewName in viewsToUpdate)
                    {
                        sqlMessages.Clear();
                        lastString = "";
                        ListBoxAddItemScrollDown(SetOnLineProgressListBox, "Updating View: " + viewName);
                        sql = "EXEC " + databaseName + ".dbo.Archive_UpdateViews '" + databaseName + "', '" + viewName + "' ";
                        //### Async Call
                        await AsyncExecuteNonQuery(db, sql);
                        Thread.Sleep(500);
                        //db.ExecuteNonQuery(sql);
                        foreach (string message in sqlMessages)
                        {
                            foreach (string s in message.Split(new string[] { "\r\n" }, StringSplitOptions.None))
                            {
                                Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, s);
                                lastString = s;
                            }
                        }
                        if (sqlMessages.Count == 0
                            || (sqlMessages.Count > 0
                                && !sqlMessages.Last<string>().ToUpper().Contains("SUCCESS"))
                            || !lastString.ToUpper().Contains("SUCCESS"))
                        {
                            MessageBox.Show("Re-writing Views failed, cannot continue.", "Can't create archive");
                            ListBoxAddItemScrollDown(SetOnLineProgressListBox, "Re-writing Views failed, cannot continue.");
                            EnableDisableControls(true);
                            CloseButton.Enabled = true;
                            return;
                        }
                        else
                        {
                            ListBoxAddItemScrollDown(SetOnLineProgressListBox, lastString);
                        }
                    }

                    // Log ArchiveStart to Audit
                    sql = "INSERT INTO ExwoldTracking.Audits.OperatorActions VALUES ( '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "', 'Set Archive Online finished for: '" + offlineArchive + "' ) ";
                    //### Async Call
                    await AsyncExecuteNonQuery(db, sql);
                    //db.ExecuteNonQuery(sql);

                }
                ListBoxAddItemScrollDown(SetOnLineProgressListBox, "Process started " + processStartDT.ToString("hh:mm:ss") + ", finished " + DateTime.Now.ToString("hh:mm:ss") + ", elapsed: " + DateTime.Now.Subtract(processStartDT).Duration().ToString("hh\\:mm\\:ss\\.fff"));
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, "EXCEPTION: " + ex.ToString());
            }
            CloseButton.Enabled = true;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Add the item to teh listbox, scroll to bottom, then refresh.
        /// </summary>
        /// <param name="listbox">ListBox to add the data to</param>
        /// <param name="item">string to add</param>
        private void ListBoxAddItemScrollDown(ListBox listbox, string item)
        {
            listbox.Items.Add(item);
            listbox.TopIndex = listbox.Items.Count - 1;
            listbox.Refresh();
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Enables/Diables controls to stop 
        /// </summary>
        /// <param name="enable">True to enable controls; False to disable</param>
        private void EnableDisableControls(bool enable)
        {
            // disable controls so nothing else can be done whilst this is running.
            ArchiveButton.Enabled = enable;
            SetOffLineButton.Enabled = enable;
            SetOnLineButton.Enabled = enable;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Don't allow form close while the Archive peocessesa re running
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatabaseMaintenance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseButton.Enabled == false)
            {
                MessageBox.Show("The archive process is running,\r\ncannot close the form at this time.\r\n\r\nPlease wait.", "Archive processes running.");
                e.Cancel = true;
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Close the form when the close button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Async wrapper for the database.AsyncExecQuery() calls
        /// </summary>
        /// <param name="database">Database object to use</param>
        /// <param name="sql">SQL to run</param>
        /// <returns></returns>
        private Task<DataTable> AsyncExecQuery(Database database, string sql)
        {
            return Task.Run(() => database.ExecuteQuery(sql));
        }

        /// <summary>
        /// Async wrapper for the database.ExecuteNonQuery() calls
        /// </summary>
        /// <param name="database">Database object to use</param>
        /// <param name="sql">SQL to run</param>
        /// <returns></returns>
        private Task<int> AsyncExecuteNonQuery(Database database, string sql)
        {
            return Task.Run(() => database.ExecuteNonQuery(sql));
        }


    }
}
