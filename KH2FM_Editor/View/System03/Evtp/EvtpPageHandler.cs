using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Evtp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.System03.Evtp
{
    class EvtpPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public EvtpFile EvtpFileLoaded { get; set; }
        public ObservableCollection<EvtpItem> EvtpFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }
        public static string MemOffsetFallback = "21CE4480"; // Crazycatz's English patch
        public static bool AddressFound = false;

        public EvtpPageHandler(EvtpFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > EvtpPageHandler > Processing file...");
            EvtpFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > EvtpPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > EvtpPageHandler > Getting file info...");

            EvtpFileItems = new ObservableCollection<EvtpItem>();
            foreach (EvtpItem entry in EvtpFileLoaded.Entries)
            {
                EvtpFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            EvtpFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (EvtpItem entry in EvtpFileItems)
            {
                EvtpFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > EvtpPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = EvtpFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > EvtpPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (EvtpFileLoaded == null) return;
            Console.WriteLine("DEBUG > EvtpPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > EvtpPageHandler > Finished saving!");
        }

        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("evtp");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
