using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Bar
{
    class RawSubFile : BarSubFile
    {
        public List<byte> raw;

        public RawSubFile(String parentBar, String name, List<byte> rawData)
        {
            ParentBarName = parentBar;
            BarName = name;
            raw = rawData;
        }
        public RawSubFile(List<byte> rawData)
        {
            raw = rawData;
        }

        public override List<byte> getAsByteList()
        {
            return raw;
        }
    }
}
