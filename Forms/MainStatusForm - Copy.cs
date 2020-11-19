//******************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd.
// All Rights Reserved.
//
// DISCUSSION
// Provides an interface to :
//  1)  Get Current production line data and display to user
//  2)  Process incoming messages from the scanner
//  3)  Give user buttons to access all other functions of the application
//
// MODIFICATION HISTORY
// FileVersion  ProgVersion  Date        Project/CRF.    Who                     References
//     1.00      1.00.00.00  04Apr2017   702678          Stuart Eglington 
//              Initial Creation
//     1.01      1.03.00.00  30Jan2018   991068/CRF002   Martin Cox
//              Added SDK directory to config file, and associacted changes
//     1.02      1.4.0.0  13Dec2018   991068/CRF003  Colin Robinson
//              Added button to open ReprintPalletLabels, and added function to process reprint when called
//
//******************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ITS.Exwold.Desktop
{
    public partial class MainStatusFormCopy : Form
    {
        int _siteNumber;
        string sql;
        string statusText;
        int status1;
        int status2;
        int status3;
        int Line1BatchID;
        int Line2BatchID;
        int Line3BatchID;
        private string messageFromScanner;
        private string DBConnectionString = "";

        private const string moduleName = "Line-Status:";


        /// <summary>
        /// V2.00 - Removed DbNightlyBackup
        /// </summary>
        //private static DbNightlyBackup dbNightlyBackup;
    
        private void MainStatusForm_Load(object sender, EventArgs e)
        {
            const string methodName = moduleName + "MainStatusForm_Load(): ";

            //set fullscreen
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            //// set-up debug logging
            //string logPath = "";
            //string appName = "";
            //int logLevel = 0;
            //string DatabaseBackupsDaysToKeep = "";
            //string DatabaseBackupPath = "";

            //Config.ReadConfig(
            //    ref _siteNumber,
            //    ref logPath,
            //    ref appName,
            //    ref logLevel,
            //    ref DBConnectionString,
            //    ref DatabaseBackupsDaysToKeep,
            //    ref DatabaseBackupPath,
            //    ref Program.NiceLabelSDKPath);
            Program.Log = new ThreadLog();
            Program.Log.Initialise(@"C:\Debug", "Exwold_PC_Interface", 15, ThreadLog.DebugLevel.Debug, false);
            Program.Log.StartLogging();

            try
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, moduleName + "DBConnectionString = " + DBConnectionString);
                //Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, moduleName + "DatabaseBackupsDaysToKeep = " + DatabaseBackupsDaysToKeep);
                //Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, moduleName + "DatabaseBackupPath = " + DatabaseBackupPath);
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, moduleName + "NiceLabelSDKPath = " + Program.NiceLabelSDKPath);

                Program.ExwoldDb = new Database(DBConnectionString); //even if it can't connect it will set the connection string 

                // V2 - Removed dbNightlyBackup
                // instanciate the dbNightlbackup control (which will trigger backups just after midnight)
                //dbNightlyBackup = new DbNightlyBackup(DBConnectionString, DatabaseBackupsDaysToKeep, DatabaseBackupPath);

                Program.ScannerServers = new List<TCPServer>();

                //set up a list of servers, one for each scanner
                string ScannerPortStart = ConfigurationManager.AppSettings["ScannerPortStart"];
                int localPort = Convert.ToUInt16(ScannerPortStart);
                int numberOfScanners = Convert.ToUInt16(ConfigurationManager.AppSettings["NumberOfScanners"]);
                for (int port = localPort; port < localPort + numberOfScanners; port++)
                {
                    TCPServer server = new TCPServer(ref Program.Log, port);
                    Program.ScannerServers.Add(server);
                }
                timerScannerMessages.Enabled = true;
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, moduleName + "EXCEPTION: Loading config error: " + ex.Message);
            }
            GetLineData();
            Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Main Form Loaded");
        }
        public MainStatusFormCopy()
        {      
            InitializeComponent();
        }

        private void button_setBatch_Click(object sender, EventArgs e)
        {
            UserAuthentication auth = new UserAuthentication();
            auth.ShowDialog();
            if (auth.Supervisor)
            {
                PalletForm form2 = new PalletForm();
                form2.ShowDialog();
                GetLineData();
            }
        }

        private void button_setProduct_Click(object sender, EventArgs e)
        {
            UserAuthentication auth = new UserAuthentication();
            auth.ShowDialog();
            if (auth.Supervisor)
            {
                ProductForm form10 = new ProductForm();
                form10.ShowDialog();
                const string methodName = moduleName + "button_setProduct_Click(): ";
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Open Product Maintenance Form");
            }
        }

        private void button_exitPalletTracking_Click(object sender, EventArgs e)
        {
            UserAuthentication auth = new UserAuthentication();
            auth.ShowDialog();
            if (auth.Supervisor)
            {
                Program.Log.logSave();
//V2 Only kill windows is not in DEBUG
#if !DEBUG
                ExitWindowsEx(0, 0);
#endif     
                this.Close();
                const string methodName = moduleName + "button_exitPalletTracking_Click(): ";
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Exit Application");
                Program.Log.logSave();
            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private extern static bool ExitWindowsEx(uint uFlags, uint dwReason);
        private void button_editLine1_Click(object sender, EventArgs e)
        {
            BatchDetailsForm form4 = new BatchDetailsForm();
            form4.ViewBatchFlag = "True";
            //form4.ViewBatchID = Convert.ToString(Line1BatchID);
            form4.ShowDialog();
            GetLineData();
            const string methodName = moduleName + "button_editLine1_Click(): ";
            Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Edit Line 1");
        }
        private void button_editLine2_Click(object sender, EventArgs e)
        {
            BatchDetailsForm form4 = new BatchDetailsForm();
            form4.ViewBatchFlag = "True";
            //form4.ViewBatchID = Convert.ToString(Line2BatchID);
            form4.ShowDialog();
            GetLineData();
            const string methodName = moduleName + "button_editLine1_Click(): ";
            Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Edit Line 2");
        }
        private void button_editLine3_Click(object sender, EventArgs e)
        {
            BatchDetailsForm form4 = new BatchDetailsForm();
            form4.ViewBatchFlag = "True";
            //form4.ViewBatchID = Convert.ToString(Line3BatchID);
            form4.ShowDialog();
            GetLineData();
            const string methodName = moduleName + "button_editLine1_Click(): ";
            Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Edit Line 3");
        }

        private void timerScannerMessages_Tick(object sender, EventArgs e)
        {
            int scannerNumber = 1;
            foreach (TCPServer server in Program.ScannerServers)
            {
                if (server.response.Count > 0)
                {
                    string scannerMessage = Encoding.Default.GetString(server.response.ToArray(), 0, server.response.Count);
                    server.response.Clear();
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "timerScannerMessages_Tick() Handling scanner " + scannerNumber.ToString() + "   message  = " + scannerMessage.Substring(0, scannerMessage.Length - 2));
                    string response = HandleMessage(scannerNumber, scannerMessage.Substring(0, scannerMessage.Length - 2));
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "timerScannerMessages_Tick() Handling scanner " + scannerNumber.ToString() + "   response = " + response);
                    server.WinsockSend(response + Environment.NewLine);
                }
                scannerNumber++;
            }
        }
        public string HandleMessage(int ScannerNumber, string message)
        {
          try
          {
            messageFromScanner = message;
            if (messageFromScanner.StartsWith("UPDATE"))
            {
              //do update code
              GetLineData();
              const string methodName = moduleName + "HandleMessage(): ";
              Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Update - run GetLineData");
              return "OK";
            }
            else if (messageFromScanner.StartsWith("PRINT") || messageFromScanner.StartsWith("REPRINT"))
            {
              String BatchNumber = messageFromScanner.Split(':').Last();
              sql = "SELECT * " +
                    "FROM   data.PalletBatch " +
                    "INNER JOIN data.Pallet " +
                    "ON     Data.PalletBatch.PalletBatchUniqueNo = Pallet.PalletBatchUniqueNo " +
                    "WHERE  Pallet.PalletUniqueNo = " + BatchNumber;
              DataTable dtCurrentBatch = Program.ExwoldDb.ExecuteQuery(sql);
              int rows = dtCurrentBatch.Rows.Count;

              if (rows == 1)
              {
                int myAction = dtCurrentBatch.Rows[0].Field<Int16>("Status");

                if (myAction != 1)
                {
                  return "CANCELLED";
                }
                else
                {
                  System.ComponentModel.BackgroundWorker backgroundWorkerPrintLabel = new BackgroundWorker();
                  backgroundWorkerPrintLabel.DoWork += BackgroundWorkerPrintLabel_DoWork;
                  backgroundWorkerPrintLabel.RunWorkerAsync();
                  return "OK";
                }
              }
              else return "ERROR";
            }
            else return "ERROR";
          }
          catch (Exception ex)
          {
            Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, "EXCEPTION: " + ex.ToString());
            return "";
          }
        }

 
        private void GetLineData()
        {
            #region Site Wide Info
            //Clear old data from the grid views
            this.dgvReadyToPrint.DataSource = null;
            this.dgvReadyToPrint.Refresh();

            this.dgvOnHold.DataSource = null;
            this.dgvOnHold.Refresh();

            //Popuplate the grid views
            //[GUI].[GetPalletBatchByStatus] @Status, @Site

            // On-Hold = 2
            DataTable dtOnHold = Program.ExwoldDb.ExecuteSP("[GUI].[GetPalletBatchByStatus]",
                new SqlParameter[]
                {
                    new SqlParameter("status", Helper.BatchStatus.OnHold),
                    new SqlParameter("Site", _siteNumber)
                });
            if (dtOnHold.Rows.Count > 0)
            {
                this.dgvOnHold.DataSource = dtOnHold;
            }

            // Ready To Print = 4
            DataTable dtReadyToPrint = Program.ExwoldDb.ExecuteSP("[GUI].[GetPalletBatchByStatus]",
                new SqlParameter[] 
                { 
                    new SqlParameter("status", Helper.BatchStatus.ReadyToPrint), 
                    new SqlParameter("Site", _siteNumber)
                });
            if (dtReadyToPrint.Rows.Count > 0)
            {
                this.dgvReadyToPrint.DataSource = dtReadyToPrint;
            }
            //Clear the contents of any text boxes
            ITS.Exwold.Desktop.Helper.ClearTextBoxes(this);

            #endregion
            this.dataGridView4.DataSource = null;
            this.dataGridView4.Refresh();
            this.dataGridView5.DataSource = null;
            this.dataGridView5.Refresh();
            this.dataGridView6.DataSource = null;
            this.dataGridView6.Refresh();


            //////Get ReadyTo Print Data
            //////Mesh [GUI].[GetPalletBatchNumbers] @Status, @Site
            ////sql = "SELECT PalletBatchNo FROM data.PalletBatch WHERE status = 4";
            ////DataTable dtReadyToPrint = Program.ExwoldDb.ExecuteQuery(sql);
            ////if (dtReadyToPrint.Rows.Count > 0)
            ////{
            ////    this.dgvReadyToPrint.DataSource = dtReadyToPrint;
            ////}

            //////Get OnHold Data
            ////sql = "SELECT PalletBatchNo FROM data.PalletBatch WHERE status = 2";
            ////DataTable dtOnHold = Program.ExwoldDb.ExecuteQuery(sql);
            ////if (dtOnHold.Rows.Count > 0)
            ////{
            ////    this.dgvOnHold.DataSource = dtOnHold;
            ////}

            //Get Current Batch For Line1
            //Mesh [GUI].[GetPalletBatch] @Status, @Site, @LineNumber
            sql = "SELECT * FROM data.PalletBatch WHERE ProductionLineNo = 1 AND (status = 1 )";
            DataTable dtCurrentBatch1 = Program.ExwoldDb.ExecuteQuery(sql);
            switch (dtCurrentBatch1.Rows.Count)
            {
                case 0:
                    labelStatus1.Text = "Not Running";
                    labelStatus1.ForeColor = System.Drawing.Color.Black;
                    button_editLine1.Visible = false;
                    break;
                case 1:
                    Line1BatchID = Convert.ToInt32(dtCurrentBatch1.Rows[0].Field<Int64>("PalletBatchUniqueNo"));

                    sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchUniqueNo = " + Line1BatchID;
                    DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                    textBoxPalletBatchNo1.Text = dtCurrentProduct.Rows[0].Field<string>("PalletBatchNo");
                    textBoxCustomer1.Text = dtCurrentProduct.Rows[0].Field<string>("Customer");
                    textBoxProdName1.Text = dtCurrentProduct.Rows[0].Field<string>("ProductName");
                    textBoxTotalCartons1.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("TotalNoOfCartons"));
                    textBoxNotes1.Text = dtCurrentProduct.Rows[0].Field<string>("AdditionalInfo");

                    //convert Status to human readable , set colour and text
                    status1 = dtCurrentProduct.Rows[0].Field<Int16>("Status");

                switch (status1)
                {
                    case 0:
                        statusText = "Available";
                        labelStatus1.ForeColor = System.Drawing.Color.Black;
                        button_editLine1.Visible = false;
                        break;
                    case 1:
                        statusText = "In-Progress";
                        labelStatus1.ForeColor = System.Drawing.Color.Green;
                        button_editLine1.Visible = true;
                        break;
                    case 2:
                        statusText = "On-Hold";
                        labelStatus1.ForeColor = System.Drawing.Color.Black;
                        button_editLine1.Visible = true;
                        break;
                    case 3:
                        statusText = "Ready to Print";
                        labelStatus1.ForeColor = System.Drawing.Color.Green;
                        button_editLine1.Visible = true;
                        break;
                    case 4:
                        statusText = "Completed";
                        labelStatus1.ForeColor = System.Drawing.Color.Black;
                        button_editLine1.Visible = false;
                        break;
                    case 5:
                        statusText = "Stopped";
                        labelStatus1.ForeColor = System.Drawing.Color.Black;
                        button_editLine1.Visible = false;
                        break;
                }
                labelStatus1.Text = statusText;
              //Get batches/carton number on Pallet

                    sql = "SELECT data.PalletLabel.MaterialBatchNo, data.PalletLabel.CartonsOnPallet, data.Pallet.PalletUniqueNo FROM data.Pallet LEFT JOIN data.PalletLabel ON data.PalletLabel.PalletUniqueNo = data.Pallet.PalletUniqueNo WHERE data.Pallet.PalletBatchUniqueNo =" + Line1BatchID;
                    DataTable dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);
                    sql = "SELECT DISTINCT data.PalletLabel.MaterialBatchNo FROM data.Pallet LEFT JOIN data.PalletLabel ON data.PalletLabel.PalletUniqueNo = data.Pallet.PalletUniqueNo WHERE data.Pallet.PalletBatchUniqueNo =" + Line1BatchID;
                    DataTable dtCurrentPalletView = Program.ExwoldDb.ExecuteQuery(sql);
                    if (dtCurrentPallet.Rows.Count > 0)
                    {
                        this.dataGridView4.DataSource = dtCurrentPalletView;
                        object sumObject;
                        sumObject = dtCurrentPallet.Compute("Sum(CartonsOnPallet)", "");
                        textBoxCartonsOnPallet1.Text = sumObject.ToString();
                    }
                    break;
                default:
                    labelStatus1.Text = "ERROR \r\nMultiple batches \r\nidentified";
                    labelStatus1.ForeColor = System.Drawing.Color.Red;
                    button_editLine1.Visible = false;
                    break;
          }
            
            const string methodName = moduleName + "GetLineData(): ";
            Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Line 1 returned " + dtCurrentBatch1.Rows.Count + " batches");

            //Get Current Batch For Line2
            sql = "SELECT * FROM data.PalletBatch WHERE ProductionLineNo = 2 AND (status = 1 )";
            DataTable dtCurrentBatch2 = Program.ExwoldDb.ExecuteQuery(sql);
            switch (dtCurrentBatch2.Rows.Count)
            {
                case 0:
                    labelStatus2.Text = "Not Running";
                    labelStatus2.ForeColor = System.Drawing.Color.Black;
                    button_editLine2.Visible = false;
                    break;
                case 1:
                    Line2BatchID = Convert.ToInt32(dtCurrentBatch2.Rows[0].Field<Int64>("PalletBatchUniqueNo"));
                    sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchUniqueNo = " + Line2BatchID;
                    DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                    textBoxPalletBatchNo2.Text = dtCurrentProduct.Rows[0].Field<string>("PalletBatchNo");
                    textBoxCustomer2.Text = dtCurrentProduct.Rows[0].Field<string>("Customer");
                    textBoxProdName2.Text = dtCurrentProduct.Rows[0].Field<string>("ProductName");
                    textBoxTotalCartons2.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("TotalNoOfCartons"));
                    textBoxNotes2.Text = dtCurrentProduct.Rows[0].Field<string>("AdditionalInfo");

                    //convert Status to human readable , set colour and text
                    status2 = dtCurrentProduct.Rows[0].Field<Int16>("Status");

                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Getting data for batch " + Line2BatchID + ". Status = " + status2);

                    switch (status2)
                {
                    case 0:
                        statusText = "Available";
                        labelStatus2.ForeColor = System.Drawing.Color.Black;
                        button_editLine2.Visible = false;
                        break;
                    case 1:
                        statusText = "In-Progress";
                        labelStatus2.ForeColor = System.Drawing.Color.Green;
                        button_editLine2.Visible = true;
                        break;
                    case 2:
                        statusText = "On-Hold";
                        labelStatus2.ForeColor = System.Drawing.Color.Black;
                        button_editLine2.Visible = true;
                        break;
                    case 3:
                    statusText = "Ready to Print";
                        labelStatus2.ForeColor = System.Drawing.Color.Green;
                        button_editLine2.Visible = true;
                        break;
                    case 4:
                        statusText = "Completed";
                        labelStatus2.ForeColor = System.Drawing.Color.Black;
                        button_editLine2.Visible = false;
                        break;
                    case 5:
                        statusText = "Stopped";
                        labelStatus2.ForeColor = System.Drawing.Color.Black;
                        button_editLine2.Visible = false;
                        break;
                }
                    labelStatus2.Text = statusText;

                    //Get batches/carton number on Pallet
                    sql = "SELECT data.PalletLabel.MaterialBatchNo, data.PalletLabel.CartonsOnPallet, data.Pallet.PalletUniqueNo FROM data.Pallet LEFT JOIN data.PalletLabel ON data.PalletLabel.PalletUniqueNo = data.Pallet.PalletUniqueNo WHERE data.Pallet.PalletBatchUniqueNo =" + Line2BatchID;
                    DataTable dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);
                    sql = "SELECT DISTINCT data.PalletLabel.MaterialBatchNo FROM data.Pallet LEFT JOIN data.PalletLabel ON data.PalletLabel.PalletUniqueNo = data.Pallet.PalletUniqueNo WHERE data.Pallet.PalletBatchUniqueNo =" + Line2BatchID;
                    DataTable dtCurrentPalletView = Program.ExwoldDb.ExecuteQuery(sql);
                    if (dtCurrentPallet.Rows.Count > 0)
                    {
                        this.dataGridView5.DataSource = dtCurrentPalletView;
                        object sumObject;
                        sumObject = dtCurrentPallet.Compute("Sum(CartonsOnPallet)", "");
                        textBoxCartonsOnPallet2.Text = sumObject.ToString();
                    }
                    break;
                default:
                    labelStatus2.Text = "ERROR \r\nMultiple batches \r\nidentified";
                    labelStatus2.ForeColor = System.Drawing.Color.Red;
                    button_editLine2.Visible = false;
                    break;
            }

            Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Line 2 returned " + dtCurrentBatch2.Rows.Count + " batches");

            //Get Current Batch For Line3
            sql = "SELECT * FROM data.PalletBatch WHERE ProductionLineNo = 3 AND (status = 1)";
            DataTable dtCurrentBatch3 = Program.ExwoldDb.ExecuteQuery(sql);
            switch (dtCurrentBatch3.Rows.Count)
            {
                case 0:
                    labelStatus3.Text = "Not Running";
                    labelStatus3.ForeColor = System.Drawing.Color.Black;
                    button_editLine3.Visible = false;
                    break;
                case 1:
                    Line3BatchID = Convert.ToInt32(dtCurrentBatch3.Rows[0].Field<Int64>("PalletBatchUniqueNo"));

                    sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchUniqueNo = " + Line3BatchID;
                    DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
                    textBoxPalletBatchNo3.Text = dtCurrentProduct.Rows[0].Field<string>("PalletBatchNo");
                    textBoxCustomer3.Text = dtCurrentProduct.Rows[0].Field<string>("Customer");
                    textBoxProdName3.Text = dtCurrentProduct.Rows[0].Field<string>("ProductName");
                    textBoxTotalCartons3.Text = Convert.ToString(dtCurrentProduct.Rows[0].Field<int>("TotalNoOfCartons"));
                    textBoxNotes3.Text = dtCurrentProduct.Rows[0].Field<string>("AdditionalInfo");

                    //convert Status to human readable , set colour and text
                    status3 = dtCurrentProduct.Rows[0].Field<Int16>("Status");

                    switch (status3)
                    {
                        case 0:
                            statusText = "Available";
                            labelStatus3.ForeColor = System.Drawing.Color.Black;
                            button_editLine3.Visible = false;
                            break;
                        case 1:
                            statusText = "In-Progress";
                            labelStatus3.ForeColor = System.Drawing.Color.Green;
                            button_editLine3.Visible = true;
                            break;
                        case 2:
                            statusText = "On-Hold";
                            labelStatus3.ForeColor = System.Drawing.Color.Black;
                            button_editLine3.Visible = true;
                            break;
                        case 3:
                            statusText = "Ready to Print";
                            labelStatus3.ForeColor = System.Drawing.Color.Green;
                            button_editLine3.Visible = true;
                            break;
                        case 4:
                            statusText = "Completed";
                            labelStatus3.ForeColor = System.Drawing.Color.Black;
                            button_editLine3.Visible = false;
                            break;
                        case 5:
                            statusText = "Stopped";
                            labelStatus3.ForeColor = System.Drawing.Color.Black;
                            button_editLine3.Visible = false;
                            break;
                    }
              labelStatus3.Text = statusText;

                  //Get batches/carton number on Pallet

                  sql = "SELECT data.PalletLabel.MaterialBatchNo, data.PalletLabel.CartonsOnPallet, data.Pallet.PalletUniqueNo FROM data.Pallet LEFT JOIN data.PalletLabel ON data.PalletLabel.PalletUniqueNo = data.Pallet.PalletUniqueNo WHERE data.Pallet.PalletBatchUniqueNo =" + Line3BatchID;
                  DataTable dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);
                  sql = "SELECT DISTINCT data.PalletLabel.MaterialBatchNo FROM data.Pallet LEFT JOIN data.PalletLabel ON data.PalletLabel.PalletUniqueNo = data.Pallet.PalletUniqueNo WHERE data.Pallet.PalletBatchUniqueNo =" + Line3BatchID;
                  DataTable dtCurrentPalletView = Program.ExwoldDb.ExecuteQuery(sql);
                  if (dtCurrentPallet.Rows.Count > 0)
                  {

                    this.dataGridView6.DataSource = dtCurrentPalletView;

                    object sumObject;
                    sumObject = dtCurrentPallet.Compute("Sum(CartonsOnPallet)", "");
                    textBoxCartonsOnPallet3.Text = sumObject.ToString();
                  }
                  break;

                default:
                  labelStatus3.Text = "ERROR \r\nMultiple batches \r\nidentified";
                  labelStatus3.ForeColor = System.Drawing.Color.Red;
                  button_editLine3.Visible = false;
                  break;
              }
              Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Line 3 returned " + dtCurrentBatch3.Rows.Count + " batches");
            }

        private void BackgroundWorkerPrintLabel_DoWork(object sender, DoWorkEventArgs e)
        {
          const string methodName = moduleName + "BackgroundWorkerPrintLabel_DoWork(): ";
          try
          {
            string BatchNumber;

            if (messageFromScanner.StartsWith("PRINT"))
            {
              Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "PRINT");
              //Open print form and pass ScannerPrint as flag
              BatchNumber = messageFromScanner.Split(':').Last();
              PrintForm1 frmPrint = new PrintForm1();
              frmPrint.PrintBatchFlag = "ScannerPrint";
              frmPrint.PrintBatchID = BatchNumber;
              frmPrint.ShowDialog();
              Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "PRINT - calling Application.Restart()");
              Program.Log.logSave();
              Application.Restart();
            }

            if (messageFromScanner.StartsWith("REPRINT"))
            {
              Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "REPRINT");
              //Open print form and pass Reprint as flag
              BatchNumber = messageFromScanner.Split(':').Last();
              PrintForm1 frmPrint = new PrintForm1();
              frmPrint.PrintBatchFlag = "Reprint";
              frmPrint.PrintBatchID = BatchNumber;
              frmPrint.ShowDialog();
              Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "REPRINT - calling Application.Restart()");
              Program.Log.logSave();
              Application.Restart();
            }
          }
          catch (Exception ex)
          {
            Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "EXCEPTION: " + ex.Message);
            MessageBox.Show("Unable to initialise print page");
          }
        }

        private void buttonReports_Click(object sender, EventArgs e)
        {

          ReportsForm frmReports = new ReportsForm();
          frmReports.ShowDialog();
          GetLineData();

        }

        private void ArchiveMaintenanceButton_Click(object sender, EventArgs e)
        {
          UserAuthentication auth = new UserAuthentication();
          auth.ShowDialog();
          if (auth.Supervisor)
          {
            //DatabaseMaintenance dbMaint = new DatabaseMaintenance(DBConnectionString, auth.UsernameTextbox.Text);

            //dbMaint.ShowDialog();
            GetLineData();
          }
        }

        private void AuditReportButton_Click(object sender, EventArgs e)
        {
          UserAuthentication auth = new UserAuthentication();
          auth.ShowDialog();
          if (auth.Supervisor)
          {
            ReportProductAudit auditRep = new ReportProductAudit(DBConnectionString);
            auditRep.ShowDialog();
            GetLineData();
          }
        }

        /// <summary>
        /// Opens the ReprintPalletLabels form in dialog mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReprintPalletLabels_Click(object sender, EventArgs e)
        {
          ReprintPalletLabels frmReprintPalletLabels = new ReprintPalletLabels();
          frmReprintPalletLabels.ShowDialog();
        }

        public void ReprintPalletLabel(long PalletNumber)
        {
          messageFromScanner = String.Format("REPRINT:{0}", PalletNumber);
          System.ComponentModel.BackgroundWorker backgroundWorkerPrintLabel = new BackgroundWorker();
          backgroundWorkerPrintLabel.DoWork += BackgroundWorkerPrintLabel_DoWork;
          backgroundWorkerPrintLabel.RunWorkerAsync();
        }
    }
}
