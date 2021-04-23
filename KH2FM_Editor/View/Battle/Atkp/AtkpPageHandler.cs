using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.Battle.Atkp;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Battle.Atkp
{
    class AtkpPageHandler : memoryLoadFile
    {
        public AtkpFile AtkpFileLoaded { get; set; }
        public ObservableCollection<AtkpItem> AtkpFileItems { get; set; }

        public AtkpPageHandler(AtkpFile file)
        {
            MemOffsetFallback = "21CE5F10"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_00BATTLE;
            subBarName = "atkp";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > AtkpPageHandler > Processing file...");
            AtkpFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > AtkpPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > AtkpPageHandler > Getting file info...");

            AtkpFileItems = new ObservableCollection<AtkpItem>();
            foreach (AtkpItem entry in AtkpFileLoaded.Entries)
            {
                AtkpFileItems.Add(entry);
            }
        }
        
        public void insertDataToFile()
        {
            AtkpFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (AtkpItem entry in AtkpFileItems)
            {
                AtkpFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > AtkpPageHandler > Writing to Process...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = AtkpFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > AtkpPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (AtkpFileLoaded == null) return;
            Console.WriteLine("DEBUG > AtkpPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > AtkpPageHandler > Finished saving!");
        }
    }
}
