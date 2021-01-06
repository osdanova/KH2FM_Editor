using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Trsr
{
    class TrsrItem : Str_EntryItem
    {
        public static readonly int entrySize = 12;
        // Data Location
        public int idOffset = 0, idSize = 2;
        public int itemOffset = 2, itemSize = 2;
        public int typeOffset = 4, typeSize = 1;
        public int worldOffset = 5, worldSize = 1;
        public int roomOffset = 6, roomSize = 1;
        public int roomIndexOffset = 7, roomIndexSize = 1;
        public int eventOffset = 8, eventSize = 2;
        public int globalIndexOffset = 10, globalIndexSize = 2;

        public TrsrItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public TrsrItem(List<byte> rawData) : base(rawData)
        {
        }

        public ushort Id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); }
        }
        public string ItemValue
        {
            get { return Items.getValue(Item); }
        }
        public ushort Item
        {
            get { return DataAccess.readUShort(raw, itemOffset, itemSize); }
            set { DataAccess.writeUShort(raw, value, itemOffset, itemSize); NotifyPropertyChanged(nameof(ItemValue)); }
        }
        public String typeValue
        {
            get
            {
                if (Type == 0) return "Chest";
                else if (Type == 1) return "Event";
                else return "";
            }
        }
        public byte Type
        {
            get { return DataAccess.readByte(raw, typeOffset); }
            set { DataAccess.writeByte(raw, value, typeOffset); NotifyPropertyChanged(nameof(typeValue)); }
        }
        public string RoomName
        {
            get
            {
                if (raw == null || raw.GetRange(worldOffset, worldSize) == null) return "";
                if (raw == null || raw.GetRange(roomOffset, roomSize) == null) return "";
                string worldName = Worlds.getValue(World);
                string roomString = "" + worldName + Room.ToString("D2");
                return Rooms.getValue(roomString);
            }
        }
        public byte World
        {
            get { return DataAccess.readByte(raw, worldOffset); }
            set { DataAccess.writeByte(raw, value, worldOffset); NotifyPropertyChanged(nameof(RoomName)); }
        }
        public byte Room
        {
            get { return DataAccess.readByte(raw, roomOffset); }
            set { DataAccess.writeByte(raw, value, roomOffset); NotifyPropertyChanged(nameof(RoomName)); }
        }
        public byte RoomIndex
        {
            get { return DataAccess.readByte(raw, roomIndexOffset); }
            set { DataAccess.writeByte(raw, value, roomIndexOffset); }
        }
        public ushort Event
        {
            get { return DataAccess.readUShort(raw, eventOffset, eventSize); }
            set { DataAccess.writeUShort(raw, value, eventOffset, eventSize); }
        }
        public ushort GlobalIndex
        {
            get { return DataAccess.readUShort(raw, globalIndexOffset, globalIndexSize); }
            set { DataAccess.writeUShort(raw, value, globalIndexOffset, globalIndexSize); }
        }
    }
}
