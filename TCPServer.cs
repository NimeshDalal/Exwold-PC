//******************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd.
// All Rights Reserved.
//
// DISCUSSION
// Creates a TCP Server connection, handles re-connects, processes incoming data in ReceiveCallback()
//
// MODIFICATION HISTORY
// Version  Project/CR      Date        By                  References
//    1.00  702385          04Apr2017   Martin Cox 
//          Initial Creation
//    1.01  702385/CRF014   23May2017   Martin Cox
//          Modify the ReceiveCallback() to catch remote disconnect
//          and set CheckConnectionTimer to immediately call the call CheckConnection().
//
//******************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.ComponentModel;
//using System.windows.Forms;
using System.Timers;

namespace ExwoldPcInterface
{
    class TCPServer
    {
        const string moduleName = "TCPServer";

        private string remoteIPAddress;
        private IPAddress localIPAddress;
        private int localIPPort;
        private TcpListener listener;

        private TcpClient winsock;
        private bool winsockShouldBeConnected;

        // we use a System.Windows.Forms.Timer not a System.Timers.Timer so everything is on the UI thread
        // Otherwise we would have a lot of cross-thread comms to marshal
        private System.Timers.Timer HandleIncomingMessageTimer = new System.Timers.Timer();
        private System.Threading.Timer CheckConnectionTimer;
        

        // The response from the remote device.   This holds any aditional characters left over (not processed) 
        // from one response and used them at the beginning of the next - used when a message is split across multiple TCP packets
        public List<byte> response = new List<byte>();

        // State Object to hold the the received data between invocations of the ReceiveCallback function
        private TCPStateObject receivedDataStateObject;

        private ThreadLog log;

        // This is incremented before sending a keep alive message,
        // and decremented when correctly receiving a match string.
        // If this counter increments over time we have lost the connection, and need to
        // disconnect & re-connect to re-establish the conection.
        private int keepAliveCounter;


        private const int PauseShort = 2;
        private const int PauseMedium = 20;
        private const int PauseLong = 100;

        object checkConnectionStateObject = new object();


        //--------------------------------------------------------------------------------
        // New
        // Constructor - assign class-level variables, and start timers
        //--------------------------------------------------------------------------------
        public TCPServer(ref ThreadLog log,  int localIPPort)
        {
            string methodName = "Constructor locIP=" + localIPAddress + " locPort=" + localIPPort.ToString();
            try
            {
                this.log = log;

                this.localIPAddress = IPAddress.Any;
                this.localIPPort = localIPPort;

                log.LogMessage(ThreadLog.DebugLevel.Information, methodName +" Instanciated");
                BackgroundWorker bwServer = new System.ComponentModel.BackgroundWorker();
                bwServer.DoWork += new DoWorkEventHandler(Connect);
                bwServer.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                if (log != null)
                    log.LogMessage(ThreadLog.DebugLevel.Exception, methodName + " EXCEPTION: " + ex.ToString());
            }
        }


