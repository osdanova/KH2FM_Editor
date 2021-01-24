using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Mixdata.Leve
{
    class LeveItem : Str_EntryItem
    {
        public static readonly int entrySize = 12;
        // Data Location
        public static readonly int titleOffset = 0, titleSize = 2;
        public static readonly int statOffset = 2, statSize = 2;
        public static readonly int enableOffset = 4, enableSize = 2;
        public static readonly int paddingOffset = 6, paddingSize = 2;
        public static readonly int expOffset = 8, expSize = 4;

        public LeveItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public LeveItem(List<byte> rawData) : base(rawData)
        {
        }

        public ushort Title
        {
            get { return DataAccess.readUShort(raw, titleOffset, titleSize); }
            set { DataAccess.writeUShort(raw, value, titleOffset, titleSize); }
        }
        public ushort Stat
        {
            get { return DataAccess.readUShort(raw, statOffset, statSize); }
            set { DataAccess.writeUShort(raw, value, statOffset, statSize); }
        }
        public short Enable
        {
            get { return DataAccess.readShort(raw, enableOffset, enableSize); }
            set { DataAccess.writeShort(raw, value, enableOffset, enableSize); }
        }
        public uint Exp
        {
            get { return DataAccess.readUInt(raw, expOffset, expSize); }
            set { DataAccess.writeUInt(raw, value, expOffset, expSize); }
        }
    }
}
