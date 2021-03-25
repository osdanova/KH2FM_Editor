using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.Battle.Przt;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Battle.Przt
{
    class PrztPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public PrztFile PrztFileLoaded { get; set; }
        public ObservableCollection<PrztItem> PrztFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }
        public static string MemOffsetFallback = "21D09824"; // Crazycatz's English patch
        public static bool AddressFound = false;

        public PrztPageHandler(PrztFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > PrztPageHandler > Processing file...");
            PrztFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > PrztPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > PrztPageHandler > Getting file info...");

            PrztFileItems = new ObservableCollection<PrztItem>();
            foreach (PrztItem entry in PrztFileLoaded.Entries)
            {
                PrztFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            PrztFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (PrztItem entry in PrztFileItems)
            {
                PrztFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > PrztPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = PrztFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > PrztPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (PrztFileLoaded == null) return;
            Console.WriteLine("DEBUG > PrztPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > PrztPageHandler > Finished saving!");
        }

        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("przt");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
