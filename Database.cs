///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Project:    702385 - Exwold - Exwold scanner - Database.cs
//  Copyright:  (c) Copyright 2017 Industrial Technology Systems Ltd. All Rights Reserved.
//
//  Description:
//  Creates and maintains a connection to a SQL server database, includes methods to run Queries and Non-Queries.
//
// FileVersion  ProgVersion Date        Project/CRF.    Who                 References
//      1.00      1.00.00.00 22Mar2017   702385          Colin Robinson      DN002
//              Initial issue
//      1.01     1.03.00.00 30Jan2018   991068/CRF003   Martin Cox
//              Added more debug logging 
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;


namespace ExwoldPcInterface
{
    public class Database
    {

        private const string moduleName = "Database.";

        public SqlConnection dbConn;
        private string dbConnStr = "";

        public int CommandTimeout = 120;

        public Database()
        {
        }
        public Database(string newDbConnStr)
        {
            this.dbConnStr = newDbConnStr;
            OpenConnection(false, this.dbConnStr);
        }

        // OpenConnection(), opens the DB conection, with option to force a new connection.
        public int OpenConnection()
        {
            return OpenConnection(false, this.dbConnStr);
        }
        public int OpenConnection(bool forceNewConnection)
        {
            return OpenConnection(forceNewConnection, this.dbConnStr);
        }
        public int OpenConnection(bool forceNewConnection, string dbConnStr)
        {
            const string methodName = moduleName + "OpenConnection(): ";
            int status = 1;
            long counter;
            Program.Log.LogMessage(ThreadLog.DebugLevel.Information, methodName + "Starting");

            try
            {
                if ((dbConn == null) || (forceNewConnection == true))
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Instantiating _dbConn");
                    dbConn = new SqlConnection();
                }

                if (dbConn.State != ConnectionState.Open)
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "DBConnStr=" + dbConnStr);

                    dbConn.ConnectionString = dbConnStr;
                    dbConn.Open();

                    counter = 0;
                    while ((dbConn.State != ConnectionState.Open) && (counter < 100))
                    {
                        System.Threading.Thread.Sleep(10);
                        counter += 1;
                    }
                    if (counter >= 100)
                    {
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Error, methodName + "Timeout connecting to Database");
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, methodName + "EXCEPTION: " + ex.ToString());
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, methodName + "DBConnStr= " + dbConnStr);
                status = 0;
            }
            Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Finished");
            return status;
        }


        public int ExecuteNonQuery(string query)
        {
            const string methodName = moduleName + "ExecuteNonQuery(): ";
            int result = 0;

            if (dbConn.State != ConnectionState.Open)
            {
                OpenConnection(false);
            }

            try
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + query);
                SqlCommand cmd = new SqlCommand();
                cmd = dbConn.CreateCommand();
                cmd.CommandTimeout = CommandTimeout;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "EXCEPTION: " + ex.ToString());
            }
            return result;
        }

        public DataTable ExecuteQuery(string query)
        {
            const string methodName = moduleName + "ExecuteQuery(): ";

            if (dbConn.State != ConnectionState.Open)
            {
                OpenConnection(false);
            }
            try
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + query);
                SqlDataAdapter adapter = new SqlDataAdapter(query, dbConn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Table");
                DataTable dt = ds.Tables["Table"];
                return dt;
            }
            catch (SqlException ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "EXCEPTION: " + ex.ToString());
                return null;
            }
        }


        public void SaveDataToRemoteDataBase(string procName, DataTable table)
        {
            const string methodName = moduleName + "SaveDataToRemoteDataBase(): ";
            try
            {
                // is there data to save?
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "Starting");
                if (table.Rows.Count > 0)
                {
                    if (dbConn.State != ConnectionState.Open)
                    {
                        OpenConnection(false);
                    }

                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Saving to server DB, row count= " + table.Rows.Count.ToString());

                    using (var cmd = new SqlCommand(procName, dbConn))
                    {
                        Program.Log.LogMessage(0, methodName + "Running SP " + procName);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = CommandTimeout;
                        SqlParameter param = cmd.Parameters.AddWithValue("@DataTable", table);
                        param.SqlDbType = SqlDbType.Structured;
                        int rowsUpdated = cmd.ExecuteNonQuery();
                        if (rowsUpdated != table.Rows.Count)
                        {
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Saving to REMOTE DB, saved " + rowsUpdated + " out of " + table.Rows.Count);
                        }
                    }
                }
                else
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, methodName + " No data to save");
                }
            }
            catch (Exception e)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, methodName + "EXCEPTION: " + e.ToString());
            }
        }
        /// <summary>
        /// 702385  CollectTableFromRemoteDataBase
        ///         Collects a table generated by a procedure from the server if available
        ///         Returns null if not
        /// V1 - 2017-03-23 - creation CAR  
        /// </summary>
        /// <param name="procName">The name of the procedure to call</param>
        /// <returns>Datatable containing results of procedure</returns>
        public DataTable CollectTableFromRemoteDataBase(string procName, List<SqlParameter> parameters)
        {
            const string methodName = moduleName + "CollectTableFromRemoteDataBase(): ";
            try
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "Starting");
                if (dbConn.State != ConnectionState.Open)
                {
                    OpenConnection(false);
                    if (dbConn.State != ConnectionState.Open)
                    {
                        Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Unable to connect to database");
                        return null;
                    }
                }
                
                DataTable dataTable = new DataTable();

                using (var cmd = new SqlCommand(procName, dbConn))
                {
                    Program.Log.LogMessage(0, methodName + "Running SP " + procName);
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    cmd.CommandTimeout = CommandTimeout;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dataTable);
                    da.Dispose();
                }
                return dataTable;
            }
            catch (Exception e)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, methodName + "EXCEPTION: " + e.ToString());
                return null;
            }
        }

    }

}
