using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Wmst;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.System03.Wmst
{
    class WmstPageHandler : memoryLoadFile
    {
        public WmstFile WmstFileLoaded { get; set; }
        public ObservableCollection<WmstItem> WmstFileItems { get; set; }

        public WmstPageHandler(WmstFile file)
        {
            MemOffsetFallback = "21CD5180"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_03SYSTEM;
            subBarName = "wmst";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > WmstPageHandler > Processing file...");
            WmstFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > WmstPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > WmstPageHandler > Getting file info...");

            WmstFileItems = new ObservableCollection<WmstItem>();
            foreach (WmstItem entry in WmstFileLoaded.Entries)
            {
                WmstFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            WmstFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (WmstItem entry in WmstFileItems)
            {
                WmstFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > WmstPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = WmstFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > WmstPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (WmstFileLoaded == null) return;
            Console.WriteLine("DEBUG > WmstPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > WmstPageHandler > Finished saving!");
        }
    }
}
