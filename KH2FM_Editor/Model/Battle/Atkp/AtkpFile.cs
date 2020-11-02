using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Atkp
{
    public class AtkpFile : Str_EntryFile, BarSubFile
    {
        public AtkpFile(String name, List<byte> raw) : base(name, 4, 4, AtkpItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new AtkpItem(raw.GetRange(currentOffset, AtkpItem.entrySize)));
                currentOffset += AtkpItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}