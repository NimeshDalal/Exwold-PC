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
        #endregion

        private int _palletBatchID;

        #region Local variables
        //Data variables
        private DataInterface.execFunction _db = null;
        private ExwoldConfigSettings _exwoldConfigSettings = null;
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
        internal DataInterface.execFunction DB
        {
            get { return _db; }
            set { _db = value; }
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
            if (int.TryParse(System.Configuration.ConfigurationManager.AppSettings["plantNumber"], out _plantNumber))
            {
                _exwoldConfigSettings = new ExwoldConfigSettings(_plantNumber);
            }
            else
            {
                _exwoldConfigSettings = null;
            }

    }
        public async void GetLineData()
        {
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
                    //Mesh
                    textBox1.Text = _palletBatchID.ToString();

                    _db.QueryParameters.Clear();
                    _db.QueryParameters.Add("PalletBatchId", _palletBatchID.ToString());
                    DataTable dtCurrentProduct = await _db.executeSP("[GUI].[getPalletBatchById]", true);

                    //sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchUniqueNo = " + Line1BatchID;
                    //DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);

                    txtPalletBatchNo.Text = dtCurrentProduct.Rows[0]["PalletBatchNo"].ToString();
                    txtCustomer.Text = dtCurrentProduct.Rows[0]["Customer"].ToString();
                    txtProdName.Text = dtCurrentProduct.Rows[0]["ProductName"].ToString();
                    txtTotalCartons.Text = dtCurrentProduct.Rows[0]["TotalNoOfCartons"].ToString();
                    txtNotes.Text = dtCurrentProduct.Rows[0]["AdditionalInfo"].ToString();
                    //convert Status to human readable , set colour and text
                    int status = -1;
                    int.TryParse(dtCurrentProduct.Rows[0]["Status"].ToString(), out status);

                    #region Set the Message Colour and Button visibility
                    lblStatusMessage.Text = Helper.LineStatus[status];
                    lblStatusMessage.ForeColor = Helper.LineStatusColour[status];
                    btnPalletDetails.Visible = Helper.LineStatusVisibility[status];
                    btnPackLabels.Visible = Helper.LineStatusVisibility[status];
                    #endregion
                    //Mesh Remove
                    //txtPalletBatchNo.Text = dtCurrentProduct.Rows[0].Field<string>("PalletBatchNo");
                    //txtCustomer.Text = dtCurrentProduct.Rows[0].Field<string>("Customer");
                    //txtProdName.Text = dtCurrentProduct.Rows[0].Field<string>("ProductName");
                    //txtTotalCartons.Text = dtCurrentProduct.Rows[0].Field<Int64>("TotalNoOfCartons").ToString();
                    //txtNotes.Text = dtCurrentProduct.Rows[0].Field<string>("AdditionalInfo");
                    //convert Status to human readable , set colour and text                    
                    // Set the Message Colour and Button visibility
                    //switch (dtCurrentProduct.Rows[0].Field<Int64>("Status"))
                    //{
                    //    case 0:
                    //        lblStatusMessage.Text = "Available";
                    //        lblStatusMessage.ForeColor = System.Drawing.Color.Black;
                    //        btnPalletDetails.Visible = false;
                    //        break;
                    //    case 1:
                    //        lblStatusMessage.Text = "In-Progress";
                    //        lblStatusMessage.ForeColor = System.Drawing.Color.Green;
                    //        btnPalletDetails.Visible = true;
                    //        break;
                    //    case 2:
                    //        lblStatusMessage.Text = "On-Hold";
                    //        lblStatusMessage.ForeColor = System.Drawing.Color.Black;
                    //        btnPalletDetails.Visible = true;
                    //        break;
                    //    case 3:
                    //        lblStatusMessage.Text = "Ready to Print";
                    //        lblStatusMessage.ForeColor = System.Drawing.Color.Green;
                    //        lblStatusMessage.Visible = true;
                    //        break;
                    //    case 4:
                    //        lblStatusMessage.Text = "Completed";
                    //        lblStatusMessage.ForeColor = System.Drawing.Color.Black;
                    //        btnPalletDetails.Visible = false;
                    //        break;
                    //    case 5:
                    //        lblStatusMessage.Text = "Stopped";
                    //        lblStatusMessage.ForeColor = System.Drawing.Color.Black;
                    //        btnPalletDetails.Visible = false;
                    //        break;
                    //}


                    //Get batches/carton number on Pallet
                    _db.QueryParameters.Clear();
                    _db.QueryParameters.Add("@PalletBatchId", _palletBatchID.ToString());
                    DataTable dtCurrentPallet = await _db.executeSP("[GUI].[getCartonsOnPallet]", true);

                    //Mesh Remove
                    /*
                    //Get batches/carton number on Pallet
                    //sql = "SELECT [DATA].PalletLabel.MaterialBatchNo, [DATA].PalletLabel.CartonsOnPallet, [DATA].Pallet.PalletUniqueNo FROM [DATA].Pallet LEFT JOIN data.PalletLabel ON data.PalletLabel.PalletUniqueNo = data.Pallet.PalletUniqueNo WHERE data.Pallet.PalletBatchUniqueNo =" + Line1BatchID;                    _sql.Clear();
                    _sql.Append("SELECT ");
                    _sql.Append("[DATA].PalletLabel.MaterialBatchNo, [DATA].PalletLabel.CartonsOnPallet,  [DATA].Pallet.PalletUniqueNo ");
                    _sql.Append("FROM [DATA].Pallet ");
                    _sql.Append("LEFT JOIN data.PalletLabel ON data.PalletLabel.PalletUniqueNo = data.Pallet.PalletUniqueNo ");
                    _sql.Append("WHERE data.Pallet.PalletBatchUniqueNo = ");
                    _sql.Append(_palletBatchID.ToString());
                    DataTable dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(_sql.ToString());
                    */

                    _db.QueryParameters.Clear();
                    _db.QueryParameters.Add("@PalletBatchId", _palletBatchID.ToString());
                    DataTable dtCurrentPalletView = await _db.executeSP("[GUI].[getBatchesOnPallet]", true);
                    
                    //Mesh Remove
                    /*
                    //sql = "SELECT DISTINCT data.PalletLabel.MaterialBatchNo FROM data.Pallet LEFT JOIN data.PalletLabel ON data.PalletLabel.PalletUniqueNo = data.Pallet.PalletUniqueNo WHERE data.Pallet.PalletBatchUniqueNo =" + Line1BatchID;
                    _sql.Clear();
                    _sql.Append("SELECT DISTINCT data.PalletLabel.MaterialBatchNo ");
                    _sql.Append("FROM data.Pallet ");
                    _sql.Append("LEFT JOIN data.PalletLabel ON data.PalletLabel.PalletUniqueNo = data.Pallet.PalletUniqueNo ");
                    _sql.Append("WHERE data.Pallet.PalletBatchUniqueNo = ");
                    _sql.Append(_palletBatchID.ToString());
                    DataTable dtCurrentPalletView = Program.ExwoldDb.ExecuteQuery(_sql.ToString());
                    */

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
            frmBatchDetails fDetails = new frmBatchDetails(_exwoldConfigSettings, _db);
            fDetails.ViewBatch = true;
            fDetails.PalletBatchId = _palletBatchID;
            fDetails.ShowDialog();
            GetLineData();
            Program.Log.LogMessage(ThreadLog.DebugLevel.Message, _moduleName + " btnPalletDetails_Click(): " + "Edit Line 1");
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
    }
}
