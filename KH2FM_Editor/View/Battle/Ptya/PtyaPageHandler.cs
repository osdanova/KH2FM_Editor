using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.Battle.Ptya;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Battle.Ptya
{
    class PtyaPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public PtyaFile PtyaFileLoaded { get; set; }
        //public ObservableCollection<PtyaItem> PtyaFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }
        public static string MemOffsetFallback = "21D05CE0"; // Crazycatz's English patch
        public static bool AddressFound = false;

        public PtyaPageHandler(PtyaFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > PtyaPageHandler > Processing file...");
            PtyaFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > PtyaPageHandler > File processed!");
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > PtyaPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = PtyaFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > PtyaPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (PtyaFileLoaded == null) return;
            Console.WriteLine("DEBUG > PtyaPageHandler > Saving...");
            Console.WriteLine("DEBUG > PtyaPageHandler > Finished saving!");
        }

        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("ptya");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
