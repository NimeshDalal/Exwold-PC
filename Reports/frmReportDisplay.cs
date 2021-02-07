/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    frmrptSalesOrder.cs
 * Description: Provides the pallet report requested by the user from the REPORTS form
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
using Microsoft.Reporting.WinForms;

namespace ITS.Exwold.Desktop
{
    public partial class frmReportDisplay : Form
    {
        public enum ReportType : int
        {
            rptSalesOrder,
            rptBatch,
            rptSSCC
        }

        #region Local Variables
        //Date variables
        private DataInterface.execFunction _db = null;
        private ReportType _rptType;
        private string _batchNumber = string.Empty;
        private string _materialBatchNumber = string.Empty;
        private string _SSCCBatchNumber = string.Empty;
        #endregion
        #region Properties
        internal DataInterface.execFunction DB
        {
            get { return _db; }
            set { _db = value; }
        }
        #endregion
        //public frmReportDisplay(ReportType rptType)
        //{
        //    InitializeComponent();
        //    _rptType = rptType;
        //}
        public frmReportDisplay(DataInterface.execFunction database, ReportType rptType, string BatchNumber)
        {
            InitializeComponent();
            _rptType = rptType;
            _batchNumber = BatchNumber;
            _db = database;
        }
        public frmReportDisplay(DataInterface.execFunction database, ReportType rptType, string MaterialBatchNumber, string SSCCBatchNumber)
        {
            InitializeComponent();
            _rptType = rptType;
            _SSCCBatchNumber = SSCCBatchNumber;
            _materialBatchNumber = MaterialBatchNumber;
            _db = database;
        }
        private void rptSalesOrder_Load(object sender, EventArgs e)
        {
            //set fullscreen
            this.TopMost = true;

            switch (_rptType)
            {
                case ReportType.rptSalesOrder:
                    this.Text = "Sales Order Report";
                    showPalletReport(_batchNumber);
                    break;
                case ReportType.rptBatch:
                    this.Text = "Batch Report";
                    showBatchRpt();                 
                    //MessageBox.Show("Show Batch report");
                    break;
                case ReportType.rptSSCC:
                    this.Text = "SSCC Report";
                    showSSCCRpt();
                    //MessageBox.Show("Show SSCC report");
                    break;
                default:
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Information, Logging.ThisMethod(), "Invalid Report Type");
                    break;
            }

        }
        private async void showPalletReport(string PalletBatchNo)
        {
            //Set the report definition file
            string rdlcFile = "ITS.Exwold.Desktop.Reports.rptPallet.rdlc";
            //Set the data source name
            string strDataSource = "RptData";

            /*
             * Check if the status is Ready to Print
             * If the status is 3, then change it to 4
             */
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("@PalletBatchUniqueNo", PalletBatchNo);
            _db.QueryParameters.Add("@FromStatus", "3");
            _db.QueryParameters.Add("@ToStatus", "4");

            DataTable dtCurrentBatch = await _db.executeSP("[GUI].[updatePalletBatchStatus]", true);

            //Get the data for the report
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("@PalletBatchNo", PalletBatchNo);
            //Get the report Data
            DataTable dtData = await _db.executeSP("Report_PalletReport", true);

            //Set the location of the report definition
            rvDisplay.LocalReport.ReportEmbeddedResource = rdlcFile;
            rvDisplay.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            rvDisplay.LocalReport.EnableExternalImages = true;
            
            Reports.dsRptPallet dsData = new Reports.dsRptPallet();
            dsData.Tables.Clear();
            dsData.Tables.Add(dtData.Copy());
            ReportDataSource rds = new ReportDataSource(strDataSource, dsData.Tables[0]);
            rvDisplay.LocalReport.DataSources.Clear();
            rvDisplay.LocalReport.DataSources.Add(rds);
            rvDisplay.LocalReport.Refresh();
            rvDisplay.RefreshReport();
        }

        private async void showBatchRpt()
        {
            //Set the report definition file
            string rdlcFile = "ITS.Exwold.Desktop.Reports.rptBatch.rdlc";
            //Set the data source name
            string strDataSource = "RptData";

            //Get the report data
            DataTable dtData = await getGenealogyReportData(_materialBatchNumber, _SSCCBatchNumber);
            //Create the report dataset
            Reports.dsRptGenealogy dsData = new Reports.dsRptGenealogy();
            
            dsData.Tables.Clear();
            dsData.Tables.Add(dtData.Copy());

            rvDisplay.LocalReport.ReportEmbeddedResource = rdlcFile;
            rvDisplay.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            rvDisplay.LocalReport.EnableExternalImages = true;
            rvDisplay.LocalReport.DataSources.Clear();
            //Set the location of the report definition
            ReportDataSource rds = new ReportDataSource(strDataSource, dsData.Tables[0]);
            rvDisplay.LocalReport.DataSources.Add(rds);
            rvDisplay.LocalReport.Refresh();
            rvDisplay.RefreshReport();
        }
        private async void showSSCCRpt()
        {
            //Set the report definition file
            string rdlcFile = "ITS.Exwold.Desktop.Reports.rptSSCC.rdlc";
            //Set the data source name
            string strDataSource = "RptData";

            //Get the report data
            DataTable dtData = await getGenealogyReportData(_materialBatchNumber, _SSCCBatchNumber);
            //Create the report dataset
            Reports.dsRptGenealogy dsData = new Reports.dsRptGenealogy();

            dsData.Tables.Clear();
            dsData.Tables.Add(dtData.Copy());

            rvDisplay.LocalReport.ReportEmbeddedResource = rdlcFile;
            rvDisplay.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            rvDisplay.LocalReport.EnableExternalImages = true;
            rvDisplay.LocalReport.DataSources.Clear();
            //Set the location of the report definition
            ReportDataSource rds = new ReportDataSource(strDataSource, dsData.Tables[0]);
            rvDisplay.LocalReport.DataSources.Add(rds);
            rvDisplay.LocalReport.Refresh();
            rvDisplay.RefreshReport();
        }

        private async Task<DataTable> getGenealogyReportData(string MBNumber, string SSCCBatchNumber)
        {
            DataTable dtRptData = null;
            try
            {
                //Get the data for the report
                _db.QueryParameters.Clear();
                _db.QueryParameters.Add("@RawMaterialBatchNo", MBNumber);
                _db.QueryParameters.Add("@SSCC", SSCCBatchNumber);
                //Get the report Data
                dtRptData = await _db.executeSP("[Report_Genealogy]", true);
            }
            catch(Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, Logging.ThisMethod(), ex);
            }
            return dtRptData;
        }
    }
}
