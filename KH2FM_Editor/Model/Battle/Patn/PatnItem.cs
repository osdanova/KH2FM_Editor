using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Patn
{
    class PatnItem : Str_EntryItem
    {
        public static readonly int entrySize = 32;
        // Data Location
        public int idOffset = 0, idSize = 1;
        // 19 values
        public int unk1Offset = 1, unk1Size = 1;
        public int unk2Offset = 2, unk2Size = 1;
        public int unk3Offset = 3, unk3Size = 1;
        public int unk4Offset = 4, unk4Size = 1;
        public int unk5Offset = 5, unk5Size = 1;
        public int unk6Offset = 6, unk6Size = 1;
        public int unk7Offset = 7, unk7Size = 1;
        public int unk8Offset = 8, unk8Size = 1;
        public int unk9Offset = 9, unk9Size = 1;
        public int unk10Offset = 10, unk10Size = 1;
        public int unk11Offset = 11, unk11Size = 1;
        public int unk12Offset = 12, unk12Size = 1;
        public int unk13Offset = 13, unk13Size = 1;
        public int unk14Offset = 14, unk14Size = 1;
        public int unk15Offset = 15, unk15Size = 1;
        public int unk16Offset = 16, unk16Size = 1;
        public int unk17Offset = 17, unk17Size = 1;
        public int unk18Offset = 18, unk18Size = 1;
        public int unk19Offset = 19, unk19Size = 1;
        public int unk20Offset = 20, unk20Size = 1;

        public int paddingOffset = 19, paddingSize = 12;

        public PatnItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public PatnItem(List<byte> rawData) : base(rawData)
        {
        }

        public byte Id
        {
            get { return DataAccess.readByte(raw, idOffset); }
            set { DataAccess.writeByte(raw, value, idOffset); }
        }
        public string UnkAll
        {
            get { return DataAccess.readHexString(raw, unk1Offset, 19); }
            set { DataAccess.writeHexString(raw, value, unk1Offset, 19); }
        }
    }
}
