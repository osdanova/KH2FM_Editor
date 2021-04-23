using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.Battle.Magc;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Battle.Magc
{
    class MagcPageHandler : memoryLoadFile
    {
        public MagcFile MagcFileLoaded { get; set; }
        public ObservableCollection<MagcItem> MagcFileItems { get; set; }

        public MagcPageHandler(MagcFile file)
        {
            MemOffsetFallback = "21D19760"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_00BATTLE;
            subBarName = "magc";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > MagcPageHandler > Processing file...");
            MagcFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > MagcPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > MagcPageHandler > Getting file info...");

            MagcFileItems = new ObservableCollection<MagcItem>();
            foreach (MagcItem entry in MagcFileLoaded.Entries)
            {
                MagcFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            MagcFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (MagcItem entry in MagcFileItems)
            {
                MagcFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > MagcPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = MagcFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > MagcPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (MagcFileLoaded == null) return;
            Console.WriteLine("DEBUG > MagcPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > MagcPageHandler > Finished saving!");
        }
    }
}
