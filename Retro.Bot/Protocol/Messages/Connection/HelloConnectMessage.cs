using Retro.Bot.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol.Messages.Connection
{
    public class HelloConnectMessage : NetworkMessage
    {
        public const string Header = "HC";
        public override string MessageHeader => Header;

        public string Salt { get; private set; }

        public HelloConnectMessage()
        {
        }

        public void Init(string salt)
        {
            Salt = salt;
        }

        public override void Deserialize()
        {
            Salt = Data.ToReadable();
        }

        public override void Serialize()
        {
            SetData(Salt.ToBytes());
        }
    }
}
