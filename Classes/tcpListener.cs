﻿using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Data;

namespace ITS.Exwold.Desktop.AsyncTcp
{
    public class tcpListener
    {
        #region Property fields
        private DataInterface.execFunction _db = null;
        private int _serverPort;
        private AsyncTcpListener _server;
        private Task serverTask;
        private const string cstConnectionReply = "::Stand By::";

        private string RxMessage = string.Empty;
        private string TxMessage = string.Empty;
        private string ConnMessage = string.Empty;
        private string SvrMessage = string.Empty;
        private bool Running = false;

        private CheckBox _chkRunning;
        private TextBox _txtConnectMessage;
        private TextBox _txtServerMsgOut;
        private TextBox _txtServerMsgIn;
        #endregion
        #region Public Properties
        public int ServerPort
        {
            get => _serverPort;
            set { _serverPort = value; }
        }
        public CheckBox chkRunning
        {
            get => _chkRunning;
            set { _chkRunning = value; }
        }
        public TextBox txtConnectMessage
        {
            get => _txtConnectMessage;
            set { _txtConnectMessage = value; }
        }
        public TextBox txtServerMsgOut
        {
            get => _txtServerMsgOut;
            set { _txtServerMsgOut = value; }
        }
        public TextBox txtServerMsgIn
        {
            get => _txtServerMsgIn;
            set { _txtServerMsgIn = value; }
        }
        #endregion
        #region Constructor
        public tcpListener(int Port, DataInterface.execFunction database)
        {
            _db = database;
            _serverPort = Port;
        }
        #endregion
        #region Public Methods
        public async void StartServer()
        {
            if (!ServerRunning())
            {
                if (_server != null)
                {
                    _server.Stop(true);
                    _server = null;
                }
                _server = getListener(_serverPort);
                _server.Message += (s, a) => ServerMessage(s, a);
                serverTask = _server.RunAsync();
                try
                {
                    await serverTask;
                }
                catch { }
                Running = ServerRunning();

                if (_chkRunning != null)
                {
                    _chkRunning.BeginInvoke((Action)delegate ()
                    {
                        _chkRunning.Checked = ServerRunning();
                    });
                }
            }
        }        
        public void StopServer()
        {
            try
            {
                _server.Stop(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{Logging.ThisMethod()} Stop Err: {ex.Message}");
            }
        }        
        public bool ServerRunning()
        {
            return (serverTask != null &&
                (serverTask.Status == TaskStatus.WaitingForActivation ||
                serverTask.Status == TaskStatus.Running));
        }
        #endregion
        #region Private Methods
        private AsyncTcpListener getListener(int ListenOnPort)
		{
			var listener = new AsyncTcpListener
			{
				IPAddress = IPAddress.IPv6Any,
				Port = ListenOnPort,
				ClientConnectedCallback = tcpClient =>
					new AsyncTcpClient
					{
						ServerTcpClient = tcpClient,
						ConnectedCallback = async (serverClient, isReconnected) =>
						{
							await Task.Delay(100);
							string connectedMsg = await ConnectedCallbackdAsync();
							byte[] bytes = Encoding.UTF8.GetBytes($"{connectedMsg}");
							await serverClient.Send(new ArraySegment<byte>(bytes, 0, bytes.Length));
						},
						ReceivedCallback = async (serverClient, count) =>
						{
							byte[] bytes = serverClient.ByteBuffer.Dequeue(count);
							string message = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
							string reply = await tcpListenerReplyMsgAsync(message);

							Console.WriteLine($"{Logging.ThisMethod()} Sending reply {reply}");


							bytes = Encoding.UTF8.GetBytes(reply);
							await serverClient.Send(new ArraySegment<byte>(bytes, 0, bytes.Length));

							//if (message == "bye")
							//{
							//	// Let the server close the connection
							//	serverClient.Disconnect();
							//}
						}
					}.RunAsync()
			};
			return listener;
		}
        /// <summary>
        /// Actions the messages send by the hand held scanner
        /// </summary>
        /// <param name="Message">Message body send by the scanner</param>
        /// <returns></returns>
        private async Task<string> tcpListenerReplyMsgAsync(string Message)
        {
            RxMessage = string.Empty;        // The reply we are going to determine
            string sRtn = string.Empty;

            // Break up the message contents to determine the instruction and the data payload
            string[] msgContents = Message.Split(':');
            if (msgContents.Length != 2) { throw new ArgumentException("Invalid TCP Message"); }

            // Get the messge contents
            string ScannerAction = msgContents[0];
            int PalletUId = int.Parse(msgContents[1]);


            /*
             * Process the message from the scanner
             */
            if (ScannerAction == "UPDATE")
            {
                // Get a pointer to the MainForm
                MainStatusForm mainStatusForm = (MainStatusForm)Application.OpenForms[0];
                sRtn = await mainStatusForm.RefreshLineInfo() ? "OK" : "ERROR";
            }
            else if (ScannerAction == "PRINT" || ScannerAction =="REPRINT")
            {
                int PalletBatchCount = int.MinValue;
                PalletLabelMethods plMethods = new PalletLabelMethods(_db);

                // Get the PalletBatch data for this pallet
                // We should have 1 PalletBatch, and the status should be in progress
                DataTable dtBatchesOnPallet = await _db.executeSP("[GUI].[getBatchesOnPalletByPalletId]", true);
                PalletBatchCount = (dtBatchesOnPallet != null) ? dtBatchesOnPallet.Rows.Count : int.MinValue;

                if (PalletBatchCount == 1)  //Should have only 1 PalletBatch record
                {
                    int BatchStatus = int.MinValue;
                    int.TryParse(dtBatchesOnPallet.Rows[0]["Status"].ToString(), out BatchStatus);
                    if (BatchStatus != 1)  // The status must be 1, In-Progress
                    {
                        sRtn =  "CANCELLED";
                    }
                    else
                    {
                        //Run the print 
                        sRtn =  await plMethods.PrintPalletLabels(PalletUId) ? "OK" : "ERROR";
                    }
                }
                else sRtn = "ERROR";  
            }
            else
            {
                sRtn = "ERROR";
            }
            TxMessage = sRtn;
            Console.WriteLine($"{Logging.ThisMethod()} Message in:{Message}, Reply:{sRtn}");

            return sRtn;
        }
        private async Task<string> ConnectedCallbackdAsync()
        {
            string sRtn = cstConnectionReply;
            await Task.Delay(50);
            if (_txtConnectMessage != null)
            {
                _txtConnectMessage.BeginInvoke((Action)delegate ()
                {
                    _txtConnectMessage.Text = sRtn;
                });
            }
            ConnMessage = sRtn;
            return sRtn;
        }
        private void ServerMessage(object sender, AsyncTcpEventArgs e)
        {
            Console.WriteLine($"{Logging.ThisMethod()} ServerMessage: {e.Message}");
            SvrMessage = e.Message;
        }
        #endregion
    }
}
