using Retro.Bot.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol.Types.Entity
{
    public class CharacterType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public Breed Breed { get; set; }
        public int Gender { get; set; }
        public Inventory.InventoryType Inventory { get; set; }

        public CharacterType() { }

        public void Serialize(PacketWriter writer)
        {

        }

        public void Deserialize(PacketReader reader)
        {
            Id = int.Parse(reader.PipeDelimiter[0]);
            Name = reader.PipeDelimiter[1];
            Level = int.Parse(reader.PipeDelimiter[2]);
            Breed = (Breed)int.Parse(reader.PipeDelimiter[3]);
            Gender = int.Parse(reader.PipeDelimiter[4]);

            Inventory = new Inventory.InventoryType();
            Inventory.Deserialize(reader);
        }
    }

    public enum Breed
    {
        Feca = 1,
        Osamoda = 2,
        Enutrof = 3,
        Sram = 4,
        Xelor = 5,
        Ecaflip = 6,
        Eniripsa = 7,
        Iop = 8,
        Cra = 9,
        Sadida = 10,
        Sacrieur = 11,
        Pandawa = 12
    }
}
