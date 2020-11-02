using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Vtbl
{
    public class VtblFile : Str_EntryFile, BarSubFile
    {
        public VtblFile(String name, List<byte> raw) : base(name, 4, 4, VtblItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new VtblItem(raw.GetRange(currentOffset, VtblItem.entrySize)));
                currentOffset += VtblItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}