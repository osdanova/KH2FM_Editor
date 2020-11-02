using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Mixdata.Reci
{
    public class ReciFile : Str_EntryFile, BarSubFile
    {
        public ReciFile(String name, List<byte> raw) : base(name, 8, 8, ReciItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new ReciItem(raw.GetRange(currentOffset, ReciItem.entrySize)));
                currentOffset += ReciItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}
