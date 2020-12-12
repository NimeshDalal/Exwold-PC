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
using System.Reflection;
using System.Diagnostics;
using System.Net.NetworkInformation;

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
                // If scanning then need to stop
                if (IsScanning())
                {
                    StopScanning();
                    _taskScanning.Wait();
                    _cancelSource.Dispose();
                    _taskScanning.Dispose();
                }

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
        private int _scanRate;
        private ListBox _logControl;
        private Control _ctrlgoodreads;
        private Control _ctrlreads;

        private string _scannerId = string.Empty;
        private int _palletBatchUId = 0;
        private int _productionLineUId = 0;
        //Tasks
        private Task<IPStatus> _taskAvailable;
        private Task<bool> _taskConnected;
        private Task _taskScanning;
        private CancellationTokenSource _cancelSource = new CancellationTokenSource();
        private CancellationToken _cancelToken;

        //Simulation
        private string _simulateMsg;
        public string SimulateMsg
        {
            get { return _simulateMsg; }
            set { _simulateMsg = value; }
        }
        private Task _taskSimulateScanning;

        private List<GS1Identifiers> _parsedData = null;
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
        public int ScanRate
        {
            get { return _scanRate; }
            set { _scanRate = value; }
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
        public string ScannerId
        {
            get { return _scannerId; }
            set { _scannerId = value; }
        }
        public int PalletBatchUId
        {
            get { return _palletBatchUId; }
            set { _palletBatchUId = value; }
        }
        public int ProductionLineUId
        {
            get { return _productionLineUId; }
            set { _productionLineUId = value; }
        }
        #endregion
        #region Event Handler Declartions
        /// <summary>
        /// Scanner Read EventHandler
        /// </summary>
        public event EventHandler<ScannerReadEventArgs> ScannerRead;
        public event EventHandler<ScannerReadStatusEventArgs> ScannerReadStarted;
        public event EventHandler<ScannerReadStatusEventArgs> ScannerReadStopped;
        public event EventHandler<ScannerDataEventArgs> ScannerDataParsed;
        #endregion
        #region Constructor(s)
        public clsMx300NDataAsync(System.Net.IPAddress IPAddr, int Port)
        {
            _ipaddr = IPAddr;
            _port = Port;
            _client = new TcpClient();

            //connectTcpClient();

            // subscribe to the local events
            // Generally not required
            //this.ScannerRead += mx300n_ScannerRead;
            //this.ScannerReadStarted += mx300n_ScannerReadStarted;
            //this.ScannerReadStopped += mx300n_ScannerReadStopped;
        }
        #endregion
        #region Public Methods
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
        /// Cancels the scanning of the tcp socket 
        /// </summary>
        public void StopScanning()
        {
            _cancelToken = _cancelSource.Token;
            _cancelSource.Cancel();
        }       
        /// <summary>
        /// Begin the scanning of the tcp port at the rate specified
        /// </summary>
        /// <param name="ReadInterval">Interval (in ms) to interrogate the port</param>
        public async void StartScanning(int ReadInterval)
        {
            _cancelSource = new CancellationTokenSource();
            try
            {
                _taskScanning = StartScanningTask(ReadInterval);
                if (_taskScanning != null)
                {
                    await _taskScanning;
                }
            }
            catch (OperationCanceledException)
            { }
            catch
            {
                throw;
                //Mx300NLogging.LogMessage(Mx300NLogging.currMethod(), ex);
            }
            finally
            {
                _cancelSource.Dispose();
            }
        }
        /// <summary>
        /// Starts a scanning 
        /// </summary>
        /// <param name="ReadInterval"></param>
        public async void StartScanningSimulation(int ReadInterval)
        {
            _cancelSource = new CancellationTokenSource();
            try
            {
                _taskSimulateScanning = StartScanningSimulationTask(ReadInterval);
                if (_taskSimulateScanning != null)
                {
                    await _taskSimulateScanning;
                }
            }
            catch (OperationCanceledException)
            { }
            catch (Exception ex)
            {
                Mx300NLogging.LogMessage(Mx300NLogging.currMethod(), ex);
            }
            finally
            {
                _cancelSource.Dispose();
            }
        }
        public async Task<bool> TryStart()
        {
            try
            {
                bool bPing = await IsAvailable();
                if (!bPing) { return false; }

                bool btcpConnected = (_client != null && _client.Connected);
                if (!btcpConnected) { return false; }

                return IsScanning();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Mx300NLogging.currMethod(), ex);
            }
        }

        #region Status Methods
        /// <summary>
        /// Ping result of the IPAddr
        /// </summary>
        /// <returns>True is successful</returns>
        public async Task<bool> IsAvailable()
        {
            _taskAvailable = ping(_ipaddr);
            IPStatus pingRtn = await _taskAvailable;
            return (pingRtn == IPStatus.Success);
        }
        /// <summary>
        /// Check the tcpSocket connection
        /// Creates a new connection if required, and of the connection does not match
        /// the IP and Port a new connection is made
        /// </summary>
        /// <returns>True if connected to the IPAddr.Port</returns>
        public async Task<bool> IsConnected()
        {
            try
            {
                bool bPing = await IsAvailable();
                if (!bPing) { return false; }
                //If the client is null then create a new one
                if (_client == null)
                {
                    _taskConnected = connectTcpClient(_ipaddr, _port);
                    bool connectionStatus = await _taskConnected;
                    return connectionStatus;
                }
                else
                {

                    if (!_client.Connected)
                    { 
                        return await connectTcpClient(_ipaddr, _port); 
                    }
                    else
                    {
                        // Check that we are connected to the correct port
                        IPEndPoint remoteEndPoint = (IPEndPoint)_client.Client.RemoteEndPoint;
                        Console.WriteLine($"{remoteEndPoint.Address}, {remoteEndPoint.Address.Equals(_ipaddr)} : {remoteEndPoint.Port}, {remoteEndPoint.Port == _port}");
                        if (remoteEndPoint.Address.Equals(_ipaddr) & remoteEndPoint.Port == _port)
                        {
                            return _client.Client.Connected;
                        }
                        else
                        {
                            // We are connected to the wrong socket, so dispose the old one and recreate it
                            _client.Close();
                            _client.Dispose();
                            _taskConnected = connectTcpClient(_ipaddr, _port);
                            bool connectionStatus = await _taskConnected;
                            return connectionStatus;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Mx300NLogging.currMethod(), ex);
            }
        }
        /// <summary>
        /// Check whether the scanning thrad is running
        /// </summary>
        /// <returns>True is running</returns>
        public bool IsScanning()
        {
            return ((_taskScanning != null) &&
                       (_taskScanning.IsCompleted == false ||
                        _taskScanning.Status == TaskStatus.Running ||
                        _taskScanning.Status == TaskStatus.WaitingToRun ||
                        _taskScanning.Status == TaskStatus.WaitingForActivation));
        }

        #endregion
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
        /// <summary>
        /// Start reading the TcpClient until stopped
        /// If the client is not connected, it will try to re-establish the connection, and raise an exception if it cannot
        /// Events raised:
        /// On reading start (after suucessful connection)
        /// On reading cancellation request received
        /// On acquisition of data
        /// </summary>
        /// <param name="ReadInterval">Time (in msec) is the time between reads</param>
        #endregion


        #region Private Methods
        private async Task<IPStatus> ping(IPAddress ipaddr)

        {
            Ping ping = new Ping();
            PingReply reply;
            try
            {
                reply = await ping.SendPingAsync(ipaddr.ToString());
            }
            catch
            {
                reply = null;
            }
            return reply.Status;
        }
        /// <summary>
        /// Connect TcpClient to the IP and Port supplied 
        /// </summary>
        /// <param name="ipAddr">IPAddress (v4 or v6) of the server</param>
        /// <param name="port">The Port number to connect to</param>
        /// <returns>true if the client is successfully connected</returns>
        private async Task<bool> connectTcpClient(IPAddress ipAddr, int port)

        {
            bool bRtn = false;

            //Check if we are currently connected, and if so don't bother again
            if ((_client != null) && (_client.Client.Connected))
                return true;

            /*
             * Create a new client and await the result of the connection
             * If the IPAddress specified is unavailable this will take time to timeout
             */
            _client = new TcpClient();
            try
            {
                //Connect to the IP and port
                Task connectTask = _client.ConnectAsync(ipAddr.ToString(), port);
                await connectTask;
                bRtn = (_client != null && _client.Connected);
            }
            catch (ArgumentException ex)
            { 
                //Mx300NLogging.LogMessage(Mx300NLogging.currMethod(), "The ipAddresses parameter is null.", ex);
                throw new InvalidOperationException($"{Mx300NLogging.currMethod()}\nThe ipAddresses parameter is null.", ex);
            }
            catch (System.Net.Sockets.SocketException ex)
            { 
                //Mx300NLogging.LogMessage(Mx300NLogging.currMethod(), $"The port number is not valid.", ex);
                throw new InvalidOperationException($"{Mx300NLogging.currMethod()}\nThe port number is not valid.", ex);
            }
            catch (ObjectDisposedException ex)
            { 
                //Mx300NLogging.LogMessage(Mx300NLogging.currMethod(), "The Socket has been closed.", ex);
                throw new InvalidOperationException($"{Mx300NLogging.currMethod()}\nThe Socket has been closed.", ex);
            }
            catch (System.Security.SecurityException ex)
            { 
                //Mx300NLogging.LogMessage(Mx300NLogging.currMethod(), "A caller higher in the call stack does not have permission for the requested operation.", ex);
                throw new InvalidOperationException($"{Mx300NLogging.currMethod()}\nA caller higher in the call stack does not have permission for the requested operation.", ex);
            }
            catch (NotSupportedException ex)
            { 
                //Mx300NLogging.LogMessage(Mx300NLogging.currMethod(), "This method is valid for sockets that use the InterNetwork flag or the InterNetworkV6 flag.", ex);
                throw new InvalidOperationException($"{Mx300NLogging.currMethod()}\nThis method is valid for sockets that use the InterNetwork flag or the InterNetworkV6 flag.", ex);
            }
            catch (Exception ex)
            { 
                //Mx300NLogging.LogMessage(Mx300NLogging.currMethod(), "Unknown error.", ex);
                throw new InvalidOperationException($"{Mx300NLogging.currMethod()}\nUnknown error.", ex);
            }

            return bRtn;
        }
        /// <summary>
        /// Read data from the TcpClient provided
        /// The data is read asynchronously
        /// </summary>
        /// <param name="tcpClient">TcpClient to read from</param>
        /// <returns></returns>
        private async Task<string> ReadTcpSocket(TcpClient tcpClient)
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
        /// <summary>
        /// Begin the periodic reading of the scanner port
        /// </summary>
        /// <param name="ReadInterval">Interval between reads in ms</param>
        /// <returns>the scanning task</returns>
        private async Task StartScanningTask(int ReadInterval)
        {
            if (ReadInterval < 50)
                throw new ArgumentOutOfRangeException("ReadInterval", "The read interval must be > 50 msec");

            if ((_client == null) || !_client.Connected)
            {
                throw new InvalidOperationException("The tcpSocket is not connected");
            }

            CancellationToken cancelReading = _cancelSource.Token;
            ScannerReadEventArgs readEventArgs;
            ScannerDataEventArgs dataEventArgs;
            ScannerReadStatusEventArgs statusEventArgs = new ScannerReadStatusEventArgs();
            int readstried = 0;
            int goodreads = 0;
            string scannerRawData = string.Empty;

            //Raise the start event
            statusEventArgs.Status = true;
            statusEventArgs.Message = "Connected to socket.  Start reading";
            statusEventArgs.IPAddr = _ipaddr;
            statusEventArgs.Port = _port;
            statusEventArgs.PalletBatchUId = _palletBatchUId;
            statusEventArgs.ProductionLineUId = _productionLineUId;
            OnScannerReadStart(statusEventArgs);
            //Loop until stopped
            while (true)
            {
                readstried++;
                LogStatus(_ctrlreads, readstried);
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
                    readEventArgs = new ScannerReadEventArgs
                    {
                        IPAddr = _ipaddr,
                        Port = _port,
                        RawData = scannerRawData,
                        ReadsTried = readstried,
                        GoodReads = goodreads,
                        PalletBatchUId = _palletBatchUId,
                        ProductionLineUId = _productionLineUId,
                        ScannerId = _scannerId,
                    };
                    //Raise the Read event
                    OnScannerRead(readEventArgs);

                    //Parse the data read
                    _parsedData = parseScannerData(ScannerId, scannerRawData);
                    dataEventArgs = new ScannerDataEventArgs
                    {
                        GTIN = _parsedData.Find(ele => ele.Name == "GTIN").DataValue,
                        ProdDate = _parsedData.Find(ele => ele.Name == "ProdDate").DataValue,
                        LotNo = _parsedData.Find(ele => ele.Name == "LotNo").DataValue,
                        ProdName =
                            _parsedData.Find(ele => ele.Name == "ProdName1").DataValue +
                            _parsedData.Find(ele => ele.Name == "ProdName2").DataValue,
                        ScannedDate = DateTime.Now,
                        PalletBatchUId = _palletBatchUId,
                        ProductionLineUId = _productionLineUId,
                        ScannerId = ScannerId,
                    };
                    //Raise the Read event
                    OnScannerDataParsed(dataEventArgs);
                }
                if (cancelReading.IsCancellationRequested)
                {
                    //Raise the Stopped event
                    statusEventArgs = new ScannerReadStatusEventArgs()
                    {
                        Status = true,
                        Message = "Stop requested"
                    };
                    //Raise the event
                    OnScannerReadStop(statusEventArgs);
                }

                //Stop if requested
                cancelReading.ThrowIfCancellationRequested();
                //Wait to read the next time
                await Task.Delay(ReadInterval);
            }
        }
        private async Task StartScanningSimulationTask(int ReadInterval)
        {
            CancellationToken cancelReading = _cancelSource.Token;
            ScannerReadEventArgs readEventArgs;
            ScannerDataEventArgs dataEventArgs;
            ScannerReadStatusEventArgs statusEventArgs = new ScannerReadStatusEventArgs();

            int readstried = 0;
            int goodreads = 0;
            string scannerRawData = string.Empty;

            //Raise the start event
            statusEventArgs.Status = true;
            statusEventArgs.Message = "Connected to socket.  Start reading";
            OnScannerReadStart(statusEventArgs);

            //Loop until stopped
            while (true)
            {
                readstried++;
                LogStatus(_ctrlreads, readstried);
                //Reset the counters if they max out
                if (readstried >= int.MaxValue) { readstried = 0; }
                if (goodreads >= int.MaxValue) { goodreads = 0; }

                //Read the scanner
                scannerRawData = _simulateMsg;

                if (!string.IsNullOrEmpty(scannerRawData))
                {
                    goodreads++;
                    //Log data back the UI
                    LogScannerReading(scannerRawData, readstried, goodreads);
                    LogStatus(_ctrlgoodreads, goodreads);

                    //Create our event data
                    readEventArgs = new ScannerReadEventArgs
                    {
                        IPAddr = _ipaddr,
                        Port = _port,
                        RawData = scannerRawData,
                        ReadsTried = readstried,
                        GoodReads = goodreads,
                        ScannerId = _scannerId
                    };
                    //Raise the Read event
                    OnScannerRead(readEventArgs);

                    //Parse the data read
                    _parsedData = parseScannerData(ScannerId, scannerRawData);
                    dataEventArgs = new ScannerDataEventArgs
                    {
                        GTIN = _parsedData.Find(ele => ele.Name == "GTIN").DataValue,
                        ProdDate = _parsedData.Find(ele => ele.Name == "ProdDate").DataValue,
                        LotNo = _parsedData.Find(ele => ele.Name == "LotNo").DataValue,
                        ProdName =
                            _parsedData.Find(ele => ele.Name == "ProdName1").DataValue +
                            _parsedData.Find(ele => ele.Name == "ProdName2").DataValue,
                        ScannedDate = DateTime.Now,
                        PalletBatchUId = _palletBatchUId,
                        ProductionLineUId = _productionLineUId,
                        ScannerId = ScannerId,

                    };
                    //Raise the Read event
                    OnScannerDataParsed(dataEventArgs);

                }
                if (cancelReading.IsCancellationRequested)
                {
                    //Raise the Stopped event
                    statusEventArgs = new ScannerReadStatusEventArgs 
                    { 
                        Status = true,
                        Message = "Stop requested"
                    };
                //Raise the event
                OnScannerReadStop(statusEventArgs);
                }

                //Stop if requested
                cancelReading.ThrowIfCancellationRequested();
                //Wait to read the next time
                await Task.Delay(ReadInterval);

            }
        }
        private void LogScannerReading(string msg, int scans, int reads)
        {
            if (_logControl != null)
            {
                _logControl.BeginInvoke((Action)delegate ()
                {
                    _logControl.Items.Insert(0, $"{msg}, Total Scans {scans}, Reads {reads}");
                });
            }
        }
        private void LogStatus(Control ctrl, int value)
        {
            if (ctrl != null)
            {
                ctrl.BeginInvoke((Action)delegate ()
                {
                    ctrl.Text = value.ToString();
                });
            }
        }

        #endregion
        #region Events
        /// <summary>
        /// OnScannerRead Event
        /// </summary>
        /// <param name="args">ScannerReadEventArgs</param>
        protected virtual void OnScannerRead(ScannerReadEventArgs args)
        {
            //EventHandler<ScannerReadEventArgs> eventHandler = ScannerRead;
            //if (eventHandler != null)
            //    eventHandler(this, e);
            ScannerRead?.Invoke(this, args);
        }
        protected virtual void OnScannerReadStart(ScannerReadStatusEventArgs args)
        {
            //EventHandler<ScannerReadStatusEventArgs> eventHandler = ScannerReadStarted;
            //if (eventHandler != null)
            //    eventHandler(this, e);

            ScannerReadStarted?.Invoke(this, args);
        }
        protected virtual void OnScannerReadStop(ScannerReadStatusEventArgs args)
        {
            //EventHandler<ScannerReadStatusEventArgs> eventHandler = ScannerReadStopped;
            //if (eventHandler != null)
            //    eventHandler(this, e);
            ScannerReadStopped.Invoke(this, args);
        }
        protected virtual void OnScannerDataParsed(ScannerDataEventArgs args)
        {
            ScannerDataParsed?.Invoke(this, args);
        }
        #endregion
        #region Event Consumers
        /// <summary>
        /// Class ScannerRead event consumer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="a"></param>

        private void mx300n_ScannerRead(object sender, ScannerReadEventArgs a)
        {
            Console.WriteLine($"clsMx300N Scanner read event fired {a.IPAddr}");
        }
        private void mx300n_ScannerReadStarted(object sender, ScannerReadStatusEventArgs a)
        {
            Console.WriteLine($"clsMx300N Scanner read started {a.IPAddr}");
        }
        private void mx300n_ScannerReadStopped(object sender, ScannerReadStatusEventArgs a)
        {
            Console.WriteLine($"clsMx300N Scanner read stopped {a.IPAddr}");
        }
        private void mx300n_ScannerDataParsed(object sender, ScannerDataEventArgs a)
        {
            Console.WriteLine($"Data parsed {a.GTIN}");
        }
        #endregion
        #region Parsing Methods
        private List<GS1Identifiers> parseScannerData(string ScannerID, string rawData)
        {
            if (string.IsNullOrEmpty(rawData) || rawData.Length < 20)
            { return null; }

            List<GS1Identifiers> Identifiers = getOuterLabelIds();
            int idxIdentifiers = 0;
            //Convert the raw data to a byte array
            byte[] bRawData = Encoding.ASCII.GetBytes(rawData);


            // The first character is <stx> (ascii 2)
            // and the terminator is  <etx> (ascii 3)
            if (bRawData[0] == (byte)(MDC_ASCII.Ascii.STX) &&
                bRawData[bRawData.Length - 1] == (byte)(MDC_ASCII.Ascii.ETX))
            {
                //We have some data 
                //check from the 2nd to the last but one character
                for (int idx = 1; idx < bRawData.Length - 1; idx++)
                {

                    if (getStringFromBytes(bRawData, idx, Identifiers[idxIdentifiers].Identifier.Length) == Identifiers[idxIdentifiers].Identifier)
                    {
                        //We have the identifier. Now get the data
                        idx = idx + Identifiers[idxIdentifiers].Identifier.Length;
                        if (Identifiers[idxIdentifiers].FixedLength)
                        {
                            Identifiers[idxIdentifiers].DataValue = getStringFromBytes(bRawData, idx, Identifiers[idxIdentifiers].Length);
                            idx = idx + Identifiers[idxIdentifiers].Length - 1;
                            idxIdentifiers++;  //Go to the next Identifier
                        }
                        else
                        {
                            // Variable length data

                            int posnGroupSeparator = Array.IndexOf(bRawData, (byte)MDC_ASCII.Ascii.GS, idx);
                            int posnETX = Array.IndexOf(bRawData, (byte)MDC_ASCII.Ascii.ETX, idx);
                            int iDatalength = 0;
                            if (posnGroupSeparator == -1)
                            {
                                //This is the last data - Read to the end (less the ETX which is the terminator)
                                iDatalength = bRawData.Length - idx - 1;
                                Identifiers[idxIdentifiers].DataValue = getStringFromBytes(bRawData, idx, iDatalength);
                            }
                            else
                            {
                                // Read to the group separator
                                iDatalength = posnGroupSeparator - idx;
                                Identifiers[idxIdentifiers].DataValue = getStringFromBytes(bRawData, idx, iDatalength);
                            }
                            //Now move on the index
                            idx = idx + Identifiers[idxIdentifiers].DataValue.Length - 1;  //This COULD end the loop
                            idxIdentifiers++;
                            if (idxIdentifiers == Identifiers.Count)
                            {
                                //There is nothing else to read
                                break;
                            }
                        }
                    }
                }
            }

            //Raise the data parsed event
            ScannerDataEventArgs dataArgs = new ScannerDataEventArgs
            {
                ScannedDate = DateTime.Now,
                ScannerId = ScannerID,
                GTIN = Identifiers.Find(ele => ele.Name == "GTIN").DataValue,
                ProdDate = Identifiers.Find(ele => ele.Name == "ProdDate").DataValue,
                LotNo = Identifiers.Find(ele => ele.Name == "LotNo").DataValue,
                ProdName =
                    Identifiers.Find(ele => ele.Name == "ProdName1").DataValue +
                    Identifiers.Find(ele => ele.Name == "ProdName2").DataValue
            };
            OnScannerDataParsed(dataArgs);

            return Identifiers;
        }

        private int getDataIndex(byte[] bBuffer, int AsciiCode, int startPosn)
        {
            int posn = Array.IndexOf(bBuffer, (byte)AsciiCode, startPosn);
            return posn;
        }
        private string getStringFromBytes(byte[] bBuffer, int startIndex, int numBytes)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            if (bBuffer.Length >= (startIndex + numBytes))
            {
                string str = ascii.GetString(bBuffer, startIndex, numBytes);
                return str;
            }
            else { return string.Empty; }
        }
        private List<GS1Identifiers> getInnerLabelIds()
        {
            List<GS1Identifiers> innerlabel = new List<GS1Identifiers>()
            {
                new GS1Identifiers("GTIN", "01", true, 14),
                new GS1Identifiers("ProdDate", "11", true, 6),
                new GS1Identifiers("LotNo", "10", false, 0)
            };

            return innerlabel;
        }
        private List<GS1Identifiers> getOuterLabelIds()
        {
            List<GS1Identifiers> outerlabel = new List<GS1Identifiers>()
            {
                new GS1Identifiers("GTIN", "01", true, 14),
                new GS1Identifiers("ProdDate", "11", true, 6),
                new GS1Identifiers("LotNo", "10", false, 20),
                new GS1Identifiers("ProdName1", "240", false, 30),
                new GS1Identifiers("ProdName2", "240", false, 30)
            };
            return outerlabel;
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
        public int PalletBatchUId { get; set; }
        public int ProductionLineUId { get; set; }
        public string ScannerId { get; set; }
    }
    public class ScannerReadStatusEventArgs : EventArgs
    {
        public IPAddress IPAddr { get; set; }
        public int Port { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public int PalletBatchUId { get; set; }
        public int ProductionLineUId { get; set; }
    }
    public class ScannerDataEventArgs : EventArgs
    {
        public DateTime ScannedDate { get; set; }
        public string ScannerId { get; set; }
        public string GTIN { get; set; }
        public string LotNo { get; set; }
        public string ProdDate { get; set; }
        public string ProdName { get; set; }
        public int PalletBatchUId { get; set; }
        public int ProductionLineUId { get; set; }
    }
    internal class GS1Identifiers
    {
        internal string Name { get; set; }
        internal string Identifier { get; set; }
        internal bool FixedLength { get; set; }

        //If Fixed length   = True, this is the length the data has to be
        //                  = False, this is the MAX length of the data
        internal int Length { get; set; }

        internal string DataValue { get; set; }

        internal GS1Identifiers() { }
        internal GS1Identifiers(string name, string identifier, bool fixedlength, int length)
        {
            Name = name;
            Identifier = identifier;
            FixedLength = fixedlength;
            Length = length;
        }
    }


    public static class Mx300NLogging
    {
        internal static string currMethod()

        {
            return new StackTrace().GetFrame(1).GetMethod().currMethod();
        }
        internal static string currMethod(this MethodBase method)
        {
            if (method.DeclaringType.GetInterfaces().Any(i => i == typeof(System.Runtime.CompilerServices.IAsyncStateMachine)))
            {
                var generatedType = method.DeclaringType;
                var originalType = generatedType.DeclaringType;
                var foundMethod = originalType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
                    .Single(m => m.GetCustomAttribute<System.Runtime.CompilerServices.AsyncStateMachineAttribute>()?.StateMachineType == generatedType);
                return foundMethod.DeclaringType.Name + "." + foundMethod.Name;
            }
            else
            {
                return method.DeclaringType.Name + "." + method.Name;
            }
        }
        public static void LogMessage(string methodName, string messageText)
        {
            StringBuilder msg = new StringBuilder();
            msg.AppendLine(methodName);
            msg.AppendLine(messageText);
            MessageBox.Show(messageText, methodName);
        }
        public static void LogMessage(string methodName, Exception ex)
        {
            LogMessage(methodName, $"{ex.Message}");
        }
        public static void LogMessage(string methodName, string messageText, Exception ex)
        {
            LogMessage(methodName, $"{messageText}\n{ex.Message}");
        }
    }
}
