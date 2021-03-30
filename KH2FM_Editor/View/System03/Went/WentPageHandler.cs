using System;
using System.Collections.Generic;
using KH2FM_Editor.Model.System03.Went;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.System03.Went
{
    class WentPageHandler : memoryLoadFile
    {
        public WentFile WentFileLoaded { get; set; }
        //public ObservableCollection<WentItem> WentFileItems { get; set; }

        public WentPageHandler(WentFile file)
        {
            MemOffsetFallback = "21CD4280"; // PCSX2 CCZ's eng patch
            MemOffset = MemOffsetFallback;
            stringToFind = "went";

            findAddress();
            Console.WriteLine("DEBUG > WentPageHandler > Processing file...");
            WentFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > WentPageHandler > File processed!");
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > WentPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = WentFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > WentPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (WentFileLoaded == null) return;
            Console.WriteLine("DEBUG > WentPageHandler > Saving...");
            Console.WriteLine("DEBUG > WentPageHandler > Finished saving!");
        }
    }
}
