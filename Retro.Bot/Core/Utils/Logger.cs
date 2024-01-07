using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Retro.Bot.Core.Utils
{
    public class Logger
    {
        private RichTextBox _richTextBox;

        public Logger(RichTextBox rtb)
        {
            _richTextBox = rtb;
        }

        public void Append(string message, LogType type = LogType.Log)
        {
            if (_richTextBox == null)
                return;

            // S'assurer que la modification de la RichTextBox se fait dans le thread UI
            if (_richTextBox.InvokeRequired)
            {
                _richTextBox.Invoke(new Action(() => Append(message, type)));
                return;
            }

            Color color = Color.Green;
            switch (type)
            {
                case LogType.Common:
                    color = Color.Green;
                    break;
                case LogType.Error:
                    color = Color.Red;
                    break;
                case LogType.Event:
                    color = Color.LightPink;
                    break;
                case LogType.Party:
                    color = Color.DarkBlue;
                    break;
                case LogType.Guild:
                    color = Color.Purple;
                    break;
                case LogType.Information:
                    color = Color.DarkGreen;
                    break;
                case LogType.Log:
                    color = Color.Green;
                    break;
                case LogType.Private:
                    color = Color.AliceBlue;
                    break;
                case LogType.Recruit:
                    color = Color.Gray;
                    break;
                case LogType.Trade:
                    color = Color.SandyBrown;
                    break;
                case LogType.Warning:
                    color = Color.Orange;
                    break;
                case LogType.Team:
                    color = Color.CornflowerBlue;
                    break;
                default:
                    color = Color.Green;
                    break;
            }

            // Sauvegarder la position actuelle du curseur et la couleur du texte
            int cursorPosition = _richTextBox.SelectionStart;
            int length = _richTextBox.TextLength;
            _richTextBox.SelectionStart = length;
            _richTextBox.SelectionLength = 0;

            // Ajouter le message avec la couleur spécifiée
            _richTextBox.SelectionColor = color;
            _richTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] ");

            // Appliquer le formatage en gras pour les mots encadrés par \b et \b0
            ApplyBoldFormatting(message);

            // Restaurer la position du curseur et la couleur du texte
            _richTextBox.SelectionStart = cursorPosition;
            _richTextBox.SelectionLength = 0;
            _richTextBox.SelectionColor = _richTextBox.ForeColor;
        }

        private void ApplyBoldFormatting(string message)
        {
            string pattern = @"\[bold\](.*?)\[/bold\]";
            var matches = Regex.Matches(message, pattern);
            int lastPos = 0;

            foreach (Match match in matches)
            {
                // Ajouter le texte avant le gras
                string beforeBold = message.Substring(lastPos, match.Index - lastPos);
                _richTextBox.AppendText(beforeBold);

                // Ajouter le texte en gras
                string boldText = match.Groups[1].Value;
                int startIndex = _richTextBox.TextLength;
                _richTextBox.AppendText(boldText);
                _richTextBox.Select(startIndex, boldText.Length);
                _richTextBox.SelectionFont = new Font(_richTextBox.Font, FontStyle.Bold);

                lastPos = match.Index + match.Length;
            }

            // Ajouter le reste du message
            _richTextBox.SelectionFont = new Font(_richTextBox.Font, FontStyle.Regular);
            _richTextBox.AppendText(message.Substring(lastPos) + "\n");
        }
    }

    public enum LogType
    {
        Log,
        Error,
        Information,
        Warning,
        Private,
        Common,
        Trade,
        Recruit,
        Guild,
        Event,
        Party,
        Team,
    }
}
