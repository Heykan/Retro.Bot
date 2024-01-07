using Retro.Bot.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol.Messages.Game.World.Map
{
    public class GameMapDataMessage : NetworkMessage
    {
        public const string Header = "GDM";
        public override string MessageHeader => Header;

        public short Id { get; set; }
        public string CreationDate { get; set; }
        public string DecryptKey { get; set; }

        public override void Deserialize(PacketReader reader)
        {
            Id = short.Parse(reader.PipeDelimiter[0]);
            CreationDate = reader.PipeDelimiter[1];
            DecryptKey = reader.PipeDelimiter[2];
        }

        public override void Serialize(PacketWriter writer)
        {
        }
    }
}
