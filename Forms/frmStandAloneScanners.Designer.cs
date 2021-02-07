
namespace ITS.Exwold.Desktop
{
    partial class frmStandAloneScanners
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
            this.grpButtons = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabctrlScanners = new System.Windows.Forms.TabControl();
            this.grpButtons.SuspendLayout();
            this.tabctrlScanners.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add(this.btnClose);
            this.grpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpButtons.Location = new System.Drawing.Point(0, 708);
            this.grpButtons.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Padding = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.grpButtons.Size = new System.Drawing.Size(512, 68);
            this.grpButtons.TabIndex = 5;
            this.grpButtons.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(357, 22);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(148, 39);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(504, 668);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Scanner 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabctrlScanners
            // 
            this.tabctrlScanners.Controls.Add(this.tabPage1);
            this.tabctrlScanners.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabctrlScanners.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabctrlScanners.Location = new System.Drawing.Point(0, 0);
            this.tabctrlScanners.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabctrlScanners.Multiline = true;
            this.tabctrlScanners.Name = "tabctrlScanners";
            this.tabctrlScanners.SelectedIndex = 0;
            this.tabctrlScanners.Size = new System.Drawing.Size(512, 703);
            this.tabctrlScanners.TabIndex = 1;
            // 
            // frmStandAloneScanners
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 776);
            this.Controls.Add(this.grpButtons);
            this.Controls.Add(this.tabctrlScanners);
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmStandAloneScanners";
            this.Text = "frmStandAloneScanners";
            this.Load += new System.EventHandler(this.frmStandAloneScanners_Load);
            this.grpButtons.ResumeLayout(false);
            this.tabctrlScanners.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabctrlScanners;
    }
}