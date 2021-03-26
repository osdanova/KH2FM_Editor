using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Item;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.System03.Item
{
    class ItemPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public ItemFile ItemFileLoaded { get; set; }
        public ObservableCollection<ItemItem> ItemFileItems { get; set; }
        public ObservableCollection<EquipmentItem> ItemFileEquipment { get; set; }

        // OPTIONS
        public static string MemOffsetFallback = "21CDBBA0"; // Crazycatz's English patch
        public string MemOffset { get; set; }
        public bool AddressFound = false;

        public ItemPageHandler(ItemFile file)
        {
            MemOffset = MemOffsetFallback;
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
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > ItemPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (ItemFileLoaded == null) return;
            Console.WriteLine("DEBUG > ItemPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > ItemPageHandler > Finished saving!");
        }

        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("item");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
