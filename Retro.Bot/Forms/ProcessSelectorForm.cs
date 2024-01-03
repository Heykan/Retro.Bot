using DarkUI.Forms;
using Retro.Bot.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Retro.Bot.Forms
{
    public partial class ProcessSelectorForm : DarkForm
    {
        public event EventHandler<ProcessSelectedEventArgs> ProcesseSelected;

        private Bot _bot;
        private List<Process> _processes;

        public ProcessSelectorForm(Bot bot)
        {
            InitializeComponent();

            _bot = bot;
            _processes = GetDofusProcesses();
        }

        private List<Process> GetDofusProcesses()
        {
            List<Process> list = new List<Process>();
            foreach (var process in Process.GetProcessesByName("Dofus"))
            {
                if (!_bot.HookedProcessId.Contains(process.Id))
                {
                    list.Add(process);
                    imagelist_process.Images.Add(process.Id.ToString(), process.GetIcon());
                    listview_process.Items.Add(process.ProcessName, process.Id.ToString());
                }
            }

            return list;
        }

        private void listview_process_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Active le bouton en fonction du nombre de sélection
            if (listview_process.SelectedIndices.Count > 0)
                btn_select.Enabled = true;
            else
                btn_select.Enabled = false;
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            if (listview_process.SelectedIndices.Count <= 0)
                return;

            ListViewItem item = listview_process.SelectedItems[0];
            int selectedIndex = int.Parse(item.ImageKey);
            Process selectedProcess = _processes.First(f => f.Id == selectedIndex);

            if (ProcesseSelected != null)
                ProcesseSelected(this, new ProcessSelectedEventArgs(selectedProcess));
        }

        public class ProcessSelectedEventArgs : EventArgs 
        {
            public Process Process { get; private set; }

            public ProcessSelectedEventArgs(Process process)
            {
                Process = process;
            }
        }
    }
}
