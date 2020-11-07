using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Bar
{
    class RawSubFile : BarSubFile
    {
        public List<byte> raw;
        public string Name { get; set; }

        public RawSubFile(string name, List<byte> rawData)
        {
            raw = rawData;
            Name = name;
        }

        public List<byte> getSubFileAsByteList()
        {
            return raw;
        }
    }
}
