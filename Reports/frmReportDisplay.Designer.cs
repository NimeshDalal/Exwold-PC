namespace ITS.Exwold.Desktop
{
    partial class frmReportDisplay
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rvDisplay = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvDisplay
            // 
            this.rvDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = null;
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource1);
            this.rvDisplay.LocalReport.ReportEmbeddedResource = "ITS.Exwold.Desktop.Reports.PalletReport.rdlc";
            this.rvDisplay.Location = new System.Drawing.Point(0, 0);
            this.rvDisplay.Name = "rvDisplay";
            this.rvDisplay.ServerReport.BearerToken = null;
            this.rvDisplay.Size = new System.Drawing.Size(1058, 622);
            this.rvDisplay.TabIndex = 1;
            // 
            // frmReportDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 622);
            this.Controls.Add(this.rvDisplay);
            this.Name = "frmReportDisplay";
            this.Text = "Sales Order Report";
            this.Load += new System.EventHandler(this.rptSalesOrder_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer rvDisplay;
    }
}