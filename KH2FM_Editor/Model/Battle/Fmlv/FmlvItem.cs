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
        public int idOffset = 0, idSize = 1;
        public int abilityLevelOffset = 1, abilityLevelSize = 1;
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
            get { return FmlvTypes.getValue(Id/16); }
        }
        public int LevelValue
        {
            get { return Id % 16; }
        }
        public byte Id
        {
            get { return DataAccess.readByte(raw, idOffset); }
            set { DataAccess.writeByte(raw, value, idOffset); NotifyPropertyChanged(nameof(TypeValue)); NotifyPropertyChanged(nameof(LevelValue)); }
        }
        public string IdAsHex
        {
            get { return DataAccess.readHexString(raw, idOffset, idSize); }
            set { DataAccess.writeHexString(raw, value, idOffset, idSize); }
        }
        public byte AbilityLevel
        {
            get { return DataAccess.readByte(raw, abilityLevelOffset); }
            set { DataAccess.writeByte(raw, value, abilityLevelOffset); }
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
