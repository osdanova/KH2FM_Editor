using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Fmlv
{
    public class FmlvItem : Str_EntryItem
    {
        public static readonly int entrySize = 8;
        // Data Location
        public int fieldsAOffset = 0, fieldsASize = 1;
        public int fieldsBOffset = 1, fieldsBSize = 1;
        public int rewardOffset = 2, rewardSize = 2;
        public int expOffset = 4, expSize = 4;

        public FmlvItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public FmlvItem(List<byte> rawData) : base(rawData)
        {
        }

        public string TypeValue
        {
            get { return FmlvTypes.getValue(Type); }
        }
        public int Type
        {
            get { return FieldsA / 16; }
            set
            {
                FieldsA -= (byte)(Type * 16);
                FieldsA += (byte)(value * 16);
                NotifyPropertyChanged(nameof(TypeValue));
                NotifyPropertyChanged(nameof(FieldsA));
            }
        }
        public int Level
        {
            get { return FieldsA % 16; }
            set
            {
                FieldsA -= (byte)Level;
                FieldsA += (byte)(value);
                NotifyPropertyChanged(nameof(FieldsA));
            }
        }
        public byte FieldsA
        {
            get { return DataAccess.readByte(raw, fieldsAOffset); }
            set { DataAccess.writeByte(raw, value, fieldsAOffset); }
        }
        public int AntiRate
        {
            get { return FieldsB / 16; }
            set
            {
                FieldsB -= (byte)(AntiRate * 16);
                FieldsB += (byte)(value * 16);
                NotifyPropertyChanged(nameof(FieldsB));
            }
        }
        public int AbilityLevel
{
            get { return FieldsB % 16; }
            set
            {
                FieldsB -= (byte)AbilityLevel;
                FieldsB += (byte)(value);
                NotifyPropertyChanged(nameof(FieldsB));
            }
        }
        public byte FieldsB
        {
            get { return DataAccess.readByte(raw, fieldsBOffset); }
            set { DataAccess.writeByte(raw, value, fieldsBOffset); }
        }
        public string RewardValue
        {
            get { return Items.getValue(Reward); }
        }
        public ushort Reward
        {
            get { return DataAccess.readUShort(raw, rewardOffset, rewardSize); }
            set { DataAccess.writeUShort(raw, value, rewardOffset, rewardSize); NotifyPropertyChanged(nameof(RewardValue)); }
        }
        public uint Exp
        {
            get { return DataAccess.readUInt(raw, expOffset, expSize); }
            set { DataAccess.writeUInt(raw, value, expOffset, expSize); }
        }
    }
}
