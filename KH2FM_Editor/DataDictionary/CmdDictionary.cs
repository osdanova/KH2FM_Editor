using System;
using System.Collections.Generic;

namespace KH2FM_Editor.DataDictionary
{
    public class CmdDictionary
    {
        // 1 Byte
        // 00battle/cmd
        public static Dictionary<byte, String> iconDictionary = new Dictionary<byte, string>() {
{ 0 , "None" },
{ 1 , "Attack" },
{ 2 , "Magic" },
{ 3 , "Item" },
{ 4 , "Form" },
{ 5 , "Summon" },
{ 6 , "Friend" },
{ 7 , "Limit" }
        };

        public static String getIcon(byte id)
        {
            if (iconDictionary.ContainsKey(id)) return iconDictionary[id];
            return "";
        }
        // 1 Byte
        // 00battle/cmd
        public static Dictionary<byte, String> cameraDictionary = new Dictionary<byte, string>() {
{ 0 , "Null" },
{ 1 , "Watch" },
{ 2 , "Lock On" },
{ 3 , "Watch & Lock On" }
        };

        public static String getCamera(byte id)
        {
            if (cameraDictionary.ContainsKey(id)) return cameraDictionary[id];
            return "";
        }
        // 1 Byte
        // 00battle/cmd
        public static Dictionary<byte, String> receiverDictionary = new Dictionary<byte, string>() {
{ 0 , "Player" },
{ 1 , "Target" },
{ 2 , "Both" }
        };

        public static String getReceiver(byte id)
        {
            if (receiverDictionary.ContainsKey(id)) return receiverDictionary[id];
            return "";
        }
        // 1 Byte
        // 00battle/cmd
        public static Dictionary<byte, String> actionDictionary = new Dictionary<byte, string>() {
{ 0 , "Null" },
{ 1 , "Idle" },
{ 2 , "Jump" }
        };

        public static String getAction(byte id)
        {
            if (actionDictionary.ContainsKey(id)) return actionDictionary[id];
            return "";
        }
    }
}