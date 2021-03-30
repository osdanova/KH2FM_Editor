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
        static Process khProcess;
        static long startingAddress = 0x20000000;
        static long startgingAddressEGS = 0x7FF71D9AEA90;
        static long findRange = 0x2000000;
        static String memoryDumpString;

        public static void findPcsx2()
        {
            if (khProcess == null) khProcess = Process.GetProcessesByName("PCSX2").FirstOrDefault();
        }
        public static void findEGS()
        {
            if (khProcess == null) khProcess = Process.GetProcessesByName("KINGDOM HEARTS II FINAL MIX").FirstOrDefault();
        }

        public static List<byte> readPcsx2(long offset, int size)
        {
            findPcsx2();
            return MemoryAccess.readMemory(khProcess, offset, size);
        }

        public static void writePcsx2(long offset, int size, List<byte> input)
        {
            findPcsx2();
            MemoryAccess.writeMemory(khProcess, offset, size, input);
        }
        public static long findAddressOf(String text)
        {
            findPcsx2();
            if (khProcess == null) return -1;

            if (memoryDumpString == null)
            {
                List<byte> memoryDump = MemoryAccess.readMemory(khProcess, startingAddress, findRange);
                memoryDumpString = System.Text.Encoding.ASCII.GetString(memoryDump.ToArray());
            }

            //IndexOf + 4 > read 4 bytes + startingAddress
            return startingAddress + memoryDumpString.IndexOf(text);
        }
        public static long findLastAddressOf(String text)
        {
            findPcsx2();
            if (khProcess == null) return -1;

            if (memoryDumpString == null)
            {
                List<byte> memoryDump = MemoryAccess.readMemory(khProcess, startingAddress, findRange);
                memoryDumpString = System.Text.Encoding.ASCII.GetString(memoryDump.ToArray());
            }

            //IndexOf + 4 > read 4 bytes + startingAddress
            return startingAddress + memoryDumpString.LastIndexOf(text);
        }
        public static long findBarFileAddress(String text)
        {
            long fileAddress = findLastAddressOf(text);
            //Debug.WriteLine("DELETE DEBUG > fileAddress: " + fileAddress);
            if (fileAddress == -1) return -1;

            //Debug.WriteLine("DELETE DEBUG > string found: " + BinaryHandler.bytesAsString(readPcsx2(fileAddress, 4)));

            // Memory address pointer
            fileAddress += 4;


            int barFilePointer = BinaryHandler.bytesAsInt(readPcsx2(fileAddress, 4));

            //Debug.WriteLine("DELETE DEBUG > barFilePointer: " + barFilePointer);

            return startingAddress + barFilePointer;
        }
        public static long findBarFileAddressMagi(String text)
        {
            long fileAddress = findAddressOf(text);
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
