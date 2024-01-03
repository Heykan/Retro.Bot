using Retro.Bot.Forms.UC;
using Retro.Bot.Game;
using Retro.Bot.Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Retro.Bot.Core
{
    public class Client
    {

        private Sniffer _sniffer { get; set; }
        private Process pythonProcess;

        public Process Process { get; private set; }
        public int PID => Process.Id;

        public AccountSelectorUC SelectorUC { get; private set; }
        public AccountUC AccountUC { get; private set; }

        public Account Account { get; internal set; }

        public Client(Process process, bool isPair = false)
        { 
            Process = process;
            Account = new Account(this);
            _sniffer = new Sniffer();

            SelectorUC = new AccountSelectorUC(isPair);
            AccountUC = new AccountUC();

            AccountUC.Dock = System.Windows.Forms.DockStyle.Fill;

            Hook();
        }

        private void Hook()
        {
            Thread hookThread = new Thread(() => RunHook(Process.Id));
            hookThread.Start();
        }

        private void RunHook(int childPid)
        {
            try
            {
                Console.WriteLine("Starting injection...");
                string path = Path.Combine(Directory.GetCurrentDirectory(), "hook.exe");
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = path,
                    Arguments = $"{childPid} {8080}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = false
                };

                pythonProcess = Process.Start(startInfo);
                Thread.Sleep(4000);
                Console.WriteLine("Process hooked.");
                pythonProcess.WaitForExit();
            }
            catch (Exception)
            {
            }
        }
    }
}
