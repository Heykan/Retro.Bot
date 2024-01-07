using Retro.Bot.Core.Utils;
using Retro.Bot.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol.Messages.Game.Chat
{
    public class ClientChatMessage : NetworkMessage
    {
        public const string Header = "BM";
        public override string MessageHeader => Header;

        public LogType Channel { get; set; }
        public string Message { get; set; }
        public string Items { get; set; }

        public ClientChatMessage() { }

        public ClientChatMessage(LogType channel, string message, string items)
        {
            Channel = channel;
            Message = message;
            Items = items;
        }

        public override void Deserialize(PacketReader reader)
        {

        }

        public override void Serialize(PacketWriter writer)
        {
            string channel = string.Empty;
            switch (Channel)
            {
                case LogType.Recruit:
                    channel = "?";
                    break;
                case LogType.Trade:
                    channel = ":";
                    break;
                case LogType.Common:
                    channel = string.Empty;
                    break;
                case LogType.Guild:
                    channel = "%";
                    break;
                case LogType.Party:
                    channel = "$";
                    break;
                case LogType.Team:
                    channel = "#";
                    break;
            }

            writer.Add(channel, "|");
            writer.Add(Message, "|");
            writer.Add(Items, "");
        }
    }
}
