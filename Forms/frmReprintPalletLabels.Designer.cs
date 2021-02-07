namespace ITS.Exwold.Desktop
{
  partial class frmReprintPalletLabels
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
            this.cmbSalesBatches = new System.Windows.Forms.ComboBox();
            this.cmbSSCCs = new System.Windows.Forms.ComboBox();
            this.btnReprint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpButtons = new System.Windows.Forms.GroupBox();
            this.grpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbSalesBatches
            // 
            this.cmbSalesBatches.FormattingEnabled = true;
            this.cmbSalesBatches.Location = new System.Drawing.Point(2, 32);
            this.cmbSalesBatches.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSalesBatches.Name = "cmbSalesBatches";
            this.cmbSalesBatches.Size = new System.Drawing.Size(180, 30);
            this.cmbSalesBatches.TabIndex = 0;
            this.cmbSalesBatches.SelectedIndexChanged += new System.EventHandler(this.cmbSalesBatches_SelectedIndexChanged);
            // 
            // cmbSSCCs
            // 
            this.cmbSSCCs.FormattingEnabled = true;
            this.cmbSSCCs.Location = new System.Drawing.Point(184, 32);
            this.cmbSSCCs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSSCCs.Name = "cmbSSCCs";
            this.cmbSSCCs.Size = new System.Drawing.Size(205, 30);
            this.cmbSSCCs.TabIndex = 0;
            // 
            // btnReprint
            // 
            this.btnReprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReprint.Location = new System.Drawing.Point(3, 18);
            this.btnReprint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(141, 39);
            this.btnReprint.TabIndex = 1;
            this.btnReprint.Text = "Reprint Labels";
            this.btnReprint.UseVisualStyleBackColor = true;
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(248, 18);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(141, 39);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sales Batch Number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(184, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pallet SSCC Number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add(this.btnCancel);
            this.grpButtons.Controls.Add(this.btnReprint);
            this.grpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpButtons.Location = new System.Drawing.Point(0, 62);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Size = new System.Drawing.Size(395, 65);
            this.grpButtons.TabIndex = 3;
            this.grpButtons.TabStop = false;
            // 
            // frmReprintPalletLabels
            // 
            this.AcceptButton = this.btnReprint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(395, 127);
            this.Controls.Add(this.grpButtons);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSSCCs);
            this.Controls.Add(this.cmbSalesBatches);
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmReprintPalletLabels";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reprint Pallet Labels";
            this.Load += new System.EventHandler(this.frmReprintPalletLabels_Load);
            this.grpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

        private System.Windows.Forms.ComboBox cmbSalesBatches;
        private System.Windows.Forms.ComboBox cmbSSCCs;
        private System.Windows.Forms.Button btnReprint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpButtons;
    }
}