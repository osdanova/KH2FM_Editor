using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Jiminy.Puzz
{
    public class PuzzFile : Str_EntryFile, BarSubFile
    {
        public PuzzFile(String name, List<byte> raw) : base(name, 8, 8, PuzzItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new PuzzItem(raw.GetRange(currentOffset, PuzzItem.entrySize)));
                currentOffset += PuzzItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}