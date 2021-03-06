﻿namespace ITS.Exwold.Desktop
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_setBatch = new System.Windows.Forms.Button();
            this.button_exitPalletTracking = new System.Windows.Forms.Button();
            this.btnSetProduct = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.buttonReports = new System.Windows.Forms.Button();
            this.AuditReportButton = new System.Windows.Forms.Button();
            this.pnlPosn3 = new System.Windows.Forms.Panel();
            this.pnlPosn2 = new System.Windows.Forms.Panel();
            this.pnlPosn1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.grpAuxBtns = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpHardware = new System.Windows.Forms.GroupBox();
            this.btnScanners = new System.Windows.Forms.Button();
            this.btnAppSettings = new System.Windows.Forms.Button();
            this.btnHardwareSettings = new System.Windows.Forms.Button();
            this.grpReporting = new System.Windows.Forms.GroupBox();
            this.grpOperation = new System.Windows.Forms.GroupBox();
            this.buttonReprintPalletLabels = new System.Windows.Forms.Button();
            this.btnChangePage = new System.Windows.Forms.Button();
            this.picExwoldLogo = new System.Windows.Forms.PictureBox();
            this.picITSLogo = new System.Windows.Forms.PictureBox();
            this.dgvOnHold = new System.Windows.Forms.DataGridView();
            this.dgvReadyToPrint = new System.Windows.Forms.DataGridView();
            this.label30 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblPlantName = new System.Windows.Forms.Label();
            this.grpTesting = new System.Windows.Forms.GroupBox();
            this.btnTCPListener = new System.Windows.Forms.Button();
            this.tbLabelTest = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.grpAuxBtns.SuspendLayout();
            this.grpHardware.SuspendLayout();
            this.grpReporting.SuspendLayout();
            this.grpOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExwoldLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picITSLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnHold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReadyToPrint)).BeginInit();
            this.grpTesting.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_setBatch
            // 
            this.button_setBatch.AutoSize = true;
            this.button_setBatch.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_setBatch.Location = new System.Drawing.Point(5, 48);
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
            this.button_exitPalletTracking.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exitPalletTracking.Location = new System.Drawing.Point(1462, 3);
            this.button_exitPalletTracking.Name = "button_exitPalletTracking";
            this.button_exitPalletTracking.Size = new System.Drawing.Size(157, 39);
            this.button_exitPalletTracking.TabIndex = 57;
            this.button_exitPalletTracking.Text = "Exit Pallet Tracking";
            this.button_exitPalletTracking.UseVisualStyleBackColor = true;
            this.button_exitPalletTracking.Click += new System.EventHandler(this.btnExitPalletTracking_Click);
            // 
            // btnSetProduct
            // 
            this.btnSetProduct.AutoSize = true;
            this.btnSetProduct.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetProduct.Location = new System.Drawing.Point(5, 16);
            this.btnSetProduct.Name = "btnSetProduct";
            this.btnSetProduct.Size = new System.Drawing.Size(182, 32);
            this.btnSetProduct.TabIndex = 58;
            this.btnSetProduct.Text = "Set Product details";
            this.btnSetProduct.UseVisualStyleBackColor = true;
            this.btnSetProduct.Click += new System.EventHandler(this.btnSetProduct_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(298, 34);
            this.lblTitle.TabIndex = 87;
            this.lblTitle.Text = "Customer / Product details";
            // 
            // buttonReports
            // 
            this.buttonReports.AutoSize = true;
            this.buttonReports.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReports.Location = new System.Drawing.Point(5, 16);
            this.buttonReports.Name = "buttonReports";
            this.buttonReports.Size = new System.Drawing.Size(182, 32);
            this.buttonReports.TabIndex = 88;
            this.buttonReports.Text = "Reports";
            this.buttonReports.UseVisualStyleBackColor = true;
            this.buttonReports.Click += new System.EventHandler(this.btnRptSelector_Click);
            // 
            // AuditReportButton
            // 
            this.AuditReportButton.AutoSize = true;
            this.AuditReportButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuditReportButton.Location = new System.Drawing.Point(5, 48);
            this.AuditReportButton.Name = "AuditReportButton";
            this.AuditReportButton.Size = new System.Drawing.Size(182, 32);
            this.AuditReportButton.TabIndex = 90;
            this.AuditReportButton.Text = "Audit Report";
            this.AuditReportButton.UseVisualStyleBackColor = true;
            this.AuditReportButton.Click += new System.EventHandler(this.AuditReportButton_Click);
            // 
            // pnlPosn3
            // 
            this.pnlPosn3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlPosn3.Location = new System.Drawing.Point(921, 43);
            this.pnlPosn3.Name = "pnlPosn3";
            this.pnlPosn3.Size = new System.Drawing.Size(454, 762);
            this.pnlPosn3.TabIndex = 91;
            // 
            // pnlPosn2
            // 
            this.pnlPosn2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlPosn2.Location = new System.Drawing.Point(464, 43);
            this.pnlPosn2.Name = "pnlPosn2";
            this.pnlPosn2.Size = new System.Drawing.Size(454, 762);
            this.pnlPosn2.TabIndex = 92;
            // 
            // pnlPosn1
            // 
            this.pnlPosn1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlPosn1.Location = new System.Drawing.Point(7, 43);
            this.pnlPosn1.Name = "pnlPosn1";
            this.pnlPosn1.Size = new System.Drawing.Size(454, 762);
            this.pnlPosn1.TabIndex = 93;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.grpAuxBtns);
            this.panel4.Controls.Add(this.grpHardware);
            this.panel4.Controls.Add(this.grpReporting);
            this.panel4.Controls.Add(this.grpOperation);
            this.panel4.Controls.Add(this.btnChangePage);
            this.panel4.Controls.Add(this.picExwoldLogo);
            this.panel4.Controls.Add(this.picITSLogo);
            this.panel4.Controls.Add(this.dgvOnHold);
            this.panel4.Controls.Add(this.dgvReadyToPrint);
            this.panel4.Controls.Add(this.label30);
            this.panel4.Controls.Add(this.label22);
            this.panel4.Controls.Add(this.pnlPosn1);
            this.panel4.Controls.Add(this.pnlPosn2);
            this.panel4.Controls.Add(this.pnlPosn3);
            this.panel4.Controls.Add(this.lblPlantName);
            this.panel4.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.panel4.Location = new System.Drawing.Point(0, 49);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1619, 912);
            this.panel4.TabIndex = 94;
            this.panel4.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // grpAuxBtns
            // 
            this.grpAuxBtns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpAuxBtns.Controls.Add(this.btnRefresh);
            this.grpAuxBtns.Location = new System.Drawing.Point(1377, 821);
            this.grpAuxBtns.Name = "grpAuxBtns";
            this.grpAuxBtns.Size = new System.Drawing.Size(191, 55);
            this.grpAuxBtns.TabIndex = 102;
            this.grpAuxBtns.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(5, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(182, 32);
            this.btnRefresh.TabIndex = 98;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpHardware
            // 
            this.grpHardware.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpHardware.Controls.Add(this.btnScanners);
            this.grpHardware.Controls.Add(this.btnAppSettings);
            this.grpHardware.Controls.Add(this.btnHardwareSettings);
            this.grpHardware.Location = new System.Drawing.Point(924, 821);
            this.grpHardware.Name = "grpHardware";
            this.grpHardware.Size = new System.Drawing.Size(373, 85);
            this.grpHardware.TabIndex = 101;
            this.grpHardware.TabStop = false;
            // 
            // btnScanners
            // 
            this.btnScanners.Location = new System.Drawing.Point(5, 16);
            this.btnScanners.Name = "btnScanners";
            this.btnScanners.Size = new System.Drawing.Size(182, 32);
            this.btnScanners.TabIndex = 98;
            this.btnScanners.Text = "Scanners";
            this.btnScanners.UseVisualStyleBackColor = true;
            this.btnScanners.Click += new System.EventHandler(this.btnScanner_Click);
            // 
            // btnAppSettings
            // 
            this.btnAppSettings.AutoSize = true;
            this.btnAppSettings.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppSettings.Location = new System.Drawing.Point(187, 16);
            this.btnAppSettings.Name = "btnAppSettings";
            this.btnAppSettings.Size = new System.Drawing.Size(182, 32);
            this.btnAppSettings.TabIndex = 95;
            this.btnAppSettings.Text = "App Settings";
            this.btnAppSettings.UseVisualStyleBackColor = true;
            this.btnAppSettings.Click += new System.EventHandler(this.btnAppSettings_Click);
            // 
            // btnHardwareSettings
            // 
            this.btnHardwareSettings.AutoSize = true;
            this.btnHardwareSettings.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHardwareSettings.Location = new System.Drawing.Point(5, 48);
            this.btnHardwareSettings.Name = "btnHardwareSettings";
            this.btnHardwareSettings.Size = new System.Drawing.Size(182, 32);
            this.btnHardwareSettings.TabIndex = 95;
            this.btnHardwareSettings.Text = "Hardware Settings";
            this.btnHardwareSettings.UseVisualStyleBackColor = true;
            this.btnHardwareSettings.Click += new System.EventHandler(this.btnHardwareSettings_Click);
            // 
            // grpReporting
            // 
            this.grpReporting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpReporting.Controls.Add(this.buttonReports);
            this.grpReporting.Controls.Add(this.AuditReportButton);
            this.grpReporting.Location = new System.Drawing.Point(730, 821);
            this.grpReporting.Name = "grpReporting";
            this.grpReporting.Size = new System.Drawing.Size(191, 85);
            this.grpReporting.TabIndex = 100;
            this.grpReporting.TabStop = false;
            // 
            // grpOperation
            // 
            this.grpOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpOperation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grpOperation.Controls.Add(this.button_setBatch);
            this.grpOperation.Controls.Add(this.btnSetProduct);
            this.grpOperation.Controls.Add(this.buttonReprintPalletLabels);
            this.grpOperation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpOperation.Location = new System.Drawing.Point(354, 821);
            this.grpOperation.Name = "grpOperation";
            this.grpOperation.Size = new System.Drawing.Size(373, 85);
            this.grpOperation.TabIndex = 99;
            this.grpOperation.TabStop = false;
            // 
            // buttonReprintPalletLabels
            // 
            this.buttonReprintPalletLabels.AutoSize = true;
            this.buttonReprintPalletLabels.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReprintPalletLabels.Location = new System.Drawing.Point(187, 16);
            this.buttonReprintPalletLabels.Name = "buttonReprintPalletLabels";
            this.buttonReprintPalletLabels.Size = new System.Drawing.Size(182, 32);
            this.buttonReprintPalletLabels.TabIndex = 97;
            this.buttonReprintPalletLabels.Text = "Reprint Pallet Label";
            this.buttonReprintPalletLabels.UseVisualStyleBackColor = true;
            this.buttonReprintPalletLabels.Click += new System.EventHandler(this.buttonReprintPalletLabels_Click);
            // 
            // btnChangePage
            // 
            this.btnChangePage.AutoSize = true;
            this.btnChangePage.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePage.Location = new System.Drawing.Point(1192, 6);
            this.btnChangePage.Name = "btnChangePage";
            this.btnChangePage.Size = new System.Drawing.Size(182, 32);
            this.btnChangePage.TabIndex = 95;
            this.btnChangePage.Text = "Next Page >>";
            this.btnChangePage.UseVisualStyleBackColor = true;
            this.btnChangePage.Click += new System.EventHandler(this.btnChangePage_Click);
            // 
            // picExwoldLogo
            // 
            this.picExwoldLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picExwoldLogo.Image = global::ITS.Exwold.Desktop.Properties.Resources.Exwold_High_Res_Logo_No_Strapline___small;
            this.picExwoldLogo.Location = new System.Drawing.Point(7, 833);
            this.picExwoldLogo.Name = "picExwoldLogo";
            this.picExwoldLogo.Size = new System.Drawing.Size(319, 73);
            this.picExwoldLogo.TabIndex = 95;
            this.picExwoldLogo.TabStop = false;
            // 
            // picITSLogo
            // 
            this.picITSLogo.Image = global::ITS.Exwold.Desktop.Properties.Resources.ITS_logo_small1;
            this.picITSLogo.Location = new System.Drawing.Point(1377, 719);
            this.picITSLogo.Name = "picITSLogo";
            this.picITSLogo.Size = new System.Drawing.Size(239, 86);
            this.picITSLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picITSLogo.TabIndex = 96;
            this.picITSLogo.TabStop = false;
            // 
            // dgvOnHold
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            this.dgvOnHold.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOnHold.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOnHold.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOnHold.CausesValidation = false;
            this.dgvOnHold.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvOnHold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOnHold.ColumnHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOnHold.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvOnHold.Enabled = false;
            this.dgvOnHold.EnableHeadersVisualStyles = false;
            this.dgvOnHold.Location = new System.Drawing.Point(1378, 397);
            this.dgvOnHold.Name = "dgvOnHold";
            this.dgvOnHold.ReadOnly = true;
            this.dgvOnHold.RowHeadersVisible = false;
            this.dgvOnHold.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvOnHold.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOnHold.Size = new System.Drawing.Size(239, 302);
            this.dgvOnHold.TabIndex = 96;
            // 
            // dgvReadyToPrint
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            this.dgvReadyToPrint.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvReadyToPrint.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReadyToPrint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReadyToPrint.CausesValidation = false;
            this.dgvReadyToPrint.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvReadyToPrint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReadyToPrint.ColumnHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReadyToPrint.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvReadyToPrint.Enabled = false;
            this.dgvReadyToPrint.EnableHeadersVisualStyles = false;
            this.dgvReadyToPrint.Location = new System.Drawing.Point(1378, 43);
            this.dgvReadyToPrint.Name = "dgvReadyToPrint";
            this.dgvReadyToPrint.ReadOnly = true;
            this.dgvReadyToPrint.RowHeadersVisible = false;
            this.dgvReadyToPrint.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvReadyToPrint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReadyToPrint.Size = new System.Drawing.Size(239, 302);
            this.dgvReadyToPrint.TabIndex = 86;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label30.Location = new System.Drawing.Point(1377, 362);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(239, 32);
            this.label30.TabIndex = 95;
            this.label30.Text = "On Hold";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label22.Location = new System.Drawing.Point(1377, 2);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(239, 40);
            this.label22.TabIndex = 94;
            this.label22.Text = "Ready to Print";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlantName
            // 
            this.lblPlantName.Font = new System.Drawing.Font("Palatino Linotype", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlantName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPlantName.Location = new System.Drawing.Point(463, 2);
            this.lblPlantName.Name = "lblPlantName";
            this.lblPlantName.Size = new System.Drawing.Size(454, 40);
            this.lblPlantName.TabIndex = 15;
            this.lblPlantName.Text = "Plant Name";
            this.lblPlantName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpTesting
            // 
            this.grpTesting.Controls.Add(this.btnTCPListener);
            this.grpTesting.Controls.Add(this.tbLabelTest);
            this.grpTesting.Controls.Add(this.btnTest);
            this.grpTesting.Location = new System.Drawing.Point(344, 3);
            this.grpTesting.Name = "grpTesting";
            this.grpTesting.Size = new System.Drawing.Size(247, 85);
            this.grpTesting.TabIndex = 100;
            this.grpTesting.TabStop = false;
            this.grpTesting.Text = "Test Group";
            // 
            // btnTCPListener
            // 
            this.btnTCPListener.Location = new System.Drawing.Point(9, 48);
            this.btnTCPListener.Name = "btnTCPListener";
            this.btnTCPListener.Size = new System.Drawing.Size(156, 29);
            this.btnTCPListener.TabIndex = 102;
            this.btnTCPListener.Text = "TCPListener";
            this.btnTCPListener.UseVisualStyleBackColor = true;
            this.btnTCPListener.Click += new System.EventHandler(this.btnTCPListener_Click);
            // 
            // tbLabelTest
            // 
            this.tbLabelTest.Location = new System.Drawing.Point(122, 16);
            this.tbLabelTest.Name = "tbLabelTest";
            this.tbLabelTest.Size = new System.Drawing.Size(107, 29);
            this.tbLabelTest.TabIndex = 101;
            this.tbLabelTest.Text = "40823";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(9, 16);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(107, 29);
            this.btnTest.TabIndex = 100;
            this.btnTest.Text = "Label Print";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // MainStatusForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1619, 961);
            this.ControlBox = false;
            this.Controls.Add(this.grpTesting);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.button_exitPalletTracking);
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainStatusForm";
            this.Text = "EXWOLD PALLET TRACKING";
            this.Load += new System.EventHandler(this.MainStatusForm_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.grpAuxBtns.ResumeLayout(false);
            this.grpHardware.ResumeLayout(false);
            this.grpHardware.PerformLayout();
            this.grpReporting.ResumeLayout(false);
            this.grpReporting.PerformLayout();
            this.grpOperation.ResumeLayout(false);
            this.grpOperation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExwoldLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picITSLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnHold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReadyToPrint)).EndInit();
            this.grpTesting.ResumeLayout(false);
            this.grpTesting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_setBatch;
        private System.Windows.Forms.Button button_exitPalletTracking;
        private System.Windows.Forms.Button btnSetProduct;
        private System.Windows.Forms.Label lblTitle;
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
        private System.Windows.Forms.Button btnScanners;
        private System.Windows.Forms.GroupBox grpTesting;
        private System.Windows.Forms.Button btnTCPListener;
        private System.Windows.Forms.TextBox tbLabelTest;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox grpHardware;
        private System.Windows.Forms.GroupBox grpReporting;
        private System.Windows.Forms.GroupBox grpOperation;
        private System.Windows.Forms.GroupBox grpAuxBtns;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAppSettings;
    }
}

