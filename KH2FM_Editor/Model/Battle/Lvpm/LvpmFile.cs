using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Lvpm
{
    public class LvpmFile : Str_EntryFile, BarSubFile
    {
        public LvpmFile(String name, List<byte> raw) : base(name, 0, 0, LvpmItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            int lvpmCount = raw.Count / LvpmItem.entrySize;

            // Entries
            for (int i = 0; i < lvpmCount; i++)
            {
                Entries.Add(new LvpmItem(raw.GetRange(currentOffset, LvpmItem.entrySize)));
                currentOffset += LvpmItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}