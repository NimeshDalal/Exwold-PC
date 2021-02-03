/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    frmReprintPalletLabels.cs
 * Description: Provides an interface to facilitate the re-printing ofPallet Labels for 'Old' batches.
 *              Pallets may have been in the warehouse for a while before shipping, and their labels scuffed.
 * FileVersion  Build       Date        Project/CRF.    Change By       References
 * 2.00         2.00.00.00  Oct 2020    008768          Nimesh Dalal    Phase 2 Build
 * ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 */
using System;
using System.Data;
using System.Windows.Forms;

namespace ITS.Exwold.Desktop
{
  public partial class frmReprintPalletLabels : Form
  {
        #region Local variables
        //Data variables
        private DataInterface.execFunction _db = null;
        #endregion

        #region Properties
        internal DataInterface.execFunction DB
        {
            get { return _db; }
            set { _db = value; }
        }
        #endregion
        public frmReprintPalletLabels(DataInterface.execFunction database)
        {
            InitializeComponent();
        }
        /// <summary>
        /// Call function in MainStatusForm to call the reprint backgroundworker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnReprint_Click(object sender, EventArgs e)
        {
            MainStatusForm mainStatusForm = (MainStatusForm)Application.OpenForms[0];
            DialogResult answer = MessageBox.Show("Please confirm that the original Pallet Label(s) have been destroyed.", "Old Labels destroyed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                bool bRtn = await mainStatusForm.PrintLabelBackground("REPRINT", cmbSSCCs.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Please ensure the original Pallet Label(s) have been destroyed, then repeat this action.", "Please destroy the old labels", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        /// <summary>
        /// Exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
          this.Close();
        }
        /// <summary>
        /// Add all sales batch numbers, (with the DB ID as the values), less than a year old to the sales batch dropdown, 
        /// newest first
        /// Call method to load SSCC numbers to cmbSSCCs for sales batch displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmReprintPalletLabels_Load(object sender, EventArgs e)
        {
            _db.QueryParameters.Clear();
            DataTable dtSalesBatches = _db.executeSP("[GUI].[getBatchesThisYear]", false).Result;

            //Mesh Remove
            //string sql = "SELECT PalletBatchUniqueNo, PalletBatchNo " +
            //"FROM [ExwoldTracking].[Data].[PalletBatch] " +
            //"WHERE StartDT > DATEADD(YEAR, -1, GETDATE()) " +
            //"ORDER BY StartDT DESC";
            //DataTable dtSalesBatches = Program.ExwoldDb.ExecuteQuery(sql);
            if (dtSalesBatches.Rows.Count > 0)
            {
                cmbSalesBatches.DisplayMember = "PalletBatchNo";
                cmbSalesBatches.ValueMember = "PalletBatchUniqueNo";
                cmbSalesBatches.DataSource = dtSalesBatches.DefaultView;
                cmbSalesBatches.BindingContext = this.BindingContext;
            }
            fillSsccCombo();
        }
        /// <summary>
        /// Takes the selected value of cmbSalesBatches and fills cmbSSCCs for that sales batch
        /// </summary>
        private void fillSsccCombo()
        {
            cmbSSCCs.DataSource = null;

            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("PalletBatchId", cmbSalesBatches.SelectedValue.ToString());
            DataTable dtSSCCs = _db.executeSP("[GUI].[getPalletByPalletBatchId]", true).Result;

            //Mesh Remove
            //string sql = String.Format("SELECT PalletUniqueNo, SSCC " +
            //"FROM [ExwoldTracking].[Data].[Pallet] " +
            //"WHERE PalletBatchUniqueNo = {0}",
            //cmbSalesBatches.SelectedValue);
            //DataTable dtSSCCs = Program.ExwoldDb.ExecuteQuery(sql);
            
            if (dtSSCCs.Rows.Count > 0)
            {
                cmbSSCCs.DisplayMember = "SSCC";
                cmbSSCCs.ValueMember = "PalletUniqueNo";
                cmbSSCCs.DataSource = dtSSCCs.DefaultView;
                cmbSSCCs.BindingContext = this.BindingContext;
            }
        }
        /// <summary>
        /// Call method to load SSCC numbers to cmbSSCCs for sales batch displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSalesBatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSsccCombo();
        }
    }
}