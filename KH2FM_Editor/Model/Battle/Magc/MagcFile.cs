using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Magc
{
    public class MagcFile : Str_EntryFile, BarSubFile
    {
        public MagcFile(String name, List<byte> raw) : base(name, 4, 4, MagcItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new MagcItem(raw.GetRange(currentOffset, MagcItem.entrySize)));
                currentOffset += MagcItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}
