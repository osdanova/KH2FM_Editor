﻿using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Model.Battle.Magc;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Battle.Magc
{
    class MagcPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public MagcFile MagcFileLoaded { get; set; }
        public ObservableCollection<MagcItem> MagcFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }

        public MagcPageHandler(MagcFile file)
        {
            MemOffset = "21D19760";
            Console.WriteLine("DEBUG > MagcPageHandler > Processing file...");
            MagcFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > MagcPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > MagcPageHandler > Getting file info...");

            MagcFileItems = new ObservableCollection<MagcItem>();
            foreach (MagcItem entry in MagcFileLoaded.Entries)
            {
                MagcFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            MagcFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (MagcItem entry in MagcFileItems)
            {
                MagcFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > MagcPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = MagcFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > MagcPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (MagcFileLoaded == null) return;
            Console.WriteLine("DEBUG > MagcPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > MagcPageHandler > Finished saving!");
        }
    }
}
