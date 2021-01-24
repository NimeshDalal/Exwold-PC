
namespace ITS.Exwold.Desktop.AsyncTcp
{
    partial class AsyncTcpTest
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
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConnectMessage = new System.Windows.Forms.TextBox();
            this.txtServerMsgIn = new System.Windows.Forms.TextBox();
            this.txtServerMsgOut = new System.Windows.Forms.TextBox();
            this.btnIsRunning = new System.Windows.Forms.Button();
            this.chkRunning = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(10, 10);
            this.btnStartServer.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(89, 28);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(102, 10);
            this.btnStopServer.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(100, 28);
            this.btnStopServer.TabIndex = 1;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Connect Response";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Server Msg In";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Server Msg Out";
            // 
            // txtConnectMessage
            // 
            this.txtConnectMessage.Location = new System.Drawing.Point(160, 43);
            this.txtConnectMessage.Margin = new System.Windows.Forms.Padding(4);
            this.txtConnectMessage.Name = "txtConnectMessage";
            this.txtConnectMessage.Size = new System.Drawing.Size(273, 22);
            this.txtConnectMessage.TabIndex = 5;
            // 
            // txtServerMsgIn
            // 
            this.txtServerMsgIn.Location = new System.Drawing.Point(160, 68);
            this.txtServerMsgIn.Margin = new System.Windows.Forms.Padding(4);
            this.txtServerMsgIn.Name = "txtServerMsgIn";
            this.txtServerMsgIn.Size = new System.Drawing.Size(273, 22);
            this.txtServerMsgIn.TabIndex = 5;
            // 
            // txtServerMsgOut
            // 
            this.txtServerMsgOut.Location = new System.Drawing.Point(160, 93);
            this.txtServerMsgOut.Margin = new System.Windows.Forms.Padding(4);
            this.txtServerMsgOut.Name = "txtServerMsgOut";
            this.txtServerMsgOut.Size = new System.Drawing.Size(273, 22);
            this.txtServerMsgOut.TabIndex = 5;
            // 
            // btnIsRunning
            // 
            this.btnIsRunning.Location = new System.Drawing.Point(204, 10);
            this.btnIsRunning.Margin = new System.Windows.Forms.Padding(4);
            this.btnIsRunning.Name = "btnIsRunning";
            this.btnIsRunning.Size = new System.Drawing.Size(85, 28);
            this.btnIsRunning.TabIndex = 1;
            this.btnIsRunning.Text = "Is Running";
            this.btnIsRunning.UseVisualStyleBackColor = true;
            this.btnIsRunning.Click += new System.EventHandler(this.btnIsRunning_Click);
            // 
            // chkRunning
            // 
            this.chkRunning.AutoSize = true;
            this.chkRunning.Location = new System.Drawing.Point(297, 15);
            this.chkRunning.Margin = new System.Windows.Forms.Padding(4);
            this.chkRunning.Name = "chkRunning";
            this.chkRunning.Size = new System.Drawing.Size(76, 20);
            this.chkRunning.TabIndex = 6;
            this.chkRunning.Text = "Running";
            this.chkRunning.UseVisualStyleBackColor = true;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(384, 13);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(49, 22);
            this.txtPort.TabIndex = 7;
            this.txtPort.Text = "1500";
            this.txtPort.Validated += new System.EventHandler(this.txtPort_Validated);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(331, 122);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AsyncTcpTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 194);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.chkRunning);
            this.Controls.Add(this.txtServerMsgOut);
            this.Controls.Add(this.txtServerMsgIn);
            this.Controls.Add(this.txtConnectMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIsRunning);
            this.Controls.Add(this.btnStopServer);
            this.Controls.Add(this.btnStartServer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AsyncTcpTest";
            this.Text = "AsyncTcpTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConnectMessage;
        private System.Windows.Forms.TextBox txtServerMsgIn;
        private System.Windows.Forms.TextBox txtServerMsgOut;
        private System.Windows.Forms.Button btnIsRunning;
        private System.Windows.Forms.CheckBox chkRunning;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnClose;
    }
}