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
      this.SuspendLayout();
      // 
      // cmbSalesBatches
      // 
      this.cmbSalesBatches.FormattingEnabled = true;
      this.cmbSalesBatches.Location = new System.Drawing.Point(12, 45);
      this.cmbSalesBatches.Name = "cmbSalesBatches";
      this.cmbSalesBatches.Size = new System.Drawing.Size(121, 21);
      this.cmbSalesBatches.TabIndex = 0;
      this.cmbSalesBatches.SelectedIndexChanged += new System.EventHandler(this.cmbSalesBatches_SelectedIndexChanged);
      // 
      // cmbSSCCs
      // 
      this.cmbSSCCs.FormattingEnabled = true;
      this.cmbSSCCs.Location = new System.Drawing.Point(149, 45);
      this.cmbSSCCs.Name = "cmbSSCCs";
      this.cmbSSCCs.Size = new System.Drawing.Size(137, 21);
      this.cmbSSCCs.TabIndex = 0;
      // 
      // btnReprint
      // 
      this.btnReprint.Location = new System.Drawing.Point(307, 43);
      this.btnReprint.Name = "btnReprint";
      this.btnReprint.Size = new System.Drawing.Size(94, 23);
      this.btnReprint.TabIndex = 1;
      this.btnReprint.Text = "Reprint Labels";
      this.btnReprint.UseVisualStyleBackColor = true;
      this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(307, 72);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(94, 23);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 26);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(104, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Sales Batch Number";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(148, 26);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(104, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Pallet SSCC Number";
      // 
      // ReprintPalletLabels
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(413, 122);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnReprint);
      this.Controls.Add(this.cmbSSCCs);
      this.Controls.Add(this.cmbSalesBatches);
      this.Name = "ReprintPalletLabels";
      this.Text = "ReprintPalletLabels";
      this.Load += new System.EventHandler(this.frmReprintPalletLabels_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox cmbSalesBatches;
    private System.Windows.Forms.ComboBox cmbSSCCs;
    private System.Windows.Forms.Button btnReprint;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
  }
}