using KH2FM_Editor.Enum;
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
        static ProcessType processType = ProcessType.PCSX2;
        static long startingAddress = 0x20000000;
        static long startingAddressEGS = 0x0;
        static long findRange = 0x3000000;
        static long BARsearchRange = 0x200;
        static String memoryDumpString;

        public static void findProcess()
        {
            if(khProcess == null)
            {
                khProcess = Process.GetProcessesByName("PCSX2").FirstOrDefault();
                if (khProcess != null) processType = ProcessType.PCSX2;
            }

            if (khProcess == null)
            {
                khProcess = Process.GetProcessesByName("KINGDOM HEARTS II FINAL MIX").FirstOrDefault();
                startingAddressEGS = khProcess.MainModule.BaseAddress.ToInt64();
                if (khProcess != null) processType = ProcessType.EGS;
                //Console.WriteLine("KH2FM process name: " + khProcess.ProcessName);
                //Console.WriteLine("KH2FM Main Module's Base address: " + startingAddressEGS + " / 0x" + startingAddressEGS.ToString("X12"));
                //Console.WriteLine("KH2FM Main Module's Base address + offset: " + (startingAddressEGS + 0x56450E) + " / 0x" + (startingAddressEGS + 0x56450E).ToString("X12"));
            }

            if (khProcess == null && processType == ProcessType.PCSX2) khProcess = Process.GetProcessesByName("PCSX2").FirstOrDefault();
            if (khProcess == null && processType == ProcessType.EGS)
            {
            }
        }

        public static List<byte> readPcsx2(long offset, int size)
        {
            findProcess();
            return MemoryAccess.readMemory(khProcess, offset, size);
        }

        public static void writePcsx2(long offset, int size, List<byte> input)
        {
            findProcess();
            MemoryAccess.writeMemory(khProcess, offset, size, input);
        }
        public static long findAddressOf(String text)
        {

            findProcess();
            if (khProcess == null) return -1;

            long initialAddress = 0;
            if (processType == ProcessType.PCSX2) initialAddress = startingAddress;
            if (processType == ProcessType.EGS) initialAddress = startingAddressEGS;

            if (memoryDumpString == null)
            {
                List<byte> memoryDump = new List<byte>();
                memoryDump = MemoryAccess.readMemory(khProcess, initialAddress, findRange);
                memoryDumpString = System.Text.Encoding.ASCII.GetString(memoryDump.ToArray());
            }

            //IndexOf + 4 > read 4 bytes + startingAddress
            return initialAddress + memoryDumpString.IndexOf(text);
        }
        public static long findLastAddressOf(String text)
        {
            findProcess();
            if (khProcess == null) return -1;

            long initialAddress = 0;
            if (processType == ProcessType.PCSX2) initialAddress = startingAddress;
            if (processType == ProcessType.EGS) initialAddress = startingAddressEGS;

            if (memoryDumpString == null)
            {
                List<byte> memoryDump = MemoryAccess.readMemory(khProcess, initialAddress, findRange);
                memoryDumpString = System.Text.Encoding.ASCII.GetString(memoryDump.ToArray());
            }

            //IndexOf + 4 > read 4 bytes + startingAddress
            return initialAddress + memoryDumpString.LastIndexOf(text);
        }
        public static long findBarFileAddress(String text)
        {
            long fileAddress = findLastAddressOf(text);
            //Console.WriteLine("KH2FM file "+text+" found at: " + fileAddress.ToString("X12"));
            //Debug.WriteLine("DELETE DEBUG > fileAddress: " + fileAddress);
            if (fileAddress == -1) return -1;

            //Debug.WriteLine("DELETE DEBUG > string found: " + BinaryHandler.bytesAsString(readPcsx2(fileAddress, 4)));

            return getBARSubfileAddress(fileAddress);
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

            long initialAddress = 0;
            if (processType == ProcessType.PCSX2) initialAddress = startingAddress;
            if (processType == ProcessType.EGS) initialAddress = startingAddressEGS;

            return initialAddress + barFilePointer;
        }


        public static long findBARAddressFromSubfile(long address)
        {
            findProcess();
            if (khProcess == null) return -1;

            //Console.WriteLine("BAR search range: " + (address - BARsearchRange).ToString("X12") + " - " + ((address - BARsearchRange)+ BARsearchRange).ToString("X12"));

            List<byte> BARSearchDump = MemoryAccess.readMemory(khProcess, address-BARsearchRange, BARsearchRange);
            String BARSearchDumpString = System.Text.Encoding.ASCII.GetString(BARSearchDump.ToArray());

            //Console.WriteLine("KH2FM BAR found at: " + BARSearchDumpString.IndexOf("BAR").ToString("X12"));

            //IndexOf + 4 > read 4 bytes + startingAddress
            return address - BARsearchRange + BARSearchDumpString.IndexOf("BAR");
        }

        public static int getBARFileOffset(long BARAddress)
        {
            return BinaryHandler.bytesAsInt(readPcsx2(BARAddress + 8, 4));
        }
        public static long getBARSubfileAddress(long subfileSearchAddress)
        {
            //Console.WriteLine("KH2FM subfile found: " + subfileSearchAddress.ToString("X12"));
            long BARAddress = findBARAddressFromSubfile(subfileSearchAddress);
            //Console.WriteLine("KH2FM BARAddress found: " + BARAddress.ToString("X12"));
            int BAROffset = getBARFileOffset(BARAddress);
            //Console.WriteLine("KH2FM BAROffset found: " + BAROffset.ToString("X12"));
            int subfileOffset = BinaryHandler.bytesAsInt(readPcsx2(subfileSearchAddress + 4, 4));
            //Console.WriteLine("KH2FM subfileOffset found: " + subfileOffset.ToString("X12"));

            long subfileOffsetInBAR = subfileOffset - BAROffset;
            //Console.WriteLine("KH2FM difference: " + subfileOffsetInBAR.ToString("X12"));
            return BARAddress + subfileOffsetInBAR;
        }
    }
}
