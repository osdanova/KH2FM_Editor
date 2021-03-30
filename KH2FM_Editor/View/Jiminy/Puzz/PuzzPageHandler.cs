using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.Jiminy.Puzz;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Jiminy.Puzz
{
    class PuzzPageHandler : memoryLoadFile
    {
        public PuzzFile PuzzFileLoaded { get; set; }
        public ObservableCollection<PuzzItem> PuzzFileItems { get; set; }

        public PuzzPageHandler(PuzzFile file)
        {
            MemOffsetFallback = "21512790"; // PCSX2 CCZ's eng patch
            MemOffset = MemOffsetFallback;
            stringToFind = "puzz";

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
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > PuzzPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (PuzzFileLoaded == null) return;
            Console.WriteLine("DEBUG > PuzzPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > PuzzPageHandler > Finished saving!");
        }
    }
}
