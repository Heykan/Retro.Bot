using Newtonsoft.Json;
using Retro.Bot.Core;
using Retro.Bot.Core.Utils.Cryptography;
using Retro.Bot.Game.Entity;
using Retro.Bot.Game.World.Interactive;
using Retro.Bot.Protocol.Messages.Game.World.Map;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Game.World
{
    public class Map
    {
        private Core.Client _client;

        public short Id { get; set; }
        public byte Width { get; set; }
        public byte Height { get; set; }
        public sbyte X { get; set; }
        public sbyte Y { get; set; }
        public bool IsMapLoaded { get; private set; }
        public Cell[] Cells { get; set; }
        public string Coordinates => $"[{X}:{Y}]";

        public ConcurrentDictionary<int, IEntity> Entities;
        public ConcurrentDictionary<int, InteractiveObject> Interactives;

        public static async Task WaitMapLoad(Map map, Account account)
        {
            if (account == null)
                return;
            while (!map.IsMapLoaded || account == null || account.Character == null || account.Character.Map == null)
            {
                await Task.Delay(100);
            }
        }

        public Map(Core.Client client)
        {
            _client = client;
            Entities = new ConcurrentDictionary<int, IEntity>();
            Interactives = new ConcurrentDictionary<int, InteractiveObject>();

            client.Network.RegisterMessage<GameMapDataMessage>(OnGameMapDataMessage, Core.MessagePriority.High);
            client.Network.RegisterMessage<GameMapMessage>(OnGameMapMesage, MessagePriority.High);
        }

        #region Public methods

        public Cell GetCellById(short cellId)
        {
            if (_client.Account != null)
                WaitMapLoad(this, _client.Account).Wait();
            return Cells[cellId];
        }
        public bool IsOnMap(string coordinates) => coordinates == Id.ToString() || coordinates == Coordinates;
        public bool IsOnMap(short id) => Id == id;
        public Cell GetCellByCoordinates(int x, int y) => Cells.FirstOrDefault(cell => cell.X == x && cell.Y == y);
        public bool CanFightMonsterGroup(int minMonsters, int maxMonsters, int minLevel, int maxLevel, List<int> prohibitedMonsters, List<int> requiredMonsters) => GetMonsterGroups(minMonsters, maxMonsters, minLevel, maxLevel, prohibitedMonsters, requiredMonsters).Count > 0;
        public List<Cell> OccupiedCells() => Entities.Values.Select(e => e.Cell).Where(c => !c.IsTeleport()).ToList();
        public List<Npc> GetNpcs() => Entities.Values.Where(e => e is Npc).Select(e => e as Npc).ToList();
        public List<Monster> GetMonsters() => Entities.Values.Where(e => e is Monster).Select(e => e as Monster).ToList();
        public List<Character> GetCharacters() => Entities.Values.Where(e => e is Character).Select(e => e as Character).ToList();
        public List<Merchant> GetMerchants() => Entities.Values.Where(e => e is Merchant).Select(e => e as Merchant).ToList();

        public List<Monster> GetMonsterGroups(int minMonsters, int maxMonsters, int minLevel, int maxLevel, List<int> prohibitedMonsters, List<int> requiredMonsters)
        {
            List<Monster> availableMonsterGroups = new List<Monster>();

            foreach (Monster monsterGroup in GetMonsters())
            {
                if (monsterGroup.TotalMonsters < minMonsters || monsterGroup.TotalMonsters > maxMonsters)
                    continue;

                if (monsterGroup.TotalGroupLevel < minLevel || monsterGroup.TotalGroupLevel > maxLevel)
                    continue;

                if (monsterGroup.Cell.IsTeleport())
                    continue;

                bool isValid = true;

                if (prohibitedMonsters != null)
                {
                    for (int i = 0; i < prohibitedMonsters.Count; i++)
                    {
                        if (monsterGroup.ContainsMonster(prohibitedMonsters[i]))
                        {
                            isValid = false;
                            break;
                        }
                    }
                }

                if (requiredMonsters != null && isValid)
                {
                    for (int i = 0; i < requiredMonsters.Count; i++)
                    {
                        if (!monsterGroup.ContainsMonster(requiredMonsters[i]))
                        {
                            isValid = false;
                            break;
                        }
                    }
                }

                if (isValid)
                    availableMonsterGroups.Add(monsterGroup);
            }
            return availableMonsterGroups;
        }

        public InteractiveObject GetInteractive(int cellId)
        {
            if (Interactives.TryGetValue(cellId, out InteractiveObject interactive))
                return interactive;

            return null;
        }

        #endregion

        #region Private methods

        public void DecompressMap(string mapData)
        {
            Cells = new Cell[mapData.Length / 10];
            string cellValues;

            for (int i = 0; i < mapData.Length; i += 10)
            {
                cellValues = mapData.Substring(i, 10);
                Cells[i / 10] = DecompressCell(cellValues, Convert.ToInt16(i / 10));
            }
        }

        public Cell DecompressCell(string cellData, short cellId)
        {
            byte[] cellInformation = new byte[cellData.Length];

            for (int i = 0; i < cellData.Length; i++)
                cellInformation[i] = Convert.ToByte(Hash.GetHash(cellData[i]));

            CellType type = (CellType)((cellInformation[2] & 56) >> 3);
            bool isActive = (cellInformation[0] & 32) >> 5 != 0;
            bool isLineOfSight = (cellInformation[0] & 1) != 1;
            bool hasInteractiveObject = ((cellInformation[7] & 2) >> 1) != 0;
            short layerObject2Num = Convert.ToInt16(((cellInformation[0] & 2) << 12) + ((cellInformation[7] & 1) << 12) + (cellInformation[8] << 6) + cellInformation[9]);
            short layerObject1Num = Convert.ToInt16(((cellInformation[0] & 4) << 11) + ((cellInformation[4] & 1) << 12) + (cellInformation[5] << 6) + cellInformation[6]);
            byte level = Convert.ToByte(cellInformation[1] & 15);
            byte slope = Convert.ToByte((cellInformation[4] & 60) >> 2);

            return new Cell(cellId, isActive, type, isLineOfSight, level, slope, hasInteractiveObject ? layerObject2Num : Convert.ToInt16(-1), layerObject1Num, layerObject2Num, this);
        }

        #endregion

        #region Handler

        private async void OnGameMapMesage(Client client, GameMapMessage message)
        {
            await WaitMapLoad(this, client.Account);
            string templateName, type;
            int id;

            foreach (string player in message.Players)
            {
                string[] informations;

                if (player.Length < 1)
                    continue;

                informations = player.Substring(1).Split(';');

                if (player[0].Equals('+'))
                {
                    if (informations.Length < 6)
                        continue;

                    Cell cell = GetCellById(short.Parse(informations[0]));
                    //FightExtension fight = account.Character.Fight;
                    id = int.Parse(informations[3]);
                    templateName = informations[4];
                    type = informations[5];
                    if (type.Contains(","))
                        type = type.Split(',')[0];

                    switch (int.Parse(type))
                    {
                        case -1: // Creature
                        case -2: // Monster
                            if (!client.Account.Character.IsFighting())
                                return;

                            int monsterLife = int.Parse(informations[12]);
                            byte monsterPA = byte.Parse(informations[13]);
                            byte monsterPM = byte.Parse(informations[14]);
                            byte monsterTeam;

                            if (informations.Length > 18)
                                monsterTeam = byte.Parse(informations[22]);
                            else
                                monsterTeam = byte.Parse(informations[15]);

                            //fight.AddFighter(new Fighter(id, true, monsterLife, monsterPA, monsterPM, cell, monsterLife, monsterTeam, 0, false));
                            break;

                        case -3: // Group of Monsters
                            string[] templates = templateName.Split(',');
                            string[] levels = informations[7].Split(',');

                            Monster monster = new Monster(id, int.Parse(templates[0]), cell, int.Parse(levels[0]));
                            monster.GroupLeader = monster;

                            for (int m = 1; m < templates.Length; ++m)
                                monster.MonstersInsideGroup.Add(new Monster(id, int.Parse(templates[m]), cell, int.Parse(levels[m])));

                            Entities.TryAdd(id, monster);
                            break;

                        case -4: // NPC's
                            Entities.TryAdd(id, new Npc(id, int.Parse(templateName), cell));
                            break;

                        case -5: // Merchants
                            Entities.TryAdd(id, new Merchant(id, cell));
                            break;

                        case -6: // Collectors
                            if (client.Account.Character.IsFighting())
                            {
                                byte collectorLife = byte.Parse(informations[9]);
                                byte collectorPA = byte.Parse(informations[9]);
                                byte collectorPM = byte.Parse(informations[10]);
                                byte collectorTeam = byte.Parse(informations[18]);

                                //fight.AddFighter(new Fighter(id, true, collectorLife, collectorPA, collectorPM, cell, collectorLife, collectorTeam, 0, false));
                            }
                            break;

                        case -7:
                        case -8:
                        case -9:
                        case -10:
                            break;

                        default: // Players
                            if (client.Account.Character.IsFighting())
                            {
                                int life = int.Parse(informations[14]);
                                byte pa = byte.Parse(informations[15]);
                                byte pm = byte.Parse(informations[16]);
                                byte team = byte.Parse(informations[24]);
                                //fight.AddFighter(new Fighter(id, true, life, pa, pm, cell, life, team, 0, false));
                            }
                            else
                            {
                                if (client.Account.Character.Id == id)
                                {
                                    client.Account.Character.Cell = cell;
                                    //account.Character.Restrictions.SetRestrictions(int.Parse(informations[18]));
                                }
                                else
                                    Entities.TryAdd(id, new Character(client, id, templateName, cell));//, byte.Parse(informations[7].ToString()), int.Parse(informations[18])));
                            }
                            break;
                    }
                }

                if (player[0].Equals('-'))
                {
                    if (!_client.Account.Character.IsFighting())
                    {
                        id = int.Parse(player.Substring(1));
                        Entities.TryRemove(id, out IEntity entity);
                        //map.GetUpdatedEntity();

                        //if (GlobalConf.ShowDebugMessages)
                        //    account.Logger.LogInformation("DEBUG", $"Entity {entity.Id} removed from cell {entity.Cell.Id}");
                    }
                }
            }

            if (Updated != null)
                Updated(this, new UpdatedMapEventArgs(this));
        }

        private void OnGameMapDataMessage(Client client, GameMapDataMessage message)
        {
            client.Account.Character.CharacterState = CharacterState.MAP_CHANGE;
            Entities.Clear();
            Interactives.Clear();

            Id = message.Id;

            FileInfo mapFile = new FileInfo($"maps/{Id}.json");
            if (!mapFile.Exists)
            {
                client.Logger.Append("Erreur lors du chargement de la map.", Core.Utils.LogType.Error);
                return;
            }

            string text = File.ReadAllText($"maps/{Id}.json");
            MapJson mapData = JsonConvert.DeserializeObject<MapJson>(text);

            Width = mapData.Width;
            Height = mapData.Height;
            X = mapData.X;
            Y = mapData.Y;

            DecompressMap(mapData.MapData);

            mapData = null;
            IsMapLoaded = true;

            if (Changed != null)
                Changed(this, new UpdatedMapEventArgs(this));
        }

        #endregion

        #region Events

        public event EventHandler<UpdatedMapEventArgs> Changed;
        public event EventHandler<UpdatedMapEventArgs> Updated;

        public class UpdatedMapEventArgs : EventArgs
        {
            public Map Map { get; private set; }

            public UpdatedMapEventArgs(Map map)
            {
                Map = map;
            }
        } 

        #endregion
    }

    [JsonObject]
    public class MapJson
    {
        [JsonProperty("id")]
        public short Id { get; set; }

        [JsonProperty("width")]
        public byte Width { get; set; }

        [JsonProperty("heigth")]
        public byte Height { get; set; }

        [JsonProperty("mapData")]
        public string MapData { get; set; } = string.Empty;

        [JsonProperty("X")]
        public sbyte X { get; set; }

        [JsonProperty("Y")]
        public sbyte Y { get; set; }

        public MapJson() { }
    }
}
