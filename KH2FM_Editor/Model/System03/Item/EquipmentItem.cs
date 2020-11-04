using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Item
{
    class EquipmentItem : Str_EntryItem
    {
        public static readonly int entrySize = 16;
        // Data Location
        public int idOffset = 0, idSize = 2;
        public int abilityOffset = 2, abilitySize = 2;
        public int strengthOffset = 4, strengthSize = 1;
        public int magicOffset = 5, magicSize = 1;
        public int defenseOffset = 6, defenseSize = 1;
        public int apOffset = 7, apSize = 1;
        public int physResOffset = 8, physResSize = 1;
        public int fireResOffset = 9, fireResSize = 1;
        public int blizResOffset = 10, blizResSize = 1;
        public int thunResOffset = 11, thunResSize = 1;
        public int darkResOffset = 12, darkResSize = 1;
        public int neutralResOffset = 13, neutralResSize = 1;
        public int generalResOffset = 14, generalResSize = 1;
        public int paddingOffset = 15, paddingSize = 1;

        public EquipmentItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public EquipmentItem(List<byte> rawData) : base(rawData)
        {
        }

        public string EquipmentValue
        {
            get { return Equipment.getValue(Id); }
        }
        public ushort Id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); NotifyPropertyChanged(nameof(EquipmentValue)); }
        }
        public string AbilityValue
        {
            get { return Items.getValue(Ability); }
        }
        public ushort Ability
        {
            get { return DataAccess.readUShort(raw, abilityOffset, abilitySize); }
            set { DataAccess.writeUShort(raw, value, abilityOffset, abilitySize); NotifyPropertyChanged(nameof(AbilityValue)); }
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
        public byte PhysRes
        {
            get { return DataAccess.readByte(raw, physResOffset); }
            set { DataAccess.writeByte(raw, value, physResOffset); }
        }
        public byte FireRes
        {
            get { return DataAccess.readByte(raw, fireResOffset); }
            set { DataAccess.writeByte(raw, value, fireResOffset); }
        }
        public byte BlizRes
        {
            get { return DataAccess.readByte(raw, blizResOffset); }
            set { DataAccess.writeByte(raw, value, blizResOffset); }
        }
        public byte ThunRes
        {
            get { return DataAccess.readByte(raw, thunResOffset); }
            set { DataAccess.writeByte(raw, value, thunResOffset); }
        }
        public byte DarkRes
        {
            get { return DataAccess.readByte(raw, darkResOffset); }
            set { DataAccess.writeByte(raw, value, darkResOffset); }
        }
        public byte NeutralRes
        {
            get { return DataAccess.readByte(raw, neutralResOffset); }
            set { DataAccess.writeByte(raw, value, neutralResOffset); }
        }
        public byte GeneralRes
        {
            get { return DataAccess.readByte(raw, generalResOffset); }
            set { DataAccess.writeByte(raw, value, generalResOffset); }
        }
    }
}
