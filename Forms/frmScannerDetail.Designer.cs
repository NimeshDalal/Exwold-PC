
namespace ITS.Exwold.Desktop
{
    partial class frmScannerDetail
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
            this.grpScannerStatus = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnScanningStop = new System.Windows.Forms.Button();
            this.chkScanningSimulate = new System.Windows.Forms.CheckBox();
            this.lblLastProdDate = new System.Windows.Forms.Label();
            this.tbOrderPalletBatchUId = new System.Windows.Forms.TextBox();
            this.lblLastLotNo = new System.Windows.Forms.Label();
            this.lblLastGTIN = new System.Windows.Forms.Label();
            this.lblLastProdName = new System.Windows.Forms.Label();
            this.tbLastLotNo = new System.Windows.Forms.TextBox();
            this.tbLastGTIN = new System.Windows.Forms.TextBox();
            this.tbLastProdName = new System.Windows.Forms.TextBox();
            this.tbLastProdDate = new System.Windows.Forms.TextBox();
            this.lblLastScannedDate = new System.Windows.Forms.Label();
            this.lblLastScanned = new System.Windows.Forms.Label();
            this.btnScanningSimulateMsg = new System.Windows.Forms.Button();
            this.btnScanningStart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbStatusScanning = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tbStatusConnected = new System.Windows.Forms.TextBox();
            this.btnIsOnline = new System.Windows.Forms.Button();
            this.tbStatusAvailable = new System.Windows.Forms.TextBox();
            this.grpScannerDetails = new System.Windows.Forms.GroupBox();
            this.tbScannerProdLine = new System.Windows.Forms.TextBox();
            this.tbScannerPort = new System.Windows.Forms.TextBox();
            this.tbScannerIPAddr = new System.Windows.Forms.TextBox();
            this.tbScannerName = new System.Windows.Forms.TextBox();
            this.tbScannerID = new System.Windows.Forms.TextBox();
            this.lblScannerLine = new System.Windows.Forms.Label();
            this.lblScannerId = new System.Windows.Forms.Label();
            this.lblScannerName = new System.Windows.Forms.Label();
            this.lblScannerIPAddr = new System.Windows.Forms.Label();
            this.grpOrderInfo = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOrderProdCode = new System.Windows.Forms.Label();
            this.tbOrderInnerGTIN = new System.Windows.Forms.TextBox();
            this.tbOrderGTIN = new System.Windows.Forms.TextBox();
            this.tbOrderProdName = new System.Windows.Forms.TextBox();
            this.tbOrderProdCode = new System.Windows.Forms.TextBox();
            this.grpScannerStatus.SuspendLayout();
            this.grpScannerDetails.SuspendLayout();
            this.grpOrderInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpScannerStatus
            // 
            this.grpScannerStatus.Controls.Add(this.btnClose);
            this.grpScannerStatus.Controls.Add(this.btnScanningStop);
            this.grpScannerStatus.Controls.Add(this.chkScanningSimulate);
            this.grpScannerStatus.Controls.Add(this.lblLastProdDate);
            this.grpScannerStatus.Controls.Add(this.tbOrderPalletBatchUId);
            this.grpScannerStatus.Controls.Add(this.lblLastLotNo);
            this.grpScannerStatus.Controls.Add(this.lblLastGTIN);
            this.grpScannerStatus.Controls.Add(this.lblLastProdName);
            this.grpScannerStatus.Controls.Add(this.tbLastLotNo);
            this.grpScannerStatus.Controls.Add(this.tbLastGTIN);
            this.grpScannerStatus.Controls.Add(this.tbLastProdName);
            this.grpScannerStatus.Controls.Add(this.tbLastProdDate);
            this.grpScannerStatus.Controls.Add(this.lblLastScannedDate);
            this.grpScannerStatus.Controls.Add(this.lblLastScanned);
            this.grpScannerStatus.Controls.Add(this.btnScanningSimulateMsg);
            this.grpScannerStatus.Controls.Add(this.btnScanningStart);
            this.grpScannerStatus.Controls.Add(this.button1);
            this.grpScannerStatus.Controls.Add(this.tbStatusScanning);
            this.grpScannerStatus.Controls.Add(this.button2);
            this.grpScannerStatus.Controls.Add(this.tbStatusConnected);
            this.grpScannerStatus.Controls.Add(this.btnIsOnline);
            this.grpScannerStatus.Controls.Add(this.tbStatusAvailable);
            this.grpScannerStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpScannerStatus.Font = new System.Drawing.Font("Palatino Linotype", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpScannerStatus.Location = new System.Drawing.Point(0, 306);
            this.grpScannerStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpScannerStatus.Name = "grpScannerStatus";
            this.grpScannerStatus.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpScannerStatus.Size = new System.Drawing.Size(486, 321);
            this.grpScannerStatus.TabIndex = 4;
            this.grpScannerStatus.TabStop = false;
            this.grpScannerStatus.Text = "Scanner Status";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(394, 199);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(144, 31);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnScanningStop
            // 
            this.btnScanningStop.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanningStop.Location = new System.Drawing.Point(394, 126);
            this.btnScanningStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnScanningStop.Name = "btnScanningStop";
            this.btnScanningStop.Size = new System.Drawing.Size(136, 31);
            this.btnScanningStop.TabIndex = 18;
            this.btnScanningStop.Text = "Stop Scanning";
            this.btnScanningStop.UseVisualStyleBackColor = true;
            this.btnScanningStop.Visible = false;
            this.btnScanningStop.Click += new System.EventHandler(this.btnScanningStop_Click);
            // 
            // chkScanningSimulate
            // 
            this.chkScanningSimulate.AutoSize = true;
            this.chkScanningSimulate.Location = new System.Drawing.Point(398, 32);
            this.chkScanningSimulate.Name = "chkScanningSimulate";
            this.chkScanningSimulate.Size = new System.Drawing.Size(96, 26);
            this.chkScanningSimulate.TabIndex = 17;
            this.chkScanningSimulate.Text = "Simulate";
            this.chkScanningSimulate.UseVisualStyleBackColor = true;
            this.chkScanningSimulate.Visible = false;
            // 
            // lblLastProdDate
            // 
            this.lblLastProdDate.AutoSize = true;
            this.lblLastProdDate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastProdDate.Location = new System.Drawing.Point(8, 224);
            this.lblLastProdDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastProdDate.Name = "lblLastProdDate";
            this.lblLastProdDate.Size = new System.Drawing.Size(121, 22);
            this.lblLastProdDate.TabIndex = 16;
            this.lblLastProdDate.Text = "Production Date";
            // 
            // tbOrderPalletBatchUId
            // 
            this.tbOrderPalletBatchUId.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrderPalletBatchUId.Location = new System.Drawing.Point(394, 160);
            this.tbOrderPalletBatchUId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbOrderPalletBatchUId.Name = "tbOrderPalletBatchUId";
            this.tbOrderPalletBatchUId.Size = new System.Drawing.Size(144, 29);
            this.tbOrderPalletBatchUId.TabIndex = 8;
            this.tbOrderPalletBatchUId.Visible = false;
            // 
            // lblLastLotNo
            // 
            this.lblLastLotNo.AutoSize = true;
            this.lblLastLotNo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastLotNo.Location = new System.Drawing.Point(8, 192);
            this.lblLastLotNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastLotNo.Name = "lblLastLotNo";
            this.lblLastLotNo.Size = new System.Drawing.Size(95, 22);
            this.lblLastLotNo.TabIndex = 15;
            this.lblLastLotNo.Text = "Lot Number";
            // 
            // lblLastGTIN
            // 
            this.lblLastGTIN.AutoSize = true;
            this.lblLastGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastGTIN.Location = new System.Drawing.Point(8, 160);
            this.lblLastGTIN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastGTIN.Name = "lblLastGTIN";
            this.lblLastGTIN.Size = new System.Drawing.Size(49, 22);
            this.lblLastGTIN.TabIndex = 14;
            this.lblLastGTIN.Text = "GTIN";
            // 
            // lblLastProdName
            // 
            this.lblLastProdName.AutoSize = true;
            this.lblLastProdName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastProdName.Location = new System.Drawing.Point(8, 266);
            this.lblLastProdName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastProdName.Name = "lblLastProdName";
            this.lblLastProdName.Size = new System.Drawing.Size(110, 22);
            this.lblLastProdName.TabIndex = 13;
            this.lblLastProdName.Text = "Product Name";
            // 
            // tbLastLotNo
            // 
            this.tbLastLotNo.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLastLotNo.Location = new System.Drawing.Point(160, 189);
            this.tbLastLotNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLastLotNo.Name = "tbLastLotNo";
            this.tbLastLotNo.Size = new System.Drawing.Size(232, 29);
            this.tbLastLotNo.TabIndex = 12;
            this.tbLastLotNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbLastGTIN
            // 
            this.tbLastGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLastGTIN.Location = new System.Drawing.Point(160, 157);
            this.tbLastGTIN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLastGTIN.Name = "tbLastGTIN";
            this.tbLastGTIN.Size = new System.Drawing.Size(232, 29);
            this.tbLastGTIN.TabIndex = 12;
            this.tbLastGTIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbLastProdName
            // 
            this.tbLastProdName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLastProdName.Location = new System.Drawing.Point(160, 253);
            this.tbLastProdName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLastProdName.Multiline = true;
            this.tbLastProdName.Name = "tbLastProdName";
            this.tbLastProdName.Size = new System.Drawing.Size(320, 59);
            this.tbLastProdName.TabIndex = 12;
            this.tbLastProdName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbLastProdDate
            // 
            this.tbLastProdDate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLastProdDate.Location = new System.Drawing.Point(160, 221);
            this.tbLastProdDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbLastProdDate.Name = "tbLastProdDate";
            this.tbLastProdDate.Size = new System.Drawing.Size(232, 29);
            this.tbLastProdDate.TabIndex = 12;
            this.tbLastProdDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLastScannedDate
            // 
            this.lblLastScannedDate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastScannedDate.Location = new System.Drawing.Point(160, 129);
            this.lblLastScannedDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastScannedDate.Name = "lblLastScannedDate";
            this.lblLastScannedDate.Size = new System.Drawing.Size(232, 22);
            this.lblLastScannedDate.TabIndex = 11;
            this.lblLastScannedDate.Text = "Last Scanned";
            this.lblLastScannedDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastScanned
            // 
            this.lblLastScanned.Font = new System.Drawing.Font("Palatino Linotype", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastScanned.Location = new System.Drawing.Point(8, 129);
            this.lblLastScanned.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastScanned.Name = "lblLastScanned";
            this.lblLastScanned.Size = new System.Drawing.Size(136, 22);
            this.lblLastScanned.TabIndex = 11;
            this.lblLastScanned.Text = "Last Scanned";
            this.lblLastScanned.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnScanningSimulateMsg
            // 
            this.btnScanningSimulateMsg.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanningSimulateMsg.Location = new System.Drawing.Point(394, 62);
            this.btnScanningSimulateMsg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnScanningSimulateMsg.Name = "btnScanningSimulateMsg";
            this.btnScanningSimulateMsg.Size = new System.Drawing.Size(136, 31);
            this.btnScanningSimulateMsg.TabIndex = 8;
            this.btnScanningSimulateMsg.Text = "Sim Message";
            this.btnScanningSimulateMsg.UseVisualStyleBackColor = true;
            this.btnScanningSimulateMsg.Visible = false;
            this.btnScanningSimulateMsg.Click += new System.EventHandler(this.btnScanningSimulateMsg_Click);
            // 
            // btnScanningStart
            // 
            this.btnScanningStart.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanningStart.Location = new System.Drawing.Point(394, 94);
            this.btnScanningStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnScanningStart.Name = "btnScanningStart";
            this.btnScanningStart.Size = new System.Drawing.Size(136, 31);
            this.btnScanningStart.TabIndex = 8;
            this.btnScanningStart.Text = "Start Scanning";
            this.btnScanningStart.UseVisualStyleBackColor = true;
            this.btnScanningStart.Visible = false;
            this.btnScanningStart.Click += new System.EventHandler(this.btnScanningStart_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(8, 94);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 31);
            this.button1.TabIndex = 8;
            this.button1.Text = "Is Scanning";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbStatusScanning
            // 
            this.tbStatusScanning.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStatusScanning.Location = new System.Drawing.Point(160, 95);
            this.tbStatusScanning.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbStatusScanning.Name = "tbStatusScanning";
            this.tbStatusScanning.Size = new System.Drawing.Size(232, 29);
            this.tbStatusScanning.TabIndex = 7;
            this.tbStatusScanning.Text = "Order Not Selected";
            this.tbStatusScanning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(8, 62);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 31);
            this.button2.TabIndex = 6;
            this.button2.Text = "Is Connected";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tbStatusConnected
            // 
            this.tbStatusConnected.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStatusConnected.Location = new System.Drawing.Point(160, 63);
            this.tbStatusConnected.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbStatusConnected.Name = "tbStatusConnected";
            this.tbStatusConnected.Size = new System.Drawing.Size(232, 29);
            this.tbStatusConnected.TabIndex = 5;
            this.tbStatusConnected.Text = "Order Not Selected";
            this.tbStatusConnected.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnIsOnline
            // 
            this.btnIsOnline.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIsOnline.Location = new System.Drawing.Point(8, 30);
            this.btnIsOnline.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIsOnline.Name = "btnIsOnline";
            this.btnIsOnline.Size = new System.Drawing.Size(144, 31);
            this.btnIsOnline.TabIndex = 4;
            this.btnIsOnline.Text = "Is On-line";
            this.btnIsOnline.UseVisualStyleBackColor = true;
            // 
            // tbStatusAvailable
            // 
            this.tbStatusAvailable.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStatusAvailable.Location = new System.Drawing.Point(160, 31);
            this.tbStatusAvailable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbStatusAvailable.Name = "tbStatusAvailable";
            this.tbStatusAvailable.Size = new System.Drawing.Size(232, 29);
            this.tbStatusAvailable.TabIndex = 3;
            this.tbStatusAvailable.Text = "Order Not Selected";
            this.tbStatusAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpScannerDetails
            // 
            this.grpScannerDetails.Controls.Add(this.tbScannerProdLine);
            this.grpScannerDetails.Controls.Add(this.tbScannerPort);
            this.grpScannerDetails.Controls.Add(this.tbScannerIPAddr);
            this.grpScannerDetails.Controls.Add(this.tbScannerName);
            this.grpScannerDetails.Controls.Add(this.tbScannerID);
            this.grpScannerDetails.Controls.Add(this.lblScannerLine);
            this.grpScannerDetails.Controls.Add(this.lblScannerId);
            this.grpScannerDetails.Controls.Add(this.lblScannerName);
            this.grpScannerDetails.Controls.Add(this.lblScannerIPAddr);
            this.grpScannerDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpScannerDetails.Font = new System.Drawing.Font("Palatino Linotype", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpScannerDetails.Location = new System.Drawing.Point(0, 0);
            this.grpScannerDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpScannerDetails.Name = "grpScannerDetails";
            this.grpScannerDetails.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpScannerDetails.Size = new System.Drawing.Size(486, 109);
            this.grpScannerDetails.TabIndex = 4;
            this.grpScannerDetails.TabStop = false;
            this.grpScannerDetails.Text = "Scanner Details";
            // 
            // tbScannerProdLine
            // 
            this.tbScannerProdLine.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScannerProdLine.Location = new System.Drawing.Point(439, 63);
            this.tbScannerProdLine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbScannerProdLine.Name = "tbScannerProdLine";
            this.tbScannerProdLine.Size = new System.Drawing.Size(42, 29);
            this.tbScannerProdLine.TabIndex = 11;
            this.tbScannerProdLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbScannerPort
            // 
            this.tbScannerPort.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScannerPort.Location = new System.Drawing.Point(295, 63);
            this.tbScannerPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbScannerPort.Name = "tbScannerPort";
            this.tbScannerPort.Size = new System.Drawing.Size(96, 29);
            this.tbScannerPort.TabIndex = 10;
            this.tbScannerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbScannerIPAddr
            // 
            this.tbScannerIPAddr.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScannerIPAddr.Location = new System.Drawing.Point(160, 63);
            this.tbScannerIPAddr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbScannerIPAddr.Name = "tbScannerIPAddr";
            this.tbScannerIPAddr.Size = new System.Drawing.Size(132, 29);
            this.tbScannerIPAddr.TabIndex = 9;
            this.tbScannerIPAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbScannerName
            // 
            this.tbScannerName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScannerName.Location = new System.Drawing.Point(160, 31);
            this.tbScannerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbScannerName.Name = "tbScannerName";
            this.tbScannerName.Size = new System.Drawing.Size(232, 29);
            this.tbScannerName.TabIndex = 8;
            this.tbScannerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbScannerID
            // 
            this.tbScannerID.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScannerID.Location = new System.Drawing.Point(394, 63);
            this.tbScannerID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbScannerID.Name = "tbScannerID";
            this.tbScannerID.Size = new System.Drawing.Size(42, 29);
            this.tbScannerID.TabIndex = 7;
            this.tbScannerID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblScannerLine
            // 
            this.lblScannerLine.AutoSize = true;
            this.lblScannerLine.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScannerLine.Location = new System.Drawing.Point(440, 35);
            this.lblScannerLine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScannerLine.Name = "lblScannerLine";
            this.lblScannerLine.Size = new System.Drawing.Size(40, 22);
            this.lblScannerLine.TabIndex = 6;
            this.lblScannerLine.Text = "Line";
            // 
            // lblScannerId
            // 
            this.lblScannerId.AutoSize = true;
            this.lblScannerId.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScannerId.Location = new System.Drawing.Point(402, 35);
            this.lblScannerId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScannerId.Name = "lblScannerId";
            this.lblScannerId.Size = new System.Drawing.Size(27, 22);
            this.lblScannerId.TabIndex = 6;
            this.lblScannerId.Text = "ID";
            // 
            // lblScannerName
            // 
            this.lblScannerName.AutoSize = true;
            this.lblScannerName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScannerName.Location = new System.Drawing.Point(8, 34);
            this.lblScannerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScannerName.Name = "lblScannerName";
            this.lblScannerName.Size = new System.Drawing.Size(52, 22);
            this.lblScannerName.TabIndex = 6;
            this.lblScannerName.Text = "Name";
            // 
            // lblScannerIPAddr
            // 
            this.lblScannerIPAddr.AutoSize = true;
            this.lblScannerIPAddr.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScannerIPAddr.Location = new System.Drawing.Point(8, 66);
            this.lblScannerIPAddr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScannerIPAddr.Name = "lblScannerIPAddr";
            this.lblScannerIPAddr.Size = new System.Drawing.Size(121, 22);
            this.lblScannerIPAddr.TabIndex = 5;
            this.lblScannerIPAddr.Text = "IP Address\\Port";
            // 
            // grpOrderInfo
            // 
            this.grpOrderInfo.Controls.Add(this.label4);
            this.grpOrderInfo.Controls.Add(this.label3);
            this.grpOrderInfo.Controls.Add(this.label2);
            this.grpOrderInfo.Controls.Add(this.lblOrderProdCode);
            this.grpOrderInfo.Controls.Add(this.tbOrderInnerGTIN);
            this.grpOrderInfo.Controls.Add(this.tbOrderGTIN);
            this.grpOrderInfo.Controls.Add(this.tbOrderProdName);
            this.grpOrderInfo.Controls.Add(this.tbOrderProdCode);
            this.grpOrderInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpOrderInfo.Font = new System.Drawing.Font("Palatino Linotype", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOrderInfo.Location = new System.Drawing.Point(0, 109);
            this.grpOrderInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpOrderInfo.Name = "grpOrderInfo";
            this.grpOrderInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpOrderInfo.Size = new System.Drawing.Size(486, 197);
            this.grpOrderInfo.TabIndex = 4;
            this.grpOrderInfo.TabStop = false;
            this.grpOrderInfo.Text = "Order Info";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 152);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "Inner GTIN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "Pallet\\Outer GTIN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Product Name";
            // 
            // lblOrderProdCode
            // 
            this.lblOrderProdCode.AutoSize = true;
            this.lblOrderProdCode.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderProdCode.Location = new System.Drawing.Point(8, 34);
            this.lblOrderProdCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderProdCode.Name = "lblOrderProdCode";
            this.lblOrderProdCode.Size = new System.Drawing.Size(103, 22);
            this.lblOrderProdCode.TabIndex = 7;
            this.lblOrderProdCode.Text = "Product Code";
            // 
            // tbOrderInnerGTIN
            // 
            this.tbOrderInnerGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrderInnerGTIN.Location = new System.Drawing.Point(160, 148);
            this.tbOrderInnerGTIN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbOrderInnerGTIN.Name = "tbOrderInnerGTIN";
            this.tbOrderInnerGTIN.Size = new System.Drawing.Size(232, 29);
            this.tbOrderInnerGTIN.TabIndex = 6;
            this.tbOrderInnerGTIN.Text = "Order Not Selected";
            this.tbOrderInnerGTIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbOrderGTIN
            // 
            this.tbOrderGTIN.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrderGTIN.Location = new System.Drawing.Point(160, 115);
            this.tbOrderGTIN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbOrderGTIN.Name = "tbOrderGTIN";
            this.tbOrderGTIN.Size = new System.Drawing.Size(232, 29);
            this.tbOrderGTIN.TabIndex = 5;
            this.tbOrderGTIN.Text = "Order Not Selected";
            this.tbOrderGTIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbOrderProdName
            // 
            this.tbOrderProdName.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrderProdName.Location = new System.Drawing.Point(160, 63);
            this.tbOrderProdName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbOrderProdName.Multiline = true;
            this.tbOrderProdName.Name = "tbOrderProdName";
            this.tbOrderProdName.Size = new System.Drawing.Size(232, 49);
            this.tbOrderProdName.TabIndex = 4;
            this.tbOrderProdName.Text = "Order Not Selected";
            this.tbOrderProdName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbOrderProdCode
            // 
            this.tbOrderProdCode.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrderProdCode.Location = new System.Drawing.Point(160, 31);
            this.tbOrderProdCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbOrderProdCode.Name = "tbOrderProdCode";
            this.tbOrderProdCode.Size = new System.Drawing.Size(232, 29);
            this.tbOrderProdCode.TabIndex = 3;
            this.tbOrderProdCode.Text = "Order Not Selected";
            this.tbOrderProdCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmScannerDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(486, 619);
            this.ControlBox = false;
            this.Controls.Add(this.grpScannerStatus);
            this.Controls.Add(this.grpOrderInfo);
            this.Controls.Add(this.grpScannerDetails);
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScannerDetail";
            this.ShowIcon = false;
            this.Text = "Scanner Details";
            this.Load += new System.EventHandler(this.frmScannerDetail_Load);
            this.grpScannerStatus.ResumeLayout(false);
            this.grpScannerStatus.PerformLayout();
            this.grpScannerDetails.ResumeLayout(false);
            this.grpScannerDetails.PerformLayout();
            this.grpOrderInfo.ResumeLayout(false);
            this.grpOrderInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpScannerStatus;
        private System.Windows.Forms.GroupBox grpScannerDetails;
        private System.Windows.Forms.GroupBox grpOrderInfo;
        private System.Windows.Forms.TextBox tbScannerProdLine;
        private System.Windows.Forms.TextBox tbScannerPort;
        private System.Windows.Forms.TextBox tbScannerIPAddr;
        private System.Windows.Forms.TextBox tbScannerName;
        private System.Windows.Forms.TextBox tbScannerID;
        private System.Windows.Forms.Label lblScannerName;
        private System.Windows.Forms.Label lblScannerIPAddr;
        private System.Windows.Forms.Label lblOrderProdCode;
        private System.Windows.Forms.TextBox tbOrderInnerGTIN;
        private System.Windows.Forms.TextBox tbOrderGTIN;
        private System.Windows.Forms.TextBox tbOrderProdName;
        private System.Windows.Forms.TextBox tbOrderProdCode;
        private System.Windows.Forms.TextBox tbOrderPalletBatchUId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbStatusScanning;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbStatusConnected;
        private System.Windows.Forms.Button btnIsOnline;
        private System.Windows.Forms.TextBox tbStatusAvailable;
        private System.Windows.Forms.TextBox tbLastProdDate;
        private System.Windows.Forms.Label lblLastScanned;
        private System.Windows.Forms.TextBox tbLastLotNo;
        private System.Windows.Forms.TextBox tbLastGTIN;
        private System.Windows.Forms.TextBox tbLastProdName;
        private System.Windows.Forms.CheckBox chkScanningSimulate;
        private System.Windows.Forms.Label lblLastProdDate;
        private System.Windows.Forms.Label lblLastLotNo;
        private System.Windows.Forms.Label lblLastGTIN;
        private System.Windows.Forms.Label lblLastProdName;
        private System.Windows.Forms.Label lblLastScannedDate;
        private System.Windows.Forms.Button btnScanningStart;
        private System.Windows.Forms.Button btnScanningSimulateMsg;
        private System.Windows.Forms.Button btnScanningStop;
        private System.Windows.Forms.Label lblScannerLine;
        private System.Windows.Forms.Label lblScannerId;
        private System.Windows.Forms.Button btnClose;
    }
}