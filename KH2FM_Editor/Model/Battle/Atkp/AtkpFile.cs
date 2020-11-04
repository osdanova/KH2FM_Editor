using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Atkp
{
    public class AtkpFile : Str_EntryFile, BarSubFile
    {
        public List<byte> AtkpFileEnd { get; set; }

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

            if(currentOffset < raw.Count)
            {
                AtkpFileEnd = new List<byte>();
                AtkpFileEnd.AddRange(raw.GetRange(currentOffset, raw.Count - currentOffset));
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            List<byte> data = getAsByteList();
            if (AtkpFileEnd != null) data.AddRange(AtkpFileEnd);
            return data;
        }
    }
}