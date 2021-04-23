using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Evtp;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.System03.Evtp
{
    class EvtpPageHandler : memoryLoadFile
    {
        public EvtpFile EvtpFileLoaded { get; set; }
        public ObservableCollection<EvtpItem> EvtpFileItems { get; set; }

        public EvtpPageHandler(EvtpFile file)
        {
            MemOffsetFallback = "21CE4480"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_03SYSTEM;
            subBarName = "evtp";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > EvtpPageHandler > Processing file...");
            EvtpFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > EvtpPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > EvtpPageHandler > Getting file info...");

            EvtpFileItems = new ObservableCollection<EvtpItem>();
            foreach (EvtpItem entry in EvtpFileLoaded.Entries)
            {
                EvtpFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            EvtpFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (EvtpItem entry in EvtpFileItems)
            {
                EvtpFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > EvtpPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = EvtpFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > EvtpPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (EvtpFileLoaded == null) return;
            Console.WriteLine("DEBUG > EvtpPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > EvtpPageHandler > Finished saving!");
        }
    }
}
