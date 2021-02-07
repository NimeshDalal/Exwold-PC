/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    clsConfigurationSettings
 * Description: Provides an interface to :
 *              1)  Get selected batch data and display to user
 *              2)  Give the user an option to repring the latest pallet from the pallet batch
 *              3)  Give the user an option to edit the batch
 * FileVersion  Build       Date        Project/CRF.    Change By       References
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

namespace ITS.Exwold.Desktop
{
    public partial class frmSalesOrderDetails : Form
    {
        #region Constants
        #endregion
        #region Local Variables
        //Date variables
        private DataInterface.execFunction _db = null;
        private ExwoldConfigSettings _exwoldConfigSettings = null;

        int _palletUId;
        bool _viewBatch = false;
        int _palletBatchId;

        #endregion
        #region Properties
        internal DataInterface.execFunction DB
        {
            get { return _db; }
            set { _db = value; }
        }
        internal int PalletBatchId
        {
            get { return _palletBatchId; }
            set { _palletBatchId = value; }
        }
        internal bool ViewBatch
        {
            get { return _viewBatch; }
            set { _viewBatch = value; }
        }
        #endregion

        int status;
        public frmSalesOrderDetails(ExwoldConfigSettings ExwoldConfigSettings, DataInterface.execFunction database)
        {
            InitializeComponent();
            _db = database;
            _exwoldConfigSettings = ExwoldConfigSettings;
            // Set the form properties
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowIcon = true;
            this.Icon = Properties.Resources.ExwoldApp;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ControlBox = true;
            this.HelpButton = false;
        }

        private async void BatchDetailsForm_Load(object sender, EventArgs e)
        {
            //set fullscreen
#if DEBUG 
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
#else
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
#endif
            switch (_viewBatch)
            {
                case true:
                    {
                        _db.QueryParameters.Clear();
                        _db.QueryParameters.Add("PalletBatchId", _palletBatchId.ToString());
                        //Get the data
                        DataTable dtCurrentProduct = await _db.executeSP("[GUI].[getPalletBatchById]", true);

                        if (dtCurrentProduct.Rows.Count > 0)
                        {

                            textBoxPalletBatchNo.Text = dtCurrentProduct.Rows[0]["PalletBatchNo"].ToString();
                            textBoxCustomer.Text = dtCurrentProduct.Rows[0]["Customer"].ToString();
                            textBoxProdCode.Text = dtCurrentProduct.Rows[0]["ProductCode"].ToString();
                            textBoxProdName.Text = dtCurrentProduct.Rows[0]["ProductName"].ToString();
                            textBoxTotalCartons.Text = dtCurrentProduct.Rows[0]["TotalNoOfCartons"].ToString();
                            textBoxCartsPerPallet.Text = dtCurrentProduct.Rows[0]["CartonsPerPallet"].ToString();
                            textBoxInnersPerCart.Text = dtCurrentProduct.Rows[0]["InnerPacksPerCarton"].ToString();
                            textBoxInnerWeight.Text = dtCurrentProduct.Rows[0]["InnerPackWeightOrVolume"].ToString();
                            comboBoxInnerUnit.Text = dtCurrentProduct.Rows[0]["UnitsOfMeasure"].ToString();
                            textBoxNotes.Text = dtCurrentProduct.Rows[0]["AdditionalInfo"].ToString();
                            textBoxProdLine.Text = dtCurrentProduct.Rows[0]["ProductionLineNo"].ToString();
                            //convert Status to human readable , set colour
                            int.TryParse(dtCurrentProduct.Rows[0]["Status"].ToString(), out status);
                            labelStatus.Text = Helper.LineStatus[status];
                            labelStatus.ForeColor = Helper.LineStatusColour[status];

                            //Get batches/carton number on Pallet
                            _db.QueryParameters.Clear();
                            _db.QueryParameters.Add("PalletBatchId", _palletBatchId.ToString());
                            //Get the data
                            DataTable dtCurrentPallet = await _db.executeSP("[GUI].[getPalletByPalletBatchId]", true);

                            if (dtCurrentPallet.Rows.Count > 0)

                            {
                                int LastRow = dtCurrentPallet.Rows.Count - 1;
                                _palletUId = Convert.ToInt32(dtCurrentPallet.Rows[LastRow].Field<Int64>("PalletUniqueNo"));
                                textBoxCurrentPallet.Text = Convert.ToString(dtCurrentPallet.Rows.Count);

                                _db.QueryParameters.Clear();
                                _db.QueryParameters.Add("@PalletId", _palletUId.ToString());
                                //Get the data
                                DataTable dtPalletLabels = await _db.executeSP("[GUI].[getPalletLabelByPalletId]", true);

                                //dtCurrentPallet = await _db.executeSP("[GUI].[getPalletLabelByPalletId]", true);

                                dgvCartonsOnPallet.DataSource = dtPalletLabels;
                                foreach (DataGridViewColumn col in dgvCartonsOnPallet.Columns)
                                {
                                    if (col.Name.ToUpper() == "MaterialBatchNo".ToUpper())
                                    {
                                        col.Visible = true;
                                        col.HeaderText = "Lot Number";
                                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                        
                                    }
                                    else
                                    {
                                        col.Visible = false;
                                    }
                                }


                                object sumObject;
                                sumObject = dtPalletLabels.Compute("Sum(CartonsOnPallet)", "");
                                textBoxCartonsOnPallet.Text = sumObject.ToString();
                            }
                        }
                        else
                        {
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), $"Failed to get data for batch {_palletUId}");
                        }
                    break;
                    }
            }
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void buttonEdit_Click(object sender, EventArgs e)
        {
            UserAuthentication auth = new UserAuthentication();
            auth.ShowDialog();
            if (auth.Supervisor)
            {
                // set batch ID globals and open palletBatch form
                frmSalesOrders fSalesOrderDetails = new frmSalesOrders(_exwoldConfigSettings, _db);
                fSalesOrderDetails.CreateBatchFlag = "Edit";
                fSalesOrderDetails.CreateBatchID = Convert.ToString(_palletBatchId);
                fSalesOrderDetails.ShowDialog();
                //Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "User clicked Edit for batch " + _palletUId);
            }
        }

        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This option is only to re-print pallet labels. \n\rPlease make sure the old label is destryoyed before re-printing.\n\r\n\rOld Label Destroyed?", "", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                frmPrint frmPrint = new frmPrint(_db, _palletUId);
                frmPrint.ShowDialog();
            }
        }
    }
}
