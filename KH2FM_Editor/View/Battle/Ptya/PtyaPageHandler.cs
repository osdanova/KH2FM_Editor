using System;
using System.Collections.Generic;
using KH2FM_Editor.Model.Battle.Ptya;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Battle.Ptya
{
    class PtyaPageHandler : memoryLoadFile
    {
        public PtyaFile PtyaFileLoaded { get; set; }
        //public ObservableCollection<PtyaItem> PtyaFileItems { get; set; }

        public PtyaPageHandler(PtyaFile file)
        {
            MemOffsetFallback = "21D05CE0"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_00BATTLE;
            subBarName = "ptya";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > PtyaPageHandler > Processing file...");
            PtyaFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > PtyaPageHandler > File processed!");
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > PtyaPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = PtyaFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > PtyaPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (PtyaFileLoaded == null) return;
            Console.WriteLine("DEBUG > PtyaPageHandler > Saving...");
            Console.WriteLine("DEBUG > PtyaPageHandler > Finished saving!");
        }
    }
}
