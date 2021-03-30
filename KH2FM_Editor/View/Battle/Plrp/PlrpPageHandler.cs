using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.Battle.Plrp;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Battle.Plrp
{
    class PlrpPageHandler : memoryLoadFile
    {
        public PlrpFile PlrpFileLoaded { get; set; }
        public ObservableCollection<PlrpItem> PlrpFileItems { get; set; }

        public PlrpPageHandler(PlrpFile file)
        {
            MemOffsetFallback = "21D16E88"; // PCSX2 CCZ's eng patch
            MemOffset = MemOffsetFallback;
            stringToFind = "plrp";

            findAddress();
            Console.WriteLine("DEBUG > PlrpPageHandler > Processing file...");
            PlrpFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > PlrpPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > PlrpPageHandler > Getting file info...");

            PlrpFileItems = new ObservableCollection<PlrpItem>();
            foreach (PlrpItem entry in PlrpFileLoaded.Entries)
            {
                PlrpFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            PlrpFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (PlrpItem entry in PlrpFileItems)
            {
                PlrpFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > PlrpPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = PlrpFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > PlrpPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (PlrpFileLoaded == null) return;
            Console.WriteLine("DEBUG > PlrpPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > PlrpPageHandler > Finished saving!");
        }
    }
}
