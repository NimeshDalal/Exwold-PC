/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    frmAuditReportsDisplay.cs
 * Description: Provides the Audit Report for the Products.
 * FileVersion  Build       Date        Project/CRF.    Change By           References
 * 1.00         1.00        04Apr2017   702678          Stuart Eglington    Initial Creation
 * 2.00         2.00.00.00  Oct 2020    008768          Nimesh Dalal        Phase 2 Build
 * ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 */
using Microsoft.Reporting.WinForms;
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
    /// <summary>
    /// Provids the Products Audit Report
    /// </summary>
    public partial class frmAuditReports : Form
    {
        #region Local Variables
        //Date variables
        private DataInterface.execFunction _db = null;
        #endregion
        
        //Mesh Remove
        //string dbConnStr = "";
        #region Properties
        internal DataInterface.execFunction DB
        {
            get { return _db; }
            set { _db = value; }
        }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public frmAuditReports(DataInterface.execFunction database)
        {
            InitializeComponent();
            _db = database;
        }
        
        //Mesh Remove
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbConnectionString">Database Connection string to use.</param>
        //public frmAuditReports(string dbConnectionString)
        //{
        //    InitializeComponent();
        //    this.dbConnStr = dbConnectionString;
        //}

        /// <summary>
        /// OnLoad: Set form to max size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportProductAudit_Load(object sender, EventArgs e)
        {
            // set form maximised
#if DEBUG
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
#else
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
#endif
        }

        /// <summary>
        /// RunReportButton handler: get the data, display it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RunProductReportButton_Click(object sender, EventArgs e)
        {
            // set the report layout to use
            string rdlcFile = "ITS.Exwold.Desktop.Reports.rptAuditProduct.rdlc";
            rvDisplay.LocalReport.ReportEmbeddedResource = rdlcFile;

            //Mesh Remove
            //reportViewer.LocalReport.ReportPath = "ReportProductAudit.rdlc";
            //Database db = new Database(dbConnStr);
            //db.OpenConnection();
            //DataTable dt = db.ExecuteQuery(" EXEC ExwoldTracking.dbo.Report_AuditReportProducts '" + 
            //StartDatePicker.Value.ToString("yyyy-MM-dd")
            //+ "', '" + EndDatePicker.Value.ToString("yyyy-MM-dd") + "' ");

            // get the data
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("StartDateTime", StartDatePicker.Value.ToString("yyyy-MM-dd"));
            _db.QueryParameters.Add("EndDateTime", EndDatePicker.Value.ToString("yyyy-MM-dd"));
            DataTable dt = await _db.executeSP("[dbo].[Report_AuditReportProduct]", true);

            dt.TableName = "ReportData";
            // Create a report data source for the sales order data  
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "RptData";
            reportDataSource.Value = dt;
            // add dataset to report
            rvDisplay.LocalReport.DataSources.Clear();
            rvDisplay.LocalReport.DataSources.Add(reportDataSource);

            // Refresh the report  
            rvDisplay.RefreshReport();
        }


        private async void RunPalletBatchReportButton_Click(object sender, EventArgs e)
        {
            // set the report layout to use
            string rdlcFile = "ITS.Exwold.Desktop.Reports.rptAuditPalletBatch.rdlc";
            rvDisplay.LocalReport.ReportEmbeddedResource = rdlcFile;

            //Mesh Remove
            //reportViewer.LocalReport.ReportPath = "ReportPalletBatchAudit.rdlc";

            //Mesh Remove
            //// get the data
            //Database db = new Database(dbConnStr);
            //db.OpenConnection();
            //DataTable dt = db.ExecuteQuery(" EXEC ExwoldTracking.dbo.Report_AuditReportPalletBatches '" 
            //    + StartDatePicker.Value.ToString("yyyy-MM-dd")
            //    + "', '" + EndDatePicker.Value.ToString("yyyy-MM-dd") + "' ");

            // get the data
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("StartDateTime", StartDatePicker.Value.ToString("yyyy-MM-dd"));
            _db.QueryParameters.Add("EndDateTime", EndDatePicker.Value.ToString("yyyy-MM-dd"));
            DataTable dt = await _db.executeSP("[dbo].[Report_AuditReportPalletBatches]", true);

            dt.TableName = "ReportData";
            // Create a report data source for the sales order data  
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "RptData";
            reportDataSource.Value = dt;
            // add dataset to report
            rvDisplay.LocalReport.DataSources.Clear();
            rvDisplay.LocalReport.DataSources.Add(reportDataSource);

            // Refresh the report  
            rvDisplay.RefreshReport();
        }


        private async void RunGeneralReportButton_Click(object sender, EventArgs e)
        {
            // set the report layout to use
            string rdlcFile = "ITS.Exwold.Desktop.Reports.rptAuditOpAction.rdlc";
            rvDisplay.LocalReport.ReportEmbeddedResource = rdlcFile;

            //Mesh Remove
            //reportViewer.LocalReport.ReportPath = "ReportOperatorActionsAudit.rdlc";
            //// get the data
            //Database db = new Database(dbConnStr);
            //db.OpenConnection();
            //DataTable dt = db.ExecuteQuery(" EXEC ExwoldTracking.dbo.Report_AuditReportOperatorActions '" 
            //    + StartDatePicker.Value.ToString("yyyy-MM-dd")
            //    + "', '" + EndDatePicker.Value.ToString("yyyy-MM-dd") + "' ");

            // get the data
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("StartDateTime", StartDatePicker.Value.ToString("yyyy-MM-dd"));
            _db.QueryParameters.Add("EndDateTime", EndDatePicker.Value.ToString("yyyy-MM-dd"));
            DataTable dt = await _db.executeSP("[dbo].[Report_AuditReportOperatorActions]", true);

            dt.TableName = "ReportData";
            // Create a report data source for the sales order data  
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "RptData";
            reportDataSource.Value = dt;
            // add dataset to report
            rvDisplay.LocalReport.DataSources.Clear();
            rvDisplay.LocalReport.DataSources.Add(reportDataSource);

            // Refresh the report  
            rvDisplay.RefreshReport();
        }

        /// <summary>
        /// Resize handler: set tehreport viewer size to fill the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportProductAudit_Resize(object sender, EventArgs e)
        {
            if (this.Width > 200 && this.Height > 100)
            {
                rvDisplay.Width = this.Width - 50;
                rvDisplay.Height = this.Height - rvDisplay.Top - 50;

            }
        }

        /// <summary>
        /// CloseButton Handler: Close the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
