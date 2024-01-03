using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro.Bot.Forms.UC
{
    public partial class AccountUC : UserControl
    {
        public AccountUC()
        {
            InitializeComponent();
        }
    }

    public enum ProgressBarDisplayText
    {
        Percentage,
        CustomText
    }

    class CustomProgressBar : Control
    {
        private int _value;
        private int _maximum = 100;
        private int _minimum = 0;

        public int Value
        {
            get { return _value; }
            set { _value = value; Invalidate(); } // Redessine le contrôle lors du changement de valeur
        }

        public int Maximum
        {
            get { return _maximum; }
            set { _maximum = value; Invalidate(); }
        }

        public int Minimum
        {
            get { return _minimum; }
            set { _minimum = value; Invalidate(); }
        }

        public ProgressBarDisplayText DisplayStyle { get; set; }
        public String CustomText { get; set; }

        public CustomProgressBar()
        {
            // Support de la peinture personnalisée
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Fond de la barre de progression
            using (SolidBrush backgroundBrush = new SolidBrush(Color.FromArgb(51, 52, 53)))
            {
                g.FillRectangle(backgroundBrush, 0, 0, Width, Height);
            }

            // Barre de progression
            if (Value > 0)
            {
                float progressRatio = (float)Value / Maximum;
                Rectangle progressRect = new Rectangle(0, 0, (int)(Width * progressRatio), Height);

                using (GraphicsPath path = CreateRoundedRectanglePath(progressRect, 4))
                {
                    using (SolidBrush progressBrush = new SolidBrush(Color.MediumPurple))
                    {
                        g.FillPath(progressBrush, path);
                    }
                }
            }

            // Texte
            string text = DisplayStyle == ProgressBarDisplayText.Percentage ? $"{(int)(Value * 100.0 / Maximum)}%" : CustomText;

            using (Font f = new Font("Arial", 10, FontStyle.Bold))
            {
                SizeF len = g.MeasureString(text, f);
                Point location = new Point((int)(Width / 2 - len.Width / 2), (int)(Height / 2 - len.Height / 2));
                g.DrawString(text, f, Brushes.WhiteSmoke, location);
            }
        }

        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
