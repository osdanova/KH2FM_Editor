using System;
using System.Collections.Generic;
using KH2FM_Editor.Model.System03.Pref.Plyr;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.System03.Plyr
{
    class PlyrPageHandler : memoryLoadFile
    {
        public PlyrFile PlyrFileLoaded { get; set; }
        //public ObservableCollection<PlyrItem> PlyrFileItems { get; set; }

        public PlyrPageHandler(PlyrFile file)
        {
            MemOffsetFallback = "21CE2810"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_03SYSTEM;
            subBarName = "pref";
            subSubBarName = "plyr";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > PlyrPageHandler > Processing file...");
            PlyrFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > PlyrPageHandler > File processed!");
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > PlyrPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = PlyrFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > PlyrPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (PlyrFileLoaded == null) return;
            Console.WriteLine("DEBUG > PlyrPageHandler > Saving...");
            Console.WriteLine("DEBUG > PlyrPageHandler > Finished saving!");
        }
    }
}
