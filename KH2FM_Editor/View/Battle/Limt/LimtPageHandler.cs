using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Model.Battle.Limt;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Battle.Limt
{
    class LimtPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public LimtFile LimtFileLoaded { get; set; }
        public ObservableCollection<LimtItem> LimtFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }

        public LimtPageHandler(LimtFile file)
        {
            MemOffset = "21D18E90";
            Console.WriteLine("DEBUG > LimtPageHandler > Processing file...");
            LimtFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > LimtPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > LimtPageHandler > Getting file info...");

            LimtFileItems = new ObservableCollection<LimtItem>();
            foreach (LimtItem entry in LimtFileLoaded.Entries)
            {
                LimtFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            LimtFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (LimtItem entry in LimtFileItems)
            {
                LimtFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > LimtPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = LimtFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > LimtPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (LimtFileLoaded == null) return;
            Console.WriteLine("DEBUG > LimtPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > LimtPageHandler > Finished saving!");
        }
    }
}
