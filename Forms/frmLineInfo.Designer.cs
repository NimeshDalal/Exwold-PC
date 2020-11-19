namespace ITS.Exwold.Desktop
{
    partial class frmLineInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCurrentPallet = new System.Windows.Forms.DataGridView();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.btnPalletDetails = new System.Windows.Forms.Button();
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblProductBatchesOnPallet = new System.Windows.Forms.Label();
            this.txtTotalCartons = new System.Windows.Forms.TextBox();
            this.lblTotalCartonsRqd = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.txtCartonsOnPallet = new System.Windows.Forms.TextBox();
            this.txtPalletBatchNo = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblSalesOrder = new System.Windows.Forms.Label();
            this.lblTotalCartonsScanned = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.grpDisplay = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentPallet)).BeginInit();
            this.grpDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCurrentPallet
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            this.dgvCurrentPallet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCurrentPallet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCurrentPallet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCurrentPallet.CausesValidation = false;
            this.dgvCurrentPallet.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvCurrentPallet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCurrentPallet.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCurrentPallet.Enabled = false;
            this.dgvCurrentPallet.EnableHeadersVisualStyles = false;
            this.dgvCurrentPallet.Location = new System.Drawing.Point(208, 176);
            this.dgvCurrentPallet.Name = "dgvCurrentPallet";
            this.dgvCurrentPallet.ReadOnly = true;
            this.dgvCurrentPallet.RowHeadersVisible = false;
            this.dgvCurrentPallet.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCurrentPallet.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvCurrentPallet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrentPallet.Size = new System.Drawing.Size(231, 176);
            this.dgvCurrentPallet.TabIndex = 78;
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotes.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtNotes.Location = new System.Drawing.Point(9, 226);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ReadOnly = true;
            this.txtNotes.Size = new System.Drawing.Size(191, 126);
            this.txtNotes.TabIndex = 77;
            this.txtNotes.Text = "";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblNotes.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNotes.Location = new System.Drawing.Point(9, 201);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(49, 22);
            this.lblNotes.TabIndex = 76;
            this.lblNotes.Text = "Notes";
            // 
            // btnPalletDetails
            // 
            this.btnPalletDetails.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPalletDetails.Location = new System.Drawing.Point(3, 424);
            this.btnPalletDetails.Name = "btnPalletDetails";
            this.btnPalletDetails.Size = new System.Drawing.Size(191, 30);
            this.btnPalletDetails.TabIndex = 60;
            this.btnPalletDetails.Text = "Pallet Details";
            this.btnPalletDetails.UseVisualStyleBackColor = true;
            this.btnPalletDetails.Click += new System.EventHandler(this.btnPalletDetails_Click);
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.AutoSize = true;
            this.lblStatusMessage.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblStatusMessage.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusMessage.ForeColor = System.Drawing.Color.Green;
            this.lblStatusMessage.Location = new System.Drawing.Point(113, 355);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(87, 22);
            this.lblStatusMessage.TabIndex = 36;
            this.lblStatusMessage.Text = "In-Progress";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblStatus.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus.Location = new System.Drawing.Point(9, 355);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(77, 22);
            this.lblStatus.TabIndex = 35;
            this.lblStatus.Text = "Status    - ";
            // 
            // lblProductBatchesOnPallet
            // 
            this.lblProductBatchesOnPallet.AutoSize = true;
            this.lblProductBatchesOnPallet.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblProductBatchesOnPallet.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductBatchesOnPallet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProductBatchesOnPallet.Location = new System.Drawing.Point(9, 176);
            this.lblProductBatchesOnPallet.Name = "lblProductBatchesOnPallet";
            this.lblProductBatchesOnPallet.Size = new System.Drawing.Size(197, 22);
            this.lblProductBatchesOnPallet.TabIndex = 31;
            this.lblProductBatchesOnPallet.Text = "Product batches on Pallet(s)";
            // 
            // txtTotalCartons
            // 
            this.txtTotalCartons.BackColor = System.Drawing.Color.DarkGray;
            this.txtTotalCartons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalCartons.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCartons.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtTotalCartons.Location = new System.Drawing.Point(208, 111);
            this.txtTotalCartons.Name = "txtTotalCartons";
            this.txtTotalCartons.ReadOnly = true;
            this.txtTotalCartons.Size = new System.Drawing.Size(37, 29);
            this.txtTotalCartons.TabIndex = 30;
            this.txtTotalCartons.Text = " \r\n";
            // 
            // lblTotalCartonsRqd
            // 
            this.lblTotalCartonsRqd.AutoSize = true;
            this.lblTotalCartonsRqd.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTotalCartonsRqd.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCartonsRqd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotalCartonsRqd.Location = new System.Drawing.Point(9, 113);
            this.lblTotalCartonsRqd.Name = "lblTotalCartonsRqd";
            this.lblTotalCartonsRqd.Size = new System.Drawing.Size(166, 22);
            this.lblTotalCartonsRqd.TabIndex = 29;
            this.lblTotalCartonsRqd.Text = "Total Cartons Required";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.DarkGray;
            this.txtCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomer.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtCustomer.Location = new System.Drawing.Point(108, 47);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(137, 29);
            this.txtCustomer.TabIndex = 28;
            this.txtCustomer.Text = " \r\n";
            // 
            // txtProdName
            // 
            this.txtProdName.BackColor = System.Drawing.Color.DarkGray;
            this.txtProdName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtProdName.Location = new System.Drawing.Point(108, 79);
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.ReadOnly = true;
            this.txtProdName.Size = new System.Drawing.Size(137, 29);
            this.txtProdName.TabIndex = 27;
            this.txtProdName.Text = " \r\n";
            // 
            // txtCartonsOnPallet
            // 
            this.txtCartonsOnPallet.BackColor = System.Drawing.Color.DarkGray;
            this.txtCartonsOnPallet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCartonsOnPallet.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCartonsOnPallet.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtCartonsOnPallet.Location = new System.Drawing.Point(208, 143);
            this.txtCartonsOnPallet.Name = "txtCartonsOnPallet";
            this.txtCartonsOnPallet.ReadOnly = true;
            this.txtCartonsOnPallet.Size = new System.Drawing.Size(37, 29);
            this.txtCartonsOnPallet.TabIndex = 26;
            this.txtCartonsOnPallet.Text = " \r\n";
            // 
            // txtPalletBatchNo
            // 
            this.txtPalletBatchNo.BackColor = System.Drawing.Color.DarkGray;
            this.txtPalletBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPalletBatchNo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPalletBatchNo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtPalletBatchNo.Location = new System.Drawing.Point(108, 15);
            this.txtPalletBatchNo.Name = "txtPalletBatchNo";
            this.txtPalletBatchNo.ReadOnly = true;
            this.txtPalletBatchNo.Size = new System.Drawing.Size(137, 29);
            this.txtPalletBatchNo.TabIndex = 23;
            this.txtPalletBatchNo.Text = " \r\n";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblProduct.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProduct.Location = new System.Drawing.Point(9, 81);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(64, 22);
            this.lblProduct.TabIndex = 22;
            this.lblProduct.Text = "Product";
            // 
            // lblSalesOrder
            // 
            this.lblSalesOrder.AutoSize = true;
            this.lblSalesOrder.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSalesOrder.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesOrder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSalesOrder.Location = new System.Drawing.Point(9, 17);
            this.lblSalesOrder.Name = "lblSalesOrder";
            this.lblSalesOrder.Size = new System.Drawing.Size(89, 22);
            this.lblSalesOrder.TabIndex = 21;
            this.lblSalesOrder.Text = "Sales Order";
            // 
            // lblTotalCartonsScanned
            // 
            this.lblTotalCartonsScanned.AutoSize = true;
            this.lblTotalCartonsScanned.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTotalCartonsScanned.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCartonsScanned.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotalCartonsScanned.Location = new System.Drawing.Point(9, 149);
            this.lblTotalCartonsScanned.Name = "lblTotalCartonsScanned";
            this.lblTotalCartonsScanned.Size = new System.Drawing.Size(163, 22);
            this.lblTotalCartonsScanned.TabIndex = 20;
            this.lblTotalCartonsScanned.Text = "Total Cartons Scanned";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCustomer.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCustomer.Location = new System.Drawing.Point(9, 49);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(76, 22);
            this.lblCustomer.TabIndex = 19;
            this.lblCustomer.Text = "Customer";
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblLine.Location = new System.Drawing.Point(0, 0);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(374, 32);
            this.lblLine.TabIndex = 79;
            this.lblLine.Text = "Line 1";
            this.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpDisplay
            // 
            this.grpDisplay.Controls.Add(this.txtPalletBatchNo);
            this.grpDisplay.Controls.Add(this.lblTotalCartonsScanned);
            this.grpDisplay.Controls.Add(this.lblSalesOrder);
            this.grpDisplay.Controls.Add(this.lblStatus);
            this.grpDisplay.Controls.Add(this.lblStatusMessage);
            this.grpDisplay.Controls.Add(this.txtCustomer);
            this.grpDisplay.Controls.Add(this.txtCartonsOnPallet);
            this.grpDisplay.Controls.Add(this.txtTotalCartons);
            this.grpDisplay.Controls.Add(this.dgvCurrentPallet);
            this.grpDisplay.Controls.Add(this.txtProdName);
            this.grpDisplay.Controls.Add(this.txtNotes);
            this.grpDisplay.Controls.Add(this.lblProductBatchesOnPallet);
            this.grpDisplay.Controls.Add(this.lblNotes);
            this.grpDisplay.Controls.Add(this.lblTotalCartonsRqd);
            this.grpDisplay.Controls.Add(this.lblCustomer);
            this.grpDisplay.Controls.Add(this.lblProduct);
            this.grpDisplay.Location = new System.Drawing.Point(3, 35);
            this.grpDisplay.Name = "grpDisplay";
            this.grpDisplay.Size = new System.Drawing.Size(445, 383);
            this.grpDisplay.TabIndex = 80;
            this.grpDisplay.TabStop = false;
            // 
            // frmLineInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(454, 457);
            this.ControlBox = false;
            this.Controls.Add(this.grpDisplay);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.btnPalletDetails);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLineInfo";
            this.ShowIcon = false;
            this.Text = "frmLineInfo";
            this.Load += new System.EventHandler(this.frmLineInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentPallet)).EndInit();
            this.grpDisplay.ResumeLayout(false);
            this.grpDisplay.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCurrentPallet;
        private System.Windows.Forms.RichTextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Button btnPalletDetails;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblProductBatchesOnPallet;
        private System.Windows.Forms.TextBox txtTotalCartons;
        private System.Windows.Forms.Label lblTotalCartonsRqd;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.TextBox txtCartonsOnPallet;
        private System.Windows.Forms.TextBox txtPalletBatchNo;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblSalesOrder;
        private System.Windows.Forms.Label lblTotalCartonsScanned;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.GroupBox grpDisplay;
    }
}