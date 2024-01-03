using Retro.Bot.Extension;
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

        public void Init(string ip, int port, string key)
        {
            Ip = ip;
            Port = port;
            Key = key;
        }

        public override void Deserialize()
        {
            string packet = Data.ToReadable();
            var splittedData = packet.Split(':');
            var splittedPortAndKey = splittedData.Last().Split(';');

            Ip = splittedData.First();
            Port = int.Parse(splittedPortAndKey.First());
            Key = splittedPortAndKey.Last();
        }

        public override void Serialize()
        {
            SetData($"{Header}{Ip}:{Port};{Key}".ToBytes());
        }
    }
}
