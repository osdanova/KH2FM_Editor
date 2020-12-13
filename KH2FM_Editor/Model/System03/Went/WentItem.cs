using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Went
{
    public class WentItem : Str_EntryItem
    {
        public static readonly int entrySize = 4;
        // Data Location
        public int idOffset = 0, idSize = 4;

        public WentItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public WentItem(List<byte> rawData) : base(rawData)
        {
        }

        public string Entity
        {
            get { return Entities.getValue(Id); }
        }
        public uint Id
        {
            get { return DataAccess.readUInt(raw, idOffset, idSize); }
            set { DataAccess.writeUInt(raw, value, idOffset, idSize); NotifyPropertyChanged(nameof(Entity)); }
        }
    }
}
