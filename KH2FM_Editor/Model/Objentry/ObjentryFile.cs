using KH2FM_Editor_WPF.FileTypes.GENERIC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KH2FM_Editor_WPF.FileTypes.Objentry
{
    public class ObjentryFile : EntryFile
    {

        public ObjentryFile(String name, List<byte> raw) : base(name, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < entryCount; i++)
            {
                entries.Add(new ObjentryItem(raw.GetRange(currentOffset, ObjentryItem.entrySize)));
                currentOffset += ObjentryItem.entrySize;
            }
        }
    }
}
