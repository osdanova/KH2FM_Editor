using System;
using System.Collections.Generic;
using KH2FM_Editor.Model.System03.Pref.Prty;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.System03.Prty
{
    class PrtyPageHandler : memoryLoadFile
    {
        public PrtyFile PrtyFileLoaded { get; set; }
        //public ObservableCollection<PrtyItem> PrtyFileItems { get; set; }

        public PrtyPageHandler(PrtyFile file)
        {
            MemOffsetFallback = "21CE2EF4"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_03SYSTEM;
            subBarName = "pref";
            subSubBarName = "prty";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > PrtyPageHandler > Processing file...");
            PrtyFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > PrtyPageHandler > File processed!");
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > PrtyPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = PrtyFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > PrtyPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (PrtyFileLoaded == null) return;
            Console.WriteLine("DEBUG > PrtyPageHandler > Saving...");
            Console.WriteLine("DEBUG > PrtyPageHandler > Finished saving!");
        }
    }
}
