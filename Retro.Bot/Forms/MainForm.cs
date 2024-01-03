using DarkUI.Forms;
using Retro.Bot.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Retro.Bot.Bot;

namespace Retro.Bot.Forms
{
    public partial class MainForm : DarkForm
    {
        private Bot _bot;

        public MainForm()
        {
            InitializeComponent();
            _bot = new Bot();

            _bot.ClientAdded += _bot_ClientAdded;
        }

        private void _bot_ClientAdded(object sender, ClientAddedEventArgs e)
        {
            panel_bot.Controls.Add(e.Client.SelectorUC);

            // Ajout du controle principal
            panel_account.Controls.Clear();
            panel_account.Controls.Add(e.Client.AccountUC);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void btn_add_account_Click(object sender, EventArgs e)
        {
            ProcessSelectorForm selectorForm = new ProcessSelectorForm(_bot);
            selectorForm.ProcesseSelected += SelectorForm_ProcesseSelected;
            selectorForm.ShowDialog();
        }

        private void SelectorForm_ProcesseSelected(object sender, ProcessSelectorForm.ProcessSelectedEventArgs e)
        {
            bool isPair = _bot.Clients.Count % 2 == 0;
            _bot.NewClient(new Core.Client(e.Process, isPair));
            var form = sender as ProcessSelectorForm;
            form.Close();
        }
    }
}
