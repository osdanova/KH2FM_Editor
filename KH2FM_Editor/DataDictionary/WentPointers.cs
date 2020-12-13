using System;
using System.Collections.Generic;

namespace KH2FM_Editor.DataDictionary
{
    public class WentPointers
    {

        public static List<int> getCharacterPointers(int id)
        {
            if (characterDictionary.ContainsKey(id))
            {
                if (pointerDictionary.ContainsKey(characterDictionary[id]))
                {
                    return pointerDictionary[characterDictionary[id]];
                }
                return new List<int>();
            }
            return new List<int>();
        }

        public static Dictionary<String, List<int>> pointerDictionary = new Dictionary<String, List<int>>() {
{ "Sora" , new List<int>{1,2,3,4,5,6,7,8,9,10,53,54,57,58,61} },
{ "Sora NM" , new List<int>{11,12,13,14,15,16,67} },
{ "Donald" , new List<int>{17,18} },
{ "Donald NM" , new List<int>{19} },
{ "Goofy" , new List<int>{20} },
{ "Goofy2" , new List<int>{21} },
{ "Goofy NM" , new List<int>{22} },
{ "Aladdin" , new List<int>{23} },
{ "Auron" , new List<int>{24} },
{ "Mulan" , new List<int>{25,26} },
{ "Tron" , new List<int>{27} },
{ "Mickey" , new List<int>{28,29,30} },
{ "Beast" , new List<int>{31} },
{ "Jack" , new List<int>{32} },
{ "Simba" , new List<int>{33} },
{ "Sparrow" , new List<int>{34} },
{ "Riku" , new List<int>{35,64,65} },
{ "Sparrow HU" , new List<int>{36} },
{ "Sora TR" , new List<int>{37,38,39,40,41,42,68} },
{ "Sora WI" , new List<int>{43,44,45,46,47,48,69} },
{ "Donald TR" , new List<int>{49} },
{ "Donald WI" , new List<int>{50} },
{ "Goofy TR" , new List<int>{51} },
{ "Goofy WI" , new List<int>{52} }
        };

        public static List<int> getPointers(String id)
        {
            if (pointerDictionary.ContainsKey(id)) return pointerDictionary[id];
            return new List<int>();
        }

        public static Dictionary<int, String> characterDictionary = new Dictionary<int, String>() {
{ 0,"Sora" },
{ 1,"Sora NM" },
{ 2,"Donald" },
{ 3,"Donald NM" },
{ 4,"Goofy" },
{ 5,"Goofy2" },
{ 6,"Goofy NM" },
{ 7,"Aladdin" },
{ 8,"Auron" },
{ 9,"Mulan" },
{ 10,"Tron" },
{ 11,"Mickey" },
{ 12,"Beast" },
{ 13,"Jack" },
{ 14,"Simba" },
{ 15,"Sparrow" },
{ 16,"Riku" },
{ 17,"Sparrow HU" },
{ 18,"Sora TR" },
{ 19,"Sora WI" },
{ 20,"Donald TR" },
{ 21,"Donald WI" },
{ 22,"Goofy TR" },
{ 23,"Goofy WI" }
        };

        public static String getCharacter(int id)
        {
            if (characterDictionary.ContainsKey(id)) return characterDictionary[id];
            return "";
        }
    }
}
