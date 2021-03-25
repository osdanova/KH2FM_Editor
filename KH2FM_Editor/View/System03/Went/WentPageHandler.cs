using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Went;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.System03.Went
{
    class WentPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public WentFile WentFileLoaded { get; set; }
        //public ObservableCollection<WentItem> WentFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }
        public static string MemOffsetFallback = "21CD4280"; // Crazycatz's English patch
        public static bool AddressFound = false;

        public WentPageHandler(WentFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > WentPageHandler > Processing file...");
            WentFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > WentPageHandler > File processed!");
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > WentPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = WentFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > WentPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (WentFileLoaded == null) return;
            Console.WriteLine("DEBUG > WentPageHandler > Saving...");
            Console.WriteLine("DEBUG > WentPageHandler > Finished saving!");
        }
        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("went");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
