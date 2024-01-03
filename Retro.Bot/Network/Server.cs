using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Retro.Bot.Network
{
    public class Server
    {
        private Socket _listener;
        private bool _isRunning;

        public bool IsRunning => _isRunning;

        public delegate void ConnectionAcceptedDelegate(object sender, Socket acceptedSocket);
        public event ConnectionAcceptedDelegate ConnectionAccepted;
        private void OnConnectionAccepted(Socket client)
        {
            if (ConnectionAccepted != null)
                ConnectionAccepted(this, client);
        }

        public Server()
        {
            if (_isRunning)
            {
                _isRunning = false;
                _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
        }

        public void Start(int port)
        {
            if (_isRunning)
            {
                Console.WriteLine("Serveur déjà en écoute.");
                return;
            }
            _isRunning = true;
            _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _listener.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
            _listener.Listen(5);
            _listener.BeginAccept(BeginAcceptCallback, _listener);
            Console.WriteLine("Serveur en écoute sur {0}.", port);
        }

        public void Listen()
        {
            _listener.BeginAccept(BeginAcceptCallback, _listener);
        }

        public void Stop()
        {
            _isRunning = false;
            _listener.Close(50);
        }

        private void BeginAcceptCallback(IAsyncResult ar)
        {
            if (_isRunning)
            {
                Socket listener = (Socket)ar.AsyncState;
                Socket acceptedSocket = listener.EndAccept(ar);
                listener.BeginAccept(BeginAcceptCallback, listener);
                OnConnectionAccepted(acceptedSocket);
            }
        }
    }
}
