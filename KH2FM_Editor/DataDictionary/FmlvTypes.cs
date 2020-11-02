using System;
using System.Collections.Generic;

namespace KH2FM_Editor.DataDictionary
{
    public class FmlvTypes
    {
        // 1/2 Bytes
        public static Dictionary<int, String> valuesDictionary = new Dictionary<int, string>()
        {
            { 0, "Summon" },
            { 1, "Valor" },
            { 2, "Wisdom" },
            { 3, "Limit" },
            { 4, "Master" },
            { 5, "Final" },
            { 6, "???" }
        };

        public static String getValue(int id)
        {
            if(valuesDictionary.ContainsKey(id)) return valuesDictionary[id];
            return "";
        }
    }
}
