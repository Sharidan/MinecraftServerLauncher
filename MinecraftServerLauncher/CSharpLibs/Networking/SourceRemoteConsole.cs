using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

/* 
 * File   : SourceRemoteConsole.cs
 * Created: 6. April 2018
 * Author : Robert Bülow - ("sharidandk" on Twitch.com)
 * Web    : www.sharidan.dk
 *          www.futte.dk
 * 
 * License: CC BY 4.0
 *          https://creativecommons.org/licenses/by/4.0/
 * This license covers this source code file only.
 * 
 * Initial namespace: CSharpLibs.Networking
 * Feel free to change the namespace to fit your needs.
 * 
 * Fully integrated TCP client to communicate with a remote
 * server via Valve's Source RemoteConsole protocol.
 * Minecraft servers also use this protocol to allow remote
 * access to the server's console.
 * 
 * SourceRemoteConsole runs in it's own thread while handling
 * networking. This class was designed to have a minimum of
 * methods and properties to make it faster and easier to
 * establish a connection, authenticate correctly and thereafter
 * communicating with the remote server.
 * 
 * The authentication process is handled internally uppon
 * successful connection to the remote server. There are events
 * available to capture the authentication process as well as
 * events for the actual connectivity status.
 * 
 * Since SourceRemoteConsole runs in it's own thread, some
 * amount of cross-thread handling may be required when using
 * this class in combination with WinForms.
 * For implmenetation help, please see each event for a working
 * sample.
 * 
 * For documentation on the Minecraft RCon implementation, see:
 * http://wiki.vg/RCON
 * 
 * For documentation on Valve's Source RemoteConsole, see:
 * https://developer.valvesoftware.com/wiki/Source_RCON_Protocol
 * 
 * This last page has far more detail regarding the protocol
 * implementation and was instrumental in creating this
 * class.
 * 
 */

namespace CSharpLibs.Networking
{
  class SourceRemoteConsole
  {

    #region ===== Variables =====

    /// <summary>
    /// Holds the IP address of the remote server to connect to. Default is localhost.
    /// </summary>
    private IPAddress RemoteIP = new IPAddress(new byte[] { 127, 0, 0, 1 });

    /// <summary>
    /// Holds the port to connect to. Default is set to the default Minecraft RCon port: 25575
    /// </summary>
    private int RemotePort = 25575;

    /// <summary>
    /// Will hold the password required to successfully authenticate.
    /// </summary>
    private string AuthenticationPassword = "";

    /// <summary>
    /// Internal control flag to determine whether we have been authenticated. Affects .Execute !
    /// </summary>
    private bool ClientAuthenticated = false;

    /// <summary>
    /// Cross-thread flag to control when to disconnect this client from the remote server.
    /// </summary>
    private volatile bool DisconnectClient = false;

    #endregion

    #region ===== Events =====

    #region Event: Authenticated

    /* 
     * This event is raised when the remote server has responded
     * with a successful authentication.
     * 
     * Sample code for properly handling cross-thread code execution
     * in the WinForms main thread:
     
      private SourceRemoteConsole RCon = new SourceRemoteConsole();

      private void RCon_Authenticated()
      {
        if (InvokeRequired)
        {
          Invoke(new Action(RCon_Authenticated));
          return;
        }

        // Past this comment it's safe to change UI elements.

        MessageBox.Show("Authenticated.");
      }

     * 
     */

    /// <summary>
    /// Represents the method that handles an Authenticated event.
    /// </summary>
    public delegate void AuthenticatedEventHandler();

    /// <summary>
    /// Triggers uppon successful authentication.
    /// </summary>
    public event AuthenticatedEventHandler Authenticated;

    /// <summary>
    /// Raises the Authenticated event.
    /// </summary>
    protected void OnAuthenticated()
    {
      Authenticated?.Invoke();
    }

    #endregion

    #region Event: AuthenticationFailed

    /* 
     * This event is raised when the remote server has rejected
     * a login attempt. Best practice: disconnect, then reconnect.
     * 
     * Sample code for properly handling cross-thread code execution
     * in the WinForms main thread:
     
      private SourceRemoteConsole RCon = new SourceRemoteConsole();

      private void RCon_AuthenticationFailed()
      {
        if (InvokeRequired)
        {
          Invoke(new Action(RCon_AuthenticationFailed));
          return;
        }

        // Past this comment it's safe to change UI elements.

        MessageBox.Show("Authentication Failed!\n\nMost likely due to incorrect password.");
      }

     * 
     */

