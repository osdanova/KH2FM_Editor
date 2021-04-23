using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Trsr;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.System03.Trsr
{
    class TrsrPageHandler : memoryLoadFile
    {
        public TrsrFile TrsrFileLoaded { get; set; }
        public ObservableCollection<TrsrItem> TrsrFileItems { get; set; }

        public TrsrPageHandler(TrsrFile file)
        {
            MemOffsetFallback = "21CDF748"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_03SYSTEM;
            subBarName = "trsr";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > TrsrPageHandler > Processing file...");
            TrsrFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > TrsrPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > TrsrPageHandler > Getting file info...");

            TrsrFileItems = new ObservableCollection<TrsrItem>();
            foreach (TrsrItem entry in TrsrFileLoaded.Entries)
            {
                TrsrFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            TrsrFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (TrsrItem entry in TrsrFileItems)
            {
                TrsrFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > TrsrPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = TrsrFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > TrsrPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (TrsrFileLoaded == null) return;
            Console.WriteLine("DEBUG > TrsrPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > TrsrPageHandler > Finished saving!");
        }
    }
}
