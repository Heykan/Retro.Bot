using Retro.Bot.IO;
using Retro.Bot.Protocol.Types.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol.Messages.Game.Entity
{
    public class CharacterSelectedMessage : NetworkMessage
    {
        public const string Header = "ASK";
        public override string MessageHeader => Header;

        public CharacterType Character { get; set; }

        public override void Deserialize(PacketReader reader)
        {
            Character = new CharacterType();
            Character.Deserialize(reader);
        }

        public override void Serialize(PacketWriter writer)
        {
        }
    }
}
