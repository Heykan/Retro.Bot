using Retro.Bot.Game;
using Retro.Bot.Managers;
using Retro.Bot.Protocol.Types.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro.Bot.Forms.UC
{
    public partial class AccountSelectorUC : UserControl
    {
        private Color _color;
        Core.Client _client;

        public AccountSelectorUC(Core.Client client, bool isPair = false)
        {
            InitializeComponent();
            _client = client;

            label_name.Text = client.Account.Nickname;

            _client.Account.Character.Loaded += Character_Loaded;
            _client.Account.Character.StateChanged += Character_StateChanged;

            if (isPair)
                _color = Color.FromArgb(60, 63, 65);
            else
                _color = Color.FromArgb(50, 51, 52);
        }

        private void Character_StateChanged(object sender, Game.Entity.Character.CharacterStateChangedEventArgs e)
        {
            string status;

            switch (e.State)
            {
                case Game.Entity.CharacterState.CONNECTED_IDLE:
                    status = "En attente";
                    break;
                case Game.Entity.CharacterState.MOVING:
                    status = "En mouvement";
                    break;
                case Game.Entity.CharacterState.CONNECTING:
                    status = "Connexion";
                    break;
                default:
                    status = "En attente";
                    break;
            }

            this.Invoke((MethodInvoker)delegate
            {
                label_status.Text = status;
            });
        }

        private void Character_Loaded(object sender, Game.Entity.Character.CharacterLoadedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                label_name.Text = e.Character.Name;
                FileInfo avatar = new FileInfo($"breeds/avatar/{(int)e.Character.Breed}{e.Character.Gender}.png");
                if (!avatar.Exists)
                    return;

                picture_avatar.ImageLocation = $"breeds/avatar/{(int)e.Character.Breed}{e.Character.Gender}.png";
            });
        }

        private void control_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(90, 91, 92);
            Cursor = Cursors.Hand;
        }

        private void control_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = _color;
            Cursor = Cursors.Default;
        }

        public void Control_Click(object sender, EventArgs e)
        {
            (WindowManager.MainWindow).Invoke((MethodInvoker)delegate
            {
                WindowManager.MainWindow.panel_account.Controls.Clear();
                WindowManager.MainWindow.panel_account.Controls.Add(_client.Control);
            });
        }
    }
}
