using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Cmd
{
    public class CmdFile : Str_EntryFile, BarSubFile
    {
        public CmdFile(String name, List<byte> raw) : base(name, 4, 4, CmdItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new CmdItem(raw.GetRange(currentOffset, CmdItem.entrySize)));
                currentOffset += CmdItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}