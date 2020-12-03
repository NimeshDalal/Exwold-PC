/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    frmMainStatus.cs
 * Description: Provides an interface to :
 *              1)  Get Current production line data and display to user
 *              2)  Process incoming messages from the scanner
 *              3)  Give user buttons to access all other functions of the application
 * FileVersion  Build       Date        Project/CRF.    Change By       References
 * 1.00         1.00.00.00  04Apr2017   702678          Stuart Eglington 
 *              Initial Creation
 * 1.01         1.03.00.00  30Jan2018   991068/CRF002   Martin Cox
 *              Added SDK directory to config file, and associacted changes
 * 1.02         1.4.0.0     13Dec2018   991068/CRF003   Colin Robinson
 *              Added button to open ReprintPalletLabels, and added function to process reprint when called
 * 
 * 2.00         2.00.00.00  Oct 2020    008768          Nimesh Dalal    Phase 2 Build
 * ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 */
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
using System.Drawing.Text;
using ITS.Exwold.Desktop.DataInterface;
using System.Threading;
using System.Net;

namespace ITS.Exwold.Desktop
{
    public partial class MainStatusForm : Form
    {
        #region private variables
        const string _cstSecConnStr = "SecureStrings";
        private int _pageNumber = 0;
        private execFunction _db = null;

        private SecurityParams _secParams = new SecurityParams();
        private AzureParams _pAzure = new AzureParams();
        private const string _password = "Password to secure my Azure connection parameters";
        private const string _payload = "Azure connection parameters enctryption payload";

        #endregion
        #region Local variables for Config File values
        private string _plantName = string.Empty;
        private int _plantNumber = 0;
        private int _logLevel = 0;
        private string _logPath = string.Empty;
        private string _niceLabelSDKPath = string.Empty;
        private string _assemblyName = string.Empty;
        private string _debugConnStr = string.Empty;
        private ExwoldConfigSettings _exwoldConfigSettings = null;
        //Instances of the Line Info form
        frmLineInfo fLineInfo1 = null;
        frmLineInfo fLineInfo2 = null;
        frmLineInfo fLineInfo3 = null;
        #endregion
        #region Read only Properties
        internal ExwoldConfigSettings ExwoldConfigSettings
        { get { return _exwoldConfigSettings; } }
        
        internal execFunction DB
        { get { return _db; } }
        #endregion

        private string messageFromScanner;
        private const string moduleName = "Line-Status:";

        public MainStatusForm()
        {      
            InitializeComponent();
            try
            {
                // Load the configuration file
            }
            catch(Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex);
            }
        }

    
        private void MainStatusForm_Load(object sender, EventArgs e)
        {
            const string methodName = moduleName + "MainStatusForm_Load(): ";

            //set fullscreen depending if we are debugging or not
#if DEBUG 
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
#else
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
#endif
            //Get the assemly config
            LoadConfigurationData();

            //Start the system logger
            Program.Log = new ThreadLog();
            Program.Log.Initialise(_logPath, _assemblyName, 15, ThreadLog.DebugLevel.Debug, false);
            Program.Log.StartLogging();

            //Set the plant name
            lblPlantName.Text = _plantName;

            //Mesh Come back to this
            #region initialise the scanner stuff
            try
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, moduleName + "NiceLabelSDKPath = " + _niceLabelSDKPath);
                Program.ScannerServers = new List<TCPServer>();

                //set up a list of servers, one for each scanner
                //Mesh Sort this out later
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
            #endregion


            //Load the line data screens
            SetPage();

