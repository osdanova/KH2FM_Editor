using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.Mixdata.Reci;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Mixdata.Reci
{
    class ReciPageHandler : memoryLoadFile
    {
        public ReciFile ReciFileLoaded { get; set; }
        public ObservableCollection<ReciItem> ReciFileItems { get; set; }

        public ReciPageHandler(ReciFile file)
        {
            MemOffsetFallback = "211A9890"; // PCSX2 CCZ's eng patch
            MemOffset = MemOffsetFallback;
            stringToFind = "MIRE";

            findAddressDirect();
            Console.WriteLine("DEBUG > ReciPageHandler > Processing file...");
            ReciFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > ReciPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > ReciPageHandler > Getting file info...");

            ReciFileItems = new ObservableCollection<ReciItem>();
            foreach (ReciItem entry in ReciFileLoaded.Entries)
            {
                ReciFileItems.Add(entry);
            }
        }
        
        public void insertDataToFile()
        {
            ReciFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (ReciItem entry in ReciFileItems)
            {
                ReciFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > ReciPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = ReciFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > ReciPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (ReciFileLoaded == null) return;
            Console.WriteLine("DEBUG > ReciPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > ReciPageHandler > Finished saving!");
        }
    }
}
