using Retro.Bot.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Retro.Bot
{
    public class Bot
    {
        public event EventHandler<ClientPatchedEventArgs> ClientPatched;

        private Dictionary<int, Thread> processThread = new Dictionary<int, Thread>();
        private Dictionary<int, Process> fridaProcesses = new Dictionary<int, Process>();

        public List<Client> Clients { get; private set; } = new List<Client>();
        public List<int> HookedProcessId { get; private set; } = new List<int>();

        public Bot() 
        {
            
        }

        public void PatchClient(Process process)
        {
            HookedProcessId.Add(process.Id);

            Thread hookThread = new Thread(() => RunHook(process.Id));
            processThread.Add(process.Id, hookThread);
            hookThread.Start();

            if (ClientPatched != null)
                ClientPatched(this, new ClientPatchedEventArgs(process.Id));
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

                var pythonProcess = Process.Start(startInfo);
                fridaProcesses.Add(childPid, pythonProcess);

                Thread.Sleep(4500);
                Console.WriteLine("Process hooked.");
                pythonProcess.WaitForExit();
            }
            catch (Exception)
            {
            }
        }

        public class ClientPatchedEventArgs : EventArgs
        {
            public int ProcessId { get; private set; }

            public ClientPatchedEventArgs(int processId)
            {
                ProcessId = processId;
            }
        }
    }
}
