using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.System03.Pref.Plyr;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.View.System03.Plyr
{
    class PlyrPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public PlyrFile PlyrFileLoaded { get; set; }
        //public ObservableCollection<PlyrItem> PlyrFileItems { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "21CE2810"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public PlyrPageHandler(PlyrFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > PlyrPageHandler > Processing file...");
            PlyrFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > PlyrPageHandler > File processed!");
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > PlyrPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = PlyrFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > PlyrPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (PlyrFileLoaded == null) return;
            Console.WriteLine("DEBUG > PlyrPageHandler > Saving...");
            Console.WriteLine("DEBUG > PlyrPageHandler > Finished saving!");
        }
        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("plyr");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
