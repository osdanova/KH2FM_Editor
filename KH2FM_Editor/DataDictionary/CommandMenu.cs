using System;
using System.Collections.Generic;

namespace KH2FM_Editor_WPF.Data
{
    class CommandMenu
    {
        // Objentry file entries. 1 Byte
        public static Dictionary<byte, String> valuesDic = new Dictionary<byte, string>() {
{ 0 , "Sora / Roxas" },
{ 1 , "Valor" },
{ 2 , "Wisdom" },
{ 3 , "Limit" },
{ 4 , "Master" },
{ 5 , "Final" },
{ 6 , "Anti" },
{ 7 , "Lion" },
{ 8 , "No Magic, Drive, Party, Limit" },
{ 9 , "No Drive, Party, Limit" },
{ 10 , "No Magic, Drive, Party, Limit (V.2)" },
{ 11 , "Only attack and Summon" },
{ 24 , "Die / Card" }
        };

        public static String getName(byte id)
        {
            if (valuesDic.ContainsKey(id)) return valuesDic[id];
            return "";
        }
    }
}
