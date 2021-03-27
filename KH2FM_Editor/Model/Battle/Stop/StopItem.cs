using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Stop
{
    class StopItem : Str_EntryItem
    {
        public static readonly int entrySize = 4;
        // Data Location
        public int idOffset = 0, idSize = 2;
        public int flagsOffset = 2, flagsSize = 2;

        public StopItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public StopItem(List<byte> rawData) : base(rawData)
        {
        }

        public ushort Id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); }
        }
        public bool Exist
        {
            get { return new BitArray(new int[1] { FlagA }).Get(0); }
            set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 0, value); }
        }
        public bool DisableDamageReaction
        {
            get { return new BitArray(new int[1] { FlagA }).Get(1); }
            set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 1, value); }
        }
        public bool Star
        {
            get { return new BitArray(new int[1] { FlagA }).Get(2); }
            set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 2, value); }
        }
        public bool DisableDraw
        {
            get { return new BitArray(new int[1] { FlagA }).Get(3); }
            set { FlagA = BinaryHandler.setBitFromFlagTo(FlagA, 3, value); }
        }
        public byte FlagA
        {
            get { return DataAccess.readByte(raw, flagsOffset); }
            set { DataAccess.writeByte(raw, value, flagsOffset); }
        }
    }
}
