using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.Mixdata.Cond;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Mixdata.Cond
{
    class CondPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public CondFile CondFileLoaded { get; set; }
        public ObservableCollection<CondItem> CondFileItems { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "211A9C60"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public CondPageHandler(CondFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > CondPageHandler > Processing file...");
            CondFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > CondPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > CondPageHandler > Getting file info...");

            CondFileItems = new ObservableCollection<CondItem>();
            foreach (CondItem entry in CondFileLoaded.Entries)
            {
                CondFileItems.Add(entry);
            }
        }
        
        public void insertDataToFile()
        {
            CondFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (CondItem entry in CondFileItems)
            {
                CondFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > CondPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = CondFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > CondPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (CondFileLoaded == null) return;
            Console.WriteLine("DEBUG > CondPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > CondPageHandler > Finished saving!");
        }

        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findAddressOf("MICO");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
