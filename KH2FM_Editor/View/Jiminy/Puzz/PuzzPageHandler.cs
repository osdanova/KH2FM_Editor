using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.Jiminy.Puzz;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Jiminy.Puzz
{
    class PuzzPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public PuzzFile PuzzFileLoaded { get; set; }
        public ObservableCollection<PuzzItem> PuzzFileItems { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "21512790"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public PuzzPageHandler(PuzzFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > PuzzPageHandler > Processing file...");
            PuzzFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > PuzzPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > PuzzPageHandler > Getting file info...");

            PuzzFileItems = new ObservableCollection<PuzzItem>();
            foreach (PuzzItem entry in PuzzFileLoaded.Entries)
            {
                PuzzFileItems.Add(entry);
            }
        }
        
        public void insertDataToFile()
        {
            PuzzFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (PuzzItem entry in PuzzFileItems)
            {
                PuzzFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > PuzzPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = PuzzFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > PuzzPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (PuzzFileLoaded == null) return;
            Console.WriteLine("DEBUG > PuzzPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > PuzzPageHandler > Finished saving!");
        }

        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("puzz");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
