using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Mixdata.Exp
{
    class ExpItem : Str_EntryItem
    {
        public static readonly int entrySize = 16;
        // Data Location
        public static readonly int expCOffset = 0, expCSize = 2;
        public static readonly int expBOffset = 2, expBSize = 2;
        public static readonly int expAOffset = 4, expASize = 2;
        public static readonly int expSOffset = 6, expSSize = 2;
        public static readonly int unk08Offset = 8, unk08Size = 8;

        public ExpItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public ExpItem(List<byte> rawData) : base(rawData)
        {
        }

        public ushort expC
        {
            get { return DataAccess.readUShort(raw, expCOffset, expCSize); }
            set { DataAccess.writeUShort(raw, value, expCOffset, expCSize); }
        }
        public ushort expB
        {
            get { return DataAccess.readUShort(raw, expBOffset, expBSize); }
            set { DataAccess.writeUShort(raw, value, expBOffset, expBSize); }
        }
        public ushort expA
        {
            get { return DataAccess.readUShort(raw, expAOffset, expASize); }
            set { DataAccess.writeUShort(raw, value, expAOffset, expASize); }
        }
        public ushort expS
        {
            get { return DataAccess.readUShort(raw, expSOffset, expSSize); }
            set { DataAccess.writeUShort(raw, value, expSOffset, expSSize); }
        }
        public string Unk08
        {
            get { return DataAccess.readHexString(raw, unk08Offset, unk08Size); }
            set { DataAccess.writeHexString(raw, value, unk08Offset, unk08Size); }
        }
    }
}
