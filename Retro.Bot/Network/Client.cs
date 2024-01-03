using Retro.Bot.Extension;
using Retro.Bot.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Retro.Bot.Network
{
    public class Client
    {
        #region Declarations
        private Socket _client;
        private bool _isRunning;
        private byte[] sendBuffer, receiveBuffer;
        const int bufferLength = 8192;
        private Buffer currentMessage;

        public bool IsConnected => _client.Connected;
        #endregion

        #region Constructeur
        public Client()
        {
            Init();
        }

        public Client(string ip, int port)
        {
            Init();
            Start(ip, port);
        }

        public Client(IPAddress ip, int port)
        {
            Init();
            Start(ip, port);
        }

        public Client(Socket socket)
        {
            Init();
            Start(socket);
        }
        #endregion

        #region Public Methods
        public void Start(string host, int port)
        {
            Regex reg = new Regex(@"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}");
            if (reg.IsMatch(host))
                _client.BeginConnect(IPAddress.Parse(host), port, new AsyncCallback(ConnectionCallback), _client);
            else
                _client.BeginConnect(host, port, new AsyncCallback(ConnectionCallback), _client);
        }

        public void Start(IPAddress adress, int port)
        {
            _client.BeginConnect(adress, port, new AsyncCallback(ConnectionCallback), _client);
        }

        public void Start(Socket socket)
        {
            _isRunning = true;
            _client = socket;
            _client.BeginReceive(receiveBuffer, 0, bufferLength, SocketFlags.None, new AsyncCallback(ReceiveCallback), _client);
        }

        public void Stop()
        {
            _client.BeginDisconnect(false, new AsyncCallback(DisconnectedCallback), _client);
        }

        public void Send(byte[] data)
        {
            if (_client.Connected == false)
                _isRunning = false;

            if (_isRunning)
            {
                if (data.Length == 0)
                    return;
                sendBuffer = data;
                _client.BeginSend(sendBuffer, 0, sendBuffer.Length, SocketFlags.None, new AsyncCallback(SendCallback), _client);
            }
        }

        public void Send(NetworkMessage msg)
        {
            Send(msg.Data);
        }
        #endregion

        #region Private methods

        private void Init()
        {
            _isRunning = false;
            receiveBuffer = new byte[bufferLength];
            _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void HandlePacket(byte[] data)
        {
            if (currentMessage == null)
                currentMessage = new Buffer();

            currentMessage.Build(data);
            OnDataReceived(new DataReceivedEventArgs(currentMessage));
        }

        #endregion

        #region Callback
        private void ConnectionCallback(IAsyncResult ar)
        {
            _isRunning = true;
            Socket client = (Socket)ar.AsyncState;
            client.EndDisconnect(ar);
            if (client.Connected)
            {
                client.BeginReceive(receiveBuffer, 0, bufferLength, SocketFlags.None, new AsyncCallback(ReceiveCallback), client);
                OnConnected(new EventArgs());
            }else
                OnDisconnected(new EventArgs());
        }

        private void DisconnectedCallback(IAsyncResult asyncResult)
        {
            _isRunning = false;
            Socket client = (Socket)asyncResult.AsyncState;
            client.EndDisconnect(asyncResult);
            OnDisconnected(new EventArgs());
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            if (client.Connected == false)
            {
                _isRunning = false;
                return;
            }
            if (_isRunning)
            {
                int bytesRead = 0;
                bytesRead = client.EndReceive(ar);
                if (bytesRead == 0)
                {
                    _isRunning = false;
                    OnDisconnected(new EventArgs());
                    return;
                }
                byte[] data = new byte[bytesRead];
                Array.Copy(receiveBuffer, data, bytesRead);
                //buffer.Add(data, 0, data.Length);
                //ThreatBuffer();
                HandlePacket(data);
                client.BeginReceive(receiveBuffer, 0, bufferLength, SocketFlags.None, new AsyncCallback(ReceiveCallback), client);
            }
            else
                Console.WriteLine("Receive data but not running");
        }

        private void SendCallback(IAsyncResult ar)
        {
            if (_isRunning)
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndSend(ar);
                //OnDataSended(new DataSendedEventArgs());
            }
            else
                Console.WriteLine("Send data but not runing");
        }
        #endregion

        #region Evenements

        public event EventHandler<EventArgs> Connected;
        public event EventHandler<EventArgs> Disconnected;
        public event EventHandler<DataReceivedEventArgs> DataReceived;
        public event EventHandler<EventArgs> DataSended;

        private void OnConnected(EventArgs e)
        {
            if (Connected != null)
                Connected(this, e);
        }

        private void OnDisconnected(EventArgs e)
        {
            if (Disconnected != null)
                Disconnected(this, e);
        }

        private void OnDataReceived(DataReceivedEventArgs e)
        {
            if (DataReceived != null)
                DataReceived(this, e);
        }

        private void OnDataSended(EventArgs e)
        {
            if (DataSended != null)
                DataSended(this, e);
        }

        #endregion

        #region EventArgs

        public class DataReceivedEventArgs : EventArgs
        {
            public Buffer Data { get; private set; }
            public bool Intercept { get; private set; }

            public DataReceivedEventArgs(Buffer data, bool intercept = false)
            {
                Data = data;
                Intercept = intercept;
            }
        }

        #endregion
    }
}
