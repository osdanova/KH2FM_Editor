using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.Mixdata.Leve;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Mixdata.Leve
{
    class LevePageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public LeveFile LeveFileLoaded { get; set; }
        public ObservableCollection<LeveItem> LeveFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }

        public LevePageHandler(LeveFile file)
        {
            MemOffset = "211A9F00";
            Console.WriteLine("DEBUG > LevePageHandler > Processing file...");
            LeveFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > LevePageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > LevePageHandler > Getting file info...");

            LeveFileItems = new ObservableCollection<LeveItem>();
            foreach (LeveItem entry in LeveFileLoaded.Entries)
            {
                LeveFileItems.Add(entry);
            }
        }
        
        public void insertDataToFile()
        {
            LeveFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (LeveItem entry in LeveFileItems)
            {
                LeveFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > LevePageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = LeveFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > LevePageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (LeveFileLoaded == null) return;
            Console.WriteLine("DEBUG > LevePageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > LevePageHandler > Finished saving!");
        }
    }
}
