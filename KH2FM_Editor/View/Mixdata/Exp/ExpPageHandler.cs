using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.Mixdata.Exp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Mixdata.Exp
{
    class ExpPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public ExpFile ExpFileLoaded { get; set; }
        public ObservableCollection<ExpItem> ExpFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }

        public ExpPageHandler(ExpFile file)
        {
            MemOffset = "211A9F80";
            Console.WriteLine("DEBUG > ExpPageHandler > Processing file...");
            ExpFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > ExpPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > ExpPageHandler > Getting file info...");

            ExpFileItems = new ObservableCollection<ExpItem>();
            foreach (ExpItem entry in ExpFileLoaded.Entries)
            {
                ExpFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            ExpFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (ExpItem entry in ExpFileItems)
            {
                ExpFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > ExpPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = ExpFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > ExpPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (ExpFileLoaded == null) return;
            Console.WriteLine("DEBUG > ExpPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > ExpPageHandler > Finished saving!");
        }
    }
}
