using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Arif
{
    public class ArifPointer : Str_EntryItem
    {
        // Data Location
        public static readonly int Size = 4;
        public static readonly int entryCountOffset = 0, entryCountSize = 2;
        public static readonly int entryOfstOffset = 2, entryOfstSize = 2;

        public ArifPointer()
        {
            raw = FormatHandler.getByteListOfSize(Size);
        }
        public ArifPointer(List<byte> rawData) : base(rawData)
        {
        }

        public ushort EntryCount
        {
            get { return DataAccess.readUShort(raw, entryCountOffset, entryCountSize); }
            set { DataAccess.writeUShort(raw, value, entryCountOffset, entryCountSize); }
        }
        public ushort EntryOffset
        {
            get { return DataAccess.readUShort(raw, entryOfstOffset, entryOfstSize); }
            set { DataAccess.writeUShort(raw, value, entryOfstOffset, entryOfstSize); }
        }
    }
}
