using System;
using System.Collections.Generic;

namespace KH2FM_Editor.DataDictionary
{
    public class Shops
    {
        // 2 Bytes
        public static Dictionary<ushort, String> valuesDictionary = new Dictionary<ushort, string>() {
{ 0 , "TT Weapons" },
{ 1 , "TT Armor" },
{ 2 , "TT Accessories" },
{ 3 , "TT Items" },
{ 4 , "TT Synthesis" },
{ 5 , "HB Weapons" },
{ 6 , "HB Armor" },
{ 7 , "HB Accessories" },
{ 8 , "HB Items" },
{ 9 , "HB Synthesis" },
{ 10 , "MU" },
{ 11 , "BC" },
{ 12 , "HE" },
{ 13 , "DC" },
{ 14 , "WI" },
{ 15 , "CA" },
{ 16 , "AL" },
{ 17 , "NM" },
{ 18 , "LK" },
{ 19 , "TR" },
{ 20 , "TWTNW" }
        };

        public static String getValue(ushort id)
        {
            if (valuesDictionary.ContainsKey(id)) return valuesDictionary[id];
            return "";
        }
    }
}
