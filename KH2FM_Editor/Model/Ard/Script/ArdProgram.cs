using KH2FM_Editor.Libs.Binary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.Model.Ard.Script
{
    public class ArdProgram
    {
        // Contains a header and a list of opcodes
        public List<byte> Header { get; set; }
        public ObservableCollection<OpcodeItem> Opcodes { get; set; }

        // Data location
        public static readonly int headerOffset = 0, headerSize = 4;
        public static readonly int typeOffset = 0, typeSize = 2;
        public static readonly int countOffset = 2, countSize = 2;

        public ArdProgram(List<byte> rawData)
        {
            Opcodes = new ObservableCollection<OpcodeItem>();
            processFile(rawData);
        }

        public ushort Type
        {
            get { return DataAccess.readUShort(Header, typeOffset, typeSize); }
            set { DataAccess.writeUShort(Header, value, typeOffset, typeSize); }
        }
        public ushort Count
        {
            get { return DataAccess.readUShort(Header, countOffset, countSize); }
            set { DataAccess.writeUShort(Header, value, countOffset, countSize); }
        }

        public void processFile(List<byte> rawData)
        {
            int currentOffset = 0;
            int currentOpcodeSize;
            int whileSec = 0;

            // Read header
            Header = rawData.GetRange(headerOffset, headerSize);
            currentOffset += headerSize;

            // Opcodes
            while (currentOffset < rawData.Count)
            {
                //Console.WriteLine("DEBUG >>> Reading opcode at offset: " + currentOffset + "/" + rawData.Count);

                // Prevent infinite loop
                if (whileSec >= 10000) break;

                // Read the opcode's size and then store it
                currentOpcodeSize = OpcodeItem.entrySize + OpcodeItem.paramSize * DataAccess.readUShort(rawData, currentOffset + OpcodeItem.paramCountOffset, OpcodeItem.paramCountSize); ;
                Opcodes.Add(new OpcodeItem(rawData.GetRange(currentOffset, currentOpcodeSize)));
                currentOffset += currentOpcodeSize;
                whileSec++;
            }
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            List<byte> data = new List<byte>();

            // Header
            data.AddRange(Header);

            // Opcodes
            foreach (OpcodeItem opcode in Opcodes)
            {
                data.AddRange(opcode.getAsByteList());
            }

            return data;
        }
    }
}
