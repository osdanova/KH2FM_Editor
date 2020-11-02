using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Vtbl
{
    public class VtblItem : Str_EntryItem
    {
        public static readonly int entrySize = 14;

        public VtblItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public VtblItem(List<byte> rawData) : base(rawData)
        {
        }
    }
}
