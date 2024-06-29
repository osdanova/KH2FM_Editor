using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Model.Battle.Atkp;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.View.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Battle.Atkp
{
    class AtkpPageHandler : memoryLoadFile
    {
        public AtkpFile AtkpFileLoaded { get; set; }
        public ObservableCollection<AtkpItem> AtkpFileItems { get; set; }
        public ObservableCollection<AtkpItem> AtkpFileItemsDisplay { get; set; }
        public string SearchString { get; set; }
        public static Dictionary<byte, string> TypeOptions { get; set; }
        public static Dictionary<byte, string> ElementOptions { get; set; }
        public static Dictionary<byte, string> RefactOptions { get; set; }
        public static Dictionary<byte, string> TrReactionOptions { get; set; }
        public static Dictionary<byte, string> KindOptions { get; set; }

        public AtkpPageHandler(AtkpFile file)
        {
            LoadOptions();
            MemOffsetFallback = "21CE5F10"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_00BATTLE;
            subBarName = "atkp";
            stringToFind = subBarName;

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
            AtkpFileItemsDisplay = new ObservableCollection<AtkpItem>();
            foreach (AtkpItem entry in AtkpFileLoaded.Entries)
            {
                AtkpFileItems.Add(entry);
                AtkpFileItemsDisplay.Add(entry);
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
            Console.WriteLine("DEBUG > AtkpPageHandler > Writing to Process...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = AtkpFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > AtkpPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (AtkpFileLoaded == null) return;
            Console.WriteLine("DEBUG > AtkpPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > AtkpPageHandler > Finished saving!");
        }
        public void act_search()
        {
            Console.WriteLine("DEBUG > AtkpPageHandler > Searching...");
            AtkpFileItemsDisplay.Clear();
            foreach (AtkpItem entry in AtkpFileItems)
            {
                if (SearchString == "" ||
                    entry.Id.ToString() == SearchString)
                {
                    AtkpFileItemsDisplay.Add(entry);
                }
            }
            Console.WriteLine("DEBUG > AtkpPageHandler > Finished searching!");
        }

        private void LoadOptions()
        {
            TypeOptions = AtkpDictionary.typeDictionary;
            ElementOptions = Elements.elementDictionary;
            RefactOptions = AtkpDictionary.refactDictionary;
            TrReactionOptions = AtkpDictionary.trReactionDictionary;
            KindOptions = AtkpDictionary.kindDictionary;
        }
    }
}
