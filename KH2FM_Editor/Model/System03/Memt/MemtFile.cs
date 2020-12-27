using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Memt
{
    public class MemtFile : Str_EntryFile, BarSubFile
    {
        public MemtFile(String name, List<byte> raw) : base(name, 4, 4, MemtItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new MemtItem(raw.GetRange(currentOffset, MemtItem.entrySize)));
                currentOffset += MemtItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}