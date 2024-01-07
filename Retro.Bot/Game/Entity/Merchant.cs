using Retro.Bot.Game.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Game.Entity
{
    public class Merchant : IEntity
    {
        public int Id { get; set; }
        public Cell Cell { get; set; }

        public Merchant(int id, Cell cell)
        {
            Id = id;
            Cell = cell;
        }
    }
}
