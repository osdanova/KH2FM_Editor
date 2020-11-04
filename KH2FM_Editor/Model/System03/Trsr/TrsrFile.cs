using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Trsr
{
    public class TrsrFile : Str_EntryFile, BarSubFile
    {
        public TrsrFile(String name, List<byte> raw) : base(name, 2, 2, TrsrItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new TrsrItem(raw.GetRange(currentOffset, TrsrItem.entrySize)));
                currentOffset += TrsrItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}