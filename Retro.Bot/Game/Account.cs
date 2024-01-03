using Retro.Bot.Core;
using Retro.Bot.Game.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Game
{
    public class Account
    {
        public Client Client { get; private set; }
        public Character Character { get; private set; }

        public Account(Client client)
        {
            Client = client;
        }
    }
}
