using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.Battle.Stop;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Battle.Stop
{
    class StopPageHandler : memoryLoadFile
    {
        public StopFile StopFileLoaded { get; set; }
        public ObservableCollection<StopItem> StopFileItems { get; set; }

        public StopPageHandler(StopFile file)
        {
            MemOffsetFallback = "21D1A394"; // PCSX2 CCZ's eng patch
            MemOffset = MemOffsetFallback;
            stringToFind = "stop";

            findAddress();
            Console.WriteLine("DEBUG > StopPageHandler > Processing file...");
            StopFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > StopPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > StopPageHandler > Getting file info...");

            StopFileItems = new ObservableCollection<StopItem>();
            foreach (StopItem entry in StopFileLoaded.Entries)
            {
                StopFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            StopFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (StopItem entry in StopFileItems)
            {
                StopFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > StopPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = StopFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > StopPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (StopFileLoaded == null) return;
            Console.WriteLine("DEBUG > StopPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > StopPageHandler > Finished saving!");
        }
    }
}
