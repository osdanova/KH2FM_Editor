using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Ard.Spawn
{
    public class SpawnItem : Str_EntryItem
    {
        public static readonly int entrySize = 64;
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
        public float PosX
        {
            get { return DataAccess.readFloat(raw, posXOffset, locRotSize); }
            set { DataAccess.writeFloat(raw, value, posXOffset, locRotSize); }
        }
        public float PosY
        {
            get { return DataAccess.readFloat(raw, posYOffset, locRotSize); }
            set { DataAccess.writeFloat(raw, value, posYOffset, locRotSize); }
        }
        public float PosZ
        {
            get { return DataAccess.readFloat(raw, posZOffset, locRotSize); }
            set { DataAccess.writeFloat(raw, value, posZOffset, locRotSize); }
        }
        public float RotX
        {
            get { return DataAccess.readFloat(raw, rotXOffset, locRotSize); }
            set { DataAccess.writeFloat(raw, value, rotXOffset, locRotSize); }
        }
        public float RotY
        {
            get { return DataAccess.readFloat(raw, rotYOffset, locRotSize); }
            set { DataAccess.writeFloat(raw, value, rotYOffset, locRotSize); }
        }
        public float RotZ
        {
            get { return DataAccess.readFloat(raw, rotZOffset, locRotSize); }
            set { DataAccess.writeFloat(raw, value, rotZOffset, locRotSize); }
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
