using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.Jiminy.Worl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Jiminy.Worl
{
    class WorlPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public WorlFile WorlFileLoaded { get; set; }
        public ObservableCollection<WorlItem> WorlFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }

        public WorlPageHandler(WorlFile file)
        {
            MemOffset = "2150C8F0";
            Console.WriteLine("DEBUG > WorlPageHandler > Processing file...");
            WorlFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > WorlPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > WorlPageHandler > Getting file info...");

            WorlFileItems = new ObservableCollection<WorlItem>();
            foreach (WorlItem entry in WorlFileLoaded.Entries)
            {
                WorlFileItems.Add(entry);
            }
        }
        
        public void insertDataToFile()
        {
            WorlFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (WorlItem entry in WorlFileItems)
            {
                WorlFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > WorlPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = WorlFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > WorlPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (WorlFileLoaded == null) return;
            Console.WriteLine("DEBUG > WorlPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > WorlPageHandler > Finished saving!");
        }
    }
}
