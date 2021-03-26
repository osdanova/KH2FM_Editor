using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Wmst;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.System03.Wmst
{
    class WmstPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public WmstFile WmstFileLoaded { get; set; }
        public ObservableCollection<WmstItem> WmstFileItems { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "21CD5180"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public WmstPageHandler(WmstFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > WmstPageHandler > Processing file...");
            WmstFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > WmstPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > WmstPageHandler > Getting file info...");

            WmstFileItems = new ObservableCollection<WmstItem>();
            foreach (WmstItem entry in WmstFileLoaded.Entries)
            {
                WmstFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            WmstFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (WmstItem entry in WmstFileItems)
            {
                WmstFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > WmstPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = WmstFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > WmstPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (WmstFileLoaded == null) return;
            Console.WriteLine("DEBUG > WmstPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > WmstPageHandler > Finished saving!");
        }
        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("wmst");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
