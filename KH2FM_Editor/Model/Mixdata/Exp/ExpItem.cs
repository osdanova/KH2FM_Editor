using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Mixdata.Exp
{
    class ExpItem : Str_EntryItem
    {
        public static readonly int entrySize = 20;
        // Data Location
        public static readonly int rawOffset = 0, rawSize = 20;

        public ExpItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public ExpItem(List<byte> rawData) : base(rawData)
        {
        }

        public string RawData
        {
            get { return DataAccess.readHexString(raw, rawOffset, rawSize); }
            set { DataAccess.writeHexString(raw, value, rawOffset, rawSize); }
        }
    }
}
