using System;
using System.Collections.Generic;

namespace KH2FM_Editor.DataDictionary
{
    public class AtkpDictionary
    {
        // 1 Byte
        // 00battle/atkp
        public static Dictionary<byte, String> typeDictionary = new Dictionary<byte, string>() {
{ 0 , "Normal Attack" },
{ 1 , "Pierce Armor" },
{ 2 , "Guard" },
{ 3 , "S Guard" },
{ 4 , "Special" },
{ 5 , "Cure" },
{ 6 , "S Cure" }
        };

        public static String getType(byte id)
        {
            if (typeDictionary.ContainsKey(id)) return typeDictionary[id];
            return "";
        }

        // 1 Byte
        // 00battle/atkp
        public static Dictionary<byte, String> refactDictionary = new Dictionary<byte, string>() {
{ 0 , "Reflect" },
{ 1 , "Guard" },
{ 2 , "Nothing" }
        };

        public static String getRefact(byte id)
        {
            if (refactDictionary.ContainsKey(id)) return refactDictionary[id];
            return "";
        }

        // 1 Byte
        // 00battle/atkp
        public static Dictionary<byte, String> trReactionDictionary = new Dictionary<byte, string>() {
{ 0 , "Attack" },
{ 1 , "Charge" },
{ 2 , "Crash" },
{ 3 , "Wall" }
        };

        public static String getTrReaction(byte id)
        {
            if (trReactionDictionary.ContainsKey(id)) return trReactionDictionary[id];
            return "";
        }

        // 1 Byte
        // 00battle/atkp
        public static Dictionary<byte, String> kindDictionary = new Dictionary<byte, string>() {
{ 1 , "Combo Finisher" },
{ 2 , "Air Combo Finisher" },
{ 4 , "Reaction Command" }
        };

        public static String getKind(byte id)
        {
            if (kindDictionary.ContainsKey(id)) return kindDictionary[id];
            return "";
        }
    }
}
