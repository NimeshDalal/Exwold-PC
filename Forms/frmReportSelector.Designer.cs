namespace ITS.Exwold.Desktop
{
    partial class frmReportSelector
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblSalesOrderRpt = new System.Windows.Forms.Label();
            this.btnRunSalesOrderRpt = new System.Windows.Forms.Button();
            this.lblSelectSalesOrderRpt = new System.Windows.Forms.Label();
            this.lblSelectBatchRpt = new System.Windows.Forms.Label();
            this.btnRunBatchRpt = new System.Windows.Forms.Button();
            this.lblBatchRpt = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.lblSelectSCCSRpt = new System.Windows.Forms.Label();
            this.btnRunSSCCReport = new System.Windows.Forms.Button();
            this.lblSSCCRpt = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.pnlRptSelector = new System.Windows.Forms.Panel();
            this.cboBatchRpt = new System.Windows.Forms.ComboBox();
            this.lblRptMsg = new System.Windows.Forms.Label();
            this.cboSSCCRpt = new System.Windows.Forms.ComboBox();
            this.cboSalesOrderRpt = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.pnlRptSelector.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(31, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(175, 20);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Pallet Tracker - Reports";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(983, 15);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(130, 25);
            this.buttonClose.TabIndex = 57;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(267, 415);
            this.dataGridView1.TabIndex = 0;
            // 
            // lblSalesOrderRpt
            // 
            this.lblSalesOrderRpt.AutoSize = true;
            this.lblSalesOrderRpt.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSalesOrderRpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesOrderRpt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSalesOrderRpt.Location = new System.Drawing.Point(82, 18);
            this.lblSalesOrderRpt.Name = "lblSalesOrderRpt";
            this.lblSalesOrderRpt.Size = new System.Drawing.Size(146, 20);
            this.lblSalesOrderRpt.TabIndex = 63;
            this.lblSalesOrderRpt.Text = "Sales Order Report";
            // 
            // btnRunSalesOrderRpt
            // 
            this.btnRunSalesOrderRpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunSalesOrderRpt.Location = new System.Drawing.Point(86, 274);
            this.btnRunSalesOrderRpt.Name = "btnRunSalesOrderRpt";
            this.btnRunSalesOrderRpt.Size = new System.Drawing.Size(97, 23);
            this.btnRunSalesOrderRpt.TabIndex = 65;
            this.btnRunSalesOrderRpt.Tag = "SalesOrder";
            this.btnRunSalesOrderRpt.Text = "Run";
            this.btnRunSalesOrderRpt.UseVisualStyleBackColor = true;
            this.btnRunSalesOrderRpt.Click += new System.EventHandler(this.btnRunRpt_Click);
            // 
            // lblSelectSalesOrderRpt
            // 
            this.lblSelectSalesOrderRpt.AutoSize = true;
            this.lblSelectSalesOrderRpt.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSelectSalesOrderRpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectSalesOrderRpt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSelectSalesOrderRpt.Location = new System.Drawing.Point(56, 149);
            this.lblSelectSalesOrderRpt.Name = "lblSelectSalesOrderRpt";
            this.lblSelectSalesOrderRpt.Size = new System.Drawing.Size(167, 34);
            this.lblSelectSalesOrderRpt.TabIndex = 66;
            this.lblSelectSalesOrderRpt.Text = "Select Sales Order below\r\nthen press run.";
            // 
            // lblSelectBatchRpt
            // 
            this.lblSelectBatchRpt.AutoSize = true;
            this.lblSelectBatchRpt.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSelectBatchRpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectBatchRpt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSelectBatchRpt.Location = new System.Drawing.Point(702, 149);
            this.lblSelectBatchRpt.Name = "lblSelectBatchRpt";
            this.lblSelectBatchRpt.Size = new System.Drawing.Size(181, 34);
            this.lblSelectBatchRpt.TabIndex = 76;
            this.lblSelectBatchRpt.Text = "Select Material Batch below\r\nthen press run.";
            // 
            // btnRunBatchRpt
            // 
            this.btnRunBatchRpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunBatchRpt.Location = new System.Drawing.Point(738, 274);
            this.btnRunBatchRpt.Name = "btnRunBatchRpt";
            this.btnRunBatchRpt.Size = new System.Drawing.Size(97, 23);
            this.btnRunBatchRpt.TabIndex = 75;
            this.btnRunBatchRpt.Tag = "Batch";
            this.btnRunBatchRpt.Text = "Run";
            this.btnRunBatchRpt.UseVisualStyleBackColor = true;
            this.btnRunBatchRpt.Click += new System.EventHandler(this.btnRunRpt_Click);
            // 
            // lblBatchRpt
            // 
            this.lblBatchRpt.AutoSize = true;
            this.lblBatchRpt.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblBatchRpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchRpt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBatchRpt.Location = new System.Drawing.Point(689, 18);
            this.lblBatchRpt.Name = "lblBatchRpt";
            this.lblBatchRpt.Size = new System.Drawing.Size(185, 20);
            this.lblBatchRpt.TabIndex = 73;
            this.lblBatchRpt.Text = "Batch Genealogy Report";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(653, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(267, 415);
            this.dataGridView3.TabIndex = 72;
            // 
            // lblSelectSCCSRpt
            // 
            this.lblSelectSCCSRpt.AutoSize = true;
            this.lblSelectSCCSRpt.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSelectSCCSRpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectSCCSRpt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSelectSCCSRpt.Location = new System.Drawing.Point(399, 149);
            this.lblSelectSCCSRpt.Name = "lblSelectSCCSRpt";
            this.lblSelectSCCSRpt.Size = new System.Drawing.Size(127, 34);
            this.lblSelectSCCSRpt.TabIndex = 81;
            this.lblSelectSCCSRpt.Text = "Select SSCC below\r\nthen press run.";
            // 
            // btnRunSSCCReport
            // 
            this.btnRunSSCCReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunSSCCReport.Location = new System.Drawing.Point(413, 274);
            this.btnRunSSCCReport.Name = "btnRunSSCCReport";
            this.btnRunSSCCReport.Size = new System.Drawing.Size(97, 23);
            this.btnRunSSCCReport.TabIndex = 80;
            this.btnRunSSCCReport.Tag = "SSCC";
            this.btnRunSSCCReport.Text = "Run";
            this.btnRunSSCCReport.UseVisualStyleBackColor = true;
            this.btnRunSSCCReport.Click += new System.EventHandler(this.btnRunRpt_Click);
            // 
            // lblSSCCRpt
            // 
            this.lblSSCCRpt.AutoSize = true;
            this.lblSSCCRpt.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSSCCRpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSSCCRpt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSSCCRpt.Location = new System.Drawing.Point(373, 18);
            this.lblSSCCRpt.Name = "lblSSCCRpt";
            this.lblSSCCRpt.Size = new System.Drawing.Size(187, 20);
            this.lblSSCCRpt.TabIndex = 78;
            this.lblSSCCRpt.Text = "SSCC Genealogy Report";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(328, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(267, 415);
            this.dataGridView2.TabIndex = 77;
            // 
            // pnlRptSelector
            // 
            this.pnlRptSelector.Controls.Add(this.cboBatchRpt);
            this.pnlRptSelector.Controls.Add(this.lblRptMsg);
            this.pnlRptSelector.Controls.Add(this.cboSSCCRpt);
            this.pnlRptSelector.Controls.Add(this.lblSelectSCCSRpt);
            this.pnlRptSelector.Controls.Add(this.cboSalesOrderRpt);
            this.pnlRptSelector.Controls.Add(this.btnRunSSCCReport);
            this.pnlRptSelector.Controls.Add(this.lblSSCCRpt);
            this.pnlRptSelector.Controls.Add(this.dataGridView2);
            this.pnlRptSelector.Controls.Add(this.lblSelectBatchRpt);
            this.pnlRptSelector.Controls.Add(this.btnRunBatchRpt);
            this.pnlRptSelector.Controls.Add(this.lblBatchRpt);
            this.pnlRptSelector.Controls.Add(this.dataGridView3);
            this.pnlRptSelector.Controls.Add(this.lblSelectSalesOrderRpt);
            this.pnlRptSelector.Controls.Add(this.btnRunSalesOrderRpt);
            this.pnlRptSelector.Controls.Add(this.lblSalesOrderRpt);
            this.pnlRptSelector.Controls.Add(this.dataGridView1);
            this.pnlRptSelector.Location = new System.Drawing.Point(33, 175);
            this.pnlRptSelector.Name = "pnlRptSelector";
            this.pnlRptSelector.Size = new System.Drawing.Size(1040, 500);
            this.pnlRptSelector.TabIndex = 82;
            // 
            // cboBatchRpt
            // 
            this.cboBatchRpt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBatchRpt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBatchRpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBatchRpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBatchRpt.FormattingEnabled = true;
            this.cboBatchRpt.Location = new System.Drawing.Point(705, 196);
            this.cboBatchRpt.Name = "cboBatchRpt";
            this.cboBatchRpt.Size = new System.Drawing.Size(163, 24);
            this.cboBatchRpt.TabIndex = 83;
            this.cboBatchRpt.SelectedIndexChanged += new System.EventHandler(this.cboTest_SelectedIndexChanged);
            // 
            // lblRptMsg
            // 
            this.lblRptMsg.AutoSize = true;
            this.lblRptMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRptMsg.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblRptMsg.Location = new System.Drawing.Point(284, 428);
            this.lblRptMsg.Name = "lblRptMsg";
            this.lblRptMsg.Size = new System.Drawing.Size(353, 20);
            this.lblRptMsg.TabIndex = 82;
            this.lblRptMsg.Text = "Report Being Generated - Please wait........";
            // 
            // cboSSCCRpt
            // 
            this.cboSSCCRpt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSSCCRpt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSSCCRpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSSCCRpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSSCCRpt.FormattingEnabled = true;
            this.cboSSCCRpt.Location = new System.Drawing.Point(377, 196);
            this.cboSSCCRpt.Name = "cboSSCCRpt";
            this.cboSSCCRpt.Size = new System.Drawing.Size(163, 24);
            this.cboSSCCRpt.TabIndex = 83;
            this.cboSSCCRpt.SelectedIndexChanged += new System.EventHandler(this.cboTest_SelectedIndexChanged);
            // 
            // cboSalesOrderRpt
            // 
            this.cboSalesOrderRpt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSalesOrderRpt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSalesOrderRpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSalesOrderRpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSalesOrderRpt.FormattingEnabled = true;
            this.cboSalesOrderRpt.Location = new System.Drawing.Point(59, 196);
            this.cboSalesOrderRpt.Name = "cboSalesOrderRpt";
            this.cboSalesOrderRpt.Size = new System.Drawing.Size(163, 24);
            this.cboSalesOrderRpt.TabIndex = 83;
            this.cboSalesOrderRpt.SelectedIndexChanged += new System.EventHandler(this.cboTest_SelectedIndexChanged);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 705);
            this.ControlBox = false;
            this.Controls.Add(this.pnlRptSelector);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.buttonClose);
            this.Name = "frmReports";
            this.Text = "EXWOLD PALLET TRACKING";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.pnlRptSelector.ResumeLayout(false);
            this.pnlRptSelector.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblSalesOrderRpt;
        private System.Windows.Forms.Button btnRunSalesOrderRpt;
        private System.Windows.Forms.Label lblSelectSalesOrderRpt;
        private System.Windows.Forms.Label lblSelectBatchRpt;
        private System.Windows.Forms.Button btnRunBatchRpt;
        private System.Windows.Forms.Label lblBatchRpt;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label lblSelectSCCSRpt;
        private System.Windows.Forms.Button btnRunSSCCReport;
        private System.Windows.Forms.Label lblSSCCRpt;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel pnlRptSelector;
        private System.Windows.Forms.Label lblRptMsg;
        private System.Windows.Forms.ComboBox cboSalesOrderRpt;
        private System.Windows.Forms.ComboBox cboSSCCRpt;
        private System.Windows.Forms.ComboBox cboBatchRpt;
    }
}