    /// <summary>
    /// Represents the method that handles an AuthenticationFailed event.
    /// </summary>
    public delegate void AuthenticationFailedEventHandler();

    /// <summary>
    /// Triggers if the attempt at authenticating failed. This is most likely due to incorrect password.
    /// </summary>
    public event AuthenticationFailedEventHandler AuthenticationFailed;

    /// <summary>
    /// Raises the AuthenticationFailed event.
    /// </summary>
    protected void OnAuthenticationFailed()
    {
      AuthenticationFailed?.Invoke();
    }

    #endregion

    #region Event: Connected

    /* 
     * This event is raised uppon successfully connecting
     * to the remote server.
     * 
     * Sample code for properly handling cross-thread code execution
     * in the WinForms main thread:
     
      private SourceRemoteConsole RCon = new SourceRemoteConsole();

      private void RCon_Connected()
      {
        if (InvokeRequired)
        {
          Invoke(new Action(RCon_Connected));
          return;
        }

        // Past this comment it's safe to change UI elements.

        MessageBox.Show("Connected.");
      }

     * 
     */

    /// <summary>
    /// Represents the method that handles a Connected event.
    /// </summary>
    public delegate void ConnectedEventHandler();

    /// <summary>
    /// Triggers once a connection to the remote server has been established.
    /// </summary>
    public event ConnectedEventHandler Connected;

    /// <summary>
    /// Raises the Connected event.
    /// </summary>
    protected void OnConnected()
    {
      Connected?.Invoke();
    }

    #endregion

    #region Event: ConnectFailed

    /* 
     * This event is raised if the attempt to connect to
     * a remote server failes. The full failure exception
     * is passed in the event.
     * 
     * Sample code for properly handling cross-thread code execution
     * in the WinForms main thread:
     
      private SourceRemoteConsole RCon = new SourceRemoteConsole();

      private void RCon_ConnectFailed(Exception ex)
      {
        if (InvokeRequired)
        {
          Invoke(new Action<Exception>(RCon_ConnectFailed), ex);
          return;
        }

        // Past this comment it's safe to change UI elements.

        MessageBox.Show("Connection failed!\n\n" + ex.Message);
      }

     * 
     */

    /// <summary>
    /// Represents the method that handles a ConnectFailed event.
    /// </summary>
    /// <param name="ex"></param>
    public delegate void ConnectFailedEventHandler(Exception ex);

    /// <summary>
    /// Triggers if the attempt at connecting to the remote server fails.
    /// </summary>
    public event ConnectFailedEventHandler ConnectFailed;

    /// <summary>
    /// Raises the ConnectFailed event.
    /// </summary>
    /// <param name="ex"></param>
    protected void OnConnectFailed(Exception ex)
    {
      ConnectFailed?.Invoke(ex);
    }

    #endregion

    #region Event: Disconnected

    /* 
     * This event is raised when the client is disconnected
     * from the remote server. This can either happen if the
     * client disconnects from the server or if the server
     * disconnects the client from it's end.
     * 
     * Sample code for properly handling cross-thread code execution
     * in the WinForms main thread:
     
      private SourceRemoteConsole RCon = new SourceRemoteConsole();

      private void RCon_Disconnected()
      {
        if (InvokeRequired)
        {
          Invoke(new Action(RCon_Disconnected));
          return;
        }

        // Past this comment it's safe to change UI elements.

        MessageBox.Show("Disconnected!");
      }

     * 
     */

    /// <summary>
    /// Represents the method that handles a Disconnected event.
    /// </summary>
    public delegate void DisconnectedEventHandler();

    /// <summary>
    /// Triggers when disconnected from the remote server. This could either be the client disconnecting from the server or the server disconnecting the client.
    /// </summary>
    public event DisconnectedEventHandler Disconnected;

    /// <summary>
    /// Raises the Disconnected event.
    /// </summary>
    protected void OnDisconnected()
    {
      Disconnected?.Invoke();
    }

    #endregion

    #region Event: ServerResponse

