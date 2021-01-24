using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Limt
{
    public class LimtItem : Str_EntryItem
    {
        public static readonly int entrySize = 64;
        // Data Location
        public int idOffset = 0, idSize = 1;
        public int characterOffset = 1, characterSize = 1;
        public int summonOffset = 2, summonSize = 1;
        public int groupOffset = 3, groupSize = 1;
        public int fileOffset = 4, fileSize = 32;
        public int spawnOffset = 36, spawnSize = 4;
        public int commandOffset = 40, commandSize = 2;
        public int limitOffset = 42, limitSize = 2;
        public int worldOffset = 44, worldSize = 1;
        public int paddingOffset = 48, paddingSize = 19;

        public LimtItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public LimtItem(List<byte> rawData) : base(rawData)
        {
        }

        public byte Id
        {
            get { return DataAccess.readByte(raw, idOffset); }
            set { DataAccess.writeByte(raw, value, idOffset); }
        }
        public string CharacterValue
        {
            get { return Characters.getValue(Character); }
        }
        public byte Character
        {
            get { return DataAccess.readByte(raw, characterOffset); }
            set { DataAccess.writeByte(raw, value, characterOffset); NotifyPropertyChanged(nameof(CharacterValue)); }
        }
        public string SummonValue
        {
            get { return Characters.getValue(Summon); }
        }
        public byte Summon
        {
            get { return DataAccess.readByte(raw, summonOffset); }
            set { DataAccess.writeByte(raw, value, summonOffset); NotifyPropertyChanged(nameof(SummonValue)); }
        }
        public byte Group
        {
            get { return DataAccess.readByte(raw, groupOffset); }
            set { DataAccess.writeByte(raw, value, groupOffset); }
        }
        public string File
        {
            get { return DataAccess.readString(raw, fileOffset, fileSize); }
            set { DataAccess.writeString32(raw, value, fileOffset, fileSize); }
        }
        public string SpawnValue
        {
            get { return Entities.getValue((ushort)Spawn); }
        }
        public uint Spawn
        {
            get { return DataAccess.readUInt(raw, spawnOffset, spawnSize); }
            set { DataAccess.writeUInt(raw, value, spawnOffset, spawnSize); NotifyPropertyChanged(nameof(SpawnValue)); }
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
        public string LimitValue
        {
            get { return Items.getValue(Limit); }
        }
        public ushort Limit
        {
            get { return DataAccess.readUShort(raw, limitOffset, limitSize); }
            set { DataAccess.writeUShort(raw, value, limitOffset, limitSize); NotifyPropertyChanged(nameof(LimitValue)); }
        }
        public string World
        {
            get { return DataAccess.readHexString(raw, worldOffset, worldSize); }
            set { DataAccess.writeHexString(raw, value, worldOffset, worldSize); }
        }
    }
}
