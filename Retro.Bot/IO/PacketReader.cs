using Retro.Bot.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.IO
{
    public class PacketReader
    {
        public string[] PipeDelimiter { get; set; }
        //public List<string[]> SemicolonDelimiter { get; set; }
        public string DecryptedData { get; set; }
        public byte[] Data { get; set; }

        public void Read(byte[] data)
        {
            string raw = data.ToReadable();
            Data = data;
            DecryptedData = raw;
            PipeDelimiter = raw.Split('|');
            //SemicolonDelimiter = new List<string[]>();

            /*foreach (string s in PipeDelimiter)
            {
                SemicolonDelimiter.Add(s.Split(';'));
            }*/
        }
    }
}
