using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Rcct;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.System03.Rcct
{
    class RcctPageHandler : memoryLoadFile
    {
        public RcctFile RcctFileLoaded { get; set; }
        public ObservableCollection<RcctItem> RcctFileItems { get; set; }

        public RcctPageHandler(RcctFile file)
        {
            MemOffsetFallback = "21CCB3E0"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_03SYSTEM;
            subBarName = "rcct";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > RcctPageHandler > Processing file...");
            RcctFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > RcctPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > RcctPageHandler > Getting file info...");

            RcctFileItems = new ObservableCollection<RcctItem>();
            foreach (RcctItem entry in RcctFileLoaded.Entries)
            {
                RcctFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            RcctFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (RcctItem entry in RcctFileItems)
            {
                RcctFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > RcctPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = RcctFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > RcctPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (RcctFileLoaded == null) return;
            Console.WriteLine("DEBUG > RcctPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > RcctPageHandler > Finished saving!");
        }
    }
}
