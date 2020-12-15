using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Pref.Magi
{
    public class MagiItem : Str_EntryItem
    {
        public static readonly int entrySize = 124;
        // Data Location
        public int rawOffset = 0, rawSize = 124;

        public MagiItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public MagiItem(List<byte> rawData) : base(rawData)
        {
        }

        public string Raw
        {
            get { return DataAccess.readHexString(raw, rawOffset, rawSize); }
            set { DataAccess.writeHexString(raw, value, rawOffset, rawSize); }
        }
    }
}
