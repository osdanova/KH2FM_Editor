using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Model.Battle.Lvup;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Battle.Lvup
{
    class LvupPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public LvupFile LvupFileLoaded { get; set; }
        public ObservableCollection<LvupItem> LvupFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }

        public LvupPageHandler(LvupFile file)
        {
            MemOffset = "21D0B6A4";
            Console.WriteLine("DEBUG > LvupPageHandler > Processing file...");
            LvupFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > LvupPageHandler > File processed!");
        }
        /*
        public void processFile()
        {
            Console.WriteLine("DEBUG > LvupPageHandler > Getting file info...");

            LvupFileItems = new ObservableCollection<LvupItem>();
            foreach (LvupItem entry in LvupFileLoaded.Entries)
            {
                LvupFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            LvupFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (LvupItem entry in LvupFileItems)
            {
                LvupFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > LvupPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = LvupFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > LvupPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (LvupFileLoaded == null) return;
            Console.WriteLine("DEBUG > LvupPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > LvupPageHandler > Finished saving!");
        }*/
    }
}
