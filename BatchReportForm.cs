//******************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd.
// All Rights Reserved.
//
// DISCUSSION
// Provides the batch report requested by the user from the REPORTS form
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
    public partial class BatchReportForm : Form
    {
        public string SSCCBatchNo2;
        public string RMBatchNo2;

        public BatchReportForm()
        {
            InitializeComponent();
        }



        private void BatchReportForm_Load(object sender, EventArgs e)
        {

        }

        private void BatchReportForm_Load_1(object sender, EventArgs e)
        {
            //set fullscreen
            this.TopMost = true;

            // TODO: This line of code loads data into the 'ExwoldTrackingDataSet2.Report_Genealogy' table. You can move, or remove it, as needed.
            ExwoldTrackingDataSet2.EnforceConstraints = false;
                this.Report_GenealogyTableAdapter.Fill(this.ExwoldTrackingDataSet2.Report_Genealogy, RMBatchNo2,SSCCBatchNo2);

            this.reportViewer1.RefreshReport();
        }
    }
}
