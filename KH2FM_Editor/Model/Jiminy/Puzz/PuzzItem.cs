using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Jiminy.Puzz
{
    class PuzzItem : Str_EntryItem
    {
        public static readonly int entrySize = 16;
        // Data Location
        public int idOffset = 0, idSize = 1;
        public int pieceDataOffset = 1, pieceDataSize = 1;
        public int nameOffset = 2, nameSize = 2;
        public int rewardOffset = 4, rewardSize = 2;
        public int filenameOffset = 6, filenameSize = 10;

        public PuzzItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public PuzzItem(List<byte> rawData) : base(rawData)
        {
        }

        public byte Id
        {
            get { return DataAccess.readByte(raw, idOffset); }
            set { DataAccess.writeByte(raw, value, idOffset); }
        }
        public string PieceData
        {
            get { return DataAccess.readHexString(raw, pieceDataOffset, pieceDataSize); }
            set { DataAccess.writeHexString(raw, value, pieceDataOffset, pieceDataSize); }
        }
        public ushort Name
        {
            get { return DataAccess.readUShort(raw, nameOffset, nameSize); }
            set { DataAccess.writeUShort(raw, value, nameOffset, nameSize); }
        }
        public string RewardValue
        {
            get { return Items.getValue(Reward); }
        }
        public ushort Reward
        {
            get { return DataAccess.readUShort(raw, rewardOffset, rewardSize); }
            set { DataAccess.writeUShort(raw, value, rewardOffset, rewardSize); }
        }
        public string Filename
        {
            get { return DataAccess.readString(raw, filenameOffset, filenameSize); }
            set { DataAccess.writeString(raw, value, filenameOffset, filenameSize); }
        }
    }
}
