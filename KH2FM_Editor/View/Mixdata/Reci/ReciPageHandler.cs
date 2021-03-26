using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.Mixdata.Reci;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Mixdata.Reci
{
    class ReciPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public ReciFile ReciFileLoaded { get; set; }
        public ObservableCollection<ReciItem> ReciFileItems { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "211A9890"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public ReciPageHandler(ReciFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > ReciPageHandler > Processing file...");
            ReciFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > ReciPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > ReciPageHandler > Getting file info...");

            ReciFileItems = new ObservableCollection<ReciItem>();
            foreach (ReciItem entry in ReciFileLoaded.Entries)
            {
                ReciFileItems.Add(entry);
            }
        }
        
        public void insertDataToFile()
        {
            ReciFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (ReciItem entry in ReciFileItems)
            {
                ReciFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > ReciPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = ReciFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > ReciPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (ReciFileLoaded == null) return;
            Console.WriteLine("DEBUG > ReciPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > ReciPageHandler > Finished saving!");
        }

        public void findAddress()
        {
            Console.WriteLine("DEBUG > Finding address");
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findAddressOf("MIRE");
            Console.WriteLine("DEBUG > Address found: " + addressInt);
            AddressFound = true;
            if (addressInt == -1) return;
            Console.WriteLine("DEBUG > Writing address");
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
