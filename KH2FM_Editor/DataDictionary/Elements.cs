using System;
using System.Collections.Generic;

namespace KH2FM_Editor.DataDictionary
{
    public class Elements
    {
        // 2 Bytes
        public static Dictionary<byte, String> elementDictionary = new Dictionary<byte, string>() {
{ 0 , "Neutral" },
{ 1 , "Fire" },
{ 2 , "Blizzard" },
{ 3 , "Thunder" },
{ 4 , "Dark" },
{ 5 , "Special" },
{ 6 , "General" }
        };

        public static String getElement(byte id)
        {
            if (elementDictionary.ContainsKey(id)) return elementDictionary[id];
            return "";
        }
    }
}
