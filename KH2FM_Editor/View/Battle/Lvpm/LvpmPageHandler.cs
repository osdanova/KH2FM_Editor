using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.Battle.Lvpm;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Battle.Lvpm
{
    class LvpmPageHandler : memoryLoadFile
    {
        public LvpmFile LvpmFileLoaded { get; set; }
        public ObservableCollection<LvpmItem> LvpmFileItems { get; set; }

        public LvpmPageHandler(LvpmFile file)
        {
            MemOffsetFallback = "21D11548"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_00BATTLE;
            subBarName = "lvpm";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > LvpmPageHandler > Processing file...");
            LvpmFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > LvpmPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > LvpmPageHandler > Getting file info...");

            LvpmFileItems = new ObservableCollection<LvpmItem>();
            foreach (LvpmItem entry in LvpmFileLoaded.Entries)
            {
                LvpmFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            LvpmFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (LvpmItem entry in LvpmFileItems)
            {
                LvpmFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > LvpmPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = LvpmFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > LvpmPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (LvpmFileLoaded == null) return;
            Console.WriteLine("DEBUG > LvpmPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > LvpmPageHandler > Finished saving!");
        }
    }
}
