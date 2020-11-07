using KH2FM_Editor.Libs.Binary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KH2FM_Editor.Model.Ard.Spawn
{
    public class WalkPathFile
    {
        // Data
        List<Byte> Header { get; set; }
        public ObservableCollection<WalkPathItem> Items { get; set; }

        // Data location
        public static readonly int headerOffset = 0, headerSize = 8;
        public static readonly int unk0Offset = 0, unk0Size = 2;
        public static readonly int itemCountOffset = 2, itemCountSize = 2;
        public static readonly int unk4Offset = 4, unk4Size = 2;
        public static readonly int unk6Offset = 6, unk6Size = 2;

        private WalkPathFile() { }
        public WalkPathFile(List<Byte> rawData)
        {
            Header = rawData;
        }
        public static WalkPathFile headerConstructor(List<Byte> rawHeader)
        {
            WalkPathFile data = new WalkPathFile();
            data.Header = rawHeader;
            return data;
        }
        public void addData(List<Byte> rawData)
        {
            int currentOffset = 0;
            foreach (var i in Enumerable.Range(0, ItemCount))
            {
                Items.Add(new WalkPathItem(rawData.GetRange(currentOffset, WalkPathItem.entrySize)));
                currentOffset += WalkPathItem.entrySize;
            }
        }

        public ushort ItemCount
        {
            get { return DataAccess.readUShort(Header, itemCountOffset, itemCountSize); }
            set { DataAccess.writeUShort(Header, value, itemCountOffset, itemCountSize); }
        }

        // Generate the item for saving
        public List<byte> getAsByteList()
        {
            recalcCounts();

            List<byte> rawItem = new List<byte>();
            // Header
            rawItem.AddRange(Header);
            // Entity spawns
            foreach (WalkPathItem wp in Items) rawItem.AddRange(wp.getAsByteList());

            return rawItem;
        }

        void recalcCounts()
        {
            ItemCount = (ushort)Items.Count;
        }
    }
}
