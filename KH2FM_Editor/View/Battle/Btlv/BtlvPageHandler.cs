using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.Battle.Btlv;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Battle.Btlv
{
    class BtlvPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public BtlvFile BtlvFileLoaded { get; set; }
        public ObservableCollection<BtlvItem> BtlvFileItems { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "21D19760"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public BtlvPageHandler(BtlvFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > BtlvPageHandler > Processing file...");
            BtlvFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > BtlvPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > BtlvPageHandler > Getting file info...");

            BtlvFileItems = new ObservableCollection<BtlvItem>();
            foreach (BtlvItem entry in BtlvFileLoaded.Entries)
            {
                BtlvFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            BtlvFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (BtlvItem entry in BtlvFileItems)
            {
                BtlvFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > BtlvPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = BtlvFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > BtlvPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (BtlvFileLoaded == null) return;
            Console.WriteLine("DEBUG > BtlvPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > BtlvPageHandler > Finished saving!");
        }

        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("btlv");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
