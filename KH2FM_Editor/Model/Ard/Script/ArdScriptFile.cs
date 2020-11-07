using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.Bar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.Model.Ard.Script
{
    public class ArdScriptFile : BarSubFile
    {
        // Contains a header and a list of programs
        public string Name { get; set; }
        public List<byte> Header { get; set; }
        public ObservableCollection<ArdProgram> Programs { get; set; }

        public ArdScriptFile(string name, List<byte> rawData)
        {
            Console.WriteLine("DEBUG >>> Found ardScript file: " + name);
            Programs = new ObservableCollection<ArdProgram>();
            processFile(rawData);
            Name = name;
        }

        public void processFile(List<byte> rawData)
        {

            int currentOffset = 0;
            int currentProgramSize;
            int whileSec = 0;

            // Programs
            while (currentOffset < rawData.Count)
            {
                //Console.WriteLine("DEBUG >>> Reading opcode at offset: " + currentOffset + "/" + rawData.Count);

                // Prevent infinite loop
                if (whileSec >= 10000) break;

                // Read the opcode's size and then store it
                currentProgramSize = DataAccess.readUShort(rawData, currentOffset + ArdProgram.countOffset, ArdProgram.countSize);
                if (currentProgramSize == 0) currentProgramSize = 4; // EOF
                Programs.Add(new ArdProgram(rawData.GetRange(currentOffset, currentProgramSize)));
                currentOffset += currentProgramSize;
                whileSec++;
            }
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            List<byte> data = new List<byte>();

            // Opcodes
            foreach (ArdProgram program in Programs)
            {
                data.AddRange(program.getAsByteList());
            }

            return data;
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}
