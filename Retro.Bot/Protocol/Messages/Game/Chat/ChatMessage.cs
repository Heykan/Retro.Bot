using Retro.Bot.Core.Utils;
using Retro.Bot.IO;
using Retro.Bot.Protocol.Types.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol.Messages.Game.Chat
{
    public class ChatMessage : NetworkMessage
    {
        public const string Header = "cMK";
        public override string MessageHeader => Header;

        public LogType Channel { get; set; }
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string Message { get; set; }
        public List<int> ItemId { get; set; }

        public override void Deserialize(PacketReader reader)
        {
            CharacterId = int.Parse(reader.PipeDelimiter[1]);
            CharacterName = reader.PipeDelimiter[2];
            Message = reader.PipeDelimiter[3];

            ItemId = new List<int>();

            string[] spllitedItem = reader.PipeDelimiter[4].Split('!');
            if (reader.PipeDelimiter.Length >= 4 && reader.PipeDelimiter[4] != "")
                for (int i = 0; i < spllitedItem.Length; i += 2)
                {
                    ItemId.Add(int.Parse(spllitedItem[i]));
                }

            switch (reader.PipeDelimiter[0])
            {
                case "?":
                    Channel = LogType.Recruit;
                    break;
                case ":":
                    Channel = LogType.Trade;
                    break;
                case "":
                    Channel = LogType.Common;
                    break;
                case "%":
                    Channel = LogType.Guild;
                    break;
                case "F":
                    Channel = LogType.Private;
                    break;
                case "$":
                    Channel = LogType.Party;
                    break;
                case "#":
                    Channel = LogType.Team;
                    break;
            }
        }

        public override void Serialize(PacketWriter writer)
        {
        }
    }
}
