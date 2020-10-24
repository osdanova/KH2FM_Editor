using KH2FM_Editor.Libs.Binary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.Model.Bar
{
    class BarFile : BarSubFile
    {
        public List<byte> Header { get; set; }
        public String Name { get; set; }
        public ObservableCollection<BarItem> Items { get; set; }
        // Items X bytes each
        public ObservableCollection<BarSubFile> SubFiles { get; set; }

        // Data Location
        public static readonly int headerSize = 16, entrySize = 16;
        public static readonly int identifierOffset = 0, identifierSize = 4;
        public static readonly int fileCountOffset = 4, fileCountSize = 4;
        public static readonly int paddingOffset = 8, paddingSize = 4;
        public static readonly int unk12Offset = 12, unk12Size = 4;

        public BarFile(String name, List<byte> raw)
        {
            this.Name = name;
            Items = new ObservableCollection<BarItem>();
            SubFiles = new ObservableCollection<BarSubFile>();
            processHeader(raw);
            processEntries(raw);
            processSubfiles(raw);
        }

        public void processHeader(List<byte> raw)
        {
            Header = raw.GetRange(0, headerSize);
        }
        public void processEntries(List<byte> raw)
        {
            int currentOffset = Header.Count;
            for (int i = 0; i < FileCount; i++)
            {
                Items.Add(new BarItem(raw.GetRange(currentOffset, entrySize)));
                currentOffset += entrySize;
            }
        }
        public void processSubfiles(List<byte> raw)
        {
            // NOTE for future -> Instead of loading all of the files, load only the one that gets open

            uint currentOffset = Items[0].Offset;
            foreach(BarItem item in Items)
            {
                // Use the handler to know which file to add
                SubFiles.Add(new RawSubFile(this.Name, item.Name, raw.GetRange((int)item.Offset, (int)item.Size)));
            }
        }


        public string Identifier
        {
            get { return DataAccess.readString(Header, identifierOffset, identifierSize); }
            set { DataAccess.writeString(Header, value, identifierOffset, identifierSize); }
        }
        public uint FileCount
        {
            get { return DataAccess.readUInt(Header, fileCountOffset, fileCountSize); }
            set { DataAccess.writeUInt(Header, value, fileCountOffset, fileCountSize); }
        }
        public uint Padding
        {
            get { return DataAccess.readUInt(Header, paddingOffset, paddingSize); }
            set { DataAccess.writeUInt(Header, value, paddingOffset, paddingSize); }
        }
        public uint Unk12
        {
            get { return DataAccess.readUInt(Header, unk12Offset, unk12Size); }
            set { DataAccess.writeUInt(Header, value, unk12Offset, unk12Size); }
        }

        public void recalcSizes()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].Size = (uint)SubFiles[i].getAsByteList().Count;
            }
        }

        public void recalcOffsets()
        {
            recalcSizes();
            for (int i = 1; i < Items.Count; i++)
            {
                Items[i].Offset = Items[i - 1].Offset + Items[i - 1].Size;
            }
        }

        // Returns the object as a byte list
        public override List<byte> getAsByteList()
        {
            recalcOffsets();

            List<byte> rawObject = new List<byte>();

            // Header
            rawObject.AddRange(Header);
            // Item entries
            foreach (BarItem item in Items) rawObject.AddRange(item.getAsByteList());
            // Items
            foreach (BarSubFile item in SubFiles) rawObject.AddRange(item.getAsByteList());

            return rawObject;
        }
    }
}
