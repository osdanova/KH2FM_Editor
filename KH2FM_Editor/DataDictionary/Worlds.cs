using System;
using System.Collections.Generic;

namespace KH2FM_Editor.DataDictionary
{
    public class Worlds
    {
        // 1 Byte
        public static Dictionary<byte, String> valuesDictionary = new Dictionary<byte, string>() {
{ 0 , "zz" },
{ 1 , "es" },
{ 2 , "tt" },
{ 3 , "di" },
{ 4 , "hb" },
{ 5 , "bb" },
{ 6 , "he" },
{ 7 , "al" },
{ 8 , "mu" },
{ 9 , "po" },
{ 10 , "lk" },
{ 11 , "lm" },
{ 12 , "dc" },
{ 13 , "wi" },
{ 14 , "nm" },
{ 15 , "wm" },
{ 16 , "ca" },
{ 17 , "tr" },
{ 18 , "eh" }
        };

        public static String getValue(byte id)
        {
            if (valuesDictionary.ContainsKey(id)) return valuesDictionary[id];
            return "";
        }
    }
}
