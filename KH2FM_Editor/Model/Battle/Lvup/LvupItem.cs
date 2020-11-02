using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Lvup
{
    class LvupItem : Str_EntryItem
    {
        public static readonly int entrySize = 16;
        // Data Location
        public int expOffset = 0, expSize = 4;
        public int strengthOffset = 4, strengthSize = 1;
        public int magicOffset = 5, magicSize = 1;
        public int defenseOffset = 6, defenseSize = 1;
        public int apOffset = 7, apSize = 1;
        public int abSwOffset = 8, abSwSize = 2;
        public int abShOffset = 10, abShSize = 2;
        public int abStOffset = 12, abStSize = 2;
        public int padOffset = 14, padSize = 2;

        public LvupItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public LvupItem(List<byte> rawData) : base(rawData)
        {
        }

        public uint Exp
        {
            get { return DataAccess.readUInt(raw, expOffset, expSize); }
            set { DataAccess.writeUInt(raw, value, expOffset, expSize); }
        }
        public byte Strength
        {
            get { return DataAccess.readByte(raw, strengthOffset); }
            set { DataAccess.writeByte(raw, value, strengthOffset); }
        }
        public byte Magic
        {
            get { return DataAccess.readByte(raw, magicOffset); }
            set { DataAccess.writeByte(raw, value, magicOffset); }
        }
        public byte Defense
        {
            get { return DataAccess.readByte(raw, defenseOffset); }
            set { DataAccess.writeByte(raw, value, defenseOffset); }
        }
        public byte Ap
        {
            get { return DataAccess.readByte(raw, apOffset); }
            set { DataAccess.writeByte(raw, value, apOffset); }
        }
        public string AbiSwordValue
        {
            get { return Items.getValue(AbiSword); }
        }
        public ushort AbiSword
        {
            get { return DataAccess.readUShort(raw, abSwOffset, abSwSize); }
            set { DataAccess.writeUShort(raw, value, abSwOffset, abSwSize); NotifyPropertyChanged(nameof(AbiSwordValue)); }
        }
        public string AbiShieldValue
        {
            get { return Items.getValue(AbiShield); }
        }
        public ushort AbiShield
        {
            get { return DataAccess.readUShort(raw, abShOffset, abShSize); }
            set { DataAccess.writeUShort(raw, value, abShOffset, abShSize); NotifyPropertyChanged(nameof(AbiShieldValue)); }
        }
        public string AbiStaffValue
        {
            get { return Items.getValue(AbiStaff); }
        }
        public ushort AbiStaff
        {
            get { return DataAccess.readUShort(raw, abStOffset, abStSize); }
            set { DataAccess.writeUShort(raw, value, abStOffset, abStSize); NotifyPropertyChanged(nameof(AbiStaffValue)); }
        }
        public ushort Padding
        {
            get { return DataAccess.readUShort(raw, padOffset, padSize); }
            set { DataAccess.writeUShort(raw, value, padOffset, padSize); }
        }
    }
}
