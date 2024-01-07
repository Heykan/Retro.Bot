using Retro.Bot.Core;
using Retro.Bot.Core.Utils;
using Retro.Bot.Game;
using Retro.Bot.Game.Inventory;
using Retro.Bot.Managers;
using Retro.Bot.Network;
using Retro.Bot.Protocol.Messages.Game.Chat;
using Retro.Bot.Protocol.Types.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro.Bot.Forms.UC
{
    public partial class AccountUC : UserControl
    {
        private Core.Client _client;
        private MapControl _mapControl;

        public AccountUC(Core.Client client)
        {
            InitializeComponent();

            _mapControl = new MapControl(client);
            _mapControl.Dock = DockStyle.Fill;

            tab_map.Controls.Add(_mapControl);

            rtb_chat.TabStop = false;
            rtb_chat.ReadOnly = true;
            rtb_chat.TextChanged += Rtb_chat_TextChanged;
            combobox_chat.SelectedIndex = 0;

            btn_send.Click += Btn_send_Click;
            textbox_chat.PreviewKeyDown += Textbox_chat_PreviewKeyDown;

            _client = client;

            _client.Account.Character.Loaded += Character_Loaded;
            _client.Account.Character.Inventory.InventoryChanged += Inventory_InventoryChanged;
            _client.Account.Character.Characteristic.Updated += Characteristic_Updated;
            _client.Account.Character.Characteristic.LifeUpdated += Characteristic_LifeUpdated;
            _client.Account.Character.Map.Changed += Map_Changed;
            _client.Account.Character.StateChanged += Character_StateChanged;
        }

        #region Interface handler

        private void Textbox_chat_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btn_send_Click(sender, EventArgs.Empty);
                textbox_chat.Clear();
            }
        }

        private void Btn_send_Click(object sender, EventArgs e)
        {
            if (textbox_chat.Text.Trim() == string.Empty)
                return;

            LogType channel;
            switch (combobox_chat.SelectedIndex)
            {
                case 0:
                    channel = LogType.Common;
                    break;
                case 1:
                    channel = LogType.Team;
                    break;
                case 2:
                    channel = LogType.Party;
                    break;
                case 3:
                    channel = LogType.Guild;
                    break;
                case 4:
                    channel = LogType.Recruit;
                    break;
                case 5:
                    channel = LogType.Trade;
                    break;
                default:
                    channel = LogType.Guild;
                    break;
            }

            _client.Network.Send(new ClientChatMessage(channel, textbox_chat.Text, ""));
            textbox_chat.Text = string.Empty;
        }

        private void Rtb_chat_Enter(object sender, EventArgs e)
        {
            label_kamas.Focus();
        }

        private void Rtb_chat_TextChanged(object sender, EventArgs e)
        {
            rtb_chat.SelectionStart = rtb_chat.Text.Length;
            // scroll it automatically
            rtb_chat.ScrollToCaret();
        }

        private void rtb_chat_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        #endregion

        #region Handler

        private void Character_Loaded(object sender, Game.Entity.Character.CharacterLoadedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                progress_level.Value = e.Character.Level;
                progress_level.CustomText = e.Character.Level.ToString();
            });
        }

        private void Characteristic_Updated(object sender, Game.Entity.Characteristic.CharacteristicsUpdatedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                // Experience
                int percentage = ((e.Characteristic.CurrentExperience - e.Characteristic.StartExperience) / (e.Characteristic.EndExperience - e.Characteristic.StartExperience)) * 100;
                progress_level.Value = percentage;
                // Life
                progress_life.Minimum = 0;
                progress_life.Maximum = e.Characteristic.MaximumLife;
                progress_life.Value = e.Characteristic.CurrentLife;
                progress_life.CustomText = $"{e.Characteristic.CurrentLife}/{e.Characteristic.MaximumLife}";
                // Energy
                progress_energy.Minimum = 0;
                progress_energy.Maximum = e.Characteristic.MaximumEnergy;
                progress_energy.Value = e.Characteristic.CurrentEnergy;
                progress_energy.CustomText = $"{e.Characteristic.CurrentEnergy}/{e.Characteristic.MaximumEnergy}";
            });
        }

        private void Inventory_InventoryChanged(object sender, EventArgs e)
        {
            Inventory inventory = (Inventory)sender;
            this.Invoke((MethodInvoker)delegate
            {
                label_kamas.Text = inventory.Kamas.ToString();

                progress_pods.Minimum = 0;
                progress_pods.Maximum = inventory.MaximumPods;
                progress_pods.Value = inventory.CurrentPods;
                progress_pods.CustomText = $"{inventory.CurrentPods}/{inventory.MaximumPods}";
            });
        }

        private void Characteristic_LifeUpdated(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                progress_life.Value = _client.Account.Character.Characteristic.CurrentLife;
                progress_life.CustomText = $"{_client.Account.Character.Characteristic.CurrentLife}/{_client.Account.Character.Characteristic.MaximumLife}";
            });
        }

        private void Map_Changed(object sender, Game.World.Map.UpdatedMapEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                label_position.Text = e.Map.Coordinates;
            });
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

        #endregion
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

    internal class DotNetBarTabControl : TabControl
    {
        public DotNetBarTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            ItemSize = new Size(36, 36); // Largeur ajustée pour les onglets
            Alignment = TabAlignment.Left;
            SelectedIndex = 0;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            foreach (TabPage page in TabPages)
            {
                page.BackColor = Color.FromArgb(60, 63, 65); // Définir la couleur de fond pour chaque page
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);

            g.Clear(Color.FromArgb(60, 63, 65)); // Couleur de fond du contrôle

            for (int i = 0; i < TabCount; i++)
            {
                Rectangle tabRect = GetTabRect(i);
                GraphicsPath path = CreateRoundedPath(tabRect, 4);

                // Fond de l'onglet
                //Brush brush = new SolidBrush(Color.FromArgb(60, 63, 65));
                //g.FillPath(brush, path);
                // Choisir la couleur de fond de l'onglet
                Color tabColor = i == SelectedIndex ? Color.FromArgb(60, 63, 65) : Color.FromArgb(50, 53, 55); // Plus sombre pour les onglets non sélectionnés

                using (SolidBrush brush = new SolidBrush(tabColor))
                {
                    g.FillRectangle(brush, tabRect);
                }

                // Dessiner l'effet d'ombre
                DrawTabShadow(g, tabRect);

                // Dessiner l'icône
                if (ImageList != null && TabPages[i].ImageIndex >= 0)
                {
                    Image icon = ImageList.Images[TabPages[i].ImageIndex];
                    Point iconLocation = new Point(tabRect.X + (tabRect.Width - ImageList.ImageSize.Width) / 2, tabRect.Y + (tabRect.Height - ImageList.ImageSize.Height) / 2);
                    g.DrawImage(icon, iconLocation);
                }
            }

            // Dessiner la bordure autour des pages
            using (Pen borderPen = new Pen(Color.FromArgb(80, 80, 80), 1)) // Couleur et épaisseur de la bordure
            {
                g.DrawRectangle(borderPen, 38, 0, Width - 40, Height - 1); // Ignorer le bord gauche
            }

            e.Graphics.DrawImage(b, 0, 0);
            g.Dispose();
            b.Dispose();
        }

        private void DrawTabShadow(Graphics g, Rectangle tabRect)
        {
            int shadowSize = 2; // Taille de l'ombre
            int radius = 2; // Rayon des coins arrondis

            // Ombre sur le bord gauche avec coins arrondis
            Rectangle leftShadowRect = new Rectangle(tabRect.Left, tabRect.Top + radius, shadowSize, tabRect.Height - 2 * radius);
            GraphicsPath leftShadowPath = CreateRoundedRectPath(leftShadowRect, radius, roundedCorners: RoundedCorners.TopLeft | RoundedCorners.BottomLeft);
            using (LinearGradientBrush leftShadowBrush = new LinearGradientBrush(leftShadowRect, Color.FromArgb(50, 0, 0, 0), Color.Transparent, LinearGradientMode.Horizontal))
            {
                g.FillPath(leftShadowBrush, leftShadowPath);
            }

            // Ombre sur le bord inférieur
            Rectangle bottomShadowRect = new Rectangle(tabRect.Left + radius, tabRect.Bottom - shadowSize, tabRect.Width - 2 * radius, shadowSize);
            using (LinearGradientBrush bottomShadowBrush = new LinearGradientBrush(bottomShadowRect, Color.FromArgb(50, 0, 0, 0), Color.Transparent, LinearGradientMode.Vertical))
            {
                g.FillRectangle(bottomShadowBrush, bottomShadowRect);
            }
        }

        private GraphicsPath CreateRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            // Ajouter les arcs pour les coins arrondis
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Coin supérieur gauche
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90); // Coin supérieur droit
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90); // Coin inférieur droit
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90); // Coin inférieur gauche

            path.CloseFigure(); // Ferme le chemin en connectant le point final au point de départ
            return path;
        }

        private GraphicsPath CreateRoundedRectPath(Rectangle rect, int radius, RoundedCorners roundedCorners)
        {
            GraphicsPath path = new GraphicsPath();

            if (roundedCorners.HasFlag(RoundedCorners.TopLeft))
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            }
            else
            {
                path.AddLine(rect.X, rect.Y, rect.X, rect.Y);
            }

            if (roundedCorners.HasFlag(RoundedCorners.TopRight))
            {
                path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            }
            else
            {
                path.AddLine(rect.Right, rect.Y, rect.Right, rect.Y);
            }

            if (roundedCorners.HasFlag(RoundedCorners.BottomRight))
            {
                path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            }
            else
            {
                path.AddLine(rect.Right, rect.Bottom, rect.Right, rect.Bottom);
            }

            if (roundedCorners.HasFlag(RoundedCorners.BottomLeft))
            {
                path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            }
            else
            {
                path.AddLine(rect.X, rect.Bottom, rect.X, rect.Bottom);
            }

            path.CloseFigure();
            return path;
        }

        [Flags]
        public enum RoundedCorners
        {
            None = 0,
            TopLeft = 1,
            TopRight = 2,
            BottomRight = 4,
            BottomLeft = 8,
            All = TopLeft | TopRight | BottomRight | BottomLeft
        }
    }
}
