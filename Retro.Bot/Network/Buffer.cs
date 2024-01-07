using Retro.Bot.Ankama;
using Retro.Bot.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Retro.Bot.Network
{
    public class Buffer
    {
        private byte[] m_data;

        public byte[] Data
        {
            get { return m_data; }
            private set { m_data = value; }
        }

        /*public string MessageHeader
        {
            get
            {
                if (m_data == null)
                    return null;

                string header = null;
                Regex regex = new Regex(@"^([A-Z]+)");
                Match match = regex.Match(m_data.ToReadable());
                if (match.Success)
                {
                    header = match.Groups[1].Value;
                }
                return header;
            }
        }*/

        public void Build(byte[] data)
        {
            Data = data;
        }
    }
}
