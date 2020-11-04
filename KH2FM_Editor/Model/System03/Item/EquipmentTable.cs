using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Item
{
    public class EquipmentTable : Str_EntryFile
    {
        public EquipmentTable(String name, List<byte> raw) : base(name, 4, 4, EquipmentItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new EquipmentItem(raw.GetRange(currentOffset, EquipmentItem.entrySize)));
                currentOffset += EquipmentItem.entrySize;
            }
        }
    }
}