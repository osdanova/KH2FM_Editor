using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Enmp
{
    public class EnmpFile : Str_EntryFile, BarSubFile
    {
        public EnmpFile(String name, List<byte> raw) : base(name, 4, 4, EnmpItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new EnmpItem(raw.GetRange(currentOffset, EnmpItem.entrySize)));
                currentOffset += EnmpItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}