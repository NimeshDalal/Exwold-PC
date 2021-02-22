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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rvDisplay = new Microsoft.Reporting.WinForms.ReportViewer();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRunProductReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRunPalletBatchReport = new System.Windows.Forms.Button();
            this.btnRunGeneralReport = new System.Windows.Forms.Button();
            this.Report_AuditReportProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Report_AuditReportProductsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvDisplay
            // 
            this.rvDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource3.Name = "AuditReportProducts";
            this.rvDisplay.LocalReport.DataSources.Add(reportDataSource3);
            this.rvDisplay.LocalReport.ReportEmbeddedResource = "ITS.Exwold.ReportProductAudit.rdlc";
            this.rvDisplay.Location = new System.Drawing.Point(0, 75);
            this.rvDisplay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rvDisplay.Name = "rvDisplay";
            this.rvDisplay.ServerReport.BearerToken = null;
            this.rvDisplay.Size = new System.Drawing.Size(2019, 1059);
            this.rvDisplay.TabIndex = 0;
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Location = new System.Drawing.Point(438, 3);
            this.StartDatePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(298, 29);
            this.StartDatePicker.TabIndex = 1;
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Location = new System.Drawing.Point(438, 35);
            this.EndDatePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(298, 29);
            this.EndDatePicker.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "End Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 44);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select the start and end dates (inclusive),\r\nthen ckick \'Run Report\'.";
            // 
            // btnRunProductReport
            // 
            this.btnRunProductReport.Location = new System.Drawing.Point(740, 3);
            this.btnRunProductReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRunProductReport.Name = "btnRunProductReport";
            this.btnRunProductReport.Size = new System.Drawing.Size(225, 39);
            this.btnRunProductReport.TabIndex = 6;
            this.btnRunProductReport.Text = "Product Config Audit Report";
            this.btnRunProductReport.UseVisualStyleBackColor = true;
            this.btnRunProductReport.Click += new System.EventHandler(this.RunProductReportButton_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1871, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(148, 39);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // btnRunPalletBatchReport
            // 
            this.btnRunPalletBatchReport.Location = new System.Drawing.Point(965, 3);
            this.btnRunPalletBatchReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRunPalletBatchReport.Name = "btnRunPalletBatchReport";
            this.btnRunPalletBatchReport.Size = new System.Drawing.Size(225, 39);
            this.btnRunPalletBatchReport.TabIndex = 8;
            this.btnRunPalletBatchReport.Text = "Sales Order Audit Report";
            this.btnRunPalletBatchReport.UseVisualStyleBackColor = true;
            this.btnRunPalletBatchReport.Click += new System.EventHandler(this.RunPalletBatchReportButton_Click);
            // 
            // btnRunGeneralReport
            // 
            this.btnRunGeneralReport.Location = new System.Drawing.Point(1190, 3);
            this.btnRunGeneralReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRunGeneralReport.Name = "btnRunGeneralReport";
            this.btnRunGeneralReport.Size = new System.Drawing.Size(225, 39);
            this.btnRunGeneralReport.TabIndex = 9;
            this.btnRunGeneralReport.Text = "General Audit Report";
            this.btnRunGeneralReport.UseVisualStyleBackColor = true;
            this.btnRunGeneralReport.Click += new System.EventHandler(this.RunGeneralReportButton_Click);
            // 
            // frmAuditReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2022, 1134);
            this.ControlBox = false;
            this.Controls.Add(this.btnRunGeneralReport);
            this.Controls.Add(this.btnRunPalletBatchReport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRunProductReport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.rvDisplay);
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.Button btnRunProductReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRunPalletBatchReport;
        private System.Windows.Forms.Button btnRunGeneralReport;
        private System.Windows.Forms.BindingSource Report_AuditReportProductsBindingSource;
    }
}