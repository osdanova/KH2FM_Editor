using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Ard.Spawn
{
    public class WalkPathItem : Str_EntryItem
    {
        public static readonly int entrySize = 12;
        // Data Location
        int xOffset = 0, yOffset = 4, zOffset = 8;
        int posSize = 4;

        public WalkPathItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public WalkPathItem(List<byte> rawData) : base(rawData)
        {
        }

        public uint PosX
        {
            get { return DataAccess.readUInt(raw, xOffset, posSize); }
            set { DataAccess.writeUInt(raw, value, xOffset, posSize); }
        }
        public uint PosY
        {
            get { return DataAccess.readUInt(raw, yOffset, posSize); }
            set { DataAccess.writeUInt(raw, value, yOffset, posSize); }
        }
        public uint PosZ
        {
            get { return DataAccess.readUInt(raw, zOffset, posSize); }
            set { DataAccess.writeUInt(raw, value, zOffset, posSize); }
        }
    }
}
