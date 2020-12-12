
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
            this.grpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGTIN
            // 
            this.lblGTIN.AutoSize = true;
            this.lblGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGTIN.Location = new System.Drawing.Point(12, 15);
            this.lblGTIN.Name = "lblGTIN";
            this.lblGTIN.Size = new System.Drawing.Size(49, 22);
            this.lblGTIN.TabIndex = 0;
            this.lblGTIN.Text = "GTIN";
            // 
            // lblLotNo
            // 
            this.lblLotNo.AutoSize = true;
            this.lblLotNo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotNo.Location = new System.Drawing.Point(12, 48);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(58, 22);
            this.lblLotNo.TabIndex = 0;
            this.lblLotNo.Text = "Lot No";
            // 
            // lblProdDate
            // 
            this.lblProdDate.AutoSize = true;
            this.lblProdDate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdDate.Location = new System.Drawing.Point(12, 80);
            this.lblProdDate.Name = "lblProdDate";
            this.lblProdDate.Size = new System.Drawing.Size(75, 22);
            this.lblProdDate.TabIndex = 0;
            this.lblProdDate.Text = "ProdDate";
            // 
            // lblProdName
            // 
            this.lblProdName.AutoSize = true;
            this.lblProdName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdName.Location = new System.Drawing.Point(12, 112);
            this.lblProdName.Name = "lblProdName";
            this.lblProdName.Size = new System.Drawing.Size(89, 22);
            this.lblProdName.TabIndex = 0;
            this.lblProdName.Text = "Prod Name";
            // 
            // tbGTIN
            // 
            this.tbGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbGTIN.Location = new System.Drawing.Point(125, 12);
            this.tbGTIN.Mask = "00000000000000";
            this.tbGTIN.Name = "tbGTIN";
            this.tbGTIN.Size = new System.Drawing.Size(122, 29);
            this.tbGTIN.TabIndex = 1;
            this.tbGTIN.Text = "11223344556677";
            // 
            // tbLotNo
            // 
            this.tbLotNo.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbLotNo.Location = new System.Drawing.Point(125, 45);
            this.tbLotNo.Mask = "AAAAAAAAAAACCCCCCCCCC";
            this.tbLotNo.Name = "tbLotNo";
            this.tbLotNo.Size = new System.Drawing.Size(186, 29);
            this.tbLotNo.TabIndex = 2;
            this.tbLotNo.Text = "Lot1212 2020.1";
            // 
            // tbProdDate
            // 
            this.tbProdDate.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbProdDate.Location = new System.Drawing.Point(125, 77);
            this.tbProdDate.Mask = "00->L<LL-0000";
            this.tbProdDate.Name = "tbProdDate";
            this.tbProdDate.Size = new System.Drawing.Size(99, 29);
            this.tbProdDate.TabIndex = 3;
            this.tbProdDate.Text = "12Dec2020";
            this.tbProdDate.ValidatingType = typeof(System.DateTime);
            // 
            // tbProdName
            // 
            this.tbProdName.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.tbProdName.Location = new System.Drawing.Point(125, 109);
            this.tbProdName.MaxLength = 50;
            this.tbProdName.Multiline = true;
            this.tbProdName.Name = "tbProdName";
            this.tbProdName.Size = new System.Drawing.Size(186, 49);
            this.tbProdName.TabIndex = 4;
            // 
            // btnSetMsg
            // 
            this.btnSetMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetMsg.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSetMsg.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.btnSetMsg.Location = new System.Drawing.Point(6, 15);
            this.btnSetMsg.Name = "btnSetMsg";
            this.btnSetMsg.Size = new System.Drawing.Size(75, 30);
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
            this.grpButtons.Location = new System.Drawing.Point(0, 163);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Size = new System.Drawing.Size(321, 51);
            this.grpButtons.TabIndex = 4;
            this.grpButtons.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.btnClose.Location = new System.Drawing.Point(240, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmScannerMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(321, 214);
            this.Controls.Add(this.grpButtons);
            this.Controls.Add(this.tbProdName);
            this.Controls.Add(this.tbProdDate);
            this.Controls.Add(this.tbLotNo);
            this.Controls.Add(this.tbGTIN);
            this.Controls.Add(this.lblProdName);
            this.Controls.Add(this.lblProdDate);
            this.Controls.Add(this.lblLotNo);
            this.Controls.Add(this.lblGTIN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmScannerMsg";
            this.Text = "Scanner Simulation Message";
            this.Load += new System.EventHandler(this.frmScannerMsg_Load);
            this.grpButtons.ResumeLayout(false);
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
    }
}