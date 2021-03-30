using System;
using System.Collections.Generic;
using KH2FM_Editor.Model.System03.Pref.Sstm;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.System03.Sstm
{
    class SstmPageHandler : memoryLoadFile
    {
        public SstmFile SstmFileLoaded { get; set; }
        //public ObservableCollection<SstmItem> SstmFileItems { get; set; }

        public SstmPageHandler(SstmFile file)
        {
            MemOffsetFallback = "21CE36C4"; // PCSX2 CCZ's eng patch
            MemOffset = MemOffsetFallback;
            stringToFind = "sstm";

            findAddress();
            Console.WriteLine("DEBUG > SstmPageHandler > Processing file...");
            SstmFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > SstmPageHandler > File processed!");
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > SstmPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = SstmFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > SstmPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (SstmFileLoaded == null) return;
            Console.WriteLine("DEBUG > SstmPageHandler > Saving...");
            Console.WriteLine("DEBUG > SstmPageHandler > Finished saving!");
        }
    }
}
