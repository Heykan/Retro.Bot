using Retro.Bot.IO;
using Retro.Bot.Protocol.Types.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol.Messages.Game.Entity
{
    public class IntervalRegenrationMessage : NetworkMessage
    {
        public const string Header = "ILS";
        public override string MessageHeader => Header;

        public int Interval { get; set; }

        public override void Deserialize(PacketReader reader)
        {
            Interval = int.Parse(reader.PipeDelimiter[0]);
        }

        public override void Serialize(PacketWriter writer)
        {

        }
    }
}
