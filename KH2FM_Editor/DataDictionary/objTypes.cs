﻿using System;
using System.Collections.Generic;

namespace KH2FM_Editor.DataDictionary
{
    public class ObjTypes
    {
        // 1 Byte
        // Objentry
        public static Dictionary<byte, String> valuesDictionary = new Dictionary<byte, string>() {
{ 0 , "PLAYER" },
{ 1 , "FRIEND" },
{ 2 , "NPC" },
{ 3 , "BOSS" },
{ 4 , "ZAKO" },
{ 5 , "WEAPON" },
{ 6 , "E_WEAPON" },
{ 7 , "SP" },
{ 8 , "F_OBJ" },
{ 9 , "BTLNPC" },
{ 10 , "TREASURE" },
{ 11 , "SUBMENU" },
{ 12 , "L_BOSS" },
{ 13 , "G_OBJ" },
{ 14 , "MEMO" },
{ 15 , "RTN" },
{ 16 , "MINIGAME" },
{ 17 , "WORLDMAP" },
{ 18 , "PRIZEBOX" },
{ 19 , "SUMMON" },
{ 20 , "SHOP" },
{ 21 , "L_ZAKO" },
{ 22 , "MASSEFFECT" },
{ 23 , "E_OBJ" },
{ 24 , "JIGSAW" }
        };

        public static String getValue(byte id)
        {
            if (valuesDictionary.ContainsKey(id)) return valuesDictionary[id];
            return "";
        }
    }
}
