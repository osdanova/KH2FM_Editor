using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Sklt
{
    public class SkltFile : Str_EntryFile, BarSubFile
    {
        public SkltFile(String name, List<byte> raw) : base(name, 4, 4, SkltItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new SkltItem(raw.GetRange(currentOffset, SkltItem.entrySize)));
                currentOffset += SkltItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}