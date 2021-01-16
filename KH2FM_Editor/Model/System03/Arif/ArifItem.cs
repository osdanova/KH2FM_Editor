using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Arif
{
    public class ArifItem : Str_EntryItem
    {
        // Data Location
        public static readonly int Size = 64;
        public int rawOffset = 0, rawSize = 64;

        public ArifItem()
        {
            raw = FormatHandler.getByteListOfSize(Size);
        }
        public ArifItem(List<byte> rawData) : base(rawData)
        {
        }

        public string Raw
        {
            get { return DataAccess.readHexString(raw, rawOffset, rawSize); }
            set { DataAccess.writeHexString(raw, value, rawOffset, rawSize); }
        }
    }
}