    /* 
     * This event is raised when the remote server responds
     * to a request or command. Use this event to receive
     * responses from the server.
     * NOTE: depending on the implementation of the server
     * some commands may produce an empty response and
     * unknown commands may also produce empty responses.
     * 
     * Sample code for properly handling cross-thread code execution
     * in the WinForms main thread:
     
      private SourceRemoteConsole RCon = new SourceRemoteConsole();

      private void RCon_ServerResponse(string responseMessage)
      {
        if (InvokeRequired)
        {
          Invoke(new Action<string>(RCon_ServerResponse), responseMessage);
          return;
        }

        // Past this comment it's safe to change UI elements.

        MessageBox.Show("Server response received:\n\n" + responseMessage);
      }

     * 
     */

    /// <summary>
    /// Represents the method that handles a ServerResponse event.
    /// </summary>
    /// <param name="responseMessage"></param>
    public delegate void ServerResponseEventHandler(string responseMessage);

    /// <summary>
    /// Triggers when a response is received from the remote server.
    /// </summary>
    public event ServerResponseEventHandler ServerResponse;

    /// <summary>
    /// Raises the ServerResponse event.
    /// </summary>
    /// <param name="responseMessage"></param>
    protected void OnServerResponse(string responseMessage)
    {
      ServerResponse?.Invoke(responseMessage);
    }

    #endregion

    #endregion

    #region ===== Packet Handling =====

    /// <summary>
    /// Client->Server: Sent to server requesting authentication.
    /// </summary>
    private const int SERVERDATA_AUTH = 3;

    /// <summary>
    /// Server->Client: Authentication response from the server to the client.
    /// </summary>
    private const int SERVERDATA_AUTH_RESPONSE = 2;

    /// <summary>
    /// Server->Client: Indicates that the SERVERDATA_AUTH_RESPONSE contained an authentication rejection. This is not an actual packetType.
    /// </summary>
    private const int SERVERDATA_AUTH_FAIL = -1;

    /// <summary>
    /// Client->Server: Sent to server to execute the command in the server's console.
    /// </summary>
    private const int SERVERDATA_EXECCOMMAND = 2;

    /// <summary>
    /// Server->Client: Response from the server as a result of a request or command.
    /// </summary>
    private const int SERVERDATA_RESPONSE_VALUE = 0;

    #region Private Method: ConvertInt32

    /// <summary>
    /// Converts the passed int (32-bit signed) into a forced little-endian byte array.
    /// </summary>
    /// <param name="value">The int (32-bit signed) value to convert.</param>
    /// <returns>Returns a forced little-endian byte array containing the original int value.</returns>
    private byte[] ConvertInt32(int value)
    {
      byte[] intBytes = BitConverter.GetBytes(value);

      // If the byte order is not Little-Endian
      if (!BitConverter.IsLittleEndian)
      { // Reverse the byte order
        Array.Reverse(intBytes);
      }

      // Return the result
      return intBytes;
    }

    /// <summary>
    /// Converts the passed byte array into a 32-bit signed int value.
    /// </summary>
    /// <param name="value">The byte array value to convert.</param>
    /// <returns>Returns a 32-bit signed int value.</returns>
    private int ConvertInt32(byte[] value)
    {
      return ConvertInt32(value, 0);
    }

    /// <summary>
    /// Converts the passed byte array, starting at the specified startIndex, into a 32-bit signed int value.
    /// </summary>
    /// <param name="value">The byte array value to convert.</param>
    /// <param name="startIndex">The position at which to start the int conversion.</param>
    /// <returns>Returns a 32-bit signed int value.</returns>
    private int ConvertInt32(byte[] value, int startIndex)
    {
      if (startIndex < value.Length - 4)
      {
        byte[] tempValue = new byte[4];

        Array.Copy(value, startIndex, tempValue, 0, 4);

        if (!BitConverter.IsLittleEndian)
        {
          Array.Reverse(tempValue);
        }

        return BitConverter.ToInt32(tempValue, 0);
      }

      return 0;
    }

    #endregion

    #region Private Method: ConvertPacket

