using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Sklt
{
    class SkltItem : Str_EntryItem
    {
        public static readonly int entrySize = 8;
        // Data Location
        public int idOffset = 0, idSize = 4;
        public int unk4Offset = 4, unk4Size = 2;
        public int unk6Offset = 6, unk6Size = 2;

        public SkltItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public SkltItem(List<byte> rawData) : base(rawData)
        {
        }

        public uint Id
        {
            get { return DataAccess.readUInt(raw, idOffset, idSize); }
            set { DataAccess.writeUInt(raw, value, idOffset, idSize); }
        }
        public string Unk4
        {
            get { return DataAccess.readHexString(raw, unk4Offset, unk4Size); }
            set { DataAccess.writeHexString(raw, value, unk4Offset, unk4Size); }
        }
        public string Unk6
        {
            get { return DataAccess.readHexString(raw, unk6Offset, unk6Size); }
            set { DataAccess.writeHexString(raw, value, unk6Offset, unk6Size); }
        }
    }
}
