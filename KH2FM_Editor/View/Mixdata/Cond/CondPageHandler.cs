using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.Mixdata.Cond;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Mixdata.Cond
{
    class CondPageHandler : memoryLoadFile
    {
        public CondFile CondFileLoaded { get; set; }
        public ObservableCollection<CondItem> CondFileItems { get; set; }

        public CondPageHandler(CondFile file)
        {
            MemOffsetFallback = "211A9C60"; // PCSX2 CCZ's eng patch
            MemOffset = MemOffsetFallback;
            stringToFind = "MICO";

            findAddressDirect();
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
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > CondPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (CondFileLoaded == null) return;
            Console.WriteLine("DEBUG > CondPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > CondPageHandler > Finished saving!");
        }
    }
}
