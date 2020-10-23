using KH2FM_Editor_WPF.Data;
using KH2FM_Editor_WPF.FileTypes.GENERIC;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KH2FM_Editor_WPF.FileTypes.Objentry
{
    public class ObjentryItem : BaseEntry, INotifyPropertyChanged
    {
        //----------------------------------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        // NotifyPropertyChanged(nameof(PROPERTY_NAME_TO_UPDATE));
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //----------------------------------------------------------------------------------------

        public static int entrySize = 96;
        // Data Location
        public int idOffset = 0, idSize = 2;
        public int unk1Offset = 2, unk1Size = 2;
        public int typeOffset = 4, typeSize = 1;
        public int unk2Offset = 5, unk2Size = 1;
        public int unk3Offset = 6, unk3Size = 1;
        public int weaponJointOffset = 7, weaponJointSize = 1;
        public int modelNameOffset = 8, modelNameSize = 32;
        public int animNameOffset = 40, animNameSize = 32;
        public int unk4Offset = 72, unk4Size = 2;
        public int unk5Offset = 74, unk5Size = 2;
        public int neoStatusOffset = 76, neoStatusSize = 2;
        public int neoMovesetOffset = 78, neoMovesetSize = 2;
        public int unk6Offset = 80, unk6Size = 2;
        public int weightOffset = 82, weightSize = 2;
        public int spawnLimitOffset = 84, spawnLimitSize = 1;
        public int unk7Offset = 85, unk7Size = 1;
        public int unk8Offset = 86, unk8Size = 1;
        public int comMenuOptOffset = 87, comMenuOptSize = 1;
        public int extraSpawn1Offset = 88, extraSpawn1Size = 2;
        public int extraSpawn2Offset = 90, extraSpawn2Size = 2;
        public int extraSpawn3Offset = 92, extraSpawn3Size = 2;
        public int unk9Offset = 94, unk9Size = 2;

        public ObjentryItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public ObjentryItem(List<byte> rawData) : base (rawData)
        {
        }

        public ushort id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); }
        }
        public string unk1
        {
            get { return DataAccess.readHexString(raw, unk1Offset, unk1Size); }
            set { DataAccess.writeHexString(raw, value, unk1Offset, unk1Size); }
        }
        public string typeName
        {
            get { return ObjTypes.getName(type); }
        }
        public byte type
        {
            get { return DataAccess.readByte(raw, typeOffset); }
            set { DataAccess.writeByte(raw, value, typeOffset); NotifyPropertyChanged(nameof(typeName)); }
        }
        public string unk2
        {
            get { return DataAccess.readHexString(raw, unk2Offset, unk2Size); }
            set { DataAccess.writeHexString(raw, value, unk2Offset, unk2Size); }
        }
        public string unk3
        {
            get { return DataAccess.readHexString(raw, unk3Offset, unk3Size); }
            set { DataAccess.writeHexString(raw, value, unk3Offset, unk3Size); }
        }
        public string weaponJoint
        {
            get { return DataAccess.readHexString(raw, weaponJointOffset, weaponJointSize); }
            set { DataAccess.writeHexString(raw, value, weaponJointOffset, weaponJointSize); }
        }
        public string entity
        {
            get { return EntityFile.getValueName(modelName.Replace("\0", "")); }
        }
        public string modelName
        {
            get { return DataAccess.readString(raw, modelNameOffset, modelNameSize); }
            set { DataAccess.writeString32(raw, value, modelNameOffset, modelNameSize); NotifyPropertyChanged(nameof(entity)); }
        }
        public string animName
        {
            get { return DataAccess.readString(raw, animNameOffset, animNameSize); }
            set { DataAccess.writeString32(raw, value, animNameOffset, animNameSize); }
        }
        public string unk4
        {
            get { return DataAccess.readHexString(raw, unk4Offset, unk4Size); }
            set { DataAccess.writeHexString(raw, value, unk4Offset, unk4Size); }
        }
        public string unk5
        {
            get { return DataAccess.readHexString(raw, unk5Offset, unk5Size); }
            set { DataAccess.writeHexString(raw, value, unk5Offset, unk5Size); }
        }
        public ushort neoStatus
        {
            get { return DataAccess.readUShort(raw, neoStatusOffset, neoStatusSize); }
            set { DataAccess.writeUShort(raw, value, neoStatusOffset, neoStatusSize); }
        }
        public ushort neoMoveset
        {
            get { return DataAccess.readUShort(raw, neoMovesetOffset, neoMovesetSize); }
            set { DataAccess.writeUShort(raw, value, neoMovesetOffset, neoMovesetSize); }
        }
        public string unk6
        {
            get { return DataAccess.readHexString(raw, unk6Offset, unk6Size); }
            set { DataAccess.writeHexString(raw, value, unk6Offset, unk6Size); }
        }
        public short weight
        {
            get { return DataAccess.readShort(raw, weightOffset, weightSize); }
            set { DataAccess.writeShort(raw, value, weightOffset, weightSize); }
        }
        public byte spawnLimit
        {
            get { return DataAccess.readByte(raw, spawnLimitOffset); }
            set { DataAccess.writeByte(raw, value, spawnLimitOffset); }
        }
        public string unk7
        {
            get { return DataAccess.readHexString(raw, unk7Offset, unk7Size); }
            set { DataAccess.writeHexString(raw, value, unk7Offset, unk7Size); }
        }
        public string unk8
        {
            get { return DataAccess.readHexString(raw, unk8Offset, unk8Size); }
            set { DataAccess.writeHexString(raw, value, unk8Offset, unk8Size); }
        }
        public string comMenuOptName
        {
            get { return CommandMenu.getName(comMenuOpt); }
        }
        public byte comMenuOpt
        {
            get { return DataAccess.readByte(raw, comMenuOptOffset); }
            set { DataAccess.writeByte(raw, value, comMenuOptOffset); NotifyPropertyChanged(nameof(comMenuOptName)); }
        }
        public string extraSpawn1Name
        {
            get { return Entity.getValueName(extraSpawn1); }
        }
        public ushort extraSpawn1
        {
            get { return DataAccess.readUShort(raw, extraSpawn1Offset, extraSpawn1Size); }
            set { DataAccess.writeUShort(raw, value, extraSpawn1Offset, extraSpawn1Size); NotifyPropertyChanged(nameof(extraSpawn1Name)); }
        }
        public string extraSpawn2Name
        {
            get { return Entity.getValueName(extraSpawn2); }
        }
        public ushort extraSpawn2
        {
            get { return DataAccess.readUShort(raw, extraSpawn2Offset, extraSpawn2Size); }
            set { DataAccess.writeUShort(raw, value, extraSpawn2Offset, extraSpawn2Size); NotifyPropertyChanged(nameof(extraSpawn2Name)); }
        }
        public string extraSpawn3Name
        {
            get { return Entity.getValueName(extraSpawn3); }
        }
        public ushort extraSpawn3
        {
            get { return DataAccess.readUShort(raw, extraSpawn3Offset, extraSpawn3Size); }
            set { DataAccess.writeUShort(raw, value, extraSpawn3Offset, extraSpawn3Size); NotifyPropertyChanged(nameof(extraSpawn3Name)); }
        }
        public string unk9
        {
            get { return DataAccess.readHexString(raw, unk9Offset, unk9Size); }
            set { DataAccess.writeHexString(raw, value, unk9Offset, unk9Size); }
        }
    }
}
