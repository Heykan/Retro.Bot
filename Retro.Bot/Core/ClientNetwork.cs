using Retro.Bot.Extension;
using Retro.Bot.IO;
using Retro.Bot.Managers;
using Retro.Bot.Network;
using Retro.Bot.Protocol;
using Retro.Bot.Protocol.Messages.Connection;
using Retro.Bot.Protocol.Messages.Game.Entity;
using Retro.Bot.Protocol.Types.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Retro.Bot.Game.Account;

namespace Retro.Bot.Core
{
    public class ClientNetwork
    {
        private Dictionary<Type, List<MessageHandler>> _handlers = new Dictionary<Type, List<MessageHandler>>();

        public Network.Client Client { get; set; }
        public Network.Client Server { get; set; }

        private Client _client;
        private Socket _socket;

        public ClientNetwork(Socket socket, Client client) 
        {
            _client = client;
            _socket = socket;
        }

        #region Methods public

        public void RegisterMessage<T>(Action<Client, T> handler, MessagePriority priority) where T : NetworkMessage
        {
            Type messageType = typeof(T);
            if (!_handlers.ContainsKey(messageType))
            {
                _handlers[messageType] = new List<MessageHandler>();
            }
            _handlers[messageType].Add(new MessageHandler((_client, msg) => handler(_client, (T)msg), priority));
        }

        public void UnregisterMessage<T>() where T : NetworkMessage
        {
            _handlers.Remove(typeof(T));
        }

        public void OpenConnection()
        {
            try
            {
                Client = new Network.Client();
                Server = new Network.Client();

                Server.Disconnected += Server_Disconnected;
                Server.DataReceived += Server_DataReceived;

                Client.Disconnected += Client_Disconnected;
                Client.DataReceived += Client_DataReceived;

                Client.Start(_socket);
                if (_client.Silent)
                {
                    Server.Start(Ankama.Data.IP, Ankama.Data.PORT);
                    RegisterMessage<ServerSelectionMessage>(OnServerSelectionMessage, MessagePriority.High);
                }
                else
                {
                    var msg = ServerManager.GetServerData();
                    string address = msg.Ip;
                    int port = msg.Port;

                    Server.Start(address, port);

                    ServerManager.SetServerInformation(null);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"[Network] {ex}");
            }
        }

        public void StopConnection()
        {
            try
            {
                if (Client != null)
                {
                    Client.Disconnected -= Client_Disconnected;
                    Client.DataReceived -= Client_DataReceived;

                    if (Client.IsConnected)
                        Client.Stop();

                    Client = null;
                }

                if (Server != null)
                {
                    Server.Disconnected -= Server_Disconnected;
                    Server.DataReceived -= Server_DataReceived;

                    if (Server.IsConnected)
                        Server.Stop();

                    Server = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Network] " + ex.Message);
            }
        }

        public void Send(Network.Buffer message, MessageDestination destination)
        {
            try
            {
                if (_client.Network == null)
                    return;

                //Console.WriteLine($"SND BUFFER :: {message.Data.ToReadable()} > {destination}");

                switch (destination)
                {
                    case MessageDestination.Client:
                        _client.Network.Client.Send(message.Data);
                        break;
                    case MessageDestination.Server:
                        _client.Network.Server.Send(message.Data);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Network] Send Function -> {ex.Message}");
            }
        }

        private void Send(byte[] message, MessageDestination destination)
        {
            try
            {
                if (_client.Network == null)
                    return;

                //Console.WriteLine($"SND BUFFER :: {message.Data.ToReadable()} > {destination}");

                switch (destination)
                {
                    case MessageDestination.Client:
                        _client.Network.Client.Send(message);
                        break;
                    case MessageDestination.Server:
                        _client.Network.Server.Send(message);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Network] Send Function -> {ex.Message}");
            }
        }

