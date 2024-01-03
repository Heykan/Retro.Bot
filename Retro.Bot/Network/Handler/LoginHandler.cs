using Retro.Bot.Protocol;
using Retro.Bot.Protocol.Messages.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Network.Handler
{
    public class LoginHandler
    {
        [PacketReceive("HC")]
        public void HandleCharacterSelection(HelloConnectMessage msg)
        {
            Console.WriteLine("Hello from login {0}", msg.Salt);
        }
    }
}
