using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using KH2FM_Editor.Libs.FileHandler;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.Objentry;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.Objentry
{
    class ObjentryPageHandler : memoryLoadFile
    {
        // DATA
        String FileName { get; set; }
        String FilePath { get; set; }
        public ObjentryFile ObjentryFileLoaded { get; set; }
        public ObservableCollection<ObjentryItem> ObjentryFileItems { get; set; }

        // OPTIONS
        public string EntitySearch { get; set; }

        public ObjentryPageHandler(String filepath)
        {
            MemOffsetFallback = "21CE3848"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_00OBJENTRY;
            stringToFind = subBarName;

            findAddress();
            EntitySearch = "";
            Console.WriteLine("DEBUG > ObjentryPageHandler > Processing file...");
            processFile(filepath);
            Console.WriteLine("DEBUG > ObjentryPageHandler > File processed!");
        }

        public void processFile(String filePath)
        {
            Console.WriteLine("DEBUG > ObjentryPageHandler > Getting file info...");
            // Get file data
            this.FilePath = filePath;
            FileName = Path.GetFileName(this.FilePath);

            // Assert objentry.bin file
            if (!FileName.EndsWith("objentry.bin")) return;

            Console.WriteLine("DEBUG > ObjentryPageHandler > Reading " + FileName + "...");
            ObjentryFileLoaded = new ObjentryFile(FileName, File.ReadAllBytes(filePath).ToList());

            ObjentryFileItems = new ObservableCollection<ObjentryItem>();
            foreach (ObjentryItem entry in ObjentryFileLoaded.Entries)
            {
                ObjentryFileItems.Add(entry);
            }
        }
        
        public void insertDataToFile()
        {
            ObjentryFileLoaded.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (ObjentryItem entry in ObjentryFileItems)
            {
                ObjentryFileLoaded.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > ObjentryPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = ObjentryFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > ObjentryPageHandler > Finished writing!");
        }

        public void act_search()
        {
            Console.WriteLine("DEBUG > ObjentryPageHandler > Searching...");
            if (EntitySearch == "")
            {
                foreach (ObjentryItem entry in ObjentryFileLoaded.Entries)
                {
                    ObjentryFileItems.Add(entry);
                }
            }
            ObjentryFileItems.Clear();
            foreach (ObjentryItem entry in ObjentryFileLoaded.Entries)
            {
                if (entry.EntityValue.ToLower().Contains(EntitySearch) ||
                    entry.Id.ToString() == EntitySearch)
                {
                    ObjentryFileItems.Add(entry);
                }
            }
            Console.WriteLine("DEBUG > ObjentryPageHandler > Finished searching!");
        }

        public void act_save()
        {
            if (ObjentryFileLoaded == null) return;
            Console.WriteLine("DEBUG > ObjentryPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > ObjentryPageHandler > Finished saving!");
        }

        public void act_export()
        {
            if (ObjentryFileLoaded == null) return;
            Console.WriteLine("DEBUG > ObjentryPageHandler > Exporting...");
            FileHandler.saveFile(FileName, ObjentryFileLoaded.getAsByteList());
            Console.WriteLine("DEBUG > ObjentryPageHandler > Export saving!");
        }
    }
}
