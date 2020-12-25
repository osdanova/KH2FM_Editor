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
        public int magnetOffset = 6, magnetSize = 1;
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

        public int paddingOffset = 20, paddingSize = 12;

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
        public string Unk1 { get { return DataAccess.readHexString(raw, unk1Offset, unk1Size); } set { DataAccess.writeHexString(raw, value, unk1Size, unk1Size); } }
        public string Unk2 { get { return DataAccess.readHexString(raw, unk2Offset, unk2Size); } set { DataAccess.writeHexString(raw, value, unk2Size, unk2Size); } }
        public string Unk3 { get { return DataAccess.readHexString(raw, unk3Offset, unk3Size); } set { DataAccess.writeHexString(raw, value, unk3Size, unk3Size); } }
        public string Unk4 { get { return DataAccess.readHexString(raw, unk4Offset, unk4Size); } set { DataAccess.writeHexString(raw, value, unk4Size, unk4Size); } }
        public string Unk5 { get { return DataAccess.readHexString(raw, unk5Offset, unk5Size); } set { DataAccess.writeHexString(raw, value, unk5Size, unk5Size); } }
        public string Magnet { get { return DataAccess.readHexString(raw, magnetOffset, magnetSize); } set { DataAccess.writeHexString(raw, value, magnetOffset, magnetSize); } }
        public string Unk7 { get { return DataAccess.readHexString(raw, unk7Offset, unk7Size); } set { DataAccess.writeHexString(raw, value, unk7Size, unk7Size); } }
        public string Unk8 { get { return DataAccess.readHexString(raw, unk8Offset, unk8Size); } set { DataAccess.writeHexString(raw, value, unk8Size, unk8Size); } }
        public string Unk9 { get { return DataAccess.readHexString(raw, unk9Offset, unk9Size); } set { DataAccess.writeHexString(raw, value, unk9Size, unk9Size); } }
        public string Unk10 { get { return DataAccess.readHexString(raw, unk10Offset, unk10Size); } set { DataAccess.writeHexString(raw, value, unk10Size, unk10Size); } }
        public string Unk11 { get { return DataAccess.readHexString(raw, unk11Offset, unk11Size); } set { DataAccess.writeHexString(raw, value, unk11Size, unk11Size); } }
        public string Unk12 { get { return DataAccess.readHexString(raw, unk12Offset, unk12Size); } set { DataAccess.writeHexString(raw, value, unk12Size, unk12Size); } }
        public string Unk13 { get { return DataAccess.readHexString(raw, unk13Offset, unk13Size); } set { DataAccess.writeHexString(raw, value, unk13Size, unk13Size); } }
        public string Unk14 { get { return DataAccess.readHexString(raw, unk14Offset, unk14Size); } set { DataAccess.writeHexString(raw, value, unk14Size, unk14Size); } }
        public string Unk15 { get { return DataAccess.readHexString(raw, unk15Offset, unk15Size); } set { DataAccess.writeHexString(raw, value, unk15Size, unk15Size); } }
        public string Unk16 { get { return DataAccess.readHexString(raw, unk16Offset, unk16Size); } set { DataAccess.writeHexString(raw, value, unk16Size, unk16Size); } }
        public string Unk17 { get { return DataAccess.readHexString(raw, unk17Offset, unk17Size); } set { DataAccess.writeHexString(raw, value, unk17Size, unk17Size); } }
        public string Unk18 { get { return DataAccess.readHexString(raw, unk18Offset, unk18Size); } set { DataAccess.writeHexString(raw, value, unk18Size, unk18Size); } }
        public string Unk19 { get { return DataAccess.readHexString(raw, unk19Offset, unk19Size); } set { DataAccess.writeHexString(raw, value, unk19Size, unk19Size); } }
    }
}
