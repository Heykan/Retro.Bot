using Retro.Bot.Managers;
using System;
using System.Net.Sockets;

namespace Retro.Bot.Network
{
    public class Sniffer : IDisposable
    {
        #region Declarations

        Server _loginServer;
        Server _gameServer;

        #endregion

        public Sniffer()
        {
            try
            {
                _loginServer = new Server();

                _loginServer.ConnectionAccepted += LoginServer_ConnectionAccepted;

                _loginServer.Start(8080);
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"[Network] {ex.Message}");
            }
        }

        private void LoginServer_ConnectionAccepted(object sender, Socket acceptedSocket)
        {
            if (ServerManager.GetServerData() == null)
            {
                Console.WriteLine("Nouveau client sur le serveur d'authentification.");
                ClientsManager.RegisterClient(acceptedSocket, true);
            }
            else
            {
                Console.WriteLine("Nouveau client sur le serveur de jeu.");
                ClientsManager.RegisterClient(acceptedSocket, false);
            }
        }

        public void Dispose()
        {
            _loginServer?.Stop();
            _gameServer?.Stop();
        }
    }
}
