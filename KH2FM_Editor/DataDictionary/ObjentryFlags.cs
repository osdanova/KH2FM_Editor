using System;
using System.Collections.Generic;

namespace KH2FM_Editor.DataDictionary
{
    public class ObjentryFlags
    {
        // 2 Bytes
        public static Dictionary<ushort, String> flags = new Dictionary<ushort, string>() {
{ 0 , "No Apdx" },
{ 1 , "Before" },
{ 2 , "FixColor" },
{ 3 , "Fly" },
{ 4 , "Scissoring" },
{ 5 , "Pirate" },
{ 6 , "Wall Occlusion" },
{ 7 , "Hift" }
        };

        public static String getFlag(ushort id)
        {
            if (flags.ContainsKey(id)) return flags[id];
            return "";
        }

        // 1 Byte
        public static Dictionary<byte, String> shadowSizes = new Dictionary<byte, string>() {
{ 0 , "None" },
{ 1 , "Small" },
{ 2 , "Middle" },
{ 3 , "Large" },
{ 4 , "Moving S" },
{ 5 , "Moving M" },
{ 6 , "Moving L" }
        };

        public static String getShadowSize(byte id)
        {
            if (shadowSizes.ContainsKey(id)) return shadowSizes[id];
            return "";
        }

        // 1 Byte
        public static Dictionary<byte, String> targets = new Dictionary<byte, string>() {
{ 0 , "M" },
{ 1 , "S" },
{ 2 , "L" }
        };

        public static String getTarget(byte id)
        {
            if (targets.ContainsKey(id)) return targets[id];
            return "";
        }

        // 1 Byte
        public static Dictionary<byte, String> forms = new Dictionary<byte, string>() {
{ 0 , "Default" },
{ 6 , "Anti" },
{ 7 , "Lion" },
{ 8 , "Atlantica" },
{ 9 , "Carpet" },
{ 10 , "Roxas Dual" },
{ 11 , "Default (Enemy)" },
{ 12 , "Die/Card" }
        };

        public static String getForm(byte id)
        {
            if (forms.ContainsKey(id)) return forms[id];
            return "";
        }
    }
}
