using Retro.Bot.Protocol.Messages.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Managers
{
    public class ServerManager
    {
        private static ServerSelectionMessage _serverSelectionMessage;

        public static void SetServerInformation(ServerSelectionMessage serverSelectionMessage)
        {
            _serverSelectionMessage = serverSelectionMessage;
        }

        public static ServerSelectionMessage GetServerData()
        {
            return _serverSelectionMessage;
        }
    }
}
