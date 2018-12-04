namespace ExwoldPcInterface
{
    partial class ReportsForm
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
            this.label15 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label28 = new System.Windows.Forms.Label();
            this.comboBoxSelectPallet = new System.Windows.Forms.ComboBox();
            this.selectorPalletReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.exwoldTrackingDataSet1 = new ExwoldPcInterface.ExwoldTrackingDataSet1();
            this.buttonPalletReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBoxBatch = new System.Windows.Forms.ComboBox();
            this.selectorMBReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.exwoldTrackingDataSet3 = new ExwoldPcInterface.ExwoldTrackingDataSet3();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSSCCReport = new System.Windows.Forms.Button();
            this.comboBoxSSCC = new System.Windows.Forms.ComboBox();
            this.selectorSSCCReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.exwoldTrackingDataSetSSCC = new ExwoldPcInterface.ExwoldTrackingDataSetSSCC();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.selector_PalletReportTableAdapter = new ExwoldPcInterface.ExwoldTrackingDataSet1TableAdapters.Selector_PalletReportTableAdapter();
            this.selector_SSCCReportTableAdapter = new ExwoldPcInterface.ExwoldTrackingDataSetSSCCTableAdapters.Selector_SSCCReportTableAdapter();
            this.selector_MBReportTableAdapter = new ExwoldPcInterface.ExwoldTrackingDataSet3TableAdapters.Selector_MBReportTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelReport = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectorPalletReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exwoldTrackingDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectorMBReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exwoldTrackingDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectorSSCCReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exwoldTrackingDataSetSSCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(31, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(175, 20);
            this.label15.TabIndex = 7;
            this.label15.Text = "Pallet Tracker - Reports";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(1342, 15);
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
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label28.Location = new System.Drawing.Point(82, 18);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(146, 20);
            this.label28.TabIndex = 63;
            this.label28.Text = "Sales Order Report";
            // 
            // comboBoxSelectPallet
            // 
            this.comboBoxSelectPallet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxSelectPallet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxSelectPallet.DataSource = this.selectorPalletReportBindingSource;
            this.comboBoxSelectPallet.DisplayMember = "PalletBatchNo";
            this.comboBoxSelectPallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectPallet.FormattingEnabled = true;
            this.comboBoxSelectPallet.Location = new System.Drawing.Point(59, 196);
            this.comboBoxSelectPallet.Name = "comboBoxSelectPallet";
            this.comboBoxSelectPallet.Size = new System.Drawing.Size(163, 21);
            this.comboBoxSelectPallet.TabIndex = 64;
            this.comboBoxSelectPallet.ValueMember = "PalletBatchUniqueNo";
            // 
            // selectorPalletReportBindingSource
            // 
            this.selectorPalletReportBindingSource.DataMember = "Selector_PalletReport";
            this.selectorPalletReportBindingSource.DataSource = this.exwoldTrackingDataSet1;
            // 
            // exwoldTrackingDataSet1
            // 
            this.exwoldTrackingDataSet1.DataSetName = "ExwoldTrackingDataSet1";
            this.exwoldTrackingDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonPalletReport
            // 
            this.buttonPalletReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPalletReport.Location = new System.Drawing.Point(86, 274);
            this.buttonPalletReport.Name = "buttonPalletReport";
            this.buttonPalletReport.Size = new System.Drawing.Size(97, 23);
            this.buttonPalletReport.TabIndex = 65;
            this.buttonPalletReport.Text = "Run";
            this.buttonPalletReport.UseVisualStyleBackColor = true;
            this.buttonPalletReport.Click += new System.EventHandler(this.buttonPalletReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(56, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 34);
            this.label1.TabIndex = 66;
            this.label1.Text = "Select Sales Order below\r\nthen press run.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(702, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 34);
            this.label4.TabIndex = 76;
            this.label4.Text = "Select Material Batch below\r\nthen press run.";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(738, 274);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 23);
            this.button2.TabIndex = 75;
            this.button2.Text = "Run";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBoxBatch
            // 
            this.comboBoxBatch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxBatch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxBatch.DataSource = this.selectorMBReportBindingSource;
            this.comboBoxBatch.DisplayMember = "BatchNo";
            this.comboBoxBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBatch.FormattingEnabled = true;
            this.comboBoxBatch.Location = new System.Drawing.Point(738, 196);
            this.comboBoxBatch.Name = "comboBoxBatch";
            this.comboBoxBatch.Size = new System.Drawing.Size(97, 21);
            this.comboBoxBatch.TabIndex = 74;
            this.comboBoxBatch.ValueMember = "BatchNo";
            // 
            // selectorMBReportBindingSource
            // 
            this.selectorMBReportBindingSource.DataMember = "Selector_MBReport";
            this.selectorMBReportBindingSource.DataSource = this.exwoldTrackingDataSet3;
            // 
            // exwoldTrackingDataSet3
            // 
            this.exwoldTrackingDataSet3.DataSetName = "ExwoldTrackingDataSet3";
            this.exwoldTrackingDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(689, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 20);
            this.label5.TabIndex = 73;
            this.label5.Text = "Batch Genealogy Report";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(653, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(267, 415);
            this.dataGridView3.TabIndex = 72;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(399, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 34);
            this.label2.TabIndex = 81;
            this.label2.Text = "Select SSCC below\r\nthen press run.";
            // 
            // buttonSSCCReport
            // 
            this.buttonSSCCReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSSCCReport.Location = new System.Drawing.Point(413, 274);
            this.buttonSSCCReport.Name = "buttonSSCCReport";
            this.buttonSSCCReport.Size = new System.Drawing.Size(97, 23);
            this.buttonSSCCReport.TabIndex = 80;
            this.buttonSSCCReport.Text = "Run";
            this.buttonSSCCReport.UseVisualStyleBackColor = true;
            this.buttonSSCCReport.Click += new System.EventHandler(this.buttonSSCCReport_Click);
            // 
            // comboBoxSSCC
            // 
            this.comboBoxSSCC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxSSCC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxSSCC.DataSource = this.selectorSSCCReportBindingSource;
            this.comboBoxSSCC.DisplayMember = "SSCC";
            this.comboBoxSSCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSSCC.FormattingEnabled = true;
            this.comboBoxSSCC.Location = new System.Drawing.Point(377, 196);
            this.comboBoxSSCC.Name = "comboBoxSSCC";
            this.comboBoxSSCC.Size = new System.Drawing.Size(183, 21);
            this.comboBoxSSCC.TabIndex = 79;
            this.comboBoxSSCC.ValueMember = "SSCC";
            // 
            // selectorSSCCReportBindingSource
            // 
            this.selectorSSCCReportBindingSource.DataMember = "Selector_SSCCReport";
            this.selectorSSCCReportBindingSource.DataSource = this.exwoldTrackingDataSetSSCC;
            // 
            // exwoldTrackingDataSetSSCC
            // 
            this.exwoldTrackingDataSetSSCC.DataSetName = "ExwoldTrackingDataSetSSCC";
            this.exwoldTrackingDataSetSSCC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(373, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 20);
            this.label3.TabIndex = 78;
            this.label3.Text = "SSCC Genealogy Report";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(328, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(267, 415);
            this.dataGridView2.TabIndex = 77;
            // 
            // selector_PalletReportTableAdapter
            // 
            this.selector_PalletReportTableAdapter.ClearBeforeFill = true;
            // 
            // selector_SSCCReportTableAdapter
            // 
            this.selector_SSCCReportTableAdapter.ClearBeforeFill = true;
            // 
            // selector_MBReportTableAdapter
            // 
            this.selector_MBReportTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.labelReport);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonSSCCReport);
            this.panel1.Controls.Add(this.comboBoxSSCC);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.comboBoxBatch);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dataGridView3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonPalletReport);
            this.panel1.Controls.Add(this.comboBoxSelectPallet);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(0, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1500, 800);
            this.panel1.TabIndex = 82;
            // 
            // labelReport
            // 
            this.labelReport.AutoSize = true;
            this.labelReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReport.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelReport.Location = new System.Drawing.Point(284, 428);
            this.labelReport.Name = "labelReport";
            this.labelReport.Size = new System.Drawing.Size(353, 20);
            this.labelReport.TabIndex = 82;
            this.labelReport.Text = "Report Being Generated - Please wait........";
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 961);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.buttonClose);
            this.Name = "ReportsForm";
            this.Text = "EXWOLD PALLET TRACKING";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectorPalletReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exwoldTrackingDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectorMBReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exwoldTrackingDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectorSSCCReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exwoldTrackingDataSetSSCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox comboBoxSelectPallet;
        private System.Windows.Forms.Button buttonPalletReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBoxBatch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSSCCReport;
        private System.Windows.Forms.ComboBox comboBoxSSCC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private ExwoldTrackingDataSet1 exwoldTrackingDataSet1;
        private System.Windows.Forms.BindingSource selectorPalletReportBindingSource;
        private ExwoldTrackingDataSet1TableAdapters.Selector_PalletReportTableAdapter selector_PalletReportTableAdapter;
        private ExwoldTrackingDataSetSSCC exwoldTrackingDataSetSSCC;
        private System.Windows.Forms.BindingSource selectorSSCCReportBindingSource;
        private ExwoldTrackingDataSetSSCCTableAdapters.Selector_SSCCReportTableAdapter selector_SSCCReportTableAdapter;
        private ExwoldTrackingDataSet3 exwoldTrackingDataSet3;
        private System.Windows.Forms.BindingSource selectorMBReportBindingSource;
        private ExwoldTrackingDataSet3TableAdapters.Selector_MBReportTableAdapter selector_MBReportTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelReport;
    }
}

