using Retro.Bot.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol.Messages.Connection
{
    public class NicknameMessage : NetworkMessage
    {
        public const string Header = "Ad";
        public override string MessageHeader => Header;

        public string Nickname { get; set; }

        public NicknameMessage() { }

        public NicknameMessage(string nickname) 
        {
            Nickname = nickname;
        }

        public override void Deserialize(PacketReader reader)
        {
            Nickname = reader.PipeDelimiter[0];
        }

        public override void Serialize(PacketWriter writer)
        {
            writer.Add(Nickname, "");
        }
    }
}
