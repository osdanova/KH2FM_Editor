using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.Battle.Patn;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Battle.Patn
{
    class PatnPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public PatnFile PatnFileLoaded { get; set; }
        public ObservableCollection<PatnItem> PatnFileItems { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "21D16C40"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public PatnPageHandler(PatnFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > PatnPageHandler > Processing file...");
            PatnFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > PatnPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > PatnPageHandler > Getting file info...");

            PatnFileItems = new ObservableCollection<PatnItem>();
            foreach (PatnItem entry in PatnFileLoaded.Entries)
            {
                PatnFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            PatnFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (PatnItem entry in PatnFileItems)
            {
                PatnFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > PatnPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = PatnFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > PatnPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (PatnFileLoaded == null) return;
            Console.WriteLine("DEBUG > PatnPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > PatnPageHandler > Finished saving!");
        }

        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("patn");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
