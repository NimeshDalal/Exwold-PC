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
    public partial class rptSalesOrder : Form
    {
        #region Local Variables
        //Date variables
        private DataInterface.clsDatabase _db = null;
        #endregion
        #region Properties
        internal DataInterface.clsDatabase DB
        {
            get { return _db; }
            set { _db = value; }
        }
        public string PalletBatchNo { get; set; }

        #endregion
        public rptSalesOrder()
        {
            InitializeComponent();
        }

        private void rptSalesOrder_Load(object sender, EventArgs e)
        {
            //set fullscreen
            this.TopMost = true;

            /*
             * Check if the status is Ready to Print
             * If the status is 3, then change it to 4
             */
            
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("@PalletBatchUniqueNo", PalletBatchNo.ToString());
            _db.QueryParameters.Add("@FromStatus","3");
            _db.QueryParameters.Add("@ToStatus","4");

            DataTable dtCurrentBatch = _db.ExecuteSP("[GUI].[updatePalletBatchStatus]", true);

            string sql = "SELECT * FROM data.PalletBatch WHERE PalletBatchUniqueNo = " + PalletBatchNo;
            //Mesh Remove
            //DataTable dtCurrentBatch = Program.ExwoldDb.ExecuteQuery(sql);

            //if (dtCurrentBatch.Rows[0].Field<Int16>("Status") == 3)
            //{
            //    //change Status to Completed
            //    sql = "UPDATE Data.PalletBatch SET Status = 4 " +
            //        " WHERE PalletBatchUniqueNo = " + PalletBatchNo;

            //    Program.ExwoldDb.ExecuteNonQuery(sql);
            //}


            //Get the data for the report
            _db.QueryParameters.Clear();
            _db.QueryParameters.Add("@PalletBatchNo", PalletBatchNo.ToString());

            //Set the location of the report definition
            reportViewer1.LocalReport.ReportEmbeddedResource = "ITS.Exwold.Desktop.Reports.SalesOrderReport.rdlc";
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.EnableExternalImages = true;
            //reportViewer1.LocalReport.ReportEmbeddedResource = ".\\Reports\\BatchReport.rdlc";

            //Get the report Data
            DataTable dtRptData = _db.ExecuteSP("Report_PalletReport", true);

            
            Reports.dsSalesOrders _data = new Reports.dsSalesOrders();

            _data.Tables.Clear();
            _data.Tables.Add(dtRptData.Copy());
            ReportDataSource rds = new ReportDataSource("DataSet1", _data.Tables[0]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();

           
            this.reportViewer1.RefreshReport();
        }
    }
}
