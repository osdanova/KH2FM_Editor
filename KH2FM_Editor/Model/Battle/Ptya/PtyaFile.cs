using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.Model.Battle.Ptya
{
    public class PtyaFile : BarSubFile
    {
        //public List<byte> tempRaw;
        // 70 pointers
        // 24 sets
        public static readonly int headerSize = 8;
        public static readonly int fileTypeOffset = 0, fileTypeSize = 4;
        public static readonly int pointerCountOffset = 4, pointerCountSize = 4;
        public static readonly int pointerSize = 4;
        public static readonly int intSize = 4;
        public static readonly int setStart = 70;

        public String Name { get; set; }
        public List<byte> Header; 
        public List<uint> Pointers; // 70
        // Without repeats and ordered, to read the sets
        public List<uint> PointerSet; // 17
        public ObservableCollection<PtyaSet> PtyaSets { get; set; }

        public uint PointerCount
        {
            get { return DataAccess.readUInt(Header, pointerCountOffset, pointerCountSize); }
            set { DataAccess.writeUInt(Header, value, pointerCountOffset, pointerCountSize); }
        }

        public PtyaFile(String name, List<byte> raw)
        {
            //tempRaw = raw;
            Console.WriteLine("DEBUG >>> Found Ptya file: " + name);
            this.Name = name;
            PointerSet = new List<uint>();
            Pointers = new List<uint>();
            //WeaponSets = new ObservableCollection<PtyaSet>();
            processFile(raw);
        }

        public void processFile(List<byte> raw)
        {
            // Header
            processHeader(raw);
            // Pointers
            processPointers(raw);
            // Sets
            processSets(raw);
        }

        public void processHeader(List<byte> raw)
        {
            Header = raw.GetRange(0, headerSize);
        }

        public void processPointers(List<byte> raw)
        {
            int currentOffset = headerSize;

            for (int i = 0; i < PointerCount; i++)
            {
                uint pointerValue = DataAccess.readUInt(raw, currentOffset, pointerSize);
                // PointerSet - Pointers not repeated, in order. To later read the sets. 
                if (pointerValue != 0 && !PointerSet.Contains(pointerValue))
                {
                    PointerSet.Add(pointerValue);
                    PointerSet.Sort();
                }

                // Pointers
                Pointers.Add(pointerValue);

                currentOffset += pointerSize;
            }
            Console.WriteLine("DELETE DEBUG >>> Pointer count: " + Pointers.Count);
            Console.WriteLine("DELETE DEBUG >>> Pointer Set count: " + PointerSet.Count);
            uint lastPointer = 0;
            foreach (uint pointer in PointerSet)
            {
                Console.WriteLine("DELETE DEBUG >>> Pointer: " + pointer + " - " + (pointer - lastPointer));
                lastPointer = pointer;
            }
        }
        public void processSets(List<byte> raw)
        {
            PtyaSets = new ObservableCollection<PtyaSet>();

            // 17 Sets
            for (int i = 0; i < PointerSet.Count; i++)
            {
                int setOffset = (int)PointerSet[i];
                // First 4 bytes is the entry count of the set
                uint setCount = DataAccess.readUInt(raw, setOffset, PtyaSet.entryCountSize);
                long setSize = PtyaSet.entryCountSize + (setCount * PtyaItem.entrySize);
                //Console.WriteLine("DELETE DEBUG >>> Weapon Set for: " + PtyaPointers.getCharacter(i) + " - size:" + setSize);
                PtyaSets.Add(new PtyaSet(i.ToString(), raw.GetRange(setOffset, (int)setSize)));
            }
            //Console.WriteLine("DELETE DEBUG >>> Weapon Set count: " + WeaponSets.Count);
        }
        
        /*public void recalcPointers()
        {
            // First 70 Pointers
            int currentPointer = Pointers.Count;
            // 24 Sets
            for (int i = 0; i < PtyaSets.Count; i++)
            {
                PtyaSets[i].recalcCount();
                // Update the set's pointers
                foreach (int pointer in PtyaPointers.getCharacterPointers(i))
                {
                    Pointers[pointer] = (uint)currentPointer;
                }
                currentPointer += (int)PtyaSets[i].TotalSize;
            }
        }*/

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            List<byte> data = new List<byte>();

            //recalcPointers();

            data.AddRange(Header);

            // 70 Pointers
            foreach (uint pointer in Pointers)
            {
                data.AddRange(BinaryHandler.uintAsBytes(pointer));
            }
            // 17 Sets
            foreach (PtyaSet inventory in PtyaSets)
            {
                data.AddRange(inventory.getAsByteList());
            }

            return data;
            //return tempRaw;
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}