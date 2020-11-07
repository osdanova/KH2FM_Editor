using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Ard.Spawn
{
    public class SpawnItem : Str_EntryItem
    {
        public static readonly int entrySize = 48;
        // Data Location
        public static readonly int entityIdOffset = 0, entityIdSize = 2;
        public static readonly int locRotSize = 4;
        public static readonly int posXOffset = 4, posYOffset = 8, posZOffset = 12;
        public static readonly int rotXOffset = 16, rotYOffset = 20, rotZOffset = 24;
        public static readonly int entityUnk28Offset = 28, entityUnk28Size = 1;
        public static readonly int entityUnk29Offset = 29, entityUnk29Size = 1;
        public static readonly int entityUnk30Offset = 30, entityUnk30Size = 2;
        public static readonly int entityAIOffset = 32, entityAISize = 4;
        public static readonly int entityTalkOffset = 36, entityTalkSize = 4;
        public static readonly int entityRCOffset = 40, entityRCSize = 4;

        public SpawnItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public SpawnItem(List<byte> rawData) : base(rawData)
        {
        }

        public string EntityValue
        {
            get { return Entities.getValue(Entity); }
        }
        public ushort Entity
        {
            get { return DataAccess.readUShort(raw, entityIdOffset, entityIdSize); }
            set { DataAccess.writeUShort(raw, value, entityIdOffset, entityIdSize); NotifyPropertyChanged(nameof(EntityValue)); }
        }
        public uint PosX
        {
            get { return DataAccess.readUInt(raw, posXOffset, locRotSize); }
            set { DataAccess.writeUInt(raw, value, posXOffset, locRotSize); }
        }
        public uint PosY
        {
            get { return DataAccess.readUInt(raw, posYOffset, locRotSize); }
            set { DataAccess.writeUInt(raw, value, posYOffset, locRotSize); }
        }
        public uint PosZ
        {
            get { return DataAccess.readUInt(raw, posZOffset, locRotSize); }
            set { DataAccess.writeUInt(raw, value, posZOffset, locRotSize); }
        }
        public uint RotX
        {
            get { return DataAccess.readUInt(raw, rotXOffset, locRotSize); }
            set { DataAccess.writeUInt(raw, value, rotXOffset, locRotSize); }
        }
        public uint RotY
        {
            get { return DataAccess.readUInt(raw, rotYOffset, locRotSize); }
            set { DataAccess.writeUInt(raw, value, rotYOffset, locRotSize); }
        }
        public uint RotZ
        {
            get { return DataAccess.readUInt(raw, rotZOffset, locRotSize); }
            set { DataAccess.writeUInt(raw, value, rotZOffset, locRotSize); }
        }
        public string Unk28
        {
            get { return DataAccess.readHexString(raw, entityUnk28Offset, entityUnk28Size); }
            set { DataAccess.writeHexString(raw, value, entityUnk28Offset, entityUnk28Size); }
        }
        public string Unk29
        {
            get { return DataAccess.readHexString(raw, entityUnk29Offset, entityUnk29Size); }
            set { DataAccess.writeHexString(raw, value, entityUnk29Offset, entityUnk29Size); }
        }
        public string Unk30
        {
            get { return DataAccess.readHexString(raw, entityUnk30Offset, entityUnk30Size); }
            set { DataAccess.writeHexString(raw, value, entityUnk30Offset, entityUnk30Size); }
        }
        public string Ai
        {
            get { return DataAccess.readHexString(raw, entityAIOffset, entityAISize); }
            set { DataAccess.writeHexString(raw, value, entityAIOffset, entityAISize); }
        }
        public string Talk
        {
            get { return DataAccess.readHexString(raw, entityTalkOffset, entityTalkSize); }
            set { DataAccess.writeHexString(raw, value, entityTalkOffset, entityTalkSize); }
        }
        public string Rc
        {
            get { return DataAccess.readHexString(raw, entityRCOffset, entityRCSize); }
            set { DataAccess.writeHexString(raw, value, entityRCOffset, entityRCSize); }
        }

    }

}
