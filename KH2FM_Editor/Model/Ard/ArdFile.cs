using KH2FM_Editor.Model.Bar;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Ard
{
    class ArdFile : BarFile
    {
        public ArdFile(String name, List<byte> raw) : base(name, raw)
        {
        }
    }
}
