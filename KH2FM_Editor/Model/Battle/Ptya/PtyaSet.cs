using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.Model.Battle.Ptya
{
    public class PtyaSet
    {
        public static int entryCountSize = 4;

        public String Name { get; set; }
        public uint EntryCount { get; set; }
        public ObservableCollection<PtyaItem> Entries { get; set; }

        public PtyaSet(String name, List<byte> raw)
        {
            //Console.WriteLine("DEBUG > PtyaSet > Found entry: " + name);
            // File name
            this.Name = name;

            Entries = new ObservableCollection<PtyaItem>();

            EntryCount = DataAccess.readUInt(raw, 0, 4);

            // Process file
            processEntries(raw);
        }

        // Reads and processes the entries
        public void processEntries(List<byte> raw)
        {
            int currentOffset = entryCountSize;

            for (int i = 0; i < EntryCount; i++)
            {
                Entries.Add(new PtyaItem(raw.GetRange(currentOffset, PtyaItem.entrySize)));
                currentOffset += PtyaItem.entrySize;
            }
        }

        public void recalcCount()
        {
            EntryCount = (uint)Entries.Count;
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            List<byte> data = new List<byte>();

            recalcCount();

            data.AddRange(BinaryHandler.uintAsBytes(EntryCount));

            // Entries
            foreach (Str_EntryItem entry in Entries)
            {
                data.AddRange(entry.getAsByteList());
            }

            return data;
        }
    }
}
