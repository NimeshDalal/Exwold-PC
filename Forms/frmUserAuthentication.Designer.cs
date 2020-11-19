namespace ITS.Exwold.Desktop
{
    partial class UserAuthentication
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CloseFormButton = new System.Windows.Forms.Button();
            this.CheckingLabel = new System.Windows.Forms.Label();
            this.grpButtons = new System.Windows.Forms.GroupBox();
            this.grpSimulate = new System.Windows.Forms.GroupBox();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.chkSupervisor = new System.Windows.Forms.CheckBox();
            this.chkUser = new System.Windows.Forms.CheckBox();
            this.btnSimulate = new System.Windows.Forms.Button();
            this.grpButtons.SuspendLayout();
            this.grpSimulate.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "User-name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(95, 49);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.PasswordChar = '*';
            this.PasswordTextbox.Size = new System.Drawing.Size(227, 22);
            this.PasswordTextbox.TabIndex = 1;
            this.PasswordTextbox.Enter += new System.EventHandler(this.PasswordTextbox_Enter);
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Location = new System.Drawing.Point(95, 13);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(227, 22);
            this.UsernameTextbox.TabIndex = 0;
            this.UsernameTextbox.Enter += new System.EventHandler(this.UsernameTextbox_Enter);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(6, 14);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CloseFormButton
            // 
            this.CloseFormButton.Location = new System.Drawing.Point(396, 14);
            this.CloseFormButton.Name = "CloseFormButton";
            this.CloseFormButton.Size = new System.Drawing.Size(75, 23);
            this.CloseFormButton.TabIndex = 3;
            this.CloseFormButton.Text = "Cancel";
            this.CloseFormButton.UseVisualStyleBackColor = true;
            this.CloseFormButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CheckingLabel
            // 
            this.CheckingLabel.AutoSize = true;
            this.CheckingLabel.Location = new System.Drawing.Point(87, 17);
            this.CheckingLabel.Name = "CheckingLabel";
            this.CheckingLabel.Size = new System.Drawing.Size(73, 16);
            this.CheckingLabel.TabIndex = 4;
            this.CheckingLabel.Text = "Checking...";
            this.CheckingLabel.Visible = false;
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add(this.OkButton);
            this.grpButtons.Controls.Add(this.CloseFormButton);
            this.grpButtons.Controls.Add(this.CheckingLabel);
            this.grpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpButtons.Location = new System.Drawing.Point(0, 128);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Size = new System.Drawing.Size(477, 44);
            this.grpButtons.TabIndex = 5;
            this.grpButtons.TabStop = false;
            // 
            // grpSimulate
            // 
            this.grpSimulate.Controls.Add(this.btnSimulate);
            this.grpSimulate.Controls.Add(this.chkUser);
            this.grpSimulate.Controls.Add(this.chkSupervisor);
            this.grpSimulate.Controls.Add(this.chkAdmin);
            this.grpSimulate.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpSimulate.Location = new System.Drawing.Point(367, 0);
            this.grpSimulate.Name = "grpSimulate";
            this.grpSimulate.Size = new System.Drawing.Size(110, 128);
            this.grpSimulate.TabIndex = 6;
            this.grpSimulate.TabStop = false;
            this.grpSimulate.Text = "Simulate";
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.Location = new System.Drawing.Point(6, 21);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(65, 20);
            this.chkAdmin.TabIndex = 0;
            this.chkAdmin.Text = "Admin";
            this.chkAdmin.UseVisualStyleBackColor = true;
            // 
            // chkSupervisor
            // 
            this.chkSupervisor.AutoSize = true;
            this.chkSupervisor.Location = new System.Drawing.Point(6, 47);
            this.chkSupervisor.Name = "chkSupervisor";
            this.chkSupervisor.Size = new System.Drawing.Size(92, 20);
            this.chkSupervisor.TabIndex = 1;
            this.chkSupervisor.Text = "Supervisor";
            this.chkSupervisor.UseVisualStyleBackColor = true;
            // 
            // chkUser
            // 
            this.chkUser.AutoSize = true;
            this.chkUser.Location = new System.Drawing.Point(6, 73);
            this.chkUser.Name = "chkUser";
            this.chkUser.Size = new System.Drawing.Size(56, 20);
            this.chkUser.TabIndex = 2;
            this.chkUser.Text = "User";
            this.chkUser.UseVisualStyleBackColor = true;
            // 
            // btnSimulate
            // 
            this.btnSimulate.Location = new System.Drawing.Point(6, 95);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(96, 27);
            this.btnSimulate.TabIndex = 3;
            this.btnSimulate.Text = "Simulate";
            this.btnSimulate.UseVisualStyleBackColor = true;
            this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click);
            // 
            // UserAuthentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 172);
            this.ControlBox = false;
            this.Controls.Add(this.grpSimulate);
            this.Controls.Add(this.grpButtons);
            this.Controls.Add(this.UsernameTextbox);
            this.Controls.Add(this.PasswordTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserAuthentication";
            this.Text = "User Authentication";
            this.grpButtons.ResumeLayout(false);
            this.grpButtons.PerformLayout();
            this.grpSimulate.ResumeLayout(false);
            this.grpSimulate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PasswordTextbox;
        public System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CloseFormButton;
        private System.Windows.Forms.Label CheckingLabel;
        private System.Windows.Forms.GroupBox grpButtons;
        private System.Windows.Forms.GroupBox grpSimulate;
        private System.Windows.Forms.Button btnSimulate;
        private System.Windows.Forms.CheckBox chkUser;
        private System.Windows.Forms.CheckBox chkSupervisor;
        private System.Windows.Forms.CheckBox chkAdmin;
    }
}