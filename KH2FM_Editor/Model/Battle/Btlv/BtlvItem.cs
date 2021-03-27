using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Btlv
{
    public class BtlvItem : Str_EntryItem
    {
        public static readonly int entrySize = 32;

        // Data Location
        public int idOffset = 0, idSize = 4;
        public int progFlagOffset = 4, progFlagSize = 4;
        public int btlLvl01Offset = 8, btlLvl01Size = 1;
        public int btlLvl02Offset = 9, btlLvl02Size = 1;
        public int btlLvl03Offset = 10, btlLvl03Size = 1;
        public int btlLvl04Offset = 11, btlLvl04Size = 1;
        public int btlLvl05Offset = 12, btlLvl05Size = 1;
        public int btlLvl06Offset = 13, btlLvl06Size = 1;
        public int btlLvl07Offset = 14, btlLvl07Size = 1;
        public int btlLvl08Offset = 15, btlLvl08Size = 1;
        public int btlLvl09Offset = 16, btlLvl09Size = 1;
        public int btlLvl10Offset = 17, btlLvl10Size = 1;
        public int btlLvl11Offset = 18, btlLvl11Size = 1;
        public int btlLvl12Offset = 19, btlLvl12Size = 1;
        public int btlLvl13Offset = 20, btlLvl13Size = 1;
        public int btlLvl14Offset = 21, btlLvl14Size = 1;
        public int btlLvl15Offset = 22, btlLvl15Size = 1;
        public int btlLvl16Offset = 23, btlLvl16Size = 1;
        public int btlLvl17Offset = 24, btlLvl17Size = 1;
        public int btlLvl18Offset = 25, btlLvl18Size = 1;
        public int btlLvl19Offset = 26, btlLvl19Size = 1;
        public int paddingOffset = 27, paddingSize = 5;

        public BtlvItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public BtlvItem(List<byte> rawData) : base(rawData)
        {
        }

        public int Id
        {
            get { return DataAccess.readInt(raw, idOffset, idSize); }
            set { DataAccess.writeInt(raw, value, idOffset, idSize); }
        }
        public byte BattleLevel01 { get { return DataAccess.readByte(raw, btlLvl01Offset); } set { DataAccess.writeByte(raw, value, btlLvl01Offset); } }
        public byte BattleLevel02 { get { return DataAccess.readByte(raw, btlLvl02Offset); } set { DataAccess.writeByte(raw, value, btlLvl02Offset); } }
        public byte BattleLevel03 { get { return DataAccess.readByte(raw, btlLvl03Offset); } set { DataAccess.writeByte(raw, value, btlLvl03Offset); } }
        public byte BattleLevel04 { get { return DataAccess.readByte(raw, btlLvl04Offset); } set { DataAccess.writeByte(raw, value, btlLvl04Offset); } }
        public byte BattleLevel05 { get { return DataAccess.readByte(raw, btlLvl05Offset); } set { DataAccess.writeByte(raw, value, btlLvl05Offset); } }
        public byte BattleLevel06 { get { return DataAccess.readByte(raw, btlLvl06Offset); } set { DataAccess.writeByte(raw, value, btlLvl06Offset); } }
        public byte BattleLevel07 { get { return DataAccess.readByte(raw, btlLvl07Offset); } set { DataAccess.writeByte(raw, value, btlLvl07Offset); } }
        public byte BattleLevel08 { get { return DataAccess.readByte(raw, btlLvl08Offset); } set { DataAccess.writeByte(raw, value, btlLvl08Offset); } }
        public byte BattleLevel09 { get { return DataAccess.readByte(raw, btlLvl09Offset); } set { DataAccess.writeByte(raw, value, btlLvl09Offset); } }
        public byte BattleLevel10 { get { return DataAccess.readByte(raw, btlLvl10Offset); } set { DataAccess.writeByte(raw, value, btlLvl10Offset); } }
        public byte BattleLevel11 { get { return DataAccess.readByte(raw, btlLvl11Offset); } set { DataAccess.writeByte(raw, value, btlLvl11Offset); } }
        public byte BattleLevel12 { get { return DataAccess.readByte(raw, btlLvl12Offset); } set { DataAccess.writeByte(raw, value, btlLvl12Offset); } }
        public byte BattleLevel13 { get { return DataAccess.readByte(raw, btlLvl13Offset); } set { DataAccess.writeByte(raw, value, btlLvl13Offset); } }
        public byte BattleLevel14 { get { return DataAccess.readByte(raw, btlLvl14Offset); } set { DataAccess.writeByte(raw, value, btlLvl14Offset); } }
        public byte BattleLevel15 { get { return DataAccess.readByte(raw, btlLvl15Offset); } set { DataAccess.writeByte(raw, value, btlLvl15Offset); } }
        public byte BattleLevel16 { get { return DataAccess.readByte(raw, btlLvl16Offset); } set { DataAccess.writeByte(raw, value, btlLvl16Offset); } }
        public byte BattleLevel17 { get { return DataAccess.readByte(raw, btlLvl17Offset); } set { DataAccess.writeByte(raw, value, btlLvl17Offset); } }
        public byte BattleLevel18 { get { return DataAccess.readByte(raw, btlLvl18Offset); } set { DataAccess.writeByte(raw, value, btlLvl18Offset); } }
        public byte BattleLevel19 { get { return DataAccess.readByte(raw, btlLvl19Offset); } set { DataAccess.writeByte(raw, value, btlLvl19Offset); } }

        public byte FlagA
        {
            get { return DataAccess.readByte(raw, progFlagOffset); }
            set { DataAccess.writeByte(raw, value, progFlagOffset); }
        }
        public bool Flag1 { get { return new BitArray(new int[1] { FlagA }).Get(0); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 0, value); } }
        public bool Flag2 { get { return new BitArray(new int[1] { FlagA }).Get(1); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 1, value); } }
        public bool Flag3 { get { return new BitArray(new int[1] { FlagA }).Get(2); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 2, value); } }
        public bool Flag4 { get { return new BitArray(new int[1] { FlagA }).Get(3); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 3, value); } }
        public bool Flag5 { get { return new BitArray(new int[1] { FlagA }).Get(4); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 4, value); } }
        public bool Flag6 { get { return new BitArray(new int[1] { FlagA }).Get(5); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 5, value); } }
        public bool Flag7 { get { return new BitArray(new int[1] { FlagA }).Get(6); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 6, value); } }
        public bool Flag8 { get { return new BitArray(new int[1] { FlagA }).Get(7); } set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 7, value); } }

        public byte FlagB
        {
            get { return DataAccess.readByte(raw, progFlagOffset + 1); }
            set { DataAccess.writeByte(raw, value, progFlagOffset + 1); }
        }
        public bool Flag9 { get { return new BitArray(new int[1] { FlagB }).Get(0); } set { FlagB = BinaryHandler.setBitFromFlagTo(FlagB, 0, value); } }
        public bool Flag10 { get { return new BitArray(new int[1] { FlagB }).Get(1); } set { FlagB = BinaryHandler.setBitFromFlagTo(FlagB, 1, value); } }
        public bool Flag11 { get { return new BitArray(new int[1] { FlagB }).Get(2); } set { FlagB = BinaryHandler.setBitFromFlagTo(FlagB, 2, value); } }
        public bool Flag12 { get { return new BitArray(new int[1] { FlagB }).Get(3); } set { FlagB = BinaryHandler.setBitFromFlagTo(FlagB, 3, value); } }
        public bool Flag13 { get { return new BitArray(new int[1] { FlagB }).Get(4); } set { FlagB = BinaryHandler.setBitFromFlagTo(FlagB, 4, value); } }
        public bool Flag14 { get { return new BitArray(new int[1] { FlagB }).Get(5); } set { FlagB = BinaryHandler.setBitFromFlagTo(FlagB, 5, value); } }

        // UNUSED
        /*public bool Flag15 { get { return new BitArray(new int[1] { FlagB }).Get(6); } set { FlagB = BinaryHandler.setBitFromFlagTo(FlagB, 6, value); } }
        public bool Flag16 { get { return new BitArray(new int[1] { FlagB }).Get(7); } set { FlagB = BinaryHandler.setBitFromFlagTo(FlagB, 7, value); } }

        public byte FlagC
        {
            get { return DataAccess.readByte(raw, progFlagOffset + 2); }
            set { DataAccess.writeByte(raw, value, progFlagOffset + 2); }
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
            get { return DataAccess.readByte(raw, progFlagOffset + 3); }
            set { DataAccess.writeByte(raw, value, progFlagOffset + 3); }
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
