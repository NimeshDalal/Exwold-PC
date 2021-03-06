﻿namespace ITS.Exwold.Desktop
{
    partial class SSCCReportForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Report_GenealogyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExwoldTrackingDataSet2 = new ITS.Exwold.Desktop.ExwoldTrackingDataSet2();
            this.Report_PalletReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Report_GenealogyTableAdapter = new ITS.Exwold.Desktop.ExwoldTrackingDataSet2TableAdapters.Report_GenealogyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Report_GenealogyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExwoldTrackingDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Report_PalletReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Report_GenealogyBindingSource
            // 
            this.Report_GenealogyBindingSource.DataMember = "Report_Genealogy";
            this.Report_GenealogyBindingSource.DataSource = this.ExwoldTrackingDataSet2;
            // 
            // ExwoldTrackingDataSet2
            // 
            this.ExwoldTrackingDataSet2.DataSetName = "ExwoldTrackingDataSet2";
            this.ExwoldTrackingDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.Report_GenealogyBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ITS.Exwold.Desktop.SSCCReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1038, 622);
            this.reportViewer1.TabIndex = 0;
            // 
            // Report_GenealogyTableAdapter
            // 
            this.Report_GenealogyTableAdapter.ClearBeforeFill = true;
            // 
            // SSCCReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 622);
            this.Controls.Add(this.reportViewer1);
            this.Name = "SSCCReportForm";
            this.Text = "SSCC Report";
            this.Load += new System.EventHandler(this.SSCCReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Report_GenealogyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExwoldTrackingDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Report_PalletReportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource Report_PalletReportBindingSource;
        private System.Windows.Forms.BindingSource Report_GenealogyBindingSource;
        private ITS.Exwold.Desktop.ExwoldTrackingDataSet2 ExwoldTrackingDataSet2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ITS.Exwold.Desktop.ExwoldTrackingDataSet2TableAdapters.Report_GenealogyTableAdapter Report_GenealogyTableAdapter;
    }
}