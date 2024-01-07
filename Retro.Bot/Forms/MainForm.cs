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
            _bot.PatchClient(e.Process);
            var form = sender as ProcessSelectorForm;
            form.Close();
        }
    }
}
