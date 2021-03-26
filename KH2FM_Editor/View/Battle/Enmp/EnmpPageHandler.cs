using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.Battle.Enmp;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Battle.Enmp
{
    class EnmpPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public EnmpFile EnmpFileLoaded { get; set; }
        public ObservableCollection<EnmpItem> EnmpFileItems { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "21D119EC"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public EnmpPageHandler(EnmpFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > EnmpPageHandler > Processing file...");
            EnmpFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > EnmpPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > EnmpPageHandler > Getting file info...");

            EnmpFileItems = new ObservableCollection<EnmpItem>();
            foreach (EnmpItem entry in EnmpFileLoaded.Entries)
            {
                EnmpFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            EnmpFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (EnmpItem entry in EnmpFileItems)
            {
                EnmpFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > EnmpPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = EnmpFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > EnmpPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (EnmpFileLoaded == null) return;
            Console.WriteLine("DEBUG > EnmpPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > EnmpPageHandler > Finished saving!");
        }

        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("enmp");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
