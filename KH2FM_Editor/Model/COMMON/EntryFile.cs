using KH2FM_Editor.Libs.Binary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.Model.COMMON
{
    /* 
     * Entry Files contain a header, with its type and the entry count. Followed by the entry list.
     * If they have a name, it comes from their parent file.
     * There are EntryFiles that have headers of 16, 8 & 4 bytes
     * I've set the default as 8. which is the most common
     */
    public class EntryFile
    {
        public String Name { get; set; }
        public List<byte> Header { get; set; }
        public ObservableCollection<EntryItem> Entries { get; set; }

        // Data Location
        protected int headerOffset = 0, headerSize = 8;
        protected int typeOffset = 0, typeSize = 4;
        protected int entryCountOffset = 4, entryCountSize = 4;
        protected int entrySize;

        public EntryFile()
        {
            Entries = new ObservableCollection<EntryItem>();
        }
        public EntryFile(String name, List<byte> raw)
        {
            Entries = new ObservableCollection<EntryItem>();
            constructorCommon(name, raw);
        }
        public EntryFile(String name, List<byte> raw, int typeSize, int entryCountSize)
        {
            entrySize = raw.Count;
            this.typeSize = typeSize;
            this.entryCountOffset = typeSize;
            this.entryCountSize = entryCountSize;
            headerSize = typeSize + entryCountSize;
            constructorCommon(name, raw);
        }
        private void constructorCommon(String name, List<byte> raw)
        {
            Console.WriteLine("DEBUG >>> Found entry file: " + name);
            this.Name = name;
            entrySize = raw.Count;
            processHeader(raw);
            processEntries(raw);
        }
        /*
        public EntryFile(String name, List<byte> raw, String filename)
        {
            Console.WriteLine("DEBUG >>> Found entry file: " + name);
            this.name = name;
            if (filename == "jiminy" ||
                filename == "mixdata")
            {
                headerSize = 16;
                entryCountOffset = 8;
                entryCountSize = 4;
            }
            processHeader(raw);
            processEntries(raw);
        }
        */

        public ulong Type
        {
            get
            {
                if (typeSize == 8) return DataAccess.readULong(Header, typeOffset, typeSize);
                else if (typeSize == 4) return DataAccess.readUInt(Header, typeOffset, typeSize);
                else if (typeSize == 2) return DataAccess.readUShort(Header, typeOffset, typeSize);
                else return 0;
            }
            set
            {
                if (entryCountSize == 8) DataAccess.writeULong(Header, (ulong)value, entryCountOffset, entryCountSize);
                if (entryCountSize == 4) DataAccess.writeUInt(Header, (uint)value, entryCountOffset, entryCountSize);
                if (entryCountSize == 2) DataAccess.writeUShort(Header, (ushort)value, entryCountOffset, entryCountSize);
            }
        }
        public ulong EntryCount
        {
            get
            {
                if (entryCountSize == 8) return DataAccess.readULong(Header, entryCountOffset, entryCountSize);
                else if (entryCountSize == 4) return DataAccess.readUInt(Header, entryCountOffset, entryCountSize);
                else if (entryCountSize == 2) return DataAccess.readUShort(Header, entryCountOffset, entryCountSize);
                else return 0;
            }
            set
            {
                if(entryCountSize == 8) DataAccess.writeULong(Header, (ulong)value, entryCountOffset, entryCountSize);
                if(entryCountSize == 4) DataAccess.writeUInt(Header, (uint)value, entryCountOffset, entryCountSize);
                if(entryCountSize == 2) DataAccess.writeUShort(Header, (ushort)value, entryCountOffset, entryCountSize);
            }
        }

        // Recalculates the entry count of the file
        public void recalcEntryCount()
        {
            if (entryCountSize == 8) EntryCount = (ulong)Entries.Count;
            else if (entryCountSize == 4) EntryCount = (uint)Entries.Count;
            else if (entryCountSize == 2) EntryCount = (ushort)Entries.Count;
            else EntryCount = (uint)Entries.Count;
        }

        // Reads and processes the header
        public void processHeader(List<byte> raw)
        {
            Header = new List<byte>();
            Header.AddRange(raw.GetRange(headerOffset, headerSize));
        }

        // Reads and processes the entries
        public virtual void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new EntryItem(raw.GetRange(currentOffset, entrySize)));
                currentOffset += entrySize;
            }
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            List<byte> data = new List<byte>();

            recalcEntryCount();

            // Header
            data.AddRange(Header);

            // Entries
            foreach (EntryItem entry in Entries)
            {
                data.AddRange(entry.getAsByteList());
            }

            return data;
        }
    }
}
