namespace ITS.Exwold.Desktop
{
    partial class frmLineInfo
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
            this.dgvCurrentPallet = new System.Windows.Forms.DataGridView();
            this.tbNotes = new System.Windows.Forms.RichTextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.btnPalletDetails = new System.Windows.Forms.Button();
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblProductBatchesOnPallet = new System.Windows.Forms.Label();
            this.tbOutersRqd = new System.Windows.Forms.TextBox();
            this.lblOutersRqd = new System.Windows.Forms.Label();
            this.tbCustomer = new System.Windows.Forms.TextBox();
            this.tbProdName = new System.Windows.Forms.TextBox();
            this.tbOutersScanned = new System.Windows.Forms.TextBox();
            this.tbPalletBatchNo = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblSalesOrder = new System.Windows.Forms.Label();
            this.lblOutersScanned = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.grpDisplay = new System.Windows.Forms.GroupBox();
            this.lblScannerMessage = new System.Windows.Forms.Label();
            this.tbLotNo = new System.Windows.Forms.TextBox();
            this.lblLotNo = new System.Windows.Forms.Label();
            this.tbPalletBatchUId = new System.Windows.Forms.TextBox();
            this.tbInnersUnassigned = new System.Windows.Forms.TextBox();
            this.tbInnersOnPallets = new System.Windows.Forms.TextBox();
            this.tbInnersScanned = new System.Windows.Forms.TextBox();
            this.tbInnersRqd = new System.Windows.Forms.TextBox();
            this.lblInnersUnassigned = new System.Windows.Forms.Label();
            this.lblInnerInPallet = new System.Windows.Forms.Label();
            this.lblInnersScanned = new System.Windows.Forms.Label();
            this.lblInnersRqd = new System.Windows.Forms.Label();
            this.btnPackLabels = new System.Windows.Forms.Button();
            this.grpButtons = new System.Windows.Forms.GroupBox();
            this.grpScanner = new System.Windows.Forms.GroupBox();
            this.tbScannerRunning = new System.Windows.Forms.TextBox();
            this.tbScannerStatus = new System.Windows.Forms.TextBox();
            this.btnScannerStartStop = new System.Windows.Forms.Button();
            this.btnShowDetails = new System.Windows.Forms.Button();
            this.btnScannerStatus = new System.Windows.Forms.Button();
            this.grpInnerCounts = new System.Windows.Forms.GroupBox();
            this.grpOuterCounts = new System.Windows.Forms.GroupBox();
            this.lblCartonMessage = new System.Windows.Forms.Label();
            this.tbInnersInOuters = new System.Windows.Forms.TextBox();
            this.lblInnersInOuters = new System.Windows.Forms.Label();
            this.grpPalletInfo = new System.Windows.Forms.GroupBox();
            this.tbProductUId = new System.Windows.Forms.TextBox();
            this.tbCartonsPerPallet = new System.Windows.Forms.TextBox();
            this.tbCurrentPalletUId = new System.Windows.Forms.TextBox();
            this.tbInnersPerCarton = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpPackTotals = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentPallet)).BeginInit();
            this.grpDisplay.SuspendLayout();
            this.grpButtons.SuspendLayout();
            this.grpScanner.SuspendLayout();
            this.grpInnerCounts.SuspendLayout();
            this.grpOuterCounts.SuspendLayout();
            this.grpPalletInfo.SuspendLayout();
            this.grpPackTotals.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCurrentPallet
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            this.dgvCurrentPallet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCurrentPallet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCurrentPallet.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCurrentPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCurrentPallet.CausesValidation = false;
            this.dgvCurrentPallet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvCurrentPallet.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvCurrentPallet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCurrentPallet.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCurrentPallet.Enabled = false;
            this.dgvCurrentPallet.EnableHeadersVisualStyles = false;
            this.dgvCurrentPallet.Location = new System.Drawing.Point(219, 39);
            this.dgvCurrentPallet.Name = "dgvCurrentPallet";
            this.dgvCurrentPallet.ReadOnly = true;
            this.dgvCurrentPallet.RowHeadersVisible = false;
            this.dgvCurrentPallet.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCurrentPallet.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvCurrentPallet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrentPallet.Size = new System.Drawing.Size(223, 127);
            this.dgvCurrentPallet.TabIndex = 78;
            // 
            // tbNotes
            // 
            this.tbNotes.BackColor = System.Drawing.SystemColors.Control;
            this.tbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNotes.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotes.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbNotes.Location = new System.Drawing.Point(9, 40);
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.ReadOnly = true;
            this.tbNotes.Size = new System.Drawing.Size(191, 126);
            this.tbNotes.TabIndex = 77;
            this.tbNotes.Text = "";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.BackColor = System.Drawing.SystemColors.Control;
            this.lblNotes.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNotes.Location = new System.Drawing.Point(9, 15);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(49, 22);
            this.lblNotes.TabIndex = 76;
            this.lblNotes.Text = "Notes";
            // 
            // btnPalletDetails
            // 
            this.btnPalletDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPalletDetails.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPalletDetails.Location = new System.Drawing.Point(6, 16);
            this.btnPalletDetails.Name = "btnPalletDetails";
            this.btnPalletDetails.Size = new System.Drawing.Size(140, 30);
            this.btnPalletDetails.TabIndex = 60;
            this.btnPalletDetails.Text = "Pallet Details";
            this.btnPalletDetails.UseVisualStyleBackColor = true;
            this.btnPalletDetails.Click += new System.EventHandler(this.btnPalletDetails_Click);
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatusMessage.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusMessage.ForeColor = System.Drawing.Color.Green;
            this.lblStatusMessage.Location = new System.Drawing.Point(61, 169);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(381, 48);
            this.lblStatusMessage.TabIndex = 36;
            this.lblStatusMessage.Text = "In-Progress";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatus.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus.Location = new System.Drawing.Point(9, 169);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(77, 22);
            this.lblStatus.TabIndex = 35;
            this.lblStatus.Text = "Status    - ";
            // 
            // lblProductBatchesOnPallet
            // 
            this.lblProductBatchesOnPallet.AutoSize = true;
            this.lblProductBatchesOnPallet.BackColor = System.Drawing.SystemColors.Control;
            this.lblProductBatchesOnPallet.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductBatchesOnPallet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProductBatchesOnPallet.Location = new System.Drawing.Point(225, 14);
            this.lblProductBatchesOnPallet.Name = "lblProductBatchesOnPallet";
            this.lblProductBatchesOnPallet.Size = new System.Drawing.Size(197, 22);
            this.lblProductBatchesOnPallet.TabIndex = 31;
            this.lblProductBatchesOnPallet.Text = "Product batches on Pallet(s)";
            // 
            // tbOutersRqd
            // 
            this.tbOutersRqd.BackColor = System.Drawing.SystemColors.Control;
            this.tbOutersRqd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOutersRqd.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOutersRqd.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbOutersRqd.Location = new System.Drawing.Point(171, 16);
            this.tbOutersRqd.Name = "tbOutersRqd";
            this.tbOutersRqd.ReadOnly = true;
            this.tbOutersRqd.Size = new System.Drawing.Size(37, 29);
            this.tbOutersRqd.TabIndex = 30;
            this.tbOutersRqd.Text = " \r\n";
            this.tbOutersRqd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblOutersRqd
            // 
            this.lblOutersRqd.AutoSize = true;
            this.lblOutersRqd.BackColor = System.Drawing.Color.Transparent;
            this.lblOutersRqd.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutersRqd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOutersRqd.Location = new System.Drawing.Point(3, 19);
            this.lblOutersRqd.Name = "lblOutersRqd";
            this.lblOutersRqd.Size = new System.Drawing.Size(166, 22);
            this.lblOutersRqd.TabIndex = 29;
            this.lblOutersRqd.Text = "Total Cartons Required";
            // 
            // tbCustomer
            // 
            this.tbCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.tbCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCustomer.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomer.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbCustomer.Location = new System.Drawing.Point(108, 45);
            this.tbCustomer.Name = "tbCustomer";
            this.tbCustomer.ReadOnly = true;
            this.tbCustomer.Size = new System.Drawing.Size(137, 29);
            this.tbCustomer.TabIndex = 28;
            this.tbCustomer.Text = " \r\n";
            // 
            // tbProdName
            // 
            this.tbProdName.BackColor = System.Drawing.SystemColors.Control;
            this.tbProdName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbProdName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProdName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbProdName.Location = new System.Drawing.Point(108, 105);
            this.tbProdName.Multiline = true;
            this.tbProdName.Name = "tbProdName";
            this.tbProdName.ReadOnly = true;
            this.tbProdName.Size = new System.Drawing.Size(340, 45);
            this.tbProdName.TabIndex = 27;
            this.tbProdName.Text = " \r\n";
            // 
            // tbOutersScanned
            // 
            this.tbOutersScanned.BackColor = System.Drawing.SystemColors.Control;
            this.tbOutersScanned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOutersScanned.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOutersScanned.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbOutersScanned.Location = new System.Drawing.Point(171, 16);
            this.tbOutersScanned.Name = "tbOutersScanned";
            this.tbOutersScanned.ReadOnly = true;
            this.tbOutersScanned.Size = new System.Drawing.Size(37, 29);
            this.tbOutersScanned.TabIndex = 26;
            this.tbOutersScanned.Text = " \r\n";
            this.tbOutersScanned.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPalletBatchNo
            // 
            this.tbPalletBatchNo.BackColor = System.Drawing.SystemColors.Control;
            this.tbPalletBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPalletBatchNo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletBatchNo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbPalletBatchNo.Location = new System.Drawing.Point(108, 15);
            this.tbPalletBatchNo.Name = "tbPalletBatchNo";
            this.tbPalletBatchNo.ReadOnly = true;
            this.tbPalletBatchNo.Size = new System.Drawing.Size(137, 29);
            this.tbPalletBatchNo.TabIndex = 23;
            this.tbPalletBatchNo.Text = " \r\n";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.BackColor = System.Drawing.SystemColors.Control;
            this.lblProduct.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProduct.Location = new System.Drawing.Point(3, 107);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(64, 22);
            this.lblProduct.TabIndex = 22;
            this.lblProduct.Text = "Product";
            // 
            // lblSalesOrder
            // 
            this.lblSalesOrder.AutoSize = true;
            this.lblSalesOrder.BackColor = System.Drawing.SystemColors.Control;
            this.lblSalesOrder.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesOrder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSalesOrder.Location = new System.Drawing.Point(3, 17);
            this.lblSalesOrder.Name = "lblSalesOrder";
            this.lblSalesOrder.Size = new System.Drawing.Size(89, 22);
            this.lblSalesOrder.TabIndex = 21;
            this.lblSalesOrder.Text = "Sales Order";
            // 
            // lblOutersScanned
            // 
            this.lblOutersScanned.AutoSize = true;
            this.lblOutersScanned.BackColor = System.Drawing.Color.Transparent;
            this.lblOutersScanned.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutersScanned.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOutersScanned.Location = new System.Drawing.Point(3, 19);
            this.lblOutersScanned.Name = "lblOutersScanned";
            this.lblOutersScanned.Size = new System.Drawing.Size(125, 22);
            this.lblOutersScanned.TabIndex = 20;
            this.lblOutersScanned.Text = "Cartons Scanned";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.lblCustomer.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCustomer.Location = new System.Drawing.Point(3, 47);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(76, 22);
            this.lblCustomer.TabIndex = 19;
            this.lblCustomer.Text = "Customer";
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLine.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblLine.Location = new System.Drawing.Point(0, 0);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(454, 32);
            this.lblLine.TabIndex = 79;
            this.lblLine.Text = "Line 1";
            this.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpDisplay
            // 
            this.grpDisplay.Controls.Add(this.lblScannerMessage);
            this.grpDisplay.Controls.Add(this.tbProdName);
            this.grpDisplay.Controls.Add(this.tbLotNo);
            this.grpDisplay.Controls.Add(this.tbPalletBatchNo);
            this.grpDisplay.Controls.Add(this.lblLotNo);
            this.grpDisplay.Controls.Add(this.lblSalesOrder);
            this.grpDisplay.Controls.Add(this.tbCustomer);
            this.grpDisplay.Controls.Add(this.lblCustomer);
            this.grpDisplay.Controls.Add(this.lblProduct);
            this.grpDisplay.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDisplay.Location = new System.Drawing.Point(0, 32);
            this.grpDisplay.Name = "grpDisplay";
            this.grpDisplay.Size = new System.Drawing.Size(454, 158);
            this.grpDisplay.TabIndex = 80;
            this.grpDisplay.TabStop = false;
            // 
            // lblScannerMessage
            // 
            this.lblScannerMessage.BackColor = System.Drawing.Color.Yellow;
            this.lblScannerMessage.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScannerMessage.ForeColor = System.Drawing.Color.Red;
            this.lblScannerMessage.Location = new System.Drawing.Point(251, 15);
            this.lblScannerMessage.Name = "lblScannerMessage";
            this.lblScannerMessage.Size = new System.Drawing.Size(197, 85);
            this.lblScannerMessage.TabIndex = 84;
            this.lblScannerMessage.Text = "An Error message from the scanner";
            // 
            // tbLotNo
            // 
            this.tbLotNo.BackColor = System.Drawing.SystemColors.Control;
            this.tbLotNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLotNo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLotNo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbLotNo.Location = new System.Drawing.Point(108, 75);
            this.tbLotNo.Name = "tbLotNo";
            this.tbLotNo.ReadOnly = true;
            this.tbLotNo.Size = new System.Drawing.Size(137, 29);
            this.tbLotNo.TabIndex = 23;
            this.tbLotNo.Text = " \r\n";
            // 
            // lblLotNo
            // 
            this.lblLotNo.AutoSize = true;
            this.lblLotNo.BackColor = System.Drawing.SystemColors.Control;
            this.lblLotNo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLotNo.Location = new System.Drawing.Point(3, 78);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(95, 22);
            this.lblLotNo.TabIndex = 21;
            this.lblLotNo.Text = "Lot Number";
            // 
            // tbPalletBatchUId
            // 
            this.tbPalletBatchUId.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletBatchUId.Location = new System.Drawing.Point(27, 3);
            this.tbPalletBatchUId.Name = "tbPalletBatchUId";
            this.tbPalletBatchUId.Size = new System.Drawing.Size(65, 29);
            this.tbPalletBatchUId.TabIndex = 79;
            // 
            // tbInnersUnassigned
            // 
            this.tbInnersUnassigned.BackColor = System.Drawing.SystemColors.Control;
            this.tbInnersUnassigned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInnersUnassigned.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnersUnassigned.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbInnersUnassigned.Location = new System.Drawing.Point(191, 76);
            this.tbInnersUnassigned.Name = "tbInnersUnassigned";
            this.tbInnersUnassigned.ReadOnly = true;
            this.tbInnersUnassigned.Size = new System.Drawing.Size(37, 29);
            this.tbInnersUnassigned.TabIndex = 30;
            this.tbInnersUnassigned.Text = " \r\n";
            this.tbInnersUnassigned.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbInnersOnPallets
            // 
            this.tbInnersOnPallets.BackColor = System.Drawing.SystemColors.Control;
            this.tbInnersOnPallets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInnersOnPallets.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnersOnPallets.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbInnersOnPallets.Location = new System.Drawing.Point(191, 46);
            this.tbInnersOnPallets.Name = "tbInnersOnPallets";
            this.tbInnersOnPallets.ReadOnly = true;
            this.tbInnersOnPallets.Size = new System.Drawing.Size(37, 29);
            this.tbInnersOnPallets.TabIndex = 30;
            this.tbInnersOnPallets.Text = " \r\n";
            this.tbInnersOnPallets.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbInnersScanned
            // 
            this.tbInnersScanned.BackColor = System.Drawing.SystemColors.Control;
            this.tbInnersScanned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInnersScanned.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnersScanned.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbInnersScanned.Location = new System.Drawing.Point(191, 16);
            this.tbInnersScanned.Name = "tbInnersScanned";
            this.tbInnersScanned.ReadOnly = true;
            this.tbInnersScanned.Size = new System.Drawing.Size(37, 29);
            this.tbInnersScanned.TabIndex = 30;
            this.tbInnersScanned.Text = " \r\n";
            this.tbInnersScanned.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbInnersRqd
            // 
            this.tbInnersRqd.BackColor = System.Drawing.SystemColors.Control;
            this.tbInnersRqd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInnersRqd.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnersRqd.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbInnersRqd.Location = new System.Drawing.Point(411, 16);
            this.tbInnersRqd.Name = "tbInnersRqd";
            this.tbInnersRqd.ReadOnly = true;
            this.tbInnersRqd.Size = new System.Drawing.Size(37, 29);
            this.tbInnersRqd.TabIndex = 30;
            this.tbInnersRqd.Text = " \r\n";
            this.tbInnersRqd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblInnersUnassigned
            // 
            this.lblInnersUnassigned.AutoSize = true;
            this.lblInnersUnassigned.BackColor = System.Drawing.Color.Transparent;
            this.lblInnersUnassigned.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInnersUnassigned.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInnersUnassigned.Location = new System.Drawing.Point(5, 79);
            this.lblInnersUnassigned.Name = "lblInnersUnassigned";
            this.lblInnersUnassigned.Size = new System.Drawing.Size(136, 22);
            this.lblInnersUnassigned.TabIndex = 29;
            this.lblInnersUnassigned.Text = "Unassigned Inners";
            // 
            // lblInnerInPallet
            // 
            this.lblInnerInPallet.AutoSize = true;
            this.lblInnerInPallet.BackColor = System.Drawing.Color.Transparent;
            this.lblInnerInPallet.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInnerInPallet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInnerInPallet.Location = new System.Drawing.Point(5, 49);
            this.lblInnerInPallet.Name = "lblInnerInPallet";
            this.lblInnerInPallet.Size = new System.Drawing.Size(125, 22);
            this.lblInnerInPallet.TabIndex = 29;
            this.lblInnerInPallet.Text = "Inners On Pallets";
            // 
            // lblInnersScanned
            // 
            this.lblInnersScanned.AutoSize = true;
            this.lblInnersScanned.BackColor = System.Drawing.Color.Transparent;
            this.lblInnersScanned.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInnersScanned.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInnersScanned.Location = new System.Drawing.Point(5, 19);
            this.lblInnersScanned.Name = "lblInnersScanned";
            this.lblInnersScanned.Size = new System.Drawing.Size(127, 22);
            this.lblInnersScanned.TabIndex = 29;
            this.lblInnersScanned.Text = "Inners In Cartons";
            // 
            // lblInnersRqd
            // 
            this.lblInnersRqd.AutoSize = true;
            this.lblInnersRqd.BackColor = System.Drawing.Color.Transparent;
            this.lblInnersRqd.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInnersRqd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInnersRqd.Location = new System.Drawing.Point(225, 19);
            this.lblInnersRqd.Name = "lblInnersRqd";
            this.lblInnersRqd.Size = new System.Drawing.Size(155, 22);
            this.lblInnersRqd.TabIndex = 29;
            this.lblInnersRqd.Text = "Total Inners Required";
            // 
            // btnPackLabels
            // 
            this.btnPackLabels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPackLabels.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPackLabels.Location = new System.Drawing.Point(308, 14);
            this.btnPackLabels.Name = "btnPackLabels";
            this.btnPackLabels.Size = new System.Drawing.Size(140, 30);
            this.btnPackLabels.TabIndex = 60;
            this.btnPackLabels.Text = "Pack Labels";
            this.btnPackLabels.UseVisualStyleBackColor = true;
            this.btnPackLabels.Click += new System.EventHandler(this.btnPackLabels_Click);
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add(this.btnPalletDetails);
            this.grpButtons.Controls.Add(this.btnPackLabels);
            this.grpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpButtons.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpButtons.Location = new System.Drawing.Point(0, 709);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Size = new System.Drawing.Size(454, 52);
            this.grpButtons.TabIndex = 81;
            this.grpButtons.TabStop = false;
            // 
            // grpScanner
            // 
            this.grpScanner.Controls.Add(this.tbScannerRunning);
            this.grpScanner.Controls.Add(this.tbScannerStatus);
            this.grpScanner.Controls.Add(this.btnScannerStartStop);
            this.grpScanner.Controls.Add(this.btnShowDetails);
            this.grpScanner.Controls.Add(this.btnScannerStatus);
            this.grpScanner.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpScanner.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpScanner.Location = new System.Drawing.Point(0, 612);
            this.grpScanner.Name = "grpScanner";
            this.grpScanner.Size = new System.Drawing.Size(454, 97);
            this.grpScanner.TabIndex = 82;
            this.grpScanner.TabStop = false;
            this.grpScanner.Text = "Scanner";
            // 
            // tbScannerRunning
            // 
            this.tbScannerRunning.Location = new System.Drawing.Point(308, 59);
            this.tbScannerRunning.Name = "tbScannerRunning";
            this.tbScannerRunning.Size = new System.Drawing.Size(140, 29);
            this.tbScannerRunning.TabIndex = 2;
            // 
            // tbScannerStatus
            // 
            this.tbScannerStatus.Location = new System.Drawing.Point(308, 27);
            this.tbScannerStatus.Name = "tbScannerStatus";
            this.tbScannerStatus.Size = new System.Drawing.Size(140, 29);
            this.tbScannerStatus.TabIndex = 2;
            // 
            // btnScannerStartStop
            // 
            this.btnScannerStartStop.Location = new System.Drawing.Point(162, 58);
            this.btnScannerStartStop.Name = "btnScannerStartStop";
            this.btnScannerStartStop.Size = new System.Drawing.Size(140, 30);
            this.btnScannerStartStop.TabIndex = 0;
            this.btnScannerStartStop.Text = "Start";
            this.btnScannerStartStop.UseVisualStyleBackColor = true;
            this.btnScannerStartStop.Click += new System.EventHandler(this.btnScannerStartStop_Click);
            // 
            // btnShowDetails
            // 
            this.btnShowDetails.Location = new System.Drawing.Point(9, 26);
            this.btnShowDetails.Name = "btnShowDetails";
            this.btnShowDetails.Size = new System.Drawing.Size(140, 30);
            this.btnShowDetails.TabIndex = 0;
            this.btnShowDetails.Text = "Details";
            this.btnShowDetails.UseVisualStyleBackColor = true;
            this.btnShowDetails.Click += new System.EventHandler(this.btnShowDetails_Click);
            // 
            // btnScannerStatus
            // 
            this.btnScannerStatus.Location = new System.Drawing.Point(162, 26);
            this.btnScannerStatus.Name = "btnScannerStatus";
            this.btnScannerStatus.Size = new System.Drawing.Size(140, 30);
            this.btnScannerStatus.TabIndex = 0;
            this.btnScannerStatus.Text = "Status";
            this.btnScannerStatus.UseVisualStyleBackColor = true;
            this.btnScannerStatus.Click += new System.EventHandler(this.btnScannerStatus_Click);
            // 
            // grpInnerCounts
            // 
            this.grpInnerCounts.BackColor = System.Drawing.Color.Yellow;
            this.grpInnerCounts.Controls.Add(this.lblInnersScanned);
            this.grpInnerCounts.Controls.Add(this.lblInnerInPallet);
            this.grpInnerCounts.Controls.Add(this.lblInnersUnassigned);
            this.grpInnerCounts.Controls.Add(this.tbInnersScanned);
            this.grpInnerCounts.Controls.Add(this.tbInnersOnPallets);
            this.grpInnerCounts.Controls.Add(this.tbInnersUnassigned);
            this.grpInnerCounts.Location = new System.Drawing.Point(220, 276);
            this.grpInnerCounts.Name = "grpInnerCounts";
            this.grpInnerCounts.Size = new System.Drawing.Size(234, 110);
            this.grpInnerCounts.TabIndex = 80;
            this.grpInnerCounts.TabStop = false;
            // 
            // grpOuterCounts
            // 
            this.grpOuterCounts.Controls.Add(this.tbInnersInOuters);
            this.grpOuterCounts.Controls.Add(this.lblCartonMessage);
            this.grpOuterCounts.Controls.Add(this.tbOutersScanned);
            this.grpOuterCounts.Controls.Add(this.lblInnersInOuters);
            this.grpOuterCounts.Controls.Add(this.lblOutersScanned);
            this.grpOuterCounts.Location = new System.Drawing.Point(0, 276);
            this.grpOuterCounts.Name = "grpOuterCounts";
            this.grpOuterCounts.Size = new System.Drawing.Size(216, 110);
            this.grpOuterCounts.TabIndex = 81;
            this.grpOuterCounts.TabStop = false;
            // 
            // lblCartonMessage
            // 
            this.lblCartonMessage.BackColor = System.Drawing.SystemColors.Control;
            this.lblCartonMessage.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartonMessage.ForeColor = System.Drawing.Color.Green;
            this.lblCartonMessage.Location = new System.Drawing.Point(5, 78);
            this.lblCartonMessage.Name = "lblCartonMessage";
            this.lblCartonMessage.Size = new System.Drawing.Size(203, 25);
            this.lblCartonMessage.TabIndex = 37;
            this.lblCartonMessage.Text = "Carton Message";
            // 
            // tbInnersInOuters
            // 
            this.tbInnersInOuters.BackColor = System.Drawing.SystemColors.Control;
            this.tbInnersInOuters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInnersInOuters.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnersInOuters.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbInnersInOuters.Location = new System.Drawing.Point(171, 46);
            this.tbInnersInOuters.Name = "tbInnersInOuters";
            this.tbInnersInOuters.ReadOnly = true;
            this.tbInnersInOuters.Size = new System.Drawing.Size(37, 29);
            this.tbInnersInOuters.TabIndex = 26;
            this.tbInnersInOuters.Text = " \r\n";
            this.tbInnersInOuters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblInnersInOuters
            // 
            this.lblInnersInOuters.AutoSize = true;
            this.lblInnersInOuters.BackColor = System.Drawing.Color.Transparent;
            this.lblInnersInOuters.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInnersInOuters.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInnersInOuters.Location = new System.Drawing.Point(3, 49);
            this.lblInnersInOuters.Name = "lblInnersInOuters";
            this.lblInnersInOuters.Size = new System.Drawing.Size(127, 22);
            this.lblInnersInOuters.TabIndex = 20;
            this.lblInnersInOuters.Text = "Inners In Cartons";
            // 
            // grpPalletInfo
            // 
            this.grpPalletInfo.Controls.Add(this.tbNotes);
            this.grpPalletInfo.Controls.Add(this.lblNotes);
            this.grpPalletInfo.Controls.Add(this.lblProductBatchesOnPallet);
            this.grpPalletInfo.Controls.Add(this.dgvCurrentPallet);
            this.grpPalletInfo.Controls.Add(this.lblStatusMessage);
            this.grpPalletInfo.Controls.Add(this.lblStatus);
            this.grpPalletInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpPalletInfo.Location = new System.Drawing.Point(0, 389);
            this.grpPalletInfo.Name = "grpPalletInfo";
            this.grpPalletInfo.Size = new System.Drawing.Size(454, 223);
            this.grpPalletInfo.TabIndex = 83;
            this.grpPalletInfo.TabStop = false;
            // 
            // tbProductUId
            // 
            this.tbProductUId.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProductUId.Location = new System.Drawing.Point(98, 3);
            this.tbProductUId.Name = "tbProductUId";
            this.tbProductUId.Size = new System.Drawing.Size(65, 29);
            this.tbProductUId.TabIndex = 79;
            // 
            // tbCartonsPerPallet
            // 
            this.tbCartonsPerPallet.BackColor = System.Drawing.SystemColors.Control;
            this.tbCartonsPerPallet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCartonsPerPallet.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCartonsPerPallet.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbCartonsPerPallet.Location = new System.Drawing.Point(171, 46);
            this.tbCartonsPerPallet.Name = "tbCartonsPerPallet";
            this.tbCartonsPerPallet.ReadOnly = true;
            this.tbCartonsPerPallet.Size = new System.Drawing.Size(37, 29);
            this.tbCartonsPerPallet.TabIndex = 26;
            this.tbCartonsPerPallet.Text = " \r\n";
            this.tbCartonsPerPallet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCurrentPalletUId
            // 
            this.tbCurrentPalletUId.BackColor = System.Drawing.SystemColors.Window;
            this.tbCurrentPalletUId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCurrentPalletUId.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCurrentPalletUId.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbCurrentPalletUId.Location = new System.Drawing.Point(309, 3);
            this.tbCurrentPalletUId.Name = "tbCurrentPalletUId";
            this.tbCurrentPalletUId.ReadOnly = true;
            this.tbCurrentPalletUId.Size = new System.Drawing.Size(71, 29);
            this.tbCurrentPalletUId.TabIndex = 26;
            this.tbCurrentPalletUId.Text = " \r\n";
            this.tbCurrentPalletUId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbInnersPerCarton
            // 
            this.tbInnersPerCarton.BackColor = System.Drawing.SystemColors.Control;
            this.tbInnersPerCarton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInnersPerCarton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnersPerCarton.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbInnersPerCarton.Location = new System.Drawing.Point(411, 46);
            this.tbInnersPerCarton.Name = "tbInnersPerCarton";
            this.tbInnersPerCarton.ReadOnly = true;
            this.tbInnersPerCarton.Size = new System.Drawing.Size(37, 29);
            this.tbInnersPerCarton.TabIndex = 26;
            this.tbInnersPerCarton.Text = " \r\n";
            this.tbInnersPerCarton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 22);
            this.label1.TabIndex = 84;
            this.label1.Text = "Cartons Per Pallet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(225, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 22);
            this.label2.TabIndex = 84;
            this.label2.Text = "Inners Per Carton";
            // 
            // grpPackTotals
            // 
            this.grpPackTotals.Controls.Add(this.tbInnersRqd);
            this.grpPackTotals.Controls.Add(this.lblInnersRqd);
            this.grpPackTotals.Controls.Add(this.label2);
            this.grpPackTotals.Controls.Add(this.tbOutersRqd);
            this.grpPackTotals.Controls.Add(this.lblOutersRqd);
            this.grpPackTotals.Controls.Add(this.label1);
            this.grpPackTotals.Controls.Add(this.tbInnersPerCarton);
            this.grpPackTotals.Controls.Add(this.tbCartonsPerPallet);
            this.grpPackTotals.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPackTotals.Location = new System.Drawing.Point(0, 190);
            this.grpPackTotals.Name = "grpPackTotals";
            this.grpPackTotals.Size = new System.Drawing.Size(454, 85);
            this.grpPackTotals.TabIndex = 85;
            this.grpPackTotals.TabStop = false;
            // 
            // frmLineInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(454, 761);
            this.ControlBox = false;
            this.Controls.Add(this.grpPackTotals);
            this.Controls.Add(this.tbProductUId);
            this.Controls.Add(this.grpPalletInfo);
            this.Controls.Add(this.tbPalletBatchUId);
            this.Controls.Add(this.tbCurrentPalletUId);
            this.Controls.Add(this.grpOuterCounts);
            this.Controls.Add(this.grpScanner);
            this.Controls.Add(this.grpInnerCounts);
            this.Controls.Add(this.grpButtons);
            this.Controls.Add(this.grpDisplay);
            this.Controls.Add(this.lblLine);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLineInfo";
            this.ShowIcon = false;
            this.Text = "frmLineInfo";
            this.Load += new System.EventHandler(this.frmLineInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentPallet)).EndInit();
            this.grpDisplay.ResumeLayout(false);
            this.grpDisplay.PerformLayout();
            this.grpButtons.ResumeLayout(false);
            this.grpScanner.ResumeLayout(false);
            this.grpScanner.PerformLayout();
            this.grpInnerCounts.ResumeLayout(false);
            this.grpInnerCounts.PerformLayout();
            this.grpOuterCounts.ResumeLayout(false);
            this.grpOuterCounts.PerformLayout();
            this.grpPalletInfo.ResumeLayout(false);
            this.grpPalletInfo.PerformLayout();
            this.grpPackTotals.ResumeLayout(false);
            this.grpPackTotals.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCurrentPallet;
        private System.Windows.Forms.RichTextBox tbNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Button btnPalletDetails;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblProductBatchesOnPallet;
        private System.Windows.Forms.TextBox tbOutersRqd;
        private System.Windows.Forms.Label lblOutersRqd;
        private System.Windows.Forms.TextBox tbCustomer;
        private System.Windows.Forms.TextBox tbProdName;
        private System.Windows.Forms.TextBox tbOutersScanned;
        private System.Windows.Forms.TextBox tbPalletBatchNo;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblSalesOrder;
        private System.Windows.Forms.Label lblOutersScanned;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.GroupBox grpDisplay;
        private System.Windows.Forms.Button btnPackLabels;
        private System.Windows.Forms.TextBox tbPalletBatchUId;
        private System.Windows.Forms.TextBox tbInnersScanned;
        private System.Windows.Forms.TextBox tbInnersRqd;
        private System.Windows.Forms.Label lblInnersScanned;
        private System.Windows.Forms.Label lblInnersRqd;
        private System.Windows.Forms.GroupBox grpButtons;
        private System.Windows.Forms.GroupBox grpScanner;
        private System.Windows.Forms.TextBox tbScannerStatus;
        private System.Windows.Forms.Button btnScannerStatus;
        private System.Windows.Forms.Button btnScannerStartStop;
        private System.Windows.Forms.TextBox tbScannerRunning;
        private System.Windows.Forms.Button btnShowDetails;
        private System.Windows.Forms.TextBox tbInnersUnassigned;
        private System.Windows.Forms.TextBox tbInnersOnPallets;
        private System.Windows.Forms.Label lblInnersUnassigned;
        private System.Windows.Forms.Label lblInnerInPallet;
        private System.Windows.Forms.GroupBox grpOuterCounts;
        private System.Windows.Forms.GroupBox grpInnerCounts;
        private System.Windows.Forms.GroupBox grpPalletInfo;
        private System.Windows.Forms.Label lblScannerMessage;
        private System.Windows.Forms.TextBox tbLotNo;
        private System.Windows.Forms.Label lblLotNo;
        private System.Windows.Forms.TextBox tbProductUId;
        private System.Windows.Forms.TextBox tbInnersInOuters;
        private System.Windows.Forms.Label lblInnersInOuters;
        private System.Windows.Forms.Label lblCartonMessage;
        private System.Windows.Forms.TextBox tbCartonsPerPallet;
        private System.Windows.Forms.TextBox tbCurrentPalletUId;
        private System.Windows.Forms.TextBox tbInnersPerCarton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpPackTotals;
    }
}