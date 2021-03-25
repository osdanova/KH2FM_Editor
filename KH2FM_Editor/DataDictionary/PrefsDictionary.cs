using System;
using System.Collections.Generic;

namespace KH2FM_Editor.DataDictionary
{
    public class PrefsDictionary
    {
        // 2 Bytes
        // Not included: Summons, Skate, Sora Card, Ride the Wind, 100 Acree Wood cave, partners, Setup (Tron's limit)
        public static Dictionary<int, String> prtyDictionary = new Dictionary<int, string>() {
{ 0 , "Sora/Roxas" },
{ 1 , "Sora Valor" },
{ 2 , "Sora Wisdom" },
{ 3 , "Sora Master" },
{ 4 , "Sora Final" },
{ 5 , "Sora Anti" },
{ 6 , "Sora LK" },
{ 7 , "Sora LM" },
{ 8 , "Donald" },
{ 9 , "Donald LK" },
{ 10 , "Goofy" },
{ 11 , "Goofy LK" },
{ 12 , "Aladdin" },
{ 13 , "Auron" },
{ 14 , "Mulan" },
{ 15 , "Ping" },
{ 16 , "Tron" },
{ 17 , "Mickey" },
{ 18 , "Beast" },
{ 19 , "Jack" },
{ 20 , "Simba" },
{ 21 , "Sparrow" },
{ 22 , "Riku" },
{ 23 , "Magic Carpet" },
{ 24 , "Light Cycle" },
{ 25 , "Sora Die" },
{ 26 , "" },
{ 27 , "" },
{ 28 , "Gummi Ship WM" },
{ 29 , "Red Rocket" },
{ 30 , "Neverland" },
{ 31 , "Session" },
{ 32 , "Sora Limit" }
        };

        public static String getPrty(int id)
        {
            if (prtyDictionary.ContainsKey(id)) return prtyDictionary[id];
            return "";
        }
    }
}
