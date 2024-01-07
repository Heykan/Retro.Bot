using Retro.Bot.Game.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Game.Entity
{
    public interface IEntity
    {
        int Id { get; set; }
        Cell Cell { get; set; }
    }
}
