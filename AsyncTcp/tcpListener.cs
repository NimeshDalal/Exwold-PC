using System;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace ITS.Exwold.Desktop.AsyncTcp
{
    public class tcpListener
    {
        #region Property fields
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
        public tcpListener(int Port)
        {
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
                await serverTask;

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
                Console.WriteLine($"Stop Err: {ex.Message}");
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
							string reply = await ReplyMsgAsync(message);

							Console.WriteLine($"Sending reply {reply}");


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
        private async Task<string> ReplyMsgAsync(string Message)
        {
            //txtServerMsgIn.BeginInvoke((Action)delegate ()
            //{
            //    txtServerMsgIn.Text = Message;
            //});
            RxMessage = Message; 
            string sRtn = string.Empty;
            await Task.Delay(1000);
            switch (Message)
            {
                case "Mesh":
                    sRtn = "Reply with Mesh";
                    break;
                case "Hello":
                    sRtn = "Hi there";
                    break;
                case "Print":
                    sRtn = "What to print";
                    break;
                default:
                    sRtn = "Whaaaaaat...";
                    break;
            }
            if (txtServerMsgIn != null)
            {
                txtServerMsgIn.BeginInvoke((Action)delegate ()
                {
                    txtServerMsgIn.Text = sRtn;
                });
            }
            if (txtServerMsgOut != null)
            {
                txtServerMsgOut.BeginInvoke((Action)delegate ()
                {
                    txtServerMsgOut.Text = sRtn;
                });
            }
            TxMessage = sRtn;
            Console.WriteLine($"Message in:{Message}, Reply:{sRtn}");

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
            Console.WriteLine($"ServerMessage: {e.Message}");
            SvrMessage = e.Message;
        }
        #endregion
    }
}