            GetLineData();
            Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Main Form Loaded");
        }
        /// <summary>
        /// Get the static data for this app from the configuration file or files
        /// </summary>
        /// <returns></returns>
        private bool LoadConfigurationData()
        {
            bool bRtn = false;
            try
            {
                //Popluate the Security Class
                _secParams.Password = _password;
                _secParams.PayLoad = _payload;
                //Populate the AzureParams class
                _pAzure = AzureHelper.GetAzureParams(_secParams);

                //Encrypt the setting if not already done so         
                bRtn = AzureHelper.enctryptionConnectivitySettings(_secParams);



                // Load data from the app.config file
                int.TryParse(ConfigurationManager.AppSettings["plantNumber"], out _plantNumber);
                int.TryParse(ConfigurationManager.AppSettings["logLevel"], out _logLevel);
                _logPath = ConfigurationManager.AppSettings["logPath"];
                _niceLabelSDKPath = ConfigurationManager.AppSettings["NiceLabelSDKPath"];

                //Load data from the Plant Config file
                _exwoldConfigSettings = new ExwoldConfigSettings(_plantNumber);

                //Get the assembly name
                _assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                _plantName = _exwoldConfigSettings.PlantName;
                

                //Create an instance of the data access class (used throught this app)
                _db = new execFunction(_pAzure);
            //Mesh Remove
            //"CartonProcName" spAcceptCartonTable
            //"LogProcName" spAcceptLogTable
            //"PalletProcName" spAcceptPalletTable
            //"BatchesProcName" spGetBatchesTable
            //"PalletDetailsProcName" spCollectPalletDetails
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex);
                return false;
            }
            return true;
        }


        private void SetPage()
        {
            btnChangePage.Visible = (_plantNumber == 1);
            if (_plantNumber == 1)
            {
                if (_pageNumber == 1)
                {
                    _pageNumber = 2;
                    btnChangePage.Text = "<< Previous Page (" + _pageNumber.ToString() + ")";
                }
                else
                {
                    _pageNumber = 1;
                    btnChangePage.Text = "Next Page (" + _pageNumber.ToString() + ") >>";
                }
            }
            LoadLineInfo(_plantNumber, _pageNumber);
        }
        private async void LoadLineInfo(int PlantNumber, int PageNumber)
        {
            const int cstNumInfoForms = 3;

            dgvReadyToPrint.DataSource = null;
            dgvOnHold.DataSource = null;



            //Get ReadyTo Print Data
            _db.QueryParameters.Clear();
//            _db.QueryParameters.Add("Status", ((int)Helper.BatchStatus.Completed).ToString());
            _db.QueryParameters.Add("Status", "4");
            _db.QueryParameters.Add("PlantNumber", PlantNumber.ToString());
            //Get the data
            DataTable dtReadyToPrint = await _db.executeSP("[GUI].[getPalletBatchByPlantAndStatus]", true);

            //sql = "SELECT PalletBatchNo FROM data.PalletBatch WHERE status = 4";
            //DataTable dtReadyToPrint = Program.ExwoldDb.ExecuteQuery(sql);
            if (dtReadyToPrint != null)
            {
                if (dtReadyToPrint.Rows.Count > 0)
                {
                    this.dgvReadyToPrint.DataSource = dtReadyToPrint;
                }
            }
            //Get OnHold Data
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("Status", ((int)Helper.BatchStatus.OnHold).ToString());
            _db.QueryParameters.Add("PlantNumber", PlantNumber.ToString());
            //Get the data
            DataTable dtOnHold = await _db.executeSP("[GUI].[getPalletBatchByPlantAndStatus]", true);

            //sql = "SELECT PalletBatchNo FROM data.PalletBatch WHERE status = 2";
            //DataTable dtOnHold = Program.ExwoldDb.ExecuteQuery(sql);
            if (dtOnHold != null)
            {
                if (dtOnHold.Rows.Count > 0)
                {
                    this.dgvOnHold.DataSource = dtOnHold;
                }
            }


            //Clear the display of data
            pnlPosn1.Controls.Clear();
            pnlPosn2.Controls.Clear();
            pnlPosn3.Controls.Clear();

            //Get the start line number
            int line = (PageNumber * cstNumInfoForms) - cstNumInfoForms;

            switch (PlantNumber)
            {
                case 1:
                    fLineInfo1 = AddLineForm(line++, pnlPosn1);
                    fLineInfo2 = AddLineForm(line++, pnlPosn2);
                    fLineInfo3 = AddLineForm(line, pnlPosn3);
                    break;
                case 2:
                    fLineInfo1 = null;
                    fLineInfo2 = AddLineForm(1, pnlPosn2);
                    fLineInfo3 = null;
                    break;
                case 3:
                    fLineInfo1 = null;
                    fLineInfo2 = AddLineForm(1, pnlPosn2);
                    fLineInfo3 = null;
                    break;
                default:
                    fLineInfo1 = null;
                    fLineInfo2 = null;
                    fLineInfo3 = null;
                    break;
            }
            
        }
        private frmLineInfo AddLineForm(int LineNumber, Panel LinePanel)
        {
            frmLineInfo fLine = new frmLineInfo(_db);
            fLine.TopLevel = false;

            //fLine.LineNumber = LineNumber;
            //Get the plant info from the ProductionLines collection (in the order they are in the config file)
            int LineId = _exwoldConfigSettings.ProductionLines[LineNumber].Id;
            string LineName = _exwoldConfigSettings.ProductionLines[LineNumber].Name;
            fLine.LineId = LineId;
            fLine.LineName = LineName;
            fLine.DB = _db;
            fLine.Visible = true;


            LinePanel.Controls.Clear();
            LinePanel.Controls.Add(fLine);

            Console.WriteLine("{0}, {1}", _exwoldConfigSettings.ProductionLines[LineNumber].Id, _exwoldConfigSettings.ProductionLines[LineNumber].Name);


            return fLine;
        }
        private void GetLineData()
        { 
            if (fLineInfo1 != null) { fLineInfo1.GetLineData(); }
            if (fLineInfo2 != null) { fLineInfo2.GetLineData(); }
            if (fLineInfo3 != null) { fLineInfo3.GetLineData(); }
        }

        #region Event Methods
        private void btnSetBatch_Click(object sender, EventArgs e)
        {
            UserAuthentication auth = new UserAuthentication();
            auth.ShowDialog();
            if (auth.Supervisor)
            {
                frmSalesOrderDetails fSalesOrderDetails = new frmSalesOrderDetails(_exwoldConfigSettings, _db);
                fSalesOrderDetails.ShowDialog();
                GetLineData();
            }
        }

        private void btnSetProduct_Click(object sender, EventArgs e)
        {
            UserAuthentication auth = new UserAuthentication();
            auth.ShowDialog();
            if (auth.Supervisor)
            {
                frmProduct fProduct = new frmProduct(_exwoldConfigSettings, _db);
                fProduct.ShowDialog();
                //Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "Open Product Maintenance Form");
            }
        }

        private void btnExitPalletTracking_Click(object sender, EventArgs e)
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
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "Exit Application");
                Program.Log.logSave();
            }
        }

        private void btnRptSelector_Click(object sender, EventArgs e)
        {
            frmReportSelector fReports = new frmReportSelector(_db);
            fReports.ShowDialog();
            GetLineData();
        }
        private void AuditReportButton_Click(object sender, EventArgs e)
        {
            UserAuthentication auth = new UserAuthentication();
            auth.ShowDialog();
            if (auth.Supervisor)
            {
                frmAuditReports fAuditReports = new frmAuditReports(_db);
                fAuditReports.ShowDialog();
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
            frmReprintPalletLabels fReprintPalletLabels = new frmReprintPalletLabels(_db);
            fReprintPalletLabels.ShowDialog();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private extern static bool ExitWindowsEx(uint uFlags, uint dwReason);


        #endregion

        private async void timerScannerMessages_Tick(object sender, EventArgs e)
        {
            int scannerNumber = 1;
            foreach (TCPServer server in Program.ScannerServers)
            {
                if (server.response.Count > 0)
                {
                    string scannerMessage = Encoding.Default.GetString(server.response.ToArray(), 0, server.response.Count);
                    server.response.Clear();
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "timerScannerMessages_Tick() Handling scanner " + scannerNumber.ToString() + "   message  = " + scannerMessage.Substring(0, scannerMessage.Length - 2));
                    string response = await HandleMessage(scannerNumber, scannerMessage.Substring(0, scannerMessage.Length - 2));
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "timerScannerMessages_Tick() Handling scanner " + scannerNumber.ToString() + "   response = " + response);
                    server.WinsockSend(response + Environment.NewLine);
                }
                scannerNumber++;
            }
        }
        public async Task<string> HandleMessage(int ScannerNumber, string message)
        {
            try
            {
                messageFromScanner = message;
                if (messageFromScanner.StartsWith("UPDATE"))
                {
                    //do update code
                    GetLineData();
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "Update - run GetLineData");
                    return "OK";
                }
                else if (messageFromScanner.StartsWith("PRINT") || messageFromScanner.StartsWith("REPRINT"))
                {
                    string PalletNumber = messageFromScanner.Split(':').Last();
                    _db.QueryParameters.Clear();
                    _db.QueryParameters.Add("PalletId", PalletNumber);
                    DataTable dtCurrentBatch = await _db.executeSP("[GUI].[getBatchesOnPalletBy PalletId]", true);

                    //Mesh Remove
                    //string BatchNumber = messageFromScanner.Split(':').Last();
                    //sql = "SELECT * " +
                    //"FROM   data.PalletBatch " +
                    //"INNER JOIN data.Pallet " +
                    //"ON     Data.PalletBatch.PalletBatchUniqueNo = Pallet.PalletBatchUniqueNo " +
                    //"WHERE  Pallet.PalletUniqueNo = " + BatchNumber;
                    //DataTable dtCurrentBatch = Program.ExwoldDb.ExecuteQuery(sql);
                    int rows = dtCurrentBatch.Rows.Count;

                    if (rows == 1)
                    {
                        int myAction = dtCurrentBatch.Rows[0].Field<int>("Status");
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
              frmPrint frmPrint = new frmPrint(_db);
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
              frmPrint frmPrint = new frmPrint(_db);
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

        public void ReprintPalletLabel(long PalletNumber)
        {
          messageFromScanner = String.Format("REPRINT:{0}", PalletNumber);
          System.ComponentModel.BackgroundWorker backgroundWorkerPrintLabel = new BackgroundWorker();
          backgroundWorkerPrintLabel.DoWork += BackgroundWorkerPrintLabel_DoWork;
          backgroundWorkerPrintLabel.RunWorkerAsync();
        }
        private void btnChangePage_Click(object sender, EventArgs e)
        {
            SetPage();
        }

        private void btnHardwareSettings_Click(object sender, EventArgs e)
        {
            frmPlantHardware frmHW = new frmPlantHardware();
            frmHW.ExwoldConfigSettings = _exwoldConfigSettings;
            frmHW.ShowDialog();
        }


        #region Testing
        private void SubscribeScannerEvents(StandAloneScanner scanner, bool subscribe)
        {
            if (subscribe)
            {
                scanner.MX300N.ScannerRead += mx300n_ScannerRead;
                scanner.MX300N.ScannerReadStarted += mx300n_ScannerReadStarted;
                scanner.MX300N.ScannerReadStopped += mx300n_ScannerReadStopped;
            }
            else
            {
                scanner.MX300N.ScannerRead -= mx300n_ScannerRead;
                scanner.MX300N.ScannerReadStarted -= mx300n_ScannerReadStarted;
                scanner.MX300N.ScannerReadStopped -= mx300n_ScannerReadStopped;
            }
        }
        private void btnLabelTest_Click(object sender, EventArgs e)
        {

            frmOuterInnerLabels fLabel = new frmOuterInnerLabels(_db, int.Parse(tbLabelTest.Text), _exwoldConfigSettings);
            fLabel.Show();
        }
        private void mx300n_ScannerRead(object sender, ScannerReadEventArgs a)
        {
            Console.WriteLine($"{Logging.ThisMethod()} Scanner:{a.IPAddr}, GoodReads:{a.GoodReads}, ReadsTried:{a.ReadsTried}, Data Length: {a.RawData.Length} Raw Data:{a.RawData}");
            List<GS1Identifiers>scannedData = parseScannerData(a.RawData);

            string GTIN = scannedData.Find(ele => ele.Name == "GTIN").DataValue; 
            string ProdDate = scannedData.Find(ele => ele.Name == "ProdDate").DataValue; 
            
            string LotNo = scannedData.Find(ele => ele.Name == "LotNo").DataValue;
            string ProdName1 = scannedData.Find(ele => ele.Name == "ProdName1").DataValue;
            string ProdName2 = scannedData.Find(ele => ele.Name == "ProdName2").DataValue;

            Console.WriteLine($"{GTIN}\n{LotNo}\n{ProdDate}\n{ProdName1}{ProdName2}");
        }
        private void mx300n_ScannerReadStarted(object sender, ScannerReadStatusEventArgs a)
        {
            Console.WriteLine($"Scanner read start {a.IPAddr}");
            //tbS1Status.BeginInvoke((Action)delegate ()
            //{
            //    tbS1Status.Text = $"{a.Message},{a.Status.ToString()}";
            //});
        }

        private void mx300n_ScannerReadStopped(object sender, ScannerReadStatusEventArgs a)
        {
            Console.WriteLine($"Scanner read stopped {a.IPAddr}");
            //tbS1Status.Text = $"{a.Message},{a.Status.ToString()}";
        }
        internal List<StandAloneScanner> Scanners = new List<StandAloneScanner>();
        private void btnScannerTest_Init_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"No of scanners : {_exwoldConfigSettings.StandAloneScanners.Count}");
            Scanners.Clear();

            foreach (StandAloneScannerConfigElement scannerConfig in _exwoldConfigSettings.StandAloneScanners)
            {
                Console.WriteLine($"Id:{scannerConfig.Id}, Name:{scannerConfig.Name}");
                if (scannerConfig.Status == "active")
                {
                    StandAloneScanner scanner = new StandAloneScanner(scannerConfig, 1000, 5);
                    Scanners.Add(scanner);
                    SubscribeScannerEvents(scanner, true);
                    scanner.MX300N.CancelMultiRead();
                }
            }
        }
        private void btnScannerTest_Start_Click(object sender, EventArgs e)
        {
            foreach (StandAloneScanner scanner in Scanners)
            {
                scanner.MX300N.multiReadTcpSocket(5000);
            }
        }
        private void btnScannerTest_Stop_Click(object sender, EventArgs e)
        {
            foreach (StandAloneScanner scanner in Scanners)
            {
                try
                {
                    scanner.MX300N.CancelMultiRead();
                }
                catch(Exception ex)
                {
                    Logging.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex.Message);
                }
            }
        }


        private List<GS1Identifiers> parseScannerData(string rawData)
        {
            if (string.IsNullOrEmpty(rawData) || rawData.Length < 20)
            { return null; }

            List<GS1Identifiers> Identifiers = getOuterLabelIds();
            int idxIdentifiers = 0;
            //Convert the raw data to a byte array
            byte[] bRawData = Encoding.ASCII.GetBytes(rawData);
            

            // The first character is <stx> (ascii 2)
            // and the terminator is  <etx> (ascii 3)
            if (bRawData[0] == (byte)(MDC_ASCII.Ascii.STX) &&
                bRawData[bRawData.Length - 1] == (byte)(MDC_ASCII.Ascii.ETX))
            {
                //We have some data 
                //check from the 2nd to the last but one character
                for (int idx = 1; idx < bRawData.Length - 1; idx++)
                {
                    
                    if (getStringFromBytes(bRawData, idx, Identifiers[idxIdentifiers].Identifier.Length) == Identifiers[idxIdentifiers].Identifier)
                    {
                        //We have the identifier. Now get the data
                        idx = idx + Identifiers[idxIdentifiers].Identifier.Length;
                        if (Identifiers[idxIdentifiers].FixedLength)
                        {
                            Identifiers[idxIdentifiers].DataValue = getStringFromBytes(bRawData, idx, Identifiers[idxIdentifiers].Length);
                            idx = idx + Identifiers[idxIdentifiers].Length - 1;
                            idxIdentifiers++;  //Go to the next Identifier
                        }
                        else
                        {
                            // Variable length data
                            
                            int posnGroupSeparator = Array.IndexOf(bRawData, (byte)MDC_ASCII.Ascii.GS, idx);
                            int posnETX = Array.IndexOf(bRawData, (byte)MDC_ASCII.Ascii.ETX, idx);
                            int iDatalength = 0;
                            if (posnGroupSeparator == -1)
                            {
                                //This is the last data - Read to the end (less the ETX which is the terminator)
                                iDatalength = bRawData.Length - idx - 1;
                                Identifiers[idxIdentifiers].DataValue = getStringFromBytes(bRawData, idx, iDatalength);
                            }
                            else
                            {
                                // Read to the group separator
                                iDatalength = posnGroupSeparator - idx;
                                Identifiers[idxIdentifiers].DataValue = getStringFromBytes(bRawData, idx, iDatalength);
                            }
                            //Now move on the index
                            idx = idx + Identifiers[idxIdentifiers].DataValue.Length - 1;  //This COULD end the loop
                            idxIdentifiers++;
                            if (idxIdentifiers == Identifiers.Count)
                            {
                                //There is nothing else to read
                                break;
                            }
                        }
                    }
                }
                
            }
            return Identifiers;
        }
        private int getDataIndex(byte[] bBuffer, int AsciiCode, int startPosn)
        {
            int posn = Array.IndexOf(bBuffer, (byte)AsciiCode, startPosn);
            return posn;
        }


        private string getStringFromBytes(byte[] bBuffer, int startIndex, int numBytes)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            if (bBuffer.Length >= (startIndex + numBytes))
            {
                string str = ascii.GetString(bBuffer, startIndex, numBytes);
                return str;
            }
            else { return string.Empty; }
        }


        private List<GS1Identifiers> getInnerLabelIds()
        {
            List<GS1Identifiers> innerlabel = new List<GS1Identifiers>();
            innerlabel.Add(new GS1Identifiers("GTIN", "01", true, 14));
            innerlabel.Add(new GS1Identifiers("ProdDate", "11", true, 6));
            innerlabel.Add(new GS1Identifiers("LotNo", "10", false, 0));

            return innerlabel;
        }
        private List<GS1Identifiers> getOuterLabelIds()
        {
            List<GS1Identifiers> outerlabel = new List<GS1Identifiers>();
            outerlabel.Add(new GS1Identifiers("GTIN", "01", true, 14));
            outerlabel.Add(new GS1Identifiers("ProdDate", "11", true, 6));
            outerlabel.Add(new GS1Identifiers("LotNo", "10", false, 20));
            outerlabel.Add(new GS1Identifiers("ProdName1", "240", false, 30));
            outerlabel.Add(new GS1Identifiers("ProdName2", "240", false, 30));
            return outerlabel;
        }
        #endregion
    }

    internal class GS1Identifiers
    {
        internal string Name { get; set; }
        internal string Identifier { get; set; }
        internal bool FixedLength { get; set; }
        
        //If Fixed length   = True, this is the length the data has to be
        //                  = False, this is the MAX length of the data
        internal int Length { get; set; }

        internal string DataValue { get; set; }

        internal GS1Identifiers() { }
        internal GS1Identifiers(string name, string identifier, bool fixedlength, int length)
        {
            Name = name;
            Identifier = identifier;
            FixedLength = fixedlength;
            Length = length;
        }
    }

    internal class StandAloneScanner
    {
        #region Local Variables
        private StandAloneScannerConfigElement _configData = null;
        //private CancellationTokenSource _cts = new CancellationTokenSource();
        private clsMx300NDataAsync _mx300n = null;
        private int _palletBatchUId = 0;
        private int _productionLineUId = 0;
        #endregion
        #region Properties
        public StandAloneScannerConfigElement ConfigData
        {
            get { return _configData; }
            set { _configData = value; }
        }
        //public CancellationTokenSource CancellationSource
        //{
        //    get { return _cts; }
        //    set { _cts = value; }
        //}
        public clsMx300NDataAsync MX300N
        {
            get { return _mx300n; }
            set { _mx300n = value; }
        }
        internal int PalletBatchUId
        {
            get { return _palletBatchUId; }
            set { _palletBatchUId = value; }
        }
        internal int ProductionLineUId
        {
            get { return _productionLineUId; }
            set { _productionLineUId = value; }
        }
        #endregion
        internal StandAloneScanner(StandAloneScannerConfigElement ConfigData, int palletBatchUId, int productionLineUId)
        {
            _configData = ConfigData;
            _mx300n = new clsMx300NDataAsync(IPAddress.Parse(_configData.IpAddr), _configData.Port);
            _mx300n.LogControl = null;
            _mx300n.ctrlReads = null;
            _mx300n.ctrlGoodReads = null;
            _mx300n.LogControl = null;
            _mx300n.PalletBatchUId = palletBatchUId;
            _mx300n.ProductionLineUId = productionLineUId;
        }
    }

}
