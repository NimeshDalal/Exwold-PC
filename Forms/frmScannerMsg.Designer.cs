
namespace ITS.Exwold.Desktop
{
    partial class frmScannerMsg
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
            this.lblGTIN = new System.Windows.Forms.Label();
            this.lblLotNo = new System.Windows.Forms.Label();
            this.lblProdDate = new System.Windows.Forms.Label();
            this.lblProdName = new System.Windows.Forms.Label();
            this.tbGTIN = new System.Windows.Forms.MaskedTextBox();
            this.tbLotNo = new System.Windows.Forms.MaskedTextBox();
            this.tbProdDate = new System.Windows.Forms.MaskedTextBox();
            this.tbProdName = new System.Windows.Forms.TextBox();
            this.btnSetMsg = new System.Windows.Forms.Button();
            this.grpButtons = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.rdoInnerLabel = new System.Windows.Forms.RadioButton();
            this.rdoOuterLabel = new System.Windows.Forms.RadioButton();
            this.rdoOther = new System.Windows.Forms.RadioButton();
            this.grpSelection = new System.Windows.Forms.GroupBox();
            this.grpButtons.SuspendLayout();
            this.grpSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGTIN
            // 
            this.lblGTIN.AutoSize = true;
            this.lblGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGTIN.Location = new System.Drawing.Point(3, 65);
            this.lblGTIN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGTIN.Name = "lblGTIN";
            this.lblGTIN.Size = new System.Drawing.Size(49, 22);
            this.lblGTIN.TabIndex = 0;
            this.lblGTIN.Text = "GTIN";
            // 
            // lblLotNo
            // 
            this.lblLotNo.AutoSize = true;
            this.lblLotNo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotNo.Location = new System.Drawing.Point(3, 95);
            this.lblLotNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(58, 22);
            this.lblLotNo.TabIndex = 0;
            this.lblLotNo.Text = "Lot No";
            // 
            // lblProdDate
            // 
            this.lblProdDate.AutoSize = true;
            this.lblProdDate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdDate.Location = new System.Drawing.Point(3, 125);
            this.lblProdDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProdDate.Name = "lblProdDate";
            this.lblProdDate.Size = new System.Drawing.Size(75, 22);
            this.lblProdDate.TabIndex = 0;
            this.lblProdDate.Text = "ProdDate";
            // 
            // lblProdName
            // 
            this.lblProdName.AutoSize = true;
            this.lblProdName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdName.Location = new System.Drawing.Point(3, 155);
            this.lblProdName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProdName.Name = "lblProdName";
            this.lblProdName.Size = new System.Drawing.Size(89, 22);
            this.lblProdName.TabIndex = 0;
            this.lblProdName.Text = "Prod Name";
            // 
            // tbGTIN
            // 
            this.tbGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbGTIN.Location = new System.Drawing.Point(106, 60);
            this.tbGTIN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGTIN.Mask = "00000000000000";
            this.tbGTIN.Name = "tbGTIN";
            this.tbGTIN.Size = new System.Drawing.Size(181, 29);
            this.tbGTIN.TabIndex = 1;
            this.tbGTIN.Text = "11223344556677";
            // 
            // tbLotNo
            // 
            this.tbLotNo.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbLotNo.Location = new System.Drawing.Point(106, 90);
            this.tbLotNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLotNo.Mask = "AAAAAAAAAAACCCCCCCCCC";
            this.tbLotNo.Name = "tbLotNo";
            this.tbLotNo.Size = new System.Drawing.Size(277, 29);
            this.tbLotNo.TabIndex = 2;
            this.tbLotNo.Text = "Lot1212 2020.1";
            // 
            // tbProdDate
            // 
            this.tbProdDate.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbProdDate.Location = new System.Drawing.Point(106, 120);
            this.tbProdDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbProdDate.Mask = "00->L<LL-0000";
            this.tbProdDate.Name = "tbProdDate";
            this.tbProdDate.Size = new System.Drawing.Size(146, 29);
            this.tbProdDate.TabIndex = 3;
            this.tbProdDate.Text = "12Dec2020";
            this.tbProdDate.ValidatingType = typeof(System.DateTime);
            // 
            // tbProdName
            // 
            this.tbProdName.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbProdName.Location = new System.Drawing.Point(106, 150);
            this.tbProdName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbProdName.MaxLength = 50;
            this.tbProdName.Multiline = true;
            this.tbProdName.Name = "tbProdName";
            this.tbProdName.Size = new System.Drawing.Size(277, 80);
            this.tbProdName.TabIndex = 4;
            // 
            // btnSetMsg
            // 
            this.btnSetMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetMsg.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSetMsg.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.btnSetMsg.Location = new System.Drawing.Point(3, 19);
            this.btnSetMsg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSetMsg.Name = "btnSetMsg";
            this.btnSetMsg.Size = new System.Drawing.Size(148, 39);
            this.btnSetMsg.TabIndex = 5;
            this.btnSetMsg.Text = "Set Msg";
            this.btnSetMsg.UseVisualStyleBackColor = true;
            this.btnSetMsg.Click += new System.EventHandler(this.btnSetMsg_Click);
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add(this.btnClose);
            this.grpButtons.Controls.Add(this.btnSetMsg);
            this.grpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpButtons.Location = new System.Drawing.Point(0, 328);
            this.grpButtons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpButtons.Size = new System.Drawing.Size(386, 64);
            this.grpButtons.TabIndex = 4;
            this.grpButtons.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.btnClose.Location = new System.Drawing.Point(233, 19);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(148, 39);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rdoInnerLabel
            // 
            this.rdoInnerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoInnerLabel.AutoSize = true;
            this.rdoInnerLabel.Checked = true;
            this.rdoInnerLabel.Location = new System.Drawing.Point(8, 20);
            this.rdoInnerLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoInnerLabel.Name = "rdoInnerLabel";
            this.rdoInnerLabel.Size = new System.Drawing.Size(106, 26);
            this.rdoInnerLabel.TabIndex = 5;
            this.rdoInnerLabel.TabStop = true;
            this.rdoInnerLabel.Text = "Inner Label";
            this.rdoInnerLabel.UseVisualStyleBackColor = true;
            this.rdoInnerLabel.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoOuterLabel
            // 
            this.rdoOuterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoOuterLabel.AutoSize = true;
            this.rdoOuterLabel.Location = new System.Drawing.Point(123, 20);
            this.rdoOuterLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoOuterLabel.Name = "rdoOuterLabel";
            this.rdoOuterLabel.Size = new System.Drawing.Size(110, 26);
            this.rdoOuterLabel.TabIndex = 5;
            this.rdoOuterLabel.Text = "Outer Label";
            this.rdoOuterLabel.UseVisualStyleBackColor = true;
            this.rdoOuterLabel.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoOther
            // 
            this.rdoOther.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdoOther.AutoSize = true;
            this.rdoOther.Location = new System.Drawing.Point(241, 20);
            this.rdoOther.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdoOther.Name = "rdoOther";
            this.rdoOther.Size = new System.Drawing.Size(68, 26);
            this.rdoOther.TabIndex = 5;
            this.rdoOther.Text = "Other";
            this.rdoOther.UseVisualStyleBackColor = true;
            this.rdoOther.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // grpSelection
            // 
            this.grpSelection.Controls.Add(this.rdoOther);
            this.grpSelection.Controls.Add(this.rdoInnerLabel);
            this.grpSelection.Controls.Add(this.rdoOuterLabel);
            this.grpSelection.Location = new System.Drawing.Point(3, 3);
            this.grpSelection.Name = "grpSelection";
            this.grpSelection.Size = new System.Drawing.Size(380, 56);
            this.grpSelection.TabIndex = 6;
            this.grpSelection.TabStop = false;
            // 
            // frmScannerMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(386, 392);
            this.Controls.Add(this.grpSelection);
            this.Controls.Add(this.grpButtons);
            this.Controls.Add(this.tbProdName);
            this.Controls.Add(this.tbProdDate);
            this.Controls.Add(this.tbLotNo);
            this.Controls.Add(this.tbGTIN);
            this.Controls.Add(this.lblProdName);
            this.Controls.Add(this.lblProdDate);
            this.Controls.Add(this.lblLotNo);
            this.Controls.Add(this.lblGTIN);
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmScannerMsg";
            this.Text = "Scanner Simulation Message";
            this.Load += new System.EventHandler(this.frmScannerMsg_Load);
            this.grpButtons.ResumeLayout(false);
            this.grpSelection.ResumeLayout(false);
            this.grpSelection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGTIN;
        private System.Windows.Forms.Label lblLotNo;
        private System.Windows.Forms.Label lblProdDate;
        private System.Windows.Forms.Label lblProdName;
        private System.Windows.Forms.MaskedTextBox tbGTIN;
        private System.Windows.Forms.MaskedTextBox tbLotNo;
        private System.Windows.Forms.MaskedTextBox tbProdDate;
        private System.Windows.Forms.TextBox tbProdName;
        private System.Windows.Forms.Button btnSetMsg;
        private System.Windows.Forms.GroupBox grpButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton rdoInnerLabel;
        private System.Windows.Forms.RadioButton rdoOuterLabel;
        private System.Windows.Forms.RadioButton rdoOther;
        private System.Windows.Forms.GroupBox grpSelection;
    }
}