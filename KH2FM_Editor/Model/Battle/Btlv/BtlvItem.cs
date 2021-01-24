using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
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
        public int ProgressFlag
        {
            get { return DataAccess.readInt(raw, progFlagOffset, progFlagSize); }
            set { DataAccess.writeInt(raw, value, progFlagOffset, progFlagSize); }
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
    }
}
