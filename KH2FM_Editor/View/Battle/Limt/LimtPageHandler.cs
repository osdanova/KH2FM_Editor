using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.Battle.Limt;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Battle.Limt
{
    class LimtPageHandler : memoryLoadFile
    {
        public LimtFile LimtFileLoaded { get; set; }
        public ObservableCollection<LimtItem> LimtFileItems { get; set; }

        public LimtPageHandler(LimtFile file)
        {
            MemOffsetFallback = "21D18E90"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_00BATTLE;
            subBarName = "limt";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > LimtPageHandler > Processing file...");
            LimtFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > LimtPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > LimtPageHandler > Getting file info...");

            LimtFileItems = new ObservableCollection<LimtItem>();
            foreach (LimtItem entry in LimtFileLoaded.Entries)
            {
                LimtFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            LimtFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (LimtItem entry in LimtFileItems)
            {
                LimtFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > LimtPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = LimtFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > LimtPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (LimtFileLoaded == null) return;
            Console.WriteLine("DEBUG > LimtPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > LimtPageHandler > Finished saving!");
        }
    }
}
