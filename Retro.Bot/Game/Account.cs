using Retro.Bot.Core;
using Retro.Bot.Game.Entity;
using Retro.Bot.Game.World;
using Retro.Bot.Network;
using Retro.Bot.Protocol.Messages.Connection;
using Retro.Bot.Protocol.Messages.Game.Entity;
using Retro.Bot.Protocol.Types.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro.Bot.Game
{
    public class Account
    {
        private Core.Client _client { get; set; }

        public Character Character { get; set; }
        public string Nickname { get; set; }

        public Account(Core.Client client)
        {
            _client = client;
            Character = new Character(_client, -1, Nickname, null);

            _client.Network.RegisterMessage<NicknameMessage>(OnNicknameMessage, MessagePriority.High);
        }

        private void OnNicknameMessage(Core.Client client, NicknameMessage message)
        {
            Console.WriteLine($"{message.Nickname} connected");
            Nickname = message.Nickname;

            if (AccountConnected != null)
                AccountConnected(this, new AccountConnectedEventArgs(message.Nickname));
        }

        #region Events

        public event EventHandler<AccountConnectedEventArgs> AccountConnected;

        public class AccountConnectedEventArgs : EventArgs
        {
            public string Nickname { get; set; }
            public AccountConnectedEventArgs(string nickname)
            {
                Nickname = nickname;
            }
        }

        #endregion
    }
}
