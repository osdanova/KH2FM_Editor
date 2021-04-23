using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Memt;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.System03.Memt
{
    class MemtPageHandler : memoryLoadFile
    {
        public MemtFile MemtFileLoaded { get; set; }
        public ObservableCollection<MemtItem> MemtFileItems { get; set; }
        public ObservableCollection<MemtConf> MemtFileConfs { get; set; }

        public MemtPageHandler(MemtFile file)
        {
            MemOffsetFallback = "21CE0BA0"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_03SYSTEM;
            subBarName = "memt";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > MemtPageHandler > Processing file...");
            MemtFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > MemtPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > MemtPageHandler > Getting file info...");

            MemtFileItems = new ObservableCollection<MemtItem>();
            foreach (MemtItem entry in MemtFileLoaded.Entries)
            {
                MemtFileItems.Add(entry);
            }
            MemtFileConfs = new ObservableCollection<MemtConf>();
            foreach (MemtConf entry in MemtFileLoaded.MemtConfs)
            {
                MemtFileConfs.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            MemtFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (MemtItem entry in MemtFileItems)
            {
                MemtFileLoaded.Entries.Add(entry);
            }
            MemtFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (MemtConf entry in MemtFileConfs)
            {
                MemtFileLoaded.MemtConfs.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > MemtPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = MemtFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > MemtPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (MemtFileLoaded == null) return;
            Console.WriteLine("DEBUG > MemtPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > MemtPageHandler > Finished saving!");
        }
    }
}
