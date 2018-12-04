//******************************************************************************
// Project: 702385 Exwold Tracking
//
// COPYRIGHT
// (c) Copyright 2017 Industrial Technology Systems Ltd.
// All Rights Reserved.
//
// DISCUSSION
// Creates a TCP Client connection, handles re-connects, processes incoming data in ReceiveCallback()
//
// MODIFICATION HISTORY
// Version  Project/CR      Date        By                  References
//    1.00  702385          04Apr2017   Martin Cox 
//          Initial Creation
//    1.01  702385/CRF014   23May2017   Martin Cox
//          Modify the ReceiveCallback() to catch remote disconnect
//          and call CheckConnectionReconnectIfNecessary() to check and reconnect.
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


namespace ExwoldPcInterface
{
    public class CommsTCPClient
    {
        private const string ModuleName = "CommsTCPClient.";

        // MDC 06Jul2016 Added so teh TCP object knows what data it's handling
        public string deviceName;
        public string responseString;

        public String remoteIPAddress;
        public int remoteIPPort;
        public String localIPPort;
        public bool connected;
        public int bufferSize;
        public List<byte> response = new List<byte>();
        public DateTime LastDataReceivedTime;

        private System.Net.Sockets.TcpClient winsock = new System.Net.Sockets.TcpClient();
        private StateObject receivedDataStateObject;


        // This is incremented before sending a keep alive message,
        // and decremented when correctly receiving a match string.
        // If this counter increments over time we have lost the connection, and need to
        // disconnect & re-connect to re-establish the conection.
        private int keepAliveCounter;

        private const int PauseShort = 2;

        //================================================================================
        //   Connection related functions
        //================================================================================
        //--------------------------------------------------------------------------------
        //   Connect()
        // Creates the Winsock connection, uses the LocalIPPort, RemoteIPAddress, and
        // RemoteIPPort that must be set before calling his function.
        // Returns:  String OK on success, else an error message
        //--------------------------------------------------------------------------------
        public bool Connect()
        {
            const string MethodName = ModuleName + "Connect(): ";
            
            // main functionality to open the connection
            try
            {
                //LastActionCaption.Text = "Connect"
                //LastResultCaption.Text = "Working..."
                Program.Log.LogMessage(ThreadLog.DebugLevel.Information , remoteIPAddress , MethodName + "Starting");
 
                if( winsock.Client.Connected == false)
                {
                    // Check we have a valid end-point
                    if( remoteIPAddress != "" && remoteIPPort != 0 )
                    {
                        // Ping to see if the remote device is on the network,
                        // if it isn't there's not much point trying top connect.
                        if (Ping(remoteIPAddress) == true)
                        {
                            // Set remote Address and Port
                            System.Net.IPAddress address = IPAddress.Parse(remoteIPAddress);

                            winsock = new System.Net.Sockets.TcpClient();
                            winsock.ReceiveTimeout = 10;
                            winsock.SendTimeout = 10;
                            winsock.NoDelay = true;
                            winsock.Client.DontFragment = true;

                            // create connection
                            winsock.Client.Connect(remoteIPAddress, remoteIPPort);

                            // Begin receiving the data from the remote device.
                            receivedDataStateObject = new StateObject();
                            receivedDataStateObject.workSocket = winsock.Client;
                            winsock.Client.BeginReceive(receivedDataStateObject.buffer,
                                                        0,
                                                        StateObject.BufferSize,
                                                        SocketFlags.None,
                                                        new AsyncCallback(ReceiveCallback),
                                                        receivedDataStateObject);

                            // wait for connection, as soon as we have it jump out
                            for (int i = 1; i <= 100; i++)
                            {
                                Thread.Sleep(PauseShort);
                                if (winsock.Client.Connected)
                                {
                                     break;
                                }
                            }
                        }
                        else
                        {
                             Program.Log.LogMessage(ThreadLog.DebugLevel.Information, remoteIPAddress, MethodName + "Cannot Ping");
                        }
                    }

                    // report results
                    if( winsock.Client.Connected )
                    {
                         Program.Log.LogMessage(ThreadLog.DebugLevel.Message, remoteIPAddress, MethodName + "Winsock Connected OK");
                        connected = true;
                    }
                    else
                    {
                         Program.Log.LogMessage(ThreadLog.DebugLevel.Message, remoteIPAddress, MethodName + "Winsock NOT Connected");
                        connected = false;
                    }
                }
                else
                {
                     Program.Log.LogMessage(ThreadLog.DebugLevel.Message, remoteIPAddress, MethodName + "Winsock already connected");
                }

                 Program.Log.LogMessage(ThreadLog.DebugLevel.Information, remoteIPAddress, MethodName + "LocalPort" + localIPPort + "   Remote IP: " + remoteIPAddress + "   Port: " + remoteIPPort + "   Connected: " + connected.ToString());
            }
            catch(Exception ex)
            {
                 Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, remoteIPAddress, MethodName + "EXCEPTION: " + ex.ToString());
            }
            return connected;
        }