        public void Send(NetworkMessage message, MessageDestination destination = MessageDestination.Server)
        {
            if (message.Cancel)
                return;

            PacketWriter writer = new PacketWriter();
            message.Pack(writer, destination);

            Console.WriteLine($"SND NETWORK :: {message.Data.ToReadable()} > {destination}");
            //return;

            try
            {
                if (_client.Network == null)
                    return;

                switch (destination) 
                {
                    case MessageDestination.Client:
                        _client.Network.Client.Send(message.Data);
                        if (ServerMessageReceived != null)
                            OnServerMessageReceived(new MessageReceivedEventArgs(message));
                        break;
                    case MessageDestination.Server:
                        _client.Network.Server.Send(message.Data);
                        if (ServerMessageReceived != null)
                            OnClientMessageReceived(new MessageReceivedEventArgs(message));
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Network] Send Function -> {ex.Message}");
            }
        }

        #endregion

        #region Private methods

        private void HandleMessage(NetworkMessage message)
        {
            if (message == null) return;

            Type messageType = message.GetType();
            if (_handlers.ContainsKey(messageType))
            {
                var handlers = _handlers[messageType];
                foreach (var handler in handlers.OrderByDescending(h => h.Priority))
                {
                    handler.Handler(_client, message);
                }
            }
        }

        #endregion

        #region Packet handler

        private void OnServerSelectionMessage(Client client, ServerSelectionMessage message)
        {
            ServerSelectionMessage msg = (ServerSelectionMessage)message;
            ServerManager.SetServerInformation(msg);
        }

        #endregion

        #region DataReceived

        private void Client_DataReceived(object sender, Network.Client.DataReceivedEventArgs e)
        {
            Console.WriteLine($"Client >> {e.Data.Data.ToReadable()}");
            try
            {
                NetworkMessage message = ProtocolManager.GetPacket(e.Data.Data);
                if (ClientMessageReceived != null)
                    OnClientMessageReceived(new MessageReceivedEventArgs(message));

                /*if (message == null)
                {
                    Send(e.Data, MessageDestination.Server);
                    return;
                }*/

                HandleMessage(message);

                /*if (!message.Cancel)
                {
                    Send(message, MessageDestination.Server);
                }*/

                Send(e.Data, MessageDestination.Server);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Network] ServerDataReceived Function {ex.Message}");
            }
        }

        private void Server_DataReceived(object sender, Network.Client.DataReceivedEventArgs e)
        {
            Console.WriteLine($"Server >> {e.Data.Data.ToReadable()}");
            try
            {
                string stringData = e.Data.Data.ToReadable();
                string[] splitData = stringData.Split('\0');

                foreach (var item in splitData)
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        continue;
                    }

                    //Console.WriteLine(item + ": " + item);

                    NetworkMessage message = ProtocolManager.GetPacket(item.ToBytes());
                    if (ClientMessageReceived != null)
                        OnClientMessageReceived(new MessageReceivedEventArgs(message));
                    
                    if (message != null)
                    {
                        HandleMessage(message);
                    }
                }

                Send(e.Data.Data, MessageDestination.Client);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Network] ServerDataReceived Function {ex.Message}");
            }
        }

        #endregion

        #region Disconnect

        private void Server_Disconnected(object sender, EventArgs e)
        {
            if (!_client.Silent)
                _client.UnloadClient();
        }

        private void Client_Disconnected(object sender, EventArgs e)
        {
            _client.UnloadClient();
        }

        #endregion

        #region Emits Events

        public event EventHandler<MessageReceivedEventArgs> ServerMessageReceived;
        public event EventHandler<MessageReceivedEventArgs> ClientMessageReceived;

        private void OnServerMessageReceived(MessageReceivedEventArgs e)
        {
            if (ServerMessageReceived != null)
                ServerMessageReceived(this, e);
        }

        private void OnClientMessageReceived(MessageReceivedEventArgs e)
        {
            if (ClientMessageReceived != null)
                ClientMessageReceived(this, e);
        }


        public class MessageReceivedEventArgs
        {
            public NetworkMessage Msg;

            public MessageReceivedEventArgs(NetworkMessage msg)
            {
                Msg = msg;
            }
        }

        #endregion

        #region Struct

        private struct MessageHandler
        {
            public Action<Client, NetworkMessage> Handler;
            public MessagePriority Priority;

            public MessageHandler(Action<Client, NetworkMessage> handler, MessagePriority priority)
            {
                Handler = handler;
                Priority = priority;
            }
        }

        #endregion
    }

    public enum MessagePriority
    {
        Low = 0,
        Normal = 1,
        High = 2
    }

    public enum MessageDestination
    {
        Server,
        Client
    }
}
