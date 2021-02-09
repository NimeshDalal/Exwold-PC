/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    frmLineInfo.cs
 *              Form showing the status of one production line
 * Description: Logging helper
 * FileVersion  Build       Date        Project/CRF.    Change By       References
 * 2.00         2.00.00.00  Oct 2020    008768          Nimesh Dalal    Phase 2 Build
 *              <Description of the change>
 * ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Data.SqlClient;
using ITS.Exwold.Desktop.Properties;
using System.Runtime.InteropServices;
using System.Drawing.Text;

namespace ITS.Exwold.Desktop
{

    public partial class frmLineInfo : Form
    {
        #region Constants
        private string _moduleName = MethodBase.GetCurrentMethod().DeclaringType.Name;
        private readonly Color clrGood = Color.Transparent;
        private readonly Color clrBad = Color.Yellow;
        #endregion

        private int _palletBatchID;

        #region Local variables
        //Data variables
        private readonly DataInterface.execFunction _db = null;
        private ExwoldConfigSettings _exwoldConfigSettings = null;
        private StandAloneScanner _scanner = null;
        private int _plantNumber = 0;
        private int _lineId = 0;
        private string _lineName = string.Empty;
        private int _innersScannedTotal = 0;
        private int _innersScannedOnPallet = 0;
        private int _innersScannedUnassigned = 0;
        private int _totalOutersScanned = 0;
        #endregion
        #region Properties
        public int LineId
        {
            get { return _lineId; }
            set 
            { 
                _lineId = value;
                WriteTitle();
            }
        }
        public string LineName
        {
            get { return _lineName; }
            set 
            { 
                _lineName = value;
                WriteTitle();
            }
        }
        internal StandAloneScanner Scanner
        {
            get { return _scanner; }
            set { _scanner = value; }
        }
        
        #endregion
        private void WriteTitle()
        {
            StringBuilder caption = new StringBuilder();
            caption.Append("[" + _lineId.ToString() + "] ");
            caption.Append(_lineName);
            this.Text = caption.ToString();
            lblLine.Text = caption.ToString();
        }


        public frmLineInfo(DataInterface.execFunction database)
        {
            InitializeComponent();
            _db = database;
            _scanner = Scanner;
            if (int.TryParse(System.Configuration.ConfigurationManager.AppSettings["plantNumber"], out _plantNumber))
            {
                _exwoldConfigSettings = new ExwoldConfigSettings(_plantNumber);
            }
            else
            {
                _exwoldConfigSettings = null;
            }
            
        }

