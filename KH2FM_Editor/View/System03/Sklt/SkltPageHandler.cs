using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Sklt;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.System03.Sklt
{
    class SkltPageHandler : memoryLoadFile
    {
        public SkltFile SkltFileLoaded { get; set; }
        public ObservableCollection<SkltItem> SkltFileItems { get; set; }

        public SkltPageHandler(SkltFile file)
        {
            MemOffsetFallback = "21CE26D0"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_03SYSTEM;
            subBarName = "sklt";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > SkltPageHandler > Processing file...");
            SkltFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > SkltPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > SkltPageHandler > Getting file info...");

            SkltFileItems = new ObservableCollection<SkltItem>();
            foreach (SkltItem entry in SkltFileLoaded.Entries)
            {
                SkltFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            SkltFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (SkltItem entry in SkltFileItems)
            {
                SkltFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > SkltPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = SkltFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > SkltPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (SkltFileLoaded == null) return;
            Console.WriteLine("DEBUG > SkltPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > SkltPageHandler > Finished saving!");
        }
    }
}
