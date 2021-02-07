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
        private readonly DataInterface.execFunction _db = null;
        #endregion

        #region Properties
        #endregion
        public frmReprintPalletLabels(DataInterface.execFunction database)
        {
            InitializeComponent();
            _db = database;

            // Set the form parameters
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
        /// <summary>
        /// Call function in MainStatusForm to call the reprint backgroundworker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReprint_Click(object sender, EventArgs e)
        {
            MainStatusForm mainStatusForm = (MainStatusForm)Application.OpenForms[0];
            DialogResult answer = MessageBox.Show("Please confirm that the original Pallet Label(s) have been destroyed.", "Old Labels destroyed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                /*
                //Print without showing the form
                PalletLabelMethods plMethods = new PalletLabelMethods(_db);
                await plMethods.PrintPalletLabels(int.Parse(cmbSSCCs.SelectedValue.ToString()));
                */
                // Print via the print form
                frmPrint fPrint = new frmPrint(_db, int.Parse(cmbSSCCs.SelectedValue.ToString()));
                fPrint.ShowDialog();
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
        private async void frmReprintPalletLabels_Load(object sender, EventArgs e)
        {
            _db.QueryParameters.Clear();
            DataTable dtSalesBatches = await _db.executeSP("[GUI].[getBatchesThisYear]", false);

            if (dtSalesBatches != null && dtSalesBatches.Rows.Count > 0)
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
        private async void fillSsccCombo()
        {
            cmbSSCCs.DataSource = null;

            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("PalletBatchId", cmbSalesBatches.SelectedValue.ToString());
            DataTable dtSSCCs = await _db.executeSP("[GUI].[getPalletByPalletBatchId]", true);

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