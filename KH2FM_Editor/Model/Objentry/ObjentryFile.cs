﻿using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Objentry
{
    public class ObjentryFile : EntryFile
    {
        public ObjentryFile(String name, List<byte> raw) : base(name, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new ObjentryItem(raw.GetRange(currentOffset, ObjentryItem.entrySize)));
                currentOffset += ObjentryItem.entrySize;
            }
        }
    }
}
