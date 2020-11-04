using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Item
{
    public class ItemTable : Str_EntryFile
    {
        public ItemTable(String name, List<byte> raw) : base(name, 4, 4, ItemItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new ItemItem(raw.GetRange(currentOffset, ItemItem.entrySize)));
                currentOffset += ItemItem.entrySize;
            }
        }
    }
}