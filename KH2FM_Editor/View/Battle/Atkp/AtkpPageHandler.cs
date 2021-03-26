using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.Battle.Atkp;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Battle.Atkp
{
    class AtkpPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public AtkpFile AtkpFileLoaded { get; set; }
        public ObservableCollection<AtkpItem> AtkpFileItems { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "21CE5F10"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public AtkpPageHandler(AtkpFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > AtkpPageHandler > Processing file...");
            AtkpFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > AtkpPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > AtkpPageHandler > Getting file info...");

            AtkpFileItems = new ObservableCollection<AtkpItem>();
            foreach (AtkpItem entry in AtkpFileLoaded.Entries)
            {
                AtkpFileItems.Add(entry);
            }
        }
        
        public void insertDataToFile()
        {
            AtkpFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (AtkpItem entry in AtkpFileItems)
            {
                AtkpFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > AtkpPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = AtkpFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > AtkpPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (AtkpFileLoaded == null) return;
            Console.WriteLine("DEBUG > AtkpPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > AtkpPageHandler > Finished saving!");
        }

        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("atkp");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
