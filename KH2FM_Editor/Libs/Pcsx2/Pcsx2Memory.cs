using KH2FM_Editor.Enum;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Memory;
using KH2FM_Editor.Libs.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace KH2FM_Editor.Libs.Pcsx2
{
    class Pcsx2Memory
    {
        public static Process process_current;
        public static ProcessType process_current_Type = ProcessType.NULL;

        static Process process_pcsx2;
        static Process process_kh1;
        static Process process_kh2;
        static Process process_kh3;
        static Process process_khBbs;
        static Process process_khDdd;
        static String process_pcsx2_Name = "PCSX2";
        static String process_kh1_Name = "KINGDOM HEARTS FINAL MIX";
        static String process_kh2_Name = "KINGDOM HEARTS II FINAL MIX";
        static String process_kh3_Name = "KINGDOM HEARTS III";
        static String process_khBbs_Name = "KINGDOM HEARTS BIRTH BY SLEEP FINAL MIX";
        static String process_khDdd_Name = "KINGDOM HEARTS DREAM DROP DISTANCE";

        public static long startingAddress = 0x20000000;
        public static long startingAddressEGS = 0x0;
        static long findRange = 0x3000000;
        static long BARsearchRange = 0x200;
        static String memoryDumpString;

        public static void findProcess()
        {
            // PCSX2
            if(process_current == null)
            {
                process_current = Process.GetProcessesByName("PCSX2").FirstOrDefault();
                if (process_current != null) process_current_Type = ProcessType.PCSX2;
            }

            // EGS
            if (process_current == null)
            {
                process_current = Process.GetProcessesByName("KINGDOM HEARTS II FINAL MIX").FirstOrDefault();
                //khProcess = Process.GetProcessesByName("KINGDOM HEARTS II FINAL MIX").FirstOrDefault();
                if (process_current != null) startingAddressEGS = process_current.MainModule.BaseAddress.ToInt64();
                if (process_current != null) process_current_Type = ProcessType.EGS;
                if (process_current != null) Console.WriteLine("KH2FM process name: " + process_current.ProcessName);
                if (process_current != null) Console.WriteLine("KH2FM Main Module's Base address: " + startingAddressEGS + " / 0x" + startingAddressEGS.ToString("X12"));
                if (process_current != null) Console.WriteLine("KH2FM Main Module's Base address + offset: " + (startingAddressEGS + 0x56450E) + " / 0x" + (startingAddressEGS + 0x56450E).ToString("X12"));
            }
        }

        public static void findProcess2(Process process, String processName, ProcessType processType)
        {
            if (processName == null) return;

            //if (process_current != null) return;

            Console.WriteLine("DEBUG > Searching process: " + processName);

            process = Process.GetProcessesByName(processName).FirstOrDefault();
            if (process == null) return;

            ProcessModule mainModule = process.MainModule;
            Console.WriteLine("DEBUG > Found process: " + process.ProcessName);
            Console.WriteLine("DEBUG > Found process's main module: " + mainModule);
            if (mainModule != null)
            {
                long mainModuleAddress = process.MainModule.BaseAddress.ToInt64();
                Console.WriteLine("DEBUG > Found process's Base address: " + mainModuleAddress + " / 0x" + mainModuleAddress.ToString("X12"));
            }

            process_current = process;
            process_current_Type = processType;

        }
        public static void findProcessContainingString(String processName)
        {
            if (processName == null) return;

            List<Process> list_processes = Process.GetProcesses().ToList();
            List<Process> list_processesFiltered = new List<Process>();

            foreach (Process process in list_processes)
            {
                if (process.ProcessName.Contains(processName)) list_processesFiltered.Add(process);
            }
            foreach (Process process in list_processesFiltered)
            {
                Console.WriteLine("DEBUG > Found process: " + process.ProcessName);
            }
        }
        public static void findPCSX2() { findProcess2(process_pcsx2, process_pcsx2_Name, ProcessType.PCSX2); }
        public static void findKH1() { Console.WriteLine("DEBUG > Finding KH1"); findProcess2(process_kh1, process_kh1_Name, ProcessType.EGS); }
        public static void findKH2() { findProcess2(process_kh2, process_kh2_Name, ProcessType.EGS); }
        public static void findKH3() { findProcess2(process_kh3, process_kh3_Name, ProcessType.EGS); }


        public static List<byte> readPcsx2(long offset, int size)
        {
            findProcess();
            return MemoryAccess.readMemory(process_current, offset, size);
        }

        public static void writePcsx2(long offset, int size, List<byte> input)
        {
            findProcess();
            MemoryAccess.writeMemory(process_current, offset, size, input);
        }
        public static long findAddressOf(String text)
        {

            findProcess();
            if (process_current == null) return -1;

            long initialAddress = 0;
            if (process_current_Type == ProcessType.PCSX2) initialAddress = startingAddress;
            if (process_current_Type == ProcessType.EGS) initialAddress = startingAddressEGS;

            if (memoryDumpString == null)
            {
                List<byte> memoryDump = new List<byte>();
                memoryDump = MemoryAccess.readMemory(process_current, initialAddress, findRange);
                memoryDumpString = System.Text.Encoding.ASCII.GetString(memoryDump.ToArray());
            }

            //IndexOf + 4 > read 4 bytes + startingAddress
            return initialAddress + memoryDumpString.IndexOf(text);
        }
        public static long findLastAddressOf(String text)
        {
            findProcess();
            if (process_current == null) return -1;

            long initialAddress = 0;
            if (process_current_Type == ProcessType.PCSX2) initialAddress = startingAddress;
            if (process_current_Type == ProcessType.EGS) initialAddress = startingAddressEGS;

            if (memoryDumpString == null)
            {
                List<byte> memoryDump = MemoryAccess.readMemory(process_current, initialAddress, findRange);
                memoryDumpString = System.Text.Encoding.ASCII.GetString(memoryDump.ToArray());
            }

            if (memoryDumpString == null) return -1;

            //IndexOf + 4 > read 4 bytes + startingAddress
            return initialAddress + memoryDumpString.LastIndexOf(text);
        }
        public static long findBarFileAddress(String text)
        {
            long fileAddress = -1;
            if (text == "cmd") fileAddress = findLastAddressOf("rcct") + 16;
            else if (text == "magi") fileAddress = findLastAddressOf("sstm") + 16;
            else fileAddress = findLastAddressOf(text);
            //Console.WriteLine("KH2FM file "+text+" found at: " + fileAddress.ToString("X12"));
            //Debug.WriteLine("DELETE DEBUG > fileAddress: " + fileAddress);
            if (fileAddress == -1) return -1;

            //Debug.WriteLine("DELETE DEBUG > string found: " + BinaryHandler.bytesAsString(readPcsx2(fileAddress, 4)));
            //Console.WriteLine("DEBUG > come on man: " + FormatHandler.getHexString(getBARSubfileAddress(fileAddress), ProcessType.PCSX2));

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
            if (process_current_Type == ProcessType.PCSX2) initialAddress = startingAddress;
            if (process_current_Type == ProcessType.EGS) initialAddress = startingAddressEGS;

            return initialAddress + barFilePointer;
        }


        public static long findBARAddressFromSubfile(long address)
        {
            findProcess();
            if (process_current == null) return -1;

            //Console.WriteLine("BAR search range: " + (address - BARsearchRange).ToString("X12") + " - " + ((address - BARsearchRange)+ BARsearchRange).ToString("X12"));

            List<byte> BARSearchDump = MemoryAccess.readMemory(process_current, address-BARsearchRange, BARsearchRange);
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
            Console.WriteLine("KH2FM subfile found: " + subfileSearchAddress.ToString("X12"));
            //long BARAddress = findBARAddressFromSubfile(subfileSearchAddress);
            //Console.WriteLine("KH2FM BARAddress found: " + BARAddress.ToString("X12"));
            //int BAROffset = getBARFileOffset(BARAddress);
            //Console.WriteLine("KH2FM BAROffset found: " + BAROffset.ToString("X12"));
            //int subfileOffset = BinaryHandler.bytesAsInt(readPcsx2(subfileSearchAddress + 4, 4));
            //Console.WriteLine("KH2FM subfileOffset found: " + subfileOffset.ToString("X12"));
            //
            //long subfileOffsetInBAR = subfileOffset - BAROffset;
            //Console.WriteLine("KH2FM difference: " + subfileOffsetInBAR.ToString("X12"));
            //return BARAddress + subfileOffsetInBAR;

            // Yes, I know, it just works and I don't care anymore
            return subfileSearchAddress;
        }

        public static long getFileOffset(FileType fileType)
        {
            findProcess();
            if (process_current == null) return -1;

            switch (process_current_Type)
            {
                case ProcessType.PCSX2:
                {
                    switch (fileType)
                    {
                        case FileType.KH2_03SYSTEM: return (long) BinaryHandler.bytesAsInt(readPcsx2(startingAddress + (long)FilePointer.KH2_03SYSTEM_PCSX2, 4));
                        case FileType.KH2_00BATTLE: return (long)BinaryHandler.bytesAsInt(readPcsx2(startingAddress + (long)FilePointer.KH2_00BATTLE_PCSX2, 4));
                        case FileType.KH2_00OBJENTRY: return (long)BinaryHandler.bytesAsInt(readPcsx2(startingAddress + (long)FilePointer.KH2_00OBJENTRY_PCSX2, 4));
                        case FileType.KH2_JIMINY: return (long)BinaryHandler.bytesAsInt(readPcsx2(startingAddress + (long)FilePointer.KH2_JIMINY_PCSX2, 4));
                        case FileType.KH2_MIXDATA: return (long)BinaryHandler.bytesAsInt(readPcsx2(startingAddress + (long)FilePointer.KH2_MIXDATA_PCSX2, 4));
                        default: return -1;
                    }
                }
                case ProcessType.EGS:
                {
                    switch (fileType)
                    {
                        case FileType.KH2_03SYSTEM: return (BinaryHandler.bytesAsLong(readPcsx2(startingAddressEGS + (long)FilePointer.KH2_03SYSTEM_EGS, 8)) - startingAddressEGS);
                        case FileType.KH2_00BATTLE: return (BinaryHandler.bytesAsLong(readPcsx2(startingAddressEGS + (long)FilePointer.KH2_00BATTLE_EGS, 8)) - startingAddressEGS);
                        case FileType.KH2_00OBJENTRY: return (BinaryHandler.bytesAsLong(readPcsx2(startingAddressEGS + (long)FilePointer.KH2_00OBJENTRY_EGS, 8)) - startingAddressEGS);
                        //case FileType.KH2_JIMINY: return (BinaryHandler.bytesAsLong(readPcsx2(startingAddressEGS + (long)FilePointer.KH2_JIMINY_EGS, 8)) - startingAddressEGS);
                        case FileType.KH2_MIXDATA: return (BinaryHandler.bytesAsLong(readPcsx2(startingAddressEGS + (long)FilePointer.KH2_MIXDATA_EGS, 8)) - startingAddressEGS);
                        default: return -1;
                    }
                }
                default: return -1;
            }
        }

        public static int getBarCountFromAddress(long address)
        {
            return BinaryHandler.bytesAsInt(readPcsx2(address + 4, 4));
        }
        public static int getBarBaseOffsetFromAddress(long address)
        {
            return BinaryHandler.bytesAsInt(readPcsx2(address + 8, 4));
        }

        public static long getOffsetOfSubBar(long barAddress, string name)
        {
            int baseOffset = getBarBaseOffsetFromAddress(barAddress);
            long offset = -1;
            // For each subBar file
            for(int i = 0; i < getBarCountFromAddress(barAddress); i++)
            {
                long subBarAddress = barAddress + 16 + (i * 16);
                string subBarName = System.Text.Encoding.ASCII.GetString(readPcsx2(subBarAddress + 4, 4).ToArray());
                long subBarOffset = BinaryHandler.bytesAsInt(readPcsx2(subBarAddress + 8, 4));
                if (subBarName == name) offset = subBarOffset;
            }
            switch (process_current_Type)
            {
                case ProcessType.PCSX2: return offset - baseOffset;
                case ProcessType.EGS: return offset - baseOffset;
                default: return -1;
            }
        }

        public static long getAddressOfSubBar(FileType fileType, string subBarName)
        {
            long startAddress = -1;
            switch (process_current_Type)
            {
                case ProcessType.PCSX2: startAddress = startingAddress; break;
                case ProcessType.EGS: startAddress = startingAddressEGS; break;
                default: return -1;
            }
            long fileAddress = startAddress + getFileOffset(fileType);
            if (subBarName == null) return fileAddress;
            return startAddress + getFileOffset(fileType) + getOffsetOfSubBar(fileAddress, subBarName);
        }

        public static long getAddressOfSubSubBar(FileType fileType, string subBarName, string subSubBarName)
        {
            long startAddress = -1;
            switch (process_current_Type)
            {
                case ProcessType.PCSX2: startAddress = startingAddress; break;
                case ProcessType.EGS: startAddress = startingAddressEGS; break;
                default: return -1;
            }
            long subBarAddress = getAddressOfSubBar(fileType, subBarName);
            return (subBarAddress + getOffsetOfSubBar(subBarAddress, subSubBarName));
        }
    }
}