    /// <summary>
    /// Generates a valid RCon packet, based on the specified packet type with the specified payload.
    /// </summary>
    /// <param name="packetType">The type of packet to generate.</param>
    /// <param name="payload">The payload to include.</param>
    /// <returns>Returns a valid RCon protocol packet as a byte array.</returns>
    private byte[] ConvertPacket(int packetType, string payload)
    {
      byte[] packetBody = Encoding.ASCII.GetBytes(payload);
      int packetSize = packetBody.Length;

      packetSize += 4; // Four bytes to hold the packetID.
      packetSize += 4; // Four bytes to hold the packet type.
      packetSize += 1; // One byte to zero-terminate the packetBody.
      packetSize += 1; // One byte to zero-termiante the empty string at the end of the packet.

      int packetID = GeneratePacketID();
      LastPacketID = packetID; // Store this ID for later verification
      byte[] packetIDBytes = ConvertInt32(packetID);
      byte[] packetTypeBytes = ConvertInt32(packetType);
      byte[] packetSizeBytes = ConvertInt32(packetSize);

      byte[] result = new byte[packetSize + 4];

      Array.Copy(packetSizeBytes, 0, result, 0, packetSizeBytes.Length);
      Array.Copy(packetIDBytes, 0, result, 4, packetIDBytes.Length);
      Array.Copy(packetTypeBytes, 0, result, 8, packetTypeBytes.Length);
      Array.Copy(packetBody, 0, result, 12, packetBody.Length);

      result[result.Length - 2] = 0;
      result[result.Length - 1] = 0;

      return result;
    }

    /// <summary>
    /// Expects a valid RCon protocol packet. Splits the packet data into it's packet type, packet ID and returns the payload if any.
    /// </summary>
    /// <param name="packet">The RCon protocol packet to convert.</param>
    /// <param name="packetType">The type of packet received.</param>
    /// <param name="packetID">The ID number of this packet.</param>
    /// <returns>Returns the payload found in the packet, if any - otherwise an empty string.</returns>
    private string ConvertPacket(byte[] packet, out int packetType, out int packetID)
    {
      int packetSize = ConvertInt32(packet, 0);

      // Verify that the received packet is of correct size
      if (packet.Length == packetSize + 4)
      {
        if (packet[packet.Length - 2] == 0 && packet[packet.Length - 1] == 0)
        {
          packetID = ConvertInt32(packet, 4);
          packetType = ConvertInt32(packet, 8);

          int payloadLength = packetSize - (4 + 4 + 2);
          string payload = "";

          if (payloadLength > 0)
          {
            byte[] payloadBytes = new byte[payloadLength];
            Array.Copy(packet, 12, payloadBytes, 0, payloadLength);
            payload = Encoding.Default.GetString(payloadBytes);
          }

          return payload;
        }
      }

      packetType = SERVERDATA_AUTH_FAIL;
      packetID = SERVERDATA_AUTH_FAIL;

      return "";
    }

    #endregion

    #region Private Method: GeneratePacketID

    /// <summary>
    /// Random number generator used to generate random packet IDs.
    /// </summary>
    private Random RNG = null;

    /// <summary>
    /// Will always contain the last used packet ID number.
    /// </summary>
    private int LastPacketID = 0;

    /// <summary>
    /// Generates a randomized packet ID number.
    /// </summary>
    /// <returns>Returns a randomized positive int-32 packet ID number.</returns>
    private int GeneratePacketID()
    {
      return RNG.Next(100, int.MaxValue - 100);
    }

    #endregion

    #endregion

    #region ===== Send Handling =====

    /// <summary>
    /// The client send queue to be processed in the connection monitoring thread.
    /// </summary>
    private Queue<byte[]> SendQueue = new Queue<byte[]>();

    #region Private Method: SendToServer

    /// <summary>
    /// Queues up the passed packet to be sent to the remote server.
    /// </summary>
    /// <param name="packet">The RCon packet to queue up for sending.</param>
    private void SendToServer(byte[] packet)
    {
      // Thread-lock the send queue
      lock (SendQueue)
      {
        SendQueue.Enqueue(packet);
      }
    }

    /// <summary>
    /// Sends the passed payload as an RCon packet to the remote server.
    /// </summary>
    /// <param name="payload"></param>
    private void SendToServer(int packetType, string payload)
    {
      SendToServer(ConvertPacket(packetType, payload));
    }

    #endregion

    #endregion

    #region ===== Receive Handling =====

