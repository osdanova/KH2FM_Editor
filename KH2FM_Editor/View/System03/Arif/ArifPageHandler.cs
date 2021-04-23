using System;
using System.Collections.Generic;
using KH2FM_Editor.Model.System03.Arif;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.System03.Arif
{
    class ArifPageHandler : memoryLoadFile
    {
        public ArifFile ArifFileLoaded { get; set; }
        //public ObservableCollection<ArifItem> ArifFileItems { get; set; }

        public ArifPageHandler(ArifFile file)
        {
            MemOffsetFallback = "21CD6300"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_03SYSTEM;
            subBarName = "arif";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > ArifPageHandler > Processing file...");
            ArifFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > ArifPageHandler > File processed!");
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > ArifPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = ArifFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > ArifPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (ArifFileLoaded == null) return;
            Console.WriteLine("DEBUG > ArifPageHandler > Saving...");
            Console.WriteLine("DEBUG > ArifPageHandler > Finished saving!");
        }
    }
}
