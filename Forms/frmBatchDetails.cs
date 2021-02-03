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
    public partial class frmBatchDetails : Form
    {
        #region Constants
        private const string moduleName = "Batch-Details:";
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
        public frmBatchDetails(ExwoldConfigSettings ExwoldConfigSettings, DataInterface.execFunction database)
        {
            InitializeComponent();
            _db = database;
            _exwoldConfigSettings = ExwoldConfigSettings;
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

                        //Mesh Remove
                        //sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchUniqueNo = " + _palletBatchID;
                        //DataTable dtCurrentProduct = Program.ExwoldDb.ExecuteQuery(sql);
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

                            //Mesh Remove
                            //sql = "SELECT PalletUniqueNo FROM data.Pallet WHERE PalletBatchUniqueNo = " + _palletBatchID;
                            //DataTable dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);

                            if (dtCurrentPallet.Rows.Count > 0)

                            {
                                int LastRow = dtCurrentPallet.Rows.Count - 1;


                                _palletUId = Convert.ToInt32(dtCurrentPallet.Rows[LastRow].Field<Int64>("PalletUniqueNo"));
                                textBoxCurrentPallet.Text = Convert.ToString(dtCurrentPallet.Rows.Count);

                                _db.QueryParameters.Clear();
                                _db.QueryParameters.Add("@PalletLabelId", _palletUId.ToString());
                                //Get the data
                                dtCurrentPallet = await _db.executeSP("[GUI].[getCartonByPalletLabelId]", true);

                                //Mesh Remove
                                //sql = "SELECT MaterialBatchNo, CartonsOnPallet FROM data.PalletLabel WHERE PalletUniqueNo = " + PalletLabelID;
                                //dtCurrentPallet = Program.ExwoldDb.ExecuteQuery(sql);

                                this.dgvCartonsOnPallet.DataSource = dtCurrentPallet;
                                this.dgvCartonsOnPallet.Columns[1].Visible = false;

                                object sumObject;
                                sumObject = dtCurrentPallet.Compute("Sum(CartonsOnPallet)", "");
                                textBoxCartonsOnPallet.Text = sumObject.ToString();
                            }
                            // See if we have any labels to print.
                            PalletLabelMethods plMethods = new PalletLabelMethods(_db);
                            List<PalletLabelData> labels = await plMethods.fetchLabelsByPallet(_palletUId);
                            btnPrintLabel.Enabled = (labels != null && labels.Count > 0);


                        }
                        else
                        {
                            const string methodName = moduleName + "viewBatchData(): ";
                            Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "Failed to get data for batch " + _palletUId);
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
                frmSalesOrderDetails fSalesOrderDetails = new frmSalesOrderDetails(_exwoldConfigSettings, _db);
                fSalesOrderDetails.CreateBatchFlag = "Edit";
                fSalesOrderDetails.CreateBatchID = Convert.ToString(_palletBatchId);
                fSalesOrderDetails.ShowDialog();
                const string methodName = moduleName + "buttonEdit_Click(): ";
                Program.Log.LogMessage(ThreadLog.DebugLevel.Message, methodName + "User clicked Edit for batch " + _palletUId);
            }
        }

        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This option is only to re-print pallet labels. \n\rPlease make sure the old label is destryoyed before re-printing.\n\r\n\rOld Label Destroyed?", "", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                frmPrint frmPrint = new frmPrint(_db);
                frmPrint.PrintBatchFlag = "Reprint";
                frmPrint.PrintBatchID = Convert.ToString(_palletUId);
                frmPrint.ShowDialog();
            }
        }
    }
}
