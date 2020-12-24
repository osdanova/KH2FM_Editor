using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Rcct
{
    public class RcctItem : Str_EntryItem
    {
        public static readonly int entrySize = 12;
        // Data Location
        public int rawOffset = 0, rawSize = 12;

        public RcctItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public RcctItem(List<byte> rawData) : base(rawData)
        {
        }

        public string Raw
        {
            get { return DataAccess.readHexString(raw, rawOffset, rawSize); }
            set { DataAccess.writeHexString(raw, value, rawOffset, rawSize); }
        }
    }
}
