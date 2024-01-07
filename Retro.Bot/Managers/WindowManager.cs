using Retro.Bot.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro.Bot.Managers
{
    public class WindowManager
    {
        public static MainForm MainWindow;

        private static object CheckLock;

        static WindowManager()
        {
            CheckLock = new object();
        }

        public static void Init(MainForm window)
        {
            MainWindow = window;
        }


    }
}