        //--------------------------------------------------------------------------------
        // Destructor method
        // try to destroy objects created by this class (be aware other classes may have already beed destroyed)
        // - try to close an open connection
        //--------------------------------------------------------------------------------
        ~TCPServer()
        {
            string methodName = "Destructor locIP=" + localIPAddress + " locPort=" + localIPPort.ToString();
            try
            {
                log.LogMessage(ThreadLog.DebugLevel.Information, methodName + " Starting");
                try
                {
                    // try to stop the listener - it it is listening
                    if(listener != null)
                    {
                        log.LogMessage(ThreadLog.DebugLevel.Information, methodName + " Stopping Listener");
                        listener.Stop();
                        listener = null;
                    }
                }
                catch( Exception ex )
                {
                    if(log != null)
                        log.LogMessage(ThreadLog.DebugLevel.Exception, methodName + " EXCEPTION: " + ex.ToString());
                }

                try
                {
                    // try to close the conection if it still exists
                    if(winsock != null && winsock.Client != null && winsock.Client.Connected)
                    {
                        if(log != null)
                            log.LogMessage(ThreadLog.DebugLevel.Information, methodName + " winsock.Client.Close(1)");
                        winsock.Client.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                        winsock.Client.Close(1);
                    }
                }
                catch( Exception ex )
                {
                    if(log != null)
                        log.LogMessage(ThreadLog.DebugLevel.Exception, methodName + " EXCEPTION: " + ex.ToString());
                }

                try
                {
                    // try to destroy the client if it still exists
                    if(winsock != null && winsock.Client != null)
                    {
                        if(log != null)
                            log.LogMessage(ThreadLog.DebugLevel.Information, methodName + " set winsock.Client = null");
                        winsock.Client = null;
                    }
                }
                catch(Exception ex)
                {
                    if(log != null)
                        log.LogMessage(ThreadLog.DebugLevel.Exception, methodName + " EXCEPTION: " + ex.ToString());
                }

                try
                {
                    if(winsock != null)
                    {
                        if(log != null)
                            log.LogMessage(ThreadLog.DebugLevel.Information, methodName + " set winsock = null");
                        winsock = null;
                    }
                }
                catch(Exception ex)
                {
                    if(log != null)
                        log.LogMessage(ThreadLog.DebugLevel.Exception, methodName +" EXCEPTION: " + ex.ToString());
                }

                if(log != null)
                    log.LogMessage(ThreadLog.DebugLevel.Information, methodName + " Finised, coded actions complete");
            }
            catch(Exception ex)
            {
                if(log != null)
                    log.LogMessage(ThreadLog.DebugLevel.Exception, methodName +" EXCEPTION: " + ex.ToString());
            }
        }

        public void Connect(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Connect();
        }
        //--------------------------------------------------------------------------------
        // Connect
        //--------------------------------------------------------------------------------
        public void Connect()
        {
            string methodName = "Connect locIP=" + localIPAddress + " locPort=" + localIPPort.ToString();

            log.LogMessage(ThreadLog.DebugLevel.Information, methodName +" Listenting for connection.");

            try
            {
                listener = new TcpListener(localIPAddress, localIPPort);
                listener.Start();
                winsock = listener.AcceptTcpClient();
                listener.Stop();
                listener = null;

                log.LogMessage(ThreadLog.DebugLevel.Information, methodName +" Connection accepted from: " + winsock.Client.RemoteEndPoint.ToString() + ", now creating callback");

                remoteIPAddress = winsock.Client.RemoteEndPoint.ToString().Substring(0, winsock.Client.RemoteEndPoint.ToString().IndexOf(":"));
                winsock.ReceiveTimeout = 10;
                winsock.SendTimeout = 10;
                winsock.NoDelay = true;
                winsock.Client.DontFragment = true;

                checkConnectionStateObject = this;

                // Begin receiving the data from the remote device.
                receivedDataStateObject = new TCPStateObject();
                receivedDataStateObject.workSocket = winsock.Client;
                receivedDataStateObject.checkConnectionStateObject = checkConnectionStateObject;
                winsock.Client.BeginReceive(receivedDataStateObject.buffer, 
                                            0, 
                                            TCPStateObject.BufferSize, 
                                            SocketFlags.None, 
                                            new AsyncCallback(ReceiveCallback), 
                                            receivedDataStateObject);

                winsockShouldBeConnected = true;
                // start the timer to check the connection
                CheckConnectionTimer = new System.Threading.Timer(new System.Threading.TimerCallback(CheckConnection), checkConnectionStateObject, 10000, 10000);
            }
            catch (Exception ex)
            {
                log.LogMessage(ThreadLog.DebugLevel.Exception, methodName +" EXCEPTION: " + ex.ToString());
                if(ex.ToString().Contains("WSACancelBlockingCall"))
                {
                    log.LogMessage(ThreadLog.DebugLevel.Information, methodName +" Caught WSACancelBlockingCall, so exiting thread");
                    try
                    {
                        if(winsock != null && winsock.Client != null)
                        {
                            winsock.Client.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                            winsock.Client.Close(1);
                        }
                    }
                    catch(Exception ex2)
                    {
                        log.LogMessage(ThreadLog.DebugLevel.Exception, methodName +" EXCEPTION: " + ex2.ToString());
                    }
                }
            }

        }


