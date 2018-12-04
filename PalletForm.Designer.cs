namespace ExwoldPcInterface
{
    partial class PalletForm
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
            this.TextBoxProdCode = new System.Windows.Forms.MaskedTextBox();
            this.buttonEnableStatus = new System.Windows.Forms.Button();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.palletBatchStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.exwoldTrackingDataSet5 = new ExwoldPcInterface.ExwoldTrackingDataSet5();
            this.labelStatus = new System.Windows.Forms.Label();
            this.TextBoxInnerPackStyle = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxClientCode = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxCompanyCode = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxGTIN = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TextBoxPalletBatchNo = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxGMID = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxDetails = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TextBoxCustomer = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxProdLine = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TextBoxNotes = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxInnerUnit = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBoxInnerWeight = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBoxInnersPerCart = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxCartsPerPallet = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxTotalCartons = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxProdName = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSetStatus = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.exwoldTrackingDataSet = new ExwoldPcInterface.ExwoldTrackingDataSet();
            this.exwoldTrackingDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.palletBatchStatusTableAdapter = new ExwoldPcInterface.ExwoldTrackingDataSet5TableAdapters.PalletBatchStatusTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palletBatchStatusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exwoldTrackingDataSet5)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exwoldTrackingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exwoldTrackingDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
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
            this.button_add.Location = new System.Drawing.Point(0, 0);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(99, 32);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click_1);
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
            this.panel1.Controls.Add(this.TextBoxProdCode);
            this.panel1.Controls.Add(this.buttonEnableStatus);
            this.panel1.Controls.Add(this.comboBoxStatus);
            this.panel1.Controls.Add(this.labelStatus);
            this.panel1.Controls.Add(this.TextBoxInnerPackStyle);
            this.panel1.Controls.Add(this.TextBoxClientCode);
            this.panel1.Controls.Add(this.TextBoxCompanyCode);
            this.panel1.Controls.Add(this.TextBoxGTIN);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.TextBoxPalletBatchNo);
            this.panel1.Controls.Add(this.TextBoxGMID);
            this.panel1.Controls.Add(this.TextBoxDetails);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.TextBoxCustomer);
            this.panel1.Controls.Add(this.comboBoxProdLine);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.TextBoxNotes);
            this.panel1.Controls.Add(this.comboBoxInnerUnit);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.TextBoxInnerWeight);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TextBoxInnersPerCart);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TextBoxCartsPerPallet);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TextBoxTotalCartons);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TextBoxProdName);
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
            this.TextBoxProdCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxProdCode.Location = new System.Drawing.Point(133, 75);
            this.TextBoxProdCode.Name = "TextBoxProdCode";
            this.TextBoxProdCode.ReadOnly = true;
            this.TextBoxProdCode.Size = new System.Drawing.Size(155, 23);
            this.TextBoxProdCode.TabIndex = 50;
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
            this.comboBoxStatus.DataSource = this.palletBatchStatusBindingSource;
            this.comboBoxStatus.DisplayMember = "Status";
            this.comboBoxStatus.Enabled = false;
            this.comboBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(1103, 128);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(146, 24);
            this.comboBoxStatus.TabIndex = 48;
            this.comboBoxStatus.ValueMember = "StatusNo";
            // 
            // palletBatchStatusBindingSource
            // 
            this.palletBatchStatusBindingSource.DataMember = "PalletBatchStatus";
            this.palletBatchStatusBindingSource.DataSource = this.exwoldTrackingDataSet5;
            // 
            // exwoldTrackingDataSet5
            // 
            this.exwoldTrackingDataSet5.DataSetName = "ExwoldTrackingDataSet5";
            this.exwoldTrackingDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(960, 128);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(48, 17);
            this.labelStatus.TabIndex = 47;
            this.labelStatus.Text = "Status";
            // 
            // TextBoxInnerPackStyle
            // 
            this.TextBoxInnerPackStyle.Location = new System.Drawing.Point(87, 242);
            this.TextBoxInnerPackStyle.Name = "TextBoxInnerPackStyle";
            this.TextBoxInnerPackStyle.Size = new System.Drawing.Size(27, 20);
            this.TextBoxInnerPackStyle.TabIndex = 46;
            this.TextBoxInnerPackStyle.Visible = false;
            // 
            // TextBoxClientCode
            // 
            this.TextBoxClientCode.Location = new System.Drawing.Point(54, 241);
            this.TextBoxClientCode.Name = "TextBoxClientCode";
            this.TextBoxClientCode.Size = new System.Drawing.Size(27, 20);
            this.TextBoxClientCode.TabIndex = 45;
            this.TextBoxClientCode.Visible = false;
            // 
            // TextBoxCompanyCode
            // 
            this.TextBoxCompanyCode.Location = new System.Drawing.Point(54, 215);
            this.TextBoxCompanyCode.Name = "TextBoxCompanyCode";
            this.TextBoxCompanyCode.Size = new System.Drawing.Size(27, 20);
            this.TextBoxCompanyCode.TabIndex = 44;
            this.TextBoxCompanyCode.Visible = false;
            // 
            // TextBoxGTIN
            // 
            this.TextBoxGTIN.Location = new System.Drawing.Point(87, 215);
            this.TextBoxGTIN.Name = "TextBoxGTIN";
            this.TextBoxGTIN.Size = new System.Drawing.Size(27, 20);
            this.TextBoxGTIN.TabIndex = 43;
            this.TextBoxGTIN.Visible = false;
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
            this.TextBoxGMID.Location = new System.Drawing.Point(21, 242);
            this.TextBoxGMID.Name = "TextBoxGMID";
            this.TextBoxGMID.Size = new System.Drawing.Size(30, 20);
            this.TextBoxGMID.TabIndex = 40;
            this.TextBoxGMID.Visible = false;
            // 
            // TextBoxDetails
            // 
            this.TextBoxDetails.Location = new System.Drawing.Point(21, 216);
            this.TextBoxDetails.Name = "TextBoxDetails";
            this.TextBoxDetails.Size = new System.Drawing.Size(30, 20);
            this.TextBoxDetails.TabIndex = 39;
            this.TextBoxDetails.Visible = false;
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
            this.TextBoxCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCustomer.Location = new System.Drawing.Point(133, 128);
            this.TextBoxCustomer.Name = "TextBoxCustomer";
            this.TextBoxCustomer.ReadOnly = true;
            this.TextBoxCustomer.Size = new System.Drawing.Size(155, 23);
            this.TextBoxCustomer.TabIndex = 36;
            // 
            // comboBoxProdLine
            // 
            this.comboBoxProdLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxProdLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxProdLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProdLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxProdLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxProdLine.FormattingEnabled = true;
            this.comboBoxProdLine.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBoxProdLine.Location = new System.Drawing.Point(1103, 101);
            this.comboBoxProdLine.Name = "comboBoxProdLine";
            this.comboBoxProdLine.Size = new System.Drawing.Size(43, 24);
            this.comboBoxProdLine.TabIndex = 35;
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
            this.TextBoxNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxNotes.Location = new System.Drawing.Point(633, 179);
            this.TextBoxNotes.Name = "TextBoxNotes";
            this.TextBoxNotes.Size = new System.Drawing.Size(261, 23);
            this.TextBoxNotes.TabIndex = 21;
            // 
            // comboBoxInnerUnit
            // 
            this.comboBoxInnerUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxInnerUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxInnerUnit.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxInnerUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInnerUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxInnerUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxInnerUnit.FormattingEnabled = true;
            this.comboBoxInnerUnit.Items.AddRange(new object[] {
            "Kg",
            "L"});
            this.comboBoxInnerUnit.Location = new System.Drawing.Point(811, 152);
            this.comboBoxInnerUnit.Name = "comboBoxInnerUnit";
            this.comboBoxInnerUnit.Size = new System.Drawing.Size(43, 24);
            this.comboBoxInnerUnit.TabIndex = 20;
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
            this.TextBoxInnerWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxInnerWeight.Location = new System.Drawing.Point(633, 153);
            this.TextBoxInnerWeight.Name = "TextBoxInnerWeight";
            this.TextBoxInnerWeight.Size = new System.Drawing.Size(172, 23);
            this.TextBoxInnerWeight.TabIndex = 16;
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
            this.TextBoxInnersPerCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxInnersPerCart.Location = new System.Drawing.Point(633, 127);
            this.TextBoxInnersPerCart.Name = "TextBoxInnersPerCart";
            this.TextBoxInnersPerCart.Size = new System.Drawing.Size(172, 23);
            this.TextBoxInnersPerCart.TabIndex = 14;
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
            this.TextBoxCartsPerPallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCartsPerPallet.Location = new System.Drawing.Point(633, 101);
            this.TextBoxCartsPerPallet.Name = "TextBoxCartsPerPallet";
            this.TextBoxCartsPerPallet.Size = new System.Drawing.Size(172, 23);
            this.TextBoxCartsPerPallet.TabIndex = 12;
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
            this.TextBoxTotalCartons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTotalCartons.Location = new System.Drawing.Point(633, 75);
            this.TextBoxTotalCartons.Name = "TextBoxTotalCartons";
            this.TextBoxTotalCartons.Size = new System.Drawing.Size(172, 23);
            this.TextBoxTotalCartons.TabIndex = 10;
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
            this.TextBoxProdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxProdName.Location = new System.Drawing.Point(133, 102);
            this.TextBoxProdName.Name = "TextBoxProdName";
            this.TextBoxProdName.ReadOnly = true;
            this.TextBoxProdName.Size = new System.Drawing.Size(155, 23);
            this.TextBoxProdName.TabIndex = 8;
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
            this.button_save.Click += new System.EventHandler(this.button_save_Click_1);
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
            this.panel2.Controls.Add(this.dataGridView1);
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
            this.panel3.Size = new System.Drawing.Size(1088, 60);
            this.panel3.TabIndex = 13;
            // 
            // exwoldTrackingDataSet
            // 
            this.exwoldTrackingDataSet.DataSetName = "ExwoldTrackingDataSet";
            this.exwoldTrackingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // exwoldTrackingDataSetBindingSource
            // 
            this.exwoldTrackingDataSetBindingSource.DataSource = this.exwoldTrackingDataSet;
            this.exwoldTrackingDataSetBindingSource.Position = 0;
            // 
            // palletBatchStatusTableAdapter
            // 
            this.palletBatchStatusTableAdapter.ClearBeforeFill = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.palletBatchStatusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exwoldTrackingDataSet5)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exwoldTrackingDataSet)).EndInit();
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
        private System.Windows.Forms.MaskedTextBox TextBoxProdName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox TextBoxCartsPerPallet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox TextBoxTotalCartons;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox TextBoxInnersPerCart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox TextBoxInnerWeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox TextBoxNotes;
        private System.Windows.Forms.ComboBox comboBoxInnerUnit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ComboBox comboBoxProdLine;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox TextBoxCustomer;
        private System.Windows.Forms.MaskedTextBox TextBoxGMID;
        private System.Windows.Forms.MaskedTextBox TextBoxDetails;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox TextBoxPalletBatchNo;
        private System.Windows.Forms.MaskedTextBox TextBoxClientCode;
        private System.Windows.Forms.MaskedTextBox TextBoxCompanyCode;
        private System.Windows.Forms.MaskedTextBox TextBoxGTIN;
        private System.Windows.Forms.MaskedTextBox TextBoxInnerPackStyle;
        private System.Windows.Forms.Button buttonSetStatus;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonEnableStatus;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MaskedTextBox TextBoxProdCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingSource exwoldTrackingDataSetBindingSource;
        private ExwoldTrackingDataSet exwoldTrackingDataSet;
        private ExwoldTrackingDataSet5 exwoldTrackingDataSet5;
        private System.Windows.Forms.BindingSource palletBatchStatusBindingSource;
        private ExwoldTrackingDataSet5TableAdapters.PalletBatchStatusTableAdapter palletBatchStatusTableAdapter;
    }
}

