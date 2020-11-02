using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Stop
{
    class StopItem : Str_EntryItem
    {
        public static readonly int entrySize = 4;
        // Data Location
        public int idOffset = 0, idSize = 2;
        public int unk2Offset = 2, unk2Size = 2;

        public StopItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public StopItem(List<byte> rawData) : base(rawData)
        {
        }

        public ushort Id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); }
        }
        public ushort Unk2
        {
            get { return DataAccess.readUShort(raw, unk2Offset, unk2Size); }
            set { DataAccess.writeUShort(raw, value, unk2Offset, unk2Size); }
        }
    }
}
