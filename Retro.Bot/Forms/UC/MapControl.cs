using Retro.Bot.Game.World;
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
    public partial class MapControl : UserControl
    {
        private Core.Client _client;
        private Map _currentMap;
        private List<(Rectangle rect, Cell cell)> rectangles = new List<(Rectangle rect, Cell cell)> ();

        public MapControl(Core.Client client)
        {
            DoubleBuffered = true;
            _client = client;

            client.Account.Character.Map.Changed += Map_Changed;
            client.Account.Character.Map.Updated += Map_Changed;
        }

        private void Map_Changed(object sender, Map.UpdatedMapEventArgs e)
        {
            _currentMap = e.Map;
            Invalidate();
        }

        private void DrawnRect(Cell cell, int xPos, int yPos, int TileWidth, int TileHeight, Graphics g)
        {
            Brush color = Brushes.White;
            if (cell == null) return;

            if (_client.Account.Character.Cell != null && cell.Id == _client.Account.Character.Cell.Id)
            {
                color = Brushes.Blue;
            }
            else if (cell.IsTeleport())
            {
                color = Brushes.Yellow;
            }
            else if (_currentMap.GetMonsters().FirstOrDefault(mob => mob.Cell.Id == cell.Id) != null)
            {
                color = Brushes.Red;
            }
            else if (_currentMap.GetCharacters().FirstOrDefault(character => character.Cell.Id == cell.Id) != null)
            {
                color = Brushes.Teal;
            }
            else if (_currentMap.GetInteractive(cell.Id) != null)
            {
                color = _currentMap.GetInteractive(cell.Id).IsUsable ? Brushes.Green : Brushes.Brown;
            }
            else if (!cell.IsWalkable())
            {
                color = Brushes.Black;
            }


            Rectangle tileRect = new Rectangle(xPos, yPos, TileWidth, TileHeight);
            rectangles.Add((tileRect, cell));
            PointF rotationPoint = new PointF(tileRect.Left + tileRect.Width / 2, tileRect.Top + tileRect.Height / 2);
            g.TranslateTransform(rotationPoint.X, rotationPoint.Y);
            g.RotateTransform(45);
            g.TranslateTransform(-rotationPoint.X, -rotationPoint.Y);

            g.FillRectangle(color, tileRect);
            g.DrawRectangle(Pens.Black, tileRect);

            g.ResetTransform();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_currentMap == null)
                return;
            Graphics g = e.Graphics;

            int mapHeight = (_currentMap.Height - 1) * 2;
            int mapWidth = (_currentMap.Width - 1);

            int TileWidth = (Width - 10) / mapWidth;
            int TileHeight = (Height - 10) / mapHeight;

            TileWidth = TileWidth > TileHeight ? TileHeight : TileWidth;
            TileHeight = TileHeight > TileWidth ? TileWidth : TileHeight;

            int cellid = 0;


            for (int y = 0; y <= (2 * _currentMap.Height) - 1; ++y)
            {
                if ((y % 2) == 0)
                {
                    for (int x = 0; x <= _currentMap.Width - 1; x++)
                    {
                        int xPos = (int)Math.Round(x * TileWidth * Math.Sqrt(2) + 10);
                        int yPos = (int)Math.Round(y * TileHeight * Math.Sqrt(2) / 2 + 10);
                        if (cellid >= _currentMap.Cells.Length) break;
                        DrawnRect(_currentMap.Cells[cellid], xPos, yPos, TileWidth, TileHeight, g);
                        cellid++;
                    }
                }
                else
                {
                    for (int x = 0; x <= _currentMap.Width - 2; x++)
                    {
                        int xPos = (int)Math.Round(x * TileWidth * Math.Sqrt(2) + 10);
                        int yPos = (int)Math.Round(y * TileHeight * Math.Sqrt(2) / 2 + 10);
                        xPos += (int)Math.Round(TileHeight * Math.Sqrt(2) / 2);
                        if (cellid >= _currentMap.Cells.Length) break;
                        DrawnRect(_currentMap.Cells[cellid], xPos, yPos, TileWidth, TileHeight, g);
                        cellid++;
                    }
                }
            }
        }
    }
}
