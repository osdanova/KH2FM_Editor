using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Przt
{
    public class PrztFile : Str_EntryFile, BarSubFile
    {
        public PrztFile(String name, List<byte> raw) : base(name, 4, 4, PrztItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new PrztItem(raw.GetRange(currentOffset, PrztItem.entrySize)));
                currentOffset += PrztItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}