        //--------------------------------------------------------------------------------
        //   Disconnect()
        // Disconnects and closed the Winsock connection.
        // Returns:  String OK on success, else an error message
        //--------------------------------------------------------------------------------
        public bool Disconnect()
        {
            const string MethodName = ModuleName + "Disconnect(): ";
            
            try
            {
                 Program.Log.LogMessage(ThreadLog.DebugLevel.Warning, remoteIPAddress, MethodName + "Starting");

                // close the winsock connection
                winsock.Client.Close(1);

                // wait for connetion to be closed
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(PauseShort);
                    if (!winsock.Client.Connected)
                    {
                        break;
                    }
                }

                if (winsock.Client.Connected)
                {
                     Program.Log.LogMessage(ThreadLog.DebugLevel.Message, remoteIPAddress, MethodName + "Winsock NOT disconnected");
                }
                else
                {
                    connected = false;
                     Program.Log.LogMessage(ThreadLog.DebugLevel.Message, remoteIPAddress, MethodName + "Disconnected OK");
                }
            }
            catch (Exception ex)
            {
                 Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, remoteIPAddress, MethodName + "EXCEPTION: " + ex.ToString());
            }

            return !connected;
        }


        //================================================================================
        //   Send Data related functions - Local Private Functions doing the work
        //================================================================================
        //--------------------------------------------------------------------------------
        //   WinsockSend()
        // Low-level command to actually send the data over the Winsock connection.
        // We do not catch errors here, instead they are passed back to the calling function
        // In:       stringToSend As String  The string to send
        //'--------------------------------------------------------------------------------
        public void WinsockSend(byte[] byteArray)
        {
            const string MethodName = ModuleName + "WinsockSend(): ";

            try
            {
                 CheckConnectionReconnectIfNecessary();
                if (connected)
                {
                     Program.Log.LogData(0, "Winsock Send: ", byteArray);
                    winsock.Client.Send(byteArray);
                }
                else
                {
                     Program.Log.LogMessage(ThreadLog.DebugLevel.Information, remoteIPAddress, MethodName + "No connection, cannot send");
                }
            }
            catch (Exception ex)
            {
                 Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, remoteIPAddress, MethodName + "EXCEPTION: " + ex.ToString());
            }
        }

        //--------------------------------------------------------------------------------
        //   CheckConnectionReconnectIfNecessary()
        // Routine to reconnect a broken connection
        //--------------------------------------------------------------------------------
        public void CheckConnectionReconnectIfNecessary()
        {
            const string MethodName = ModuleName + "CheckConnectionReconnectIfNecessary(): ";

            try
            {
                // has the keepAliveCounter incremented so far that it look like we have lost the connection?
                if (keepAliveCounter >= 5)
                {
                    Disconnect();
                    Thread.Sleep(PauseShort);
                    Connect();
                    // reset counter, so we don't get stuck in a loop
                    keepAliveCounter = 0;
                }

                // do we have a connection object
                if (winsock != null)
                {
                    if (winsock.Client != null)
                    {
                        // Check state of connection
                        bool a = false;

                        bool b = false;
                        bool c = false;
                        bool d = false;
                        bool e = false;
                        bool f = false;
                        // Check state of connection
                        a = !winsock.Client.Connected;
                        if (!a)
                        {
                            b = winsock.Client.Poll(0, SelectMode.SelectRead);
                            c = winsock.Client.Poll(0, SelectMode.SelectWrite);
                            d = winsock.Client.Poll(0, SelectMode.SelectError);
                            e = false;
                            if (winsock.Client.Available == 0)
                            {
                                e = true;
                            }
                        }
                        f = connected;

                        // Poll(0, SelectMode.SelectRead) will return:
                        //   false if the client is still connected but there is no data in the buffer
                        //   else true
                        // if it returns true, and there is no data available, then we have lost the connection.

                        //   a          implies winsock object exists, but no connection
                        //   b And e    implies read error
                        //   c          implies write error
                        //   (not d)    implies general error
                        //   e          implies we think we are connected (so if we aren't we should be)
                        bool isDisconnected = a | (b & c & !d & e & f);
                        if (isDisconnected)
                        {
                            Disconnect();
                            Thread.Sleep(PauseShort);
                            Connect();
                            Thread.Sleep(PauseShort);
                        }
                    }
                }
            }
            catch (System.NullReferenceException ex1)
            {
                 Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, remoteIPAddress, MethodName + "System.NullReferenceException: Object reference not set to an instance" + ex1.Message);
            }
            catch (Exception ex2)
            {
                 Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, remoteIPAddress, MethodName + "EXCEPTION: " + ex2.ToString());
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
            const string MethodName = ModuleName + "ReceiveCallback(): ";
           
            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.
                int bytesRead = client.EndReceive(ar);

                if( bytesRead > 0 )
                {
                    // Data avialable
                    // Store the data received so far.
                    List<byte> temp = new List<byte>();
                    for (int i = 0; i < bytesRead; i++)
                    {
                        temp.Add(state.buffer[i]);
                    }
                    state.receivedData.AddRange(temp.ToList());
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Debug, "Winsock Recd (" + remoteIPAddress + ":" + remoteIPPort +"):", MDC_ASCII.ConvertAsciiArrayToReadableString(temp.ToArray()));
                    
                    // Begin the next read
                    client.BeginReceive(state.buffer,
                                        0, 
                                        StateObject.BufferSize, 
                                        0, 
                                        new AsyncCallback(ReceiveCallback), 
                                        state);
                }
                else
                {
                    // start the next read
                    client.BeginReceive(state.buffer,
                                        0, 
                                        StateObject.BufferSize, 
                                        0, 
                                        new AsyncCallback(ReceiveCallback), 
                                        state);
                }
            
                // store data in response variable for handling
                response.AddRange(state.receivedData.ToList());
                state.receivedData.Clear();

                // now handle the data
                try
                {
                     Program.Log.LogMessage(ThreadLog.DebugLevel.Information, MethodName + "Processing device: " + this.deviceName + " add data to dataset, TCP.response.Count = " + response.Count.ToString());

                    if (response.Count >= 0 && response.Contains((byte)MDC_ASCII.Ascii.LF))
                    {
                        responseString = System.Text.Encoding.UTF8.GetString(response.ToArray());                        
                    }
                }
                catch (Exception e1)
                {
                     Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, MethodName + "EXCEPTION in add data to dataset: " + e1.ToString());
                }

            }
            catch(Exception ex)
            {
                Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, remoteIPAddress, MethodName + "EXCEPTION: " + ex.ToString());
                if (ex.ToString().Contains("An existing connection was forcibly closed by the remote host"))
                {
                    Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, remoteIPAddress, MethodName + "Connection forcibly closed, calling CheckConnectionReconnectIfNecessary()");
                    CheckConnectionReconnectIfNecessary();
                }
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
            const string MethodName = ModuleName + "Ping(): ";

            bool returnBool = false;

            try
            {
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
            }
            catch(Exception ex)
            {
                 Program.Log.LogMessage(ThreadLog.DebugLevel.Exception, remoteIPAddress, MethodName + "EXCEPTION: " + ex.ToString());
            }
            return returnBool;
        }

    }


    //================================================================================
    //   Class StateObject
    //   Ancillary Class, used for the TCP Receive functions
    //   DO NOT CHANGE
    //================================================================================
    public class StateObject
    {
        // Client socket
        public System.Net.Sockets.Socket workSocket = null;

        // Size of receive buffer
        public const int BufferSize = 10240;

        // Receive buffer
        public byte[] buffer = new byte[BufferSize];

        // Received data string
        public List<byte> receivedData = new List<byte> ();
    }

}
