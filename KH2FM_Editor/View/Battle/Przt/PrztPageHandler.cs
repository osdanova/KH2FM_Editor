using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.Battle.Przt;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Battle.Przt
{
    class PrztPageHandler : memoryLoadFile
    {
        public PrztFile PrztFileLoaded { get; set; }
        public ObservableCollection<PrztItem> PrztFileItems { get; set; }

        public PrztPageHandler(PrztFile file)
        {
            MemOffsetFallback = "21D09824"; // PCSX2 CCZ's eng patch
            MemOffset = MemOffsetFallback;
            stringToFind = "przt";

            findAddress();
            Console.WriteLine("DEBUG > PrztPageHandler > Processing file...");
            PrztFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > PrztPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > PrztPageHandler > Getting file info...");

            PrztFileItems = new ObservableCollection<PrztItem>();
            foreach (PrztItem entry in PrztFileLoaded.Entries)
            {
                PrztFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            PrztFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (PrztItem entry in PrztFileItems)
            {
                PrztFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > PrztPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = PrztFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > PrztPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (PrztFileLoaded == null) return;
            Console.WriteLine("DEBUG > PrztPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > PrztPageHandler > Finished saving!");
        }
    }
}
