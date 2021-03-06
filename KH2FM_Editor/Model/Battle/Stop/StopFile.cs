﻿using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Stop
{
    public class StopFile : Str_EntryFile, BarSubFile
    {
        public StopFile(String name, List<byte> raw) : base(name, 4, 4, StopItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new StopItem(raw.GetRange(currentOffset, StopItem.entrySize)));
                currentOffset += StopItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}