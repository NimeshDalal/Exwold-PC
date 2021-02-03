using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITS.Exwold.Desktop.AsyncTcp
{
    public partial class AsyncTcpTest : Form
    {
        private tcpListener _listener;
        private int _serverPort = 1500;
        public AsyncTcpTest(DataInterface.execFunction database)
        {
            InitializeComponent();
            _listener = new tcpListener(1500, database);
            _listener.txtConnectMessage = txtConnectMessage;
            _listener.txtServerMsgIn = txtServerMsgIn;
            _listener.txtServerMsgOut = txtServerMsgOut;
            _listener.chkRunning = chkRunning;
            txtPort.Text = _serverPort.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIsRunning_Click(object sender, EventArgs e)
        {
            _listener.ServerRunning();
        }

        private void txtPort_Validated(object sender, EventArgs e)
        {
            _serverPort = int.Parse((sender as TextBox).Text);
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            _listener.StartServer();
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            _listener.StopServer();
        }

    }
}
