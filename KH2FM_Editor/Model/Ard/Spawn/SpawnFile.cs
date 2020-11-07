using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.Bar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KH2FM_Editor.Model.Ard.Spawn
{
    public class SpawnFile : BarSubFile
    {
        // Contains a header and a list of Blocks
        public string Name { get; set; }
        public List<byte> Header { get; set; }
        public ObservableCollection<ArdBlockFile> Blocks { get; set; }
        public List<byte> Raw { get; set; }

        // Data Location
        protected int headerOffset = 0, headerSize = 8;
        protected int typeOffset = 0, typeSize = 4;
        protected int blockCountOffset = 4, blockCountSize = 4;

        public SpawnFile(string name, List<byte> rawData)
        {
            Console.WriteLine("DEBUG >>> Processing " + name + ", size: " + rawData.Count);
            Name = name;
            if (rawData.Count >= headerSize) processData(rawData);
            else Raw = rawData;
        }

        public ushort Type
        {
            get { return DataAccess.readUShort(Header, typeOffset, typeSize); }
            set { DataAccess.writeUShort(Header, value, typeOffset, typeSize); }
        }
        public ushort BlockCount
        {
            get { return DataAccess.readUShort(Header, blockCountOffset, blockCountSize); }
            set { DataAccess.writeUShort(Header, value, blockCountOffset, blockCountSize); }
        }

        private void processData(List<byte> rawData)
        {
            Blocks = new ObservableCollection<ArdBlockFile>();

            int currentOffset = 0;

            Header = rawData.GetRange(0, headerSize);
            currentOffset += headerSize;

            Console.WriteLine("DEBUG >>> Found " + BlockCount + " blocks");
            // Blocks
            foreach (var i in Enumerable.Range(0, BlockCount))
            {
                // Blocks only read up to their size, so no need to pass only their data
                ArdBlockFile currentBlock = new ArdBlockFile(rawData.GetRange(currentOffset, rawData.Count - currentOffset));
                Blocks.Add(currentBlock);
                currentOffset += currentBlock.getAsByteList().Count;
            }
        }

        void recalcCounts()
        {
            BlockCount = (ushort)Blocks.Count;
        }

        // Generate the item for saving
        public List<byte> getAsByteList()
        {
            if (Header == null) return Raw;

            recalcCounts();

            List<byte> rawItem = new List<byte>();
            // Header
            rawItem.AddRange(Header);
            // Blocks
            foreach (ArdBlockFile block in Blocks) rawItem.AddRange(block.getAsByteList());

            return rawItem;
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}
