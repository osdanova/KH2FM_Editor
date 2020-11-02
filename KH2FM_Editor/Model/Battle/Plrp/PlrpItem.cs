using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Plrp
{
    class PlrpItem : Str_EntryItem
    {
        public static readonly int entrySize = 128;
        // Data Location
        public int unk0Offset = 0, unk0Size = 2;
        public int unk2Offset = 2, unk2Size = 1;
        public int hpOffset = 3, hpSize = 1;
        public int mpOffset = 4, mpSize = 1;
        public int apOffset = 5, apSize = 1;
        public int unk6Offset = 6, unk6Size = 2;
        public int unk8Offset = 8, unk8Size = 2;
        public int unk10Offset = 10, unk10Size = 2;
        public int itemsOffset = 12, itemsSize = 116;

        public PlrpItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public PlrpItem(List<byte> rawData) : base(rawData)
        {
        }

        public string Unk0
        {
            get { return DataAccess.readHexString(raw, unk0Offset, unk0Size); }
            set { DataAccess.writeHexString(raw, value, unk0Offset, unk0Size); }
        }
        public string Unk2
        {
            get { return DataAccess.readHexString(raw, unk2Offset, unk2Size); }
            set { DataAccess.writeHexString(raw, value, unk2Offset, unk2Size); }
        }
        public byte Hp
        {
            get { return DataAccess.readByte(raw, hpOffset); }
            set { DataAccess.writeByte(raw, value, hpOffset); }
        }
        public byte Mp
        {
            get { return DataAccess.readByte(raw, mpOffset); }
            set { DataAccess.writeByte(raw, value, mpOffset); }
        }
        public byte Ap
        {
            get { return DataAccess.readByte(raw, apOffset); }
            set { DataAccess.writeByte(raw, value, apOffset); }
        }
        public string Unk6
        {
            get { return DataAccess.readHexString(raw, unk6Offset, unk6Size); }
            set { DataAccess.writeHexString(raw, value, unk6Offset, unk6Size); }
        }
        public string Unk8
        {
            get { return DataAccess.readHexString(raw, unk8Offset, unk8Size); }
            set { DataAccess.writeHexString(raw, value, unk8Offset, unk8Size); }
        }
        public string Unk10
        {
            get { return DataAccess.readHexString(raw, unk10Offset, unk10Size); }
            set { DataAccess.writeHexString(raw, value, unk10Offset, unk10Size); }
        }
        public string Items
        {
            get { return DataAccess.readHexString(raw, itemsOffset, itemsSize); }
            set { DataAccess.writeHexString(raw, value, itemsOffset, itemsSize); }
        }
    }
}
