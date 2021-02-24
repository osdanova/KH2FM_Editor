using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;
using System.Collections;

namespace KH2FM_Editor.Model.Objentry
{
    public class ObjentryItem : Str_EntryItem
    {
        public static readonly int entrySize = 96;
        // Data Location
        public static readonly int idOffset = 0, idSize = 4;
        public static readonly int typeOffset = 4, typeSize = 1;
        public static readonly int subtypeOffset = 5, subtypeSize = 1;
        public static readonly int drawPriorityOffset = 6, drawPrioritySize = 1;
        public static readonly int weaponJointOffset = 7, weaponJointSize = 1;
        public static readonly int modelNameOffset = 8, modelNameSize = 32;
        public static readonly int animNameOffset = 40, animNameSize = 32;
        public static readonly int flagsOffset = 72, flagsSize = 2;
        public static readonly int targetOffset = 74, targetSize = 1;
        public static readonly int paddingOffset = 75, paddingSize = 1;
        public static readonly int neoStatusOffset = 76, neoStatusSize = 2;
        public static readonly int neoMovesetOffset = 78, neoMovesetSize = 2;
        public static readonly int weightOffset = 80, weightSize = 4;
        public static readonly int spawnLimitOffset = 84, spawnLimitSize = 1;
        public static readonly int pageOffset = 85, pageSize = 1;
        public static readonly int shadowSizeOffset = 86, shadowSizeSize = 1;
        public static readonly int formOffset = 87, formSize = 1;
        public static readonly int extraSpawn1Offset = 88, extraSpawn1Size = 2;
        public static readonly int extraSpawn2Offset = 90, extraSpawn2Size = 2;
        public static readonly int extraSpawn3Offset = 92, extraSpawn3Size = 2;
        public static readonly int extraSpawn4Offset = 94, extraSpawn4Size = 2;

        public ObjentryItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public ObjentryItem(List<byte> rawData) : base (rawData)
        {
        }

        public uint Id
        {
            get { return DataAccess.readUInt(raw, idOffset, idSize); }
            set { DataAccess.writeUInt(raw, value, idOffset, idSize); }
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
        public byte Subtype
        {
            get { return DataAccess.readByte(raw, subtypeOffset); }
            set { DataAccess.writeByte(raw, value, subtypeOffset); }
        }
        public byte DrawPriority
        {
            get { return DataAccess.readByte(raw, drawPriorityOffset); }
            set { DataAccess.writeByte(raw, value, drawPriorityOffset); }
        }
        public byte WeaponJoint
        {
            get { return DataAccess.readByte(raw, weaponJointOffset); }
            set { DataAccess.writeByte(raw, value, weaponJointOffset); }
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
        public bool FlagNoApdx
        {
            get { return new BitArray(new int[1] { Flags }).Get(0); }
        }
        public bool FlagBefore
        {
            get { return new BitArray(new int[1] { Flags }).Get(1); }
        }
        public bool FlagFixColor
        {
            get { return new BitArray(new int[1] { Flags }).Get(2); }
        }
        public bool FlagFly
        {
            get { return new BitArray(new int[1] { Flags }).Get(3); }
        }
        public bool FlagScissoring
        {
            get { return new BitArray(new int[1] { Flags }).Get(4); }
        }
        public bool FlagPirate
        {
            get { return new BitArray(new int[1] { Flags }).Get(5); }
        }
        public bool FlagWallOcclusion
        {
            get { return new BitArray(new int[1] { Flags }).Get(6); }
        }
        public bool FlagHift
        {
            get { return new BitArray(new int[1] { Flags }).Get(7); }
        }
        public ushort Flags
        {
            get { return DataAccess.readUShort(raw, flagsOffset, flagsSize); }
            set { DataAccess.writeUShort(raw, value, flagsOffset, flagsSize);
                NotifyPropertyChanged(nameof(FlagNoApdx));
                NotifyPropertyChanged(nameof(FlagBefore));
                NotifyPropertyChanged(nameof(FlagFixColor));
                NotifyPropertyChanged(nameof(FlagFly));
                NotifyPropertyChanged(nameof(FlagScissoring));
                NotifyPropertyChanged(nameof(FlagPirate));
                NotifyPropertyChanged(nameof(FlagWallOcclusion));
                NotifyPropertyChanged(nameof(FlagHift));
            }
        }
        public string TargetValue
        {
            get { return ObjentryFlags.getTarget(Target); }
        }
        public byte Target
        {
            get { return DataAccess.readByte(raw, targetOffset); }
            set { DataAccess.writeByte(raw, value, targetOffset); }
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
        public float Weight
        {
            get { return DataAccess.readFloat(raw, weightOffset, weightSize); }
            set { DataAccess.writeFloat(raw, value, weightOffset, weightSize); }
        }
        public byte SpawnLimit
        {
            get { return DataAccess.readByte(raw, spawnLimitOffset); }
            set { DataAccess.writeByte(raw, value, spawnLimitOffset); }
        }
        public byte Page
        {
            get { return DataAccess.readByte(raw, pageOffset); }
            set { DataAccess.writeByte(raw, value, pageOffset); }
        }
        public string ShadowSizeValue
        {
            get { return ObjentryFlags.getShadowSize(ShadowSize); }
        }
        public byte ShadowSize
        {
            get { return DataAccess.readByte(raw, shadowSizeOffset); }
            set { DataAccess.writeByte(raw, value, shadowSizeOffset); }
        }
        public string FormValue
        {
            get { return ObjentryFlags.getForm(Form); }
        }
        public byte Form
        {
            get { return DataAccess.readByte(raw, formOffset); }
            set { DataAccess.writeByte(raw, value, formOffset); NotifyPropertyChanged(nameof(FormValue)); }
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
        public string ExtraSpawn4Value
        {
            get { return Entities.getValue(ExtraSpawn4); }
        }
        public ushort ExtraSpawn4
        {
            get { return DataAccess.readUShort(raw, extraSpawn4Offset, extraSpawn4Size); }
            set { DataAccess.writeUShort(raw, value, extraSpawn4Offset, extraSpawn4Size); NotifyPropertyChanged(nameof(ExtraSpawn4Value)); }
        }
    }
}
