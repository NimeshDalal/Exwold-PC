
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlDisplay = new System.Windows.Forms.Panel();
            this.tabctrlScanners = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.tabctrlScanners.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlDisplay);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(554, 792);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Scanner 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlDisplay
            // 
            this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplay.Location = new System.Drawing.Point(3, 3);
            this.pnlDisplay.Name = "pnlDisplay";
            this.pnlDisplay.Size = new System.Drawing.Size(548, 786);
            this.pnlDisplay.TabIndex = 0;
            // 
            // tabctrlScanners
            // 
            this.tabctrlScanners.Controls.Add(this.tabPage1);
            this.tabctrlScanners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabctrlScanners.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabctrlScanners.Location = new System.Drawing.Point(0, 0);
            this.tabctrlScanners.Multiline = true;
            this.tabctrlScanners.Name = "tabctrlScanners";
            this.tabctrlScanners.SelectedIndex = 0;
            this.tabctrlScanners.Size = new System.Drawing.Size(562, 827);
            this.tabctrlScanners.TabIndex = 1;
            // 
            // frmStandAloneScanners
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 827);
            this.Controls.Add(this.tabctrlScanners);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmStandAloneScanners";
            this.Text = "frmStandAloneScanners";
            this.Load += new System.EventHandler(this.frmStandAloneScanners_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabctrlScanners.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabctrlScanners;
        private System.Windows.Forms.Panel pnlDisplay;
    }
}