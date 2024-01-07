using Retro.Bot.Game.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Game.Entity
{
    public class Monster : IEntity
    {
        public int Id { get; set; }
        public Cell Cell { get; set; }
        public int TemplateId { get; set; } = 0;
        public int Level { get; set; }
        public List<Monster> MonstersInsideGroup { get; set; }
        public Monster GroupLeader { get; set; }
        public int TotalMonsters => MonstersInsideGroup.Count + 1;
        public int TotalGroupLevel => GroupLeader.Level + MonstersInsideGroup.Sum(f => f.Level);

        public Monster(int id, int template, Cell cell, int level)
        {
            Id = id;
            TemplateId = template;
            Cell = cell;
            MonstersInsideGroup = new List<Monster>();
            Level = level;
        }

        public bool ContainsMonster(int id)
        {
            if (GroupLeader.TemplateId == id)
                return true;

            for (int i = 0; i < MonstersInsideGroup.Count; i++)
            {
                if (MonstersInsideGroup[i].TemplateId == id)
                    return true;
            }
            return false;
        }
    }
}
