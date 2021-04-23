using System;
using System.Collections.Generic;
using KH2FM_Editor.Enum;
using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;

namespace KH2FM_Editor.View.Common
{
    class memoryLoadFile
    {
        public string stringToFind { get; set; }
        public FileType fileType { get; set; }
        public string subBarName { get; set; }
        public string subSubBarName { get; set; }
        public string MemOffsetFallback { get; set; }
        public string MemOffset { get; set; }
        public bool AddressFound = false;
        public ProcessType procType;

        private readonly string NOT_FOUND = "NOT FOUND";

        public void findAddress()
        {
            if (AddressFound) return;
            Pcsx2Memory.findProcess();

            // Find by pointers
            long autoAddress = -1;
            if (fileType == FileType.KH2_00OBJENTRY) autoAddress = Pcsx2Memory.getAddressOfSubBar(fileType, null);
            else if (subBarName != null && subSubBarName != null) autoAddress = Pcsx2Memory.getAddressOfSubSubBar(fileType, subBarName, subSubBarName);
            else if (subBarName != null) autoAddress = Pcsx2Memory.getAddressOfSubBar(fileType, subBarName);
            // Find by string search
            if (autoAddress <= 0 && fileType != FileType.KH2_00OBJENTRY) autoAddress = Pcsx2Memory.findBarFileAddress(stringToFind);

            // If address was found
            if (autoAddress > 0)
            {
                AddressFound = true;
                MemOffset = FormatHandler.getHexString(autoAddress, ProcessType.PCSX2);
                if (Pcsx2Memory.process_current_Type == ProcessType.PCSX2 && autoAddress > 0x2FFFFFFF) MemOffset = NOT_FOUND;
            }
            else MemOffset = NOT_FOUND;
        }
        public void findAddressDirect()
        {
            if (AddressFound) return;

            long addressInt = Pcsx2Memory.findAddressOf(stringToFind);
            AddressFound = true;

            if (addressInt == -1)
            {
                MemOffset = MemOffsetFallback;
            }
            else
            {
                MemOffset = FormatHandler.getHexString(addressInt, ProcessType.PCSX2);
            }
            if (procType == ProcessType.PCSX2 && addressInt > 0x2FFFFFFF) MemOffset = MemOffsetFallback;
        }

        public void writeFileToProcess(List<byte> fileToWrite)
        {
            if (MemOffset == NOT_FOUND) return;
            Pcsx2Memory.writePcsx2(long.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
        }
    }
}
