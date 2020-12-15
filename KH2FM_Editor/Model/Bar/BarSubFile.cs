using System.Collections.Generic;

namespace KH2FM_Editor.Model.Bar
{
    public interface BarSubFile
    {
        //public string ParentBarName { get; set; }
        //public string BarName { get; set; }
        //public virtual List<byte> getSubFileAsByteList() { return null; }
        List<byte> getSubFileAsByteList();
    }
}
