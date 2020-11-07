namespace KH2FM_Editor
{
    class ARDitemSpawn //: FileTypes.FileItem
    {/*
        // Data
        string name;
        List<byte> header;
        List<ARDblock> blocks = new List<ARDblock>();
        List<byte> rawData;

        // Data Location
        int headerSize = 8;
        int blockCountOffset = 4, blockCountSize = 4;

        // Block Data
        int blockHeaderSize = 44;
        int spawnSize = 64;
        int walkPathHeaderSize = 8;
        int unk16Size = 16;
        int unk8Size = 8;

        public ARDitemSpawn(string name, List<byte> raw)
        {
            Console.WriteLine("DEBUG >>> Processing " + name + ", size: " + raw.Count);
            //this.raw = raw;
            this.name = name;
            if (raw.Count > 7) processData(raw);
            else rawData = raw;
        }


        private void processData(List<byte> rawData)
        {
            int currentOffset = 0;
            ARDblock currentBlock;
            WalkPath walkPath;
            // Header
            header = rawData.GetRange(0, headerSize);
            currentOffset += headerSize;
            Console.WriteLine("DEBUG >>> Found " + getBlockCount() + " blocks");
            // Blocks
            for (int i = 0; i < getBlockCount(); i++)
            {
                // Block header - 44 bytes
                currentBlock = new ARDblock(rawData.GetRange(currentOffset, blockHeaderSize));
                currentOffset += blockHeaderSize;

                Console.WriteLine("DEBUG >>> Reading block " + currentBlock.getID() + " at offset: " + currentOffset);
                Console.WriteLine("DEBUG >>> Entity count: " + currentBlock.getEntityCount());
                Console.WriteLine("DEBUG >>> Event count: " + currentBlock.getEventCount());
                Console.WriteLine("DEBUG >>> Walk Path count: " + currentBlock.getWalkPathCount());
                Console.WriteLine("DEBUG >>> unknown16 count: " + currentBlock.getUnk16Count());
                Console.WriteLine("DEBUG >>> unknown8 count: " + currentBlock.getUnk8Count());

                // Entities - 64 bytes each
                for (int j = 0; j < currentBlock.getEntityCount(); j++)
                {
                    Console.WriteLine("DEBUG >>> Reading entity #" + j + " at offset: " + currentOffset);
                    currentBlock.entitySpawns.Add(new Spawn(rawData.GetRange(currentOffset, spawnSize)));
                    currentOffset += spawnSize;
                }
                // Events - 64 bytes each
                for (int j = 0; j < currentBlock.getEventCount(); j++)
                {
                    Console.WriteLine("DEBUG >>> Reading event #" + j + " at offset: " + currentOffset);
                    currentBlock.eventSpawns.Add(new Spawn(rawData.GetRange(currentOffset, spawnSize)));
                    currentOffset += spawnSize;
                }
                // Walk Paths - 8 + X*12 bytes each
                for (int j = 0; j < currentBlock.getWalkPathCount(); j++)
                {
                    Console.WriteLine("DEBUG >>> Reading path #" + j + " at offset: " + currentOffset);
                    walkPath = new WalkPath(rawData.GetRange(currentOffset, walkPathHeaderSize));
                    currentOffset += walkPathHeaderSize;
                    // Walk Path Points
                    for(int k = 0; k < walkPath.getWalkPathPointCount(); k++)
                    {
                        Console.WriteLine("DEBUG >>> Reading path point #" + k + " at offset: " + currentOffset);
                        walkPath.walkPathPoints.Add(new WalkPathPoint(rawData.GetRange(currentOffset, walkPath.walkPathPointSize)));
                        currentOffset += walkPath.walkPathPointSize;
                    }
                    currentBlock.walkPathSpawns.Add(walkPath);
                }
                // Unknown16 - 16 bytes each
                for (int j = 0; j < currentBlock.getUnk16Count(); j++)
                {
                    Console.WriteLine("DEBUG >>> Reading unknown16 #" + j + " at offset: " + currentOffset);
                    currentBlock.unk16Spawns.Add(new ByteList(rawData.GetRange(currentOffset, unk16Size)));
                    currentOffset += unk16Size;
                }
                // Unknown8 - 8 bytes each
                for (int j = 0; j < currentBlock.getUnk8Count(); j++)
                {
                    Console.WriteLine("DEBUG >>> Reading unknown8 #" + j + " at offset: " + currentOffset);
                    currentBlock.unk8Spawns.Add(new ByteList(rawData.GetRange(currentOffset, unk8Size)));
                    currentOffset += unk8Size;
                }

                blocks.Add(currentBlock);
            }
        }

        public int getBlockCount()
        {
            return Utils.byteList2Int(header.GetRange(blockCountOffset, blockCountSize));
        }
        public void setBlockCount(int value)
        {
            header.RemoveRange(blockCountOffset, blockCountSize);
            header.InsertRange(blockCountOffset, Utils.int2ByteList(value));
        }
        void recalcBlockCount()
        {
            setBlockCount(blocks.Count);
        }

        // ---------------------------------------------------------
        // GENERIC ARDITEM


        // Create Control to show data
        public override Tuple<String, Control> getControl()
        {
            if (header == null)
            {
                RichTextBox output = new RichTextBox();
                output.AutoSize = true;
                output.Dock = DockStyle.Fill;
                //output.Text = Utils.SpliceText(Utils.byteArrayToHEXstring(raw.ToArray()), 64);
                return new Tuple<string, Control>(name, output);
            }

            // TabControl
            TabControl tabControl = new TabControl();
            tabControl.AutoSize = true;
            tabControl.Dock = DockStyle.Fill;
            TabPage tab;
            String tabName;

            for (int i = 0; i < blocks.Count; i++)
            {
                ARDblock block = blocks[i];
                tabName = "Block_" + i;
                tab = new TabPage(tabName);
                tab.Name = tabName;
                tabControl.TabPages.Add(tab);
                tabControl.TabPages[tabName].Controls.Add(block.getTabControl());
            }

            return new Tuple<string, Control>(name, tabControl);
        }

        // Generate the item for saving
        public override List<byte> generateItem()
        {
            if (header == null) return rawData;

            recalcBlockCount();
            Console.WriteLine("DGP >> Recalc item: " + name);

            List<byte> rawItem = new List<byte>();
            // Header
            rawItem.AddRange(header);
            // Blocks
            foreach (ARDblock block in blocks) rawItem.AddRange(block.generateItem());

            return rawItem;
        }*/
    }
}
