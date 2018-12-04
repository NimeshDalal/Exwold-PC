namespace ExwoldPcInterface
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "User-name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(120, 80);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.PasswordChar = '*';
            this.PasswordTextbox.Size = new System.Drawing.Size(227, 22);
            this.PasswordTextbox.TabIndex = 1;
            this.PasswordTextbox.Enter += new System.EventHandler(this.PasswordTextbox_Enter);
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Location = new System.Drawing.Point(120, 40);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(227, 22);
            this.UsernameTextbox.TabIndex = 0;
            this.UsernameTextbox.Enter += new System.EventHandler(this.UsernameTextbox_Enter);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(120, 120);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CloseFormButton
            // 
            this.CloseFormButton.Location = new System.Drawing.Point(380, 120);
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
            this.CheckingLabel.Location = new System.Drawing.Point(201, 123);
            this.CheckingLabel.Name = "CheckingLabel";
            this.CheckingLabel.Size = new System.Drawing.Size(73, 16);
            this.CheckingLabel.TabIndex = 4;
            this.CheckingLabel.Text = "Checking...";
            this.CheckingLabel.Visible = false;
            // 
            // UserAuthentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 172);
            this.ControlBox = false;
            this.Controls.Add(this.CheckingLabel);
            this.Controls.Add(this.CloseFormButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.UsernameTextbox);
            this.Controls.Add(this.PasswordTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserAuthentication";
            this.Text = "User Authentication";
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
    }
}