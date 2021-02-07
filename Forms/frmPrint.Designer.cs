namespace ITS.Exwold.Desktop
{
    partial class frmPrint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPrint = new System.Windows.Forms.Button();
            this.tabPrintForms = new System.Windows.Forms.TabControl();
            this.tabPalletLabels = new System.Windows.Forms.TabPage();
            this.grpPalletPrintInfo = new System.Windows.Forms.GroupBox();
            this.tbPrintQuantity = new System.Windows.Forms.TextBox();
            this.cboPalletPrinter = new System.Windows.Forms.ComboBox();
            this.lblPalletQty = new System.Windows.Forms.Label();
            this.lblPalletPrinter = new System.Windows.Forms.Label();
            this.grpPalletLabelData = new System.Windows.Forms.GroupBox();
            this.lblPalletTotLabels = new System.Windows.Forms.Label();
            this.tbPalletTotalLabels = new System.Windows.Forms.TextBox();
            this.tbPalletLabelNumber = new System.Windows.Forms.TextBox();
            this.lblPalletLabelNo = new System.Windows.Forms.Label();
            this.tbPalletCount = new System.Windows.Forms.TextBox();
            this.lblPalletCount = new System.Windows.Forms.Label();
            this.lblPalletGMID = new System.Windows.Forms.Label();
            this.tbPalletGMID = new System.Windows.Forms.TextBox();
            this.tbPalletNetUnits = new System.Windows.Forms.TextBox();
            this.lblPalletNetUnits = new System.Windows.Forms.Label();
            this.lblPalletNetUnits_AI = new System.Windows.Forms.Label();
            this.tbPalletNetUnits_AI = new System.Windows.Forms.TextBox();
            this.tbPalletProductionLineNumber = new System.Windows.Forms.TextBox();
            this.lblPalletBatchNo = new System.Windows.Forms.Label();
            this.lblPalletLineNo = new System.Windows.Forms.Label();
            this.tbPalletBatchNumber = new System.Windows.Forms.TextBox();
            this.tbPalletNetVolume = new System.Windows.Forms.TextBox();
            this.tbPalletProductionDate = new System.Windows.Forms.TextBox();
            this.lblPalletNetWt = new System.Windows.Forms.Label();
            this.tbPalletSSCC = new System.Windows.Forms.TextBox();
            this.lblPalletProdDate = new System.Windows.Forms.Label();
            this.lblPalletSSCC = new System.Windows.Forms.Label();
            this.lblPalletGTIN = new System.Windows.Forms.Label();
            this.tbPalletGTIN = new System.Windows.Forms.TextBox();
            this.grpButtons = new System.Windows.Forms.GroupBox();
            this.btnPalletClose = new System.Windows.Forms.Button();
            this.tabPrintForms.SuspendLayout();
            this.tabPalletLabels.SuspendLayout();
            this.grpPalletPrintInfo.SuspendLayout();
            this.grpPalletLabelData.SuspendLayout();
            this.grpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(478, 17);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 39);
            this.btnPrint.TabIndex = 33;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // tabPrintForms
            // 
            this.tabPrintForms.Controls.Add(this.tabPalletLabels);
            this.tabPrintForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrintForms.Location = new System.Drawing.Point(0, 0);
            this.tabPrintForms.Name = "tabPrintForms";
            this.tabPrintForms.SelectedIndex = 0;
            this.tabPrintForms.Size = new System.Drawing.Size(611, 409);
            this.tabPrintForms.TabIndex = 36;
            // 
            // tabPalletLabels
            // 
            this.tabPalletLabels.Controls.Add(this.grpPalletPrintInfo);
            this.tabPalletLabels.Controls.Add(this.grpPalletLabelData);
            this.tabPalletLabels.Controls.Add(this.grpButtons);
            this.tabPalletLabels.Location = new System.Drawing.Point(4, 31);
            this.tabPalletLabels.Name = "tabPalletLabels";
            this.tabPalletLabels.Padding = new System.Windows.Forms.Padding(3);
            this.tabPalletLabels.Size = new System.Drawing.Size(603, 374);
            this.tabPalletLabels.TabIndex = 0;
            this.tabPalletLabels.Text = "Pallet Labels";
            this.tabPalletLabels.UseVisualStyleBackColor = true;
            // 
            // grpPalletPrintInfo
            // 
            this.grpPalletPrintInfo.Controls.Add(this.btnPrint);
            this.grpPalletPrintInfo.Controls.Add(this.tbPrintQuantity);
            this.grpPalletPrintInfo.Controls.Add(this.cboPalletPrinter);
            this.grpPalletPrintInfo.Controls.Add(this.lblPalletQty);
            this.grpPalletPrintInfo.Controls.Add(this.lblPalletPrinter);
            this.grpPalletPrintInfo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPalletPrintInfo.Location = new System.Drawing.Point(3, 251);
            this.grpPalletPrintInfo.Name = "grpPalletPrintInfo";
            this.grpPalletPrintInfo.Size = new System.Drawing.Size(597, 63);
            this.grpPalletPrintInfo.TabIndex = 69;
            this.grpPalletPrintInfo.TabStop = false;
            this.grpPalletPrintInfo.Text = "Print Info";
            // 
            // tbPrintQuantity
            // 
            this.tbPrintQuantity.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrintQuantity.Location = new System.Drawing.Point(361, 23);
            this.tbPrintQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPrintQuantity.MaxLength = 15;
            this.tbPrintQuantity.Name = "tbPrintQuantity";
            this.tbPrintQuantity.Size = new System.Drawing.Size(48, 29);
            this.tbPrintQuantity.TabIndex = 45;
            this.tbPrintQuantity.Text = "1";
            this.tbPrintQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboPalletPrinter
            // 
            this.cboPalletPrinter.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPalletPrinter.FormattingEnabled = true;
            this.cboPalletPrinter.Items.AddRange(new object[] {
            "SATO CL6NX 305dpi 1",
            "SATO CL6NX 305dpi 2"});
            this.cboPalletPrinter.Location = new System.Drawing.Point(75, 22);
            this.cboPalletPrinter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboPalletPrinter.Name = "cboPalletPrinter";
            this.cboPalletPrinter.Size = new System.Drawing.Size(194, 30);
            this.cboPalletPrinter.TabIndex = 64;
            // 
            // lblPalletQty
            // 
            this.lblPalletQty.AutoSize = true;
            this.lblPalletQty.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletQty.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletQty.Location = new System.Drawing.Point(277, 26);
            this.lblPalletQty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletQty.Name = "lblPalletQty";
            this.lblPalletQty.Size = new System.Drawing.Size(76, 22);
            this.lblPalletQty.TabIndex = 44;
            this.lblPalletQty.Text = "Quantity:";
            this.lblPalletQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPalletPrinter
            // 
            this.lblPalletPrinter.AutoSize = true;
            this.lblPalletPrinter.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletPrinter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletPrinter.Location = new System.Drawing.Point(9, 26);
            this.lblPalletPrinter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletPrinter.Name = "lblPalletPrinter";
            this.lblPalletPrinter.Size = new System.Drawing.Size(61, 22);
            this.lblPalletPrinter.TabIndex = 62;
            this.lblPalletPrinter.Text = "Printer:";
            this.lblPalletPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpPalletLabelData
            // 
            this.grpPalletLabelData.Controls.Add(this.lblPalletTotLabels);
            this.grpPalletLabelData.Controls.Add(this.tbPalletTotalLabels);
            this.grpPalletLabelData.Controls.Add(this.tbPalletLabelNumber);
            this.grpPalletLabelData.Controls.Add(this.lblPalletLabelNo);
            this.grpPalletLabelData.Controls.Add(this.tbPalletCount);
            this.grpPalletLabelData.Controls.Add(this.lblPalletCount);
            this.grpPalletLabelData.Controls.Add(this.lblPalletGMID);
            this.grpPalletLabelData.Controls.Add(this.tbPalletGMID);
            this.grpPalletLabelData.Controls.Add(this.tbPalletNetUnits);
            this.grpPalletLabelData.Controls.Add(this.lblPalletNetUnits);
            this.grpPalletLabelData.Controls.Add(this.lblPalletNetUnits_AI);
            this.grpPalletLabelData.Controls.Add(this.tbPalletNetUnits_AI);
            this.grpPalletLabelData.Controls.Add(this.tbPalletProductionLineNumber);
            this.grpPalletLabelData.Controls.Add(this.lblPalletBatchNo);
            this.grpPalletLabelData.Controls.Add(this.lblPalletLineNo);
            this.grpPalletLabelData.Controls.Add(this.tbPalletBatchNumber);
            this.grpPalletLabelData.Controls.Add(this.tbPalletNetVolume);
            this.grpPalletLabelData.Controls.Add(this.tbPalletProductionDate);
            this.grpPalletLabelData.Controls.Add(this.lblPalletNetWt);
            this.grpPalletLabelData.Controls.Add(this.tbPalletSSCC);
            this.grpPalletLabelData.Controls.Add(this.lblPalletProdDate);
            this.grpPalletLabelData.Controls.Add(this.lblPalletSSCC);
            this.grpPalletLabelData.Controls.Add(this.lblPalletGTIN);
            this.grpPalletLabelData.Controls.Add(this.tbPalletGTIN);
            this.grpPalletLabelData.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPalletLabelData.Location = new System.Drawing.Point(-7, 4);
            this.grpPalletLabelData.Name = "grpPalletLabelData";
            this.grpPalletLabelData.Size = new System.Drawing.Size(607, 245);
            this.grpPalletLabelData.TabIndex = 68;
            this.grpPalletLabelData.TabStop = false;
            this.grpPalletLabelData.Text = "Label Data";
            // 
            // lblPalletTotLabels
            // 
            this.lblPalletTotLabels.AutoSize = true;
            this.lblPalletTotLabels.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletTotLabels.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletTotLabels.Location = new System.Drawing.Point(294, 203);
            this.lblPalletTotLabels.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletTotLabels.Name = "lblPalletTotLabels";
            this.lblPalletTotLabels.Size = new System.Drawing.Size(23, 22);
            this.lblPalletTotLabels.TabIndex = 71;
            this.lblPalletTotLabels.Text = "of";
            this.lblPalletTotLabels.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPalletTotalLabels
            // 
            this.tbPalletTotalLabels.Enabled = false;
            this.tbPalletTotalLabels.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletTotalLabels.Location = new System.Drawing.Point(327, 199);
            this.tbPalletTotalLabels.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletTotalLabels.MaxLength = 15;
            this.tbPalletTotalLabels.Name = "tbPalletTotalLabels";
            this.tbPalletTotalLabels.Size = new System.Drawing.Size(75, 29);
            this.tbPalletTotalLabels.TabIndex = 72;
            this.tbPalletTotalLabels.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPalletLabelNumber
            // 
            this.tbPalletLabelNumber.Enabled = false;
            this.tbPalletLabelNumber.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletLabelNumber.Location = new System.Drawing.Point(209, 199);
            this.tbPalletLabelNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletLabelNumber.MaxLength = 15;
            this.tbPalletLabelNumber.Name = "tbPalletLabelNumber";
            this.tbPalletLabelNumber.Size = new System.Drawing.Size(75, 29);
            this.tbPalletLabelNumber.TabIndex = 70;
            this.tbPalletLabelNumber.Text = "\r\n                           ";
            this.tbPalletLabelNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPalletLabelNo
            // 
            this.lblPalletLabelNo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletLabelNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletLabelNo.Location = new System.Drawing.Point(204, 176);
            this.lblPalletLabelNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletLabelNo.Name = "lblPalletLabelNo";
            this.lblPalletLabelNo.Size = new System.Drawing.Size(194, 22);
            this.lblPalletLabelNo.TabIndex = 69;
            this.lblPalletLabelNo.Text = "Label No:";
            this.lblPalletLabelNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPalletCount
            // 
            this.tbPalletCount.Enabled = false;
            this.tbPalletCount.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletCount.Location = new System.Drawing.Point(209, 93);
            this.tbPalletCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletCount.MaxLength = 40;
            this.tbPalletCount.Name = "tbPalletCount";
            this.tbPalletCount.Size = new System.Drawing.Size(194, 29);
            this.tbPalletCount.TabIndex = 68;
            this.tbPalletCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPalletCount
            // 
            this.lblPalletCount.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletCount.Location = new System.Drawing.Point(209, 70);
            this.lblPalletCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletCount.Name = "lblPalletCount";
            this.lblPalletCount.Size = new System.Drawing.Size(194, 22);
            this.lblPalletCount.TabIndex = 67;
            this.lblPalletCount.Text = "Count:";
            this.lblPalletCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPalletGMID
            // 
            this.lblPalletGMID.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletGMID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletGMID.Location = new System.Drawing.Point(406, 17);
            this.lblPalletGMID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletGMID.Name = "lblPalletGMID";
            this.lblPalletGMID.Size = new System.Drawing.Size(194, 22);
            this.lblPalletGMID.TabIndex = 36;
            this.lblPalletGMID.Text = "GMID:";
            this.lblPalletGMID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPalletGMID
            // 
            this.tbPalletGMID.Enabled = false;
            this.tbPalletGMID.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletGMID.Location = new System.Drawing.Point(406, 40);
            this.tbPalletGMID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletGMID.MaxLength = 40;
            this.tbPalletGMID.Name = "tbPalletGMID";
            this.tbPalletGMID.Size = new System.Drawing.Size(194, 29);
            this.tbPalletGMID.TabIndex = 37;
            this.tbPalletGMID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPalletNetUnits
            // 
            this.tbPalletNetUnits.Enabled = false;
            this.tbPalletNetUnits.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletNetUnits.Location = new System.Drawing.Point(552, 206);
            this.tbPalletNetUnits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletNetUnits.MaxLength = 40;
            this.tbPalletNetUnits.Name = "tbPalletNetUnits";
            this.tbPalletNetUnits.Size = new System.Drawing.Size(48, 29);
            this.tbPalletNetUnits.TabIndex = 41;
            this.tbPalletNetUnits.Visible = false;
            // 
            // lblPalletNetUnits
            // 
            this.lblPalletNetUnits.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletNetUnits.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletNetUnits.Location = new System.Drawing.Point(432, 209);
            this.lblPalletNetUnits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletNetUnits.Name = "lblPalletNetUnits";
            this.lblPalletNetUnits.Size = new System.Drawing.Size(112, 22);
            this.lblPalletNetUnits.TabIndex = 40;
            this.lblPalletNetUnits.Text = "Net Units:";
            this.lblPalletNetUnits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPalletNetUnits.Visible = false;
            // 
            // lblPalletNetUnits_AI
            // 
            this.lblPalletNetUnits_AI.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletNetUnits_AI.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletNetUnits_AI.Location = new System.Drawing.Point(432, 179);
            this.lblPalletNetUnits_AI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletNetUnits_AI.Name = "lblPalletNetUnits_AI";
            this.lblPalletNetUnits_AI.Size = new System.Drawing.Size(112, 22);
            this.lblPalletNetUnits_AI.TabIndex = 42;
            this.lblPalletNetUnits_AI.Text = "NetUnits_AI:";
            this.lblPalletNetUnits_AI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPalletNetUnits_AI.Visible = false;
            // 
            // tbPalletNetUnits_AI
            // 
            this.tbPalletNetUnits_AI.Enabled = false;
            this.tbPalletNetUnits_AI.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletNetUnits_AI.Location = new System.Drawing.Point(552, 176);
            this.tbPalletNetUnits_AI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletNetUnits_AI.MaxLength = 15;
            this.tbPalletNetUnits_AI.Name = "tbPalletNetUnits_AI";
            this.tbPalletNetUnits_AI.Size = new System.Drawing.Size(48, 29);
            this.tbPalletNetUnits_AI.TabIndex = 43;
            this.tbPalletNetUnits_AI.Visible = false;
            // 
            // tbPalletProductionLineNumber
            // 
            this.tbPalletProductionLineNumber.Enabled = false;
            this.tbPalletProductionLineNumber.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletProductionLineNumber.Location = new System.Drawing.Point(552, 146);
            this.tbPalletProductionLineNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletProductionLineNumber.MaxLength = 15;
            this.tbPalletProductionLineNumber.Name = "tbPalletProductionLineNumber";
            this.tbPalletProductionLineNumber.Size = new System.Drawing.Size(48, 29);
            this.tbPalletProductionLineNumber.TabIndex = 61;
            this.tbPalletProductionLineNumber.Visible = false;
            // 
            // lblPalletBatchNo
            // 
            this.lblPalletBatchNo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletBatchNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletBatchNo.Location = new System.Drawing.Point(12, 123);
            this.lblPalletBatchNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletBatchNo.Name = "lblPalletBatchNo";
            this.lblPalletBatchNo.Size = new System.Drawing.Size(194, 22);
            this.lblPalletBatchNo.TabIndex = 46;
            this.lblPalletBatchNo.Text = "Lot Number:";
            this.lblPalletBatchNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPalletLineNo
            // 
            this.lblPalletLineNo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletLineNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletLineNo.Location = new System.Drawing.Point(432, 149);
            this.lblPalletLineNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletLineNo.Name = "lblPalletLineNo";
            this.lblPalletLineNo.Size = new System.Drawing.Size(112, 22);
            this.lblPalletLineNo.TabIndex = 60;
            this.lblPalletLineNo.Text = "Line Number:";
            this.lblPalletLineNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPalletLineNo.Visible = false;
            // 
            // tbPalletBatchNumber
            // 
            this.tbPalletBatchNumber.Enabled = false;
            this.tbPalletBatchNumber.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletBatchNumber.Location = new System.Drawing.Point(12, 146);
            this.tbPalletBatchNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletBatchNumber.MaxLength = 40;
            this.tbPalletBatchNumber.Name = "tbPalletBatchNumber";
            this.tbPalletBatchNumber.Size = new System.Drawing.Size(194, 29);
            this.tbPalletBatchNumber.TabIndex = 47;
            this.tbPalletBatchNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPalletNetVolume
            // 
            this.tbPalletNetVolume.Enabled = false;
            this.tbPalletNetVolume.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletNetVolume.Location = new System.Drawing.Point(406, 93);
            this.tbPalletNetVolume.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletNetVolume.MaxLength = 15;
            this.tbPalletNetVolume.Name = "tbPalletNetVolume";
            this.tbPalletNetVolume.Size = new System.Drawing.Size(194, 29);
            this.tbPalletNetVolume.TabIndex = 59;
            this.tbPalletNetVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPalletProductionDate
            // 
            this.tbPalletProductionDate.Enabled = false;
            this.tbPalletProductionDate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletProductionDate.Location = new System.Drawing.Point(209, 146);
            this.tbPalletProductionDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletProductionDate.MaxLength = 40;
            this.tbPalletProductionDate.Name = "tbPalletProductionDate";
            this.tbPalletProductionDate.Size = new System.Drawing.Size(194, 29);
            this.tbPalletProductionDate.TabIndex = 49;
            this.tbPalletProductionDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPalletNetWt
            // 
            this.lblPalletNetWt.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletNetWt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletNetWt.Location = new System.Drawing.Point(406, 70);
            this.lblPalletNetWt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletNetWt.Name = "lblPalletNetWt";
            this.lblPalletNetWt.Size = new System.Drawing.Size(194, 22);
            this.lblPalletNetWt.TabIndex = 58;
            this.lblPalletNetWt.Text = "Net Weight or Volume:";
            this.lblPalletNetWt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPalletSSCC
            // 
            this.tbPalletSSCC.Enabled = false;
            this.tbPalletSSCC.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletSSCC.Location = new System.Drawing.Point(12, 199);
            this.tbPalletSSCC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletSSCC.MaxLength = 40;
            this.tbPalletSSCC.Name = "tbPalletSSCC";
            this.tbPalletSSCC.Size = new System.Drawing.Size(194, 29);
            this.tbPalletSSCC.TabIndex = 51;
            this.tbPalletSSCC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPalletProdDate
            // 
            this.lblPalletProdDate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletProdDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletProdDate.Location = new System.Drawing.Point(209, 123);
            this.lblPalletProdDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletProdDate.Name = "lblPalletProdDate";
            this.lblPalletProdDate.Size = new System.Drawing.Size(194, 22);
            this.lblPalletProdDate.TabIndex = 48;
            this.lblPalletProdDate.Text = "Production Date:";
            this.lblPalletProdDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPalletSSCC
            // 
            this.lblPalletSSCC.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletSSCC.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletSSCC.Location = new System.Drawing.Point(7, 176);
            this.lblPalletSSCC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletSSCC.Name = "lblPalletSSCC";
            this.lblPalletSSCC.Size = new System.Drawing.Size(194, 22);
            this.lblPalletSSCC.TabIndex = 50;
            this.lblPalletSSCC.Text = "SSCC:";
            this.lblPalletSSCC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPalletGTIN
            // 
            this.lblPalletGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletGTIN.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletGTIN.Location = new System.Drawing.Point(17, 70);
            this.lblPalletGTIN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletGTIN.Name = "lblPalletGTIN";
            this.lblPalletGTIN.Size = new System.Drawing.Size(194, 22);
            this.lblPalletGTIN.TabIndex = 52;
            this.lblPalletGTIN.Text = "Article Number:";
            this.lblPalletGTIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPalletGTIN
            // 
            this.tbPalletGTIN.Enabled = false;
            this.tbPalletGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletGTIN.Location = new System.Drawing.Point(12, 93);
            this.tbPalletGTIN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletGTIN.MaxLength = 15;
            this.tbPalletGTIN.Name = "tbPalletGTIN";
            this.tbPalletGTIN.Size = new System.Drawing.Size(194, 29);
            this.tbPalletGTIN.TabIndex = 53;
            this.tbPalletGTIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add(this.btnPalletClose);
            this.grpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpButtons.Location = new System.Drawing.Point(3, 308);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Size = new System.Drawing.Size(597, 63);
            this.grpButtons.TabIndex = 67;
            this.grpButtons.TabStop = false;
            // 
            // btnPalletClose
            // 
            this.btnPalletClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPalletClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPalletClose.Location = new System.Drawing.Point(516, 17);
            this.btnPalletClose.Name = "btnPalletClose";
            this.btnPalletClose.Size = new System.Drawing.Size(75, 39);
            this.btnPalletClose.TabIndex = 0;
            this.btnPalletClose.Text = "Close";
            this.btnPalletClose.UseVisualStyleBackColor = true;
            this.btnPalletClose.Click += new System.EventHandler(this.btnPalletClose_Click);
            // 
            // frmPrint
            // 
            this.AcceptButton = this.btnPrint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnPalletClose;
            this.ClientSize = new System.Drawing.Size(611, 409);
            this.Controls.Add(this.tabPrintForms);
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmPrint";
            this.Text = "Label Print Form";
            this.tabPrintForms.ResumeLayout(false);
            this.tabPalletLabels.ResumeLayout(false);
            this.grpPalletPrintInfo.ResumeLayout(false);
            this.grpPalletPrintInfo.PerformLayout();
            this.grpPalletLabelData.ResumeLayout(false);
            this.grpPalletLabelData.PerformLayout();
            this.grpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TabControl tabPrintForms;
        private System.Windows.Forms.TabPage tabPalletLabels;
        private System.Windows.Forms.GroupBox grpButtons;
        private System.Windows.Forms.Button btnPalletClose;
        private System.Windows.Forms.ComboBox cboPalletPrinter;
        private System.Windows.Forms.Label lblPalletPrinter;
        private System.Windows.Forms.TextBox tbPalletProductionLineNumber;
        private System.Windows.Forms.Label lblPalletLineNo;
        private System.Windows.Forms.TextBox tbPalletNetVolume;
        private System.Windows.Forms.Label lblPalletNetWt;
        private System.Windows.Forms.TextBox tbPalletGTIN;
        private System.Windows.Forms.Label lblPalletGTIN;
        private System.Windows.Forms.Label lblPalletSSCC;
        private System.Windows.Forms.Label lblPalletProdDate;
        private System.Windows.Forms.TextBox tbPalletSSCC;
        private System.Windows.Forms.TextBox tbPalletProductionDate;
        private System.Windows.Forms.TextBox tbPalletBatchNumber;
        private System.Windows.Forms.Label lblPalletBatchNo;
        private System.Windows.Forms.Label lblPalletQty;
        private System.Windows.Forms.TextBox tbPrintQuantity;
        private System.Windows.Forms.TextBox tbPalletNetUnits_AI;
        private System.Windows.Forms.Label lblPalletNetUnits_AI;
        private System.Windows.Forms.Label lblPalletNetUnits;
        private System.Windows.Forms.TextBox tbPalletNetUnits;
        private System.Windows.Forms.TextBox tbPalletGMID;
        private System.Windows.Forms.Label lblPalletGMID;
        private System.Windows.Forms.GroupBox grpPalletPrintInfo;
        private System.Windows.Forms.GroupBox grpPalletLabelData;
        private System.Windows.Forms.TextBox tbPalletCount;
        private System.Windows.Forms.Label lblPalletCount;
        private System.Windows.Forms.Label lblPalletTotLabels;
        private System.Windows.Forms.TextBox tbPalletTotalLabels;
        private System.Windows.Forms.TextBox tbPalletLabelNumber;
        private System.Windows.Forms.Label lblPalletLabelNo;
    }
}

