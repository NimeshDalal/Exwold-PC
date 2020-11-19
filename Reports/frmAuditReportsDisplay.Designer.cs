namespace ITS.Exwold.Desktop
{
    partial class frmAuditReports
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
            this.Report_AuditReportProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rvDisplay = new Microsoft.Reporting.WinForms.ReportViewer();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RunProductReportButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.RunPalletBatchReportButton = new System.Windows.Forms.Button();
            this.RunGeneralReportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Report_AuditReportProductsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvDisplay
            // 
            this.rvDisplay.Dock = System.Windows.Forms.DockStyle.Bottom;
            reportDataSource1.Name = "AuditReportProducts";
            reportDataSource1.Value = this.Report_AuditReportProductsBindingSource;
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource1);
            this.rvDisplay.LocalReport.ReportEmbeddedResource = "ITS.Exwold.ReportProductAudit.rdlc";
            this.rvDisplay.Location = new System.Drawing.Point(0, 43);
            this.rvDisplay.Name = "rvDisplay";
            this.rvDisplay.ServerReport.BearerToken = null;
            this.rvDisplay.Size = new System.Drawing.Size(1585, 627);
            this.rvDisplay.TabIndex = 0;
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Location = new System.Drawing.Point(324, 17);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(200, 20);
            this.StartDatePicker.TabIndex = 1;
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Location = new System.Drawing.Point(685, 17);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(200, 20);
            this.EndDatePicker.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(605, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "End Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select the start and end dates (inclusive),\r\nthen ckick \'Run Report\'.";
            // 
            // RunProductReportButton
            // 
            this.RunProductReportButton.Location = new System.Drawing.Point(909, 14);
            this.RunProductReportButton.Name = "RunProductReportButton";
            this.RunProductReportButton.Size = new System.Drawing.Size(150, 23);
            this.RunProductReportButton.TabIndex = 6;
            this.RunProductReportButton.Text = "Product Config Audit Report";
            this.RunProductReportButton.UseVisualStyleBackColor = true;
            this.RunProductReportButton.Click += new System.EventHandler(this.RunProductReportButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(1498, 10);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // RunPalletBatchReportButton
            // 
            this.RunPalletBatchReportButton.Location = new System.Drawing.Point(1065, 14);
            this.RunPalletBatchReportButton.Name = "RunPalletBatchReportButton";
            this.RunPalletBatchReportButton.Size = new System.Drawing.Size(150, 23);
            this.RunPalletBatchReportButton.TabIndex = 8;
            this.RunPalletBatchReportButton.Text = "Sales Order Audit Report";
            this.RunPalletBatchReportButton.UseVisualStyleBackColor = true;
            this.RunPalletBatchReportButton.Click += new System.EventHandler(this.RunPalletBatchReportButton_Click);
            // 
            // RunGeneralReportButton
            // 
            this.RunGeneralReportButton.Location = new System.Drawing.Point(1221, 14);
            this.RunGeneralReportButton.Name = "RunGeneralReportButton";
            this.RunGeneralReportButton.Size = new System.Drawing.Size(150, 23);
            this.RunGeneralReportButton.TabIndex = 9;
            this.RunGeneralReportButton.Text = "General Audit Report";
            this.RunGeneralReportButton.UseVisualStyleBackColor = true;
            this.RunGeneralReportButton.Click += new System.EventHandler(this.RunGeneralReportButton_Click);
            // 
            // frmAuditReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1585, 670);
            this.ControlBox = false;
            this.Controls.Add(this.RunGeneralReportButton);
            this.Controls.Add(this.RunPalletBatchReportButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.RunProductReportButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.rvDisplay);
            this.Name = "frmAuditReports";
            this.Text = "Audit Reports";
            this.Load += new System.EventHandler(this.ReportProductAudit_Load);
            this.Resize += new System.EventHandler(this.ReportProductAudit_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.Report_AuditReportProductsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvDisplay;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button RunProductReportButton;
        private System.Windows.Forms.BindingSource Report_AuditReportProductsBindingSource;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button RunPalletBatchReportButton;
        private System.Windows.Forms.Button RunGeneralReportButton;
    }
}