        private bool DisconnectRunning;
        //--------------------------------------------------------------------------------
        //   Disconnect()
        //   DisconnectAsync()
        // Disconnects and closed the Winsock connection.
        // controlledDisconnect is used as follows:
        //   Set to true for a manual disconnect, you then need to cal connect again manually.
        //   Set to false for a disconnect/reconnect attempt.
        // Returns True on success, else False
        //--------------------------------------------------------------------------------
        public void Disconnect(bool controlledDisconnect)
        {
            string methodName = "Disconnect locIP=" + localIPAddress + " locPort=" + localIPPort.ToString(); 
        
            if(!DisconnectRunning)
            {
                DisconnectRunning = true;

                try
                {
                    log.LogMessage(ThreadLog.DebugLevel.Information, methodName +" Starting");

                    // stop the CheckConnection Timer 
                    CheckConnectionTimer.Change(Timeout.Infinite, Timeout.Infinite);

                    if (winsock != null && winsock.Client != null)
                    {
                        winsock.Client.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                        winsock.Client.Close(1);
                    }

                    // wait for connetion to be closed
                    for( int i = 0; i < 100; i++)
                    {
                        if (winsock != null && winsock.Client != null)
                        {
                            if (!winsock.Client.Connected)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }

                        Thread.Sleep(10);
                    }

                    if (winsock != null && winsock.Client != null)
                    {
                        if(!winsock.Client.Connected)
                        {
                            log.LogMessage(ThreadLog.DebugLevel.Information, methodName +" Disconnected OK");
                            if(controlledDisconnect)
                                winsockShouldBeConnected = false;
                        }
                        else
                        {
                            log.LogMessage(ThreadLog.DebugLevel.Warning, methodName + " EXCEPTION NOT DISCONNECTED");
                        }
                    }
                    else
                    {
                        log.LogMessage(ThreadLog.DebugLevel.Warning, methodName + "WINSOCK IS NOTHING");
                    }

                    // wait for a new connection
                    BackgroundWorker bwServer = new System.ComponentModel.BackgroundWorker();
                    bwServer.DoWork += new DoWorkEventHandler(Connect);
                    bwServer.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    log.LogMessage(ThreadLog.DebugLevel.Exception, methodName +" EXCEPTION: " + ex.ToString());
                }

                DisconnectRunning = false;
            }
        }

        //--------------------------------------------------------------------------------
        // StopListening
        //--------------------------------------------------------------------------------
        public void StopListening()
        {
            string methodName = "StopListening locIP=" + localIPAddress + " locPort=" + localIPPort.ToString(); 
            try
            {
                // try to stop the listener - it it is listening
                log.LogMessage(ThreadLog.DebugLevel.Information, methodName +" Starting... Listener exists?");
                if(listener != null)
                {
                    log.LogMessage(ThreadLog.DebugLevel.Information, methodName + "Stopping Listener");
                    listener.Stop();
                    listener = null;
                }
            }
            catch(Exception ex)
            {
                if(log!= null)
                    log.LogMessage(ThreadLog.DebugLevel.Exception, methodName +" EXCEPTION: " + ex.ToString());
            }
        }

        //--------------------------------------------------------------------------------
        // WinsockSend
        //--------------------------------------------------------------------------------
        public void WinsockSend(string stringToSend)
        {
            string methodName = "WinsockSend locIP=" + localIPAddress + " locPort=" + localIPPort.ToString(); 
            try
            { 
                winsock.Client.Send(Encoding.ASCII.GetBytes(stringToSend));
            }
            catch(Exception ex)
            {
                log.LogMessage(ThreadLog.DebugLevel.Exception, methodName + " SENDING:   " + stringToSend,
                                                                       "EXCEPTION: " + ex.ToString());
            }

        }


