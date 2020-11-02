using KH2FM_Editor.Model.Bar;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Mixdata
{
    class MixdataFile : BarFile
    {
        public MixdataFile(String name, List<byte> raw) : base(name, raw)
        {
        }
    }
}
