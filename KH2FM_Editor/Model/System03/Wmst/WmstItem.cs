using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Wmst
{
    class WmstItem : Str_EntryItem
    {
        public static readonly int entrySize = 32;
        // Data Location
        public int nameOffset = 0, nameSize = 32;

        public WmstItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public WmstItem(List<byte> rawData) : base(rawData)
        {
        }

        public string Name
        {
            get { return DataAccess.readString(raw, nameOffset, nameSize); }
            set { DataAccess.writeString32(raw, value, nameOffset, nameSize); }
        }
    }
}
