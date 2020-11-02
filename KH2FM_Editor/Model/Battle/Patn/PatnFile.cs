using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Patn
{
    public class PatnFile : Str_EntryFile, BarSubFile
    {
        public PatnFile(String name, List<byte> raw) : base(name, 4, 4, PatnItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new PatnItem(raw.GetRange(currentOffset, PatnItem.entrySize)));
                currentOffset += PatnItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}