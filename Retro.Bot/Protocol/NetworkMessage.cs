using Retro.Bot.Core;
using Retro.Bot.Extension;
using Retro.Bot.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro.Bot.Protocol
{
    public abstract class NetworkMessage : MarshalByRefObject
    {
        private byte[] _data;
        public byte[] Data
        {
            get => _data; 
            set
            {
                int offset = 0;
                var sData = value.ToReadable();
                if (MessageHeader.Length + 1 <= sData.Length && sData.Substring(0, MessageHeader.Length + 1).EndsWith("|"))
                    offset = 1;
                _data = sData.Substring(MessageHeader.Length + offset).ToBytes();
            }
        }

        public byte[] RawData => $"{MessageHeader}{_data.ToReadable()}".ToBytes();

        public bool Cancel { get; set; } = false;

        public abstract string MessageHeader { get; }

        public abstract void Serialize(PacketWriter writer);
        public abstract void Deserialize(PacketReader reader);

        public void Pack(PacketWriter writer, MessageDestination destination)
        {
            Serialize(writer);
            if (!writer.Data.StartsWith(MessageHeader))
                writer.AddHeader(MessageHeader);

            if (destination == MessageDestination.Server)
                writer.Add($"{(char)10}{(char)0}", "");

            _data = writer.Data.ToBytes(); ;
        }
    }
}
