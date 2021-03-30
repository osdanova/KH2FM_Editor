using System;
using System.Collections.Generic;
using KH2FM_Editor.Model.System03.Pref.Fmab;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.System03.Fmab
{
    class FmabPageHandler : memoryLoadFile
    {
        public FmabFile FmabFileLoaded { get; set; }
        //public ObservableCollection<FmabItem> FmabFileItems { get; set; }

        public FmabPageHandler(FmabFile file)
        {
            MemOffsetFallback = "21CE2D88"; // PCSX2 CCZ's eng patch
            MemOffset = MemOffsetFallback;
            stringToFind = "fmab";

            findAddress();
            Console.WriteLine("DEBUG > FmabPageHandler > Processing file...");
            FmabFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > FmabPageHandler > File processed!");
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > FmabPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = FmabFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > FmabPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (FmabFileLoaded == null) return;
            Console.WriteLine("DEBUG > FmabPageHandler > Saving...");
            Console.WriteLine("DEBUG > FmabPageHandler > Finished saving!");
        }
    }
}
