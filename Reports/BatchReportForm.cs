/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    BatchReportForm.cs
 * Description: Provides the batch report requested by the user from the REPORTS form
 * FileVersion  Build       Date        Project/CRF.    Change By           References
 * 1.00         1.00        04Apr2017   702678          Stuart Eglington    Initial Creation
 * 2.00         2.00.00.00  Oct 2020    008768          Nimesh Dalal        Phase 2 Build
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
    public partial class BatchReportForm : Form
    {
        #region Local Variables
        //Date variables
        private DataInterface.clsDatabase _db = null;
        #endregion
        public string SSCCBatchNo2;
        public string RMBatchNo2;

        public BatchReportForm()
        {
            InitializeComponent();
        }
        private void BatchReportForm_Load(object sender, EventArgs e)
        {
            //set fullscreen
            this.TopMost = true;

            // TODO: This line of code loads data into the 'ExwoldTrackingDataSet2.Report_Genealogy' table. You can move, or remove it, as needed.
            ExwoldTrackingDataSet2.EnforceConstraints = false;
                this.Report_GenealogyTableAdapter.Fill(this.ExwoldTrackingDataSet2.Report_Genealogy, RMBatchNo2,SSCCBatchNo2);

            this.rptVwrBatchReport.RefreshReport();
        }
    }
}
