using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retro.Bot.Protocol.Types.Inventory
{
    public static class InventoryUtils
    {
        private static Dictionary<int, List<InventoryPosition>> possiblePositions = new Dictionary<int, List<InventoryPosition>>()
        {
            { 1,  new List<InventoryPosition>() { InventoryPosition.AMULET } },
            { 2,  new List<InventoryPosition>() { InventoryPosition.WEAPON } },
            { 3,  new List<InventoryPosition>() { InventoryPosition.WEAPON } },
            { 4,  new List<InventoryPosition>() { InventoryPosition.WEAPON } },
            { 5,  new List<InventoryPosition>() { InventoryPosition.WEAPON } },
            { 6,  new List<InventoryPosition>() { InventoryPosition.WEAPON } },
            { 7,  new List<InventoryPosition>() { InventoryPosition.WEAPON } },
            { 8,  new List<InventoryPosition>() { InventoryPosition.WEAPON } },
            { 9,  new List<InventoryPosition>() { InventoryPosition.LEFT_RING, InventoryPosition.RIGHT_RING } },
            { 10, new List<InventoryPosition>() { InventoryPosition.BELT } },
            { 11, new List<InventoryPosition>() { InventoryPosition.BOOTS } },
            { 16, new List<InventoryPosition>() { InventoryPosition.HAT } },
            { 17, new List<InventoryPosition>() { InventoryPosition.CAPE } },
            { 18, new List<InventoryPosition>() { InventoryPosition.PET } },
            { 19, new List<InventoryPosition>() { InventoryPosition.WEAPON } }, //axe
            { 20, new List<InventoryPosition>() { InventoryPosition.WEAPON } }, //tool
            { 21, new List<InventoryPosition>() { InventoryPosition.WEAPON } }, //pickaxe
            { 22, new List<InventoryPosition>() { InventoryPosition.WEAPON } }, //scythe
            { 23, new List<InventoryPosition>() { InventoryPosition.DOFUS1, InventoryPosition.DOFUS2, InventoryPosition.DOFUS3, InventoryPosition.DOFUS4, InventoryPosition.DOFUS5, InventoryPosition.DOFUS6 } },
            { 82, new List<InventoryPosition>() { InventoryPosition.SHIELD } },
            { 83, new List<InventoryPosition>() { InventoryPosition.WEAPON } }, //soul stone
        };

        public static List<InventoryPosition> GetPossiblePositions(int objectType) => possiblePositions.ContainsKey(objectType) ? possiblePositions[objectType] : null;

        public static InventoryItemType GetInventoryItemsType(byte type)
        {
            switch (type)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 83:
                    return InventoryItemType.EQUIPMENT;

                case 12:
                case 13:
                case 85:
                case 86:
                    return InventoryItemType.DIVERSE;

                case 15:
                case 33:
                case 34:
                case 35:
                case 36:
                case 38:
                case 41:
                case 46:
                case 47:
                case 48:
                case 50:
                case 51:
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:
                case 58:
                case 59:
                case 60:
                case 65:
                case 68:
                case 84:
                case 96:
                case 98:
                case 100:
                case 103:
                case 104:
                case 105:
                case 106:
                case 107:
                case 108:
                case 109:
                case 111:
                    return InventoryItemType.RESOURCES;

                case 24:
                    return InventoryItemType.USABLE;

                default:
                    return InventoryItemType.UNKNOWN;
            }
        }
    }
}
