using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.Battle.Stop;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Battle.Stop
{
    class StopPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public StopFile StopFileLoaded { get; set; }
        public ObservableCollection<StopItem> StopFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }
        public static string MemOffsetFallback = "21D1A394"; // Crazycatz's English patch
        public static bool AddressFound = false;

        public StopPageHandler(StopFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > StopPageHandler > Processing file...");
            StopFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > StopPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > StopPageHandler > Getting file info...");

            StopFileItems = new ObservableCollection<StopItem>();
            foreach (StopItem entry in StopFileLoaded.Entries)
            {
                StopFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            StopFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (StopItem entry in StopFileItems)
            {
                StopFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > StopPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = StopFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > StopPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (StopFileLoaded == null) return;
            Console.WriteLine("DEBUG > StopPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > StopPageHandler > Finished saving!");
        }

        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("stop");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
