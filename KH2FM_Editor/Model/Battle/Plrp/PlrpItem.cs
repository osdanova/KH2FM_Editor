using KH2FM_Editor.DataDictionary;
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
        //public int itemsOffset = 12, itemsSize = 116;
        public static readonly int item1Offset = 12, item1Size = 2;
        public static readonly int item2Offset = 14, item2Size = 2;
        public static readonly int item3Offset = 16, item3Size = 2;
        public static readonly int item4Offset = 18, item4Size = 2;
        public static readonly int item5Offset = 20, item5Size = 2;
        public static readonly int item6Offset = 22, item6Size = 2;
        public static readonly int item7Offset = 24, item7Size = 2;
        public static readonly int item8Offset = 26, item8Size = 2;
        public static readonly int item9Offset = 28, item9Size = 2;
        public static readonly int item10Offset = 30, item10Size = 2;
        public static readonly int item11Offset = 32, item11Size = 2;
        public static readonly int item12Offset = 34, item12Size = 2;
        public static readonly int item13Offset = 36, item13Size = 2;
        public static readonly int item14Offset = 38, item14Size = 2;
        public static readonly int item15Offset = 40, item15Size = 2;
        public static readonly int item16Offset = 42, item16Size = 2;
        public static readonly int item17Offset = 44, item17Size = 2;
        public static readonly int item18Offset = 46, item18Size = 2;
        public static readonly int item19Offset = 48, item19Size = 2;
        public static readonly int item20Offset = 50, item20Size = 2;
        public static readonly int item21Offset = 52, item21Size = 2;
        public static readonly int item22Offset = 54, item22Size = 2;
        public static readonly int item23Offset = 56, item23Size = 2;
        public static readonly int item24Offset = 58, item24Size = 2;
        public static readonly int item25Offset = 60, item25Size = 2;
        public static readonly int item26Offset = 62, item26Size = 2;
        public static readonly int item27Offset = 64, item27Size = 2;
        public static readonly int item28Offset = 66, item28Size = 2;
        public static readonly int item29Offset = 68, item29Size = 2;
        public static readonly int item30Offset = 70, item30Size = 2;
        public static readonly int item31Offset = 72, item31Size = 2;
        public static readonly int item32Offset = 74, item32Size = 2;
        public static readonly int item33Offset = 76, item33Size = 2;
        public static readonly int item34Offset = 78, item34Size = 2;
        public static readonly int item35Offset = 80, item35Size = 2;
        public static readonly int item36Offset = 82, item36Size = 2;
        public static readonly int item37Offset = 84, item37Size = 2;
        public static readonly int item38Offset = 86, item38Size = 2;
        public static readonly int item39Offset = 88, item39Size = 2;
        public static readonly int item40Offset = 90, item40Size = 2;
        public static readonly int item41Offset = 92, item41Size = 2;
        public static readonly int item42Offset = 94, item42Size = 2;
        public static readonly int item43Offset = 96, item43Size = 2;
        public static readonly int item44Offset = 98, item44Size = 2;
        public static readonly int item45Offset = 100, item45Size = 2;
        public static readonly int item46Offset = 102, item46Size = 2;
        public static readonly int item47Offset = 104, item47Size = 2;
        public static readonly int item48Offset = 106, item48Size = 2;
        public static readonly int item49Offset = 108, item49Size = 2;
        public static readonly int item50Offset = 110, item50Size = 2;


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
        }/*
        public string Items
        {
            get { return DataAccess.readHexString(raw, itemsOffset, itemsSize); }
            set { DataAccess.writeHexString(raw, value, itemsOffset, itemsSize); }
        }*/
        public string Item1Value
        {
            get { return Items.getValue(Item1); }
        }
        public ushort Item1
        {
            get { return DataAccess.readUShort(raw, item1Offset, item1Size); }
            set { DataAccess.writeUShort(raw, value, item1Offset, item1Size); NotifyPropertyChanged(nameof(Item1Value)); }
        }
        public string Item2Value
        {
            get { return Items.getValue(Item2); }
        }
        public ushort Item2
        {
            get { return DataAccess.readUShort(raw, item2Offset, item2Size); }
            set { DataAccess.writeUShort(raw, value, item2Offset, item2Size); NotifyPropertyChanged(nameof(Item2Value)); }
        }
        public string Item3Value
        {
            get { return Items.getValue(Item3); }
        }
        public ushort Item3
        {
            get { return DataAccess.readUShort(raw, item3Offset, item3Size); }
            set { DataAccess.writeUShort(raw, value, item3Offset, item3Size); NotifyPropertyChanged(nameof(Item3Value)); }
        }
        public string Item4Value
        {
            get { return Items.getValue(Item4); }
        }
        public ushort Item4
        {
            get { return DataAccess.readUShort(raw, item4Offset, item4Size); }
            set { DataAccess.writeUShort(raw, value, item4Offset, item4Size); NotifyPropertyChanged(nameof(Item4Value)); }
        }
        public string Item5Value
        {
            get { return Items.getValue(Item5); }
        }
        public ushort Item5
        {
            get { return DataAccess.readUShort(raw, item5Offset, item5Size); }
            set { DataAccess.writeUShort(raw, value, item5Offset, item5Size); NotifyPropertyChanged(nameof(Item5Value)); }
        }
        public string Item6Value
        {
            get { return Items.getValue(Item6); }
        }
        public ushort Item6
        {
            get { return DataAccess.readUShort(raw, item6Offset, item6Size); }
            set { DataAccess.writeUShort(raw, value, item6Offset, item6Size); NotifyPropertyChanged(nameof(Item6Value)); }
        }
        public string Item7Value
        {
            get { return Items.getValue(Item7); }
        }
        public ushort Item7
        {
            get { return DataAccess.readUShort(raw, item7Offset, item7Size); }
            set { DataAccess.writeUShort(raw, value, item7Offset, item7Size); NotifyPropertyChanged(nameof(Item7Value)); }
        }
        public string Item8Value
        {
            get { return Items.getValue(Item8); }
        }
        public ushort Item8
        {
            get { return DataAccess.readUShort(raw, item8Offset, item8Size); }
            set { DataAccess.writeUShort(raw, value, item8Offset, item8Size); NotifyPropertyChanged(nameof(Item8Value)); }
        }
        public string Item9Value
        {
            get { return Items.getValue(Item9); }
        }
        public ushort Item9
        {
            get { return DataAccess.readUShort(raw, item9Offset, item9Size); }
            set { DataAccess.writeUShort(raw, value, item9Offset, item9Size); NotifyPropertyChanged(nameof(Item9Value)); }
        }
        public string Item10Value
        {
            get { return Items.getValue(Item10); }
        }
        public ushort Item10
        {
            get { return DataAccess.readUShort(raw, item10Offset, item10Size); }
            set { DataAccess.writeUShort(raw, value, item10Offset, item10Size); NotifyPropertyChanged(nameof(Item10Value)); }
        }
        public string Item11Value
        {
            get { return Items.getValue(Item11); }
        }
        public ushort Item11
        {
            get { return DataAccess.readUShort(raw, item11Offset, item11Size); }
            set { DataAccess.writeUShort(raw, value, item11Offset, item11Size); NotifyPropertyChanged(nameof(Item11Value)); }
        }
        public string Item12Value
        {
            get { return Items.getValue(Item12); }
        }
        public ushort Item12
        {
            get { return DataAccess.readUShort(raw, item12Offset, item12Size); }
            set { DataAccess.writeUShort(raw, value, item12Offset, item12Size); NotifyPropertyChanged(nameof(Item12Value)); }
        }
        public string Item13Value
        {
            get { return Items.getValue(Item13); }
        }
        public ushort Item13
        {
            get { return DataAccess.readUShort(raw, item13Offset, item13Size); }
            set { DataAccess.writeUShort(raw, value, item13Offset, item13Size); NotifyPropertyChanged(nameof(Item13Value)); }
        }
        public string Item14Value
        {
            get { return Items.getValue(Item14); }
        }
        public ushort Item14
        {
            get { return DataAccess.readUShort(raw, item14Offset, item14Size); }
            set { DataAccess.writeUShort(raw, value, item14Offset, item14Size); NotifyPropertyChanged(nameof(Item14Value)); }
        }
        public string Item15Value
        {
            get { return Items.getValue(Item15); }
        }
        public ushort Item15
        {
            get { return DataAccess.readUShort(raw, item15Offset, item15Size); }
            set { DataAccess.writeUShort(raw, value, item15Offset, item15Size); NotifyPropertyChanged(nameof(Item15Value)); }
        }
        public string Item16Value
        {
            get { return Items.getValue(Item16); }
        }
        public ushort Item16
        {
            get { return DataAccess.readUShort(raw, item16Offset, item16Size); }
            set { DataAccess.writeUShort(raw, value, item16Offset, item16Size); NotifyPropertyChanged(nameof(Item16Value)); }
        }
        public string Item17Value
        {
            get { return Items.getValue(Item17); }
        }
        public ushort Item17
        {
            get { return DataAccess.readUShort(raw, item17Offset, item17Size); }
            set { DataAccess.writeUShort(raw, value, item17Offset, item17Size); NotifyPropertyChanged(nameof(Item17Value)); }
        }
        public string Item18Value
        {
            get { return Items.getValue(Item18); }
        }
        public ushort Item18
        {
            get { return DataAccess.readUShort(raw, item18Offset, item18Size); }
            set { DataAccess.writeUShort(raw, value, item18Offset, item18Size); NotifyPropertyChanged(nameof(Item18Value)); }
        }
        public string Item19Value
        {
            get { return Items.getValue(Item19); }
        }
        public ushort Item19
        {
            get { return DataAccess.readUShort(raw, item19Offset, item19Size); }
            set { DataAccess.writeUShort(raw, value, item19Offset, item19Size); NotifyPropertyChanged(nameof(Item19Value)); }
        }
        public string Item20Value
        {
            get { return Items.getValue(Item20); }
        }
        public ushort Item20
        {
            get { return DataAccess.readUShort(raw, item20Offset, item20Size); }
            set { DataAccess.writeUShort(raw, value, item20Offset, item20Size); NotifyPropertyChanged(nameof(Item20Value)); }
        }
        public string Item21Value
        {
            get { return Items.getValue(Item21); }
        }
        public ushort Item21
        {
            get { return DataAccess.readUShort(raw, item21Offset, item21Size); }
            set { DataAccess.writeUShort(raw, value, item21Offset, item21Size); NotifyPropertyChanged(nameof(Item21Value)); }
        }
        public string Item22Value
        {
            get { return Items.getValue(Item22); }
        }
        public ushort Item22
        {
            get { return DataAccess.readUShort(raw, item22Offset, item22Size); }
            set { DataAccess.writeUShort(raw, value, item22Offset, item22Size); NotifyPropertyChanged(nameof(Item22Value)); }
        }
        public string Item23Value
        {
            get { return Items.getValue(Item23); }
        }
        public ushort Item23
        {
            get { return DataAccess.readUShort(raw, item23Offset, item23Size); }
            set { DataAccess.writeUShort(raw, value, item23Offset, item23Size); NotifyPropertyChanged(nameof(Item23Value)); }
        }
        public string Item24Value
        {
            get { return Items.getValue(Item24); }
        }
        public ushort Item24
        {
            get { return DataAccess.readUShort(raw, item24Offset, item24Size); }
            set { DataAccess.writeUShort(raw, value, item24Offset, item24Size); NotifyPropertyChanged(nameof(Item24Value)); }
        }
        public string Item25Value
        {
            get { return Items.getValue(Item25); }
        }
        public ushort Item25
        {
            get { return DataAccess.readUShort(raw, item25Offset, item25Size); }
            set { DataAccess.writeUShort(raw, value, item25Offset, item25Size); NotifyPropertyChanged(nameof(Item25Value)); }
        }
        public string Item26Value
        {
            get { return Items.getValue(Item26); }
        }
        public ushort Item26
        {
            get { return DataAccess.readUShort(raw, item26Offset, item26Size); }
            set { DataAccess.writeUShort(raw, value, item26Offset, item26Size); NotifyPropertyChanged(nameof(Item26Value)); }
        }
        public string Item27Value
        {
            get { return Items.getValue(Item27); }
        }
        public ushort Item27
        {
            get { return DataAccess.readUShort(raw, item27Offset, item27Size); }
            set { DataAccess.writeUShort(raw, value, item27Offset, item27Size); NotifyPropertyChanged(nameof(Item27Value)); }
        }
        public string Item28Value
        {
            get { return Items.getValue(Item28); }
        }
        public ushort Item28
        {
            get { return DataAccess.readUShort(raw, item28Offset, item28Size); }
            set { DataAccess.writeUShort(raw, value, item28Offset, item28Size); NotifyPropertyChanged(nameof(Item28Value)); }
        }
        public string Item29Value
        {
            get { return Items.getValue(Item29); }
        }
        public ushort Item29
        {
            get { return DataAccess.readUShort(raw, item29Offset, item29Size); }
            set { DataAccess.writeUShort(raw, value, item29Offset, item29Size); NotifyPropertyChanged(nameof(Item29Value)); }
        }
        public string Item30Value
        {
            get { return Items.getValue(Item30); }
        }
        public ushort Item30
        {
            get { return DataAccess.readUShort(raw, item30Offset, item30Size); }
            set { DataAccess.writeUShort(raw, value, item30Offset, item30Size); NotifyPropertyChanged(nameof(Item30Value)); }
        }
        public string Item31Value
        {
            get { return Items.getValue(Item31); }
        }
        public ushort Item31
        {
            get { return DataAccess.readUShort(raw, item31Offset, item31Size); }
            set { DataAccess.writeUShort(raw, value, item31Offset, item31Size); NotifyPropertyChanged(nameof(Item31Value)); }
        }
        public string Item32Value
        {
            get { return Items.getValue(Item32); }
        }
        public ushort Item32
        {
            get { return DataAccess.readUShort(raw, item32Offset, item32Size); }
            set { DataAccess.writeUShort(raw, value, item32Offset, item32Size); NotifyPropertyChanged(nameof(Item32Value)); }
        }
        public string Item33Value
        {
            get { return Items.getValue(Item33); }
        }
        public ushort Item33
        {
            get { return DataAccess.readUShort(raw, item33Offset, item33Size); }
            set { DataAccess.writeUShort(raw, value, item33Offset, item33Size); NotifyPropertyChanged(nameof(Item33Value)); }
        }
        public string Item34Value
        {
            get { return Items.getValue(Item34); }
        }
        public ushort Item34
        {
            get { return DataAccess.readUShort(raw, item34Offset, item34Size); }
            set { DataAccess.writeUShort(raw, value, item34Offset, item34Size); NotifyPropertyChanged(nameof(Item34Value)); }
        }
        public string Item35Value
        {
            get { return Items.getValue(Item35); }
        }
        public ushort Item35
        {
            get { return DataAccess.readUShort(raw, item35Offset, item35Size); }
            set { DataAccess.writeUShort(raw, value, item35Offset, item35Size); NotifyPropertyChanged(nameof(Item35Value)); }
        }
        public string Item36Value
        {
            get { return Items.getValue(Item36); }
        }
        public ushort Item36
        {
            get { return DataAccess.readUShort(raw, item36Offset, item36Size); }
            set { DataAccess.writeUShort(raw, value, item36Offset, item36Size); NotifyPropertyChanged(nameof(Item36Value)); }
        }
        public string Item37Value
        {
            get { return Items.getValue(Item37); }
        }
        public ushort Item37
        {
            get { return DataAccess.readUShort(raw, item37Offset, item37Size); }
            set { DataAccess.writeUShort(raw, value, item37Offset, item37Size); NotifyPropertyChanged(nameof(Item37Value)); }
        }
        public string Item38Value
        {
            get { return Items.getValue(Item38); }
        }
        public ushort Item38
        {
            get { return DataAccess.readUShort(raw, item38Offset, item38Size); }
            set { DataAccess.writeUShort(raw, value, item38Offset, item38Size); NotifyPropertyChanged(nameof(Item38Value)); }
        }
        public string Item39Value
        {
            get { return Items.getValue(Item39); }
        }
        public ushort Item39
        {
            get { return DataAccess.readUShort(raw, item39Offset, item39Size); }
            set { DataAccess.writeUShort(raw, value, item39Offset, item39Size); NotifyPropertyChanged(nameof(Item39Value)); }
        }
        public string Item40Value
        {
            get { return Items.getValue(Item40); }
        }
        public ushort Item40
        {
            get { return DataAccess.readUShort(raw, item40Offset, item40Size); }
            set { DataAccess.writeUShort(raw, value, item40Offset, item40Size); NotifyPropertyChanged(nameof(Item40Value)); }
        }
        public string Item41Value
        {
            get { return Items.getValue(Item41); }
        }
        public ushort Item41
        {
            get { return DataAccess.readUShort(raw, item41Offset, item41Size); }
            set { DataAccess.writeUShort(raw, value, item41Offset, item41Size); NotifyPropertyChanged(nameof(Item41Value)); }
        }
        public string Item42Value
        {
            get { return Items.getValue(Item42); }
        }
        public ushort Item42
        {
            get { return DataAccess.readUShort(raw, item42Offset, item42Size); }
            set { DataAccess.writeUShort(raw, value, item42Offset, item42Size); NotifyPropertyChanged(nameof(Item42Value)); }
        }
        public string Item43Value
        {
            get { return Items.getValue(Item43); }
        }
        public ushort Item43
        {
            get { return DataAccess.readUShort(raw, item43Offset, item43Size); }
            set { DataAccess.writeUShort(raw, value, item43Offset, item43Size); NotifyPropertyChanged(nameof(Item43Value)); }
        }
        public string Item44Value
        {
            get { return Items.getValue(Item44); }
        }
        public ushort Item44
        {
            get { return DataAccess.readUShort(raw, item44Offset, item44Size); }
            set { DataAccess.writeUShort(raw, value, item44Offset, item44Size); NotifyPropertyChanged(nameof(Item44Value)); }
        }
        public string Item45Value
        {
            get { return Items.getValue(Item45); }
        }
        public ushort Item45
        {
            get { return DataAccess.readUShort(raw, item45Offset, item45Size); }
            set { DataAccess.writeUShort(raw, value, item45Offset, item45Size); NotifyPropertyChanged(nameof(Item45Value)); }
        }
        public string Item46Value
        {
            get { return Items.getValue(Item46); }
        }
        public ushort Item46
        {
            get { return DataAccess.readUShort(raw, item46Offset, item46Size); }
            set { DataAccess.writeUShort(raw, value, item46Offset, item46Size); NotifyPropertyChanged(nameof(Item46Value)); }
        }
        public string Item47Value
        {
            get { return Items.getValue(Item47); }
        }
        public ushort Item47
        {
            get { return DataAccess.readUShort(raw, item47Offset, item47Size); }
            set { DataAccess.writeUShort(raw, value, item47Offset, item47Size); NotifyPropertyChanged(nameof(Item47Value)); }
        }
        public string Item48Value
        {
            get { return Items.getValue(Item48); }
        }
        public ushort Item48
        {
            get { return DataAccess.readUShort(raw, item48Offset, item48Size); }
            set { DataAccess.writeUShort(raw, value, item48Offset, item48Size); NotifyPropertyChanged(nameof(Item48Value)); }
        }
        public string Item49Value
        {
            get { return Items.getValue(Item49); }
        }
        public ushort Item49
        {
            get { return DataAccess.readUShort(raw, item49Offset, item49Size); }
            set { DataAccess.writeUShort(raw, value, item49Offset, item49Size); NotifyPropertyChanged(nameof(Item49Value)); }
        }
        public string Item50Value
        {
            get { return Items.getValue(Item50); }
        }
        public ushort Item50
        {
            get { return DataAccess.readUShort(raw, item50Offset, item50Size); }
            set { DataAccess.writeUShort(raw, value, item50Offset, item50Size); NotifyPropertyChanged(nameof(Item50Value)); }
        }
    }
}
