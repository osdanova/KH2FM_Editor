using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Ptya
{
    public class PtyaItem : Str_EntryItem
    {
        public static readonly int entrySize = 68;
        // Data Location
        public int idOffset = 0, idSize = 1;
        public int typeOffset = 1, typeSize = 1;
        public int subOffset = 2, subSize = 1;
        public int comboOfstOffset = 3, comboOfstSize = 1;
        public int flagOffset = 4, flagSize = 4;
        public int motionOffset = 8, motionSize = 2;
        public int nextMotionOffset = 10, nextMotionSize = 2;
        public int jumpOffset = 12, jumpSize = 4;
        public int jumpMaxOffset = 16, jumpMaxSize = 4;
        public int jumpMinOffset = 20, jumpMinSize = 4;
        public int speedMinOffset = 24, speedMinSize = 4;
        public int speedMaxOffset = 28, speedMaxSize = 4;
        public int nearOffset = 32, nearSize = 4;
        public int farOffset = 36, farSize = 4;
        public int lowOffset = 40, lowSize = 4;
        public int highOffset = 44, highSize = 4;
        public int innerMinOffset = 48, innerMinSize = 4;
        public int innerMaxOffset = 52, innerMaxSize = 4;
        public int blendTimeOffset = 56, blendTimeSize = 4;
        public int distanceAdjustOffset = 60, distanceAdjustSize = 4;
        public int abilityOffset = 64, abilitySize = 2;
        public int scoreOffset = 66, scoreSize = 2;

        public PtyaItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public PtyaItem(List<byte> rawData) : base(rawData)
        {
        }

        public byte Id
        {
            get { return DataAccess.readByte(raw, idOffset); }
            set { DataAccess.writeByte(raw, value, idOffset); }
        }
        public byte Type
        {
            get { return DataAccess.readByte(raw, typeOffset); }
            set { DataAccess.writeByte(raw, value, typeOffset); }
        }
        public sbyte Sub
        {
            get { return DataAccess.readSByte(raw, subOffset); }
            set { DataAccess.writeSByte(raw, value, subOffset); }
        }
        public sbyte ComboOffset
        {
            get { return DataAccess.readSByte(raw, comboOfstOffset); }
            set { DataAccess.writeSByte(raw, value, comboOfstOffset); }
        }
        public string MotionName
        {
            get { return Animations.getSoraAnimation((ushort)(Motion * 4)); }
        }
        public string MotionValue
        {
            get { return "" + Motion * 4; }
        }
        public ushort Motion
        {
            get { return DataAccess.readUShort(raw, motionOffset, motionSize); }
            set { DataAccess.writeUShort(raw, value, motionOffset, motionSize); NotifyPropertyChanged(nameof(MotionValue)); }
        }
        public string NextMotionName
        {
            get { return Animations.getSoraAnimation((ushort)(NextMotion * 4)); }
        }
        public string NextMotionValue
        {
            get { return "" + NextMotion * 4; }
        }
        public ushort NextMotion
        {
            get { return DataAccess.readUShort(raw, nextMotionOffset, nextMotionSize); }
            set { DataAccess.writeUShort(raw, value, nextMotionOffset, nextMotionSize); NotifyPropertyChanged(nameof(NextMotionValue)); }
        }
        public float Jump
        {
            get { return DataAccess.readFloat(raw, jumpOffset, jumpSize); }
            set { DataAccess.writeFloat(raw, value, jumpOffset, jumpSize); }
        }
        public float JumpMax
        {
            get { return DataAccess.readFloat(raw, jumpMaxOffset, jumpMaxSize); }
            set { DataAccess.writeFloat(raw, value, jumpMaxOffset, jumpMaxSize); }
        }
        public float JumpMin
        {
            get { return DataAccess.readFloat(raw, jumpMinOffset, jumpMinSize); }
            set { DataAccess.writeFloat(raw, value, jumpMinOffset, jumpMinSize); }
        }
        public float SpeedMin
        {
            get { return DataAccess.readFloat(raw, speedMinOffset, speedMinSize); }
            set { DataAccess.writeFloat(raw, value, speedMinOffset, speedMinSize); }
        }
        public float SpeedMax
        {
            get { return DataAccess.readFloat(raw, speedMaxOffset, speedMaxSize); }
            set { DataAccess.writeFloat(raw, value, speedMaxOffset, speedMaxSize); }
        }
        public float Near
        {
            get { return DataAccess.readFloat(raw, nearOffset, nearSize); }
            set { DataAccess.writeFloat(raw, value, nearOffset, nearSize); }
        }
        public float Far
        {
            get { return DataAccess.readFloat(raw, farOffset, farSize); }
            set { DataAccess.writeFloat(raw, value, farOffset, farSize); }
        }
        public float Low
        {
            get { return DataAccess.readFloat(raw, lowOffset, lowSize); }
            set { DataAccess.writeFloat(raw, value, lowOffset, lowSize); }
        }
        public float High
        {
            get { return DataAccess.readFloat(raw, highOffset, highSize); }
            set { DataAccess.writeFloat(raw, value, highOffset, highSize); }
        }
        public float InnerMin
        {
            get { return DataAccess.readFloat(raw, innerMinOffset, innerMinSize); }
            set { DataAccess.writeFloat(raw, value, innerMinOffset, innerMinSize); }
        }
        public float InnerMax
        {
            get { return DataAccess.readFloat(raw, innerMaxOffset, innerMaxSize); }
            set { DataAccess.writeFloat(raw, value, innerMaxOffset, innerMaxSize); }
        }
        public float BlendTime
        {
            get { return DataAccess.readFloat(raw, blendTimeOffset, blendTimeSize); }
            set { DataAccess.writeFloat(raw, value, blendTimeOffset, blendTimeSize); }
        }
        public float DistanceAdjust
        {
            get { return DataAccess.readFloat(raw, distanceAdjustOffset, distanceAdjustSize); }
            set { DataAccess.writeFloat(raw, value, distanceAdjustOffset, distanceAdjustSize); }
        }
        public string AbilityValue
        {
            get { return Abilities.getValue(Ability); }
        }
        public ushort Ability
        {
            get { return DataAccess.readUShort(raw, abilityOffset, abilitySize); }
            set { DataAccess.writeUShort(raw, value, abilityOffset, abilitySize); NotifyPropertyChanged(nameof(AbilityValue)); }
        }
        public ushort Score
        {
            get { return DataAccess.readUShort(raw, scoreOffset, scoreSize); }
            set { DataAccess.writeUShort(raw, value, scoreOffset, scoreSize); }
        }

        public byte FlagA
        {
            get { return DataAccess.readByte(raw, flagOffset); }
            set { DataAccess.writeByte(raw, value, flagOffset); }
        }
        public bool Flag1 { get { return new BitArray(new int[1] { FlagA }).Get(0); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 0, value); } }
        public bool Flag2 { get { return new BitArray(new int[1] { FlagA }).Get(1); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 1, value); } }
        public bool Flag3 { get { return new BitArray(new int[1] { FlagA }).Get(2); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 2, value); } }
        public bool Flag4 { get { return new BitArray(new int[1] { FlagA }).Get(3); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 3, value); } }
        
        // UNUSED
        /*public bool Flag5 { get { return new BitArray(new int[1] { FlagA }).Get(4); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 4, value); } }
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
        public bool Flag18 { get { return new BitArray(new int[1] { FlagC }).Get(1); } set { FlagC = BinaryHandler.setBitFromFlagTo(FlagC, 1, value); } }
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
