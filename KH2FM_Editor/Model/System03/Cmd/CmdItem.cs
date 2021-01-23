using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Cmd
{
    class CmdItem : Str_EntryItem
    {
        public static readonly int entrySize = 48;
        // Data Location
        public static readonly int idOffset = 0, idSize = 2;
        public static readonly int execOffset = 2, execSize = 2;
        public static readonly int unkId2Offset = 4, unkId2Size = 2;
        public static readonly int submenuOffset = 6, submenuSize = 1;
        public static readonly int iconOffset = 7, iconSize = 1;
        public static readonly int textOffset = 8, textSize = 4;
        public static readonly int flagOffset = 12, flagSize = 4;
        public static readonly int rangeOffset = 16, rangeSize = 4;
        public static readonly int dirOffset = 20, dirSize = 4;
        public static readonly int dirRangeOffset = 24, dirRangeSize = 4;
        public static readonly int mpDrCostOffset = 28, mpDrCostSize = 1;
        public static readonly int cameraOffset = 29, cameraSize = 1;
        public static readonly int priorityOffset = 30, prioritySize = 1;
        public static readonly int receiverOffset = 31, receiverSize = 1;
        public static readonly int timeOffset = 32, timeSize = 2;
        public static readonly int requireOffset = 34, requireSize = 2;
        public static readonly int markOffset = 36, markSize = 1;
        public static readonly int actionOffset = 37, actionSize = 1;
        public static readonly int rcCountOffset = 38, rcCountSize = 2;
        public static readonly int distanceRangeOffset = 40, distanceRangeSize = 2;
        public static readonly int scoreOffset = 42, scoreSize = 2;
        public static readonly int disableFormOffset = 44, disableFormSize = 2;
        public static readonly int groupOffset = 46, groupize = 1;
        public static readonly int reserveOffset = 47, reserveize = 1;

        public CmdItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public CmdItem(List<byte> rawData) : base(rawData)
        {
        }

        public string CommandValue
        {
            get { return Commands.getValue(Id); }
        }
        public ushort Id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); NotifyPropertyChanged(nameof(CommandValue)); }
        }
        public ushort Exec
        {
            get { return DataAccess.readUShort(raw, execOffset, execSize); }
            set { DataAccess.writeUShort(raw, value, execOffset, execSize); }
        }
        public ushort UnkId2
        {
            get { return DataAccess.readUShort(raw, unkId2Offset, unkId2Size); }
            set { DataAccess.writeUShort(raw, value, unkId2Offset, unkId2Size); }
        }
        public sbyte Submenu
        {
            get { return DataAccess.readSByte(raw, submenuOffset); }
            set { DataAccess.writeSByte(raw, value, submenuOffset); }
        }
        public byte Icon
        {
            get { return DataAccess.readByte(raw, iconOffset); }
            set { DataAccess.writeByte(raw, value, iconOffset); }
        }
        public int Text
        {
            get { return DataAccess.readInt(raw, textOffset, textSize); }
            set { DataAccess.writeInt(raw, value, textOffset, textSize); }
        }
        public uint Flag
        {
            get { return DataAccess.readUInt(raw, flagOffset, flagSize); }
            set { DataAccess.writeUInt(raw, value, flagOffset, flagSize); }
        }
        public float Range
        {
            get { return DataAccess.readFloat(raw, rangeOffset, rangeSize); }
            set { DataAccess.writeFloat(raw, value, rangeOffset, rangeSize); }
        }
        public float Dir
        {
            get { return DataAccess.readFloat(raw, dirOffset, dirSize); }
            set { DataAccess.writeFloat(raw, value, dirOffset, dirSize); }
        }
        public float DirRange
        {
            get { return DataAccess.readFloat(raw, dirRangeOffset, dirRangeSize); }
            set { DataAccess.writeFloat(raw, value, dirRangeOffset, dirRangeSize); }
        }
        public byte MpDrCost
        {
            get { return DataAccess.readByte(raw, mpDrCostOffset); }
            set { DataAccess.writeByte(raw, value, mpDrCostOffset); }
        }
        public byte Camera
        {
            get { return DataAccess.readByte(raw, cameraOffset); }
            set { DataAccess.writeByte(raw, value, cameraOffset); }
        }
        public byte Priority
        {
            get { return DataAccess.readByte(raw, priorityOffset); }
            set { DataAccess.writeByte(raw, value, priorityOffset); }
        }
        public byte Receiver
        {
            get { return DataAccess.readByte(raw, receiverOffset); }
            set { DataAccess.writeByte(raw, value, receiverOffset); }
        }
        public ushort Time
        {
            get { return DataAccess.readUShort(raw, timeOffset, timeSize); }
            set { DataAccess.writeUShort(raw, value, timeOffset, timeSize); }
        }
        public ushort Require
        {
            get { return DataAccess.readUShort(raw, requireOffset, requireSize); }
            set { DataAccess.writeUShort(raw, value, requireOffset, requireSize); }
        }
        public byte Mark
        {
            get { return DataAccess.readByte(raw, markOffset); }
            set { DataAccess.writeByte(raw, value, markOffset); }
        }
        public byte Action
        {
            get { return DataAccess.readByte(raw, actionOffset); }
            set { DataAccess.writeByte(raw, value, actionOffset); }
        }
        public ushort RcCount
        {
            get { return DataAccess.readUShort(raw, rcCountOffset, rcCountSize); }
            set { DataAccess.writeUShort(raw, value, rcCountOffset, rcCountSize); }
        }
        public ushort DistanceRange
        {
            get { return DataAccess.readUShort(raw, distanceRangeOffset, distanceRangeSize); }
            set { DataAccess.writeUShort(raw, value, distanceRangeOffset, distanceRangeSize); }
        }
        public ushort Score
        {
            get { return DataAccess.readUShort(raw, scoreOffset, scoreSize); }
            set { DataAccess.writeUShort(raw, value, scoreOffset, scoreSize); }
        }
        public ushort DisableForm
        {
            get { return DataAccess.readUShort(raw, disableFormOffset, disableFormSize); }
            set { DataAccess.writeUShort(raw, value, requireOffset, requireSize); }
        }
        public byte Group
        {
            get { return DataAccess.readByte(raw, groupOffset); }
            set { DataAccess.writeByte(raw, value, groupOffset); }
        }
        public byte Reserve
        {
            get { return DataAccess.readByte(raw, reserveOffset); }
            set { DataAccess.writeByte(raw, value, reserveOffset); }
        }
    }
}
