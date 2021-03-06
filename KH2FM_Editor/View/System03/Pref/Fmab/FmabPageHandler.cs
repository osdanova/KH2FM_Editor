﻿using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Model.System03.Pref.Fmab;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.View.System03.Fmab
{
    class FmabPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public FmabFile FmabFileLoaded { get; set; }
        //public ObservableCollection<FmabItem> FmabFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }

        public FmabPageHandler(FmabFile file)
        {
            MemOffset = "21CE2D88";
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
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
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
