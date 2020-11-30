namespace ITS.Exwold.Desktop
{
    partial class frmSalesOrderDetails
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
            this.buttonEnableStatus = new System.Windows.Forms.Button();
            this.cboStatus = new System.Windows.Forms.ComboBox();
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
            this.btnSave = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.buttonSetStatus = new System.Windows.Forms.Button();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.tbInnerGTIN = new System.Windows.Forms.MaskedTextBox();
            this.tbPlant = new System.Windows.Forms.MaskedTextBox();
            this.tbDateOfManufacture = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.pnlTextBoxes.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(3, 0);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.ShowCellErrors = false;
            this.dgvOrders.ShowCellToolTips = false;
            this.dgvOrders.ShowEditingIcon = false;
            this.dgvOrders.ShowRowErrors = false;
            this.dgvOrders.Size = new System.Drawing.Size(1469, 400);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(99, 32);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(105, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(99, 32);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // pnlTextBoxes
            // 
            this.pnlTextBoxes.Controls.Add(this.tbProdCode);
            this.pnlTextBoxes.Controls.Add(this.buttonEnableStatus);
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
            this.pnlTextBoxes.Controls.Add(this.TextBoxPalletBatchNo);
            this.pnlTextBoxes.Controls.Add(this.tbGMID);
            this.pnlTextBoxes.Controls.Add(this.tbDetails);
            this.pnlTextBoxes.Controls.Add(this.label8);
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
            this.pnlTextBoxes.Controls.Add(this.button_cancel);
            this.pnlTextBoxes.Controls.Add(this.btnSave);
            this.pnlTextBoxes.Location = new System.Drawing.Point(96, 500);
            this.pnlTextBoxes.Name = "pnlTextBoxes";
            this.pnlTextBoxes.Size = new System.Drawing.Size(1308, 264);
            this.pnlTextBoxes.TabIndex = 3;
            this.pnlTextBoxes.Visible = false;
            // 
            // tbProdCode
            // 
            this.tbProdCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProdCode.Location = new System.Drawing.Point(133, 75);
            this.tbProdCode.Name = "tbProdCode";
            this.tbProdCode.ReadOnly = true;
            this.tbProdCode.Size = new System.Drawing.Size(155, 23);
            this.tbProdCode.TabIndex = 50;
            // 
            // buttonEnableStatus
            // 
            this.buttonEnableStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEnableStatus.Location = new System.Drawing.Point(1103, 155);
            this.buttonEnableStatus.Name = "buttonEnableStatus";
            this.buttonEnableStatus.Size = new System.Drawing.Size(172, 25);
            this.buttonEnableStatus.TabIndex = 49;
            this.buttonEnableStatus.Text = "Change Status";
            this.buttonEnableStatus.UseVisualStyleBackColor = true;
            this.buttonEnableStatus.Click += new System.EventHandler(this.btnEnableStatus_Click);
            // 
            // cboStatus
            // 
            this.cboStatus.Enabled = false;
            this.cboStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(1103, 128);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(172, 24);
            this.cboStatus.TabIndex = 48;
            this.cboStatus.ValueMember = "StatusNo";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(960, 128);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 17);
            this.lblStatus.TabIndex = 47;
            this.lblStatus.Text = "Status";
            // 
            // tbInnerPackStyle
            // 
            this.tbInnerPackStyle.Location = new System.Drawing.Point(87, 242);
            this.tbInnerPackStyle.Name = "tbInnerPackStyle";
            this.tbInnerPackStyle.Size = new System.Drawing.Size(27, 20);
            this.tbInnerPackStyle.TabIndex = 46;
            this.tbInnerPackStyle.Visible = false;
            // 
            // tbClientCode
            // 
            this.tbClientCode.Location = new System.Drawing.Point(54, 242);
            this.tbClientCode.Name = "tbClientCode";
            this.tbClientCode.Size = new System.Drawing.Size(27, 20);
            this.tbClientCode.TabIndex = 45;
            this.tbClientCode.Visible = false;
            // 
            // tbCompanyCode
            // 
            this.tbCompanyCode.Location = new System.Drawing.Point(54, 216);
            this.tbCompanyCode.Name = "tbCompanyCode";
            this.tbCompanyCode.Size = new System.Drawing.Size(27, 20);
            this.tbCompanyCode.TabIndex = 44;
            this.tbCompanyCode.Visible = false;
            // 
            // tbGTIN
            // 
            this.tbGTIN.Location = new System.Drawing.Point(87, 216);
            this.tbGTIN.Name = "tbGTIN";
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
            // tbGMID
            // 
            this.tbGMID.Location = new System.Drawing.Point(21, 242);
            this.tbGMID.Name = "tbGMID";
            this.tbGMID.Size = new System.Drawing.Size(27, 20);
            this.tbGMID.TabIndex = 40;
            this.tbGMID.Visible = false;
            // 
            // tbDetails
            // 
            this.tbDetails.Location = new System.Drawing.Point(21, 216);
            this.tbDetails.Name = "tbDetails";
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
            // tbCustomer
            // 
            this.tbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomer.Location = new System.Drawing.Point(133, 128);
            this.tbCustomer.Name = "tbCustomer";
            this.tbCustomer.ReadOnly = true;
            this.tbCustomer.Size = new System.Drawing.Size(155, 23);
            this.tbCustomer.TabIndex = 36;
            // 
            // cboProdLine
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
            this.cboProdLine.Name = "cboProdLine";
            this.cboProdLine.Size = new System.Drawing.Size(172, 24);
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
            // tbNotes
            // 
            this.tbNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotes.Location = new System.Drawing.Point(633, 179);
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(261, 23);
            this.tbNotes.TabIndex = 21;
            // 
            // cboInnerUnit
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
            this.cboInnerUnit.Name = "cboInnerUnit";
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
            // tbInnerWeight
            // 
            this.tbInnerWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnerWeight.Location = new System.Drawing.Point(633, 153);
            this.tbInnerWeight.Name = "tbInnerWeight";
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
            // tbInnersPerCart
            // 
            this.tbInnersPerCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInnersPerCart.Location = new System.Drawing.Point(633, 127);
            this.tbInnersPerCart.Name = "tbInnersPerCart";
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
            // tbCartonsPerPallet
            // 
            this.tbCartonsPerPallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCartonsPerPallet.Location = new System.Drawing.Point(633, 101);
            this.tbCartonsPerPallet.Name = "tbCartonsPerPallet";
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
            // tbTotalCartons
            // 
            this.tbTotalCartons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalCartons.Location = new System.Drawing.Point(633, 75);
            this.tbTotalCartons.Name = "tbTotalCartons";
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
            // tbProdName
            // 
            this.tbProdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProdName.Location = new System.Drawing.Point(133, 102);
            this.tbProdName.Name = "tbProdName";
            this.tbProdName.ReadOnly = true;
            this.tbProdName.Size = new System.Drawing.Size(325, 23);
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
            this.button_cancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button_save
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1085, 226);
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
            this.button_close.Click += new System.EventHandler(this.btnClose_Click);
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
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(210, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 32);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // buttonSetStatus
            // 
            this.buttonSetStatus.Location = new System.Drawing.Point(870, 0);
            this.buttonSetStatus.Name = "buttonSetStatus";
            this.buttonSetStatus.Size = new System.Drawing.Size(217, 32);
            this.buttonSetStatus.TabIndex = 12;
            this.buttonSetStatus.Text = "View details for this Sales Order";
            this.buttonSetStatus.UseVisualStyleBackColor = true;
            this.buttonSetStatus.Click += new System.EventHandler(this.btnSetStatus_Click);
            // 
            // pnlForm
            // 
            this.pnlForm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlForm.Controls.Add(this.pnlButtons);
            this.pnlForm.Controls.Add(this.pnlTextBoxes);
            this.pnlForm.Controls.Add(this.dgvOrders);
            this.pnlForm.Location = new System.Drawing.Point(0, 175);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(1472, 764);
            this.pnlForm.TabIndex = 13;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.buttonSetStatus);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlButtons.Location = new System.Drawing.Point(206, 415);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1088, 33);
            this.pnlButtons.TabIndex = 13;
            // 
            // tbInnerGTIN
            // 
            this.tbInnerGTIN.Location = new System.Drawing.Point(120, 216);
            this.tbInnerGTIN.Name = "tbInnerGTIN";
            this.tbInnerGTIN.Size = new System.Drawing.Size(27, 20);
            this.tbInnerGTIN.TabIndex = 43;
            this.tbInnerGTIN.Visible = false;
            // 
            // tbPlant
            // 
            this.tbPlant.Location = new System.Drawing.Point(21, 190);
            this.tbPlant.Name = "tbPlant";
            this.tbPlant.Size = new System.Drawing.Size(27, 20);
            this.tbPlant.TabIndex = 43;
            this.tbPlant.Visible = false;
            // 
            // tbDateOfManufacture
            // 
            this.tbDateOfManufacture.Location = new System.Drawing.Point(120, 242);
            this.tbDateOfManufacture.Name = "tbDateOfManufacture";
            this.tbDateOfManufacture.Size = new System.Drawing.Size(27, 20);
            this.tbDateOfManufacture.TabIndex = 43;
            this.tbDateOfManufacture.Visible = false;
            // 
            // frmSalesOrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 961);
            this.ControlBox = false;
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button_close);
            this.Name = "frmSalesOrderDetails";
            this.Text = "EXWOLD PALLET TRACKING";
            this.Load += new System.EventHandler(this.PalletDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.pnlTextBoxes.ResumeLayout(false);
            this.pnlTextBoxes.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel pnlTextBoxes;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button btnSave;
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
        private System.Windows.Forms.Button btnDelete;
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
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.MaskedTextBox tbPlant;
        private System.Windows.Forms.MaskedTextBox tbDateOfManufacture;
        private System.Windows.Forms.MaskedTextBox tbInnerGTIN;
    }
}

