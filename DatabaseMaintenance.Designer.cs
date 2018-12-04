namespace ExwoldPcInterface
{
    partial class DatabaseMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseMaintenance));
            this.ArchiveGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ArchiveProgressListBox = new System.Windows.Forms.ListBox();
            this.ArchiveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ArchiveCutOffDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SetOffLineGroupBox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SetOffLineProgressListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.OnLineArchivesListBox = new System.Windows.Forms.ListBox();
            this.SetOffLineButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SetOnLineGroupBox = new System.Windows.Forms.GroupBox();
            this.OffLineArchivesListBox = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SetOnLineProgressListBox = new System.Windows.Forms.ListBox();
            this.SetOnLineButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ArchiveGroupBox.SuspendLayout();
            this.SetOffLineGroupBox.SuspendLayout();
            this.SetOnLineGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ArchiveGroupBox
            // 
            this.ArchiveGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.ArchiveGroupBox.Controls.Add(this.label3);
            this.ArchiveGroupBox.Controls.Add(this.ArchiveProgressListBox);
            this.ArchiveGroupBox.Controls.Add(this.ArchiveButton);
            this.ArchiveGroupBox.Controls.Add(this.label2);
            this.ArchiveGroupBox.Controls.Add(this.ArchiveCutOffDate);
            this.ArchiveGroupBox.Controls.Add(this.label1);
            this.ArchiveGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ArchiveGroupBox.Name = "ArchiveGroupBox";
            this.ArchiveGroupBox.Size = new System.Drawing.Size(1417, 250);
            this.ArchiveGroupBox.TabIndex = 0;
            this.ArchiveGroupBox.TabStop = false;
            this.ArchiveGroupBox.Text = "Archive Database";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(650, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Progress:";
            // 
            // ArchiveProgressListBox
            // 
            this.ArchiveProgressListBox.FormattingEnabled = true;
            this.ArchiveProgressListBox.HorizontalScrollbar = true;
            this.ArchiveProgressListBox.ItemHeight = 16;
            this.ArchiveProgressListBox.Location = new System.Drawing.Point(653, 37);
            this.ArchiveProgressListBox.Name = "ArchiveProgressListBox";
            this.ArchiveProgressListBox.ScrollAlwaysVisible = true;
            this.ArchiveProgressListBox.Size = new System.Drawing.Size(700, 196);
            this.ArchiveProgressListBox.TabIndex = 4;
            // 
            // ArchiveButton
            // 
            this.ArchiveButton.Location = new System.Drawing.Point(353, 77);
            this.ArchiveButton.Name = "ArchiveButton";
            this.ArchiveButton.Size = new System.Drawing.Size(218, 23);
            this.ArchiveButton.TabIndex = 3;
            this.ArchiveButton.Text = "Create On-line Archive";
            this.ArchiveButton.UseVisualStyleBackColor = true;
            this.ArchiveButton.Click += new System.EventHandler(this.ArchiveButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select the cut-off date:";
            // 
            // ArchiveCutOffDate
            // 
            this.ArchiveCutOffDate.Location = new System.Drawing.Point(353, 37);
            this.ArchiveCutOffDate.Name = "ArchiveCutOffDate";
            this.ArchiveCutOffDate.Size = new System.Drawing.Size(218, 22);
            this.ArchiveCutOffDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 80);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // SetOffLineGroupBox
            // 
            this.SetOffLineGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.SetOffLineGroupBox.Controls.Add(this.label8);
            this.SetOffLineGroupBox.Controls.Add(this.SetOffLineProgressListBox);
            this.SetOffLineGroupBox.Controls.Add(this.label5);
            this.SetOffLineGroupBox.Controls.Add(this.OnLineArchivesListBox);
            this.SetOffLineGroupBox.Controls.Add(this.SetOffLineButton);
            this.SetOffLineGroupBox.Controls.Add(this.label4);
            this.SetOffLineGroupBox.Location = new System.Drawing.Point(12, 288);
            this.SetOffLineGroupBox.Name = "SetOffLineGroupBox";
            this.SetOffLineGroupBox.Size = new System.Drawing.Size(1417, 250);
            this.SetOffLineGroupBox.TabIndex = 1;
            this.SetOffLineGroupBox.TabStop = false;
            this.SetOffLineGroupBox.Text = "Set Archive to Off-line";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(650, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Progress:";
            // 
            // SetOffLineProgressListBox
            // 
            this.SetOffLineProgressListBox.FormattingEnabled = true;
            this.SetOffLineProgressListBox.HorizontalScrollbar = true;
            this.SetOffLineProgressListBox.ItemHeight = 16;
            this.SetOffLineProgressListBox.Location = new System.Drawing.Point(653, 37);
            this.SetOffLineProgressListBox.Name = "SetOffLineProgressListBox";
            this.SetOffLineProgressListBox.ScrollAlwaysVisible = true;
            this.SetOffLineProgressListBox.Size = new System.Drawing.Size(700, 196);
            this.SetOffLineProgressListBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Select the On-line Archive";
            // 
            // OnLineArchivesListBox
            // 
            this.OnLineArchivesListBox.FormattingEnabled = true;
            this.OnLineArchivesListBox.ItemHeight = 16;
            this.OnLineArchivesListBox.Location = new System.Drawing.Point(353, 37);
            this.OnLineArchivesListBox.Name = "OnLineArchivesListBox";
            this.OnLineArchivesListBox.Size = new System.Drawing.Size(218, 84);
            this.OnLineArchivesListBox.TabIndex = 7;
            // 
            // SetOffLineButton
            // 
            this.SetOffLineButton.Location = new System.Drawing.Point(353, 146);
            this.SetOffLineButton.Name = "SetOffLineButton";
            this.SetOffLineButton.Size = new System.Drawing.Size(218, 23);
            this.SetOffLineButton.TabIndex = 6;
            this.SetOffLineButton.Text = "Set Archive to Off-line";
            this.SetOffLineButton.UseVisualStyleBackColor = true;
            this.SetOffLineButton.Click += new System.EventHandler(this.SetOffLineButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(299, 80);
            this.label4.TabIndex = 0;
            this.label4.Text = "Once the On-line Archives are no longer needed, \r\nthey can be set to Off-line.\r\n\r" +
    "\nThe data will no longer be available for reporting,\r\nbut can be brought On-line" +
    " again if needed.";
            // 
            // SetOnLineGroupBox
            // 
            this.SetOnLineGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.SetOnLineGroupBox.Controls.Add(this.OffLineArchivesListBox);
            this.SetOnLineGroupBox.Controls.Add(this.label10);
            this.SetOnLineGroupBox.Controls.Add(this.label9);
            this.SetOnLineGroupBox.Controls.Add(this.SetOnLineProgressListBox);
            this.SetOnLineGroupBox.Controls.Add(this.SetOnLineButton);
            this.SetOnLineGroupBox.Controls.Add(this.label7);
            this.SetOnLineGroupBox.Location = new System.Drawing.Point(12, 578);
            this.SetOnLineGroupBox.Name = "SetOnLineGroupBox";
            this.SetOnLineGroupBox.Size = new System.Drawing.Size(1417, 250);
            this.SetOnLineGroupBox.TabIndex = 8;
            this.SetOnLineGroupBox.TabStop = false;
            this.SetOnLineGroupBox.Text = "Bring Archive On-line again";
            // 
            // OffLineArchivesListBox
            // 
            this.OffLineArchivesListBox.FormattingEnabled = true;
            this.OffLineArchivesListBox.ItemHeight = 16;
            this.OffLineArchivesListBox.Location = new System.Drawing.Point(353, 37);
            this.OffLineArchivesListBox.Name = "OffLineArchivesListBox";
            this.OffLineArchivesListBox.Size = new System.Drawing.Size(218, 84);
            this.OffLineArchivesListBox.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(350, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "Select Off-line Archive:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(654, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Progress:";
            // 
            // SetOnLineProgressListBox
            // 
            this.SetOnLineProgressListBox.FormattingEnabled = true;
            this.SetOnLineProgressListBox.HorizontalScrollbar = true;
            this.SetOnLineProgressListBox.ItemHeight = 16;
            this.SetOnLineProgressListBox.Location = new System.Drawing.Point(657, 37);
            this.SetOnLineProgressListBox.Name = "SetOnLineProgressListBox";
            this.SetOnLineProgressListBox.ScrollAlwaysVisible = true;
            this.SetOnLineProgressListBox.Size = new System.Drawing.Size(700, 196);
            this.SetOnLineProgressListBox.TabIndex = 8;
            // 
            // SetOnLineButton
            // 
            this.SetOnLineButton.Location = new System.Drawing.Point(353, 147);
            this.SetOnLineButton.Name = "SetOnLineButton";
            this.SetOnLineButton.Size = new System.Drawing.Size(218, 23);
            this.SetOnLineButton.TabIndex = 6;
            this.SetOnLineButton.Text = "Bring Archive back On-line";
            this.SetOnLineButton.UseVisualStyleBackColor = true;
            this.SetOnLineButton.Click += new System.EventHandler(this.SetOnLineButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(262, 192);
            this.label7.TabIndex = 0;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(1435, 23);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 9;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // DatabaseMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1531, 784);
            this.ControlBox = false;
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SetOnLineGroupBox);
            this.Controls.Add(this.SetOffLineGroupBox);
            this.Controls.Add(this.ArchiveGroupBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DatabaseMaintenance";
            this.Text = "Database Maintenance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatabaseMaintenance_FormClosing);
            this.Load += new System.EventHandler(this.DatabaseMaintenance_Load);
            this.ArchiveGroupBox.ResumeLayout(false);
            this.ArchiveGroupBox.PerformLayout();
            this.SetOffLineGroupBox.ResumeLayout(false);
            this.SetOffLineGroupBox.PerformLayout();
            this.SetOnLineGroupBox.ResumeLayout(false);
            this.SetOnLineGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ArchiveGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker ArchiveCutOffDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox ArchiveProgressListBox;
        private System.Windows.Forms.Button ArchiveButton;
        private System.Windows.Forms.GroupBox SetOffLineGroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox OnLineArchivesListBox;
        private System.Windows.Forms.Button SetOffLineButton;
        private System.Windows.Forms.GroupBox SetOnLineGroupBox;
        private System.Windows.Forms.Button SetOnLineButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox SetOffLineProgressListBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox SetOnLineProgressListBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox OffLineArchivesListBox;
        private System.Windows.Forms.Button CloseButton;
    }
}