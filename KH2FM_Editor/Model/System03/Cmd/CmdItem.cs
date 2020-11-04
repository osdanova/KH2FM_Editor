using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Cmd
{
    class CmdItem : Str_EntryItem
    {
        public static readonly int entrySize = 48;
        // Data Location
        public static readonly int idOffset = 0, idSize = 2;
        public static readonly int unkId1Offset = 2, unkId1Size = 2;
        public static readonly int unkId2Offset = 4, unkId2Size = 2;
        public static readonly int unk6Offset = 6, unk6Size = 1;
        public static readonly int unk7Offset = 7, unk7Size = 1;
        public static readonly int unk8Offset = 8, unk8Size = 2;
        public static readonly int unk10Offset = 10, unk10Size = 2;
        public static readonly int unk12Offset = 12, unk12Size = 4;
        public static readonly int unk16Offset = 16, unk16Size = 2;
        public static readonly int unk18Offset = 18, unk18Size = 2;
        public static readonly int unk20Offset = 20, unk20Size = 4;
        public static readonly int unk24Offset = 24, unk24Size = 1;
        public static readonly int unk25Offset = 25, unk25Size = 1;
        public static readonly int unk26Offset = 26, unk26Size = 2;
        public static readonly int mpCostOffset = 28, mpCostSize = 2;
        public static readonly int unk30Offset = 30, unk30Size = 4;
        public static readonly int unk34Offset = 34, unk34Size = 2;
        public static readonly int unk36Offset = 36, unk36Size = 1;
        public static readonly int unk37Offset = 37, unk37Size = 1;
        public static readonly int unk38Offset = 38, unk38Size = 2;
        public static readonly int unk40Offset = 40, unk40Size = 2;
        public static readonly int unk42Offset = 42, unk42Size = 2;
        public static readonly int unk44Offset = 44, unk44Size = 2;
        public static readonly int unk46Offset = 46, unk46Size = 2;

        public CmdItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public CmdItem(List<byte> rawData) : base(rawData)
        {
        }

        public string CommandValue
        {
            get { return Commands.getValue(Id); }
        }
        public ushort Id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); NotifyPropertyChanged(nameof(CommandValue)); }
        }
        public ushort UnkId1
        {
            get { return DataAccess.readUShort(raw, unkId1Offset, unkId1Size); }
            set { DataAccess.writeUShort(raw, value, unkId1Offset, unkId1Size); }
        }
        public ushort UnkId2
        {
            get { return DataAccess.readUShort(raw, unkId2Offset, unkId2Size); }
            set { DataAccess.writeUShort(raw, value, unkId2Offset, unkId2Size); }
        }
        public string Unk6
        {
            get { return DataAccess.readHexString(raw, unk6Offset, unk6Size); }
            set { DataAccess.writeHexString(raw, value, unk6Offset, unk6Size); }
        }
        public string Unk7
        {
            get { return DataAccess.readHexString(raw, unk7Offset, unk7Size); }
            set { DataAccess.writeHexString(raw, value, unk7Offset, unk7Size); }
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
        public string Unk12
        {
            get { return DataAccess.readHexString(raw, unk12Offset, unk12Size); }
            set { DataAccess.writeHexString(raw, value, unk12Offset, unk12Size); }
        }
        public string Unk16
        {
            get { return DataAccess.readHexString(raw, unk16Offset, unk16Size); }
            set { DataAccess.writeHexString(raw, value, unk16Offset, unk16Size); }
        }
        public string Unk18
        {
            get { return DataAccess.readHexString(raw, unk18Offset, unk18Size); }
            set { DataAccess.writeHexString(raw, value, unk18Offset, unk18Size); }
        }
        public string Unk20
        {
            get { return DataAccess.readHexString(raw, unk20Offset, unk20Size); }
            set { DataAccess.writeHexString(raw, value, unk20Offset, unk20Size); }
        }
        public string Unk24
        {
            get { return DataAccess.readHexString(raw, unk24Offset, unk24Size); }
            set { DataAccess.writeHexString(raw, value, unk24Offset, unk24Size); }
        }
        public string Unk25
        {
            get { return DataAccess.readHexString(raw, unk25Offset, unk25Size); }
            set { DataAccess.writeHexString(raw, value, unk25Offset, unk25Size); }
        }
        public string Unk26
        {
            get { return DataAccess.readHexString(raw, unk26Offset, unk26Size); }
            set { DataAccess.writeHexString(raw, value, unk26Offset, unk26Size); }
        }
        public ushort MpCost
        {
            get { return DataAccess.readUShort(raw, mpCostOffset, mpCostSize); }
            set { DataAccess.writeUShort(raw, value, mpCostOffset, mpCostSize); }
        }
        public string Unk30
        {
            get { return DataAccess.readHexString(raw, unk30Offset, unk30Size); }
            set { DataAccess.writeHexString(raw, value, unk30Offset, unk30Size); }
        }
        public string Unk34
        {
            get { return DataAccess.readHexString(raw, unk34Offset, unk34Size); }
            set { DataAccess.writeHexString(raw, value, unk34Offset, unk34Size); }
        }
        public string Unk36
        {
            get { return DataAccess.readHexString(raw, unk36Offset, unk36Size); }
            set { DataAccess.writeHexString(raw, value, unk36Offset, unk36Size); }
        }
        public string Unk37
        {
            get { return DataAccess.readHexString(raw, unk37Offset, unk37Size); }
            set { DataAccess.writeHexString(raw, value, unk37Offset, unk37Size); }
        }
        public string Unk38
        {
            get { return DataAccess.readHexString(raw, unk38Offset, unk38Size); }
            set { DataAccess.writeHexString(raw, value, unk38Offset, unk38Size); }
        }
        public string Unk40
        {
            get { return DataAccess.readHexString(raw, unk40Offset, unk40Size); }
            set { DataAccess.writeHexString(raw, value, unk40Offset, unk40Size); }
        }
        public string Unk42
        {
            get { return DataAccess.readHexString(raw, unk42Offset, unk42Size); }
            set { DataAccess.writeHexString(raw, value, unk42Offset, unk42Size); }
        }
        public string Unk44
        {
            get { return DataAccess.readHexString(raw, unk44Offset, unk44Size); }
            set { DataAccess.writeHexString(raw, value, unk44Offset, unk44Size); }
        }
        public string Unk46
        {
            get { return DataAccess.readHexString(raw, unk46Offset, unk46Size); }
            set { DataAccess.writeHexString(raw, value, unk46Offset, unk46Size); }
        }
    }
}
