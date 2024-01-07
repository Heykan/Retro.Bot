using Retro.Bot.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol.Messages.Game.Inventory
{
    public class InventoryWeightMessage : NetworkMessage
    {
        public const string Header = "Ow";
        public override string MessageHeader => Header;

        public short CurrentPods { get; set; }
        public short MaximumPods { get; set; }

        public override void Deserialize(PacketReader reader)
        {
            CurrentPods = short.Parse(reader.PipeDelimiter[0]);
            MaximumPods = short.Parse(reader.PipeDelimiter[1]);
        }

        public override void Serialize(PacketWriter writer)
        {

        }
    }
}
