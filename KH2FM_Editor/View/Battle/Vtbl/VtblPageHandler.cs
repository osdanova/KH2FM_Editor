using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.Battle.Vtbl;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Battle.Vtbl
{
    class VtblPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public VtblFile VtblFileLoaded { get; set; }
        public ObservableCollection<VtblItem> VtblFileItems { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "21D0A96C"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public VtblPageHandler(VtblFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > VtblPageHandler > Processing file...");
            VtblFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > VtblPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > VtblPageHandler > Getting file info...");

            VtblFileItems = new ObservableCollection<VtblItem>();
            foreach (VtblItem entry in VtblFileLoaded.Entries)
            {
                VtblFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            VtblFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (VtblItem entry in VtblFileItems)
            {
                VtblFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > VtblPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = VtblFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > VtblPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (VtblFileLoaded == null) return;
            Console.WriteLine("DEBUG > VtblPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > VtblPageHandler > Finished saving!");
        }

        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("vtbl");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
