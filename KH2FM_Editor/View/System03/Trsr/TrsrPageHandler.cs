using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Trsr;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.System03.Trsr
{
    class TrsrPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public TrsrFile TrsrFileLoaded { get; set; }
        public ObservableCollection<TrsrItem> TrsrFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }

        public TrsrPageHandler(TrsrFile file)
        {
            MemOffset = "21CDF748";
            Console.WriteLine("DEBUG > TrsrPageHandler > Processing file...");
            TrsrFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > TrsrPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > TrsrPageHandler > Getting file info...");

            TrsrFileItems = new ObservableCollection<TrsrItem>();
            foreach (TrsrItem entry in TrsrFileLoaded.Entries)
            {
                TrsrFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            TrsrFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (TrsrItem entry in TrsrFileItems)
            {
                TrsrFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > TrsrPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = TrsrFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > TrsrPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (TrsrFileLoaded == null) return;
            Console.WriteLine("DEBUG > TrsrPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > TrsrPageHandler > Finished saving!");
        }
    }
}
