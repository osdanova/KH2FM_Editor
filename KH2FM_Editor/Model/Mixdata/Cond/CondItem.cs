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
        public static readonly int unk04Offset = 4, unk04Size = 4;
        public static readonly int countOffset = 8, countSize = 2;
        public static readonly int unk10Offset = 10, unk10Size = 2;

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
        public string Reward
        {
            get { return DataAccess.readHexString(raw, rewardOffset, rewardSize); }
            set { DataAccess.writeHexString(raw, value, rewardOffset, rewardSize); }
        }
        public string Unk04
        {
            get { return DataAccess.readHexString(raw, unk04Offset, unk04Size); }
            set { DataAccess.writeHexString(raw, value, unk04Offset, unk04Size); }
        }
        public ushort Count
        {
            get { return DataAccess.readUShort(raw, countOffset, countSize); }
            set { DataAccess.writeUShort(raw, value, countOffset, countSize); }
        }
        public string Unk10
        {
            get { return DataAccess.readHexString(raw, unk10Offset, unk10Size); }
            set { DataAccess.writeHexString(raw, value, unk10Offset, unk10Size); }
        }
    }
}
