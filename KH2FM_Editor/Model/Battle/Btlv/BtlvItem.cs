using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Btlv
{
    public class BtlvItem : Str_EntryItem
    {
        public static readonly int entrySize = 32;

        public BtlvItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public BtlvItem(List<byte> rawData) : base(rawData)
        {
        }

    }
}
