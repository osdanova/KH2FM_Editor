using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.Mixdata.Exp;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Mixdata.Exp
{
    class ExpPageHandler : memoryLoadFile
    {
        public ExpFile ExpFileLoaded { get; set; }
        public ObservableCollection<ExpItem> ExpFileItems { get; set; }

        public ExpPageHandler(ExpFile file)
        {
            MemOffsetFallback = "211A9F80"; // PCSX2 CCZ's eng patch
            MemOffset = MemOffsetFallback;
            stringToFind = "MIEX";

            findAddressDirect();
            Console.WriteLine("DEBUG > ExpPageHandler > Processing file...");
            ExpFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > ExpPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > ExpPageHandler > Getting file info...");

            ExpFileItems = new ObservableCollection<ExpItem>();
            foreach (ExpItem entry in ExpFileLoaded.Entries)
            {
                ExpFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            ExpFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (ExpItem entry in ExpFileItems)
            {
                ExpFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > ExpPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = ExpFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > ExpPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (ExpFileLoaded == null) return;
            Console.WriteLine("DEBUG > ExpPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > ExpPageHandler > Finished saving!");
        }
    }
}
