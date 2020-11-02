using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Btlv
{
    public class BtlvFile : Str_EntryFile, BarSubFile
    {
        public BtlvFile(String name, List<byte> raw) : base(name, 4, 4, BtlvItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new BtlvItem(raw.GetRange(currentOffset, BtlvItem.entrySize)));
                currentOffset += BtlvItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}