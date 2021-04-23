using System;
using System.Collections.Generic;
using KH2FM_Editor.Model.System03.Pref.Magi;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.System03.Magi
{
    class MagiPageHandler : memoryLoadFile
    {
        public MagiFile MagiFileLoaded { get; set; }
        //public ObservableCollection<MagiItem> MagiFileItems { get; set; }

        public MagiPageHandler(MagiFile file)
        {
            MemOffsetFallback = "21CE3848"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_03SYSTEM;
            subBarName = "pref";
            subSubBarName = "magi";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > MagiPageHandler > Processing file...");
            MagiFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > MagiPageHandler > File processed!");
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > MagiPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = MagiFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > MagiPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (MagiFileLoaded == null) return;
            Console.WriteLine("DEBUG > MagiPageHandler > Saving...");
            Console.WriteLine("DEBUG > MagiPageHandler > Finished saving!");
        }
    }
}
