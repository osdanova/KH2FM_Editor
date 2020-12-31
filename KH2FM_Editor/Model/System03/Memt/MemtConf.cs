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
        public static readonly int playerOffset = 16, playerSize = 1;
        public static readonly int party1Offset = 18, party1Size = 1;
        public static readonly int party2Offset = 20, party2Size = 1;
        public static readonly int party3Offset = 22, party3Size = 1;

        public MemtConf()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public MemtConf(List<byte> rawData) : base(rawData)
        {
        }

        public ushort Player
        {
            get { return DataAccess.readUShort(raw, playerOffset, playerSize); }
            set { DataAccess.writeUShort(raw, value, playerOffset, playerSize); }
        }
        public ushort Party1
        {
            get { return DataAccess.readUShort(raw, party1Offset, party1Size); }
            set { DataAccess.writeUShort(raw, value, party1Offset, party1Size); }
        }
        public ushort Party2
        {
            get { return DataAccess.readUShort(raw, party2Offset, party2Size); }
            set { DataAccess.writeUShort(raw, value, party2Offset, party2Size); }
        }
        public ushort Party3
        {
            get { return DataAccess.readUShort(raw, party3Offset, party3Size); }
            set { DataAccess.writeUShort(raw, value, party3Offset, party3Size); }
        }
    }
}
