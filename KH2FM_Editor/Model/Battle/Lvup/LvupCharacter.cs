using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Lvup
{
    public class LvupCharacter : Str_EntryFile
    {
        public LvupCharacter(String name, List<byte> raw) : base(name, 0, 4, LvupItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new LvupItem(raw.GetRange(currentOffset, LvupItem.entrySize)));
                currentOffset += LvupItem.entrySize;
            }
        }
    }
}
