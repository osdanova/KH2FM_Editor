using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace KH2FM_Editor.Libs.Pcsx2
{
    class Pcsx2Memory
    {
        static Process pcsx2;
        static int startingAddress = 0x20000000;
        static int findRange = 0x2000000;
        static String memoryDumpString;

        public static void findPcsx2()
        {
            if (pcsx2 == null) pcsx2 = Process.GetProcessesByName("PCSX2").FirstOrDefault();
        }

        public static List<byte> readPcsx2(int offset, int size)
        {
            findPcsx2();
            return MemoryAccess.readMemory(pcsx2, offset, size);
        }

        public static void writePcsx2(int offset, int size, List<byte> input)
        {
            findPcsx2();
            MemoryAccess.writeMemory(pcsx2, offset, size, input);
        }
        public static int findAddressOf(String text)
        {
            findPcsx2();
            if (pcsx2 == null) return -1;

            if (memoryDumpString == null)
            {
                List<byte> memoryDump = MemoryAccess.readMemory(pcsx2, startingAddress, findRange);
                memoryDumpString = System.Text.Encoding.ASCII.GetString(memoryDump.ToArray());
            }

            //IndexOf + 4 > read 4 bytes + startingAddress
            return startingAddress + memoryDumpString.IndexOf(text);
        }
        public static int findLastAddressOf(String text)
        {
            findPcsx2();
            if (pcsx2 == null) return -1;

            if (memoryDumpString == null)
            {
                List<byte> memoryDump = MemoryAccess.readMemory(pcsx2, startingAddress, findRange);
                memoryDumpString = System.Text.Encoding.ASCII.GetString(memoryDump.ToArray());
            }

            //IndexOf + 4 > read 4 bytes + startingAddress
            return startingAddress + memoryDumpString.LastIndexOf(text);
        }
        public static int findBarFileAddress(String text)
        {
            int fileAddress = findLastAddressOf(text);
            //Debug.WriteLine("DELETE DEBUG > fileAddress: " + fileAddress);
            if (fileAddress == -1) return -1;

            //Debug.WriteLine("DELETE DEBUG > string found: " + BinaryHandler.bytesAsString(readPcsx2(fileAddress, 4)));

            // Memory address pointer
            fileAddress += 4;


            int barFilePointer = BinaryHandler.bytesAsInt(readPcsx2(fileAddress, 4));

            //Debug.WriteLine("DELETE DEBUG > barFilePointer: " + barFilePointer);

            return startingAddress + barFilePointer;
        }
        public static int findBarFileAddressMagi(String text)
        {
            int fileAddress = findAddressOf(text);
            //Debug.WriteLine("DELETE DEBUG > fileAddress: " + fileAddress);
            if (fileAddress == -1) return -1;

            //Debug.WriteLine("DELETE DEBUG > string found: " + BinaryHandler.bytesAsString(readPcsx2(fileAddress, 4)));

            // Memory address pointer
            fileAddress += 4;

            int barFilePointer = BinaryHandler.bytesAsInt(readPcsx2(fileAddress, 4));

            //Debug.WriteLine("DELETE DEBUG > barFilePointer: " + barFilePointer);

            return startingAddress + barFilePointer;
        }
    }
}
