using Retro.Bot.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot
{
    public class Bot
    {
        public event EventHandler<ClientAddedEventArgs> ClientAdded;
        public event EventHandler ClientRemoved;

        public List<Client> Clients { get; private set; } = new List<Client>();
        public List<int> HookedProcessId { get; private set; } = new List<int>();

        public Bot() 
        {
            
        }

        public void NewClient(Client client)
        {
            Clients.Add(client);
            HookedProcessId.Add(client.Process.Id);

            if (ClientAdded != null)
                ClientAdded(this, new ClientAddedEventArgs(client));
        }

        public void RemoveClient(Client client)
        {
            Clients.Remove(client);
            HookedProcessId.Remove(client.Process.Id);

            if (ClientRemoved != null)
                ClientRemoved(this, new EventArgs());
        }

        public class ClientAddedEventArgs : EventArgs
        {
            public Client Client { get; private set; }

            public ClientAddedEventArgs(Client client)
            {
                Client = client;
            }
        }
    }
}