        public void UpdateScannerUI(bool InnerScanGood, string InnerErrorMsg, bool OuterScanGood, string OuterErrorMsg)
        {
            if (InnerScanGood)
            {
                grpInnerCounts.BackColor = clrGood;
                lblScannerMessage.Text = string.Empty;
                lblScannerMessage.Visible = false;
            }
            else
            {
                grpInnerCounts.BackColor = clrBad;
                lblScannerMessage.Text = InnerErrorMsg;
                lblScannerMessage.Visible = true;
                return;
            }
            if (OuterScanGood)
            {
                grpOuterCounts.BackColor = clrGood;
                lblScannerMessage.Text =string.Empty;
                lblScannerMessage.Visible = false;
            }
            else
            {
                grpOuterCounts.BackColor = clrBad;
                lblScannerMessage.Text = OuterErrorMsg;
                lblScannerMessage.Visible = true;
            }
        }
        public async Task UpdateScannedCounts()
        {
            try
            {
                _db.QueryParameters.Clear();
                _db.QueryParameters.Add("@PalletBatchUniqueNo", _palletBatchID.ToString());
                DataTable dtScannedInners = await _db.executeSP("[GUI].[getScannedInners]", true);
                if (dtScannedInners != null)
                {
                    _innersScannedTotal = dtScannedInners.AsEnumerable().Where(row => int.Parse(row["Valid"].ToString()) == 1).Sum(res => int.Parse(res["Total"].ToString()));
                    _innersScannedOnPallet = dtScannedInners.AsEnumerable().Where(row => int.Parse(row["Valid"].ToString()) == 1 && row["PalletUniqueNo"] != DBNull.Value).Sum(res => (int)(res["Total"] == DBNull.Value ? 0 : int.Parse(res["Total"].ToString())));
                    _innersScannedUnassigned = dtScannedInners.AsEnumerable().Where(row => int.Parse(row["Valid"].ToString()) == 1 && row["PalletUniqueNo"] == DBNull.Value).Sum(res => (int)(res["Total"] == DBNull.Value ? 0 : int.Parse(res["Total"].ToString())));

                    tbInnersScanned.Text = _innersScannedTotal.ToString();
                    tbInnersOnPallets.Text = _innersScannedOnPallet.ToString();
                    tbInnersUnassigned.Text = _innersScannedUnassigned.ToString();
                }
            }
            catch(Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), ex.Message);
                _innersScannedTotal = int.MinValue;
                _innersScannedOnPallet = int.MinValue;
                _innersScannedUnassigned = int.MinValue;
                tbInnersScanned.Text = string.Empty;
                tbInnersOnPallets.Text = string.Empty;
                tbInnersUnassigned.Text = string.Empty;
            }
        }

        public async void GetLineData()
        {
            grpScanner.Enabled = (_scanner != null);
            CheckScannerStatus();
            SetScannerStartStop();

            //Collect the line information
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("status", ((int)Helper.BatchStatus.InProgress).ToString());
            _db.QueryParameters.Add("LineNumber", _lineId.ToString());

            //Get the data
            DataTable dtPalletBatch = await _db.executeSP("[GUI].[getPalletBatch]", true);
            
            //Get Current Batch For Line1
            switch (dtPalletBatch.Rows.Count)
            {
                case 0:
                    lblStatusMessage.Text = "Not Running";
                    lblStatusMessage.ForeColor = System.Drawing.Color.Black;
                    btnPalletDetails.Visible = false;
                    btnPackLabels.Visible = false;
                    break;
                case 1:
                    _palletBatchID = Convert.ToInt32(dtPalletBatch.Rows[0].Field<Int64>("PalletBatchUniqueNo"));

                    tbPalletBatch.Text = _palletBatchID.ToString();
                    txtPalletBatchNo.Text = dtPalletBatch.Rows[0]["PalletBatchNo"].ToString();
                    txtCustomer.Text = dtPalletBatch.Rows[0]["Customer"].ToString();
                    txtProdName.Text = dtPalletBatch.Rows[0]["ProductName"].ToString();
                    txtTotalCartons.Text = dtPalletBatch.Rows[0]["TotalNoOfCartons"].ToString();
                    txtNotes.Text = dtPalletBatch.Rows[0]["AdditionalInfo"].ToString();
                    tbInnersRqd.Text = dtPalletBatch.Rows[0]["InnerLabelsRqd"].ToString();
                    

                    //convert Status to human readable , set colour and text
                    int status = -1;
                    int.TryParse(dtPalletBatch.Rows[0]["Status"].ToString(), out status);

                    #region Set the Message Colour and Button visibility
                    lblStatusMessage.Text = Helper.LineStatus[status];
                    lblStatusMessage.ForeColor = Helper.LineStatusColour[status];
                    btnPalletDetails.Visible = Helper.LineStatusVisibility[status];
                    btnPackLabels.Visible = Helper.LineStatusVisibility[status];
                    #endregion
                    // Get the current number of inners scanned
                    await UpdateScannedCounts();



                    //Get batches/carton number on Pallet
                    _db.QueryParameters.Clear();
                    _db.QueryParameters.Add("@PalletBatchId", _palletBatchID.ToString());
                    DataTable dtCurrentPallet = await _db.executeSP("[GUI].[getCartonsOnPallet]", true);

                    _db.QueryParameters.Clear();
                    _db.QueryParameters.Add("@PalletBatchId", _palletBatchID.ToString());
                    DataTable dtCurrentPalletView = await _db.executeSP("[GUI].[getBatchesOnPallet]", true);

                    if (dtCurrentPallet.Rows.Count > 0)
                    {
                        this.dgvCurrentPallet.DataSource = dtCurrentPalletView;
                        object sumObject;
                        sumObject = dtCurrentPallet.Compute("Sum(CartonsOnPallet)", "");
                        txtCartonsOnPallet.Text = sumObject.ToString();
                    }
                    break;
                default:
                    lblStatusMessage.Text = "ERROR \r\nMultiple batches \r\nidentified";
                    lblStatusMessage.ForeColor = System.Drawing.Color.Red;
                    btnPalletDetails.Visible = false;
                    break;
            }
        }

        private void btnPalletDetails_Click(object sender, EventArgs e)
        {
            frmSalesOrderDetails fDetails = new frmSalesOrderDetails(_exwoldConfigSettings, _db);
            fDetails.ViewBatch = true;
            fDetails.PalletBatchId = _palletBatchID;
            fDetails.ShowDialog();
            GetLineData();           
        }

        private void frmLineInfo_Load(object sender, EventArgs e)
        {
            GetLineData();
        }

        private void btnPackLabels_Click(object sender, EventArgs e)
        {
            // Need the plant settings for the Pack Printer form
            if (_exwoldConfigSettings == null) throw new ArgumentNullException("PlantSettings", Logging.ThisMethod());

            frmOuterInnerLabels fLabel = new frmOuterInnerLabels(_db, _palletBatchID, _exwoldConfigSettings);
            fLabel.Show();
        }

        private void btnScannerStatus_Click(object sender, EventArgs e)
        {
            CheckScannerStatus();
        }

        private void btnScannerStartStop_Click(object sender, EventArgs e)
        {
            SetScannerStartStop();
        }

        private async void CheckScannerStatus()
        {
            if (_scanner != null && _scanner.MX300N != null)
            {
                bool bConnected;
                btnScannerStatus.Enabled = true;
                try
                {
                    bConnected = await _scanner.MX300N.IsConnected();
                }
                catch
                {
                    tbScannerStatus.Text = "Invalid Socket";
                    btnScannerStartStop.Enabled = false;
                    return;
                }
                if (await _scanner.MX300N.IsAvailable())
                { 
                    tbScannerStatus.Text = "On-Line";
                    btnScannerStartStop.Enabled = true;
                }
                else
                { 
                    tbScannerStatus.Text = "Off-Line";
                    btnScannerStartStop.Enabled = false;
                }
            }
            else
            {
                btnScannerStatus.Enabled = false;
            }
        }
        private async void SetScannerStartStop()
        {
            if (_scanner == null)
            {
                btnScannerStartStop.Text = "No Scanner";
                btnScannerStartStop.Enabled = false;
            }
            else
            {
                try
                {
                    bool bPing = await _scanner.MX300N.IsConnected();
                    if (bPing)
                    {
                        if (_scanner.MX300N.IsScanning())
                        {
                            _scanner.MX300N.StopScanning();
                            btnScannerStartStop.Text = "Start";
                        }
                        else
                        {
                            try
                            {
                                _scanner.MX300N.StartScanning(_scanner.ConfigData.ScanRate);
                            }
                            catch { }
                            btnScannerStartStop.Text = "Stop";
                        }
                    }
                }
                catch { }
            }
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            frmScannerDetail fscannerDetail = new frmScannerDetail(_scanner)
            {
                // Set the form parameters
                FormBorderStyle = FormBorderStyle.FixedDialog,
                BackColor = Color.AliceBlue,
                StartPosition = FormStartPosition.CenterParent,
                ShowIcon = true,
                Icon = Properties.Resources.ExwoldApp,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false,
                TopMost = true,
                ControlBox = true,
                HelpButton = false,
                EnableClose = true
        };
            
            fscannerDetail.ShowDialog();
            fscannerDetail.Dispose();
        }
    }
}
