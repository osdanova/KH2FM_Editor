using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Jiminy.Worl
{
    public class WorlFile : Str_EntryFile, BarSubFile
    {
        public WorlFile(String name, List<byte> raw) : base(name, 8, 8, WorlItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new WorlItem(raw.GetRange(currentOffset, WorlItem.entrySize)));
                currentOffset += WorlItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}