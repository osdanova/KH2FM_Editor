using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KH2FM_Editor.Model.Battle.Przt
{
    class PrztItem : Str_EntryItem
    {
        public static readonly int entrySize = 24;
        // Data Location
        public int idOffset = 0, idSize = 2;
        public int hpSOffset = 2, hpSSize = 1;
        public int hpLOffset = 3, hpLSize = 1;
        public int munnyLOffset = 4, munnyLSize = 1;
        public int munnyMOffset = 5, munnyMSize = 1;
        public int munnySOffset = 6, munnySSize = 1;
        public int mpSOffset = 7, mpSSize = 1;
        public int mpLOffset = 8, mpLSize = 1;
        public int driveSOffset = 9, driveSSize = 1;
        public int driveLOffset = 10, driveLSize = 1;
        public int unk11Offset = 11, unk11Size = 1;
        public int drop1Offset = 12, drop1Size = 2;
        public int drop1ChanceOffset = 14, drop1ChanceSize = 2;
        public int drop2Offset = 16, drop2Size = 2;
        public int drop2ChanceOffset = 18, drop2ChanceSize = 2;
        public int drop3Offset = 20, drop3Size = 2;
        public int drop3ChanceOffset = 22, drop3ChanceSize = 2;

        public PrztItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public PrztItem(List<byte> rawData) : base(rawData)
        {
        }

        public ushort Id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); }
        }
        public byte HpS
        {
            get { return DataAccess.readByte(raw, hpSOffset); }
            set { DataAccess.writeByte(raw, value, hpSOffset); }
        }
        public byte HpL
        {
            get { return DataAccess.readByte(raw, hpLOffset); }
            set { DataAccess.writeByte(raw, value, hpLOffset); }
        }
        public byte MunnyL
        {
            get { return DataAccess.readByte(raw, munnyLOffset); }
            set { DataAccess.writeByte(raw, value, munnyLOffset); }
        }
        public byte MunnyM
        {
            get { return DataAccess.readByte(raw, munnyMOffset); }
            set { DataAccess.writeByte(raw, value, munnyMOffset); }
        }
        public byte MunnyS
        {
            get { return DataAccess.readByte(raw, munnySOffset); }
            set { DataAccess.writeByte(raw, value, munnySOffset); }
        }
        public byte MpS
        {
            get { return DataAccess.readByte(raw, mpSOffset); }
            set { DataAccess.writeByte(raw, value, mpSOffset); }
        }
        public byte MpL
        {
            get { return DataAccess.readByte(raw, mpLOffset); }
            set { DataAccess.writeByte(raw, value, mpLOffset); }
        }
        public byte DriveS
        {
            get { return DataAccess.readByte(raw, driveSOffset); }
            set { DataAccess.writeByte(raw, value, driveSOffset); }
        }
        public byte DriveL
        {
            get { return DataAccess.readByte(raw, driveLOffset); }
            set { DataAccess.writeByte(raw, value, driveLOffset); }
        }
        public byte Unk11
        {
            get { return DataAccess.readByte(raw, unk11Offset); }
            set { DataAccess.writeByte(raw, value, unk11Offset); }
        }
        public string Drop1Value
        {
            get { return Items.getValue(Drop1); }
        }
        public ushort Drop1
        {
            get { return DataAccess.readUShort(raw, drop1Offset, drop1Size); }
            set { DataAccess.writeUShort(raw, value, drop1Offset, drop1Size); NotifyPropertyChanged(nameof(Drop1Value)); }
        }
        public ushort Drop1Chance
        {
            get { return DataAccess.readUShort(raw, drop1ChanceOffset, drop1ChanceSize); }
            set { DataAccess.writeUShort(raw, value, drop1ChanceOffset, drop1ChanceSize); }
        }
        public string Drop2Value
        {
            get { return Items.getValue(Drop2); }
        }
        public ushort Drop2
        {
            get { return DataAccess.readUShort(raw, drop2Offset, drop2Size); }
            set { DataAccess.writeUShort(raw, value, drop2Offset, drop2Size); NotifyPropertyChanged(nameof(Drop2Value)); }
        }
        public ushort Drop2Chance
        {
            get { return DataAccess.readUShort(raw, drop2ChanceOffset, drop2ChanceSize); }
            set { DataAccess.writeUShort(raw, value, drop2ChanceOffset, drop2ChanceSize); }
        }
        public string Drop3Value
        {
            get { return Items.getValue(Drop3); }
        }
        public ushort Drop3
        {
            get { return DataAccess.readUShort(raw, drop3Offset, drop3Size); }
            set { DataAccess.writeUShort(raw, value, drop3Offset, drop3Size); NotifyPropertyChanged(nameof(Drop3Value)); }
        }
        public ushort Drop3Chance
        {
            get { return DataAccess.readUShort(raw, drop3ChanceOffset, drop3ChanceSize); }
            set { DataAccess.writeUShort(raw, value, drop3ChanceOffset, drop3ChanceSize); }
        }
    }
}
