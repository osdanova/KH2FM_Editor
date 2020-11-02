using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Bons
{
    public class BonsFile : Str_EntryFile, BarSubFile
    {
        public BonsFile(String name, List<byte> raw) : base(name, 4, 4, BonsItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new BonsItem(raw.GetRange(currentOffset, BonsItem.entrySize)));
                currentOffset += BonsItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}