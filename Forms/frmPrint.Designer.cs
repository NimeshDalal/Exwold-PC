namespace ITS.Exwold.Desktop
{
    partial class frmPrint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnPalletReprint = new System.Windows.Forms.Button();
            this.tabPrintForms = new System.Windows.Forms.TabControl();
            this.tabPalletLabels = new System.Windows.Forms.TabPage();
            this.grpPalletPrintInfo = new System.Windows.Forms.GroupBox();
            this.tbPalletLabelNumber = new System.Windows.Forms.TextBox();
            this.tbPalletCount = new System.Windows.Forms.TextBox();
            this.lblPalletCount = new System.Windows.Forms.Label();
            this.tbPalletQuantity = new System.Windows.Forms.TextBox();
            this.cboPalletPrinter = new System.Windows.Forms.ComboBox();
            this.lblPalletPrintStatus = new System.Windows.Forms.Label();
            this.lblPalletQty = new System.Windows.Forms.Label();
            this.lblPalletPrinter = new System.Windows.Forms.Label();
            this.lblPalletTotLabels = new System.Windows.Forms.Label();
            this.tbPalletTotalLabels = new System.Windows.Forms.TextBox();
            this.lblPalletLabelNo = new System.Windows.Forms.Label();
            this.grpPalletLabelData = new System.Windows.Forms.GroupBox();
            this.lblPalletProductName = new System.Windows.Forms.Label();
            this.lblPalletGMID = new System.Windows.Forms.Label();
            this.tbPalletProductName = new System.Windows.Forms.TextBox();
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabPrintForms.SuspendLayout();
            this.tabPalletLabels.SuspendLayout();
            this.grpPalletPrintInfo.SuspendLayout();
            this.grpPalletLabelData.SuspendLayout();
            this.grpButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPalletReprint
            // 
            this.btnPalletReprint.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPalletReprint.Location = new System.Drawing.Point(188, 171);
            this.btnPalletReprint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPalletReprint.Name = "btnPalletReprint";
            this.btnPalletReprint.Size = new System.Drawing.Size(112, 39);
            this.btnPalletReprint.TabIndex = 33;
            this.btnPalletReprint.Text = "&Print";
            this.btnPalletReprint.UseVisualStyleBackColor = true;
            this.btnPalletReprint.Click += new System.EventHandler(this.buttonReprint_Click);
            // 
            // tabPrintForms
            // 
            this.tabPrintForms.Controls.Add(this.tabPalletLabels);
            this.tabPrintForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrintForms.Location = new System.Drawing.Point(0, 0);
            this.tabPrintForms.Name = "tabPrintForms";
            this.tabPrintForms.SelectedIndex = 0;
            this.tabPrintForms.Size = new System.Drawing.Size(479, 654);
            this.tabPrintForms.TabIndex = 36;
            this.tabPrintForms.Visible = false;
            // 
            // tabPalletLabels
            // 
            this.tabPalletLabels.Controls.Add(this.grpPalletPrintInfo);
            this.tabPalletLabels.Controls.Add(this.grpPalletLabelData);
            this.tabPalletLabels.Controls.Add(this.grpButtons);
            this.tabPalletLabels.Location = new System.Drawing.Point(4, 31);
            this.tabPalletLabels.Name = "tabPalletLabels";
            this.tabPalletLabels.Padding = new System.Windows.Forms.Padding(3);
            this.tabPalletLabels.Size = new System.Drawing.Size(471, 619);
            this.tabPalletLabels.TabIndex = 0;
            this.tabPalletLabels.Text = "Pallet Labels";
            this.tabPalletLabels.UseVisualStyleBackColor = true;
            // 
            // grpPalletPrintInfo
            // 
            this.grpPalletPrintInfo.Controls.Add(this.tbPalletLabelNumber);
            this.grpPalletPrintInfo.Controls.Add(this.tbPalletCount);
            this.grpPalletPrintInfo.Controls.Add(this.lblPalletCount);
            this.grpPalletPrintInfo.Controls.Add(this.btnPalletReprint);
            this.grpPalletPrintInfo.Controls.Add(this.tbPalletQuantity);
            this.grpPalletPrintInfo.Controls.Add(this.cboPalletPrinter);
            this.grpPalletPrintInfo.Controls.Add(this.lblPalletPrintStatus);
            this.grpPalletPrintInfo.Controls.Add(this.lblPalletQty);
            this.grpPalletPrintInfo.Controls.Add(this.lblPalletPrinter);
            this.grpPalletPrintInfo.Controls.Add(this.lblPalletTotLabels);
            this.grpPalletPrintInfo.Controls.Add(this.tbPalletTotalLabels);
            this.grpPalletPrintInfo.Controls.Add(this.lblPalletLabelNo);
            this.grpPalletPrintInfo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPalletPrintInfo.Location = new System.Drawing.Point(3, 340);
            this.grpPalletPrintInfo.Name = "grpPalletPrintInfo";
            this.grpPalletPrintInfo.Size = new System.Drawing.Size(465, 224);
            this.grpPalletPrintInfo.TabIndex = 69;
            this.grpPalletPrintInfo.TabStop = false;
            this.grpPalletPrintInfo.Text = "Print Info";
            // 
            // tbPalletLabelNumber
            // 
            this.tbPalletLabelNumber.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletLabelNumber.Location = new System.Drawing.Point(189, 21);
            this.tbPalletLabelNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletLabelNumber.MaxLength = 15;
            this.tbPalletLabelNumber.Name = "tbPalletLabelNumber";
            this.tbPalletLabelNumber.Size = new System.Drawing.Size(263, 29);
            this.tbPalletLabelNumber.TabIndex = 57;
            this.tbPalletLabelNumber.Text = "\r\n                           ";
            this.tbPalletLabelNumber.Visible = false;
            // 
            // tbPalletCount
            // 
            this.tbPalletCount.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletCount.Location = new System.Drawing.Point(189, 51);
            this.tbPalletCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletCount.MaxLength = 40;
            this.tbPalletCount.Name = "tbPalletCount";
            this.tbPalletCount.Size = new System.Drawing.Size(263, 29);
            this.tbPalletCount.TabIndex = 39;
            this.tbPalletCount.Visible = false;
            // 
            // lblPalletCount
            // 
            this.lblPalletCount.AutoSize = true;
            this.lblPalletCount.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletCount.Location = new System.Drawing.Point(128, 54);
            this.lblPalletCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletCount.Name = "lblPalletCount";
            this.lblPalletCount.Size = new System.Drawing.Size(56, 22);
            this.lblPalletCount.TabIndex = 38;
            this.lblPalletCount.Text = "Count:";
            this.lblPalletCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletCount.Visible = false;
            // 
            // tbPalletQuantity
            // 
            this.tbPalletQuantity.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletQuantity.Location = new System.Drawing.Point(189, 142);
            this.tbPalletQuantity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletQuantity.MaxLength = 15;
            this.tbPalletQuantity.Name = "tbPalletQuantity";
            this.tbPalletQuantity.Size = new System.Drawing.Size(110, 29);
            this.tbPalletQuantity.TabIndex = 45;
            this.tbPalletQuantity.Text = "1";
            // 
            // cboPalletPrinter
            // 
            this.cboPalletPrinter.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPalletPrinter.FormattingEnabled = true;
            this.cboPalletPrinter.Items.AddRange(new object[] {
            "SATO CL6NX 305dpi 1",
            "SATO CL6NX 305dpi 2"});
            this.cboPalletPrinter.Location = new System.Drawing.Point(189, 111);
            this.cboPalletPrinter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboPalletPrinter.Name = "cboPalletPrinter";
            this.cboPalletPrinter.Size = new System.Drawing.Size(263, 30);
            this.cboPalletPrinter.TabIndex = 64;
            // 
            // lblPalletPrintStatus
            // 
            this.lblPalletPrintStatus.AutoSize = true;
            this.lblPalletPrintStatus.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletPrintStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletPrintStatus.Location = new System.Drawing.Point(307, 171);
            this.lblPalletPrintStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletPrintStatus.Name = "lblPalletPrintStatus";
            this.lblPalletPrintStatus.Size = new System.Drawing.Size(76, 22);
            this.lblPalletPrintStatus.TabIndex = 44;
            this.lblPalletPrintStatus.Text = "Quantity:";
            this.lblPalletPrintStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPalletQty
            // 
            this.lblPalletQty.AutoSize = true;
            this.lblPalletQty.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletQty.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletQty.Location = new System.Drawing.Point(108, 145);
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
            this.lblPalletPrinter.Location = new System.Drawing.Point(123, 115);
            this.lblPalletPrinter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletPrinter.Name = "lblPalletPrinter";
            this.lblPalletPrinter.Size = new System.Drawing.Size(61, 22);
            this.lblPalletPrinter.TabIndex = 62;
            this.lblPalletPrinter.Text = "Printer:";
            this.lblPalletPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPalletTotLabels
            // 
            this.lblPalletTotLabels.AutoSize = true;
            this.lblPalletTotLabels.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletTotLabels.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletTotLabels.Location = new System.Drawing.Point(88, 84);
            this.lblPalletTotLabels.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletTotLabels.Name = "lblPalletTotLabels";
            this.lblPalletTotLabels.Size = new System.Drawing.Size(96, 22);
            this.lblPalletTotLabels.TabIndex = 54;
            this.lblPalletTotLabels.Text = "Total Labels:";
            this.lblPalletTotLabels.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletTotLabels.Visible = false;
            // 
            // tbPalletTotalLabels
            // 
            this.tbPalletTotalLabels.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletTotalLabels.Location = new System.Drawing.Point(189, 81);
            this.tbPalletTotalLabels.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletTotalLabels.MaxLength = 15;
            this.tbPalletTotalLabels.Name = "tbPalletTotalLabels";
            this.tbPalletTotalLabels.Size = new System.Drawing.Size(263, 29);
            this.tbPalletTotalLabels.TabIndex = 55;
            this.tbPalletTotalLabels.Visible = false;
            // 
            // lblPalletLabelNo
            // 
            this.lblPalletLabelNo.AutoSize = true;
            this.lblPalletLabelNo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletLabelNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletLabelNo.Location = new System.Drawing.Point(107, 24);
            this.lblPalletLabelNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletLabelNo.Name = "lblPalletLabelNo";
            this.lblPalletLabelNo.Size = new System.Drawing.Size(77, 22);
            this.lblPalletLabelNo.TabIndex = 56;
            this.lblPalletLabelNo.Text = "Label No:";
            this.lblPalletLabelNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletLabelNo.Visible = false;
            // 
            // grpPalletLabelData
            // 
            this.grpPalletLabelData.Controls.Add(this.lblPalletProductName);
            this.grpPalletLabelData.Controls.Add(this.lblPalletGMID);
            this.grpPalletLabelData.Controls.Add(this.tbPalletProductName);
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
            this.grpPalletLabelData.Location = new System.Drawing.Point(3, 4);
            this.grpPalletLabelData.Name = "grpPalletLabelData";
            this.grpPalletLabelData.Size = new System.Drawing.Size(465, 334);
            this.grpPalletLabelData.TabIndex = 68;
            this.grpPalletLabelData.TabStop = false;
            this.grpPalletLabelData.Text = "Label Data";
            // 
            // lblPalletProductName
            // 
            this.lblPalletProductName.AutoSize = true;
            this.lblPalletProductName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletProductName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletProductName.Location = new System.Drawing.Point(70, 25);
            this.lblPalletProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletProductName.Name = "lblPalletProductName";
            this.lblPalletProductName.Size = new System.Drawing.Size(114, 22);
            this.lblPalletProductName.TabIndex = 63;
            this.lblPalletProductName.Text = "Product Name:";
            this.lblPalletProductName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPalletGMID
            // 
            this.lblPalletGMID.AutoSize = true;
            this.lblPalletGMID.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletGMID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletGMID.Location = new System.Drawing.Point(126, 115);
            this.lblPalletGMID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletGMID.Name = "lblPalletGMID";
            this.lblPalletGMID.Size = new System.Drawing.Size(58, 22);
            this.lblPalletGMID.TabIndex = 36;
            this.lblPalletGMID.Text = "GMID:";
            this.lblPalletGMID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletGMID.Visible = false;
            // 
            // tbPalletProductName
            // 
            this.tbPalletProductName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletProductName.Location = new System.Drawing.Point(189, 22);
            this.tbPalletProductName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletProductName.MaxLength = 50;
            this.tbPalletProductName.Name = "tbPalletProductName";
            this.tbPalletProductName.Size = new System.Drawing.Size(263, 29);
            this.tbPalletProductName.TabIndex = 66;
            this.tbPalletProductName.Visible = false;
            // 
            // tbPalletGMID
            // 
            this.tbPalletGMID.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletGMID.Location = new System.Drawing.Point(189, 112);
            this.tbPalletGMID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletGMID.MaxLength = 40;
            this.tbPalletGMID.Name = "tbPalletGMID";
            this.tbPalletGMID.Size = new System.Drawing.Size(263, 29);
            this.tbPalletGMID.TabIndex = 37;
            this.tbPalletGMID.Visible = false;
            // 
            // tbPalletNetUnits
            // 
            this.tbPalletNetUnits.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletNetUnits.Location = new System.Drawing.Point(189, 292);
            this.tbPalletNetUnits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletNetUnits.MaxLength = 40;
            this.tbPalletNetUnits.Name = "tbPalletNetUnits";
            this.tbPalletNetUnits.Size = new System.Drawing.Size(263, 29);
            this.tbPalletNetUnits.TabIndex = 41;
            this.tbPalletNetUnits.Visible = false;
            // 
            // lblPalletNetUnits
            // 
            this.lblPalletNetUnits.AutoSize = true;
            this.lblPalletNetUnits.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletNetUnits.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletNetUnits.Location = new System.Drawing.Point(104, 295);
            this.lblPalletNetUnits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletNetUnits.Name = "lblPalletNetUnits";
            this.lblPalletNetUnits.Size = new System.Drawing.Size(80, 22);
            this.lblPalletNetUnits.TabIndex = 40;
            this.lblPalletNetUnits.Text = "Net Units:";
            this.lblPalletNetUnits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletNetUnits.Visible = false;
            // 
            // lblPalletNetUnits_AI
            // 
            this.lblPalletNetUnits_AI.AutoSize = true;
            this.lblPalletNetUnits_AI.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletNetUnits_AI.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletNetUnits_AI.Location = new System.Drawing.Point(84, 265);
            this.lblPalletNetUnits_AI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletNetUnits_AI.Name = "lblPalletNetUnits_AI";
            this.lblPalletNetUnits_AI.Size = new System.Drawing.Size(100, 22);
            this.lblPalletNetUnits_AI.TabIndex = 42;
            this.lblPalletNetUnits_AI.Text = "NetUnits_AI:";
            this.lblPalletNetUnits_AI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletNetUnits_AI.Visible = false;
            // 
            // tbPalletNetUnits_AI
            // 
            this.tbPalletNetUnits_AI.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletNetUnits_AI.Location = new System.Drawing.Point(189, 262);
            this.tbPalletNetUnits_AI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletNetUnits_AI.MaxLength = 15;
            this.tbPalletNetUnits_AI.Name = "tbPalletNetUnits_AI";
            this.tbPalletNetUnits_AI.Size = new System.Drawing.Size(263, 29);
            this.tbPalletNetUnits_AI.TabIndex = 43;
            this.tbPalletNetUnits_AI.Visible = false;
            // 
            // tbPalletProductionLineNumber
            // 
            this.tbPalletProductionLineNumber.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletProductionLineNumber.Location = new System.Drawing.Point(189, 202);
            this.tbPalletProductionLineNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletProductionLineNumber.MaxLength = 15;
            this.tbPalletProductionLineNumber.Name = "tbPalletProductionLineNumber";
            this.tbPalletProductionLineNumber.Size = new System.Drawing.Size(263, 29);
            this.tbPalletProductionLineNumber.TabIndex = 61;
            this.tbPalletProductionLineNumber.Visible = false;
            // 
            // lblPalletBatchNo
            // 
            this.lblPalletBatchNo.AutoSize = true;
            this.lblPalletBatchNo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletBatchNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletBatchNo.Location = new System.Drawing.Point(85, 55);
            this.lblPalletBatchNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletBatchNo.Name = "lblPalletBatchNo";
            this.lblPalletBatchNo.Size = new System.Drawing.Size(99, 22);
            this.lblPalletBatchNo.TabIndex = 46;
            this.lblPalletBatchNo.Text = "Lot Number:";
            this.lblPalletBatchNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletBatchNo.Visible = false;
            // 
            // lblPalletLineNo
            // 
            this.lblPalletLineNo.AutoSize = true;
            this.lblPalletLineNo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletLineNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletLineNo.Location = new System.Drawing.Point(78, 205);
            this.lblPalletLineNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletLineNo.Name = "lblPalletLineNo";
            this.lblPalletLineNo.Size = new System.Drawing.Size(106, 22);
            this.lblPalletLineNo.TabIndex = 60;
            this.lblPalletLineNo.Text = "Line Number:";
            this.lblPalletLineNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletLineNo.Visible = false;
            // 
            // tbPalletBatchNumber
            // 
            this.tbPalletBatchNumber.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletBatchNumber.Location = new System.Drawing.Point(189, 52);
            this.tbPalletBatchNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletBatchNumber.MaxLength = 40;
            this.tbPalletBatchNumber.Name = "tbPalletBatchNumber";
            this.tbPalletBatchNumber.Size = new System.Drawing.Size(263, 29);
            this.tbPalletBatchNumber.TabIndex = 47;
            this.tbPalletBatchNumber.Visible = false;
            // 
            // tbPalletNetVolume
            // 
            this.tbPalletNetVolume.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletNetVolume.Location = new System.Drawing.Point(189, 232);
            this.tbPalletNetVolume.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletNetVolume.MaxLength = 15;
            this.tbPalletNetVolume.Name = "tbPalletNetVolume";
            this.tbPalletNetVolume.Size = new System.Drawing.Size(263, 29);
            this.tbPalletNetVolume.TabIndex = 59;
            this.tbPalletNetVolume.Visible = false;
            // 
            // tbPalletProductionDate
            // 
            this.tbPalletProductionDate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletProductionDate.Location = new System.Drawing.Point(189, 172);
            this.tbPalletProductionDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletProductionDate.MaxLength = 40;
            this.tbPalletProductionDate.Name = "tbPalletProductionDate";
            this.tbPalletProductionDate.Size = new System.Drawing.Size(263, 29);
            this.tbPalletProductionDate.TabIndex = 49;
            this.tbPalletProductionDate.Visible = false;
            // 
            // lblPalletNetWt
            // 
            this.lblPalletNetWt.AutoSize = true;
            this.lblPalletNetWt.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletNetWt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletNetWt.Location = new System.Drawing.Point(17, 235);
            this.lblPalletNetWt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletNetWt.Name = "lblPalletNetWt";
            this.lblPalletNetWt.Size = new System.Drawing.Size(167, 22);
            this.lblPalletNetWt.TabIndex = 58;
            this.lblPalletNetWt.Text = "Net Weight or Volume:";
            this.lblPalletNetWt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletNetWt.Visible = false;
            // 
            // tbPalletSSCC
            // 
            this.tbPalletSSCC.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletSSCC.Location = new System.Drawing.Point(189, 142);
            this.tbPalletSSCC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletSSCC.MaxLength = 40;
            this.tbPalletSSCC.Name = "tbPalletSSCC";
            this.tbPalletSSCC.Size = new System.Drawing.Size(263, 29);
            this.tbPalletSSCC.TabIndex = 51;
            this.tbPalletSSCC.Visible = false;
            // 
            // lblPalletProdDate
            // 
            this.lblPalletProdDate.AutoSize = true;
            this.lblPalletProdDate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletProdDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletProdDate.Location = new System.Drawing.Point(59, 175);
            this.lblPalletProdDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletProdDate.Name = "lblPalletProdDate";
            this.lblPalletProdDate.Size = new System.Drawing.Size(125, 22);
            this.lblPalletProdDate.TabIndex = 48;
            this.lblPalletProdDate.Text = "Production Date:";
            this.lblPalletProdDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletProdDate.Visible = false;
            // 
            // lblPalletSSCC
            // 
            this.lblPalletSSCC.AutoSize = true;
            this.lblPalletSSCC.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletSSCC.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletSSCC.Location = new System.Drawing.Point(130, 145);
            this.lblPalletSSCC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletSSCC.Name = "lblPalletSSCC";
            this.lblPalletSSCC.Size = new System.Drawing.Size(54, 22);
            this.lblPalletSSCC.TabIndex = 50;
            this.lblPalletSSCC.Text = "SSCC:";
            this.lblPalletSSCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletSSCC.Visible = false;
            // 
            // lblPalletGTIN
            // 
            this.lblPalletGTIN.AutoSize = true;
            this.lblPalletGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletGTIN.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletGTIN.Location = new System.Drawing.Point(131, 83);
            this.lblPalletGTIN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalletGTIN.Name = "lblPalletGTIN";
            this.lblPalletGTIN.Size = new System.Drawing.Size(53, 22);
            this.lblPalletGTIN.TabIndex = 52;
            this.lblPalletGTIN.Text = "GTIN:";
            this.lblPalletGTIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPalletGTIN.Visible = false;
            // 
            // tbPalletGTIN
            // 
            this.tbPalletGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPalletGTIN.Location = new System.Drawing.Point(189, 82);
            this.tbPalletGTIN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPalletGTIN.MaxLength = 15;
            this.tbPalletGTIN.Name = "tbPalletGTIN";
            this.tbPalletGTIN.Size = new System.Drawing.Size(263, 29);
            this.tbPalletGTIN.TabIndex = 53;
            this.tbPalletGTIN.Visible = false;
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add(this.btnPalletClose);
            this.grpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpButtons.Location = new System.Drawing.Point(3, 554);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Size = new System.Drawing.Size(465, 62);
            this.grpButtons.TabIndex = 67;
            this.grpButtons.TabStop = false;
            // 
            // btnPalletClose
            // 
            this.btnPalletClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPalletClose.Location = new System.Drawing.Point(384, 16);
            this.btnPalletClose.Name = "btnPalletClose";
            this.btnPalletClose.Size = new System.Drawing.Size(75, 39);
            this.btnPalletClose.TabIndex = 0;
            this.btnPalletClose.Text = "Close";
            this.btnPalletClose.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 654);
            this.Controls.Add(this.tabPrintForms);
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmPrint";
            this.Text = "Label Print Form";
            this.Load += new System.EventHandler(this.PrintForm_Load);
            this.tabPrintForms.ResumeLayout(false);
            this.tabPalletLabels.ResumeLayout(false);
            this.grpPalletPrintInfo.ResumeLayout(false);
            this.grpPalletPrintInfo.PerformLayout();
            this.grpPalletLabelData.ResumeLayout(false);
            this.grpPalletLabelData.PerformLayout();
            this.grpButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPalletReprint;
        private System.Windows.Forms.TabControl tabPrintForms;
        private System.Windows.Forms.TabPage tabPalletLabels;
        private System.Windows.Forms.GroupBox grpButtons;
        private System.Windows.Forms.Button btnPalletClose;
        private System.Windows.Forms.TextBox tbPalletProductName;
        private System.Windows.Forms.ComboBox cboPalletPrinter;
        private System.Windows.Forms.Label lblPalletProductName;
        private System.Windows.Forms.Label lblPalletPrinter;
        private System.Windows.Forms.TextBox tbPalletProductionLineNumber;
        private System.Windows.Forms.Label lblPalletLineNo;
        private System.Windows.Forms.TextBox tbPalletNetVolume;
        private System.Windows.Forms.Label lblPalletNetWt;
        private System.Windows.Forms.TextBox tbPalletLabelNumber;
        private System.Windows.Forms.Label lblPalletLabelNo;
        private System.Windows.Forms.TextBox tbPalletTotalLabels;
        private System.Windows.Forms.Label lblPalletTotLabels;
        private System.Windows.Forms.TextBox tbPalletGTIN;
        private System.Windows.Forms.Label lblPalletGTIN;
        private System.Windows.Forms.Label lblPalletSSCC;
        private System.Windows.Forms.Label lblPalletProdDate;
        private System.Windows.Forms.TextBox tbPalletSSCC;
        private System.Windows.Forms.TextBox tbPalletProductionDate;
        private System.Windows.Forms.TextBox tbPalletBatchNumber;
        private System.Windows.Forms.Label lblPalletBatchNo;
        private System.Windows.Forms.Label lblPalletQty;
        private System.Windows.Forms.TextBox tbPalletQuantity;
        private System.Windows.Forms.TextBox tbPalletNetUnits_AI;
        private System.Windows.Forms.Label lblPalletNetUnits_AI;
        private System.Windows.Forms.Label lblPalletNetUnits;
        private System.Windows.Forms.Label lblPalletCount;
        private System.Windows.Forms.TextBox tbPalletNetUnits;
        private System.Windows.Forms.TextBox tbPalletCount;
        private System.Windows.Forms.TextBox tbPalletGMID;
        private System.Windows.Forms.Label lblPalletGMID;
        private System.Windows.Forms.GroupBox grpPalletPrintInfo;
        private System.Windows.Forms.GroupBox grpPalletLabelData;
        private System.Windows.Forms.Label lblPalletPrintStatus;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

