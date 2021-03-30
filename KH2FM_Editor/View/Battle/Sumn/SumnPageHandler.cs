using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.Battle.Sumn;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Battle.Sumn
{
    class SumnPageHandler : memoryLoadFile
    {
        public SumnFile SumnFileLoaded { get; set; }
        public ObservableCollection<SumnItem> SumnFileItems { get; set; }

        public SumnPageHandler(SumnFile file)
        {
            MemOffsetFallback = "21D19658"; // PCSX2 CCZ's eng patch
            MemOffset = MemOffsetFallback;
            stringToFind = "sumn";

            findAddress();
            Console.WriteLine("DEBUG > SumnPageHandler > Processing file...");
            SumnFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > SumnPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > SumnPageHandler > Getting file info...");

            SumnFileItems = new ObservableCollection<SumnItem>();
            foreach (SumnItem entry in SumnFileLoaded.Entries)
            {
                SumnFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            SumnFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (SumnItem entry in SumnFileItems)
            {
                SumnFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > SumnPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = SumnFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > SumnPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (SumnFileLoaded == null) return;
            Console.WriteLine("DEBUG > SumnPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > SumnPageHandler > Finished saving!");
        }
    }
}
