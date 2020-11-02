using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Bar
{
    class RawSubFile : BarSubFile
    {
        public List<byte> raw;

        public RawSubFile(List<byte> rawData)
        {
            raw = rawData;
        }

        public List<byte> getSubFileAsByteList()
        {
            return raw;
        }
    }
}
