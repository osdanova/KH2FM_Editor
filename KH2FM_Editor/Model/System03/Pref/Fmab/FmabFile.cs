using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.Bar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.Model.System03.Pref.Fmab
{
    public class FmabFile : BarSubFile
    {
        // 5 pointers
        public uint pointerCount = 5;
        public int uintSize = 4;
        public static readonly int formAbSize = 68;

        public String Name { get; set; }
        public List<uint> Pointers;
        public ObservableCollection<FmabItem> FormAbs { get; set; }

        public FmabFile(String name, List<byte> raw)
        {
            Console.WriteLine("DEBUG >>> Found Fmab file: " + name);
            this.Name = name;
            Pointers = new List<uint>();
            FormAbs = new ObservableCollection<FmabItem>();
            processFile(raw);
        }

        public void processFile(List<byte> raw)
        {
            // Header
            processPointerCount(raw);
            // Pointers
            processPointers(raw);
            // Sets
            processData(raw);
        }

        public void processPointerCount(List<byte> raw)
        {
            pointerCount = DataAccess.readUInt(raw, 0, uintSize);
        }
        public void processPointers(List<byte> raw)
        {
            // 5 Pointers
            for (int i = 0; i < pointerCount; i++)
            {
                Pointers.Add(DataAccess.readUInt(raw, uintSize + i * uintSize, uintSize));
                //Console.WriteLine("DELETE DEBUG >>> Found pointer to: " + Pointers[i]);
            }
        }
        public void processData(List<byte> raw)
        {
            for (int i = 0; i < Pointers.Count; i++)
            {
                //Console.WriteLine("DELETE DEBUG >>> Reading data at: " + (int)Pointers[i]);
                FormAbs.Add(new FmabItem(raw.GetRange((int)Pointers[i], FmabItem.entrySize)));
                //Console.WriteLine("DELETE DEBUG >>> Data line: " + FormAbs[i].getAsByteList());
            }
        }

        public void recalcPointers()
        {
            pointerCount = (uint)Pointers.Count;

            uint currentOffset = (uint)uintSize + pointerCount * (uint)uintSize;

            for (int i = 0; i < FormAbs.Count; i++)
            {
                //Console.WriteLine("DELETE DEBUG > FmabFile > pointer "+i+" before: " + Pointers[i]);
                Pointers[i] = currentOffset;
                currentOffset += (uint)(FormAbs[i].raw.Count);
                //Console.WriteLine("DELETE DEBUG > FmabFile > pointer " + i + " after: " + Pointers[i]);
            }
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            List<byte> data = new List<byte>();

            recalcPointers();

            // PointerCount
            data.AddRange(BinaryHandler.uintAsBytes(pointerCount));
            // Pointers
            foreach (uint pointer in Pointers)
            {
                data.AddRange(BinaryHandler.uintAsBytes(pointer));
            }
            // Items
            foreach (FmabItem item in FormAbs)
            {
                data.AddRange(item.getAsByteList());
            }

            return data;
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}