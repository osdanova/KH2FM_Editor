using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Memt
{
    class MemtConf : Str_EntryItem
    {
        public static readonly int entryCount = 7;
        public static readonly int entrySize = 4;
        // Data Location
        public static readonly int playerOffset = 0, playerSize = 1;
        public static readonly int party1Offset = 1, party1Size = 1;
        public static readonly int party2Offset = 2, party2Size = 1;
        public static readonly int party3Offset = 3, party3Size = 1;

        public MemtConf()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public MemtConf(List<byte> rawData) : base(rawData)
        {
        }

        public byte Player
        {
            get { return DataAccess.readByte(raw, playerOffset); }
            set { DataAccess.writeByte(raw, value, playerOffset); }
        }
        public byte Party1
        {
            get { return DataAccess.readByte(raw, party1Offset); }
            set { DataAccess.writeByte(raw, value, party1Offset); }
        }
        public byte Party2
        {
            get { return DataAccess.readByte(raw, party2Offset); }
            set { DataAccess.writeByte(raw, value, party2Offset); }
        }
        public byte Party3
        {
            get { return DataAccess.readByte(raw, party3Offset); }
            set { DataAccess.writeByte(raw, value, party3Offset); }
        }
    }
}
