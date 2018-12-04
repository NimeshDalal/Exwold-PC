//******************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd.
// All Rights Reserved.
//
// DISCUSSION
// Provides the pallet report requested by the user from the REPORTS form
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
    public partial class PalletReportForm : Form
    {
        public string PalletBatchNo;
        public PalletReportForm()
        {
            InitializeComponent();
        }

        private void PalletReportForm_Load(object sender, EventArgs e)
        {
            //set fullscreen
            this.TopMost = true;

            // TODO: This line of code loads data into the 'ExwoldTrackingDataSet.Report_PalletReport' table. You can move, or remove it, as needed.
            ExwoldTrackingDataSet.EnforceConstraints = false;
            this.Report_PalletReportTableAdapter.Fill(this.ExwoldTrackingDataSet.Report_PalletReport, PalletBatchNo);
            this.reportViewerPalletReport.RefreshReport();

            //Check ifr status is Ready to Print
            string sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchUniqueNo = " + PalletBatchNo;
            DataTable dtCurrentBatch = Program.ExwoldDb.ExecuteQuery(sql);

            if (dtCurrentBatch.Rows[0].Field<Int16>("Status") == 3)
            {
                //change Status to Completed
                sql = "UPDATE Data.PalletBatch SET Status = 4 " +
                    " WHERE PalletBatchUniqueNo = " + PalletBatchNo;

                Program.ExwoldDb.ExecuteNonQuery(sql);                


            }
        }

        private void reportViewerPalletReport_Load(object sender, EventArgs e)
        {

        }
    }
}
