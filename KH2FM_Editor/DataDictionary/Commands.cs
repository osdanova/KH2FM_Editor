using System;
using System.Collections.Generic;

namespace KH2FM_Editor_WPF.Data
{
    class Commands
    {
        public static Dictionary<ushort, String> valuesDic = new Dictionary<ushort, string>() {
{ 26 , "Hi-Potion" },
{ 27 , "Ether" },
{ 28 , "Elixir" },
{ 29 , "Potion" },
{ 138 , "Fira" },
{ 139 , "Firaga" },
{ 140 , "Blizzara" },
{ 142 , "Thundara" },
{ 143 , "Thundaga" },
{ 145 , "Cura" },
{ 196 , "Magnet" },
{ 198 , "Magnega" },
{ 200 , "Reflera" },
{ 201 , "Reflega" },
{ 242 , "Mega-Potion" },
{ 243 , "Mega-Ether" },
{ 244 , "Megaelixir" }
        };

        public static String getName(ushort id)
        {
            if (valuesDic.ContainsKey(id)) return valuesDic[id];
            return "";
        }
    }
}