        //================================================================================
        //   Receive data functions - Low Level Functions doing the work
        //================================================================================
        //--------------------------------------------------------------------------------
        //   ReceiveCallback()
        // Callback function for receiving data from the Winsock control.
        // Data is received
        //--------------------------------------------------------------------------------
        private void ReceiveCallback(IAsyncResult ar)
        {
            string methodName = "ReceiveCallback locIP=" + localIPAddress + " locPort=" + localIPPort.ToString() + " "; 
            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                TCPStateObject state = (TCPStateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // Data avialable
                    // Store the data received so far.
                    List<byte> temp = new List<byte>();
                    for (int i = 0; i < bytesRead; i++)
                    {
                        temp.Add(state.buffer[i]);
                    }
                    state.receivedData.AddRange(temp.ToList());
                    log.LogMessage(ThreadLog.DebugLevel.Information, methodName + "Winsock Recd:", MDC_ASCII.ConvertAsciiArrayToReadableString(temp.ToArray()));

                    // Begin the next read
                    client.BeginReceive(state.buffer,
                                        0,
                                        TCPStateObject.BufferSize,
                                        0,
                                        new AsyncCallback(ReceiveCallback),
                                        state);
                }
                else
                {
                    // start the next read
                    client.BeginReceive(state.buffer,
                                        0,
                                        TCPStateObject.BufferSize,
                                        0,
                                        new AsyncCallback(ReceiveCallback),
                                        state);
                }

                // store data in response variable for handling elsewhere
                response.AddRange(state.receivedData.ToList());
                state.receivedData.Clear();

                if (response.Count > 0)
                    log.LogMessage(ThreadLog.DebugLevel.Debug, methodName + "Finished, responseCharacters now=" + MDC_ASCII.ConvertAsciiArrayToReadableString(response.ToArray()));
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("The I/O operation has been aborted because of either a thread exit or an application request"))
                {
                    log.LogMessage(ThreadLog.DebugLevel.Information, methodName + " The I/O operation has been aborted because of either a thread exit or an application request.   This is normal if the remote end disconncted");
                }
                else if (ex.ToString().Contains("Cannot access a disposed object."))
                {
                    log.LogMessage(ThreadLog.DebugLevel.Information, methodName + " Cannot access a disposed object.   This is normal if the remote end disconncted");
                }
                else if (ex.ToString().Contains("An existing connection was forcibly closed by the remote host"))
                {
                    // catch the other end disconnecting, log this, get teh timeer that triggers a connection check, and change teh timeout so it triggers as soon as this function exits
                    log.LogMessage(ThreadLog.DebugLevel.Exception, remoteIPAddress, methodName + "Connection forcibly closed, changing CheckConnectionTimer so it calls CheckConnection() immediately");
                    TCPStateObject state = (TCPStateObject)ar.AsyncState;
                    ((TCPServer)state.checkConnectionStateObject).CheckConnectionTimer.Change(0,10000);
                }
                else
                {
                    log.LogMessage(ThreadLog.DebugLevel.Exception, methodName + " EXCEPTION: " + ex.ToString());
                }
            }

        }
        private bool lastPingSuccessful = false;
        //--------------------------------------------------------------------------------
        //   CheckConnection()
        // Routine to disconnect a broken connection
        //--------------------------------------------------------------------------------
        private void CheckConnection(object stateObject)
        {
            string methodName = "CheckConnection locIP=" + ((TCPServer)stateObject).localIPAddress + " locPort=" + ((TCPServer)stateObject).localIPPort.ToString(); 
            try
            {
                //((TCPServer)stateObject).log.LogMessage(ThreadLog.DebugLevel.Information, methodName +" Starting");
                // has the keepAliveCounter incremented so far that it look like we have lost the connection?
                if (((TCPServer)stateObject).keepAliveCounter >= 5)
                {
                    ((TCPServer)stateObject).Disconnect(false);
                    Thread.Sleep(PauseShort);
                    ((TCPServer)stateObject).Connect();
                    // reset counter, so we don't get stuck in a loop
                    ((TCPServer)stateObject).keepAliveCounter = 0;
                }

                // do we have a connection object
                if (((TCPServer)stateObject).winsock != null)
                {
                    if (((TCPServer)stateObject).winsock.Client != null)
                    {
                        // Check state of connection
                        bool a = false;

                        bool b = false;
                        bool c = false;
                        bool d = false;
                        bool e = false;
                        bool f = false;
                        //bool p = false;
                        //bool q = false;
                        // Check state of connection
                        a = !((TCPServer)stateObject).winsock.Client.Connected;
                        if (!a)
                        {
                            b = ((TCPServer)stateObject).winsock.Client.Poll(0, SelectMode.SelectRead);
                            c = ((TCPServer)stateObject).winsock.Client.Poll(0, SelectMode.SelectWrite);
                            d = ((TCPServer)stateObject).winsock.Client.Poll(0, SelectMode.SelectError);
                            e = false;
                            if (((TCPServer)stateObject).winsock.Client.Available == 0)
                            {
                                e = true;
                            }
                        }
                        f = ((TCPServer)stateObject).winsockShouldBeConnected;

                        // for this application the scanners do not respond to PING, so we cannot use it.
                        //// check Ping
                        //if (((TCPServer)stateObject).winsock.Client.RemoteEndPoint != null && ((IPEndPoint)((TCPServer)stateObject).winsock.Client.RemoteEndPoint).Address.ToString() != "")
                        //{
                        //    for (int i = 0; i < 5; i++)
                        //    {
                        //        p = Ping(((IPEndPoint)((TCPServer)stateObject).winsock.Client.RemoteEndPoint).Address.ToString());
                        //        if (p)
                        //            break;
                        //    }
                        //}
                        //// now determine if a loss of physical connection is a new loss, or ongoing
                        //if (p != lastPingSuccessful)            // change of state
                        //{
                        //    if (!p && lastPingSuccessful)       // was successful, now not
                        //        q = true;
                        //    lastPingSuccessful = p;
                        //}

                        // Poll(0, SelectMode.SelectRead) will return:
                        //   false if the client is still connected but there is no data in the buffer
                        //   else true
                        // if it returns true, and there is no data available, then we have lost the connection.

                        //   a          implies winsock object exists, but no connection
                        //   b And e    implies read error
                        //   c          implies write error
                        //   (not d)    implies general error
                        //   e          implies we think we are connected (so if we aren't we should be)
                        //   q          implies connecton lost (first unseccessful ping)
                        //bool isDisconnected = a | (b & c & !d & e & f) | q;
                        bool isDisconnected = a | (b & c & !d & e & f);
                        if (isDisconnected)
                        {
                            ((TCPServer)stateObject).Disconnect(false);
                            Thread.Sleep(PauseShort);
                        }
                    }
                }
                //((TCPServer)stateObject).log.LogMessage(ThreadLog.DebugLevel.Information, methodName +" Finished");
            }
            catch (System.NullReferenceException ex1)
            {
                ((TCPServer)stateObject).log.LogMessage(ThreadLog.DebugLevel.Information, methodName +" System.NullReferenceException: Object reference not set to an instance");
            }
            catch (Exception ex2)
            {
                ((TCPServer)stateObject).log.LogMessage(ThreadLog.DebugLevel.Exception, methodName +" EXCEPTION: " + ex2.ToString());
            }
        }


        //--------------------------------------------------------------------------------
        //   Ping()
        // Used to Ping the IPAddress of the device to ensure it is available on the
        // network before we try to connect using winsock, this saved a long delay while
        // we try to connect to a device that is not there.
        //--------------------------------------------------------------------------------
        private bool Ping(string ipAddress)
        {
            string methodName = "Ping locIP=" + localIPAddress + " locPort=" + localIPPort.ToString() + " RemIP=" + ipAddress; 
            bool returnBool = false;
            try
            {
                log.LogMessage(ThreadLog.DebugLevel.Information, methodName +" Starting");
                System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();

                // Use the default Ttl value which is 128, but change the fragmentation behavior.
                options.DontFragment = true;

                // Create a buffer of 32 bytes of data to be transmitted.
                String data = "Ping data for test";
                byte[] buffer = Encoding.ASCII.GetBytes(data);

                // timeout in milliseconds
                int timeout = 1000;

                System.Net.NetworkInformation.PingReply reply = pingSender.Send(ipAddress, timeout, buffer, options);

                if( reply.Status == System.Net.NetworkInformation.IPStatus.Success )
                {
                    returnBool = true;
                }
                else
                {
                    returnBool = false;
                }
                log.LogMessage(ThreadLog.DebugLevel.Information, methodName +" Finished");
            }
            catch(Exception ex)
            {
                log.LogMessage(ThreadLog.DebugLevel.Exception, methodName +" EXCEPTION: " + ex.ToString());
            }
            return returnBool;
        }
    }


    //================================================================================
    //   Class StateObject
    //   Ancillary Class, used for the TCP Receive functions
    //   *** DO NOT CHANGE ***
    //================================================================================
    public class TCPStateObject
    {
        // Client socket.
        public System.Net.Sockets.Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public List<byte> receivedData = new List<byte>();
        // copy fo teh checkConnectionStateObject for use to change the time out for checkConnection
        public object checkConnectionStateObject = new object();
    }

}
