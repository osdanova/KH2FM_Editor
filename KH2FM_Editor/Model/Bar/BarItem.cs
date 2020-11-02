using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Bar
{
    class BarItem : Str_EntryItem
    {
        public static readonly int entrySize = 16;
        // Data Location
        public static readonly int typeOffset = 0, typeSize = 2;
        public static readonly int dupFlagOffset = 2, dupFlagSize = 2;
        public static readonly int nameOffset = 4, nameSize = 4;
        public static readonly int offsetOffset = 8, offsetSize = 4;
        public static readonly int sizeOffset = 12, sizeSize = 4;

        public BarItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public BarItem(List<byte> rawData) : base(rawData)
        {
        }

        public ushort Type
        {
            get { return DataAccess.readUShort(raw, typeOffset, typeSize); }
            set { DataAccess.writeUShort(raw, value, typeOffset, typeSize); }
        }
        public ushort DupFlag
        {
            get { return DataAccess.readUShort(raw, dupFlagOffset, dupFlagSize); }
            set { DataAccess.writeUShort(raw, value, dupFlagOffset, dupFlagSize); }
        }
        public string Name
        {
            get { return DataAccess.readString(raw, nameOffset, nameSize); }
            set { DataAccess.writeString(raw, value, nameOffset, nameSize); }
        }
        public uint Offset
        {
            get { return DataAccess.readUInt(raw, offsetOffset, offsetSize); }
            set { DataAccess.writeUInt(raw, value, offsetOffset, offsetSize); }
        }
        public uint Size
        {
            get { return DataAccess.readUInt(raw, sizeOffset, sizeSize); }
            set { DataAccess.writeUInt(raw, value, sizeOffset, sizeSize); }
        }
    }
}
