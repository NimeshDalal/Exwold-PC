namespace ITS.Exwold.Desktop
{
    partial class frmProduct
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
            this.button_add = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.pnlProductDetails = new System.Windows.Forms.Panel();
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
            this.label7 = new System.Windows.Forms.Label();
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
            this.button_cancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllProducts)).BeginInit();
            this.pnlProductDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dgvAllProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllProducts.Location = new System.Drawing.Point(0, 0);
            this.dgvAllProducts.MultiSelect = false;
            this.dgvAllProducts.Name = "dataGridView1";
            this.dgvAllProducts.ReadOnly = true;
            this.dgvAllProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllProducts.ShowCellErrors = false;
            this.dgvAllProducts.ShowCellToolTips = false;
            this.dgvAllProducts.ShowEditingIcon = false;
            this.dgvAllProducts.ShowRowErrors = false;
            this.dgvAllProducts.Size = new System.Drawing.Size(1500, 400);
            this.dgvAllProducts.TabIndex = 0;
            this.dgvAllProducts.TabStop = false;
            // 
            // button_add
            // 
            this.button_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_add.Location = new System.Drawing.Point(0, 0);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(99, 32);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_edit
            // 
            this.button_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_edit.Location = new System.Drawing.Point(105, 0);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(99, 32);
            this.button_edit.TabIndex = 2;
            this.button_edit.Text = "Edit";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // panel1
            // 
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
            this.pnlProductDetails.Controls.Add(this.label7);
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
            this.pnlProductDetails.Controls.Add(this.button_cancel);
            this.pnlProductDetails.Controls.Add(this.btnSave);
            this.pnlProductDetails.Location = new System.Drawing.Point(96, 500);
            this.pnlProductDetails.Name = "panel1";
            this.pnlProductDetails.Size = new System.Drawing.Size(1308, 267);
            this.pnlProductDetails.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(471, 214);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(110, 17);
            this.label18.TabIndex = 38;
            this.label18.Text = "Inner Pack Style";
            // 
            // TextBoxInnerPackStyle
            // 
            this.tbInnerPackStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnerPackStyle.Location = new System.Drawing.Point(610, 214);
            this.tbInnerPackStyle.Name = "TextBoxInnerPackStyle";
            this.tbInnerPackStyle.Size = new System.Drawing.Size(172, 23);
            this.tbInnerPackStyle.TabIndex = 37;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(945, 136);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 17);
            this.label17.TabIndex = 36;
            this.label17.Text = "Notes";
            // 
            // TextBoxNotes
            // 
            this.tbNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotes.Location = new System.Drawing.Point(1132, 136);
            this.tbNotes.Name = "TextBoxNotes";
            this.tbNotes.Size = new System.Drawing.Size(133, 23);
            this.tbNotes.TabIndex = 35;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(471, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 17);
            this.label14.TabIndex = 34;
            this.label14.Text = "Product Details";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(52, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 17);
            this.label13.TabIndex = 33;
            this.label13.Text = "Customer Details";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(52, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 17);
            this.label12.TabIndex = 32;
            this.label12.Text = "GMID";
            // 
            // TextBoxGMID
            // 
            this.tbGMID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGMID.Location = new System.Drawing.Point(138, 110);
            this.tbGMID.Name = "TextBoxGMID";
            this.tbGMID.Size = new System.Drawing.Size(192, 23);
            this.tbGMID.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(52, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 17);
            this.label11.TabIndex = 30;
            this.label11.Text = "Details";
            // 
            // TextBoxDetails
            // 
            this.tbDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDetails.Location = new System.Drawing.Point(138, 84);
            this.tbDetails.Name = "TextBoxDetails";
            this.tbDetails.Size = new System.Drawing.Size(192, 23);
            this.tbDetails.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(52, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 17);
            this.label10.TabIndex = 28;
            this.label10.Text = "Customer";
            // 
            // TextBoxCustomer
            // 
            this.tbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomer.Location = new System.Drawing.Point(138, 58);
            this.tbCustomer.Name = "TextBoxCustomer";
            this.tbCustomer.Size = new System.Drawing.Size(192, 23);
            this.tbCustomer.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(945, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(166, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "SSCC PL Customer Code";
            // 
            // TextBoxClientCode
            // 
            this.tbClientCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbClientCode.Location = new System.Drawing.Point(1132, 110);
            this.tbClientCode.Name = "TextBoxClientCode";
            this.tbClientCode.Size = new System.Drawing.Size(133, 23);
            this.tbClientCode.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(945, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "SSCC Company Code";
            // 
            // TextBoxCompanyCode
            // 
            this.tbCompanyCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCompanyCode.Location = new System.Drawing.Point(1132, 84);
            this.tbCompanyCode.Name = "TextBoxCompanyCode";
            this.tbCompanyCode.Size = new System.Drawing.Size(133, 23);
            this.tbCompanyCode.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(945, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "GTIN";
            // 
            // TextBoxGTIN
            // 
            this.tbGTIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGTIN.Location = new System.Drawing.Point(1132, 58);
            this.tbGTIN.Mask = "00000000000000";
            this.tbGTIN.Name = "TextBoxGTIN";
            this.tbGTIN.Size = new System.Drawing.Size(133, 23);
            this.tbGTIN.TabIndex = 21;
            // 
            // comboBoxInnerUnit
            // 
            this.cboInnerUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboInnerUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboInnerUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInnerUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboInnerUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInnerUnit.FormattingEnabled = true;
            this.cboInnerUnit.Items.AddRange(new object[] {
            "Kg",
            "L"});
            this.cboInnerUnit.Location = new System.Drawing.Point(788, 187);
            this.cboInnerUnit.Name = "comboBoxInnerUnit";
            this.cboInnerUnit.Size = new System.Drawing.Size(43, 24);
            this.cboInnerUnit.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(471, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Inner weight/volume";
            // 
            // TextBoxInnerWeight
            // 
            this.tbInnerWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnerWeight.Location = new System.Drawing.Point(610, 188);
            this.tbInnerWeight.Name = "TextBoxInnerWeight";
            this.tbInnerWeight.Size = new System.Drawing.Size(172, 23);
            this.tbInnerWeight.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(471, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Inners per Carton";
            // 
            // TextBoxInnersPerCart
            // 
            this.tbInnersPerCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnersPerCart.Location = new System.Drawing.Point(610, 162);
            this.tbInnersPerCart.Name = "TextBoxInnersPerCart";
            this.tbInnersPerCart.Size = new System.Drawing.Size(172, 23);
            this.tbInnersPerCart.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(471, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Cartons per Pallet";
            // 
            // TextBoxCartsPerPallet
            // 
            this.tbCartsPerPallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCartsPerPallet.Location = new System.Drawing.Point(610, 136);
            this.tbCartsPerPallet.Name = "TextBoxCartsPerPallet";
            this.tbCartsPerPallet.Size = new System.Drawing.Size(172, 23);
            this.tbCartsPerPallet.TabIndex = 12;
            this.tbCartsPerPallet.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(471, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Default no. Cartons";
            // 
            // TextBoxDefaultCartons
            // 
            this.tbDefaultCartons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDefaultCartons.Location = new System.Drawing.Point(610, 110);
            this.tbDefaultCartons.Name = "TextBoxDefaultCartons";
            this.tbDefaultCartons.Size = new System.Drawing.Size(172, 23);
            this.tbDefaultCartons.TabIndex = 10;
            this.tbDefaultCartons.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(471, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Prod Name";
            // 
            // TextBoxProdName
            // 
            this.tbProdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProdName.Location = new System.Drawing.Point(610, 84);
            this.tbProdName.Name = "TextBoxProdName";
            this.tbProdName.Size = new System.Drawing.Size(172, 23);
            this.tbProdName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(471, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Prod Code";
            // 
            // TextBoxProdCode
            // 
            this.tbProdCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProdCode.Location = new System.Drawing.Point(610, 58);
            this.tbProdCode.Name = "TextBoxProdCode";
            this.tbProdCode.Size = new System.Drawing.Size(172, 23);
            this.tbProdCode.TabIndex = 6;
            // 
            // button_cancel
            // 
            this.button_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.Location = new System.Drawing.Point(1109, 226);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(99, 32);
            this.button_cancel.TabIndex = 5;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_save
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1004, 226);
            this.btnSave.Name = "button_save";
            this.btnSave.Size = new System.Drawing.Size(99, 32);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button_close
            // 
            this.button_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_close.Location = new System.Drawing.Point(1342, 15);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(130, 25);
            this.button_close.TabIndex = 6;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(31, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(195, 20);
            this.label15.TabIndex = 7;
            this.label15.Text = "Customer / Product details";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(851, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 32);
            this.button1.TabIndex = 9;
            this.button1.Text = "Create Sales Order for this product";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(210, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(99, 32);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pnlProductDetails);
            this.panel2.Controls.Add(this.dgvAllProducts);
            this.panel2.Location = new System.Drawing.Point(0, 175);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1500, 800);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonDelete);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button_edit);
            this.panel3.Controls.Add(this.button_add);
            this.panel3.Location = new System.Drawing.Point(206, 415);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1088, 60);
            this.panel3.TabIndex = 11;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 961);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button_close);
            this.Name = "ProductForm";
            this.Text = "EXWOLD PALLET TRACKING";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllProducts)).EndInit();
            this.pnlProductDetails.ResumeLayout(false);
            this.pnlProductDetails.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAllProducts;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Panel pnlProductDetails;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button_close;
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
        private System.Windows.Forms.Label label7;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.MaskedTextBox tbNotes;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MaskedTextBox tbInnerPackStyle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}

