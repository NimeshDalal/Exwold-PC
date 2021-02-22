namespace ITS.Exwold.Desktop
{
    partial class Product
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
            this.dgvAllProducts = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pnlProductDetails = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLotNumber = new System.Windows.Forms.MaskedTextBox();
            this.dtpDateOfManufacture = new System.Windows.Forms.DateTimePicker();
            this.lblDoM = new System.Windows.Forms.Label();
            this.lblInnerGTIN = new System.Windows.Forms.Label();
            this.tbInnerGTIN = new System.Windows.Forms.MaskedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbInnerPackStyle = new System.Windows.Forms.MaskedTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbGMID = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbDetails = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbCustomer = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbClientCode = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCompanyCode = new System.Windows.Forms.MaskedTextBox();
            this.lblOuterGTIN = new System.Windows.Forms.Label();
            this.tbGTIN = new System.Windows.Forms.MaskedTextBox();
            this.cboInnerUnit = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbInnerWeight = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbInnersPerCart = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCartsPerPallet = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDefaultCartons = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbProdName = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbProdCode = new System.Windows.Forms.MaskedTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCreateSalesOrder = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpEditButtons = new System.Windows.Forms.GroupBox();
            this.grpButtons = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllProducts)).BeginInit();
            this.pnlProductDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            this.grpEditButtons.SuspendLayout();
            this.grpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAllProducts
            // 
            this.dgvAllProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAllProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAllProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAllProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllProducts.Location = new System.Drawing.Point(3, 42);
            this.dgvAllProducts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvAllProducts.MultiSelect = false;
            this.dgvAllProducts.Name = "dgvAllProducts";
            this.dgvAllProducts.ReadOnly = true;
            this.dgvAllProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllProducts.ShowCellErrors = false;
            this.dgvAllProducts.ShowCellToolTips = false;
            this.dgvAllProducts.ShowEditingIcon = false;
            this.dgvAllProducts.ShowRowErrors = false;
            this.dgvAllProducts.Size = new System.Drawing.Size(1481, 515);
            this.dgvAllProducts.TabIndex = 0;
            this.dgvAllProducts.TabStop = false;
            this.dgvAllProducts.DataSourceChanged += new System.EventHandler(this.dgvAllProducts_DataSourceChanged);
            this.dgvAllProducts.SelectionChanged += new System.EventHandler(this.dgvAllProducts_SelectionChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.btnAdd.Location = new System.Drawing.Point(8, 19);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(148, 39);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.btnEdit.Location = new System.Drawing.Point(156, 19);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(148, 39);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // pnlProductDetails
            // 
            this.pnlProductDetails.Controls.Add(this.label7);
            this.pnlProductDetails.Controls.Add(this.tbLotNumber);
            this.pnlProductDetails.Controls.Add(this.dtpDateOfManufacture);
            this.pnlProductDetails.Controls.Add(this.lblDoM);
            this.pnlProductDetails.Controls.Add(this.lblInnerGTIN);
            this.pnlProductDetails.Controls.Add(this.tbInnerGTIN);
            this.pnlProductDetails.Controls.Add(this.label18);
            this.pnlProductDetails.Controls.Add(this.tbInnerPackStyle);
            this.pnlProductDetails.Controls.Add(this.label17);
            this.pnlProductDetails.Controls.Add(this.tbNotes);
            this.pnlProductDetails.Controls.Add(this.label14);
            this.pnlProductDetails.Controls.Add(this.label13);
            this.pnlProductDetails.Controls.Add(this.label12);
            this.pnlProductDetails.Controls.Add(this.tbGMID);
            this.pnlProductDetails.Controls.Add(this.label11);
            this.pnlProductDetails.Controls.Add(this.tbDetails);
            this.pnlProductDetails.Controls.Add(this.label10);
            this.pnlProductDetails.Controls.Add(this.tbCustomer);
            this.pnlProductDetails.Controls.Add(this.label9);
            this.pnlProductDetails.Controls.Add(this.tbClientCode);
            this.pnlProductDetails.Controls.Add(this.label8);
            this.pnlProductDetails.Controls.Add(this.tbCompanyCode);
            this.pnlProductDetails.Controls.Add(this.lblOuterGTIN);
            this.pnlProductDetails.Controls.Add(this.tbGTIN);
            this.pnlProductDetails.Controls.Add(this.cboInnerUnit);
            this.pnlProductDetails.Controls.Add(this.label6);
            this.pnlProductDetails.Controls.Add(this.tbInnerWeight);
            this.pnlProductDetails.Controls.Add(this.label5);
            this.pnlProductDetails.Controls.Add(this.tbInnersPerCart);
            this.pnlProductDetails.Controls.Add(this.label4);
            this.pnlProductDetails.Controls.Add(this.tbCartsPerPallet);
            this.pnlProductDetails.Controls.Add(this.label3);
            this.pnlProductDetails.Controls.Add(this.tbDefaultCartons);
            this.pnlProductDetails.Controls.Add(this.label2);
            this.pnlProductDetails.Controls.Add(this.tbProdName);
            this.pnlProductDetails.Controls.Add(this.label1);
            this.pnlProductDetails.Controls.Add(this.tbProdCode);
            this.pnlProductDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProductDetails.Location = new System.Drawing.Point(0, 614);
            this.pnlProductDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlProductDetails.Name = "pnlProductDetails";
            this.pnlProductDetails.Size = new System.Drawing.Size(1484, 281);
            this.pnlProductDetails.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label7.Location = new System.Drawing.Point(993, 41);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 22);
            this.label7.TabIndex = 42;
            this.label7.Text = "Lot Number";
            // 
            // tbLotNumber
            // 
            this.tbLotNumber.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbLotNumber.Location = new System.Drawing.Point(1286, 38);
            this.tbLotNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLotNumber.Name = "tbLotNumber";
            this.tbLotNumber.Size = new System.Drawing.Size(198, 29);
            this.tbLotNumber.TabIndex = 43;
            // 
            // dtpDateOfManufacture
            // 
            this.dtpDateOfManufacture.CustomFormat = "dd-MMM-yyyy";
            this.dtpDateOfManufacture.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.dtpDateOfManufacture.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfManufacture.Location = new System.Drawing.Point(1286, 128);
            this.dtpDateOfManufacture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDateOfManufacture.Name = "dtpDateOfManufacture";
            this.dtpDateOfManufacture.Size = new System.Drawing.Size(198, 29);
            this.dtpDateOfManufacture.TabIndex = 41;
            // 
            // lblDoM
            // 
            this.lblDoM.AutoSize = true;
            this.lblDoM.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.lblDoM.Location = new System.Drawing.Point(993, 131);
            this.lblDoM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDoM.Name = "lblDoM";
            this.lblDoM.Size = new System.Drawing.Size(156, 22);
            this.lblDoM.TabIndex = 40;
            this.lblDoM.Text = "Date Of Manufacture";
            // 
            // lblInnerGTIN
            // 
            this.lblInnerGTIN.AutoSize = true;
            this.lblInnerGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.lblInnerGTIN.Location = new System.Drawing.Point(993, 101);
            this.lblInnerGTIN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInnerGTIN.Name = "lblInnerGTIN";
            this.lblInnerGTIN.Size = new System.Drawing.Size(89, 22);
            this.lblInnerGTIN.TabIndex = 40;
            this.lblInnerGTIN.Text = "Inner GTIN";
            // 
            // tbInnerGTIN
            // 
            this.tbInnerGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbInnerGTIN.Location = new System.Drawing.Point(1286, 98);
            this.tbInnerGTIN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbInnerGTIN.Mask = "00000000000000";
            this.tbInnerGTIN.Name = "tbInnerGTIN";
            this.tbInnerGTIN.Size = new System.Drawing.Size(198, 29);
            this.tbInnerGTIN.TabIndex = 32;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label18.Location = new System.Drawing.Point(409, 221);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(121, 22);
            this.label18.TabIndex = 38;
            this.label18.Text = "Inner Pack Style";
            // 
            // tbInnerPackStyle
            // 
            this.tbInnerPackStyle.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbInnerPackStyle.Location = new System.Drawing.Point(572, 218);
            this.tbInnerPackStyle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbInnerPackStyle.Name = "tbInnerPackStyle";
            this.tbInnerPackStyle.Size = new System.Drawing.Size(303, 29);
            this.tbInnerPackStyle.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label17.Location = new System.Drawing.Point(993, 221);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 22);
            this.label17.TabIndex = 36;
            this.label17.Text = "Notes";
            // 
            // tbNotes
            // 
            this.tbNotes.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbNotes.Location = new System.Drawing.Point(1063, 218);
            this.tbNotes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(422, 29);
            this.tbNotes.TabIndex = 35;
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(413, 0);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(1071, 35);
            this.label14.TabIndex = 34;
            this.label14.Text = "Product Details";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(376, 35);
            this.label13.TabIndex = 33;
            this.label13.Text = "Customer Details";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label12.Location = new System.Drawing.Point(2, 101);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 22);
            this.label12.TabIndex = 32;
            this.label12.Text = "GMID";
            // 
            // tbGMID
            // 
            this.tbGMID.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbGMID.Location = new System.Drawing.Point(90, 98);
            this.tbGMID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGMID.Name = "tbGMID";
            this.tbGMID.Size = new System.Drawing.Size(286, 29);
            this.tbGMID.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label11.Location = new System.Drawing.Point(2, 71);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 22);
            this.label11.TabIndex = 30;
            this.label11.Text = "Details";
            // 
            // tbDetails
            // 
            this.tbDetails.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbDetails.Location = new System.Drawing.Point(90, 68);
            this.tbDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDetails.Name = "tbDetails";
            this.tbDetails.Size = new System.Drawing.Size(286, 29);
            this.tbDetails.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label10.Location = new System.Drawing.Point(2, 43);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 22);
            this.label10.TabIndex = 28;
            this.label10.Text = "Customer";
            // 
            // tbCustomer
            // 
            this.tbCustomer.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbCustomer.Location = new System.Drawing.Point(90, 38);
            this.tbCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCustomer.Name = "tbCustomer";
            this.tbCustomer.Size = new System.Drawing.Size(286, 29);
            this.tbCustomer.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label9.Location = new System.Drawing.Point(993, 191);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(183, 22);
            this.label9.TabIndex = 26;
            this.label9.Text = "SSCC PL Customer Code";
            // 
            // tbClientCode
            // 
            this.tbClientCode.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbClientCode.Location = new System.Drawing.Point(1286, 188);
            this.tbClientCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbClientCode.Name = "tbClientCode";
            this.tbClientCode.Size = new System.Drawing.Size(198, 29);
            this.tbClientCode.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label8.Location = new System.Drawing.Point(993, 161);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 22);
            this.label8.TabIndex = 24;
            this.label8.Text = "SSCC Company Code";
            // 
            // tbCompanyCode
            // 
            this.tbCompanyCode.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbCompanyCode.Location = new System.Drawing.Point(1286, 158);
            this.tbCompanyCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCompanyCode.Name = "tbCompanyCode";
            this.tbCompanyCode.Size = new System.Drawing.Size(198, 29);
            this.tbCompanyCode.TabIndex = 33;
            // 
            // lblOuterGTIN
            // 
            this.lblOuterGTIN.AutoSize = true;
            this.lblOuterGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.lblOuterGTIN.Location = new System.Drawing.Point(993, 71);
            this.lblOuterGTIN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOuterGTIN.Name = "lblOuterGTIN";
            this.lblOuterGTIN.Size = new System.Drawing.Size(135, 22);
            this.lblOuterGTIN.TabIndex = 22;
            this.lblOuterGTIN.Text = "Pallet/Outer GTIN";
            // 
            // tbGTIN
            // 
            this.tbGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbGTIN.Location = new System.Drawing.Point(1286, 68);
            this.tbGTIN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGTIN.Mask = "00000000000000";
            this.tbGTIN.Name = "tbGTIN";
            this.tbGTIN.Size = new System.Drawing.Size(198, 29);
            this.tbGTIN.TabIndex = 31;
            // 
            // cboInnerUnit
            // 
            this.cboInnerUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboInnerUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboInnerUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInnerUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboInnerUnit.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.cboInnerUnit.FormattingEnabled = true;
            this.cboInnerUnit.Items.AddRange(new object[] {
            "Kg",
            "L"});
            this.cboInnerUnit.Location = new System.Drawing.Point(878, 186);
            this.cboInnerUnit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboInnerUnit.Name = "cboInnerUnit";
            this.cboInnerUnit.Size = new System.Drawing.Size(62, 30);
            this.cboInnerUnit.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label6.Location = new System.Drawing.Point(409, 193);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 22);
            this.label6.TabIndex = 17;
            this.label6.Text = "Inner weight/volume";
            // 
            // tbInnerWeight
            // 
            this.tbInnerWeight.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbInnerWeight.Location = new System.Drawing.Point(572, 188);
            this.tbInnerWeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbInnerWeight.Name = "tbInnerWeight";
            this.tbInnerWeight.Size = new System.Drawing.Size(303, 29);
            this.tbInnerWeight.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label5.Location = new System.Drawing.Point(409, 161);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 22);
            this.label5.TabIndex = 15;
            this.label5.Text = "Inners per Carton";
            // 
            // tbInnersPerCart
            // 
            this.tbInnersPerCart.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbInnersPerCart.Location = new System.Drawing.Point(572, 158);
            this.tbInnersPerCart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbInnersPerCart.Name = "tbInnersPerCart";
            this.tbInnersPerCart.Size = new System.Drawing.Size(303, 29);
            this.tbInnersPerCart.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label4.Location = new System.Drawing.Point(409, 131);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 22);
            this.label4.TabIndex = 13;
            this.label4.Text = "Cartons per Pallet";
            // 
            // tbCartsPerPallet
            // 
            this.tbCartsPerPallet.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbCartsPerPallet.Location = new System.Drawing.Point(572, 128);
            this.tbCartsPerPallet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCartsPerPallet.Name = "tbCartsPerPallet";
            this.tbCartsPerPallet.Size = new System.Drawing.Size(303, 29);
            this.tbCartsPerPallet.TabIndex = 24;
            this.tbCartsPerPallet.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label3.Location = new System.Drawing.Point(409, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Default no. Cartons";
            // 
            // tbDefaultCartons
            // 
            this.tbDefaultCartons.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbDefaultCartons.Location = new System.Drawing.Point(572, 98);
            this.tbDefaultCartons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbDefaultCartons.Name = "tbDefaultCartons";
            this.tbDefaultCartons.Size = new System.Drawing.Size(303, 29);
            this.tbDefaultCartons.TabIndex = 23;
            this.tbDefaultCartons.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label2.Location = new System.Drawing.Point(409, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Prod Name";
            // 
            // tbProdName
            // 
            this.tbProdName.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbProdName.Location = new System.Drawing.Point(572, 68);
            this.tbProdName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbProdName.Name = "tbProdName";
            this.tbProdName.Size = new System.Drawing.Size(303, 29);
            this.tbProdName.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label1.Location = new System.Drawing.Point(409, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Prod Code";
            // 
            // tbProdCode
            // 
            this.tbProdCode.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbProdCode.Location = new System.Drawing.Point(572, 38);
            this.tbProdCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbProdCode.Name = "tbProdCode";
            this.tbProdCode.Size = new System.Drawing.Size(303, 29);
            this.tbProdCode.TabIndex = 21;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.btnSave.Location = new System.Drawing.Point(1033, 19);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 39);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.btnClose.Location = new System.Drawing.Point(1329, 19);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(148, 39);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button_close_Click);
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
            this.label15.Text = "Customer / Product details";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCreateSalesOrder
            // 
            this.btnCreateSalesOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateSalesOrder.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.btnCreateSalesOrder.Location = new System.Drawing.Point(1181, 19);
            this.btnCreateSalesOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreateSalesOrder.Name = "btnCreateSalesOrder";
            this.btnCreateSalesOrder.Size = new System.Drawing.Size(296, 39);
            this.btnCreateSalesOrder.TabIndex = 9;
            this.btnCreateSalesOrder.Text = "Create Sales Order for this product";
            this.btnCreateSalesOrder.UseVisualStyleBackColor = true;
            this.btnCreateSalesOrder.Click += new System.EventHandler(this.btnCreateSalesOrder_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.btnDelete.Location = new System.Drawing.Point(304, 19);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(148, 39);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.btnRefresh.Location = new System.Drawing.Point(7, 19);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(148, 39);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpEditButtons
            // 
            this.grpEditButtons.Controls.Add(this.btnDelete);
            this.grpEditButtons.Controls.Add(this.btnAdd);
            this.grpEditButtons.Controls.Add(this.btnCreateSalesOrder);
            this.grpEditButtons.Controls.Add(this.btnEdit);
            this.grpEditButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpEditButtons.Location = new System.Drawing.Point(0, 548);
            this.grpEditButtons.Name = "grpEditButtons";
            this.grpEditButtons.Size = new System.Drawing.Size(1484, 66);
            this.grpEditButtons.TabIndex = 13;
            this.grpEditButtons.TabStop = false;
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add(this.btnClose);
            this.grpButtons.Controls.Add(this.btnCancel);
            this.grpButtons.Controls.Add(this.btnSave);
            this.grpButtons.Controls.Add(this.btnRefresh);
            this.grpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpButtons.Location = new System.Drawing.Point(0, 895);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Size = new System.Drawing.Size(1484, 66);
            this.grpButtons.TabIndex = 14;
            this.grpButtons.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.btnCancel.Location = new System.Drawing.Point(1181, 19);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(148, 39);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1484, 961);
            this.ControlBox = false;
            this.Controls.Add(this.grpEditButtons);
            this.Controls.Add(this.pnlProductDetails);
            this.Controls.Add(this.dgvAllProducts);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.grpButtons);
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Product";
            this.Text = "EXWOLD PALLET TRACKING";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllProducts)).EndInit();
            this.pnlProductDetails.ResumeLayout(false);
            this.pnlProductDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            this.grpEditButtons.ResumeLayout(false);
            this.grpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAllProducts;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel pnlProductDetails;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox tbProdCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbProdName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox tbCartsPerPallet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tbDefaultCartons;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox tbInnersPerCart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox tbInnerWeight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox tbClientCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox tbCompanyCode;
        private System.Windows.Forms.Label lblOuterGTIN;
        private System.Windows.Forms.MaskedTextBox tbGTIN;
        private System.Windows.Forms.ComboBox cboInnerUnit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox tbGMID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox tbDetails;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox tbCustomer;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCreateSalesOrder;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.MaskedTextBox tbNotes;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MaskedTextBox tbInnerPackStyle;
        private System.Windows.Forms.Label lblInnerGTIN;
        private System.Windows.Forms.MaskedTextBox tbInnerGTIN;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblDoM;
        private System.Windows.Forms.DateTimePicker dtpDateOfManufacture;
        private System.Windows.Forms.GroupBox grpEditButtons;
        private System.Windows.Forms.GroupBox grpButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox tbLotNumber;
    }
}

