/* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 * Project:     008768 - Phase 2 Traceability System for Crop Unique Identification
 * Copyright:   (c) Copyright 2020 Industrial Technology Systems Ltd. All Rights Reserved.
 * Filename:    clsMx300N.cs
 *              Scans a TCP Port as a TCP client
 *              Runs asynchronously until stopped
 * Description: Data Logic  300N Scanner read
 * FileVersion  Build       Date        Project/CRF.    Change By       References
 * 1.00         1.00.00.00  Oct 2020    008768          Nimesh Dalal    Phase 2 Build
 *              Initial build
 * ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.ComponentModel;

namespace ITS.Exwold.Desktop
{
    class clsMx300NDataAsync : IDisposable
    {
        #region IDisposable vars
        private bool isDisposed;
        private IntPtr nativeResource = System.Runtime.InteropServices.Marshal.AllocHGlobal(100);
        #endregion
        #region IDisposable Methods
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;

            if (disposing)
            {
                // Tidy up the TcpClient
                if (_client != null)
                {
                    if (_client.Connected)
                        _client.Close();

                    _client.Dispose();
                }
            }

            // free native resources if there are any.
            if (nativeResource != IntPtr.Zero)
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(nativeResource);
                nativeResource = IntPtr.Zero;
            }

            isDisposed = true;
        }
        // NOTE: Leave out the finalizer altogether if this class doesn't
        // own unmanaged resources, but leave the other methods
        // exactly as they are.
        ~clsMx300NDataAsync()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }
        #endregion
        #region Local Variables
        private int _port = int.MinValue;
        private System.Net.IPAddress _ipaddr;
        private System.Net.Sockets.TcpClient _client;
        private CancellationTokenSource _cancelMultiRead = new CancellationTokenSource();
        private ListBox _logControl;
        private Control _ctrlgoodreads;
        private Control _ctrlreads;
        #endregion
        #region Properties
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }
        public System.Net.IPAddress IPAddr
        {
            get { return _ipaddr; }
            set { _ipaddr = value; }
        }
        public System.Net.Sockets.TcpClient Client
        {
            get { return _client; }
            set { _client = value; }
        }
        public ListBox LogControl
        {
            get { return _logControl; }
            set { _logControl = value; }
        }
        public Control ctrlReads
        {
            get { return _ctrlreads; }
            set { _ctrlreads = value; }
        }
        public Control ctrlGoodReads
        {
            get { return _ctrlgoodreads; }
            set { _ctrlgoodreads = value; }
        }
        #endregion
        #region Constructor(s)
        public clsMx300NDataAsync() { }
        public clsMx300NDataAsync(System.Net.IPAddress IPAddr, int Port)
        {
            _ipaddr = IPAddr;
            _port = Port;
            connectTcpClient();
            this.ScannerRead += mx300n_ScannerRead;
            this.ScannerReadStarted += mx300n_ScannerReadStarted;
            this.ScannerReadStopped += mx300n_ScannerReadStopped;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Connect TcpClient to the IP and Port supplied when constructing the class
        /// </summary>
        public async void connectTcpClient()
        {
            if (_ipaddr == null)
                throw new ArgumentNullException("IPAddress");

            if (_port == int.MinValue)
                throw new ArgumentException("Port number not set");

            bool bRtn = false;
            bRtn = await connectTcpClient(_ipaddr, _port);
        }
        /// <summary>
        /// Read the TcpSocket once, using the TcpClient defined when constructing the class
        /// This is a synchronous call to an async method
        /// </summary>
        /// <returns>The data string read from the socket</returns>
        public string ReadTcpSocket()
        {
            Task<string> rtn = Task.Run(async () => await ReadTcpSocket(_client));
            Console.WriteLine("Socket Read");
            return rtn.Result;
        }
        /// <summary>
        /// Cancels the multiple readings of the socket 
        /// (started by multiReadTcpSocket)
        /// </summary>
        public void CancelMultiRead()
        {
            _cancelMultiRead.Cancel();
        }
        /// <summary>
        /// Adds the OnScannerRead event to this class, but only permits one
        /// </summary>
        /// <param name="Enable">Enable = Consume the event, Disable = Ignore the event</param>
        /// <returns>Number of Event enabled</returns>
        public int EnableOnScannerRead(bool Enable)
        {
            int numEventSubscriptions = -1;
            //Get the number of times the event is subscribed (within this class)
            try
            {
                if (ScannerRead == null)
                {
                    numEventSubscriptions = 0;
                }
                else
                {
                    numEventSubscriptions = this.ScannerRead.GetInvocationList().Where(t => t.Target.GetType() == this.GetType()).Count();                    
                }
                //Console.WriteLine("Before Total Events {0}, Number in class {0}", this.ScannerRead.GetInvocationList().Length.ToString(), numEventSubscriptions);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            switch (Enable)
            {
                case true:
                    //Asked to add the event
                    if (numEventSubscriptions == 0)
                    {
                        //Add a new event
                        this.ScannerRead += mx300n_ScannerRead;
                    }
                    break;
                case false:
                    //Asked to remove the event
                    if (numEventSubscriptions > 0)
                    {
                        this.ScannerRead -= mx300n_ScannerRead;
                    }
                    break;
            }
            if (ScannerRead == null)
                return 0;
            else
                return numEventSubscriptions = this.ScannerRead.GetInvocationList().Where(t => t.Target.GetType() == this.GetType()).Count();
            
        }
        #region Event Handler Declartions
        /// <summary>
        /// Scanner Read EventHandler
        /// </summary>
        public event EventHandler<ScannerReadEventArgs> ScannerRead;
        public event EventHandler<ScannerReadStatusEventArgs> ScannerReadStarted;
        public event EventHandler<ScannerReadStatusEventArgs> ScannerReadStopped;
        #endregion
        /// <summary>
        /// Start reading the TcpClient until stopped
        /// If the client is not connected, it will try to re-establish the connection, and raise an exception if it cannot
        /// Events raised:
        /// On reading start (after suucessful connection)
        /// On reading cancellation request received
        /// On acquisition of data
        /// </summary>
        /// <param name="ReadInterval">Time (in msec) is the time between reads</param>
        public async void multiReadTcpSocket(int ReadInterval)
        {
            if (ReadInterval < 50)
                throw new ArgumentOutOfRangeException("ReadInterval", "The read interval must be > 50 msec");

            //Recreate the token source - to clear any previous cancellation request
            _cancelMultiRead = new CancellationTokenSource();

            bool TcpSocketConnected = false;
            #region Verify Socket is connected
            try
            {
                //Connect to the client if not connected
                if ((_client == null) || !_client.Connected)
                {
                    TcpSocketConnected = await Task.Run(async () =>
                    {
                        return await connectTcpClient(_ipaddr, _port);
                    });
                }
                else
                {
                    TcpSocketConnected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
            if (!TcpSocketConnected)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendLine("TcpSocket failed to connect to:");
                msg.AppendLine("IPAddress :" + _ipaddr.ToString());
                msg.AppendLine("On Port :" + _port.ToString());
                msg.AppendLine("At :" + System.DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss"));
                throw new Exception(msg.ToString());
            }

            //We are connected to the socket, not start to read the data
            try
            {
                CancellationToken cancelReading = _cancelMultiRead.Token;
                ScannerReadEventArgs readEventArgs;
                ScannerReadStatusEventArgs statusEventArgs = new ScannerReadStatusEventArgs();
                await Task.Run(async () =>
                {
                    int readstried = 0;
                    int goodreads = 0;
                    string scannerRawData = string.Empty;

                    //Raise the start event
                    statusEventArgs.Status = true;
                    statusEventArgs.Message = "Connected to socket.  Start reading";
                    OnScannerReadStart(statusEventArgs);

                    //Loop until stopper
                    while (true)
                    {
                        readstried++;
                        //Reset the counters if they max out
                        if (readstried >= int.MaxValue) { readstried = 0; }
                        if (goodreads >= int.MaxValue) { goodreads = 0; }

                        //Read the scanner
                        scannerRawData = await ReadTcpSocket(_client);
                        if (!string.IsNullOrEmpty(scannerRawData))
                        {
                            goodreads++;
                            //Log data back the UI
                            LogScannerReading(scannerRawData, readstried, goodreads);
                            LogStatus(_ctrlgoodreads, goodreads);

                            //Create our event data
                            readEventArgs = new ScannerReadEventArgs();
                            readEventArgs.IPAddr = _ipaddr;
                            readEventArgs.Port = _port;
                            readEventArgs.RawData = scannerRawData;
                            readEventArgs.ReadsTried = readstried;
                            readEventArgs.GoodReads = goodreads;
                            //Raise the Read event
                            OnScannerRead(readEventArgs);

                        }
                        if (cancelReading.IsCancellationRequested)
                        {
                            //Raise the Stopped event
                            statusEventArgs = new ScannerReadStatusEventArgs();
                            statusEventArgs.Status = true;
                            statusEventArgs.Message = "Stop requested";
                            //Raise the event
                            OnScannerReadStop(statusEventArgs);
                        }

                        //Stop if requested
                        cancelReading.ThrowIfCancellationRequested();
                        //Wait to read the next time
                        await Task.Delay(ReadInterval);
                        //Log data back the UI
                        LogStatus(_ctrlreads, readstried);                        
                    }
                }
                );
            }
            catch (OperationCanceledException ex)
            {
                //NOTE:- This error is rethrown after it is handled
                MessageBox.Show(ex.Message.ToString(), "multiSocketRead Cancelled");
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Connect TcpClient to the IP and Port supplied 
        /// </summary>
        /// <param name="ipAddr">IPAddress (v4 or v6) of the server</param>
        /// <param name="port">The Port number to connect to</param>
        /// <returns>true if the client is successfully connected</returns>
        private async Task<bool> connectTcpClient(System.Net.IPAddress ipAddr, int port)
        {
            bool bRtn = false;

            //Check if we are currently connected, and if so don't bother again
            if ((_client != null) && (_client.Connected))
                return true;

            /*
             * Create a new client and await the result of the connection
             * If the IPAddress specified is unavailabel this will take time to timeout
             */
            _client = new System.Net.Sockets.TcpClient();
            try
            {
                //Connect to the IP and port
                await _client.ConnectAsync(ipAddr.ToString(), port);
                bRtn = (_client != null && _client.Connected);
            }
            catch (ArgumentException ex)
            { System.Windows.Forms.MessageBox.Show(ex.ToString(), "The ipAddresses parameter is null."); }
            catch (System.Net.Sockets.SocketException ex)
            { System.Windows.Forms.MessageBox.Show(ex.ToString(), "The port number is not valid."); }
            catch (ObjectDisposedException ex)
            { System.Windows.Forms.MessageBox.Show(ex.ToString(), "The Socket has been closed."); }
            catch (System.Security.SecurityException ex)
            { System.Windows.Forms.MessageBox.Show(ex.ToString(), "A caller higher in the call stack does not have permission for the requested operation."); }
            catch (NotSupportedException ex)
            { System.Windows.Forms.MessageBox.Show(ex.ToString(), "This method is valid for sockets that use the InterNetwork flag or the InterNetworkV6 flag."); }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show(ex.ToString(), "Unknown error."); }

            return bRtn;
        }
        /// <summary>
        /// Read data from the TcpClient provided
        /// The data is read asynchronously
        /// </summary>
        /// <param name="tcpClient">TcpClient to read from</param>
        /// <returns></returns>
        private async Task<string> ReadTcpSocket(System.Net.Sockets.TcpClient tcpClient)
        {
            if (tcpClient == null || !tcpClient.Connected)
            {
                throw new Exception("TcpClient is not connected");
            }
            // We have a connection so we can read the data
            //If there isn't any data available, don't bother to continue
            if (tcpClient.Available == 0)
            {
                return string.Empty;
            }

            // Create:
            // string to contain our data
            // the data stream to read the data from, 
            // a buffer to put the data into, and
            // and encoder to convert the data
            string scannerData = string.Empty;
            System.IO.Stream dataStrm = tcpClient.GetStream();
            byte[] bBuffer = new byte[1000];
            ASCIIEncoding ascii = new ASCIIEncoding();
            //
            // Read the data into our buffer (asynchronously)
            //
            int NoBytes = await dataStrm.ReadAsync(bBuffer, 0, 1000);
            scannerData = ascii.GetString(bBuffer, 0, NoBytes);

            return scannerData;
        }
        
        
        private void LogScannerReading(string msg, int scans, int reads)
        {
            _logControl.BeginInvoke((Action)delegate ()
            {
                _logControl.Items.Insert(0, $"{msg}, Total Scans {scans.ToString()}, Reads {reads.ToString()}");
            });
        }
        private void LogStatus(Control ctrl, int value)
        {
            ctrl.BeginInvoke((Action)delegate ()
            {
                ctrl.Text = value.ToString();
            });
        }

        #endregion
        #region Events
        /// <summary>
        /// OnScannerRead Event
        /// </summary>
        /// <param name="e">ScannerReadEventArgs</param>
        protected virtual void OnScannerRead(ScannerReadEventArgs e)
        {
            EventHandler<ScannerReadEventArgs> eventHandler = ScannerRead;
            if (eventHandler != null)
                eventHandler(this, e);
        }
        protected virtual void OnScannerReadStart(ScannerReadStatusEventArgs e)
        {
            EventHandler<ScannerReadStatusEventArgs> eventHandler = ScannerReadStarted;
            if (eventHandler != null)
                eventHandler(this, e);
        }
        protected virtual void OnScannerReadStop(ScannerReadStatusEventArgs e)
        {
            EventHandler<ScannerReadStatusEventArgs> eventHandler = ScannerReadStopped;
            if (eventHandler != null)
                eventHandler(this, e);
        }
        #endregion
        #region Event Comsumers
        /// <summary>
        /// Class ScannerRead event consumer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="a"></param>
        private void mx300n_ScannerRead(object sender, ScannerReadEventArgs a)
        {
            Console.WriteLine("Scanner read event fired");
        }
        private void mx300n_ScannerReadStarted(object sender, ScannerReadStatusEventArgs a)
        {
            Console.WriteLine("Scanner read event fired");
        }
        private void mx300n_ScannerReadStopped(object sender, ScannerReadStatusEventArgs a)
        {
            Console.WriteLine("Scanner read event fired");
        }
        #endregion
    }
    public class ScannerReadEventArgs : EventArgs 
    { 
        public IPAddress IPAddr { get; set; }
        public int Port { get; set; }
        public string RawData { get; set; }
        public int ReadsTried { get; set; }
        public int GoodReads { get; set; }
    }
    public class ScannerReadStatusEventArgs : EventArgs
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
