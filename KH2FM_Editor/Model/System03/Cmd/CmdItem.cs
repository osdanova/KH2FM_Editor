using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Cmd
{
    class CmdItem : Str_EntryItem
    {
        public static readonly int entrySize = 48;
        // Data Location
        public static readonly int idOffset = 0, idSize = 2;
        public static readonly int execOffset = 2, execSize = 2;
        public static readonly int argumentOffset = 4, argumentSize = 2;
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
        public ushort Argument
        {
            get { return DataAccess.readUShort(raw, argumentOffset, argumentSize); }
            set { DataAccess.writeUShort(raw, value, argumentOffset, argumentSize); }
        }
        public sbyte Submenu
        {
            get { return DataAccess.readSByte(raw, submenuOffset); }
            set { DataAccess.writeSByte(raw, value, submenuOffset); }
        }
        public string IconValue
        {
            get { return CmdDictionary.getIcon(Icon); }
        }
        public byte Icon
        {
            get { return DataAccess.readByte(raw, iconOffset); }
            set { DataAccess.writeByte(raw, value, iconOffset); NotifyPropertyChanged(nameof(IconValue)); }
        }
        public int Text
        {
            get { return DataAccess.readInt(raw, textOffset, textSize); }
            set { DataAccess.writeInt(raw, value, textOffset, textSize); }
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
        public string CameraValue
        {
            get { return CmdDictionary.getCamera(Camera); }
        }
        public byte Camera
        {
            get { return DataAccess.readByte(raw, cameraOffset); }
            set { DataAccess.writeByte(raw, value, cameraOffset); NotifyPropertyChanged(nameof(CameraValue)); }
        }
        public byte Priority
        {
            get { return DataAccess.readByte(raw, priorityOffset); }
            set { DataAccess.writeByte(raw, value, priorityOffset); }
        }
        public string ReceiverValue
        {
            get { return CmdDictionary.getReceiver(Receiver); }
        }
        public byte Receiver
        {
            get { return DataAccess.readByte(raw, receiverOffset); }
            set { DataAccess.writeByte(raw, value, receiverOffset); NotifyPropertyChanged(nameof(Receiver)); }
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
        public string ActionValue
        {
            get { return CmdDictionary.getAction(Action); }
        }
        public byte Action
        {
            get { return DataAccess.readByte(raw, actionOffset); }
            set { DataAccess.writeByte(raw, value, actionOffset); NotifyPropertyChanged(nameof(ActionValue)); }
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
            set { DataAccess.writeUShort(raw, value, disableFormOffset, disableFormSize); }
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

        public byte FlagA
        {
            get { return DataAccess.readByte(raw, flagOffset); }
            set { DataAccess.writeByte(raw, value, flagOffset); }
        }
        public bool FlagCursor { get { return new BitArray(new int[1] { FlagA }).Get(0); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 0, value); } }
        public bool FlagLand { get { return new BitArray(new int[1] { FlagA }).Get(1); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 1, value); } }
        public bool FlagForce { get { return new BitArray(new int[1] { FlagA }).Get(2); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 2, value); } }
        public bool FlagCombo { get { return new BitArray(new int[1] { FlagA }).Get(3); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 3, value); } }
        public bool Flag5 { get { return new BitArray(new int[1] { FlagA }).Get(4); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 4, value); } }
        public bool Flag6 { get { return new BitArray(new int[1] { FlagA }).Get(5); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 5, value); } }
        public bool Flag7 { get { return new BitArray(new int[1] { FlagA }).Get(6); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 6, value); } }
        public bool Flag8 { get { return new BitArray(new int[1] { FlagA }).Get(7); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 7, value); } }

        public byte FlagB
        {
            get { return DataAccess.readByte(raw, flagOffset + 1); }
            set { DataAccess.writeByte(raw, value, flagOffset + 1); }
        }
        public bool Flag9 { get { return new BitArray(new int[1] { FlagB }).Get(0); } set { FlagB = BinaryHandler.setBitFromFlagTo(FlagB, 0, value); } }
        public bool Flag10 { get { return new BitArray(new int[1] { FlagB }).Get(1); } set { FlagB = BinaryHandler.setBitFromFlagTo(FlagB, 1, value); } }
        public bool Flag11 { get { return new BitArray(new int[1] { FlagB }).Get(2); } set { FlagB = BinaryHandler.setBitFromFlagTo(FlagB, 2, value); } }
        public bool Flag12 { get { return new BitArray(new int[1] { FlagB }).Get(3); } set { FlagB = BinaryHandler.setBitFromFlagTo(FlagB, 3, value); } }
        public bool Flag13 { get { return new BitArray(new int[1] { FlagB }).Get(4); } set { FlagB = BinaryHandler.setBitFromFlagTo(FlagB, 4, value); } }
        public bool Flag14 { get { return new BitArray(new int[1] { FlagB }).Get(5); } set { FlagB = BinaryHandler.setBitFromFlagTo(FlagB, 5, value); } }
        public bool Flag15 { get { return new BitArray(new int[1] { FlagB }).Get(6); } set { FlagB = BinaryHandler.setBitFromFlagTo(FlagB, 6, value); } }
        public bool Flag16 { get { return new BitArray(new int[1] { FlagB }).Get(7); } set { FlagB = BinaryHandler.setBitFromFlagTo(FlagB, 7, value); } }

        public byte FlagC
        {
            get { return DataAccess.readByte(raw, flagOffset + 2); }
            set { DataAccess.writeByte(raw, value, flagOffset + 2); }
        }
        public bool Flag17 { get { return new BitArray(new int[1] { FlagC }).Get(0); } set { FlagC = BinaryHandler.setBitFromFlagTo(FlagC, 0, value); } }
        /*public bool Flag18 { get { return new BitArray(new int[1] { FlagC }).Get(1); } set { FlagC = BinaryHandler.setBitFromFlagTo(FlagC, 1, value); } }
        public bool Flag19 { get { return new BitArray(new int[1] { FlagC }).Get(2); } set { FlagC = BinaryHandler.setBitFromFlagTo(FlagC, 2, value); } }
        public bool Flag20 { get { return new BitArray(new int[1] { FlagC }).Get(3); } set { FlagC = BinaryHandler.setBitFromFlagTo(FlagC, 3, value); } }
        public bool Flag21 { get { return new BitArray(new int[1] { FlagC }).Get(4); } set { FlagC = BinaryHandler.setBitFromFlagTo(FlagC, 4, value); } }
        public bool Flag22 { get { return new BitArray(new int[1] { FlagC }).Get(5); } set { FlagC = BinaryHandler.setBitFromFlagTo(FlagC, 5, value); } }
        public bool Flag23 { get { return new BitArray(new int[1] { FlagC }).Get(6); } set { FlagC = BinaryHandler.setBitFromFlagTo(FlagC, 6, value); } }
        public bool Flag24 { get { return new BitArray(new int[1] { FlagC }).Get(7); } set { FlagC = BinaryHandler.setBitFromFlagTo(FlagC, 7, value); } }

        public byte FlagD
        {
            get { return DataAccess.readByte(raw, flagOffset + 3); }
            set { DataAccess.writeByte(raw, value, flagOffset + 3); }
        }
        public bool Flag25 { get { return new BitArray(new int[1] { FlagD }).Get(0); } set { FlagD = BinaryHandler.setBitFromFlagTo(FlagD, 0, value); } }
        public bool Flag26 { get { return new BitArray(new int[1] { FlagD }).Get(1); } set { FlagD = BinaryHandler.setBitFromFlagTo(FlagD, 1, value); } }
        public bool Flag27 { get { return new BitArray(new int[1] { FlagD }).Get(2); } set { FlagD = BinaryHandler.setBitFromFlagTo(FlagD, 2, value); } }
        public bool Flag28 { get { return new BitArray(new int[1] { FlagD }).Get(3); } set { FlagD = BinaryHandler.setBitFromFlagTo(FlagD, 3, value); } }
        public bool Flag29 { get { return new BitArray(new int[1] { FlagD }).Get(4); } set { FlagD = BinaryHandler.setBitFromFlagTo(FlagD, 4, value); } }
        public bool Flag30 { get { return new BitArray(new int[1] { FlagD }).Get(5); } set { FlagD = BinaryHandler.setBitFromFlagTo(FlagD, 5, value); } }
        public bool Flag31 { get { return new BitArray(new int[1] { FlagD }).Get(6); } set { FlagD = BinaryHandler.setBitFromFlagTo(FlagD, 6, value); } }
        public bool Flag32 { get { return new BitArray(new int[1] { FlagD }).Get(7); } set { FlagD = BinaryHandler.setBitFromFlagTo(FlagD, 7, value); } }*/
    }
}
