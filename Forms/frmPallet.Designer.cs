namespace ITS.Exwold.Desktop
{
    partial class frmPallet
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
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.button_add = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbProdCode = new System.Windows.Forms.MaskedTextBox();
            this.buttonEnableStatus = new System.Windows.Forms.Button();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.palletBatchStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.tbInnerPackStyle = new System.Windows.Forms.MaskedTextBox();
            this.tbClientCode = new System.Windows.Forms.MaskedTextBox();
            this.tbCompanyCode = new System.Windows.Forms.MaskedTextBox();
            this.tbGTIN = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TextBoxPalletBatchNo = new System.Windows.Forms.MaskedTextBox();
            this.tbGMID = new System.Windows.Forms.MaskedTextBox();
            this.tbDetails = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
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
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSetStatus = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.exwoldTrackingDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palletBatchStatusBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exwoldTrackingDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(0, 0);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.ShowCellErrors = false;
            this.dgvOrders.ShowCellToolTips = false;
            this.dgvOrders.ShowEditingIcon = false;
            this.dgvOrders.ShowRowErrors = false;
            this.dgvOrders.Size = new System.Drawing.Size(1500, 400);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.TabStop = false;
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(0, 0);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(99, 32);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // button_edit
            // 
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
            this.panel1.Controls.Add(this.tbProdCode);
            this.panel1.Controls.Add(this.buttonEnableStatus);
            this.panel1.Controls.Add(this.cboStatus);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.tbInnerPackStyle);
            this.panel1.Controls.Add(this.tbClientCode);
            this.panel1.Controls.Add(this.tbCompanyCode);
            this.panel1.Controls.Add(this.tbGTIN);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.TextBoxPalletBatchNo);
            this.panel1.Controls.Add(this.tbGMID);
            this.panel1.Controls.Add(this.tbDetails);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tbCustomer);
            this.panel1.Controls.Add(this.cboProdLine);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbNotes);
            this.panel1.Controls.Add(this.cboInnerUnit);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbInnerWeight);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbInnersPerCart);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbCartonsPerPallet);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbTotalCartons);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbProdName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Controls.Add(this.button_save);
            this.panel1.Location = new System.Drawing.Point(96, 500);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1308, 267);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
            // 
            // TextBoxProdCode
            // 
            this.tbProdCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProdCode.Location = new System.Drawing.Point(133, 75);
            this.tbProdCode.Name = "TextBoxProdCode";
            this.tbProdCode.ReadOnly = true;
            this.tbProdCode.Size = new System.Drawing.Size(155, 23);
            this.tbProdCode.TabIndex = 50;
            // 
            // buttonEnableStatus
            // 
            this.buttonEnableStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEnableStatus.Location = new System.Drawing.Point(1103, 155);
            this.buttonEnableStatus.Name = "buttonEnableStatus";
            this.buttonEnableStatus.Size = new System.Drawing.Size(110, 25);
            this.buttonEnableStatus.TabIndex = 49;
            this.buttonEnableStatus.Text = "Change Status";
            this.buttonEnableStatus.UseVisualStyleBackColor = true;
            this.buttonEnableStatus.Click += new System.EventHandler(this.buttonEnableStatus_Click);
            // 
            // comboBoxStatus
            // 
            this.cboStatus.DataSource = this.palletBatchStatusBindingSource;
            this.cboStatus.DisplayMember = "Status";
            this.cboStatus.Enabled = false;
            this.cboStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(1103, 128);
            this.cboStatus.Name = "comboBoxStatus";
            this.cboStatus.Size = new System.Drawing.Size(146, 24);
            this.cboStatus.TabIndex = 48;
            this.cboStatus.ValueMember = "StatusNo";
            // 
            // labelStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(960, 128);
            this.lblStatus.Name = "labelStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 17);
            this.lblStatus.TabIndex = 47;
            this.lblStatus.Text = "Status";
            // 
            // TextBoxInnerPackStyle
            // 
            this.tbInnerPackStyle.Location = new System.Drawing.Point(87, 242);
            this.tbInnerPackStyle.Name = "TextBoxInnerPackStyle";
            this.tbInnerPackStyle.Size = new System.Drawing.Size(27, 20);
            this.tbInnerPackStyle.TabIndex = 46;
            this.tbInnerPackStyle.Visible = false;
            // 
            // TextBoxClientCode
            // 
            this.tbClientCode.Location = new System.Drawing.Point(54, 242);
            this.tbClientCode.Name = "TextBoxClientCode";
            this.tbClientCode.Size = new System.Drawing.Size(27, 20);
            this.tbClientCode.TabIndex = 45;
            this.tbClientCode.Visible = false;
            // 
            // TextBoxCompanyCode
            // 
            this.tbCompanyCode.Location = new System.Drawing.Point(54, 216);
            this.tbCompanyCode.Name = "TextBoxCompanyCode";
            this.tbCompanyCode.Size = new System.Drawing.Size(27, 20);
            this.tbCompanyCode.TabIndex = 44;
            this.tbCompanyCode.Visible = false;
            // 
            // TextBoxGTIN
            // 
            this.tbGTIN.Location = new System.Drawing.Point(87, 216);
            this.tbGTIN.Name = "TextBoxGTIN";
            this.tbGTIN.Size = new System.Drawing.Size(27, 20);
            this.tbGTIN.TabIndex = 43;
            this.tbGTIN.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(960, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 17);
            this.label9.TabIndex = 42;
            this.label9.Text = "Sales Order Number";
            // 
            // TextBoxPalletBatchNo
            // 
            this.TextBoxPalletBatchNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxPalletBatchNo.Location = new System.Drawing.Point(1103, 75);
            this.TextBoxPalletBatchNo.Name = "TextBoxPalletBatchNo";
            this.TextBoxPalletBatchNo.Size = new System.Drawing.Size(172, 23);
            this.TextBoxPalletBatchNo.TabIndex = 41;
            // 
            // TextBoxGMID
            // 
            this.tbGMID.Location = new System.Drawing.Point(21, 242);
            this.tbGMID.Name = "TextBoxGMID";
            this.tbGMID.Size = new System.Drawing.Size(27, 20);
            this.tbGMID.TabIndex = 40;
            this.tbGMID.Visible = false;
            // 
            // TextBoxDetails
            // 
            this.tbDetails.Location = new System.Drawing.Point(21, 216);
            this.tbDetails.Name = "TextBoxDetails";
            this.tbDetails.Size = new System.Drawing.Size(27, 20);
            this.tbDetails.TabIndex = 39;
            this.tbDetails.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 17);
            this.label8.TabIndex = 37;
            this.label8.Text = "Customer Name";
            // 
            // TextBoxCustomer
            // 
            this.tbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomer.Location = new System.Drawing.Point(133, 128);
            this.tbCustomer.Name = "TextBoxCustomer";
            this.tbCustomer.ReadOnly = true;
            this.tbCustomer.Size = new System.Drawing.Size(155, 23);
            this.tbCustomer.TabIndex = 36;
            // 
            // comboBoxProdLine
            // 
            this.cboProdLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProdLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProdLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProdLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProdLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProdLine.FormattingEnabled = true;
            this.cboProdLine.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cboProdLine.Location = new System.Drawing.Point(1103, 101);
            this.cboProdLine.Name = "comboBoxProdLine";
            this.cboProdLine.Size = new System.Drawing.Size(43, 24);
            this.cboProdLine.TabIndex = 35;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(490, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(131, 17);
            this.label14.TabIndex = 34;
            this.label14.Text = "Sales Order Details";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(18, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(300, 17);
            this.label13.TabIndex = 33;
            this.label13.Text = "Product Details (cannot be changed for batch)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(18, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 17);
            this.label10.TabIndex = 28;
            this.label10.Text = "Product Code";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(490, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Notes";
            // 
            // TextBoxNotes
            // 
            this.tbNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotes.Location = new System.Drawing.Point(633, 179);
            this.tbNotes.Name = "TextBoxNotes";
            this.tbNotes.Size = new System.Drawing.Size(261, 23);
            this.tbNotes.TabIndex = 21;
            // 
            // comboBoxInnerUnit
            // 
            this.cboInnerUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboInnerUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboInnerUnit.BackColor = System.Drawing.SystemColors.Window;
            this.cboInnerUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInnerUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboInnerUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInnerUnit.FormattingEnabled = true;
            this.cboInnerUnit.Items.AddRange(new object[] {
            "Kg",
            "L"});
            this.cboInnerUnit.Location = new System.Drawing.Point(811, 152);
            this.cboInnerUnit.Name = "comboBoxInnerUnit";
            this.cboInnerUnit.Size = new System.Drawing.Size(43, 24);
            this.cboInnerUnit.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(490, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Inner weight/volume";
            // 
            // TextBoxInnerWeight
            // 
            this.tbInnerWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnerWeight.Location = new System.Drawing.Point(633, 153);
            this.tbInnerWeight.Name = "TextBoxInnerWeight";
            this.tbInnerWeight.Size = new System.Drawing.Size(172, 23);
            this.tbInnerWeight.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(490, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Inners per Carton";
            // 
            // TextBoxInnersPerCart
            // 
            this.tbInnersPerCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnersPerCart.Location = new System.Drawing.Point(633, 127);
            this.tbInnersPerCart.Name = "TextBoxInnersPerCart";
            this.tbInnersPerCart.Size = new System.Drawing.Size(172, 23);
            this.tbInnersPerCart.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(490, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Cartons per Pallet";
            // 
            // TextBoxCartsPerPallet
            // 
            this.tbCartonsPerPallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCartonsPerPallet.Location = new System.Drawing.Point(633, 101);
            this.tbCartonsPerPallet.Name = "TextBoxCartsPerPallet";
            this.tbCartonsPerPallet.Size = new System.Drawing.Size(172, 23);
            this.tbCartonsPerPallet.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(490, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Number of Cartons";
            // 
            // TextBoxTotalCartons
            // 
            this.tbTotalCartons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalCartons.Location = new System.Drawing.Point(633, 75);
            this.tbTotalCartons.Name = "TextBoxTotalCartons";
            this.tbTotalCartons.Size = new System.Drawing.Size(172, 23);
            this.tbTotalCartons.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Product Name";
            // 
            // TextBoxProdName
            // 
            this.tbProdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProdName.Location = new System.Drawing.Point(133, 102);
            this.tbProdName.Name = "TextBoxProdName";
            this.tbProdName.ReadOnly = true;
            this.tbProdName.Size = new System.Drawing.Size(155, 23);
            this.tbProdName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(960, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Production Line";
            // 
            // button_cancel
            // 
            this.button_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.Location = new System.Drawing.Point(1190, 226);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(99, 32);
            this.button_cancel.TabIndex = 5;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_save
            // 
            this.button_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.Location = new System.Drawing.Point(1085, 226);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(99, 32);
            this.button_save.TabIndex = 4;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.btnSave_Click);
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
            this.label15.Size = new System.Drawing.Size(143, 20);
            this.label15.TabIndex = 7;
            this.label15.Text = "Sales Order details";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(210, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(99, 32);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSetStatus
            // 
            this.buttonSetStatus.Location = new System.Drawing.Point(870, 0);
            this.buttonSetStatus.Name = "buttonSetStatus";
            this.buttonSetStatus.Size = new System.Drawing.Size(217, 32);
            this.buttonSetStatus.TabIndex = 12;
            this.buttonSetStatus.Text = "View details for this Sales Order";
            this.buttonSetStatus.UseVisualStyleBackColor = true;
            this.buttonSetStatus.Click += new System.EventHandler(this.buttonSetStatus_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.dgvOrders);
            this.panel2.Location = new System.Drawing.Point(0, 175);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1500, 800);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonSetStatus);
            this.panel3.Controls.Add(this.buttonDelete);
            this.panel3.Controls.Add(this.button_edit);
            this.panel3.Controls.Add(this.button_add);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(206, 415);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1088, 33);
            this.panel3.TabIndex = 13;
            // 
            // PalletForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 961);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button_close);
            this.Name = "PalletForm";
            this.Text = "EXWOLD PALLET TRACKING";
            this.Load += new System.EventHandler(this.PalletDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palletBatchStatusBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exwoldTrackingDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_close;
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
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ComboBox cboProdLine;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox tbCustomer;
        private System.Windows.Forms.MaskedTextBox tbGMID;
        private System.Windows.Forms.MaskedTextBox tbDetails;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox TextBoxPalletBatchNo;
        private System.Windows.Forms.MaskedTextBox tbClientCode;
        private System.Windows.Forms.MaskedTextBox tbCompanyCode;
        private System.Windows.Forms.MaskedTextBox tbGTIN;
        private System.Windows.Forms.MaskedTextBox tbInnerPackStyle;
        private System.Windows.Forms.Button buttonSetStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button buttonEnableStatus;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.MaskedTextBox tbProdCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingSource exwoldTrackingDataSetBindingSource;
        private System.Windows.Forms.BindingSource palletBatchStatusBindingSource;
    }
}

