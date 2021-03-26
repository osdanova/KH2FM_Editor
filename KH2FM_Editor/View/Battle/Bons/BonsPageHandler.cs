using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.Battle.Bons;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Battle.Bons
{
    class BonsPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public BonsFile BonsFileLoaded { get; set; }
        public ObservableCollection<BonsItem> BonsFileItems { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "21D10788"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public BonsPageHandler(BonsFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > BonsPageHandler > Processing file...");
            BonsFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > BonsPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > BonsPageHandler > Getting file info...");

            BonsFileItems = new ObservableCollection<BonsItem>();
            foreach (BonsItem entry in BonsFileLoaded.Entries)
            {
                BonsFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            BonsFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (BonsItem entry in BonsFileItems)
            {
                BonsFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > BonsPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = BonsFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > BonsPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (BonsFileLoaded == null) return;
            Console.WriteLine("DEBUG > BonsPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > BonsPageHandler > Finished saving!");
        }

        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("bons");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
