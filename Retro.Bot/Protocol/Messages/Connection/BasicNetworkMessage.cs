using Retro.Bot.IO;
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

        public BasicNetworkMessage() { }

        public override void Deserialize(PacketReader reader)
        {
        }

        public override void Serialize(PacketWriter writer)
        {
        }
    }
}
