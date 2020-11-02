using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Mixdata.Leve
{
    class LeveItem : Str_EntryItem
    {
        public static readonly int entrySize = 12;
        // Data Location
        public static readonly int idOffset = 0, idSize = 2;
        public static readonly int unk02Offset = 2, unk02Size = 2;
        public static readonly int unk04Offset = 4, unk04Size = 2;
        public static readonly int unk06Offset = 6, unk06Size = 2;
        public static readonly int expOffset = 8, expSize = 4;

        public LeveItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public LeveItem(List<byte> rawData) : base(rawData)
        {
        }

        public ushort Id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); }
        }
        public string Unk02
        {
            get { return DataAccess.readHexString(raw, unk02Offset, unk02Size); }
            set { DataAccess.writeHexString(raw, value, unk02Offset, unk02Size); }
        }
        public string Unk04
        {
            get { return DataAccess.readHexString(raw, unk04Offset, unk04Size); }
            set { DataAccess.writeHexString(raw, value, unk04Offset, unk04Size); }
        }
        public string Unk06
        {
            get { return DataAccess.readHexString(raw, unk06Offset, unk06Size); }
            set { DataAccess.writeHexString(raw, value, unk06Offset, unk06Size); }
        }
        public uint Exp
        {
            get { return DataAccess.readUInt(raw, expOffset, expSize); }
            set { DataAccess.writeUInt(raw, value, expOffset, expSize); }
        }
    }
}
