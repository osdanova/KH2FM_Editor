using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Plrp
{
    public class PlrpFile : Str_EntryFile, BarSubFile
    {
        public PlrpFile(String name, List<byte> raw) : base(name, 4, 4, PlrpItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new PlrpItem(raw.GetRange(currentOffset, PlrpItem.entrySize)));
                currentOffset += PlrpItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}