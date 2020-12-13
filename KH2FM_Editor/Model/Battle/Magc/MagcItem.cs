using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Magc
{
    class MagcItem : Str_EntryItem
    {
        public static readonly int entrySize = 56;
        // Data Location
        public int typeIdOffset = 0, typeIdSize = 1;
        public int levelIdOffset = 1, levelIdSize = 1;
        public int unk2Offset = 2, unk2Size = 2;
        public int filenameOffset = 4, filenameSize = 32;
        public int unk36Offset = 36, unk36Size = 2;
        public int commandOffset = 38, commandSize = 2;
        public int groundAnimOffset = 40, groundAnimSize = 2;
        public int groundUnkOffset = 42, groundUnkSize = 2;
        public int airAnimOffset = 44, airAnimSize = 2;
        public int airUnkOffset = 46, airUnkSize = 2;
        public int finishAnimOffset = 48, finishAnimSize = 2;
        public int finishUnkOffset = 50, finishUnkSize = 2;
        public int unk52Offset = 52, unk52Size = 1;
        public int unk53Offset = 53, unk53Size = 1;
        public int unk54Offset = 54, unk54Size = 1;
        public int paddingOffset = 55, paddingSize = 1;

        public MagcItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public MagcItem(List<byte> rawData) : base(rawData)
        {
        }

        public byte TypeId
        {
            get { return DataAccess.readByte(raw, typeIdOffset); }
            set { DataAccess.writeByte(raw, value, typeIdOffset); }
        }
        public byte LevelId
        {
            get { return DataAccess.readByte(raw, levelIdOffset); }
            set { DataAccess.writeByte(raw, value, levelIdOffset); }
        }
        public string Unk2
        {
            get { return DataAccess.readHexString(raw, unk2Offset, unk2Size); }
            set { DataAccess.writeHexString(raw, value, unk2Offset, unk2Size); }
        }
        public string Filename
        {
            get { return DataAccess.readString(raw, filenameOffset, filenameSize); }
            set { DataAccess.writeString32(raw, value, filenameOffset, filenameSize); }
        }
        public string Unk36
        {
            get { return DataAccess.readHexString(raw, unk36Offset, unk36Size); }
            set { DataAccess.writeHexString(raw, value, unk36Offset, unk36Size); }
        }
        public string CommandValue
        {
            get { return Commands.getValue(Command); }
        }
        public ushort Command
        {
            get { return DataAccess.readUShort(raw, commandOffset, commandSize); }
            set { DataAccess.writeUShort(raw, value, commandOffset, commandSize); NotifyPropertyChanged(nameof(CommandValue)); }
        }
        public ushort GroundAnim
        {
            get { return DataAccess.readUShort(raw, groundAnimOffset, groundAnimSize); }
            set { DataAccess.writeUShort(raw, value, groundAnimOffset, groundAnimSize); }
        }
        public string GroundUnk
        {
            get { return DataAccess.readHexString(raw, groundUnkOffset, groundUnkSize); }
            set { DataAccess.writeHexString(raw, value, groundUnkOffset, groundUnkSize); }
        }
        public ushort FinishAnim
        {
            get { return DataAccess.readUShort(raw, airAnimOffset, airAnimSize); }
            set { DataAccess.writeUShort(raw, value, airAnimOffset, airAnimSize); }
        }
        public string FinishUnk
        {
            get { return DataAccess.readHexString(raw, airUnkOffset, airUnkSize); }
            set { DataAccess.writeHexString(raw, value, airUnkOffset, airUnkSize); }
        }
        public ushort AirAnim
        {
            get { return DataAccess.readUShort(raw, finishAnimOffset, finishAnimSize); }
            set { DataAccess.writeUShort(raw, value, finishAnimOffset, finishAnimSize); }
        }
        public string AirUnk
        {
            get { return DataAccess.readHexString(raw, finishUnkOffset, finishUnkSize); }
            set { DataAccess.writeHexString(raw, value, finishUnkOffset, finishUnkSize); }
        }
        public string Unk52
        {
            get { return DataAccess.readHexString(raw, unk52Offset, unk52Size); }
            set { DataAccess.writeHexString(raw, value, unk52Offset, unk52Size); }
        }
        public string Unk53
        {
            get { return DataAccess.readHexString(raw, unk53Offset, unk53Size); }
            set { DataAccess.writeHexString(raw, value, unk53Offset, unk53Size); }
        }
        public string Unk54
        {
            get { return DataAccess.readHexString(raw, unk54Offset, unk54Size); }
            set { DataAccess.writeHexString(raw, value, unk54Offset, unk54Size); }
        }
    }
}
