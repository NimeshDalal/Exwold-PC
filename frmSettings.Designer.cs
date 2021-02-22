
namespace ITS.Exwold.Desktop
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPlantNumber = new System.Windows.Forms.TextBox();
            this.tbTcpListenPort = new System.Windows.Forms.TextBox();
            this.tbNiceLabelSDKPath = new System.Windows.Forms.TextBox();
            this.tbLogPath = new System.Windows.Forms.TextBox();
            this.tbLogLevel = new System.Windows.Forms.TextBox();
            this.grpButtons = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.grpButtons.SuspendLayout();
            this.grpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "plantNumber";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "tcpListenPort";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Log Level\\Path";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "NiceLabelSDKPath";
            // 
            // tbPlantNumber
            // 
            this.tbPlantNumber.Location = new System.Drawing.Point(152, 18);
            this.tbPlantNumber.Name = "tbPlantNumber";
            this.tbPlantNumber.Size = new System.Drawing.Size(58, 29);
            this.tbPlantNumber.TabIndex = 5;
            // 
            // tbTcpListenPort
            // 
            this.tbTcpListenPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTcpListenPort.Location = new System.Drawing.Point(552, 18);
            this.tbTcpListenPort.Name = "tbTcpListenPort";
            this.tbTcpListenPort.Size = new System.Drawing.Size(58, 29);
            this.tbTcpListenPort.TabIndex = 5;
            // 
            // tbNiceLabelSDKPath
            // 
            this.tbNiceLabelSDKPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNiceLabelSDKPath.Location = new System.Drawing.Point(152, 78);
            this.tbNiceLabelSDKPath.Name = "tbNiceLabelSDKPath";
            this.tbNiceLabelSDKPath.Size = new System.Drawing.Size(458, 29);
            this.tbNiceLabelSDKPath.TabIndex = 5;
            // 
            // tbLogPath
            // 
            this.tbLogPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLogPath.Location = new System.Drawing.Point(211, 48);
            this.tbLogPath.Name = "tbLogPath";
            this.tbLogPath.Size = new System.Drawing.Size(399, 29);
            this.tbLogPath.TabIndex = 5;
            // 
            // tbLogLevel
            // 
            this.tbLogLevel.Location = new System.Drawing.Point(152, 48);
            this.tbLogLevel.Name = "tbLogLevel";
            this.tbLogLevel.Size = new System.Drawing.Size(58, 29);
            this.tbLogLevel.TabIndex = 5;
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add(this.btnSave);
            this.grpButtons.Controls.Add(this.btnClose);
            this.grpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpButtons.Location = new System.Drawing.Point(0, 118);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Size = new System.Drawing.Size(616, 60);
            this.grpButtons.TabIndex = 6;
            this.grpButtons.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 39);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(464, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(149, 39);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.label1);
            this.grpSettings.Controls.Add(this.label2);
            this.grpSettings.Controls.Add(this.tbLogLevel);
            this.grpSettings.Controls.Add(this.label4);
            this.grpSettings.Controls.Add(this.tbLogPath);
            this.grpSettings.Controls.Add(this.label5);
            this.grpSettings.Controls.Add(this.tbNiceLabelSDKPath);
            this.grpSettings.Controls.Add(this.tbPlantNumber);
            this.grpSettings.Controls.Add(this.tbTcpListenPort);
            this.grpSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSettings.Location = new System.Drawing.Point(0, 0);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(616, 117);
            this.grpSettings.TabIndex = 7;
            this.grpSettings.TabStop = false;
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(616, 178);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.grpButtons);
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSettings";
            this.Text = "frmSettings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.grpButtons.ResumeLayout(false);
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPlantNumber;
        private System.Windows.Forms.TextBox tbTcpListenPort;
        private System.Windows.Forms.TextBox tbNiceLabelSDKPath;
        private System.Windows.Forms.TextBox tbLogPath;
        private System.Windows.Forms.TextBox tbLogLevel;
        private System.Windows.Forms.GroupBox grpButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpSettings;
    }
}