﻿using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Model.Battle.Fmlv;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Battle.Fmlv
{
    class FmlvPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public FmlvFile FmlvFileLoaded { get; set; }
        public ObservableCollection<FmlvItem> FmlvFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }

        public FmlvPageHandler(FmlvFile file)
        {
            MemOffset = "21D1A224";
            Console.WriteLine("DEBUG > FmlvPageHandler > Processing file...");
            FmlvFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > FmlvPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > FmlvPageHandler > Getting file info...");

            FmlvFileItems = new ObservableCollection<FmlvItem>();
            foreach (FmlvItem entry in FmlvFileLoaded.Entries)
            {
                FmlvFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            FmlvFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (FmlvItem entry in FmlvFileItems)
            {
                FmlvFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > FmlvPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = FmlvFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > FmlvPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (FmlvFileLoaded == null) return;
            Console.WriteLine("DEBUG > FmlvPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > FmlvPageHandler > Finished saving!");
        }
    }
}
