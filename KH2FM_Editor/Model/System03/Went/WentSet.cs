using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.Model.System03.Went
{
    public class WentSet
    {
        public String Name { get; set; }
        public uint TotalSize { get; set; }
        public ObservableCollection<WentItem> Entries { get; set; }

        public WentSet(String name, List<byte> raw)
        {
            Console.WriteLine("DEBUG > WentSet > Found entry: " + name);
            // File name
            this.Name = name;

            Entries = new ObservableCollection<WentItem>();

            TotalSize = DataAccess.readUInt(raw, 0, 4);

            // Process file
            processEntries(raw);
        }

        // Reads and processes the entries
        public void processEntries(List<byte> raw)
        {
            // Skip the first one, which is the count
            for (int i = 1; i < TotalSize; i++)
            {
                Entries.Add(new WentItem(raw.GetRange(i*4, 4)));
            }
        }

        public void recalcCount()
        {
            TotalSize = (uint)Entries.Count + 1;
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            List<byte> data = new List<byte>();

            data.AddRange(BinaryHandler.uintAsBytes(TotalSize));

            // Entries
            foreach (Str_EntryItem entry in Entries)
            {
                data.AddRange(entry.getAsByteList());
            }

            return data;
        }
    }
}
