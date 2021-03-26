using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.System03.Pref.Sstm;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.View.System03.Sstm
{
    class SstmPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public SstmFile SstmFileLoaded { get; set; }
        //public ObservableCollection<SstmItem> SstmFileItems { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "21CE36C4"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public SstmPageHandler(SstmFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > SstmPageHandler > Processing file...");
            SstmFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > SstmPageHandler > File processed!");
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > SstmPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = SstmFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > SstmPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (SstmFileLoaded == null) return;
            Console.WriteLine("DEBUG > SstmPageHandler > Saving...");
            Console.WriteLine("DEBUG > SstmPageHandler > Finished saving!");
        }
        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("sstm");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
