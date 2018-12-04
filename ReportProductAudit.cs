//******************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd.
// All Rights Reserved.
//
// DISCUSSION
// Provides the Audit Report for the Products.
//
// MODIFICATION HISTORY
// Version  Project/CR      Date        By                  References
//    1.00  702678          05Apr2017   Martin Cox 
//          Initial Creation
//
//******************************************************************************
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

namespace ExwoldPcInterface
{
    /// <summary>
    /// Provids the Products Audit Report
    /// </summary>
    public partial class ReportProductAudit : Form
    {
        string dbConnStr = "";


        /// <summary>
        /// Constructor
        /// </summary>
        public ReportProductAudit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbConnectionString">Database Connection string to use.</param>
        public ReportProductAudit(string dbConnectionString)
        {
            InitializeComponent();
            this.dbConnStr = dbConnectionString;
        }

        /// <summary>
        /// OnLoad: Set form to max size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportProductAudit_Load(object sender, EventArgs e)
        {
            // set form maximised
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        /// <summary>
        /// RunReportButton handler: get the data, display it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunProductReportButton_Click(object sender, EventArgs e)
        {
            // set the report layout to use
            reportViewer.LocalReport.ReportPath = "ReportProductAudit.rdlc";
            // get the data
            Database db = new Database(dbConnStr);
            db.OpenConnection();
            DataTable dt = db.ExecuteQuery(" EXEC ExwoldTracking.dbo.Report_AuditReportProducts '" + StartDatePicker.Value.ToString("yyyy-MM-dd")
                                                                                          + "', '" + EndDatePicker.Value.ToString("yyyy-MM-dd") + "' ");
            dt.TableName = "ReportData";
            // Create a report data source for the sales order data  
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = dt;
            // add dataset to report
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);

            // Refresh the report  
            reportViewer.RefreshReport();
        }


        private void RunPalletBatchReportButton_Click(object sender, EventArgs e)
        {
            // set the report layout to use
            reportViewer.LocalReport.ReportPath = "ReportPalletBatchAudit.rdlc";
            // get the data
            Database db = new Database(dbConnStr);
            db.OpenConnection();
            DataTable dt = db.ExecuteQuery(" EXEC ExwoldTracking.dbo.Report_AuditReportPalletBatches '" + StartDatePicker.Value.ToString("yyyy-MM-dd")
                                                                                               + "', '" + EndDatePicker.Value.ToString("yyyy-MM-dd") + "' ");
            dt.TableName = "ReportData";
            // Create a report data source for the sales order data  
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = dt;
            // add dataset to report
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);

            // Refresh the report  
            reportViewer.RefreshReport();
        }


        private void RunGeneralReportButton_Click(object sender, EventArgs e)
        {
            // set the report layout to use
            reportViewer.LocalReport.ReportPath = "ReportOperatorActionsAudit.rdlc";
            // get the data
            Database db = new Database(dbConnStr);
            db.OpenConnection();
            DataTable dt = db.ExecuteQuery(" EXEC ExwoldTracking.dbo.Report_AuditReportOperatorActions '" + StartDatePicker.Value.ToString("yyyy-MM-dd")
                                                                                                 + "', '" + EndDatePicker.Value.ToString("yyyy-MM-dd") + "' ");
            dt.TableName = "ReportData";
            // Create a report data source for the sales order data  
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = dt;
            // add dataset to report
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);

            // Refresh the report  
            reportViewer.RefreshReport();
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
                reportViewer.Width = this.Width - 50;
                reportViewer.Height = this.Height - reportViewer.Top - 50;

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
