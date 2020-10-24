using System.Collections.Generic;

namespace KH2FM_Editor.Model.Bar
{
    class BarSubFileHandler
    {
        public static BarSubFile handleSubFile(string parentBar, string name, List<byte> raw)
        {
            if (name == "") return new RawSubFile(parentBar, name, raw);
            return new RawSubFile(parentBar, name, raw);
        }
    }
}
