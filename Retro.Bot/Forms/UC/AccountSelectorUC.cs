using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro.Bot.Forms.UC
{
    public partial class AccountSelectorUC : UserControl
    {
        private Color _color;

        public AccountSelectorUC(bool isPair = false)
        {
            InitializeComponent();

            if (isPair)
                _color = Color.FromArgb(60, 63, 65);
            else
                _color = Color.FromArgb(50, 51, 52) ;
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
    }
}
