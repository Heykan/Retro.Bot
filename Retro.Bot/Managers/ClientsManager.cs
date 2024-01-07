using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro.Bot.Managers
{
    public class ClientsManager
    {
        public static List<Core.Client> GameClients;
        public static List<Core.Client> LoginClients;
        private static object CheckLock;

        static ClientsManager()
        {
            GameClients = new List<Core.Client>();
            LoginClients = new List<Core.Client>();
            CheckLock = new object();
        }

        public static Core.Client RegisterClient(Socket sock, bool silent)
        {
            lock(CheckLock)
            {
                Core.Client client = new Core.Client(sock, silent);
                client.ClientUnloaded += Client_ClientUnloaded;
                client.LoadClient();

                if (silent)
                    LoginClients.Add(client);
                else
                    GameClients.Add(client);

                return client;
            }
        }

        public static void UnloadAll()
        {
            lock (CheckLock)
            {
                foreach (Core.Client client in GameClients)
                    client.UnloadClient(true);

                foreach (Core.Client client in LoginClients)
                    client.UnloadClient(true);
            }
        }

        private static void Client_ClientUnloaded(object sender, Core.Client.ClientEventArgs e)
        {
            e.Client.ClientUnloaded -= Client_ClientUnloaded;

            if (!e.Client.Silent)
                OnClientUnloaded(e.Client.Account.Nickname);

            lock (CheckLock)
            {
                if (LoginClients.Contains(e.Client))
                    LoginClients.Remove(e.Client);
                else if (GameClients.Contains(e.Client))
                    GameClients.Remove(e.Client);
            }
        }

        #region Events

        public static event EventHandler<Core.Client> ClientLoaded_Event;
        public static event EventHandler<string> ClientUnloaded_Event;

        public static void OnClientLoaded(Core.Client c)
        {
            if (ClientLoaded_Event != null)
                ClientLoaded_Event(null, c);
        }

        private static void OnClientUnloaded(string c)
        {
            if (ClientUnloaded_Event != null)
                ClientUnloaded_Event(null, c);
        }

        #endregion
    }
}
