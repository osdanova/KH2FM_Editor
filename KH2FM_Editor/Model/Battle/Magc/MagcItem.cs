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
        public int worldOffset = 2, worldSize = 1;
        public int padding1Offset = 3, padding1Size = 1;
        public int filenameOffset = 4, filenameSize = 32;
        public int itemOffset = 36, itemSize = 2;
        public int commandOffset = 38, commandSize = 2;
        public int groundAnimOffset = 40, groundAnimSize = 2;
        public int groundBlendOffset = 42, groundBlendSize = 2;
        public int airAnimOffset = 44, airAnimSize = 2;
        public int airBlendOffset = 46, airBlendSize = 2;
        public int finishAnimOffset = 48, finishAnimSize = 2;
        public int finishBlendOffset = 50, finishBlendSize = 2;
        public int voiceOffset = 52, voiceSize = 1;
        public int voiceFinishOffset = 53, voiceFinishSize = 1;
        public int voiceSelfOffset = 54, voiceSelfSize = 1;
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
        public string WorldValue
        {
            get { return Worlds.getValue(World); }
        }
        public byte World
        {
            get { return DataAccess.readByte(raw, worldOffset); }
            set { DataAccess.writeByte(raw, value, worldOffset); NotifyPropertyChanged(nameof(CommandValue)); }
        }
        public string Filename
        {
            get { return DataAccess.readString(raw, filenameOffset, filenameSize); }
            set { DataAccess.writeString32(raw, value, filenameOffset, filenameSize); }
        }
        public string ItemValue
        {
            get { return Items.getValue(Item); }
        }
        public ushort Item
        {
            get { return DataAccess.readUShort(raw, itemOffset, itemSize); }
            set { DataAccess.writeUShort(raw, value, itemOffset, itemSize); }
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
        public int GroundAnim4
        {
            get { return GroundAnim*4; }
        }
        public ushort GroundAnim
        {
            get { return DataAccess.readUShort(raw, groundAnimOffset, groundAnimSize); }
            set { DataAccess.writeUShort(raw, value, groundAnimOffset, groundAnimSize); }
        }
        public int GroundBlend4
        {
            get { return GroundBlend * 4; }
        }
        public ushort GroundBlend
        {
            get { return DataAccess.readUShort(raw, groundBlendOffset, groundBlendSize); }
            set { DataAccess.writeUShort(raw, value, groundBlendOffset, groundBlendSize); }
        }
        public int FinishAnim4
        {
            get { return FinishAnim * 4; }
        }
        public ushort FinishAnim
        {
            get { return DataAccess.readUShort(raw, airAnimOffset, airAnimSize); }
            set { DataAccess.writeUShort(raw, value, airAnimOffset, airAnimSize); }
        }
        public int FinishBlend4
        {
            get { return FinishBlend * 4; }
        }
        public ushort FinishBlend
        {
            get { return DataAccess.readUShort(raw, airBlendOffset, airBlendSize); }
            set { DataAccess.writeUShort(raw, value, airBlendOffset, airBlendSize); }
        }
        public int AirAnim4
        {
            get { return AirAnim * 4; }
        }
        public ushort AirAnim
        {
            get { return DataAccess.readUShort(raw, finishAnimOffset, finishAnimSize); }
            set { DataAccess.writeUShort(raw, value, finishAnimOffset, finishAnimSize); }
        }
        public int AirBlend4
        {
            get { return AirBlend * 4; }
        }
        public ushort AirBlend
        {
            get { return DataAccess.readUShort(raw, finishBlendOffset, finishBlendSize); }
            set { DataAccess.writeUShort(raw, value, finishBlendOffset, finishBlendSize); }
        }
        public sbyte Voice
        {
            get { return DataAccess.readSByte(raw, voiceOffset); }
            set { DataAccess.writeSByte(raw, value, voiceOffset); }
        }
        public sbyte VoiceFinish
        {
            get { return DataAccess.readSByte(raw, voiceFinishOffset); }
            set { DataAccess.writeSByte(raw, value, voiceFinishSize); }
        }
        public sbyte VoiceSelf
        {
            get { return DataAccess.readSByte(raw, voiceSelfOffset); }
            set { DataAccess.writeSByte(raw, value, voiceSelfOffset); }
        }
    }
}
