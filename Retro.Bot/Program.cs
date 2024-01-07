using Retro.Bot.Forms;
using Retro.Bot.Managers;
using Retro.Bot.Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro.Bot
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Sniffer sniffer = new Sniffer();
                MainForm mainForm = new MainForm();

                WindowManager.Init(mainForm);
                Application.Run(mainForm);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                Console.Read();
            }
        }
    }
}
