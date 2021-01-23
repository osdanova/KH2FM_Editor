using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Arif
{
    public class ArifItem : Str_EntryItem
    {
        // Data Location
        public static readonly int Size = 64;
        public int flagOffset = 0, flagSize = 4;
        public int reverbOffset = 4, reverbSize = 4;
        public int bgSet1Offset = 8, bgSet1Size = 4;
        public int bgSet2Offset = 12, bgSet2Size = 4;
        public int bgm1AOffset = 16, bgm1ASize = 2;
        public int bgm1BOffset = 18, bgm1BSize = 2;
        public int bgm2AOffset = 20, bgm2ASize = 2;
        public int bgm2BOffset = 22, bgm2BSize = 2;
        public int bgm3AOffset = 24, bgm3ASize = 2;
        public int bgm3BOffset = 26, bgm3BSize = 2;
        public int bgm4AOffset = 28, bgm4ASize = 2;
        public int bgm4BOffset = 30, bgm4BSize = 2;
        public int bgm5AOffset = 32, bgm5ASize = 2;
        public int bgm5BOffset = 34, bgm5BSize = 2;
        public int bgm6AOffset = 36, bgm6ASize = 2;
        public int bgm6BOffset = 38, bgm6BSize = 2;
        public int bgm7AOffset = 40, bgm7ASize = 2;
        public int bgm7BOffset = 42, bgm7BSize = 2;
        public int bgm8AOffset = 44, bgm8ASize = 2;
        public int bgm8BOffset = 46, bgm8BSize = 2;
        public int voiceOffset = 48, voiceSize = 2;
        public int navimapOffset = 50, navimapSize = 2;
        public int commandOffset = 52, commandSize = 1;
        public int reserve1Offset = 53, reserve1Size = 1;
        public int reserve2Offset = 54, reserve2Size = 1;
        public int reserve3Offset = 55, reserve3Size = 1;
        public int reserve4Offset = 56, reserve4Size = 1;
        public int reserve5Offset = 57, reserve5Size = 1;
        public int reserve6Offset = 58, reserve6Size = 1;
        public int reserve7Offset = 59, reserve7Size = 1;
        public int reserve8Offset = 60, reserve8Size = 1;
        public int reserve9Offset = 61, reserve9Size = 1;
        public int reserve10Offset = 62, reserve10Size = 1;
        public int reserve11Offset = 63, reserve11Size = 1;

        public ArifItem()
        {
            raw = FormatHandler.getByteListOfSize(Size);
        }
        public ArifItem(List<byte> rawData) : base(rawData)
        {
        }

        public uint Flag
        {
            get { return DataAccess.readUInt(raw, flagOffset, flagSize); }
            set { DataAccess.writeUInt(raw, value, flagOffset, flagSize); }
        }
        public int Reverb
        {
            get { return DataAccess.readInt(raw, reverbOffset, reverbSize); }
            set { DataAccess.writeInt(raw, value, reverbOffset, reverbSize); }
        }
        public int BgSet1
        {
            get { return DataAccess.readInt(raw, bgSet1Offset, bgSet1Size); }
            set { DataAccess.writeInt(raw, value, bgSet1Offset, bgSet1Size); }
        }
        public int BgSet2
        {
            get { return DataAccess.readInt(raw, bgSet2Offset, bgSet2Size); }
            set { DataAccess.writeInt(raw, value, bgSet2Offset, bgSet2Size); }
        }
        public ushort Bgm1A
        {
            get { return DataAccess.readUShort(raw, bgm1AOffset, bgm1ASize); }
            set { DataAccess.writeUShort(raw, value, bgm1AOffset, bgm1ASize); }
        }
        public ushort Bgm1B
        {
            get { return DataAccess.readUShort(raw, bgm1BOffset, bgm1BSize); }
            set { DataAccess.writeUShort(raw, value, bgm1BOffset, bgm1BSize); }
        }
        public ushort Bgm2A
        {
            get { return DataAccess.readUShort(raw, bgm2AOffset, bgm2ASize); }
            set { DataAccess.writeUShort(raw, value, bgm2AOffset, bgm2ASize); }
        }
        public ushort Bgm2B
        {
            get { return DataAccess.readUShort(raw, bgm2BOffset, bgm2BSize); }
            set { DataAccess.writeUShort(raw, value, bgm2BOffset, bgm2BSize); }
        }
        public ushort Bgm3A
        {
            get { return DataAccess.readUShort(raw, bgm3AOffset, bgm3ASize); }
            set { DataAccess.writeUShort(raw, value, bgm3AOffset, bgm3ASize); }
        }
        public ushort Bgm3B
        {
            get { return DataAccess.readUShort(raw, bgm3BOffset, bgm3BSize); }
            set { DataAccess.writeUShort(raw, value, bgm3BOffset, bgm3BSize); }
        }
        public ushort Bgm4A
        {
            get { return DataAccess.readUShort(raw, bgm4AOffset, bgm4ASize); }
            set { DataAccess.writeUShort(raw, value, bgm4AOffset, bgm4ASize); }
        }
        public ushort Bgm4B
        {
            get { return DataAccess.readUShort(raw, bgm4BOffset, bgm4BSize); }
            set { DataAccess.writeUShort(raw, value, bgm4BOffset, bgm4BSize); }
        }
        public ushort Bgm5A
        {
            get { return DataAccess.readUShort(raw, bgm5AOffset, bgm5ASize); }
            set { DataAccess.writeUShort(raw, value, bgm5AOffset, bgm5ASize); }
        }
        public ushort Bgm5B
        {
            get { return DataAccess.readUShort(raw, bgm5BOffset, bgm5BSize); }
            set { DataAccess.writeUShort(raw, value, bgm5BOffset, bgm5BSize); }
        }
        public ushort Bgm6A
        {
            get { return DataAccess.readUShort(raw, bgm6AOffset, bgm6ASize); }
            set { DataAccess.writeUShort(raw, value, bgm6AOffset, bgm6ASize); }
        }
        public ushort Bgm6B
        {
            get { return DataAccess.readUShort(raw, bgm6BOffset, bgm6BSize); }
            set { DataAccess.writeUShort(raw, value, bgm6BOffset, bgm6BSize); }
        }
        public ushort Bgm7A
        {
            get { return DataAccess.readUShort(raw, bgm7AOffset, bgm7ASize); }
            set { DataAccess.writeUShort(raw, value, bgm7AOffset, bgm7ASize); }
        }
        public ushort Bgm7B
        {
            get { return DataAccess.readUShort(raw, bgm7BOffset, bgm7BSize); }
            set { DataAccess.writeUShort(raw, value, bgm7BOffset, bgm7BSize); }
        }
        public ushort Bgm8A
        {
            get { return DataAccess.readUShort(raw, bgm8AOffset, bgm8ASize); }
            set { DataAccess.writeUShort(raw, value, bgm8AOffset, bgm8ASize); }
        }
        public ushort Bgm8B
        {
            get { return DataAccess.readUShort(raw, bgm8BOffset, bgm8BSize); }
            set { DataAccess.writeUShort(raw, value, bgm8BOffset, bgm8BSize); }
        }
        public ushort Voice
        {
            get { return DataAccess.readUShort(raw, voiceOffset, voiceSize); }
            set { DataAccess.writeUShort(raw, value, voiceOffset, voiceSize); }
        }
        public ushort Navimap
        {
            get { return DataAccess.readUShort(raw, navimapOffset, navimapSize); }
            set { DataAccess.writeUShort(raw, value, navimapOffset, navimapSize); }
        }
        public byte Command
        {
            get { return DataAccess.readByte(raw, commandOffset); }
            set { DataAccess.writeByte(raw, value, commandOffset); }
        }
        public byte Reserve1
        {
            get { return DataAccess.readByte(raw, reserve1Offset); }
            set { DataAccess.writeByte(raw, value, reserve1Offset); }
        }
        public byte Reserve2
        {
            get { return DataAccess.readByte(raw, reserve2Offset); }
            set { DataAccess.writeByte(raw, value, reserve2Offset); }
        }
        public byte Reserve3
        {
            get { return DataAccess.readByte(raw, reserve3Offset); }
            set { DataAccess.writeByte(raw, value, reserve3Offset); }
        }
        public byte Reserve4
        {
            get { return DataAccess.readByte(raw, reserve4Offset); }
            set { DataAccess.writeByte(raw, value, reserve4Offset); }
        }
        public byte Reserve5
        {
            get { return DataAccess.readByte(raw, reserve5Offset); }
            set { DataAccess.writeByte(raw, value, reserve5Offset); }
        }
        public byte Reserve6
        {
            get { return DataAccess.readByte(raw, reserve6Offset); }
            set { DataAccess.writeByte(raw, value, reserve6Offset); }
        }
        public byte Reserve7
        {
            get { return DataAccess.readByte(raw, reserve7Offset); }
            set { DataAccess.writeByte(raw, value, reserve7Offset); }
        }
        public byte Reserve8
        {
            get { return DataAccess.readByte(raw, reserve8Offset); }
            set { DataAccess.writeByte(raw, value, reserve8Offset); }
        }
        public byte Reserve9
        {
            get { return DataAccess.readByte(raw, reserve9Offset); }
            set { DataAccess.writeByte(raw, value, reserve9Offset); }
        }
        public byte Reserve10
        {
            get { return DataAccess.readByte(raw, reserve10Offset); }
            set { DataAccess.writeByte(raw, value, reserve10Offset); }
        }
        public byte Reserve11
        {
            get { return DataAccess.readByte(raw, reserve11Offset); }
            set { DataAccess.writeByte(raw, value, reserve11Offset); }
        }
    }
}
