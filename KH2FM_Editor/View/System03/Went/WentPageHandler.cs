using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Went;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.System03.Went
{
    class WentPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public WentFile WentFileLoaded { get; set; }
        //public ObservableCollection<WentItem> WentFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }

        public WentPageHandler(WentFile file)
        {
            MemOffset = "21CD4280";
            Console.WriteLine("DEBUG > WentPageHandler > Processing file...");
            WentFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > WentPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > WentPageHandler > Getting file info...");

            /*WentFileItems = new ObservableCollection<WentItem>();
            foreach (WentItem entry in WentFileLoaded.Entries)
            {
                WentFileItems.Add(entry);
            }*/
        }

        public void insertDataToFile()
        {/*
            WentFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (WentItem entry in WentFileItems)
            {
                WentFileLoaded.Entries.Add(entry);
            }*/
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > WentPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = WentFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > WentPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (WentFileLoaded == null) return;
            Console.WriteLine("DEBUG > WentPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > WentPageHandler > Finished saving!");
        }
    }
}
