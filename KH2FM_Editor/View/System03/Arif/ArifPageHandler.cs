using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Model.System03.Arif;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Libs.Utils;

namespace KH2FM_Editor.View.System03.Arif
{
    class ArifPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public ArifFile ArifFileLoaded { get; set; }
        //public ObservableCollection<ArifItem> ArifFileItems { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "21CD6300"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public ArifPageHandler(ArifFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > ArifPageHandler > Processing file...");
            ArifFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > ArifPageHandler > File processed!");
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > ArifPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = ArifFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > ArifPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (ArifFileLoaded == null) return;
            Console.WriteLine("DEBUG > ArifPageHandler > Saving...");
            Console.WriteLine("DEBUG > ArifPageHandler > Finished saving!");
        }
        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("arif");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
