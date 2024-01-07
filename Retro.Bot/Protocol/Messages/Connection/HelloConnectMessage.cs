using Retro.Bot.Extension;
using Retro.Bot.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol.Messages.Connection
{
    public class HelloConnectMessage : NetworkMessage
    {
        public const string Header = "HC";
        public override string MessageHeader => Header;

        public string Salt { get; private set; }

        public HelloConnectMessage()
        {
        }

        public HelloConnectMessage(string salt)
        {
            Salt = salt;
        }

        public override void Deserialize(PacketReader reader)
        {
            Salt = reader.PipeDelimiter[0];
        }

        public override void Serialize(PacketWriter writer)
        {
            writer.Add(Salt, "");
        }
    }
}
