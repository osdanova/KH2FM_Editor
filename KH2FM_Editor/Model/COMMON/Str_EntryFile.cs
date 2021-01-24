using KH2FM_Editor.Libs.Binary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.Model.COMMON
{
    /*
     * Contains a header and a list of entries.
     * The header contains the file type and entry count.
     * The file type and entry count can be 2/4/8 bytes long.
     * If the file has no header, use (0,0)
     * The processEntries method must be overriden for the file's specifics.
     */
    public class Str_EntryFile
    {
        public String Name { get; set; }
        public List<byte> Header { get; set; }
        public ObservableCollection<Str_EntryItem> Entries { get; set; }
        public List<byte> padding { get; set; }

        // Data Location
        // Default is set to (4,4) because it's the most common
        protected int headerOffset = 0, headerSize = 8;
        protected int typeOffset = 0, typeSize = 4;
        protected int entryCountOffset = 4, entryCountSize = 4;
        protected int entrySize;

        public Str_EntryFile()
        {
            Entries = new ObservableCollection<Str_EntryItem>();
        }
        public Str_EntryFile(String name, int typeSize, int entryCountSize, int entrySize, List<byte> raw)
        {
            //Console.WriteLine("DEBUG > Str_EntryFile > Found entry file: " + name);
            // File name
            this.Name = name;
            // Header data
            this.typeSize = typeSize;
            this.entryCountOffset = typeSize;
            this.entryCountSize = entryCountSize;
            headerSize = typeSize + entryCountSize;
            // Entry data
            this.entrySize = entrySize;

            // If there are 0 entries, allows to add more
            Entries = new ObservableCollection<Str_EntryItem>();

            // Process file
            processHeader(raw);
            processEntries(raw);
        }

        public string Type
        {
            get
            {
                if (Header != null)
                    return DataAccess.readHexString(Header, typeOffset, typeSize);
                else
                    return null;
            }
            set
            {
                if (Header != null)
                    DataAccess.writeHexString(Header, value, typeOffset, typeSize);
            }
        }
        public ulong EntryCount
        {
            get
            {
                if (Header != null)
                {
                    if (entryCountSize == 8) return DataAccess.readULong(Header, entryCountOffset, entryCountSize);
                    else if (entryCountSize == 4) return DataAccess.readUInt(Header, entryCountOffset, entryCountSize);
                    else if (entryCountSize == 2) return DataAccess.readUShort(Header, entryCountOffset, entryCountSize);
                    else return 0;
                }
                else
                    return 0;
            }
            set
            {
                if (Header != null)
                {
                    if (entryCountSize == 8) DataAccess.writeULong(Header, (ulong)value, entryCountOffset, entryCountSize);
                    if (entryCountSize == 4) DataAccess.writeUInt(Header, (uint)value, entryCountOffset, entryCountSize);
                    if (entryCountSize == 2) DataAccess.writeUShort(Header, (ushort)value, entryCountOffset, entryCountSize);
                }
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
            if (headerSize < 1) return;

            Header = new List<byte>();
            Header.AddRange(raw.GetRange(headerOffset, headerSize));
        }

        // Reads and processes the entries
        public virtual void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            if(headerSize > 0)
            {
                // Entries
                for (ulong i = 0; i < EntryCount; i++)
                {
                    Entries.Add(new Str_EntryItem(raw.GetRange(currentOffset, entrySize)));
                    currentOffset += entrySize;
                }
                // Read padding
                if (currentOffset < raw.Count)
                {
                    padding = new List<byte>();
                    padding.AddRange(raw.GetRange(currentOffset, raw.Count - currentOffset));
                }
            }
            // No header
            else
            {
                // Read as many entries as you can
                while (currentOffset + entrySize <= raw.Count)
                {
                    Entries.Add(new Str_EntryItem(raw.GetRange(currentOffset, entrySize)));
                    currentOffset += entrySize;
                }
                // Read padding
                if (currentOffset < raw.Count)
                {
                    padding = new List<byte>();
                    padding.AddRange(raw.GetRange(currentOffset, raw.Count - currentOffset));
                }
            }
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            List<byte> data = new List<byte>();

            // Header
            if (Header != null)
            {
                recalcEntryCount();
                data.AddRange(Header);
            }

            // Entries
            foreach (Str_EntryItem entry in Entries)
            {
                data.AddRange(entry.getAsByteList());
            }

            // Padding
            if (padding != null)
            {
                data.AddRange(padding);
            }

            return data;
        }
    }
}
