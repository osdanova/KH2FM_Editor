using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Evtp
{
    class EvtpItem : Str_EntryItem
    {
        public static readonly int entrySize = 8;
        // Data Location
        public int idOffset = 0, idSize = 1;
        public int unk1Offset = 1, unk1Size = 2;
        public int unk3Offset = 3, unk3Size = 3;
        public int unk6Offset = 6, unk6Size = 2;

        public EvtpItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public EvtpItem(List<byte> rawData) : base(rawData)
        {
        }

        public byte Id
        {
            get { return DataAccess.readByte(raw, idOffset); }
            set { DataAccess.writeByte(raw, value, idOffset); }
        }
        public string Unk1
        {
            get { return DataAccess.readHexString(raw, unk1Offset, unk1Size); }
            set { DataAccess.writeHexString(raw, value, unk1Offset, unk1Size); }
        }
        public string Unk3
        {
            get { return DataAccess.readHexString(raw, unk3Offset, unk3Size); }
            set { DataAccess.writeHexString(raw, value, unk3Offset, unk3Size); }
        }
        public string Unk6
        {
            get { return DataAccess.readHexString(raw, unk6Offset, unk6Size); }
            set { DataAccess.writeHexString(raw, value, unk6Offset, unk6Size); }
        }
    }
}
