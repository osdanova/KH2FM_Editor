using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.Battle.Lvpm;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Battle.Lvpm
{
    class LvpmPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public LvpmFile LvpmFileLoaded { get; set; }
        public ObservableCollection<LvpmItem> LvpmFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }
        public static string MemOffsetFallback = "21D11548"; // Crazycatz's English patch
        public static bool AddressFound = false;

        public LvpmPageHandler(LvpmFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > LvpmPageHandler > Processing file...");
            LvpmFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > LvpmPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > LvpmPageHandler > Getting file info...");

            LvpmFileItems = new ObservableCollection<LvpmItem>();
            foreach (LvpmItem entry in LvpmFileLoaded.Entries)
            {
                LvpmFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            LvpmFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (LvpmItem entry in LvpmFileItems)
            {
                LvpmFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > LvpmPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = LvpmFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > LvpmPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (LvpmFileLoaded == null) return;
            Console.WriteLine("DEBUG > LvpmPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > LvpmPageHandler > Finished saving!");
        }

        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("lvpm");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
