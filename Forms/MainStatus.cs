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
using ITS.Exwold.Desktop.AsyncTcp;
using System.Threading;
using System.Net;

namespace ITS.Exwold.Desktop
{
    public partial class MainStatusForm : Form
    {
        #region local variables
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
        
        private int _tcpListenPort = 0;
        private tcpListener _listener = null;

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
            //set fullscreen depending if we are debugging or not
#if DEBUG 
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.CenterScreen;
            grpTesting.Visible = true;
            grpTesting.Visible = false;

#else
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            grpTesting.Visible = false;
#endif
            //Get the assemly config
            LoadConfigurationData();

            //Start the system logger
            Program.Log = new ThreadLog();
            Program.Log.Initialise(_logPath, _assemblyName, 15, ThreadLog.DebugLevel.Debug, false);
            Program.Log.StartLogging();

            //Set the plant name
            lblPlantName.Text = _plantName;
             
            //Create the TCP Listener
            _listener = new tcpListener(_tcpListenPort, _db);
            // Start the listener running
            _listener.StartServer();

            #region initialise the scanner stuff
            try
            {
                //Start the Stand Alone Scanners
                InitScanners();
            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), ex.Message);
            }
            #endregion


            //Load the line data screens
            SetPage();

            GetLineData();
            //Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), "Main Form Loaded");
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
                int.TryParse(ConfigurationManager.AppSettings["tcpListenPort"], out _tcpListenPort);

                //Load data from the Plant Config file
                _exwoldConfigSettings = new ExwoldConfigSettings(_plantNumber);

                //Get the assembly name
                _assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                _plantName = _exwoldConfigSettings.PlantName;                
                

                //Create an instance of the data access class (used throught this app)
                _db = new execFunction(_pAzure);

            }
            catch (Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex);
                return false;
            }
            return true;
        }
        private async void SetPage()
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
            await LoadLineInfo(_plantNumber, _pageNumber);
        }
        // Refresh (UPDATE) the line infomration displayed
        // using the current settings
        public async Task<bool> RefreshLineInfo()
        {
            try
            {
                await LoadLineInfo(_plantNumber, _pageNumber, true);
                GetLineData();
                return true;
            }
            catch { }
            return false;
        }
        private async Task LoadLineInfo(int PlantNumber, int PageNumber, bool RefreshOnly = false)
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

            if (!RefreshOnly)
            {
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
        }
        private frmLineInfo AddLineForm(int LineNumber, Panel LinePanel)
        {
            frmLineInfo fLine = new frmLineInfo(_db);
            fLine.TopLevel = false;

            //fLine.LineNumber = LineNumber;
            //Get the plant info from the ProductionLines collection (in the order they are in the config file)
            int LineId = _exwoldConfigSettings.ProductionLines[LineNumber].Id;
            string LineName = _exwoldConfigSettings.ProductionLines[LineNumber].Name;
            //Pass in the scanner if one is configured for the line
            foreach (StandAloneScanner scanner in Scanners)
            {
                if (scanner.ConfigData.ProductionLine == LineId)
                {
                    fLine.Scanner = scanner;
                }
            }
            fLine.LineId = LineId;
            fLine.LineName = LineName;
            fLine.Visible = true;

            LinePanel.Controls.Clear();
            LinePanel.Controls.Add(fLine);

            Console.WriteLine("{0}, {1}", 
                _exwoldConfigSettings.ProductionLines[LineNumber].Id, 
                _exwoldConfigSettings.ProductionLines[LineNumber].Name);


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
                frmSalesOrders fSalesOrderDetails = new frmSalesOrders(_exwoldConfigSettings, _db);
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
                Product fProduct = new Product(_exwoldConfigSettings, _db);
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
            ReportSelector fReports = new ReportSelector(_db);
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


        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshLineInfo();
        }

        private void btnChangePage_Click(object sender, EventArgs e)
        {
            SetPage();
        }

        private void btnHardwareSettings_Click(object sender, EventArgs e)
        {
            UserAuthentication auth = new UserAuthentication();
            frmPlantHardware frmHW = null;
            auth.ShowDialog();
            if (auth.Supervisor) 
            {
                frmHW = new frmPlantHardware(_db, _exwoldConfigSettings, Scanners);
                frmHW.ShowDialog();
                if (frmHW.DialogResult == DialogResult.OK)
                {
                    if (frmHW.DiscardChanges)
                    {
                        //Re-Load data from the Plant Config file
                        _exwoldConfigSettings = new ExwoldConfigSettings(_plantNumber);
                    }
                    else
                    {
                        _exwoldConfigSettings.Save();
                    }
                    if (frmHW.ReInitialiseScanners) { InitScanners(); }
                }
            }
            if (frmHW != null) frmHW.Dispose();
            GetLineData();
        }
        private void btnAppSettings_Click(object sender, EventArgs e)
        {
            UserAuthentication auth = new UserAuthentication();
            frmSettings frmset = new frmSettings();
            auth.ShowDialog();
            if (auth.Supervisor)
            {
                frmset.ShowDialog();
            }
        }
        private void btnScanner_Click(object sender, EventArgs e)
        {
            frmStandAloneScanners fScanners = new frmStandAloneScanners(_db, Scanners);
            fScanners.ShowDialog();
            fScanners.Dispose();
        }
        #endregion
        #region Test Events
        private void btnTCPListener_Click(object sender, EventArgs e)
        {
            frmAsyncTcpTest listener = new frmAsyncTcpTest(_db, _listener);
            listener.Show();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            PalletLabelMethods plMethods = new PalletLabelMethods(_db);

            //plMethods.ScannerPrint(int.Parse(tbLabelTest.Text));

            plMethods.PrintBatchLabels(int.Parse(tbLabelTest.Text));
            
            //List<PalletLabelData> plData = await plMethods.fetchLabelsByPalletBatch(1945);
            //List<string> plPrinters = plMethods.GetPalletLabelPrinters();

            //plMethods.SendLabelToPrinter(plData, plPrinters[0], 1);
            //GetPalletLabelData plData = new GetPalletLabelData(_db);
            //List<PalletLabelInfo> plInfo = await plData.getPalletBatchLabels(1942);

        }
        #endregion


    }
}
