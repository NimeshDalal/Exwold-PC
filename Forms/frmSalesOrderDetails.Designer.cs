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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrintLabel = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.textBoxPalletBatchNo = new System.Windows.Forms.Label();
            this.textBoxCustomer = new System.Windows.Forms.Label();
            this.textBoxInnersPerCart = new System.Windows.Forms.Label();
            this.textBoxCartsPerPallet = new System.Windows.Forms.Label();
            this.textBoxProdName = new System.Windows.Forms.Label();
            this.textBoxProdCode = new System.Windows.Forms.Label();
            this.comboBoxInnerUnit = new System.Windows.Forms.Label();
            this.textBoxInnerWeight = new System.Windows.Forms.Label();
            this.textBoxTotalCartons = new System.Windows.Forms.Label();
            this.textBoxProdLine = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCartonsOnPallet = new System.Windows.Forms.Label();
            this.dgvCartonsOnPallet = new System.Windows.Forms.DataGridView();
            this.textBoxNotes = new System.Windows.Forms.RichTextBox();
            this.textBoxCurrentPallet = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.grpButtons = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartonsOnPallet)).BeginInit();
            this.grpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(513, 34);
            this.label15.TabIndex = 7;
            this.label15.Text = "Sales Order Details";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(3, 110);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 29);
            this.label6.TabIndex = 19;
            this.label6.Text = "Customer";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(3, 41);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 29);
            this.label8.TabIndex = 21;
            this.label8.Text = "Sales Order No";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(3, 140);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 29);
            this.label9.TabIndex = 22;
            this.label9.Text = "Product Code";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(318, 222);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 29);
            this.label10.TabIndex = 29;
            this.label10.Text = "Cartons Required";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(318, 313);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(191, 29);
            this.label11.TabIndex = 31;
            this.label11.Text = "Product batches on Pallet";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 29);
            this.label1.TabIndex = 35;
            this.label1.Text = "Status ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStatus
            // 
            this.labelStatus.BackColor = System.Drawing.SystemColors.Window;
            this.labelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStatus.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.Green;
            this.labelStatus.Location = new System.Drawing.Point(139, 71);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(177, 29);
            this.labelStatus.TabIndex = 36;
            this.labelStatus.Text = "...";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.btnClose.Location = new System.Drawing.Point(358, 20);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(148, 39);
            this.btnClose.TabIndex = 57;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // btnPrintLabel
            // 
            this.btnPrintLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintLabel.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.btnPrintLabel.Location = new System.Drawing.Point(210, 20);
            this.btnPrintLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrintLabel.Name = "btnPrintLabel";
            this.btnPrintLabel.Size = new System.Drawing.Size(148, 39);
            this.btnPrintLabel.TabIndex = 58;
            this.btnPrintLabel.Text = "Print Label";
            this.btnPrintLabel.UseVisualStyleBackColor = true;
            this.btnPrintLabel.Click += new System.EventHandler(this.btnPrintLabel_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.buttonEdit.Location = new System.Drawing.Point(62, 20);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(148, 39);
            this.buttonEdit.TabIndex = 60;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(318, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 29);
            this.label3.TabIndex = 61;
            this.label3.Text = "Production Line";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(3, 222);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 29);
            this.label4.TabIndex = 64;
            this.label4.Text = "Outers per pallet";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(3, 170);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 29);
            this.label5.TabIndex = 63;
            this.label5.Text = "Product Name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(3, 313);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(135, 29);
            this.label14.TabIndex = 86;
            this.label14.Text = "Notes";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.SystemColors.Control;
            this.label19.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(3, 283);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(135, 29);
            this.label19.TabIndex = 87;
            this.label19.Text = "Unit weight/volume";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.SystemColors.Control;
            this.label21.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(3, 253);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(135, 29);
            this.label21.TabIndex = 88;
            this.label21.Text = "Inners per outer";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxPalletBatchNo
            // 
            this.textBoxPalletBatchNo.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPalletBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPalletBatchNo.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPalletBatchNo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxPalletBatchNo.Location = new System.Drawing.Point(139, 41);
            this.textBoxPalletBatchNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textBoxPalletBatchNo.Name = "textBoxPalletBatchNo";
            this.textBoxPalletBatchNo.Size = new System.Drawing.Size(177, 29);
            this.textBoxPalletBatchNo.TabIndex = 90;
            this.textBoxPalletBatchNo.Text = "...";
            this.textBoxPalletBatchNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxCustomer
            // 
            this.textBoxCustomer.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCustomer.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.textBoxCustomer.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxCustomer.Location = new System.Drawing.Point(139, 110);
            this.textBoxCustomer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textBoxCustomer.Name = "textBoxCustomer";
            this.textBoxCustomer.Size = new System.Drawing.Size(177, 29);
            this.textBoxCustomer.TabIndex = 91;
            this.textBoxCustomer.Text = "...";
            this.textBoxCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxInnersPerCart
            // 
            this.textBoxInnersPerCart.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxInnersPerCart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxInnersPerCart.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.textBoxInnersPerCart.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxInnersPerCart.Location = new System.Drawing.Point(139, 253);
            this.textBoxInnersPerCart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textBoxInnersPerCart.Name = "textBoxInnersPerCart";
            this.textBoxInnersPerCart.Size = new System.Drawing.Size(46, 29);
            this.textBoxInnersPerCart.TabIndex = 92;
            this.textBoxInnersPerCart.Text = "...";
            this.textBoxInnersPerCart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxCartsPerPallet
            // 
            this.textBoxCartsPerPallet.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCartsPerPallet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCartsPerPallet.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.textBoxCartsPerPallet.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxCartsPerPallet.Location = new System.Drawing.Point(139, 222);
            this.textBoxCartsPerPallet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textBoxCartsPerPallet.Name = "textBoxCartsPerPallet";
            this.textBoxCartsPerPallet.Size = new System.Drawing.Size(46, 29);
            this.textBoxCartsPerPallet.TabIndex = 93;
            this.textBoxCartsPerPallet.Text = "...";
            this.textBoxCartsPerPallet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxProdName
            // 
            this.textBoxProdName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxProdName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxProdName.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.textBoxProdName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxProdName.Location = new System.Drawing.Point(139, 170);
            this.textBoxProdName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textBoxProdName.Name = "textBoxProdName";
            this.textBoxProdName.Size = new System.Drawing.Size(370, 51);
            this.textBoxProdName.TabIndex = 94;
            this.textBoxProdName.Text = "...";
            this.textBoxProdName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxProdCode
            // 
            this.textBoxProdCode.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxProdCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxProdCode.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.textBoxProdCode.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxProdCode.Location = new System.Drawing.Point(139, 140);
            this.textBoxProdCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textBoxProdCode.Name = "textBoxProdCode";
            this.textBoxProdCode.Size = new System.Drawing.Size(177, 29);
            this.textBoxProdCode.TabIndex = 95;
            this.textBoxProdCode.Text = "...";
            this.textBoxProdCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxInnerUnit
            // 
            this.comboBoxInnerUnit.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxInnerUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.comboBoxInnerUnit.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.comboBoxInnerUnit.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.comboBoxInnerUnit.Location = new System.Drawing.Point(187, 283);
            this.comboBoxInnerUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.comboBoxInnerUnit.Name = "comboBoxInnerUnit";
            this.comboBoxInnerUnit.Size = new System.Drawing.Size(46, 29);
            this.comboBoxInnerUnit.TabIndex = 96;
            this.comboBoxInnerUnit.Text = "...";
            this.comboBoxInnerUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxInnerWeight
            // 
            this.textBoxInnerWeight.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxInnerWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxInnerWeight.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.textBoxInnerWeight.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxInnerWeight.Location = new System.Drawing.Point(139, 283);
            this.textBoxInnerWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textBoxInnerWeight.Name = "textBoxInnerWeight";
            this.textBoxInnerWeight.Size = new System.Drawing.Size(46, 29);
            this.textBoxInnerWeight.TabIndex = 97;
            this.textBoxInnerWeight.Text = "...";
            this.textBoxInnerWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxTotalCartons
            // 
            this.textBoxTotalCartons.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxTotalCartons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTotalCartons.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.textBoxTotalCartons.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxTotalCartons.Location = new System.Drawing.Point(463, 222);
            this.textBoxTotalCartons.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textBoxTotalCartons.Name = "textBoxTotalCartons";
            this.textBoxTotalCartons.Size = new System.Drawing.Size(46, 29);
            this.textBoxTotalCartons.TabIndex = 103;
            this.textBoxTotalCartons.Text = "...";
            this.textBoxTotalCartons.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxProdLine
            // 
            this.textBoxProdLine.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxProdLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxProdLine.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.textBoxProdLine.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxProdLine.Location = new System.Drawing.Point(463, 71);
            this.textBoxProdLine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textBoxProdLine.Name = "textBoxProdLine";
            this.textBoxProdLine.Size = new System.Drawing.Size(46, 29);
            this.textBoxProdLine.TabIndex = 104;
            this.textBoxProdLine.Text = "...";
            this.textBoxProdLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(318, 253);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 29);
            this.label7.TabIndex = 20;
            this.label7.Text = "Cartons on Pallet";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxCartonsOnPallet
            // 
            this.textBoxCartonsOnPallet.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCartonsOnPallet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCartonsOnPallet.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.textBoxCartonsOnPallet.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxCartonsOnPallet.Location = new System.Drawing.Point(463, 253);
            this.textBoxCartonsOnPallet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textBoxCartonsOnPallet.Name = "textBoxCartonsOnPallet";
            this.textBoxCartonsOnPallet.Size = new System.Drawing.Size(46, 29);
            this.textBoxCartonsOnPallet.TabIndex = 102;
            this.textBoxCartonsOnPallet.Text = "...";
            this.textBoxCartonsOnPallet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvCartonsOnPallet
            // 
            this.dgvCartonsOnPallet.AllowUserToAddRows = false;
            this.dgvCartonsOnPallet.AllowUserToDeleteRows = false;
            this.dgvCartonsOnPallet.AllowUserToResizeColumns = false;
            this.dgvCartonsOnPallet.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dgvCartonsOnPallet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCartonsOnPallet.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCartonsOnPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCartonsOnPallet.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvCartonsOnPallet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCartonsOnPallet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartonsOnPallet.Enabled = false;
            this.dgvCartonsOnPallet.EnableHeadersVisualStyles = false;
            this.dgvCartonsOnPallet.Location = new System.Drawing.Point(318, 343);
            this.dgvCartonsOnPallet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCartonsOnPallet.MultiSelect = false;
            this.dgvCartonsOnPallet.Name = "dgvCartonsOnPallet";
            this.dgvCartonsOnPallet.RowHeadersVisible = false;
            this.dgvCartonsOnPallet.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvCartonsOnPallet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCartonsOnPallet.Size = new System.Drawing.Size(191, 140);
            this.dgvCartonsOnPallet.TabIndex = 105;
            this.dgvCartonsOnPallet.TabStop = false;
            this.dgvCartonsOnPallet.Tag = "";
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxNotes.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.textBoxNotes.Location = new System.Drawing.Point(3, 343);
            this.textBoxNotes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.ReadOnly = true;
            this.textBoxNotes.Size = new System.Drawing.Size(313, 140);
            this.textBoxNotes.TabIndex = 106;
            this.textBoxNotes.Text = "This is the notes field which have a max number of characters";
            // 
            // textBoxCurrentPallet
            // 
            this.textBoxCurrentPallet.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCurrentPallet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCurrentPallet.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.textBoxCurrentPallet.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxCurrentPallet.Location = new System.Drawing.Point(463, 283);
            this.textBoxCurrentPallet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textBoxCurrentPallet.Name = "textBoxCurrentPallet";
            this.textBoxCurrentPallet.Size = new System.Drawing.Size(46, 29);
            this.textBoxCurrentPallet.TabIndex = 108;
            this.textBoxCurrentPallet.Text = "...";
            this.textBoxCurrentPallet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(318, 283);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 29);
            this.label12.TabIndex = 107;
            this.label12.Text = "Current Pallet";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add(this.btnPrintLabel);
            this.grpButtons.Controls.Add(this.buttonEdit);
            this.grpButtons.Controls.Add(this.btnClose);
            this.grpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpButtons.Location = new System.Drawing.Point(0, 485);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Size = new System.Drawing.Size(513, 67);
            this.grpButtons.TabIndex = 109;
            this.grpButtons.TabStop = false;
            // 
            // frmSalesOrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(513, 552);
            this.ControlBox = false;
            this.Controls.Add(this.grpButtons);
            this.Controls.Add(this.textBoxCurrentPallet);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.dgvCartonsOnPallet);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBoxProdLine);
            this.Controls.Add(this.textBoxTotalCartons);
            this.Controls.Add(this.textBoxCartonsOnPallet);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxInnerWeight);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxInnerUnit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxProdCode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxProdName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxCartsPerPallet);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxInnersPerCart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCustomer);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxPalletBatchNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label14);
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSalesOrderDetails";
            this.Text = "EXWOLD PALLET TRACKING";
            this.Load += new System.EventHandler(this.BatchDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartonsOnPallet)).EndInit();
            this.grpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrintLabel;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label textBoxPalletBatchNo;
        private System.Windows.Forms.Label textBoxCustomer;
        private System.Windows.Forms.Label textBoxInnersPerCart;
        private System.Windows.Forms.Label textBoxCartsPerPallet;
        private System.Windows.Forms.Label textBoxProdName;
        private System.Windows.Forms.Label textBoxProdCode;
        private System.Windows.Forms.Label comboBoxInnerUnit;
        private System.Windows.Forms.Label textBoxInnerWeight;
        private System.Windows.Forms.Label textBoxTotalCartons;
        private System.Windows.Forms.Label textBoxProdLine;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label textBoxCartonsOnPallet;
        private System.Windows.Forms.DataGridView dgvCartonsOnPallet;
        private System.Windows.Forms.RichTextBox textBoxNotes;
        private System.Windows.Forms.Label textBoxCurrentPallet;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox grpButtons;
    }
}

