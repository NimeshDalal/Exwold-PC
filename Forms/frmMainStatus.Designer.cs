namespace ITS.Exwold.Desktop
{
    partial class MainStatusForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_setBatch = new System.Windows.Forms.Button();
            this.button_exitPalletTracking = new System.Windows.Forms.Button();
            this.btnSetProduct = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.timerScannerMessages = new System.Windows.Forms.Timer(this.components);
            this.buttonReports = new System.Windows.Forms.Button();
            this.AuditReportButton = new System.Windows.Forms.Button();
            this.pnlPosn3 = new System.Windows.Forms.Panel();
            this.pnlPosn2 = new System.Windows.Forms.Panel();
            this.pnlPosn1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbLabelTest = new System.Windows.Forms.TextBox();
            this.btnScannerTest_Stop = new System.Windows.Forms.Button();
            this.btnScannerTest_Start = new System.Windows.Forms.Button();
            this.btnScannerTest_Init = new System.Windows.Forms.Button();
            this.btnLabelTest = new System.Windows.Forms.Button();
            this.btnChangePage = new System.Windows.Forms.Button();
            this.btnHardwareSettings = new System.Windows.Forms.Button();
            this.buttonReprintPalletLabels = new System.Windows.Forms.Button();
            this.picExwoldLogo = new System.Windows.Forms.PictureBox();
            this.picITSLogo = new System.Windows.Forms.PictureBox();
            this.dgvOnHold = new System.Windows.Forms.DataGridView();
            this.dgvReadyToPrint = new System.Windows.Forms.DataGridView();
            this.label30 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblPlantName = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExwoldLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picITSLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnHold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReadyToPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // button_setBatch
            // 
            this.button_setBatch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_setBatch.AutoSize = true;
            this.button_setBatch.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_setBatch.Location = new System.Drawing.Point(493, 561);
            this.button_setBatch.Name = "button_setBatch";
            this.button_setBatch.Size = new System.Drawing.Size(182, 32);
            this.button_setBatch.TabIndex = 16;
            this.button_setBatch.Text = "Set Sales Order details";
            this.button_setBatch.UseVisualStyleBackColor = true;
            this.button_setBatch.Click += new System.EventHandler(this.btnSetBatch_Click);
            // 
            // button_exitPalletTracking
            // 
            this.button_exitPalletTracking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_exitPalletTracking.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exitPalletTracking.Location = new System.Drawing.Point(1385, 3);
            this.button_exitPalletTracking.Name = "button_exitPalletTracking";
            this.button_exitPalletTracking.Size = new System.Drawing.Size(130, 45);
            this.button_exitPalletTracking.TabIndex = 57;
            this.button_exitPalletTracking.Text = "Exit Pallet Tracking";
            this.button_exitPalletTracking.UseVisualStyleBackColor = true;
            this.button_exitPalletTracking.Click += new System.EventHandler(this.btnExitPalletTracking_Click);
            // 
            // btnSetProduct
            // 
            this.btnSetProduct.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSetProduct.AutoSize = true;
            this.btnSetProduct.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetProduct.Location = new System.Drawing.Point(493, 599);
            this.btnSetProduct.Name = "btnSetProduct";
            this.btnSetProduct.Size = new System.Drawing.Size(182, 32);
            this.btnSetProduct.TabIndex = 58;
            this.btnSetProduct.Text = "Set Product details";
            this.btnSetProduct.UseVisualStyleBackColor = true;
            this.btnSetProduct.Click += new System.EventHandler(this.btnSetProduct_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(13, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(296, 32);
            this.label13.TabIndex = 87;
            this.label13.Text = "Customer / Product details";
            // 
            // timerScannerMessages
            // 
            this.timerScannerMessages.Interval = 500;
            this.timerScannerMessages.Tick += new System.EventHandler(this.timerScannerMessages_Tick);
            // 
            // buttonReports
            // 
            this.buttonReports.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonReports.AutoSize = true;
            this.buttonReports.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReports.Location = new System.Drawing.Point(681, 561);
            this.buttonReports.Name = "buttonReports";
            this.buttonReports.Size = new System.Drawing.Size(182, 32);
            this.buttonReports.TabIndex = 88;
            this.buttonReports.Text = "Reports";
            this.buttonReports.UseVisualStyleBackColor = true;
            this.buttonReports.Click += new System.EventHandler(this.btnRptSelector_Click);
            // 
            // AuditReportButton
            // 
            this.AuditReportButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AuditReportButton.AutoSize = true;
            this.AuditReportButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuditReportButton.Location = new System.Drawing.Point(869, 599);
            this.AuditReportButton.Name = "AuditReportButton";
            this.AuditReportButton.Size = new System.Drawing.Size(182, 32);
            this.AuditReportButton.TabIndex = 90;
            this.AuditReportButton.Text = "Audit Report";
            this.AuditReportButton.UseVisualStyleBackColor = true;
            this.AuditReportButton.Click += new System.EventHandler(this.AuditReportButton_Click);
            // 
            // pnlPosn3
            // 
            this.pnlPosn3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlPosn3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlPosn3.Location = new System.Drawing.Point(933, 71);
            this.pnlPosn3.Name = "pnlPosn3";
            this.pnlPosn3.Size = new System.Drawing.Size(454, 474);
            this.pnlPosn3.TabIndex = 91;
            // 
            // pnlPosn2
            // 
            this.pnlPosn2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlPosn2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlPosn2.Location = new System.Drawing.Point(476, 71);
            this.pnlPosn2.Name = "pnlPosn2";
            this.pnlPosn2.Size = new System.Drawing.Size(454, 474);
            this.pnlPosn2.TabIndex = 92;
            // 
            // pnlPosn1
            // 
            this.pnlPosn1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlPosn1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlPosn1.Location = new System.Drawing.Point(19, 71);
            this.pnlPosn1.Name = "pnlPosn1";
            this.pnlPosn1.Size = new System.Drawing.Size(454, 474);
            this.pnlPosn1.TabIndex = 93;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.tbLabelTest);
            this.panel4.Controls.Add(this.btnScannerTest_Stop);
            this.panel4.Controls.Add(this.btnScannerTest_Start);
            this.panel4.Controls.Add(this.btnScannerTest_Init);
            this.panel4.Controls.Add(this.btnLabelTest);
            this.panel4.Controls.Add(this.btnChangePage);
            this.panel4.Controls.Add(this.btnHardwareSettings);
            this.panel4.Controls.Add(this.buttonReprintPalletLabels);
            this.panel4.Controls.Add(this.picExwoldLogo);
            this.panel4.Controls.Add(this.picITSLogo);
            this.panel4.Controls.Add(this.dgvOnHold);
            this.panel4.Controls.Add(this.dgvReadyToPrint);
            this.panel4.Controls.Add(this.label30);
            this.panel4.Controls.Add(this.label22);
            this.panel4.Controls.Add(this.pnlPosn1);
            this.panel4.Controls.Add(this.pnlPosn2);
            this.panel4.Controls.Add(this.pnlPosn3);
            this.panel4.Controls.Add(this.AuditReportButton);
            this.panel4.Controls.Add(this.buttonReports);
            this.panel4.Controls.Add(this.btnSetProduct);
            this.panel4.Controls.Add(this.button_setBatch);
            this.panel4.Controls.Add(this.lblPlantName);
            this.panel4.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.panel4.Location = new System.Drawing.Point(0, 49);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1518, 634);
            this.panel4.TabIndex = 94;
            // 
            // tbLabelTest
            // 
            this.tbLabelTest.Location = new System.Drawing.Point(414, 15);
            this.tbLabelTest.Name = "tbLabelTest";
            this.tbLabelTest.Size = new System.Drawing.Size(100, 29);
            this.tbLabelTest.TabIndex = 99;
            this.tbLabelTest.Text = "858";
            // 
            // btnScannerTest_Stop
            // 
            this.btnScannerTest_Stop.Location = new System.Drawing.Point(132, 35);
            this.btnScannerTest_Stop.Name = "btnScannerTest_Stop";
            this.btnScannerTest_Stop.Size = new System.Drawing.Size(122, 29);
            this.btnScannerTest_Stop.TabIndex = 98;
            this.btnScannerTest_Stop.Text = "Scanner Stop";
            this.btnScannerTest_Stop.UseVisualStyleBackColor = true;
            this.btnScannerTest_Stop.Click += new System.EventHandler(this.btnScannerTest_Stop_Click);
            // 
            // btnScannerTest_Start
            // 
            this.btnScannerTest_Start.Location = new System.Drawing.Point(132, 3);
            this.btnScannerTest_Start.Name = "btnScannerTest_Start";
            this.btnScannerTest_Start.Size = new System.Drawing.Size(122, 29);
            this.btnScannerTest_Start.TabIndex = 98;
            this.btnScannerTest_Start.Text = "Scanner Start";
            this.btnScannerTest_Start.UseVisualStyleBackColor = true;
            this.btnScannerTest_Start.Click += new System.EventHandler(this.btnScannerTest_Start_Click);
            // 
            // btnScannerTest_Init
            // 
            this.btnScannerTest_Init.Location = new System.Drawing.Point(19, 3);
            this.btnScannerTest_Init.Name = "btnScannerTest_Init";
            this.btnScannerTest_Init.Size = new System.Drawing.Size(107, 29);
            this.btnScannerTest_Init.TabIndex = 98;
            this.btnScannerTest_Init.Text = "Scanner Init";
            this.btnScannerTest_Init.UseVisualStyleBackColor = true;
            this.btnScannerTest_Init.Click += new System.EventHandler(this.btnScannerTest_Init_Click);
            // 
            // btnLabelTest
            // 
            this.btnLabelTest.Location = new System.Drawing.Point(301, 15);
            this.btnLabelTest.Name = "btnLabelTest";
            this.btnLabelTest.Size = new System.Drawing.Size(107, 29);
            this.btnLabelTest.TabIndex = 98;
            this.btnLabelTest.Text = "Label Test";
            this.btnLabelTest.UseVisualStyleBackColor = true;
            this.btnLabelTest.Click += new System.EventHandler(this.btnLabelTest_Click);
            // 
            // btnChangePage
            // 
            this.btnChangePage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnChangePage.AutoSize = true;
            this.btnChangePage.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePage.Location = new System.Drawing.Point(1205, 33);
            this.btnChangePage.Name = "btnChangePage";
            this.btnChangePage.Size = new System.Drawing.Size(182, 32);
            this.btnChangePage.TabIndex = 95;
            this.btnChangePage.Text = "Next Page >>";
            this.btnChangePage.UseVisualStyleBackColor = true;
            this.btnChangePage.Click += new System.EventHandler(this.btnChangePage_Click);
            // 
            // btnHardwareSettings
            // 
            this.btnHardwareSettings.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnHardwareSettings.AutoSize = true;
            this.btnHardwareSettings.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHardwareSettings.Location = new System.Drawing.Point(869, 561);
            this.btnHardwareSettings.Name = "btnHardwareSettings";
            this.btnHardwareSettings.Size = new System.Drawing.Size(182, 32);
            this.btnHardwareSettings.TabIndex = 95;
            this.btnHardwareSettings.Text = "Hardware Settings";
            this.btnHardwareSettings.UseVisualStyleBackColor = true;
            this.btnHardwareSettings.Click += new System.EventHandler(this.btnHardwareSettings_Click);
            // 
            // buttonReprintPalletLabels
            // 
            this.buttonReprintPalletLabels.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonReprintPalletLabels.AutoSize = true;
            this.buttonReprintPalletLabels.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReprintPalletLabels.Location = new System.Drawing.Point(681, 599);
            this.buttonReprintPalletLabels.Name = "buttonReprintPalletLabels";
            this.buttonReprintPalletLabels.Size = new System.Drawing.Size(182, 32);
            this.buttonReprintPalletLabels.TabIndex = 97;
            this.buttonReprintPalletLabels.Text = "Reprint Pallet Label";
            this.buttonReprintPalletLabels.UseVisualStyleBackColor = true;
            this.buttonReprintPalletLabels.Click += new System.EventHandler(this.buttonReprintPalletLabels_Click);
            // 
            // picExwoldLogo
            // 
            this.picExwoldLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picExwoldLogo.Image = global::ITS.Exwold.Desktop.Properties.Resources.Exwold_High_Res_Logo_No_Strapline___small;
            this.picExwoldLogo.Location = new System.Drawing.Point(0, 561);
            this.picExwoldLogo.Name = "picExwoldLogo";
            this.picExwoldLogo.Size = new System.Drawing.Size(319, 73);
            this.picExwoldLogo.TabIndex = 95;
            this.picExwoldLogo.TabStop = false;
            // 
            // picITSLogo
            // 
            this.picITSLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picITSLogo.Image = global::ITS.Exwold.Desktop.Properties.Resources.ITS_logo_small1;
            this.picITSLogo.Location = new System.Drawing.Point(1279, 548);
            this.picITSLogo.Name = "picITSLogo";
            this.picITSLogo.Size = new System.Drawing.Size(239, 86);
            this.picITSLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picITSLogo.TabIndex = 96;
            this.picITSLogo.TabStop = false;
            // 
            // dgvOnHold
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            this.dgvOnHold.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOnHold.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvOnHold.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOnHold.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOnHold.CausesValidation = false;
            this.dgvOnHold.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvOnHold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOnHold.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOnHold.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOnHold.Enabled = false;
            this.dgvOnHold.EnableHeadersVisualStyles = false;
            this.dgvOnHold.Location = new System.Drawing.Point(1390, 325);
            this.dgvOnHold.Name = "dgvOnHold";
            this.dgvOnHold.ReadOnly = true;
            this.dgvOnHold.RowHeadersVisible = false;
            this.dgvOnHold.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvOnHold.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOnHold.Size = new System.Drawing.Size(119, 220);
            this.dgvOnHold.TabIndex = 96;
            // 
            // dgvReadyToPrint
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            this.dgvReadyToPrint.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReadyToPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvReadyToPrint.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReadyToPrint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReadyToPrint.CausesValidation = false;
            this.dgvReadyToPrint.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvReadyToPrint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReadyToPrint.ColumnHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReadyToPrint.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReadyToPrint.Enabled = false;
            this.dgvReadyToPrint.EnableHeadersVisualStyles = false;
            this.dgvReadyToPrint.Location = new System.Drawing.Point(1390, 71);
            this.dgvReadyToPrint.Name = "dgvReadyToPrint";
            this.dgvReadyToPrint.ReadOnly = true;
            this.dgvReadyToPrint.RowHeadersVisible = false;
            this.dgvReadyToPrint.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvReadyToPrint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReadyToPrint.Size = new System.Drawing.Size(119, 216);
            this.dgvReadyToPrint.TabIndex = 86;
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label30.Location = new System.Drawing.Point(1394, 290);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(110, 32);
            this.label30.TabIndex = 95;
            this.label30.Text = "On Hold";
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label22.Location = new System.Drawing.Point(1393, 4);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(110, 64);
            this.label22.TabIndex = 94;
            this.label22.Text = "Ready to\r\nPrint";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPlantName
            // 
            this.lblPlantName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPlantName.AutoSize = true;
            this.lblPlantName.Font = new System.Drawing.Font("Palatino Linotype", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlantName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPlantName.Location = new System.Drawing.Point(606, 30);
            this.lblPlantName.Name = "lblPlantName";
            this.lblPlantName.Size = new System.Drawing.Size(142, 32);
            this.lblPlantName.TabIndex = 15;
            this.lblPlantName.Text = "Plant Name";
            this.lblPlantName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainStatusForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1518, 683);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button_exitPalletTracking);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainStatusForm";
            this.Text = "EXWOLD PALLET TRACKING";
            this.Load += new System.EventHandler(this.MainStatusForm_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExwoldLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picITSLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnHold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReadyToPrint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_setBatch;
        private System.Windows.Forms.Button button_exitPalletTracking;
        private System.Windows.Forms.Button btnSetProduct;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer timerScannerMessages;
        private System.Windows.Forms.Button buttonReports;
        private System.Windows.Forms.Button AuditReportButton;
        private System.Windows.Forms.Panel pnlPosn3;
        private System.Windows.Forms.Panel pnlPosn2;
        private System.Windows.Forms.Panel pnlPosn1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DataGridView dgvOnHold;
        private System.Windows.Forms.DataGridView dgvReadyToPrint;
        private System.Windows.Forms.PictureBox picExwoldLogo;
        private System.Windows.Forms.PictureBox picITSLogo;
        private System.Windows.Forms.Button buttonReprintPalletLabels;
        private System.Windows.Forms.Button btnHardwareSettings;
        private System.Windows.Forms.Button btnChangePage;
        private System.Windows.Forms.Label lblPlantName;
        private System.Windows.Forms.Button btnLabelTest;
        private System.Windows.Forms.TextBox tbLabelTest;
        private System.Windows.Forms.Button btnScannerTest_Init;
        private System.Windows.Forms.Button btnScannerTest_Stop;
        private System.Windows.Forms.Button btnScannerTest_Start;
    }
}

