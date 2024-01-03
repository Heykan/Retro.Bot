using Retro.Bot.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var sData = value.ToReadable();
                _data = sData.Substring(MessageHeader.Length).ToBytes();
            }
        }

        public abstract string MessageHeader { get; }

        public abstract void Serialize();
        public abstract void Deserialize();

        protected void SetData(byte[] data)
        {
            _data = data;
        }
    }
}
