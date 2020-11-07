using System;
using System.Collections.Generic;

namespace KH2FM_Editor.DataDictionary
{
    public class ArdOpcodes
    {
        // 2 Bytes
        public static Dictionary<ushort, String> valuesDictionary = new Dictionary<ushort, string>() {
{ 0 , "Spawn" },
{ 1 , "MapOcclusion" },
{ 2 , "MultipleSpawn" },
{ 3 , "???" },
{ 4 , "???" },
{ 5 , "???" },
{ 6 , "???" },
{ 7 , "???" },
{ 8 , "???" },
{ 9 , "???" },
{ 10 , "???" },
{ 11 , "???" },
{ 12 , "Scene" },
{ 13 , "???" },
{ 14 , "BGM" },
{ 15 , "Party" },
{ 16 , "???" },
{ 17 , "???" },
{ 18 , "???" },
{ 19 , "???" },
{ 20 , "???" },
{ 21 , "Mission" },
{ 22 , "Bar" },
{ 23 , "???" },
{ 24 , "???" },
{ 25 , "???" },
{ 26 , "???" },
{ 27 , "???" },
{ 28 , "???" },
{ 29 , "???" },
{ 30 , "BattleLevel" },
{ 31 , "???" }
        };

        public static String getValue(ushort id)
        {
            if(valuesDictionary.ContainsKey(id)) return valuesDictionary[id];
            return "";
        }
    }
}
