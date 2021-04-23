using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Item;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.System03.Item
{
    class ItemPageHandler : memoryLoadFile
    {
        public ItemFile ItemFileLoaded { get; set; }
        public ObservableCollection<ItemItem> ItemFileItems { get; set; }
        public ObservableCollection<EquipmentItem> ItemFileEquipment { get; set; }

        public ItemPageHandler(ItemFile file)
        {
            MemOffsetFallback = "21CDBBA0"; // PCSX2 CCZ's eng patch
            fileType = Enum.FileType.KH2_03SYSTEM;
            subBarName = "item";
            stringToFind = subBarName;

            findAddress();
            Console.WriteLine("DEBUG > ItemPageHandler > Processing file...");
            ItemFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > ItemPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > ItemPageHandler > Getting file info...");

            ItemFileItems = new ObservableCollection<ItemItem>();
            ItemFileEquipment = new ObservableCollection<EquipmentItem>();
            foreach (ItemItem entry in ItemFileLoaded.Items.Entries)
            {
                ItemFileItems.Add(entry);
            }
            foreach (EquipmentItem entry in ItemFileLoaded.Equipment.Entries)
            {
                ItemFileEquipment.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            ItemFileLoaded.Items.Entries = new ObservableCollection<Str_EntryItem>();
            ItemFileLoaded.Equipment.Entries = new ObservableCollection<Str_EntryItem>();
            foreach (ItemItem entry in ItemFileItems)
            {
                ItemFileLoaded.Items.Entries.Add(entry);
            }
            foreach (EquipmentItem entry in ItemFileEquipment)
            {
                ItemFileLoaded.Equipment.Entries.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > ItemPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = ItemFileLoaded.getAsByteList();
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > ItemPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (ItemFileLoaded == null) return;
            Console.WriteLine("DEBUG > ItemPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > ItemPageHandler > Finished saving!");
        }
    }
}
