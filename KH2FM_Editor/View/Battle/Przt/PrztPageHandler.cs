using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.Battle.Przt;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Battle.Przt
{
    class PrztPageHandler : memoryLoadFile
    {
        public PrztFile PrztFileLoaded { get; set; }
        public ObservableCollection<PrztItem> PrztFileItems { get; set; }
        public ObservableCollection<PrztItem> PrztFileItemsDisplay { get; set; }
        public string SearchString { get; set; }

        public PrztPageHandler(PrztFile file)
        {
            MemOffsetFallback = "21D09824"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_00BATTLE;
            subBarName = "przt";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > PrztPageHandler > Processing file...");
            PrztFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > PrztPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > PrztPageHandler > Getting file info...");

            PrztFileItems = new ObservableCollection<PrztItem>();
            PrztFileItemsDisplay = new ObservableCollection<PrztItem>();
            foreach (PrztItem entry in PrztFileLoaded.Entries)
            {
                PrztFileItems.Add(entry);
                PrztFileItemsDisplay.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            PrztFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (PrztItem entry in PrztFileItems)
            {
                PrztFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > PrztPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = PrztFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > PrztPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (PrztFileLoaded == null) return;
            Console.WriteLine("DEBUG > PrztPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > PrztPageHandler > Finished saving!");
        }
        public void act_search()
        {
            Console.WriteLine("DEBUG > PrztPageHandler > Searching...");
            PrztFileItemsDisplay.Clear();
            foreach (PrztItem entry in PrztFileItems)
            {
                if (SearchString == "" ||
                    entry.IdValue.ToLower().Contains(SearchString) ||
                    entry.Id.ToString() == SearchString)
                {
                    PrztFileItemsDisplay.Add(entry);
                }
            }
            Console.WriteLine("DEBUG > PrztPageHandler > Finished searching!");
        }
    }
}
