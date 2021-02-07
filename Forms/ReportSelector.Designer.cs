namespace ITS.Exwold.Desktop
{
    partial class ReportSelector
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
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.lblBatchRpt = new System.Windows.Forms.Label();
            this.btnRunBatchRpt = new System.Windows.Forms.Button();
            this.lblSelectBatchRpt = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.lblSSCCRpt = new System.Windows.Forms.Label();
            this.btnRunSSCCReport = new System.Windows.Forms.Button();
            this.cboSalesOrderRpt = new System.Windows.Forms.ComboBox();
            this.lblSelectSCCSRpt = new System.Windows.Forms.Label();
            this.cboSSCCRpt = new System.Windows.Forms.ComboBox();
            this.lblRptMsg = new System.Windows.Forms.Label();
            this.cboBatchRpt = new System.Windows.Forms.ComboBox();
            this.pnlRptSelector = new System.Windows.Forms.Panel();
            this.grpButtons = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.pnlRptSelector.SuspendLayout();
            this.grpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Palatino Linotype", 18F);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1484, 34);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Pallet Tracker - Reports";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.buttonClose.Location = new System.Drawing.Point(1329, 18);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(148, 39);
            this.buttonClose.TabIndex = 57;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 31);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(400, 702);
            this.dataGridView1.TabIndex = 0;
            // 
            // lblSalesOrderRpt
            // 
            this.lblSalesOrderRpt.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSalesOrderRpt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSalesOrderRpt.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesOrderRpt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSalesOrderRpt.Location = new System.Drawing.Point(28, 31);
            this.lblSalesOrderRpt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalesOrderRpt.Name = "lblSalesOrderRpt";
            this.lblSalesOrderRpt.Size = new System.Drawing.Size(400, 38);
            this.lblSalesOrderRpt.TabIndex = 63;
            this.lblSalesOrderRpt.Text = "Sales Order Report";
            this.lblSalesOrderRpt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRunSalesOrderRpt
            // 
            this.btnRunSalesOrderRpt.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.btnRunSalesOrderRpt.Location = new System.Drawing.Point(131, 495);
            this.btnRunSalesOrderRpt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRunSalesOrderRpt.Name = "btnRunSalesOrderRpt";
            this.btnRunSalesOrderRpt.Size = new System.Drawing.Size(146, 39);
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
            this.lblSelectSalesOrderRpt.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.lblSelectSalesOrderRpt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSelectSalesOrderRpt.Location = new System.Drawing.Point(116, 283);
            this.lblSelectSalesOrderRpt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectSalesOrderRpt.Name = "lblSelectSalesOrderRpt";
            this.lblSelectSalesOrderRpt.Size = new System.Drawing.Size(176, 44);
            this.lblSelectSalesOrderRpt.TabIndex = 66;
            this.lblSelectSalesOrderRpt.Text = "Select Sales Order below\r\nthen press run.";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(1054, 31);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(400, 702);
            this.dataGridView3.TabIndex = 72;
            // 
            // lblBatchRpt
            // 
            this.lblBatchRpt.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblBatchRpt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBatchRpt.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchRpt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBatchRpt.Location = new System.Drawing.Point(1053, 31);
            this.lblBatchRpt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBatchRpt.Name = "lblBatchRpt";
            this.lblBatchRpt.Size = new System.Drawing.Size(401, 38);
            this.lblBatchRpt.TabIndex = 73;
            this.lblBatchRpt.Text = "Batch Genealogy Report";
            this.lblBatchRpt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRunBatchRpt
            // 
            this.btnRunBatchRpt.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.btnRunBatchRpt.Location = new System.Drawing.Point(1157, 495);
            this.btnRunBatchRpt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRunBatchRpt.Name = "btnRunBatchRpt";
            this.btnRunBatchRpt.Size = new System.Drawing.Size(146, 39);
            this.btnRunBatchRpt.TabIndex = 75;
            this.btnRunBatchRpt.Tag = "Batch";
            this.btnRunBatchRpt.Text = "Run";
            this.btnRunBatchRpt.UseVisualStyleBackColor = true;
            this.btnRunBatchRpt.Click += new System.EventHandler(this.btnRunRpt_Click);
            // 
            // lblSelectBatchRpt
            // 
            this.lblSelectBatchRpt.AutoSize = true;
            this.lblSelectBatchRpt.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSelectBatchRpt.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.lblSelectBatchRpt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSelectBatchRpt.Location = new System.Drawing.Point(1132, 283);
            this.lblSelectBatchRpt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectBatchRpt.Name = "lblSelectBatchRpt";
            this.lblSelectBatchRpt.Size = new System.Drawing.Size(197, 44);
            this.lblSelectBatchRpt.TabIndex = 76;
            this.lblSelectBatchRpt.Text = "Select Material Batch below\r\nthen press run.";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(541, 31);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(400, 702);
            this.dataGridView2.TabIndex = 77;
            // 
            // lblSSCCRpt
            // 
            this.lblSSCCRpt.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSSCCRpt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSSCCRpt.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSSCCRpt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSSCCRpt.Location = new System.Drawing.Point(541, 31);
            this.lblSSCCRpt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSSCCRpt.Name = "lblSSCCRpt";
            this.lblSSCCRpt.Size = new System.Drawing.Size(400, 38);
            this.lblSSCCRpt.TabIndex = 78;
            this.lblSSCCRpt.Text = "SSCC Genealogy Report";
            this.lblSSCCRpt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRunSSCCReport
            // 
            this.btnRunSSCCReport.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.btnRunSSCCReport.Location = new System.Drawing.Point(619, 495);
            this.btnRunSSCCReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRunSSCCReport.Name = "btnRunSSCCReport";
            this.btnRunSSCCReport.Size = new System.Drawing.Size(146, 39);
            this.btnRunSSCCReport.TabIndex = 80;
            this.btnRunSSCCReport.Tag = "SSCC";
            this.btnRunSSCCReport.Text = "Run";
            this.btnRunSSCCReport.UseVisualStyleBackColor = true;
            this.btnRunSSCCReport.Click += new System.EventHandler(this.btnRunRpt_Click);
            // 
            // cboSalesOrderRpt
            // 
            this.cboSalesOrderRpt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSalesOrderRpt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSalesOrderRpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSalesOrderRpt.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.cboSalesOrderRpt.FormattingEnabled = true;
            this.cboSalesOrderRpt.Location = new System.Drawing.Point(83, 363);
            this.cboSalesOrderRpt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboSalesOrderRpt.Name = "cboSalesOrderRpt";
            this.cboSalesOrderRpt.Size = new System.Drawing.Size(242, 30);
            this.cboSalesOrderRpt.TabIndex = 83;
            this.cboSalesOrderRpt.SelectedIndexChanged += new System.EventHandler(this.cboTest_SelectedIndexChanged);
            // 
            // lblSelectSCCSRpt
            // 
            this.lblSelectSCCSRpt.AutoSize = true;
            this.lblSelectSCCSRpt.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSelectSCCSRpt.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.lblSelectSCCSRpt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSelectSCCSRpt.Location = new System.Drawing.Point(624, 283);
            this.lblSelectSCCSRpt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectSCCSRpt.Name = "lblSelectSCCSRpt";
            this.lblSelectSCCSRpt.Size = new System.Drawing.Size(137, 44);
            this.lblSelectSCCSRpt.TabIndex = 81;
            this.lblSelectSCCSRpt.Text = "Select SSCC below\r\nthen press run.";
            // 
            // cboSSCCRpt
            // 
            this.cboSSCCRpt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSSCCRpt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSSCCRpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSSCCRpt.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.cboSSCCRpt.FormattingEnabled = true;
            this.cboSSCCRpt.Location = new System.Drawing.Point(571, 363);
            this.cboSSCCRpt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboSSCCRpt.Name = "cboSSCCRpt";
            this.cboSSCCRpt.Size = new System.Drawing.Size(242, 30);
            this.cboSSCCRpt.TabIndex = 83;
            this.cboSSCCRpt.SelectedIndexChanged += new System.EventHandler(this.cboTest_SelectedIndexChanged);
            // 
            // lblRptMsg
            // 
            this.lblRptMsg.AutoSize = true;
            this.lblRptMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRptMsg.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblRptMsg.Location = new System.Drawing.Point(516, 761);
            this.lblRptMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRptMsg.Name = "lblRptMsg";
            this.lblRptMsg.Size = new System.Drawing.Size(353, 20);
            this.lblRptMsg.TabIndex = 82;
            this.lblRptMsg.Text = "Report Being Generated - Please wait........";
            // 
            // cboBatchRpt
            // 
            this.cboBatchRpt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBatchRpt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBatchRpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBatchRpt.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.cboBatchRpt.FormattingEnabled = true;
            this.cboBatchRpt.Location = new System.Drawing.Point(1109, 363);
            this.cboBatchRpt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboBatchRpt.Name = "cboBatchRpt";
            this.cboBatchRpt.Size = new System.Drawing.Size(242, 30);
            this.cboBatchRpt.TabIndex = 83;
            this.cboBatchRpt.SelectedIndexChanged += new System.EventHandler(this.cboTest_SelectedIndexChanged);
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
            this.pnlRptSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRptSelector.Location = new System.Drawing.Point(0, 34);
            this.pnlRptSelector.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlRptSelector.Name = "pnlRptSelector";
            this.pnlRptSelector.Size = new System.Drawing.Size(1484, 927);
            this.pnlRptSelector.TabIndex = 82;
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add(this.buttonClose);
            this.grpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpButtons.Location = new System.Drawing.Point(0, 897);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Size = new System.Drawing.Size(1484, 64);
            this.grpButtons.TabIndex = 83;
            this.grpButtons.TabStop = false;
            // 
            // ReportSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 961);
            this.ControlBox = false;
            this.Controls.Add(this.grpButtons);
            this.Controls.Add(this.pnlRptSelector);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ReportSelector";
            this.Text = "EXWOLD PALLET TRACKING";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.pnlRptSelector.ResumeLayout(false);
            this.pnlRptSelector.PerformLayout();
            this.grpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblSalesOrderRpt;
        private System.Windows.Forms.Button btnRunSalesOrderRpt;
        private System.Windows.Forms.Label lblSelectSalesOrderRpt;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label lblBatchRpt;
        private System.Windows.Forms.Button btnRunBatchRpt;
        private System.Windows.Forms.Label lblSelectBatchRpt;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label lblSSCCRpt;
        private System.Windows.Forms.Button btnRunSSCCReport;
        private System.Windows.Forms.ComboBox cboSalesOrderRpt;
        private System.Windows.Forms.Label lblSelectSCCSRpt;
        private System.Windows.Forms.ComboBox cboSSCCRpt;
        private System.Windows.Forms.Label lblRptMsg;
        private System.Windows.Forms.ComboBox cboBatchRpt;
        private System.Windows.Forms.Panel pnlRptSelector;
        private System.Windows.Forms.GroupBox grpButtons;
    }
}

