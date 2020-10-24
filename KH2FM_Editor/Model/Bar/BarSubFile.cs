using System.Collections.Generic;

namespace KH2FM_Editor.Model.Bar
{
    public class BarSubFile
    {
        public string ParentBarName { get; set; }
        public string BarName { get; set; }
        public virtual List<byte> getAsByteList() { return null; }
    }
}
