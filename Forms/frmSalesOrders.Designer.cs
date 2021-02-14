namespace ITS.Exwold.Desktop
{
    partial class frmSalesOrders
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
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pnlTextBoxes = new System.Windows.Forms.Panel();
            this.tbProdCode = new System.Windows.Forms.MaskedTextBox();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tbInnerPackStyle = new System.Windows.Forms.MaskedTextBox();
            this.tbClientCode = new System.Windows.Forms.MaskedTextBox();
            this.tbCompanyCode = new System.Windows.Forms.MaskedTextBox();
            this.tbPlant = new System.Windows.Forms.MaskedTextBox();
            this.tbDateOfManufacture = new System.Windows.Forms.MaskedTextBox();
            this.tbInnerGTIN = new System.Windows.Forms.MaskedTextBox();
            this.tbGTIN = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbPalletBatchNo = new System.Windows.Forms.MaskedTextBox();
            this.tbGMID = new System.Windows.Forms.MaskedTextBox();
            this.tbDetails = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLotNumber = new System.Windows.Forms.MaskedTextBox();
            this.tbCustomer = new System.Windows.Forms.MaskedTextBox();
            this.cboProdLine = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.MaskedTextBox();
            this.cboInnerUnit = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbInnerWeight = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbInnersPerCart = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCartonsPerPallet = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTotalCartons = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbProdName = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.grpButtons = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.pnlTextBoxes.SuspendLayout();
            this.grpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(3, 41);
            this.dgvOrders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.ShowCellErrors = false;
            this.dgvOrders.ShowCellToolTips = false;
            this.dgvOrders.ShowEditingIcon = false;
            this.dgvOrders.ShowRowErrors = false;
            this.dgvOrders.Size = new System.Drawing.Size(1480, 616);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.TabStop = false;
            this.dgvOrders.DataSourceChanged += new System.EventHandler(this.dgvOrders_DataSourceChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(3, 663);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 39);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(143, 663);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(140, 39);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // pnlTextBoxes
            // 
            this.pnlTextBoxes.Controls.Add(this.tbProdCode);
            this.pnlTextBoxes.Controls.Add(this.btnChangeStatus);
            this.pnlTextBoxes.Controls.Add(this.cboStatus);
            this.pnlTextBoxes.Controls.Add(this.lblStatus);
            this.pnlTextBoxes.Controls.Add(this.tbInnerPackStyle);
            this.pnlTextBoxes.Controls.Add(this.tbClientCode);
            this.pnlTextBoxes.Controls.Add(this.tbCompanyCode);
            this.pnlTextBoxes.Controls.Add(this.tbPlant);
            this.pnlTextBoxes.Controls.Add(this.tbDateOfManufacture);
            this.pnlTextBoxes.Controls.Add(this.tbInnerGTIN);
            this.pnlTextBoxes.Controls.Add(this.tbGTIN);
            this.pnlTextBoxes.Controls.Add(this.label9);
            this.pnlTextBoxes.Controls.Add(this.tbPalletBatchNo);
            this.pnlTextBoxes.Controls.Add(this.tbGMID);
            this.pnlTextBoxes.Controls.Add(this.tbDetails);
            this.pnlTextBoxes.Controls.Add(this.label11);
            this.pnlTextBoxes.Controls.Add(this.label8);
            this.pnlTextBoxes.Controls.Add(this.tbLotNumber);
            this.pnlTextBoxes.Controls.Add(this.tbCustomer);
            this.pnlTextBoxes.Controls.Add(this.cboProdLine);
            this.pnlTextBoxes.Controls.Add(this.label14);
            this.pnlTextBoxes.Controls.Add(this.label13);
            this.pnlTextBoxes.Controls.Add(this.label10);
            this.pnlTextBoxes.Controls.Add(this.label7);
            this.pnlTextBoxes.Controls.Add(this.tbNotes);
            this.pnlTextBoxes.Controls.Add(this.cboInnerUnit);
            this.pnlTextBoxes.Controls.Add(this.label6);
            this.pnlTextBoxes.Controls.Add(this.tbInnerWeight);
            this.pnlTextBoxes.Controls.Add(this.label5);
            this.pnlTextBoxes.Controls.Add(this.tbInnersPerCart);
            this.pnlTextBoxes.Controls.Add(this.label4);
            this.pnlTextBoxes.Controls.Add(this.tbCartonsPerPallet);
            this.pnlTextBoxes.Controls.Add(this.label3);
            this.pnlTextBoxes.Controls.Add(this.tbTotalCartons);
            this.pnlTextBoxes.Controls.Add(this.label2);
            this.pnlTextBoxes.Controls.Add(this.tbProdName);
            this.pnlTextBoxes.Controls.Add(this.label1);
            this.pnlTextBoxes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTextBoxes.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTextBoxes.Location = new System.Drawing.Point(0, 708);
            this.pnlTextBoxes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTextBoxes.Name = "pnlTextBoxes";
            this.pnlTextBoxes.Size = new System.Drawing.Size(1484, 187);
            this.pnlTextBoxes.TabIndex = 3;
            this.pnlTextBoxes.Visible = false;
            // 
            // tbProdCode
            // 
            this.tbProdCode.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProdCode.Location = new System.Drawing.Point(132, 33);
            this.tbProdCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbProdCode.Name = "tbProdCode";
            this.tbProdCode.ReadOnly = true;
            this.tbProdCode.Size = new System.Drawing.Size(230, 29);
            this.tbProdCode.TabIndex = 50;
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeStatus.Location = new System.Drawing.Point(1225, 123);
            this.btnChangeStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(258, 29);
            this.btnChangeStatus.TabIndex = 49;
            this.btnChangeStatus.Text = "Change Status";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnEnableStatus_Click);
            // 
            // cboStatus
            // 
            this.cboStatus.DisplayMember = "StatusNo";
            this.cboStatus.Enabled = false;
            this.cboStatus.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(1227, 92);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(256, 30);
            this.cboStatus.TabIndex = 48;
            this.cboStatus.ValueMember = "StatusNo";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(1049, 96);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 22);
            this.lblStatus.TabIndex = 47;
            this.lblStatus.Text = "Status";
            // 
            // tbInnerPackStyle
            // 
            this.tbInnerPackStyle.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnerPackStyle.Location = new System.Drawing.Point(312, 154);
            this.tbInnerPackStyle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbInnerPackStyle.Name = "tbInnerPackStyle";
            this.tbInnerPackStyle.Size = new System.Drawing.Size(39, 29);
            this.tbInnerPackStyle.TabIndex = 46;
            this.tbInnerPackStyle.Visible = false;
            // 
            // tbClientCode
            // 
            this.tbClientCode.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbClientCode.Location = new System.Drawing.Point(272, 154);
            this.tbClientCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbClientCode.Name = "tbClientCode";
            this.tbClientCode.Size = new System.Drawing.Size(39, 29);
            this.tbClientCode.TabIndex = 45;
            this.tbClientCode.Visible = false;
            // 
            // tbCompanyCode
            // 
            this.tbCompanyCode.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCompanyCode.Location = new System.Drawing.Point(112, 154);
            this.tbCompanyCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCompanyCode.Name = "tbCompanyCode";
            this.tbCompanyCode.Size = new System.Drawing.Size(39, 29);
            this.tbCompanyCode.TabIndex = 44;
            this.tbCompanyCode.Visible = false;
            // 
            // tbPlant
            // 
            this.tbPlant.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPlant.Location = new System.Drawing.Point(32, 154);
            this.tbPlant.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPlant.Name = "tbPlant";
            this.tbPlant.Size = new System.Drawing.Size(39, 29);
            this.tbPlant.TabIndex = 43;
            this.tbPlant.Visible = false;
            // 
            // tbDateOfManufacture
            // 
            this.tbDateOfManufacture.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDateOfManufacture.Location = new System.Drawing.Point(352, 154);
            this.tbDateOfManufacture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDateOfManufacture.Name = "tbDateOfManufacture";
            this.tbDateOfManufacture.Size = new System.Drawing.Size(39, 29);
            this.tbDateOfManufacture.TabIndex = 43;
            this.tbDateOfManufacture.Visible = false;
            // 
            // tbInnerGTIN
            // 
            this.tbInnerGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnerGTIN.Location = new System.Drawing.Point(192, 154);
            this.tbInnerGTIN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbInnerGTIN.Name = "tbInnerGTIN";
            this.tbInnerGTIN.Size = new System.Drawing.Size(39, 29);
            this.tbInnerGTIN.TabIndex = 43;
            this.tbInnerGTIN.Visible = false;
            // 
            // tbGTIN
            // 
            this.tbGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGTIN.Location = new System.Drawing.Point(152, 154);
            this.tbGTIN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGTIN.Name = "tbGTIN";
            this.tbGTIN.Size = new System.Drawing.Size(39, 29);
            this.tbGTIN.TabIndex = 43;
            this.tbGTIN.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1049, 35);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 22);
            this.label9.TabIndex = 42;
            this.label9.Text = "Sales Order Number";
            // 
            // tbPalletBatchNo
            // 
            this.tbPalletBatchNo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletBatchNo.Location = new System.Drawing.Point(1227, 35);
            this.tbPalletBatchNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletBatchNo.Name = "tbPalletBatchNo";
            this.tbPalletBatchNo.Size = new System.Drawing.Size(256, 29);
            this.tbPalletBatchNo.TabIndex = 41;
            // 
            // tbGMID
            // 
            this.tbGMID.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGMID.Location = new System.Drawing.Point(232, 154);
            this.tbGMID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGMID.Name = "tbGMID";
            this.tbGMID.Size = new System.Drawing.Size(39, 29);
            this.tbGMID.TabIndex = 40;
            this.tbGMID.Visible = false;
            // 
            // tbDetails
            // 
            this.tbDetails.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDetails.Location = new System.Drawing.Point(72, 154);
            this.tbDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDetails.Name = "tbDetails";
            this.tbDetails.Size = new System.Drawing.Size(39, 29);
            this.tbDetails.TabIndex = 39;
            this.tbDetails.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 126);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 22);
            this.label11.TabIndex = 37;
            this.label11.Text = "Lot Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 96);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 22);
            this.label8.TabIndex = 37;
            this.label8.Text = "Customer Name";
            // 
            // tbLotNumber
            // 
            this.tbLotNumber.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLotNumber.Location = new System.Drawing.Point(132, 123);
            this.tbLotNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLotNumber.Name = "tbLotNumber";
            this.tbLotNumber.ReadOnly = true;
            this.tbLotNumber.Size = new System.Drawing.Size(230, 29);
            this.tbLotNumber.TabIndex = 36;
            // 
            // tbCustomer
            // 
            this.tbCustomer.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomer.Location = new System.Drawing.Point(132, 93);
            this.tbCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCustomer.Name = "tbCustomer";
            this.tbCustomer.ReadOnly = true;
            this.tbCustomer.Size = new System.Drawing.Size(230, 29);
            this.tbCustomer.TabIndex = 36;
            // 
            // cboProdLine
            // 
            this.cboProdLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProdLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProdLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProdLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProdLine.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProdLine.FormattingEnabled = true;
            this.cboProdLine.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cboProdLine.Location = new System.Drawing.Point(1227, 65);
            this.cboProdLine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboProdLine.Name = "cboProdLine";
            this.cboProdLine.Size = new System.Drawing.Size(256, 30);
            this.cboProdLine.TabIndex = 35;
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(567, 3);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(916, 29);
            this.label14.TabIndex = 34;
            this.label14.Text = "Sales Order Details";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 3);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(541, 29);
            this.label13.TabIndex = 33;
            this.label13.Text = "Product Details (cannot be changed for batch)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 36);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 22);
            this.label10.TabIndex = 28;
            this.label10.Text = "Product Code";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(567, 158);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 22);
            this.label7.TabIndex = 22;
            this.label7.Text = "Notes";
            // 
            // tbNotes
            // 
            this.tbNotes.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotes.Location = new System.Drawing.Point(782, 153);
            this.tbNotes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(390, 29);
            this.tbNotes.TabIndex = 21;
            // 
            // cboInnerUnit
            // 
            this.cboInnerUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboInnerUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboInnerUnit.BackColor = System.Drawing.SystemColors.Window;
            this.cboInnerUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInnerUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboInnerUnit.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInnerUnit.FormattingEnabled = true;
            this.cboInnerUnit.Items.AddRange(new object[] {
            "Kg",
            "L"});
            this.cboInnerUnit.Location = new System.Drawing.Point(912, 121);
            this.cboInnerUnit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboInnerUnit.Name = "cboInnerUnit";
            this.cboInnerUnit.Size = new System.Drawing.Size(62, 30);
            this.cboInnerUnit.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(567, 123);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 22);
            this.label6.TabIndex = 17;
            this.label6.Text = "Inner weight/volume";
            // 
            // tbInnerWeight
            // 
            this.tbInnerWeight.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnerWeight.Location = new System.Drawing.Point(782, 123);
            this.tbInnerWeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbInnerWeight.Name = "tbInnerWeight";
            this.tbInnerWeight.Size = new System.Drawing.Size(127, 29);
            this.tbInnerWeight.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(567, 96);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 22);
            this.label5.TabIndex = 15;
            this.label5.Text = "Inners per Carton";
            // 
            // tbInnersPerCart
            // 
            this.tbInnersPerCart.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnersPerCart.Location = new System.Drawing.Point(782, 93);
            this.tbInnersPerCart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbInnersPerCart.Name = "tbInnersPerCart";
            this.tbInnersPerCart.Size = new System.Drawing.Size(127, 29);
            this.tbInnersPerCart.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(567, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 22);
            this.label4.TabIndex = 13;
            this.label4.Text = "Cartons per Pallet";
            // 
            // tbCartonsPerPallet
            // 
            this.tbCartonsPerPallet.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCartonsPerPallet.Location = new System.Drawing.Point(782, 63);
            this.tbCartonsPerPallet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCartonsPerPallet.Name = "tbCartonsPerPallet";
            this.tbCartonsPerPallet.Size = new System.Drawing.Size(127, 29);
            this.tbCartonsPerPallet.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(567, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Number of Cartons";
            // 
            // tbTotalCartons
            // 
            this.tbTotalCartons.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalCartons.Location = new System.Drawing.Point(782, 33);
            this.tbTotalCartons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTotalCartons.Name = "tbTotalCartons";
            this.tbTotalCartons.Size = new System.Drawing.Size(127, 29);
            this.tbTotalCartons.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Product Name";
            // 
            // tbProdName
            // 
            this.tbProdName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProdName.Location = new System.Drawing.Point(132, 63);
            this.tbProdName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbProdName.Name = "tbProdName";
            this.tbProdName.ReadOnly = true;
            this.tbProdName.Size = new System.Drawing.Size(412, 29);
            this.tbProdName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1049, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Production Line";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1185, 19);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(144, 39);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1037, 19);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 39);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Font = new System.Drawing.Font("Palatino Linotype", 18F);
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(1484, 34);
            this.label15.TabIndex = 7;
            this.label15.Text = "Sales Orders";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(283, 663);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(140, 39);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewDetails.Location = new System.Drawing.Point(1158, 663);
            this.btnViewDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(325, 39);
            this.btnViewDetails.TabIndex = 12;
            this.btnViewDetails.Text = "View details for this Sales Order";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnSetStatus_Click);
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add(this.btnClose);
            this.grpButtons.Controls.Add(this.btnCancel);
            this.grpButtons.Controls.Add(this.btnSave);
            this.grpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpButtons.Location = new System.Drawing.Point(0, 895);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Size = new System.Drawing.Size(1484, 66);
            this.grpButtons.TabIndex = 13;
            this.grpButtons.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1329, 19);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(148, 39);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSalesOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1484, 961);
            this.ControlBox = false;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.pnlTextBoxes);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.grpButtons);
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSalesOrders";
            this.Text = "EXWOLD PALLET TRACKING";
            this.Load += new System.EventHandler(this.PalletDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.pnlTextBoxes.ResumeLayout(false);
            this.pnlTextBoxes.PerformLayout();
            this.grpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel pnlTextBoxes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbProdName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox tbCartonsPerPallet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tbTotalCartons;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox tbInnersPerCart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox tbInnerWeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox tbNotes;
        private System.Windows.Forms.ComboBox cboInnerUnit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cboProdLine;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox tbCustomer;
        private System.Windows.Forms.MaskedTextBox tbGMID;
        private System.Windows.Forms.MaskedTextBox tbDetails;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox tbPalletBatchNo;
        private System.Windows.Forms.MaskedTextBox tbClientCode;
        private System.Windows.Forms.MaskedTextBox tbCompanyCode;
        private System.Windows.Forms.MaskedTextBox tbGTIN;
        private System.Windows.Forms.MaskedTextBox tbInnerPackStyle;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.MaskedTextBox tbProdCode;
        private System.Windows.Forms.MaskedTextBox tbPlant;
        private System.Windows.Forms.MaskedTextBox tbDateOfManufacture;
        private System.Windows.Forms.MaskedTextBox tbInnerGTIN;
        private System.Windows.Forms.GroupBox grpButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox tbLotNumber;
    }
}

