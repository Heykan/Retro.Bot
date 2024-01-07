using Retro.Bot.Core.Utils;
using Retro.Bot.Forms;
using Retro.Bot.Forms.UC;
using Retro.Bot.Game;
using Retro.Bot.Managers;
using Retro.Bot.Network;
using Retro.Bot.Protocol;
using Retro.Bot.Protocol.Messages.Game.Chat;
using Retro.Bot.Protocol.Types.Inventory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Retro.Bot.Core
{
    public class Client
    {
        public AccountUC Control { get; set; }
        public AccountSelectorUC Selector { get; set; }

        public Account Account { get; internal set; }
        public Logger Logger { get; private set; }
        public ClientNetwork Network { get; private set; }

        public bool Silent { get; set; }

        public Client(Socket socket, bool silent)
        {
            Silent = silent;
            Network = new ClientNetwork(socket, this);
            Account = new Account(this);

            Network.RegisterMessage<ChatMessage>(OnChatMessage, Core.MessagePriority.Normal);
        }

        public void LoadClient()
        {
            try
            {
                if (!Silent)
                {
                    LoadControl();
                }

                Network.OpenConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LoadClient] {ex.Message}");
            }
        }

        public void UnloadClient(bool cancelEvent = false)
        {
            try
            {
                if (!cancelEvent)
                    OnClientUnloaded(new ClientEventArgs(this));

                if (Network != null)
                {
                    Network.StopConnection();
                }

                if (Control != null)
                    (WindowManager.MainWindow).Invoke((MethodInvoker)delegate
                    {
                        WindowManager.MainWindow.panel_account.Controls.Clear();
                        WindowManager.MainWindow.panel_bot.Controls.Remove(Selector);
                    });

                Network = null;

                GC.Collect();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UnloadClient] {ex.Message}");
            }
        }

        public void LoadControl()
        {
            try
            {
                Control = new AccountUC(this);
                Control.Dock = System.Windows.Forms.DockStyle.Fill;

                Logger = new Logger(Control.rtb_chat);

                Selector = new AccountSelectorUC(this);

                (WindowManager.MainWindow).Invoke((MethodInvoker)delegate 
                {
                    WindowManager.MainWindow.panel_account.Controls.Add(Control);
                    WindowManager.MainWindow.panel_bot.Controls.Add(Selector); 
                });
                Logger.Append($"Connexion au serveur de jeu réussi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UnloadClient] {ex.Message}");
            }
        }

        #region Handler

        private void OnChatMessage(Client client, ChatMessage message)
        {
            StringBuilder builder = new StringBuilder();
            switch(message.Channel)
            {
                case LogType.Common:
                    builder.Append($@"(Général) [bold]{message.CharacterName}[/bold]: ");
                    break;
                case LogType.Recruit:
                    builder.Append($@"(Recrutement) [bold]{message.CharacterName}[/bold]: ");
                    break;
                case LogType.Trade:
                    builder.Append($@"(Commerce) [bold]{message.CharacterName}[/bold]: ");
                    break;
                case LogType.Guild:
                    builder.Append($@"(Guilde) [bold]{message.CharacterName}[/bold]: ");
                    break;
                case LogType.Private:
                    builder.Append($@"(Message privé) de [bold]{message.CharacterName}[/bold]: ");
                    break;
                case LogType.Party:
                    builder.Append($@"(Groupe) [bold]{message.CharacterName}[/bold]: ");
                    break;
                case LogType.Team:
                    builder.Append($@"(Équipe) [bold]{message.CharacterName}[/bold]: ");
                    break;
            }

            if (message.ItemId.Count > 0)
            {
                for (int i = 0; i < message.ItemId.Count; i++)
                {
                    FileInfo itemFileDetails = new FileInfo($"items/{message.ItemId[i]}.xml");
                    if (itemFileDetails.Exists)
                    {
                        var itemFile = XElement.Load(itemFileDetails.FullName);
                        var name = itemFile.Element("Name").Value;
                        message.Message = message.Message.Replace($"°{i}", $"[bold][{name}][/bold]");
                    }
                }
            }

            builder.Append(message.Message);
            Logger.Append(builder.ToString(), message.Channel);
        }

        #endregion

        #region Events

        public event EventHandler<ClientEventArgs> ClientUnloaded;

        private void OnClientUnloaded(ClientEventArgs e)
        {
            if (ClientUnloaded != null)
                ClientUnloaded(this, e);
        }

        public class ClientEventArgs
        {
            public Client Client;

            public ClientEventArgs(Client client)
            {
                Client = client;
            }
        }

        #endregion
    }
}
