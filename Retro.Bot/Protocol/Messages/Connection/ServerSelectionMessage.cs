using Retro.Bot.Extension;
using Retro.Bot.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol.Messages.Connection
{
    public class ServerSelectionMessage : NetworkMessage
    {
        public const string Header = "AYK";
        public override string MessageHeader => Header;

        public string Ip { get; private set; }
        public int Port { get; private set; }
        public string Key { get; private set; }

        public ServerSelectionMessage()
        {
        }

        public ServerSelectionMessage(string ip, int port, string key)
        {
            Ip = ip;
            Port = port;
            Key = key;
        }

        public override void Deserialize(PacketReader reader)
        {
            string[] ipPort = reader.PipeDelimiter.First().Split(';')[0].Split(':');

            Ip = ipPort[0];
            Port = int.Parse(ipPort[1]);
            Key = reader.PipeDelimiter.First().Split(';')[1];
        }

        public override void Serialize(PacketWriter writer)
        {
            writer.Add(Ip, ":");
            writer.Add(Port.ToString(), ";");
            writer.Add(Key, "");
        }
    }
}
