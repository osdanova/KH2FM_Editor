using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.Bar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.Model.System03.Pref.Prty
{
    public class PrtyFile : BarSubFile
    {
        public static readonly int intSize = 4;
        public uint settingCount { get; set; }

        public String Name { get; set; }
        public List<uint> Pointers;
        // Without repeats and ordered, to read the sets
        public List<uint> PointerSet;
        public ObservableCollection<PrtyItem> PlayerPrefs { get; set; }

        public PrtyFile(String name, List<byte> raw)
        {
            Console.WriteLine("DEBUG >>> Found Prty file: " + name);
            this.Name = name;
            PointerSet = new List<uint>();
            Pointers = new List<uint>();
            PlayerPrefs = new ObservableCollection<PrtyItem>();
            processFile(raw);
        }

        public void processFile(List<byte> raw)
        {
            // Header
            processSettingCount(raw);
            // Pointers
            processPointers(raw);
            // Sets
            processSets(raw);
        }

        public void processSettingCount(List<byte> raw)
        {
            settingCount = DataAccess.readUInt(raw, 0, intSize);
        }
        public void processPointers(List<byte> raw)
        {
            int pointersOffset = intSize;
            for (int i = 0; i < settingCount; i++)
            {
                uint pointerValue = DataAccess.readUInt(raw, pointersOffset + i * intSize, intSize);
                // PointerSet - Pointers not repeated, in order. To later read the sets. 
                if (pointerValue != 0 && !PointerSet.Contains(pointerValue))
                {
                    PointerSet.Add(pointerValue);
                    PointerSet.Sort();
                }

                // Pointers
                Pointers.Add(pointerValue);
            }
            Console.WriteLine("DELETE DEBUG >>> Pointer count: " + Pointers.Count);
            Console.WriteLine("DELETE DEBUG >>> Pointer Set count: " + PointerSet.Count);
        }
        public void processSets(List<byte> raw)
        {
            for (int i = 0; i < PointerSet.Count; i++)
            {
                //Console.WriteLine("DELETE DEBUG >>> Weapon Set for: " + WentPointers.getCharacter(i) + " - size:" + setSize);
                PlayerPrefs.Add(new PrtyItem(i, raw.GetRange((int)PointerSet[i], PrtyItem.entrySize)));
            }
            //Console.WriteLine("DELETE DEBUG >>> Weapon Set count: " + WeaponSets.Count);
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            List<byte> data = new List<byte>();

            //recalcPointers(); Not doing it, don't mess with the preferences dude

            // Header
            data.AddRange(BinaryHandler.uintAsBytes(settingCount));
            // Pointers
            foreach (uint pointer in Pointers)
            {
                data.AddRange(BinaryHandler.uintAsBytes(pointer));
            }
            // Settings
            foreach (PrtyItem setting in PlayerPrefs)
            {
                data.AddRange(setting.getAsByteList());
            }

            return data;
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}