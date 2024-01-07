using Retro.Bot.Core;
using Retro.Bot.Protocol.Messages.Game.Entity;
using Retro.Bot.Protocol.Messages.Game.Inventory;
using Retro.Bot.Protocol.Types.Entity;
using Retro.Bot.Protocol.Types.Inventory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Retro.Bot.Game.Entity.Character;
using System.Xml.Linq;

namespace Retro.Bot.Game.Inventory
{
    public class Inventory
    {
        public long Kamas { get; private set; }
        public short CurrentPods { get; set; }
        public short MaximumPods { get; set; }
        public int PodsPercentage => (int)((double)CurrentPods / MaximumPods * 100);

        public IEnumerable<ItemType> Items { get; private set; }
        public IEnumerable<ItemType> Equipment => Items.Where(o => o.InventoryType == InventoryItemType.EQUIPMENT);
        public IEnumerable<ItemType> Miscellaneous => Items.Where(o => o.InventoryType == InventoryItemType.DIVERSE);
        public IEnumerable<ItemType> Resources => Items.Where(o => o.InventoryType == InventoryItemType.RESOURCES);
        public IEnumerable<ItemType> QuestItems => Items.Where(o => o.InventoryType == InventoryItemType.USABLE);

        public Inventory(Core.Client client) 
        {
            Items = new List<ItemType>();

            client.Network.RegisterMessage<InventoryWeightMessage>(OnInventoryWeightMessage, Core.MessagePriority.Normal);
            client.Network.RegisterMessage<CharacteristicDataMessage>(OnCharacteristicDataMessage, Core.MessagePriority.Normal);
            client.Network.RegisterMessage<CharacterSelectedMessage>(OnCharacterSelectedMessage, MessagePriority.High);
        }

        public void OnCharacterSelectedMessage(Core.Client client, CharacterSelectedMessage message)
        {
            Items = message.Character.Inventory.Items.Values;
        }

        private void OnCharacteristicDataMessage(Client client, CharacteristicDataMessage message)
        {
            Kamas = message.Kamas;

            if (InventoryChanged != null)
                InventoryChanged(this, EventArgs.Empty);
        }

        private void OnInventoryWeightMessage(Client client, InventoryWeightMessage message)
        {
            CurrentPods = message.CurrentPods;
            MaximumPods = message.MaximumPods;

            if (InventoryChanged != null)
                InventoryChanged(this, EventArgs.Empty);
        }

        #region Event

        public event EventHandler InventoryChanged;

        #endregion
    }
}
