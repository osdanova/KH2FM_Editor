using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Sklt;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.System03.Sklt
{
    class SkltPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public SkltFile SkltFileLoaded { get; set; }
        public ObservableCollection<SkltItem> SkltFileItems { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "21CE26D0"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public SkltPageHandler(SkltFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > SkltPageHandler > Processing file...");
            SkltFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > SkltPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > SkltPageHandler > Getting file info...");

            SkltFileItems = new ObservableCollection<SkltItem>();
            foreach (SkltItem entry in SkltFileLoaded.Entries)
            {
                SkltFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            SkltFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (SkltItem entry in SkltFileItems)
            {
                SkltFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > SkltPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = SkltFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > SkltPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (SkltFileLoaded == null) return;
            Console.WriteLine("DEBUG > SkltPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > SkltPageHandler > Finished saving!");
        }
        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("sklt");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
