using Retro.Bot.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol.Messages.Game.Entity
{
    public class CharacteristicDataMessage : NetworkMessage
    {
        public const string Header = "As";
        public override string MessageHeader => Header;

        public long Kamas { get; set; }
        public int CurrentExperience { get; set; }
        public int StartExperience { get; set; }
        public int EndExperience { get; set; }
        public int Capital { get; set; }
        public int SpellCapital { get; set; }
        public string Alignement { get; set; }
        public int CurrentLife { get; set; }
        public int MaximumLife { get; set; }
        public int CurrentEnergy { get; set; }
        public int MaximumEnergy { get; set; }


        public override void Deserialize(PacketReader reader)
        {
            // Experience
            string[] experience = reader.PipeDelimiter[0].Split(',');
            CurrentExperience = int.Parse(experience[0]);
            StartExperience = int.Parse(experience[1]);
            EndExperience = int.Parse(experience[2]);
            // Kamas
            Kamas = int.Parse(reader.PipeDelimiter[1]);
            // Capital
            Capital = int.Parse(reader.PipeDelimiter[2]);
            SpellCapital = int.Parse(reader.PipeDelimiter[3]);
            // Alignement
            Alignement = reader.PipeDelimiter[4];
            // Life
            string[] life = reader.PipeDelimiter[5].Split(',');
            CurrentLife = int.Parse(life[0]);
            MaximumLife = int.Parse(life[1]);
            // Energy
            string[] energy = reader.PipeDelimiter[6].Split(',');
            CurrentEnergy = int.Parse(energy[0]);
            MaximumEnergy = int.Parse(energy[1]);
        }

        public override void Serialize(PacketWriter writer)
        {

        }
    }
}
