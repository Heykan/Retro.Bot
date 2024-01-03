using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Network
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PacketReceiveAttribute : Attribute
    {
        public string Header { get; private set; }

        public PacketReceiveAttribute(string header)
        {
            Header = header;
        }
    }
}
