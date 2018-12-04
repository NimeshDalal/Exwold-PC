namespace ExwoldPcInterface
{
    partial class ProductForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_add = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.TextBoxInnerPackStyle = new System.Windows.Forms.MaskedTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.TextBoxNotes = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TextBoxGMID = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TextBoxDetails = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TextBoxCustomer = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TextBoxClientCode = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TextBoxCompanyCode = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TextBoxGTIN = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxInnerUnit = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBoxInnerWeight = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBoxInnersPerCart = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxCartsPerPallet = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxDefaultCartons = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxProdName = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxProdCode = new System.Windows.Forms.MaskedTextBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.dataSet1 = new ExwoldPcInterface.DataSet1();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(1500, 400);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
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
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.TextBoxInnerPackStyle);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.TextBoxNotes);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.TextBoxGMID);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.TextBoxDetails);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.TextBoxCustomer);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.TextBoxClientCode);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.TextBoxCompanyCode);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.TextBoxGTIN);
            this.panel1.Controls.Add(this.comboBoxInnerUnit);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.TextBoxInnerWeight);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TextBoxInnersPerCart);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TextBoxCartsPerPallet);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TextBoxDefaultCartons);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TextBoxProdName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TextBoxProdCode);
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Controls.Add(this.button_save);
            this.panel1.Location = new System.Drawing.Point(96, 500);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1308, 267);
            this.panel1.TabIndex = 3;
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
            this.TextBoxInnerPackStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxInnerPackStyle.Location = new System.Drawing.Point(610, 214);
            this.TextBoxInnerPackStyle.Name = "TextBoxInnerPackStyle";
            this.TextBoxInnerPackStyle.Size = new System.Drawing.Size(172, 23);
            this.TextBoxInnerPackStyle.TabIndex = 37;
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
            this.TextBoxNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxNotes.Location = new System.Drawing.Point(1132, 136);
            this.TextBoxNotes.Name = "TextBoxNotes";
            this.TextBoxNotes.Size = new System.Drawing.Size(133, 23);
            this.TextBoxNotes.TabIndex = 35;
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
            this.TextBoxGMID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxGMID.Location = new System.Drawing.Point(138, 110);
            this.TextBoxGMID.Name = "TextBoxGMID";
            this.TextBoxGMID.Size = new System.Drawing.Size(192, 23);
            this.TextBoxGMID.TabIndex = 31;
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
            this.TextBoxDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDetails.Location = new System.Drawing.Point(138, 84);
            this.TextBoxDetails.Name = "TextBoxDetails";
            this.TextBoxDetails.Size = new System.Drawing.Size(192, 23);
            this.TextBoxDetails.TabIndex = 29;
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
            this.TextBoxCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCustomer.Location = new System.Drawing.Point(138, 58);
            this.TextBoxCustomer.Name = "TextBoxCustomer";
            this.TextBoxCustomer.Size = new System.Drawing.Size(192, 23);
            this.TextBoxCustomer.TabIndex = 27;
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
            this.TextBoxClientCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxClientCode.Location = new System.Drawing.Point(1132, 110);
            this.TextBoxClientCode.Name = "TextBoxClientCode";
            this.TextBoxClientCode.Size = new System.Drawing.Size(133, 23);
            this.TextBoxClientCode.TabIndex = 25;
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
            this.TextBoxCompanyCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCompanyCode.Location = new System.Drawing.Point(1132, 84);
            this.TextBoxCompanyCode.Name = "TextBoxCompanyCode";
            this.TextBoxCompanyCode.Size = new System.Drawing.Size(133, 23);
            this.TextBoxCompanyCode.TabIndex = 23;
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
            this.TextBoxGTIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxGTIN.Location = new System.Drawing.Point(1132, 58);
            this.TextBoxGTIN.Mask = "00000000000000";
            this.TextBoxGTIN.Name = "TextBoxGTIN";
            this.TextBoxGTIN.Size = new System.Drawing.Size(133, 23);
            this.TextBoxGTIN.TabIndex = 21;
            // 
            // comboBoxInnerUnit
            // 
            this.comboBoxInnerUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxInnerUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxInnerUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInnerUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxInnerUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxInnerUnit.FormattingEnabled = true;
            this.comboBoxInnerUnit.Items.AddRange(new object[] {
            "Kg",
            "L"});
            this.comboBoxInnerUnit.Location = new System.Drawing.Point(788, 187);
            this.comboBoxInnerUnit.Name = "comboBoxInnerUnit";
            this.comboBoxInnerUnit.Size = new System.Drawing.Size(43, 24);
            this.comboBoxInnerUnit.TabIndex = 20;
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
            this.TextBoxInnerWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxInnerWeight.Location = new System.Drawing.Point(610, 188);
            this.TextBoxInnerWeight.Name = "TextBoxInnerWeight";
            this.TextBoxInnerWeight.Size = new System.Drawing.Size(172, 23);
            this.TextBoxInnerWeight.TabIndex = 16;
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
            this.TextBoxInnersPerCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxInnersPerCart.Location = new System.Drawing.Point(610, 162);
            this.TextBoxInnersPerCart.Name = "TextBoxInnersPerCart";
            this.TextBoxInnersPerCart.Size = new System.Drawing.Size(172, 23);
            this.TextBoxInnersPerCart.TabIndex = 14;
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
            this.TextBoxCartsPerPallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCartsPerPallet.Location = new System.Drawing.Point(610, 136);
            this.TextBoxCartsPerPallet.Name = "TextBoxCartsPerPallet";
            this.TextBoxCartsPerPallet.Size = new System.Drawing.Size(172, 23);
            this.TextBoxCartsPerPallet.TabIndex = 12;
            this.TextBoxCartsPerPallet.Text = "0";
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
            this.TextBoxDefaultCartons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxDefaultCartons.Location = new System.Drawing.Point(610, 110);
            this.TextBoxDefaultCartons.Name = "TextBoxDefaultCartons";
            this.TextBoxDefaultCartons.Size = new System.Drawing.Size(172, 23);
            this.TextBoxDefaultCartons.TabIndex = 10;
            this.TextBoxDefaultCartons.Text = "0";
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
            this.TextBoxProdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxProdName.Location = new System.Drawing.Point(610, 84);
            this.TextBoxProdName.Name = "TextBoxProdName";
            this.TextBoxProdName.Size = new System.Drawing.Size(172, 23);
            this.TextBoxProdName.TabIndex = 8;
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
            this.TextBoxProdCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxProdCode.Location = new System.Drawing.Point(610, 58);
            this.TextBoxProdCode.Name = "TextBoxProdCode";
            this.TextBoxProdCode.Size = new System.Drawing.Size(172, 23);
            this.TextBoxProdCode.TabIndex = 6;
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
            this.button_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.Location = new System.Drawing.Point(1004, 226);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(99, 32);
            this.button_save.TabIndex = 4;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
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
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click_1);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.dataGridView1);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox TextBoxProdCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox TextBoxProdName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox TextBoxCartsPerPallet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox TextBoxDefaultCartons;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox TextBoxInnersPerCart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox TextBoxInnerWeight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox TextBoxClientCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox TextBoxCompanyCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox TextBoxGTIN;
        private System.Windows.Forms.ComboBox comboBoxInnerUnit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox TextBoxGMID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox TextBoxDetails;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox TextBoxCustomer;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private ExwoldPcInterface.DataSet1 dataSet1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.MaskedTextBox TextBoxNotes;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MaskedTextBox TextBoxInnerPackStyle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}

