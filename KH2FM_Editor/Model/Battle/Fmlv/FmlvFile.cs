using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Fmlv
{
    public class FmlvFile : Str_EntryFile, BarSubFile
    {
        public FmlvFile(String name, List<byte> raw) : base(name, 4, 4, FmlvItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new FmlvItem(raw.GetRange(currentOffset, FmlvItem.entrySize)));
                currentOffset += FmlvItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}