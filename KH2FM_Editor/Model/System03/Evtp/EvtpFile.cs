using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Evtp
{
    public class EvtpFile : Str_EntryFile, BarSubFile
    {
        public EvtpFile(String name, List<byte> raw) : base(name, 4, 4, EvtpItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new EvtpItem(raw.GetRange(currentOffset, EvtpItem.entrySize)));
                currentOffset += EvtpItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}