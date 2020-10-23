using KH2FM_Editor_WPF.FileTypes.GENERIC;
using KH2FM_Editor_WPF.FileTypes.Objentry;
using KH2FM_Editor.Libs.Pcsx2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace KH2FM_Editor.View.Objentry
{
    class ObjentryPageHandler
    {
        // DATA
        String fileName { get; set; }
        String filePath { get; set; }
        public ObjentryFile objentryFile { get; set; }
        public ObservableCollection<ObjentryItem> objentryItems { get; set; }

        // OPTIONS
        public string memOffset { get; set; }
        public string entitySearch { get; set; }

        public ObjentryPageHandler(String filepath)
        {
            memOffset = "21C94100";
            entitySearch = "";
            Console.WriteLine("DEBUG > ObjentryPageHandler > Processing file...");
            processFile(filepath);
            Console.WriteLine("DEBUG > ObjentryPageHandler > File processed!");
        }

        public void processFile(String filePath)
        {
            Console.WriteLine("DEBUG > ObjentryPageHandler > Getting file info...");
            // Get file data
            this.filePath = filePath;
            fileName = Path.GetFileName(this.filePath);

            // Assert objentry.bin file
            if (!fileName.EndsWith("objentry.bin")) return;

            Console.WriteLine("DEBUG > ObjentryPageHandler > Reading " + fileName + "...");
            objentryFile = new ObjentryFile(fileName, File.ReadAllBytes(filePath).ToList());
            objentryItems = new ObservableCollection<ObjentryItem>();

            foreach (ObjentryItem entry in objentryFile.entries)
            {
                objentryItems.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            objentryFile.entries = new List<BaseEntry>();
            foreach (ObjentryItem entry in objentryItems)
            {
                objentryFile.entries.Add(entry);
            }
        }

        public void testData()
        {
            Console.WriteLine("DEBUG > ObjentryPageHandler > Writing to Pcsx2...");
            //insertDataToFile();
            List<byte> fileToWrite = objentryFile.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(memOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > ObjentryPageHandler > Finished writing!");
        }

        public void search()
        {
            Console.WriteLine("DEBUG > ObjentryPageHandler > Searching...");
            if (entitySearch == "")
            {
                foreach (ObjentryItem entry in objentryFile.entries)
                {
                    objentryItems.Add(entry);
                }
            }
            objentryItems.Clear();
            foreach (ObjentryItem entry in objentryFile.entries)
            {
                if (entry.entity.Contains(entitySearch))
                {
                    objentryItems.Add(entry);
                }
            }
            Console.WriteLine("DEBUG > ObjentryPageHandler > Finished searching!");
        }
    }
}
