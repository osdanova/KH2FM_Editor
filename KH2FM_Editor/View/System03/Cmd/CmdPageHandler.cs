using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Cmd;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.System03.Cmd
{
    class CmdPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public CmdFile CmdFileLoaded { get; set; }
        public ObservableCollection<CmdItem> CmdFileItems { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "21CCB5A0"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public CmdPageHandler(CmdFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > CmdPageHandler > Processing file...");
            CmdFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > CmdPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > CmdPageHandler > Getting file info...");

            CmdFileItems = new ObservableCollection<CmdItem>();
            foreach (CmdItem entry in CmdFileLoaded.Entries)
            {
                CmdFileItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            CmdFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (CmdItem entry in CmdFileItems)
            {
                CmdFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > CmdPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = CmdFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > CmdPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (CmdFileLoaded == null) return;
            Console.WriteLine("DEBUG > CmdPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > CmdPageHandler > Finished saving!");
        }
        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("cmd");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
