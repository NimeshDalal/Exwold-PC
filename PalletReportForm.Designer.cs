namespace ExwoldPcInterface
{
    partial class PalletReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Report_PalletReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExwoldTrackingDataSet = new ExwoldPcInterface.ExwoldTrackingDataSet();
            this.reportViewerPalletReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Report_PalletReportTableAdapter = new ExwoldPcInterface.ExwoldTrackingDataSetTableAdapters.Report_PalletReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Report_PalletReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExwoldTrackingDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // Report_PalletReportBindingSource
            // 
            this.Report_PalletReportBindingSource.DataMember = "Report_PalletReport";
            this.Report_PalletReportBindingSource.DataSource = this.ExwoldTrackingDataSet;
            // 
            // ExwoldTrackingDataSet
            // 
            this.ExwoldTrackingDataSet.DataSetName = "ExwoldTrackingDataSet";
            this.ExwoldTrackingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewerPalletReport
            // 
            this.reportViewerPalletReport.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.Report_PalletReportBindingSource;
            this.reportViewerPalletReport.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewerPalletReport.LocalReport.ReportEmbeddedResource = "ExwoldPcInterface.PalletReport.rdlc";
            this.reportViewerPalletReport.Location = new System.Drawing.Point(0, 0);
            this.reportViewerPalletReport.Name = "reportViewerPalletReport";
            this.reportViewerPalletReport.Size = new System.Drawing.Size(1038, 622);
            this.reportViewerPalletReport.TabIndex = 0;
            this.reportViewerPalletReport.Load += new System.EventHandler(this.reportViewerPalletReport_Load);
            // 
            // Report_PalletReportTableAdapter
            // 
            this.Report_PalletReportTableAdapter.ClearBeforeFill = true;
            // 
            // PalletReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 622);
            this.Controls.Add(this.reportViewerPalletReport);
            this.Name = "PalletReportForm";
            this.Text = "Sales Order Report";
            this.Load += new System.EventHandler(this.PalletReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Report_PalletReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExwoldTrackingDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerPalletReport;
        private System.Windows.Forms.BindingSource Report_PalletReportBindingSource;
        private ExwoldTrackingDataSet ExwoldTrackingDataSet;
        private ExwoldTrackingDataSetTableAdapters.Report_PalletReportTableAdapter Report_PalletReportTableAdapter;
    }
}