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

        public static void findPcsx2()
        {
            pcsx2 = Process.GetProcessesByName("PCSX2").FirstOrDefault();
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
    }
}
