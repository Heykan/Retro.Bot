﻿using Retro.Bot.Game.World.Interactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Retro.Bot.Game.World
{
    public class Cell
    {
        public short Id { get; private set; }
        public bool IsActive { get; private set; }
        public CellType Type { get; private set; }
        public bool IsLineOfSight { get; private set; } = false;
        public byte GroundLevel { get; private set; }
        public byte GroundSlope { get; private set; }
        public short LayerObject1Num { get; private set; }
        public short LayerObject2Num { get; private set; }
        public InteractiveObject InteractiveObject { get; private set; }
        public int X { get; private set; } = 0;
        public int Y { get; private set; } = 0;

        public byte MapWidth { get; private set; } = 0;
        public Map Map { get; private set; }

        public static readonly int[] TeleportTextures = { 1030, 1029, 4088 };

        public Cell(short id, bool isActive, CellType type, bool isLineOfSight, byte groundLevel, byte groundSlope, short interactiveObjectId, short layerObject1Num, short layerObject2Num, Map map)
        {
            Map = map;
            Id = id;
            IsActive = isActive;
            Type = type;

            LayerObject1Num = layerObject1Num;
            LayerObject2Num = layerObject2Num;

            IsLineOfSight = isLineOfSight;
            GroundLevel = groundLevel;
            GroundSlope = groundSlope;

            if (interactiveObjectId != -1)
            {
                InteractiveObject = new InteractiveObject(interactiveObjectId, this);
                map.Interactives.TryAdd(id, InteractiveObject);
            }

            MapWidth = map.Width;
            int _loc5 = id / ((MapWidth * 2) - 1);
            int _loc6 = id - (_loc5 * ((MapWidth * 2) - 1));
            int _loc7 = _loc6 % MapWidth;
            Y = _loc5 - _loc7;
            X = (id - ((MapWidth - 1) * Y)) / MapWidth;

            int cellid = 0;
            for (int y = 0; y <= (2 * map.Height) - 1; ++y)
            {
                if ((y % 2) == 0)
                {
                    for (int x = 0; x <= MapWidth - 1; x++)
                    {
                        if (id == cellid)
                        {
                            X = x;
                            Y = y;
                            return;
                        }
                        cellid++;
                    }
                }
                else
                {
                    for (int x = 0; x <= MapWidth - 2; x++)
                    {
                        if (id == cellid)
                        {
                            X = x;
                            Y = y;
                            return;
                        }
                        cellid++;
                    }
                }
            }
        }

        public int GetDistance(Cell destination) => Math.Abs(X - destination.X) + Math.Abs(Y - destination.Y);
        public bool IsInLine(Cell destination) => X == destination.X || Y == destination.Y;

        public char GetDirection(Cell cell)
        {
            /** Diagonals **/
            if (X == cell.X)
                return cell.Y < Y ? (char)(3 + 'a') : (char)(7 + 'a');
            else if (Y == cell.Y)
                return cell.X < X ? (char)(1 + 'a') : (char)(5 + 'a');

            /** Lineals **/
            else if (X > cell.X)
                return Y > cell.Y ? (char)(2 + 'a') : (char)(0 + 'a');
            else if (X < cell.X)
                return Y < cell.Y ? (char)(6 + 'a') : (char)(4 + 'a');

            throw new Exception("Error: Direction not found.");
        }

        public bool IsTeleport() => TeleportTextures.Contains(LayerObject1Num) || TeleportTextures.Contains(LayerObject2Num);
        public bool IsInteractive() => Type == CellType.InteractiveObject || InteractiveObject != null;
        public bool IsWalkable() => IsActive && Type != CellType.NotWalkable && !IsWalkableInteractive();
        public bool IsWalkableInteractive() => Type == CellType.InteractiveObject || InteractiveObject != null && InteractiveObject.Model != null && !InteractiveObject.Model.IsWalkable;

    }
}
