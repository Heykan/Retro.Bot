using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.IO
{
    public class PacketWriter
    {
        public string Data { get; private set; } = string.Empty;

        public void Add(string data, string delimiter)
        {
            Data += $"{data}{delimiter}";
        }

        public void AddHeader(string data)
        {
            Data = data + Data;
        }
    }
}
