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
        public static readonly int expRateOffset = 8, expRateSize = 4;
        public static readonly int progressOffset = 12, progressSize = 2;
        public static readonly int funcOffset = 14, funcSize = 2;

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
        public float ExpRate
        {
            get { return DataAccess.readFloat(raw, expRateOffset, expRateSize); }
            set { DataAccess.writeFloat(raw, value, expRateOffset, expRateSize); }
        }
        public ushort Progress
        {
            get { return DataAccess.readUShort(raw, progressOffset, progressSize); }
            set { DataAccess.writeUShort(raw, value, progressOffset, progressSize); }
        }
        public ushort Func
        {
            get { return DataAccess.readUShort(raw, funcOffset, funcSize); }
            set { DataAccess.writeUShort(raw, value, funcOffset, funcSize); }
        }
    }
}
