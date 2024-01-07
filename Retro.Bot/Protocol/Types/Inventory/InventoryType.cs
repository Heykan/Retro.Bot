using Retro.Bot.Game.Inventory;
using Retro.Bot.IO;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro.Bot.Protocol.Types.Inventory
{
    public class InventoryType
    {
        public ConcurrentDictionary<uint, ItemType> Items { get; set; }

        public InventoryType() 
        {
            Items = new ConcurrentDictionary<uint, ItemType>();
        }

        public void Serialize(PacketWriter writer)
        {

        }

        public void Deserialize(PacketReader reader) 
        {
            foreach(var item in reader.PipeDelimiter[9].Split(';'))
            {
                if (!string.IsNullOrEmpty(item))
                {
                    string[] separator = item.Split('~');
                    uint inventoryId = Convert.ToUInt32(separator[0], 16);
                    try
                    {
                        ItemType newItem = new ItemType(item);
                        //ChangeIndexToList(newItem, +1);
                        Items.TryAdd(inventoryId, newItem);
                    }
                    catch (Exception)
                    {
                    }

                }
            }
        }
    }

    public enum InventoryItemType
    {
        EQUIPMENT,
        RESOURCES,
        DIVERSE,
        USABLE,
        UNKNOWN
    }
}
