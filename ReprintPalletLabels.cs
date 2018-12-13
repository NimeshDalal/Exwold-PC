//******************************************************************************
// Project: 702385 Exwold Tracking
// File:    ReprintPalletLabels
// COPYRIGHT
// © Copyright 2018 Industrial Technology Systems Ltd.
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
//     1.00      1.4.0.0  13Dec2018   991068/CRF003  Colin Robinson
//        Loads sales batches and pallets for each batch, then sends a request to reprint the labels for that batch to MainStatusForm
//
//******************************************************************************

using System;
using System.Data;
using System.Windows.Forms;

namespace ExwoldPcInterface
{
  public partial class ReprintPalletLabels : Form
  {
    public ReprintPalletLabels()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Call function in MainStatusForm to call the reprint backgroundworker
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnReprint_Click(object sender, EventArgs e)
    {
      MainStatusForm mainStatusForm = (MainStatusForm)Application.OpenForms[0];

      mainStatusForm.ReprintPalletLabel((long)cmbSSCCs.SelectedValue);
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
    /// Add all sales batch numbers, (with the DB ID as the values), less than a year old to the sales batch dropdown, newest first
    /// Call method to load SSCC numbers to cmbSSCCs for sales batch displayed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ReprintPalletLabels_Load(object sender, EventArgs e)
    {
      string sql = "SELECT PalletBatchUniqueNo, PalletBatchNo " +
        "FROM [ExwoldTracking].[Data].[PalletBatch] " +
        "WHERE StartDT > DATEADD(YEAR, -1, GETDATE()) " +
        "ORDER BY StartDT DESC";
      DataTable dtSalesBatches = Program.ExwoldDb.ExecuteQuery(sql);
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
      string sql = String.Format("SELECT PalletUniqueNo, SSCC " + "" +
        "FROM [ExwoldTracking].[Data].[Pallet]" +
        "WHERE PalletBatchUniqueNo = {0}",
        cmbSalesBatches.SelectedValue);
      DataTable dtSSCCs = Program.ExwoldDb.ExecuteQuery(sql);
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