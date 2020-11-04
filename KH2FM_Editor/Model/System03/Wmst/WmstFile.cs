using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Wmst
{
    public class WmstFile : Str_EntryFile, BarSubFile
    {
        public WmstFile(String name, List<byte> raw) : base(name, 0, 0, WmstItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            int wmstCount = raw.Count / WmstItem.entrySize;

            // Entries
            for (int i = 0; i < wmstCount; i++)
            {
                Entries.Add(new WmstItem(raw.GetRange(currentOffset, WmstItem.entrySize)));
                currentOffset += WmstItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}