using Retro.Bot.Game.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Game.Entity
{
    public class Npc : IEntity
    {
        public int Id { get; set; }
        public Cell Cell { get; set; }
        public int ModelId { get; private set; }

        public Npc(int id, int modelId, Cell cell)
        {
            Id = id;
            ModelId = modelId;
            Cell = cell;
        }
    }
}
