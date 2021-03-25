using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Rcct;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.System03.Rcct
{
    class RcctPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public RcctFile RcctFileLoaded { get; set; }
        public ObservableCollection<RcctItem> RcctFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }
        public static string MemOffsetFallback = "21CCB3E0"; // Crazycatz's English patch
        public static bool AddressFound = false;

        public RcctPageHandler(RcctFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > RcctPageHandler > Processing file...");
            RcctFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > RcctPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > RcctPageHandler > Getting file info...");

            RcctFileItems = new ObservableCollection<RcctItem>();
            foreach (RcctItem entry in RcctFileLoaded.Entries)
            {
                RcctFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            RcctFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (RcctItem entry in RcctFileItems)
            {
                RcctFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > RcctPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = RcctFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > RcctPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (RcctFileLoaded == null) return;
            Console.WriteLine("DEBUG > RcctPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > RcctPageHandler > Finished saving!");
        }
        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("rcct");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