    /// <summary>
    /// Processes the data received from the server.
    /// </summary>
    /// <param name="packet">The packet received.</param>
    private void DataReceived(byte[] packet)
    {
      int packetType = 0;
      int packetID = 0;
      string responseMessage = "";

      responseMessage = ConvertPacket(packet, out packetType, out packetID);

      switch (packetType)
      {
        case SERVERDATA_AUTH_RESPONSE:

          if (packetID == LastPacketID)
          {
            OnAuthenticated();

            ClientAuthenticated = true;
          }
          else if (packetID == SERVERDATA_AUTH_FAIL)
          {
            OnAuthenticationFailed();
            //NOTE: Here we could add in a forced disconnect or an authentication retry.
            // Since we have no idea how the remote server is implemented,
            // no additional methods have been added to support authentication retry.
            // We don't know whether the remote server decides to forcedly disconnect
            // us uppon a failed authentication, so we will leave it up to the dev
            // using this class to perform the disconnect if needed.
          }

          break;
        case SERVERDATA_RESPONSE_VALUE:

          OnServerResponse(responseMessage);

          break;
      }
    }

    #endregion

    #region ===== Connection Monitoring =====

    /// <summary>
    /// The thread that hosts the client connection monitoring.
    /// </summary>
    private Thread ClientThread = null;

    /// <summary>
    /// The TCP/IP socket that handles the network connection.
    /// </summary>
    private Socket ClientSocket = null;

    #region Thread Method: MonitorConnection

    /// <summary>
    /// Monitors the activities of the TCP connection and processes the send queue.
    /// </summary>
    private void MonitorConnection()
    {
      // Indicate that we have to perform initial authentication.
      bool authenticate = true;

      // Reset the flag that indicates whether we have been authenticated or not.
      ClientAuthenticated = false;

      // Attempt to establish a connection to the remote server using standard TCP.
      try
      {
        ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        ClientSocket.Connect(RemoteIP, RemotePort);
      }
      catch (Exception ex)
      {
        OnConnectFailed(ex);
        StopMonitor(false);
        return;
      }

      // We are now connected, so raise the event for it
      OnConnected();

      while (true)
      {
        // Are we still connected to the server?
        if (IsConnected)
        {
          // Do we need to authenticate?
          if (authenticate)
          {
            authenticate = false;
            // Send an authentication request to the server
            SendToServer(SERVERDATA_AUTH, AuthenticationPassword);
          }

          // First lets check if there is data to receive
          if (ClientSocket.Poll(10, SelectMode.SelectRead))
          {
            // There is data ready to be received!
            byte[] buffer = new byte[4096];
            int receivedBytes = 0;

            try
            {
              receivedBytes = ClientSocket.Receive(buffer, buffer.Length, SocketFlags.None);
            }
            catch
            {
              receivedBytes = 0;
            }

            // if we actually did receive some data
            if (receivedBytes > 0)
            {
              // go forth and process the data
              byte[] data = new byte[receivedBytes];

              Array.Copy(buffer, 0, data, 0, receivedBytes);

              DataReceived(data);

              data = new byte[0];
            }

            buffer = new byte[0];
          }
          else
          { // No data to receive: process the send queue

            // Thread-lock the send queue to prevent desync
            lock (SendQueue)
            {
              if (SendQueue.Count > 0)
              {
                // Grab the next block of data to send ...
                byte[] dataBlock = SendQueue.Dequeue();
                try
                {
                  ClientSocket.Send(dataBlock, dataBlock.Length, SocketFlags.None);
                }
                catch
                {
                  // If an error occurs here: it could be because the connection was broken
                  //                          orphaned or disconnected server side.
                  DisconnectClient = true;
                }
              }
            } // lock

          }
        }
        else // if (IsConnected)
        { // Nope, we are not longer connected so exit the loop
          break;
        }

        if (DisconnectClient)
        {
          break;
        }

      } // while (true)

      // We are no longer connected, so do the socket cleanup and raise the Disconnected event
      StopMonitor(true);
    }

    #endregion

    #region Method: StartMonitor

    /// <summary>
    /// Starts the connection monitoring thread.
    /// </summary>
    private void StartMonitor()
    {
      if (!IsConnected && ClientSocket == null)
      {
        ClientThread = new Thread(new ThreadStart(MonitorConnection));
        ClientThread.Start();

        if (!ClientThread.IsAlive)
        {
          Thread.Sleep(5);
        }
      }
    }

