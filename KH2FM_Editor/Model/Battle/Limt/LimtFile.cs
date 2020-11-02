using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Limt
{
    public class LimtFile : Str_EntryFile, BarSubFile
    {
        public LimtFile(String name, List<byte> raw) : base(name, 4, 4, LimtItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new LimtItem(raw.GetRange(currentOffset, LimtItem.entrySize)));
                currentOffset += LimtItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}