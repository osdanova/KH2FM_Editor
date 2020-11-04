using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Objentry
{
    public class ObjentryItem : Str_EntryItem
    {
        public static readonly int entrySize = 96;
        // Data Location
        public static readonly int idOffset = 0, idSize = 2;
        public static readonly int unk02Offset = 2, unk02Size = 2;
        public static readonly int typeOffset = 4, typeSize = 1;
        public static readonly int unk05Offset = 5, unk05Size = 1;
        public static readonly int unk06Offset = 6, unk06Size = 1;
        public static readonly int weaponJointOffset = 7, weaponJointSize = 1;
        public static readonly int modelNameOffset = 8, modelNameSize = 32;
        public static readonly int animNameOffset = 40, animNameSize = 32;
        public static readonly int unk72Offset = 72, unk72Size = 2;
        public static readonly int unk74Offset = 74, unk74Size = 2;
        public static readonly int neoStatusOffset = 76, neoStatusSize = 2;
        public static readonly int neoMovesetOffset = 78, neoMovesetSize = 2;
        public static readonly int unk80Offset = 80, unk80Size = 2;
        public static readonly int weightOffset = 82, weightSize = 2;
        public static readonly int spawnLimitOffset = 84, spawnLimitSize = 1;
        public static readonly int unk85Offset = 85, unk85Size = 1;
        public static readonly int unk86Offset = 86, unk86Size = 1;
        public static readonly int comMenuOptOffset = 87, comMenuOptSize = 1;
        public static readonly int extraSpawn1Offset = 88, extraSpawn1Size = 2;
        public static readonly int extraSpawn2Offset = 90, extraSpawn2Size = 2;
        public static readonly int extraSpawn3Offset = 92, extraSpawn3Size = 2;
        public static readonly int unk94Offset = 94, unk94Size = 2;

        public ObjentryItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public ObjentryItem(List<byte> rawData) : base (rawData)
        {
        }

        public ushort Id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); }
        }
        public string Unk02
        {
            get { return DataAccess.readHexString(raw, unk02Offset, unk02Size); }
            set { DataAccess.writeHexString(raw, value, unk02Offset, unk02Size); }
        }
        public string TypeValue
        {
            get { return ObjTypes.getValue(Type); }
        }
        public byte Type
        {
            get { return DataAccess.readByte(raw, typeOffset); }
            set { DataAccess.writeByte(raw, value, typeOffset); NotifyPropertyChanged(nameof(TypeValue)); }
        }
        public string Unk05
        {
            get { return DataAccess.readHexString(raw, unk05Offset, unk05Size); }
            set { DataAccess.writeHexString(raw, value, unk05Offset, unk05Size); }
        }
        public string Unk06
        {
            get { return DataAccess.readHexString(raw, unk06Offset, unk06Size); }
            set { DataAccess.writeHexString(raw, value, unk06Offset, unk06Size); }
        }
        public string WeaponJoint
        {
            get { return DataAccess.readHexString(raw, weaponJointOffset, weaponJointSize); }
            set { DataAccess.writeHexString(raw, value, weaponJointOffset, weaponJointSize); }
        }
        public string EntityValue
        {
            get { return EntityFile.getValue(ModelName.Replace("\0", "")); }
        }
        public string ModelName
        {
            get { return DataAccess.readString(raw, modelNameOffset, modelNameSize); }
            set { DataAccess.writeString32(raw, value, modelNameOffset, modelNameSize); NotifyPropertyChanged(nameof(EntityValue)); }
        }
        public string AnimName
        {
            get { return DataAccess.readString(raw, animNameOffset, animNameSize); }
            set { DataAccess.writeString32(raw, value, animNameOffset, animNameSize); }
        }
        public string Unk72
        {
            get { return DataAccess.readHexString(raw, unk72Offset, unk72Size); }
            set { DataAccess.writeHexString(raw, value, unk72Offset, unk72Size); }
        }
        public string Unk74
        {
            get { return DataAccess.readHexString(raw, unk74Offset, unk74Size); }
            set { DataAccess.writeHexString(raw, value, unk74Offset, unk74Size); }
        }
        public ushort NeoStatus
        {
            get { return DataAccess.readUShort(raw, neoStatusOffset, neoStatusSize); }
            set { DataAccess.writeUShort(raw, value, neoStatusOffset, neoStatusSize); }
        }
        public ushort NeoMoveset
        {
            get { return DataAccess.readUShort(raw, neoMovesetOffset, neoMovesetSize); }
            set { DataAccess.writeUShort(raw, value, neoMovesetOffset, neoMovesetSize); }
        }
        public string Unk80
        {
            get { return DataAccess.readHexString(raw, unk80Offset, unk80Size); }
            set { DataAccess.writeHexString(raw, value, unk80Offset, unk80Size); }
        }
        public short Weight
        {
            get { return DataAccess.readShort(raw, weightOffset, weightSize); }
            set { DataAccess.writeShort(raw, value, weightOffset, weightSize); }
        }
        public byte SpawnLimit
        {
            get { return DataAccess.readByte(raw, spawnLimitOffset); }
            set { DataAccess.writeByte(raw, value, spawnLimitOffset); }
        }
        public string Unk85
        {
            get { return DataAccess.readHexString(raw, unk85Offset, unk85Size); }
            set { DataAccess.writeHexString(raw, value, unk85Offset, unk85Size); }
        }
        public string Unk86
        {
            get { return DataAccess.readHexString(raw, unk86Offset, unk86Size); }
            set { DataAccess.writeHexString(raw, value, unk86Offset, unk86Size); }
        }
        public string ComMenuOptValue
        {
            get { return CommandMenu.getValue(ComMenuOpt); }
        }
        public byte ComMenuOpt
        {
            get { return DataAccess.readByte(raw, comMenuOptOffset); }
            set { DataAccess.writeByte(raw, value, comMenuOptOffset); NotifyPropertyChanged(nameof(ComMenuOptValue)); }
        }
        public string ExtraSpawn1Value
        {
            get { return Entities.getValue(ExtraSpawn1); }
        }
        public ushort ExtraSpawn1
        {
            get { return DataAccess.readUShort(raw, extraSpawn1Offset, extraSpawn1Size); }
            set { DataAccess.writeUShort(raw, value, extraSpawn1Offset, extraSpawn1Size); NotifyPropertyChanged(nameof(ExtraSpawn1Value)); }
        }
        public string ExtraSpawn2Value
        {
            get { return Entities.getValue(ExtraSpawn2); }
        }
        public ushort ExtraSpawn2
        {
            get { return DataAccess.readUShort(raw, extraSpawn2Offset, extraSpawn2Size); }
            set { DataAccess.writeUShort(raw, value, extraSpawn2Offset, extraSpawn2Size); NotifyPropertyChanged(nameof(ExtraSpawn2Value)); }
        }
        public string ExtraSpawn3Value
        {
            get { return Entities.getValue(ExtraSpawn3); }
        }
        public ushort ExtraSpawn3
        {
            get { return DataAccess.readUShort(raw, extraSpawn3Offset, extraSpawn3Size); }
            set { DataAccess.writeUShort(raw, value, extraSpawn3Offset, extraSpawn3Size); NotifyPropertyChanged(nameof(ExtraSpawn3Value)); }
        }
        public string Unk94
        {
            get { return DataAccess.readHexString(raw, unk94Offset, unk94Size); }
            set { DataAccess.writeHexString(raw, value, unk94Offset, unk94Size); }
        }
    }
}
