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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCurrentPallet = new System.Windows.Forms.DataGridView();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.btnPalletDetails = new System.Windows.Forms.Button();
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblProductBatchesOnPallet = new System.Windows.Forms.Label();
            this.txtTotalCartons = new System.Windows.Forms.TextBox();
            this.lblTotalCartonsRqd = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.txtCartonsOnPallet = new System.Windows.Forms.TextBox();
            this.txtPalletBatchNo = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblSalesOrder = new System.Windows.Forms.Label();
            this.lblTotalCartonsScanned = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.grpDisplay = new System.Windows.Forms.GroupBox();
            this.tbPalletBatch = new System.Windows.Forms.TextBox();
            this.tbInnersScanned = new System.Windows.Forms.TextBox();
            this.tbInnersRqd = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentPallet)).BeginInit();
            this.grpDisplay.SuspendLayout();
            this.grpButtons.SuspendLayout();
            this.grpScanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCurrentPallet
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            this.dgvCurrentPallet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvCurrentPallet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCurrentPallet.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCurrentPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCurrentPallet.CausesValidation = false;
            this.dgvCurrentPallet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvCurrentPallet.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvCurrentPallet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCurrentPallet.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvCurrentPallet.Enabled = false;
            this.dgvCurrentPallet.EnableHeadersVisualStyles = false;
            this.dgvCurrentPallet.Location = new System.Drawing.Point(225, 219);
            this.dgvCurrentPallet.Name = "dgvCurrentPallet";
            this.dgvCurrentPallet.ReadOnly = true;
            this.dgvCurrentPallet.RowHeadersVisible = false;
            this.dgvCurrentPallet.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCurrentPallet.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvCurrentPallet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrentPallet.Size = new System.Drawing.Size(223, 176);
            this.dgvCurrentPallet.TabIndex = 78;
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.Control;
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotes.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtNotes.Location = new System.Drawing.Point(9, 244);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ReadOnly = true;
            this.txtNotes.Size = new System.Drawing.Size(191, 126);
            this.txtNotes.TabIndex = 77;
            this.txtNotes.Text = "";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.BackColor = System.Drawing.SystemColors.Control;
            this.lblNotes.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNotes.Location = new System.Drawing.Point(9, 219);
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
            this.lblStatusMessage.AutoSize = true;
            this.lblStatusMessage.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatusMessage.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusMessage.ForeColor = System.Drawing.Color.Green;
            this.lblStatusMessage.Location = new System.Drawing.Point(113, 373);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(87, 22);
            this.lblStatusMessage.TabIndex = 36;
            this.lblStatusMessage.Text = "In-Progress";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatus.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus.Location = new System.Drawing.Point(9, 373);
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
            this.lblProductBatchesOnPallet.Location = new System.Drawing.Point(9, 197);
            this.lblProductBatchesOnPallet.Name = "lblProductBatchesOnPallet";
            this.lblProductBatchesOnPallet.Size = new System.Drawing.Size(197, 22);
            this.lblProductBatchesOnPallet.TabIndex = 31;
            this.lblProductBatchesOnPallet.Text = "Product batches on Pallet(s)";
            // 
            // txtTotalCartons
            // 
            this.txtTotalCartons.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalCartons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalCartons.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCartons.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtTotalCartons.Location = new System.Drawing.Point(177, 133);
            this.txtTotalCartons.Name = "txtTotalCartons";
            this.txtTotalCartons.ReadOnly = true;
            this.txtTotalCartons.Size = new System.Drawing.Size(37, 29);
            this.txtTotalCartons.TabIndex = 30;
            this.txtTotalCartons.Text = " \r\n";
            this.txtTotalCartons.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTotalCartonsRqd
            // 
            this.lblTotalCartonsRqd.AutoSize = true;
            this.lblTotalCartonsRqd.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalCartonsRqd.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCartonsRqd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotalCartonsRqd.Location = new System.Drawing.Point(9, 135);
            this.lblTotalCartonsRqd.Name = "lblTotalCartonsRqd";
            this.lblTotalCartonsRqd.Size = new System.Drawing.Size(166, 22);
            this.lblTotalCartonsRqd.TabIndex = 29;
            this.lblTotalCartonsRqd.Text = "Total Cartons Required";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomer.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtCustomer.Location = new System.Drawing.Point(108, 47);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(137, 29);
            this.txtCustomer.TabIndex = 28;
            this.txtCustomer.Text = " \r\n";
            // 
            // txtProdName
            // 
            this.txtProdName.BackColor = System.Drawing.SystemColors.Control;
            this.txtProdName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtProdName.Location = new System.Drawing.Point(108, 79);
            this.txtProdName.Multiline = true;
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.ReadOnly = true;
            this.txtProdName.Size = new System.Drawing.Size(340, 45);
            this.txtProdName.TabIndex = 27;
            this.txtProdName.Text = " \r\n";
            // 
            // txtCartonsOnPallet
            // 
            this.txtCartonsOnPallet.BackColor = System.Drawing.SystemColors.Control;
            this.txtCartonsOnPallet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCartonsOnPallet.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCartonsOnPallet.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtCartonsOnPallet.Location = new System.Drawing.Point(177, 165);
            this.txtCartonsOnPallet.Name = "txtCartonsOnPallet";
            this.txtCartonsOnPallet.ReadOnly = true;
            this.txtCartonsOnPallet.Size = new System.Drawing.Size(37, 29);
            this.txtCartonsOnPallet.TabIndex = 26;
            this.txtCartonsOnPallet.Text = " \r\n";
            this.txtCartonsOnPallet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPalletBatchNo
            // 
            this.txtPalletBatchNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtPalletBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPalletBatchNo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPalletBatchNo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtPalletBatchNo.Location = new System.Drawing.Point(108, 15);
            this.txtPalletBatchNo.Name = "txtPalletBatchNo";
            this.txtPalletBatchNo.ReadOnly = true;
            this.txtPalletBatchNo.Size = new System.Drawing.Size(137, 29);
            this.txtPalletBatchNo.TabIndex = 23;
            this.txtPalletBatchNo.Text = " \r\n";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.BackColor = System.Drawing.SystemColors.Control;
            this.lblProduct.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProduct.Location = new System.Drawing.Point(9, 81);
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
            this.lblSalesOrder.Location = new System.Drawing.Point(9, 17);
            this.lblSalesOrder.Name = "lblSalesOrder";
            this.lblSalesOrder.Size = new System.Drawing.Size(89, 22);
            this.lblSalesOrder.TabIndex = 21;
            this.lblSalesOrder.Text = "Sales Order";
            // 
            // lblTotalCartonsScanned
            // 
            this.lblTotalCartonsScanned.AutoSize = true;
            this.lblTotalCartonsScanned.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalCartonsScanned.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCartonsScanned.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotalCartonsScanned.Location = new System.Drawing.Point(9, 167);
            this.lblTotalCartonsScanned.Name = "lblTotalCartonsScanned";
            this.lblTotalCartonsScanned.Size = new System.Drawing.Size(163, 22);
            this.lblTotalCartonsScanned.TabIndex = 20;
            this.lblTotalCartonsScanned.Text = "Total Cartons Scanned";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.lblCustomer.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCustomer.Location = new System.Drawing.Point(9, 49);
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
            this.grpDisplay.Controls.Add(this.tbPalletBatch);
            this.grpDisplay.Controls.Add(this.txtPalletBatchNo);
            this.grpDisplay.Controls.Add(this.lblTotalCartonsScanned);
            this.grpDisplay.Controls.Add(this.lblSalesOrder);
            this.grpDisplay.Controls.Add(this.lblStatus);
            this.grpDisplay.Controls.Add(this.lblStatusMessage);
            this.grpDisplay.Controls.Add(this.txtCustomer);
            this.grpDisplay.Controls.Add(this.txtCartonsOnPallet);
            this.grpDisplay.Controls.Add(this.tbInnersScanned);
            this.grpDisplay.Controls.Add(this.tbInnersRqd);
            this.grpDisplay.Controls.Add(this.txtTotalCartons);
            this.grpDisplay.Controls.Add(this.dgvCurrentPallet);
            this.grpDisplay.Controls.Add(this.txtProdName);
            this.grpDisplay.Controls.Add(this.txtNotes);
            this.grpDisplay.Controls.Add(this.lblProductBatchesOnPallet);
            this.grpDisplay.Controls.Add(this.lblNotes);
            this.grpDisplay.Controls.Add(this.lblInnersScanned);
            this.grpDisplay.Controls.Add(this.lblInnersRqd);
            this.grpDisplay.Controls.Add(this.lblTotalCartonsRqd);
            this.grpDisplay.Controls.Add(this.lblCustomer);
            this.grpDisplay.Controls.Add(this.lblProduct);
            this.grpDisplay.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDisplay.Location = new System.Drawing.Point(0, 32);
            this.grpDisplay.Name = "grpDisplay";
            this.grpDisplay.Size = new System.Drawing.Size(454, 401);
            this.grpDisplay.TabIndex = 80;
            this.grpDisplay.TabStop = false;
            // 
            // tbPalletBatch
            // 
            this.tbPalletBatch.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletBatch.Location = new System.Drawing.Point(348, 15);
            this.tbPalletBatch.Name = "tbPalletBatch";
            this.tbPalletBatch.Size = new System.Drawing.Size(100, 29);
            this.tbPalletBatch.TabIndex = 79;
            // 
            // tbInnersScanned
            // 
            this.tbInnersScanned.BackColor = System.Drawing.SystemColors.Control;
            this.tbInnersScanned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInnersScanned.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnersScanned.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tbInnersScanned.Location = new System.Drawing.Point(411, 165);
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
            this.tbInnersRqd.Location = new System.Drawing.Point(411, 133);
            this.tbInnersRqd.Name = "tbInnersRqd";
            this.tbInnersRqd.ReadOnly = true;
            this.tbInnersRqd.Size = new System.Drawing.Size(37, 29);
            this.tbInnersRqd.TabIndex = 30;
            this.tbInnersRqd.Text = " \r\n";
            this.tbInnersRqd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblInnersScanned
            // 
            this.lblInnersScanned.AutoSize = true;
            this.lblInnersScanned.BackColor = System.Drawing.SystemColors.Control;
            this.lblInnersScanned.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInnersScanned.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInnersScanned.Location = new System.Drawing.Point(225, 170);
            this.lblInnersScanned.Name = "lblInnersScanned";
            this.lblInnersScanned.Size = new System.Drawing.Size(152, 22);
            this.lblInnersScanned.TabIndex = 29;
            this.lblInnersScanned.Text = "Total Inners Scanned";
            // 
            // lblInnersRqd
            // 
            this.lblInnersRqd.AutoSize = true;
            this.lblInnersRqd.BackColor = System.Drawing.SystemColors.Control;
            this.lblInnersRqd.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInnersRqd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInnersRqd.Location = new System.Drawing.Point(225, 135);
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
            this.grpButtons.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpButtons.Location = new System.Drawing.Point(0, 529);
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
            this.grpScanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpScanner.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpScanner.Location = new System.Drawing.Point(0, 433);
            this.grpScanner.Name = "grpScanner";
            this.grpScanner.Size = new System.Drawing.Size(454, 96);
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
            // frmLineInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(454, 587);
            this.ControlBox = false;
            this.Controls.Add(this.grpScanner);
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCurrentPallet;
        private System.Windows.Forms.RichTextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Button btnPalletDetails;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblProductBatchesOnPallet;
        private System.Windows.Forms.TextBox txtTotalCartons;
        private System.Windows.Forms.Label lblTotalCartonsRqd;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.TextBox txtCartonsOnPallet;
        private System.Windows.Forms.TextBox txtPalletBatchNo;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblSalesOrder;
        private System.Windows.Forms.Label lblTotalCartonsScanned;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.GroupBox grpDisplay;
        private System.Windows.Forms.Button btnPackLabels;
        private System.Windows.Forms.TextBox tbPalletBatch;
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
    }
}