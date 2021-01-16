using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Rcct
{
    public class RcctFile : Str_EntryFile, BarSubFile
    {
        public RcctFile(String name, List<byte> raw) : base(name, 4, 4, RcctItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new RcctItem(raw.GetRange(currentOffset, RcctItem.entrySize)));
                currentOffset += RcctItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}