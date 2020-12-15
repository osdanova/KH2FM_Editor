using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.Model.System03.Went
{
    public class WentFile : BarSubFile
    {
        // 70 pointers
        // 24 sets
        public static readonly int intSize = 4;
        public static readonly int setStart = 70;
        public static readonly int setCount = 24;

        public String Name { get; set; }
        public List<uint> Pointers; // 70
        // Without repeats and ordered, to read the sets
        public List<uint> PointerSet; // 24
        public ObservableCollection<WentSet> WeaponSets { get; set; } // 24

        public WentFile(String name, List<byte> raw)
        {
            Console.WriteLine("DEBUG >>> Found Went file: " + name);
            this.Name = name;
            PointerSet = new List<uint>();
            Pointers = new List<uint>();
            WeaponSets = new ObservableCollection<WentSet>();
            processFile(raw);
        }

        public void processFile(List<byte> raw)
        {
            // Pointers
            processPointers(raw);
            // Sets
            processSets(raw);
        }

        public void processPointers(List<byte> raw)
        {
            // 70 Pointers
            for (int i = 0; i < setStart; i++)
            {
                uint pointerValue = DataAccess.readUInt(raw, i * intSize, intSize);
                // PointerSet - Pointers not repeated, in order. To later read the sets. 
                if (pointerValue != 0 && !PointerSet.Contains(pointerValue))
                {
                    PointerSet.Add(pointerValue);
                    PointerSet.Sort();
                }

                // Pointers
                Pointers.Add(pointerValue);
            }
            //Console.WriteLine("DELETE DEBUG >>> Pointer count: " + Pointers.Count);
            //Console.WriteLine("DELETE DEBUG >>> Pointer Set count: " + PointerSet.Count);
        }
        public void processSets(List<byte> raw)
        {
            // 24 Sets
            for (int i = 0; i < PointerSet.Count; i++)
            {
                // First 4 bytes is the size of the set, including the size itself
                uint setSize = DataAccess.readUInt(raw, (int)PointerSet[i] * intSize, intSize);
                //Console.WriteLine("DELETE DEBUG >>> Weapon Set for: " + WentPointers.getCharacter(i) + " - size:" + setSize);
                WeaponSets.Add(new WentSet(WentPointers.getCharacter(i), raw.GetRange((int)PointerSet[i] * intSize, (int)setSize * intSize))) ;
            }
            //Console.WriteLine("DELETE DEBUG >>> Weapon Set count: " + WeaponSets.Count);
        }

        public void recalcPointers()
        {
            // First 70 Pointers
            int currentPointer = Pointers.Count;
            // 24 Sets
            for (int i = 0; i < WeaponSets.Count; i++)
            {
                WeaponSets[i].recalcCount();
                // Update the set's pointers
                foreach (int pointer in WentPointers.getCharacterPointers(i))
                {
                    Pointers[pointer] = (uint) currentPointer;
                }
                currentPointer += (int) WeaponSets[i].TotalSize;
            }
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            List<byte> data = new List<byte>();

            recalcPointers();

            // 70 Pointers
            foreach (uint pointer in Pointers)
            {
                data.AddRange(BinaryHandler.uintAsBytes(pointer));
            }
            // 24 Sets
            foreach (WentSet inventory in WeaponSets)
            {
                data.AddRange(inventory.getAsByteList());
            }

            return data;
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}