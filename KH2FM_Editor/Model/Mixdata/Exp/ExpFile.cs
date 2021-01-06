using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Mixdata.Exp
{
    public class ExpFile : Str_EntryFile, BarSubFile
    {
        public ExpFile(String name, List<byte> raw) : base(name, 8, 8, ExpItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new ExpItem(raw.GetRange(currentOffset, ExpItem.entrySize)));
                currentOffset += ExpItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}
