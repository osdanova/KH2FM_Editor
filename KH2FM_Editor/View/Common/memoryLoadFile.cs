using System.Collections.Generic;
using KH2FM_Editor.Enum;
using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;

namespace KH2FM_Editor.View.Common
{
    class memoryLoadFile
    {
        public string stringToFind { get; set; }
        public string MemOffsetFallback { get; set; }
        public string MemOffset { get; set; }
        public bool AddressFound = false;
        public ProcessType procType;

        public void findAddress()
        {
            if (AddressFound) return;

            long addressInt = Pcsx2Memory.findBarFileAddress(stringToFind);
            AddressFound = true;

            if (addressInt == -1) {
                MemOffset = MemOffsetFallback;
            }
            else {
                MemOffset = FormatHandler.getHexString(addressInt, ProcessType.PCSX2);
            }
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
        }

        public void writeFileToProcess(List<byte> fileToWrite)
        {
            Pcsx2Memory.writePcsx2(long.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
        }
    }
}
