using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.Battle.Fmlv;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Battle.Fmlv
{
    class FmlvPageHandler : memoryLoadFile
    {
        public FmlvFile FmlvFileLoaded { get; set; }
        public ObservableCollection<FmlvItem> FmlvFileItems { get; set; }

        public FmlvPageHandler(FmlvFile file)
        {
            MemOffsetFallback = "21D1A224"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_00BATTLE;
            subBarName = "fmlv";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > FmlvPageHandler > Processing file...");
            FmlvFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > FmlvPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > FmlvPageHandler > Getting file info...");

            FmlvFileItems = new ObservableCollection<FmlvItem>();
            foreach (FmlvItem entry in FmlvFileLoaded.Entries)
            {
                FmlvFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            FmlvFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (FmlvItem entry in FmlvFileItems)
            {
                FmlvFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > FmlvPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = FmlvFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > FmlvPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (FmlvFileLoaded == null) return;
            Console.WriteLine("DEBUG > FmlvPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > FmlvPageHandler > Finished saving!");
        }
    }
}
