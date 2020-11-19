/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    frmReports.cs
 * Description: Provides an interface to :
 *              1)  Select a Pallet Batch number and open a Pallet batch report
 *              2)  Select a SSCC number and print a Genealogy report for that Pallet
 *              3)  Select a Material Batch and print a Batch report form for that Batch
 * FileVersion  Build       Date        Project/CRF.    Change By       References
 * 2.00         2.00.00.00  Oct 2020    008768          Nimesh Dalal    Phase 2 Build
 * ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 */
using System;
using System.Data;
using System.Windows.Forms;

namespace ITS.Exwold.Desktop
{
    public partial class frmReportSelector : Form
    {
        #region Local variables
        //Data variables
        private DataInterface.execFunction _db = null;
        DataTable _dtSalesOrders = new DataTable();
        DataTable _dtSSCCRpt = new DataTable();
        DataTable _dtBatchRpt = new DataTable();
        #endregion
        public string ViewBatchFlag;
        public string ViewBatchID;

        #region Properties
        internal DataInterface.execFunction DB
        {
            get { return _db; }
            set { _db = value; }
        }
        #endregion

        public frmReportSelector(DataInterface.execFunction database)
        {
            InitializeComponent();
            _db = database;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            lblRptMsg.Visible = false;
            //set fullscreen
#if DEBUG
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
#else
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
#endif
            getData();
        }

        private async void getData()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _db.QueryParameters.Clear();
                _dtSalesOrders = await _db.executeSP("Selector_PalletReport", false);
                _db.QueryParameters.Clear();
                _dtSSCCRpt = await _db.executeSP("Selector_SSCCReport", false);
                _db.QueryParameters.Clear();
                _dtBatchRpt = await _db.executeSP("Selector_MBReport", false);
            }
            catch { }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            cboSalesOrderRpt.DataSource = _dtSalesOrders;
            cboSalesOrderRpt.DisplayMember = "PalletBatchNo";
            cboSalesOrderRpt.ValueMember = "PalletBatchUniqueNo";

            cboSSCCRpt.DataSource = _dtSSCCRpt;
            cboSSCCRpt.DisplayMember = "SSCC"; 
            cboSSCCRpt.ValueMember = "SSCC";

            cboBatchRpt.DataSource = _dtBatchRpt;
            cboBatchRpt.DisplayMember = "BatchNo"; 
            cboBatchRpt.ValueMember = "BatchNo";

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnRunRpt_Click(object sender, EventArgs e)
        {
            lblRptMsg.Visible = true;
            lblRptMsg.Refresh();

            /* Determine the Report (button) selected */
            Button btn = (sender as Button);
            frmReportDisplay fRpt = null;
            switch (btn.Tag.ToString())
            {
                case "SalesOrder":
                    fRpt = new frmReportDisplay(_db, frmReportDisplay.ReportType.rptSalesOrder, Convert.ToString(cboSalesOrderRpt.SelectedValue));
                    break;
                case "Batch":
                    fRpt = new frmReportDisplay(_db, frmReportDisplay.ReportType.rptBatch, Convert.ToString(cboBatchRpt.SelectedValue), "%");
                    break;
                case "SSCC":
                    fRpt = new frmReportDisplay(_db, frmReportDisplay.ReportType.rptSSCC, "%", Convert.ToString(cboSSCCRpt.SelectedValue));
                    break;
                default:
                    break;
            }
            if (fRpt != null)
            {
                fRpt.ShowDialog();
            }
            lblRptMsg.Visible = false;
        }
        private void btnRunSalesOrderRpt_Click(object sender, EventArgs e)
        {
            //Mesh Remove
            //lblRptMsg.Visible = true;
            //lblRptMsg.Refresh();
            //frmReportDisplay fSaleOrdersRpt = new frmReportDisplay(frmReportDisplay.ReportType.rptSalesOrder, Convert.ToString(cboSalesOrderRpt.SelectedValue));
            //fSaleOrdersRpt.DB = _db;
            //fSaleOrdersRpt.PalletBatchNo = Convert.ToString(cboSalesOrderRpt.SelectedValue);
            //fSaleOrdersRpt.ShowDialog();
            //lblRptMsg.Visible = false;
        }

        private void btnRunSSCCReport_Click(object sender, EventArgs e)
        {
            //Mesh Remove
            //lblRptMsg.Visible = true;
            //lblRptMsg.Refresh();
            ////SSCCReportForm frmPallet = new SSCCReportForm();
            //frmReportDisplay fSSCCRpt = new frmReportDisplay(frmReportDisplay.ReportType.rptSSCC, "%", Convert.ToString(cboSSCCRpt.SelectedValue));
            //fSSCCRpt.DB = _db;
            
            ////Mesh Remove//fSSCCRpt.SSCCBatchNo = Convert.ToString(cboSSCCRpt.SelectedValue);
            ////fSSCCRpt.RMBatchNo = "%";
            //fSSCCRpt.ShowDialog();
            //lblRptMsg.Visible = false;
        }

        private void btnRunBatchRpt_Click(object sender, EventArgs e)
        {
            //Mesh Remove
            //lblRptMsg.Visible = true;
            //lblRptMsg.Refresh();
            //frmReportDisplay fBatchRpt = new frmReportDisplay(frmReportDisplay.ReportType.rptBatch, Convert.ToString(cboBatchRpt.SelectedValue), "%");
            ////Mesh Remove
            ////BatchReportForm frmBatch = new BatchReportForm();
            ////frmBatch.SSCCBatchNo2 = "%";
            ////frmBatch.RMBatchNo2 = Convert.ToString(cboBatchRpt.SelectedValue);
            //fBatchRpt.ShowDialog();
            //lblRptMsg.Visible = false;
        }

        private void cboTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (sender as ComboBox);
            Console.WriteLine("{0}", cbo.SelectedItem);

            Console.WriteLine("{0}, {1}, {2}",
                cbo.SelectedIndex,
                cbo.SelectedValue, cbo.Text
                );
        }
    }
}
