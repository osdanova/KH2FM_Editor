using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.Battle.Patn;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Battle.Patn
{
    class PatnPageHandler : memoryLoadFile
    {
        public PatnFile PatnFileLoaded { get; set; }
        public ObservableCollection<PatnItem> PatnFileItems { get; set; }

        public PatnPageHandler(PatnFile file)
        {
            MemOffsetFallback = "21D16C40"; // PCSX2 CCZ's eng patch
            MemOffset = MemOffsetFallback;
            stringToFind = "patn";

            findAddress();
            Console.WriteLine("DEBUG > PatnPageHandler > Processing file...");
            PatnFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > PatnPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > PatnPageHandler > Getting file info...");

            PatnFileItems = new ObservableCollection<PatnItem>();
            foreach (PatnItem entry in PatnFileLoaded.Entries)
            {
                PatnFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            PatnFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (PatnItem entry in PatnFileItems)
            {
                PatnFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > PatnPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = PatnFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > PatnPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (PatnFileLoaded == null) return;
            Console.WriteLine("DEBUG > PatnPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > PatnPageHandler > Finished saving!");
        }
    }
}
