//******************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd.
// All Rights Reserved.
//
// DISCUSSION
// Provides the sscc report requested by the user from the REPORTS form
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

namespace ITS.Exwold.Desktop
{
    public partial class SSCCReportForm : Form
    {
        #region Local Variables
        //Date variables
        private DataInterface.clsDatabase _db = null;
        #endregion
        public string SSCCBatchNo;
        public string RMBatchNo; 
        public SSCCReportForm()
        {
            InitializeComponent();
        }

        private void SSCCReportForm_Load(object sender, EventArgs e)
        {

            //set fullscreen
            this.TopMost = true;



            // TODO: This line of code loads data into the 'ExwoldTrackingDataSet2.Report_Genealogy' table. You can move, or remove it, as needed.
            ExwoldTrackingDataSet2.EnforceConstraints = false;
            this.Report_GenealogyTableAdapter.Fill(this.ExwoldTrackingDataSet2.Report_Genealogy, RMBatchNo,SSCCBatchNo);


            this.reportViewer1.RefreshReport();
        }
    }
}
