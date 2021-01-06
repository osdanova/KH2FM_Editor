using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Mixdata.Cond
{
    class CondItem : Str_EntryItem
    {
        public static readonly int entrySize = 12;
        // Data Location
        public static readonly int idOffset = 0, idSize = 2;
        public static readonly int rewardOffset = 2, rewardSize = 2;
        public static readonly int rewardTypeOffset = 4, rewardTypeSize = 1;
        public static readonly int typeOffset = 5, typeSize = 1;
        public static readonly int rankOffset = 6, rankSize = 1;
        public static readonly int condTypeOffset = 7, condTypeSize = 1;
        public static readonly int countOffset = 8, countSize = 2;
        public static readonly int unlockFlagOffset = 10, unlockFlagSize = 2;

        public CondItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public CondItem(List<byte> rawData) : base(rawData)
        {
        }

        public ushort Id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); }
        }
        public string RewardValue
        {
            get
            {
                if (RewardType == 0) return Items.getValue(Reward);
                else return "Upgrade!";
            }
        }
        public ushort Reward
        {
            get { return DataAccess.readUShort(raw, rewardOffset, rewardSize); }
            set { DataAccess.writeUShort(raw, value, rewardOffset, rewardSize); NotifyPropertyChanged(nameof(RewardValue)); }
        }
        public string RewardTypeValue
        {
            get
            {
                if (RewardType == 0) return "Item";
                if (RewardType == 1) return "Upgrade";
                return "";
            }
        }
        public byte RewardType
        {
            get { return DataAccess.readByte(raw, rewardTypeOffset); }
            set { DataAccess.writeByte(raw, value, rewardTypeOffset); NotifyPropertyChanged(nameof(RewardTypeValue)); }
        }
        public byte Type
        {
            get { return DataAccess.readByte(raw, typeOffset); }
            set { DataAccess.writeByte(raw, value, typeOffset); }
        }
        public byte Rank
        {
            get { return DataAccess.readByte(raw, rankOffset); }
            set { DataAccess.writeByte(raw, value, rankOffset); }
        }
        public string CondTypeValue
        {
            get
            {
                if (CondType == 0) return "Stack";
                if (CondType == 1) return "Collect";
                return "";
            }
        }
        public byte CondType
        {
            get { return DataAccess.readByte(raw, condTypeOffset); }
            set { DataAccess.writeByte(raw, value, condTypeOffset); NotifyPropertyChanged(nameof(CondTypeValue)); }
        }
        public ushort Count
        {
            get { return DataAccess.readUShort(raw, countOffset, countSize); }
            set { DataAccess.writeUShort(raw, value, countOffset, countSize); }
        }
        public string UnlockFlag
        {
            get { return DataAccess.readHexString(raw, unlockFlagOffset, unlockFlagSize); }
            set { DataAccess.writeHexString(raw, value, unlockFlagOffset, unlockFlagSize); }
        }
    }
}
