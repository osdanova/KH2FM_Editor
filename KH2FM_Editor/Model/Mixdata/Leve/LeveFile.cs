using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Mixdata.Leve
{
    public class LeveFile : Str_EntryFile, BarSubFile
    {
        public LeveFile(String name, List<byte> raw) : base(name, 8, 8, LeveItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new LeveItem(raw.GetRange(currentOffset, LeveItem.entrySize)));
                currentOffset += LeveItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}
