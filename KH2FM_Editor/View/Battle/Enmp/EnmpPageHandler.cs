using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.Battle.Enmp;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Battle.Enmp
{
    class EnmpPageHandler : memoryLoadFile
    {
        public EnmpFile EnmpFileLoaded { get; set; }
        public ObservableCollection<EnmpItem> EnmpFileItems { get; set; }

        public EnmpPageHandler(EnmpFile file)
        {
            MemOffsetFallback = "21D119EC"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_00BATTLE;
            subBarName = "enmp";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > EnmpPageHandler > Processing file...");
            EnmpFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > EnmpPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > EnmpPageHandler > Getting file info...");

            EnmpFileItems = new ObservableCollection<EnmpItem>();
            foreach (EnmpItem entry in EnmpFileLoaded.Entries)
            {
                EnmpFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            EnmpFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (EnmpItem entry in EnmpFileItems)
            {
                EnmpFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > EnmpPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = EnmpFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > EnmpPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (EnmpFileLoaded == null) return;
            Console.WriteLine("DEBUG > EnmpPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > EnmpPageHandler > Finished saving!");
        }
    }
}
