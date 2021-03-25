using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Memt;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.System03.Memt
{
    class MemtPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public MemtFile MemtFileLoaded { get; set; }
        public ObservableCollection<MemtItem> MemtFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }
        public static string MemOffsetFallback = "21CE0BA0"; // Crazycatz's English patch
        public static bool AddressFound = false;

        public MemtPageHandler(MemtFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > MemtPageHandler > Processing file...");
            MemtFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > MemtPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > MemtPageHandler > Getting file info...");

            MemtFileItems = new ObservableCollection<MemtItem>();
            foreach (MemtItem entry in MemtFileLoaded.Entries)
            {
                MemtFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            MemtFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (MemtItem entry in MemtFileItems)
            {
                MemtFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > MemtPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = MemtFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > MemtPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (MemtFileLoaded == null) return;
            Console.WriteLine("DEBUG > MemtPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > MemtPageHandler > Finished saving!");
        }
        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("memt");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