    #endregion

    #region Method: StopMonitor

    /// <summary>
    /// Shuts down the TCP connect, terminates the socket and monitoring thread and finally resets everything.
    /// </summary>
    /// <param name="raiseDisconnectedEvent">Should the Disconnected event be raised?</param>
    private void StopMonitor(bool raiseDisconnectedEvent)
    {
      if (ClientSocket != null)
      {
        // Attempt to shut down sending and receiving through the socket.
        try
        {
          ClientSocket.Shutdown(SocketShutdown.Both);
        }
        catch { }

        // Give it a bit to complete it's work.
        Thread.Sleep(50); // 50ms

        // Disconnect the socket. The false indicates that we don't want to reuse this socket.
        try
        {
          ClientSocket.Disconnect(false);
        }
        catch { }

        // Give it a bit to complete it's work.
        Thread.Sleep(50);

        // And finally close the socket and release all resources that were in use.
        try
        {
          ClientSocket.Close();
        }
        catch { }
      }

      // Clean up both the socket and the monitoring thread.
      ClientSocket = null;
      ClientThread = null;

      // Force the internal authenticated flag back to false
      ClientAuthenticated = false;
      // Force the DisconnectClient control flag back to false, since we are done disconnecting.
      DisconnectClient = false;

      // And finally: do we need to raise the Disconnected event?
      if (raiseDisconnectedEvent)
      {
        OnDisconnected();
      }
    }

    #endregion

    #endregion

    #region ===== Properties =====

    #region Property: IsConnected

    /// <summary>
    /// Indicates whether we are still connected or not.
    /// </summary>
    public bool IsConnected
    {
      get
      {
        bool result = false;

        try
        {
          result = !(ClientSocket.Poll(1, SelectMode.SelectRead) && ClientSocket.Available == 0);
        }
        catch { }

        return result;
      }
    }

    #endregion

    #endregion

    #region ===== Public Methods =====

    #region Public Method: Connect

    /// <summary>
    /// Attempt to establish a connection to a remote server.
    /// </summary>
    /// <param name="serverIP">The IPAddress of the remote server to connect to.</param>
    /// <param name="serverPort">The port that the remote server is listening on.</param>
    /// <param name="authPassword">The password to authenticate with.</param>
    public void Connect(IPAddress serverIP, int serverPort, string authPassword)
    {
      if ((serverPort > 1024 && serverPort < 65536) && authPassword.Trim().Length > 0)
      {
        // Store the passed values
        RemoteIP = serverIP;
        RemotePort = serverPort;
        AuthenticationPassword = authPassword.Trim();

        // Fire up the monitoring thread, which attempts the connection
        StartMonitor();
      }
    }

    /// <summary>
    /// Attempt to establish a connection to a remote server.
    /// </summary>
    /// <param name="ip">A 4-byte byte array containing the IP to connect to.</param>
    /// <param name="serverPort">The port that the remote server is listening on.</param>
    /// <param name="authPassword">The password to authenticate with.</param>
    public void Connect(byte[] ip, int serverPort, string authPassword)
    {
      if (ip.Length == 4)
      {
        Connect(new IPAddress(ip), serverPort, authPassword);
      }
    }

    #endregion

    #region Public Method: Disconnect

    /// <summary>
    /// Disconnects from the remote server.
    /// </summary>
    public void Disconnect()
    {
      if (IsConnected)
      {
        DisconnectClient = true;
      }
    }

    #endregion

    #region Public Method: Execute

    /// <summary>
    /// While connected to a remote server, attempts to execute the passed command.
    /// </summary>
    /// <param name="command">The text command to execute in the remote server's console.</param>
    public void Execute(string command)
    {
      if (IsConnected && ClientAuthenticated)
      {
        SendToServer(SERVERDATA_EXECCOMMAND, command);
      }
    }

    #endregion

    #endregion

    #region ===== Constructor =====

    public SourceRemoteConsole()
    {
      // Initialize the random number generator needed
      // for randomized packet IDs.
      RNG = new Random(DateTime.Now.Millisecond);
    }

    #endregion

  }
}
