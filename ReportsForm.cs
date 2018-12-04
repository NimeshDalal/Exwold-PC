//******************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd.
// All Rights Reserved.
//
// DISCUSSION
// Provides an interface to :
//  1)  Select a Pallet Batch number and open a Pallet batch report
//  2)  Select a SSCC number and print a Genealogy report for that Pallet
//  3)  Select a Material Batch and print a Batch report form for that Batch
//
// MODIFICATION HISTORY
// Version  Project/CR      Date        By                  References
//    1.00  702678          04Apr2017   Stuart Eglington 
//          Initial Creation
//
//******************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExwoldPcInterface
{
    public partial class ReportsForm : Form
    {
        public string ViewBatchFlag;
        public string ViewBatchID;



        private void Form5_Load(object sender, EventArgs e)
        {
            labelReport.Visible = false;
            exwoldTrackingDataSet1.EnforceConstraints = false;
            exwoldTrackingDataSet3.EnforceConstraints = false;
            exwoldTrackingDataSetSSCC.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'exwoldTrackingDataSet3.Selector_MBReport' table. You can move, or remove it, as needed.
            this.selector_MBReportTableAdapter.Fill(this.exwoldTrackingDataSet3.Selector_MBReport);
            // TODO: This line of code loads data into the 'exwoldTrackingDataSetSSCC.Selector_SSCCReport' table. You can move, or remove it, as needed.
            this.selector_SSCCReportTableAdapter.Fill(this.exwoldTrackingDataSetSSCC.Selector_SSCCReport);
            // TODO: This line of code loads data into the 'exwoldTrackingDataSet1.Selector_PalletReport' table. You can move, or remove it, as needed.
            this.selector_PalletReportTableAdapter.Fill(this.exwoldTrackingDataSet1.Selector_PalletReport);



            //set fullscreen
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        public ReportsForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonPalletReport_Click(object sender, EventArgs e)
        {
            labelReport.Visible = true;
            labelReport.Refresh();
            PalletReportForm frmPallet = new PalletReportForm();
            frmPallet.PalletBatchNo = Convert.ToString(comboBoxSelectPallet.SelectedValue);
            frmPallet.ShowDialog();
            labelReport.Visible = false;
        }

        private void buttonSSCCReport_Click(object sender, EventArgs e)
        {
            labelReport.Visible = true;
            labelReport.Refresh();
            SSCCReportForm frmPallet = new SSCCReportForm();
            frmPallet.SSCCBatchNo = Convert.ToString(comboBoxSSCC.SelectedValue);
            frmPallet.RMBatchNo = "%";
            frmPallet.ShowDialog();
            labelReport.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelReport.Visible = true;
            labelReport.Refresh();
            BatchReportForm frmBatch = new BatchReportForm();
            frmBatch.SSCCBatchNo2 = "%";
            frmBatch.RMBatchNo2 = Convert.ToString(comboBoxBatch.SelectedValue);
            frmBatch.ShowDialog();
            labelReport.Visible = false;
        }
    }
}
