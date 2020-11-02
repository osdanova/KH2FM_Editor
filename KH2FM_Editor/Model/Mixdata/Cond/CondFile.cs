using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Mixdata.Cond
{
    public class CondFile : Str_EntryFile, BarSubFile
    {
        public CondFile(String name, List<byte> raw) : base(name, 8, 8, CondItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new CondItem(raw.GetRange(currentOffset, CondItem.entrySize)));
                currentOffset += CondItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}
