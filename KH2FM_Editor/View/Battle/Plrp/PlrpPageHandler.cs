using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.Battle.Plrp;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Battle.Plrp
{
    class PlrpPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public PlrpFile PlrpFileLoaded { get; set; }
        public ObservableCollection<PlrpItem> PlrpFileItems { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "21D16E88"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public PlrpPageHandler(PlrpFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > PlrpPageHandler > Processing file...");
            PlrpFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > PlrpPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > PlrpPageHandler > Getting file info...");

            PlrpFileItems = new ObservableCollection<PlrpItem>();
            foreach (PlrpItem entry in PlrpFileLoaded.Entries)
            {
                PlrpFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            PlrpFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (PlrpItem entry in PlrpFileItems)
            {
                PlrpFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > PlrpPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = PlrpFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > PlrpPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (PlrpFileLoaded == null) return;
            Console.WriteLine("DEBUG > PlrpPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > PlrpPageHandler > Finished saving!");
        }

        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("plrp");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
