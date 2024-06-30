using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Cmd;
using KH2FM_Editor.View.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.System03.Cmd
{
    class CmdPageHandler : memoryLoadFile
    {
        public CmdFile CmdFileLoaded { get; set; }
        public ObservableCollection<CmdItem> CmdFileItems { get; set; }
        public ObservableCollection<CmdItem> CmdFileItemsDisplay { get; set; }
        public string SearchString { get; set; }
        public static Dictionary<byte, string> IconOptions { get; set; }
        public static Dictionary<byte, string> CameraOptions { get; set; }
        public static Dictionary<byte, string> ReceiverOptions { get; set; }
        public static Dictionary<byte, string> ActionOptions { get; set; }

        public CmdPageHandler(CmdFile file)
        {
            LoadOptions();
            MemOffsetFallback = "21CCB5A0"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_03SYSTEM;
            subBarName = "cmd\0";
            stringToFind = subBarName;

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
            CmdFileItemsDisplay = new ObservableCollection<CmdItem>();
            foreach (CmdItem entry in CmdFileLoaded.Entries)
            {
                CmdFileItems.Add(entry);
                CmdFileItemsDisplay.Add(entry);
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
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > CmdPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (CmdFileLoaded == null) return;
            Console.WriteLine("DEBUG > CmdPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > CmdPageHandler > Finished saving!");
        }

        public void act_search()
        {
            Console.WriteLine("DEBUG > CmdPageHandler > Searching...");
            CmdFileItemsDisplay.Clear();
            foreach (CmdItem entry in CmdFileItems)
            {
                if (SearchString == null || SearchString == "" ||
                    entry.CommandValue.ToLower().Contains(SearchString) ||
                    entry.Id.ToString() == SearchString)
                {
                    CmdFileItemsDisplay.Add(entry);
                }
            }
            Console.WriteLine("DEBUG > CmdPageHandler > Finished searching!");
        }

        private void LoadOptions()
        {
            IconOptions = CmdDictionary.iconDictionary;
            CameraOptions = CmdDictionary.cameraDictionary;
            ReceiverOptions = CmdDictionary.receiverDictionary;
            ActionOptions = CmdDictionary.actionDictionary;
        }
    }
}
