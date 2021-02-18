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
using System.Diagnostics;
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
        private string _palletGTIN = string.Empty;
        #region Local variables
        //Data variables
        private readonly DataInterface.execFunction _db = null;
        private ExwoldConfigSettings _exwoldConfigSettings = null;
        private StandAloneScanner _scanner = null;
        private int _plantNumber = 0;
        private int _lineId = 0;
        private string _lineName = string.Empty;
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


        #region Constructor
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
            lblCartonMessage.Text = string.Empty;
            lblStatusMessage.Text = string.Empty;
        }
        #endregion
        #region Public Methods
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
            PackInformation.PackInfo packinfo;
            try
            {
                packinfo = await Helper.PackInfoAsync(_db, _palletBatchID);

                if (packinfo.RawPackInfo != null)
                {
                    tbCartonsPerPallet.Text = packinfo.CartonsPerPallet.ToString();
                    tbCurrentPalletUId.Text = packinfo.CurrPalletUId.ToString();
                    tbInnersPerCarton.Text = packinfo.InnerPacksPerCarton.ToString();

                    tbCartonsPerPallet.Text = packinfo.CartonsPerPallet.ToString();
                    tbCurrentPalletUId.Text = packinfo.CurrPalletUId.ToString();
                    tbInnersPerCarton.Text = packinfo.InnerPacksPerCarton.ToString();


                    tbOutersRqd.Text = packinfo.RequiredTotalOuters.ToString();
                    tbOutersScanned.Text = packinfo.NumCartons.ToString();
                    tbInnersInOuters.Text = packinfo.InnersInCarton.ToString();
                    tbInnersRqd.Text = packinfo.RequiredTotalInners.ToString();
                    tbInnersOnPallets.Text = packinfo.InnersOnPallet.ToString();
                    tbInnersUnassigned.Text = packinfo.InnersUnassigned.ToString();

                    //Write the screen message
                    lblCartonMessage.Text = (packinfo.CartonsPerPallet > 0 && packinfo.OutersScanned >= packinfo.CartonsPerPallet) ? "Pallet is ready for scanning" : string.Empty;
                    if (string.IsNullOrEmpty(lblCartonMessage.Text))
                    {
                        lblCartonMessage.Text = (packinfo.InnerPacksPerCarton > 0 && packinfo.InnersUnassigned >= packinfo.InnerPacksPerCarton) ? "Carton is for ready scanning" : string.Empty;
                    }
                    //dtScannedInners.AsEnumerable().Where(row => int.Parse(row["Valid"].ToString()) == 1).Sum(res => int.Parse(res["Total"].ToString()));
                    //dtScannedInners.AsEnumerable().Where(row => int.Parse(row["Valid"].ToString()) == 1 && row["PalletUniqueNo"] != DBNull.Value).Sum(res => (int)(res["Total"] == DBNull.Value ? 0 : int.Parse(res["Total"].ToString())));
                    //dtScannedInners.AsEnumerable().Where(row => int.Parse(row["Valid"].ToString()) == 1 && row["PalletUniqueNo"] == DBNull.Value).Sum(res => (int)(res["Total"] == DBNull.Value ? 0 : int.Parse(res["Total"].ToString())));
                }
                else
                {
                    tbOutersRqd.Text = string.Empty;
                    tbOutersScanned.Text = string.Empty;
                    tbInnersInOuters.Text = string.Empty;
                    tbInnersRqd.Text = string.Empty;
                    tbInnersOnPallets.Text = string.Empty;
                    tbInnersUnassigned.Text = string.Empty;
                    lblCartonMessage.Text = string.Empty;
                }
            }
            catch(Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, Logging.ThisMethod(), ex.Message);
                tbOutersRqd.Text = string.Empty;
                tbOutersScanned.Text = string.Empty;
                tbInnersInOuters.Text = string.Empty;
                tbInnersRqd.Text = string.Empty;
                tbInnersOnPallets.Text = string.Empty;
                tbInnersUnassigned.Text = string.Empty;
                lblCartonMessage.Text = string.Empty;
            }
        }
        public async void GetLineData()
        {
            grpScanner.Enabled = (_scanner != null);
            CheckScannerStatus();
            SetScannerStartStop();
            UpdateScannerUI(true, string.Empty, true, string.Empty);

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

                    tbPalletBatchUId.Text = _palletBatchID.ToString();
                    tbProductUId.Text = dtPalletBatch.Rows[0]["ProductUniqueNo"].ToString();
                    tbPalletBatchNo.Text = dtPalletBatch.Rows[0]["PalletBatchNo"].ToString();
                    tbLotNo.Text = dtPalletBatch.Rows[0]["LotNumber"].ToString();
                    tbCustomer.Text = dtPalletBatch.Rows[0]["Customer"].ToString();
                    tbProdName.Text = dtPalletBatch.Rows[0]["ProductName"].ToString();
                    tbOutersRqd.Text = dtPalletBatch.Rows[0]["TotalNoOfCartons"].ToString();
                    tbNotes.Text = dtPalletBatch.Rows[0]["AdditionalInfo"].ToString();
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

                    //Mesh
                    ////Get batches/carton number on Pallet
                    //_db.QueryParameters.Clear();
                    //_db.QueryParameters.Add("@PalletBatchId", _palletBatchID.ToString());
                    //DataTable dtCurrentPallet = await _db.executeSP("[GUI].[getCartonsOnPallet]", true);

                    _db.QueryParameters.Clear();
                    _db.QueryParameters.Add("@PalletBatchId", _palletBatchID.ToString());
                    DataTable dtCurrentPalletView = await _db.executeSP("[GUI].[getBatchesOnPallet]", true);

                    if (dtCurrentPalletView != null && dtCurrentPalletView.Rows.Count > 0)
                    {
                        try
                        {
                            this.dgvCurrentPallet.DataSource = dtCurrentPalletView;
                            //object sumObject;
                            //sumObject = dtCurrentPallet.Compute("Sum(CartonsOnPallet)", "");
                            //tbOutersScanned.Text = sumObject.ToString();
                        }
                        catch { }//tbOutersScanned.Text = string.Empty; }
                    }
                    break;
                default:
                    lblStatusMessage.Text = "ERROR Multiple batches identified";
                    lblStatusMessage.ForeColor = System.Drawing.Color.Red;
                    btnPalletDetails.Visible = false;
                    break;
            }
        }
        #endregion
        #region Private Methods
        private void WriteTitle()
        {
            StringBuilder caption = new StringBuilder();
            caption.Append("[" + _lineId.ToString() + "] ");
            caption.Append(_lineName);
            this.Text = caption.ToString();
            lblLine.Text = caption.ToString();
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
            frmScannerDetail fscannerDetail = new frmScannerDetail(_db, _scanner)
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

        #endregion

        private async void btnCompletePallet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to end the current pallet?", "End Pallet", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Get the PalletUId
                PackInformation.PackInfo packinfo = await Helper.PackInfoAsync(_db, _palletBatchID);

                // This call closes the Pallet
                _db.QueryParameters.Clear();
                _db.QueryParameters.Add("PalletUniqueNo", packinfo.CurrPalletUId.ToString());
                DataTable dtCollectPalletLabels = await _db.executeSP("[dbo].[spCollectPalletLabels]", true);

                PalletLabelMethods plMethods = new PalletLabelMethods(_db);
                if (await plMethods.PrintPalletLabels(packinfo.CurrPalletUId, 1))
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Information, Logging.ThisMethod(), "Pallet labels printed");
                }
                else
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Information, Logging.ThisMethod(), "Pallet labels failed to print");
                }
            }
        }
    }
}
