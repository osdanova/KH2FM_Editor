using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.Bar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KH2FM_Editor.Model.System03.Arif
{
    public class ArifFile : BarSubFile
    {
        // Contains a list of programs
        public String Name { get; set; }
        public List<byte> Header { get; set; }
        public ObservableCollection<ArifPointer> Pointers { get; set; }
        public ObservableCollection<ArifBlock> Blocks { get; set; }
        //public ObservableCollection<ArifItem> Entries { get; set; }

        // Data Location
        protected int headerOffset = 0, headerSize = 8;
        protected int pointerCountOffset = 4, pointerCountSize = 4;

        public ArifFile(String name, List<byte> raw)
        {
            Console.WriteLine("DEBUG >>> Found Arif file: " + name);
            this.Name = name;
            processFile(raw);
        }

        public uint PointerCount
        {
            get { return DataAccess.readUInt(Header, pointerCountOffset, pointerCountSize); }
            set { DataAccess.writeUInt(Header, value, pointerCountOffset, pointerCountSize); }
        }

        public void processFile(List<byte> raw)
        {
            processHeader(raw);
            // Pointers
            processPointers(raw, headerSize);
            // Inventories
            //int inventoryStartOffset = headerSize + (int)(Pointers.Count * ArifPointer.Size);
            processBlocks(raw);
        }

        public void processHeader(List<byte> raw)
        {
            Header = raw.GetRange(headerOffset, headerSize);
        }

        public void processPointers(List<byte> raw, int offset)
        {
            Pointers = new ObservableCollection<ArifPointer>();
            int currentOffset = offset;

            for (int i = 0; i < PointerCount; i++)
            {
                Pointers.Add(new ArifPointer(raw.GetRange(currentOffset, ArifPointer.Size)));
                currentOffset += ArifPointer.Size;
            }
        }
        public void processBlocks(List<byte> raw)
        {
            Blocks = new ObservableCollection<ArifBlock>();
            byte worldId = 0;

            foreach(ArifPointer pointer in Pointers)
            {
                //Console.WriteLine("DELETE DEBUG >>> Pointer at: " + pointer.EntryOffset + ", count: " + pointer.EntryCount);

                Blocks.Add(new ArifBlock(worldId, raw.GetRange(pointer.EntryOffset, pointer.EntryCount * ArifItem.Size), pointer.EntryCount));
                worldId++;
            }
        }

        public void recalcEntryCount()
        {
            // Too much of a mess for an unknown file, don't add or remove entries
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            List<byte> data = new List<byte>();

            //recalcEntryCount();

            // Header
            data.AddRange(Header);
            // Pointers
            foreach (ArifPointer pointer in Pointers)
            {
                data.AddRange(pointer.getAsByteList());
            }
            // Blocks
            foreach (ArifBlock entry in Blocks)
            {
                data.AddRange(entry.getAsByteList());
            }

            return data;
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}
