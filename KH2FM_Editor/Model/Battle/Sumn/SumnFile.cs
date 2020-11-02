using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Sumn
{
    public class SumnFile : Str_EntryFile, BarSubFile
    {
        public SumnFile(String name, List<byte> raw) : base(name, 4, 4, SumnItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new SumnItem(raw.GetRange(currentOffset, SumnItem.entrySize)));
                currentOffset += SumnItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}