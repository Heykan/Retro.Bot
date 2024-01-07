using Retro.Bot.Ankama;
using Retro.Bot.Extension;
using Retro.Bot.Game.Entity;
using Retro.Bot.Game.World;
using Retro.Bot.Game;
using Retro.Bot.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol.Messages.Game.World.Map
{
    public class GameMapMessage : NetworkMessage
    {
        public const string Header = "GM";
        public override string MessageHeader => Header;
        public string[] Players { get; set; }

        public GameMapMessage()
        {
        }

        public void Init()
        {
        }

        public override void Serialize(PacketWriter writer)
        {
        }

        public override void Deserialize(PacketReader reader)
        {
            Players = reader.PipeDelimiter;
        }
    }
}
