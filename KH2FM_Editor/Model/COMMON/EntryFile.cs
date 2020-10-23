using KH2FM_Editor.Libs.Binary;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor_WPF.FileTypes.GENERIC
{
    public class EntryFile
    {
        // There are EntryFiles that have headers of 16, 8 & 4 bytes
        // I've set the default as 8. which is the most common

        protected String name;
        // Header contains the file type and the entry count
        protected List<byte> header;
        public List<BaseEntry> entries = new List<BaseEntry>();

        // Data Location
        protected int headerOffset = 0, headerSize = 8;
        protected int typeOffset = 0, typeSize = 4;
        protected int entryCountOffset = 4, entryCountSize = 4;
        int entrySize;

        public EntryFile() { }
        public EntryFile(String name, List<byte> raw)
        {
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
            this.name = name;
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

        public ulong entryCount
        {
            get
            {
                if (entryCountSize == 8) return DataAccess.readULong(header, entryCountOffset, entryCountSize);
                else if (entryCountSize == 4) return DataAccess.readUInt(header, entryCountOffset, entryCountSize);
                else if (entryCountSize == 2) return DataAccess.readUShort(header, entryCountOffset, entryCountSize);
                else return 0;
            }
            set
            {
                if(entryCountSize == 8) DataAccess.writeULong(header, (ulong)value, entryCountOffset, entryCountSize);
                if(entryCountSize == 4) DataAccess.writeUInt(header, (uint)value, entryCountOffset, entryCountSize);
                if(entryCountSize == 2) DataAccess.writeUShort(header, (ushort)value, entryCountOffset, entryCountSize);
            }
        }
        public void recalcEntryCount()
        {
            if (entryCountSize == 8) entryCount = (ulong)entries.Count;
            else if (entryCountSize == 4) entryCount = (uint)entries.Count;
            else if (entryCountSize == 2) entryCount = (ushort)entries.Count;
            else entryCount = (uint)entries.Count;
        }

        public void processHeader(List<byte> raw)
        {
            header = new List<byte>();
            header.AddRange(raw.GetRange(headerOffset, headerSize));
        }

        public virtual void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < entryCount; i++)
            {
                entries.Add(new BaseEntry(raw.GetRange(currentOffset, entrySize)));
                currentOffset += entrySize;
            }
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            List<byte> data = new List<byte>();

            recalcEntryCount();

            // Header
            data.AddRange(header);

            // Entries
            foreach (BaseEntry entry in entries)
            {
                data.AddRange(entry.getAsByteList());
            }

            return data;
        }
        /*
        // Create Control to show data
        public override Tuple<String, Control> getControl()
        {
            if (entries.Count <= 0)
            {
                RichTextBox output = new RichTextBox();
                output.AutoSize = true;
                output.Dock = DockStyle.Fill;
                return new Tuple<string, Control>(name, output);
            }

            return new Tuple<string, Control>(name, entries[0].getDataGrid(entries));
        }
        */


    }
}
