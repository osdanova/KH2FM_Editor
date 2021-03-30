using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.Battle.Bons;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Battle.Bons
{
    class BonsPageHandler : memoryLoadFile
    {
        public BonsFile BonsFileLoaded { get; set; }
        public ObservableCollection<BonsItem> BonsFileItems { get; set; }

        public BonsPageHandler(BonsFile file)
        {
            MemOffsetFallback = "21D10788"; // PCSX2 CCZ's eng patch
            MemOffset = MemOffsetFallback;
            stringToFind = "bons";

            findAddress();
            Console.WriteLine("DEBUG > BonsPageHandler > Processing file...");
            BonsFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > BonsPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > BonsPageHandler > Getting file info...");

            BonsFileItems = new ObservableCollection<BonsItem>();
            foreach (BonsItem entry in BonsFileLoaded.Entries)
            {
                BonsFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            BonsFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (BonsItem entry in BonsFileItems)
            {
                BonsFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > BonsPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = BonsFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > BonsPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (BonsFileLoaded == null) return;
            Console.WriteLine("DEBUG > BonsPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > BonsPageHandler > Finished saving!");
        }
    }
}
