using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol.Messages.Connection
{
    public class BasicNetworkMessage : NetworkMessage
    {
        public const string Header = "BN";
        public override string MessageHeader => Header;

        public override void Deserialize()
        {
        }

        public override void Serialize()
        {
        }
    }
}
