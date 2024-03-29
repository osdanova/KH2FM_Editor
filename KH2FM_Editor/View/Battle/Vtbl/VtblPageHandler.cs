﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.Battle.Vtbl;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Battle.Vtbl
{
    class VtblPageHandler : memoryLoadFile
    {
        public VtblFile VtblFileLoaded { get; set; }
        public ObservableCollection<VtblItem> VtblFileItems { get; set; }

        public VtblPageHandler(VtblFile file)
        {
            MemOffsetFallback = "21D0A96C"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_00BATTLE;
            subBarName = "vtbl";
            stringToFind = subBarName;

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
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > VtblPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (VtblFileLoaded == null) return;
            Console.WriteLine("DEBUG > VtblPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > VtblPageHandler > Finished saving!");
        }
    }
}
