using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.System03.Pref.Magi;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.View.System03.Magi
{
    class MagiPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public MagiFile MagiFileLoaded { get; set; }
        //public ObservableCollection<MagiItem> MagiFileItems { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "21CE3848"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public MagiPageHandler(MagiFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > MagiPageHandler > Processing file...");
            MagiFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > MagiPageHandler > File processed!");
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > MagiPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = MagiFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > MagiPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (MagiFileLoaded == null) return;
            Console.WriteLine("DEBUG > MagiPageHandler > Saving...");
            Console.WriteLine("DEBUG > MagiPageHandler > Finished saving!");
        }
        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddressMagi("magi");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
