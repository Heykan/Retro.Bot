using Retro.Bot.Ankama;
using Retro.Bot.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol.Messages.Game.Map
{
    public class GameMapMessage : NetworkMessage
    {
        public const string Header = "GM";
        public override string MessageHeader => Header;

        public GameMapMessage()
        {
        }

        public void Init()
        {
        }

        public override void Deserialize()
        {
        }

        public override void Serialize()
        {
        }
    }
}
