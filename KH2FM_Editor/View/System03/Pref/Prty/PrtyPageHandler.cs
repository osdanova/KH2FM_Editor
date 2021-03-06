﻿using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Model.System03.Pref.Prty;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.View.System03.Prty
{
    class PrtyPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public PrtyFile PrtyFileLoaded { get; set; }
        //public ObservableCollection<PrtyItem> PrtyFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }

        public PrtyPageHandler(PrtyFile file)
        {
            MemOffset = "21CE2EF4";
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
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
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
