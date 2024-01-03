using Retro.Bot.Extension;
using Retro.Bot.Protocol;
using Retro.Bot.Protocol.Messages.Connection;
using Retro.Bot.Protocol.Messages.Game.Map;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro.Bot.Network
{
    public class Sniffer : IDisposable
    {
        #region Declarations

        Server server;
        Client clientLocal;
        Client clientRemote;

        string forcedAddress = null;
        int forcedPort = 0;

        #endregion

        public Sniffer()
        {
            server = new Server();
            server.ConnectionAccepted += Server_ConnectionAccepted;
            server.Start(8080);
        }

        private void Server_ConnectionAccepted(object sender, System.Net.Sockets.Socket acceptedSocket)
        {
            Console.WriteLine("Nouveau client détecté.");
            clientLocal = new Client(acceptedSocket);
            clientRemote = new Client();
            clientLocal.DataReceived += ClientLocal_DataReceived;
            clientRemote.DataReceived += ClientRemote_DataReceived;
            if (forcedAddress == null)
                clientRemote.Start(Ankama.Data.IP, Ankama.Data.PORT);
            else
                clientRemote.Start(forcedAddress, forcedPort);
        }

        private void ClientRemote_DataReceived(object sender, Client.DataReceivedEventArgs e)
        {
            string packet = e.Data.Data.ToReadable();
            Console.WriteLine("RCV :: {0}", packet);

            NetworkMessage msg = ProtocolManager.GetPacket(e.Data.Data, e.Data.MessageHeader);
            try
            {
                msg?.Deserialize();
                /*if (msg != null)
                    HandlerManager.GetHandlers(msg);*/
            }
            catch
            {
                Console.WriteLine("Can't be deserialized/Get handler for {0}", msg.GetType().Name);
            }

            // On envoie au client les données
            switch (e.Data.MessageHeader)
            {
                case ServerSelectionMessage.Header:
                    var ssm = msg as ServerSelectionMessage;
                    forcedAddress = ssm.Ip;
                    forcedPort = ssm.Port;
                    string key = ssm.Key;

                    var nssm = new ServerSelectionMessage();
                    nssm.Init("127.0.0.1", 8080, key);
                    nssm.Serialize();
                    clientLocal.Send(nssm);
                    break;
                default:
                    clientLocal.Send(e.Data.Data);
                    break;
            }
        }

        private void ClientLocal_DataReceived(object sender, Client.DataReceivedEventArgs e)
        {
            Console.WriteLine("SND :: {0}", e.Data.Data.ToReadable());
            // On envoie au serveur les données
            clientRemote.Send(e.Data.Data);
        }

        public void Dispose()
        {
            clientLocal?.Stop();
            clientRemote?.Stop();
            server?.Stop();
        }
    }
}
