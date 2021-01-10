using System;
using System.Collections.Generic;

namespace KH2FM_Editor.DataDictionary
{
    public class ItemData
    {
        // 2 Bytes
        public static Dictionary<ushort, String> categories = new Dictionary<ushort, string>() {
{ 0 , "Consumable (Equippable)" },
{ 1 , "Consumable (Menu)" },
{ 2 , "Keyblade" },
{ 3 , "Staff" },
{ 4 , "Shield" },
{ 5 , "Aladdin weapon" },
{ 6 , "Auron weapon" },
{ 7 , "Beast weapon" },
{ 8 , "Jack weapon" },
{ 9 , "Ping / Mulan weapon" },
{ 10 , "Riku weapon" },
{ 11 , "Simba weapon" },
{ 12 , "Sparrow weapon" },
{ 13 , "Tron weapon" },
{ 14 , "Armor" },
{ 15 , "Accessory" },
{ 16 , "Synthesis" },
{ 17 , "Moguri Recipe" },
{ 18 , "Magic" },
{ 19 , "Ability" },
{ 20 , "Summon" },
{ 21 , "Form" },
{ 22 , "Map" },
{ 23 , "Report" }
        };

        public static String getCategory(ushort id)
        {
            if (categories.ContainsKey(id)) return categories[id];
            return "";
        }

        public static Dictionary<byte, string> prizeBoxes = new Dictionary<byte, string>() {
{ 0 , "Red S" },
{ 1 , "Red L" },
{ 2 , "Red XL" },
{ 3 , "Blue S" },
{ 4 , "Blue L" },
{ 5 , "Blue XL" },
{ 6 , "Horned S" },
{ 7 , "Horned L" },
{ 8 , "Horned XL" },
{ 9 , "Purple S" },
{ 10 , "Purple L" },
{ 11 , "Purple XL" }
        };

        public static String getPrizeBox(byte id)
        {
            if (prizeBoxes.ContainsKey(id)) return prizeBoxes[id];
            return "";
        }

        public static Dictionary<byte, string> icons = new Dictionary<byte, string>() {
{ 0 , "Consumable (Equippable)" },
{ 1 , "Consumable (Menu)" },
{ 2 , "Document" },
{ 3 , "Ability" },
{ 4 , "Keyblade" },
{ 5 , "Staff" },
{ 6 , "Shield" },
{ 7 , "Armor" },
{ 8 , "Magic" },
{ 9 , "Synthesis" },
{ 10 , "Purple L" },
{ 11 , "Purple XL" }
        };

        public static String getIcon(byte id)
        {
            if (icons.ContainsKey(id)) return icons[id];
            return "";
        }

        public static Dictionary<byte, string> visibilities = new Dictionary<byte, string>() {
{ 0 , "Stock" },
{ 1 , "No Stock" },
{ 2 , "Stock (Team)" }
        };

        public static String getVisibility(byte id)
        {
            if (visibilities.ContainsKey(id)) return visibilities[id];
            return "";
        }
    }
}
