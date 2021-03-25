using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using KH2FM_Editor.Model.System03.Shop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.System03.Shop
{
    class ShopPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public ShopFile ShopFileLoaded { get; set; }
        public ObservableCollection<ShopItem> ShopFileShops { get; set; }
        public ObservableCollection<InventoryItem> ShopFileInventories { get; set; }
        public ObservableCollection<ProductItem> ShopFileProducts { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }
        public static string MemOffsetFallback = "21CE1630"; // Crazycatz's English patch
        public static bool AddressFound = false;

        public ShopPageHandler(ShopFile file)
        {
            MemOffset = MemOffsetFallback;
            findAddress();
            Console.WriteLine("DEBUG > ShopPageHandler > Processing file...");
            ShopFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > ShopPageHandler > File processed!");
        }

        public void processFile()
        {
            Console.WriteLine("DEBUG > ShopPageHandler > Getting file info...");

            ShopFileShops = new ObservableCollection<ShopItem>();
            ShopFileInventories = new ObservableCollection<InventoryItem>();
            ShopFileProducts = new ObservableCollection<ProductItem>();
            foreach (ShopItem entry in ShopFileLoaded.Shops)
            {
                ShopFileShops.Add(entry);
            }
            foreach (InventoryItem entry in ShopFileLoaded.Inventories)
            {
                ShopFileInventories.Add(entry);
            }
            foreach (ProductItem entry in ShopFileLoaded.Products)
            {
                ShopFileProducts.Add(entry);
            }
        }

        public void insertDataToFile()
        {
            ShopFileLoaded.Shops = new ObservableCollection<ShopItem>();
            ShopFileLoaded.Inventories = new ObservableCollection<InventoryItem>();
            ShopFileLoaded.Products = new ObservableCollection<ProductItem>();
            foreach (ShopItem entry in ShopFileShops)
            {
                ShopFileLoaded.Shops.Add(entry);
            }
            foreach (InventoryItem entry in ShopFileInventories)
            {
                ShopFileLoaded.Inventories.Add(entry);
            }
            foreach (ProductItem entry in ShopFileProducts)
            {
                ShopFileLoaded.Products.Add(entry);
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > ShopPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = ShopFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > ShopPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (ShopFileLoaded == null) return;
            Console.WriteLine("DEBUG > ShopPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > ShopPageHandler > Finished saving!");
        }
        public void findAddress()
        {
            if (AddressFound) return;
            int addressInt = Pcsx2Memory.findBarFileAddress("shop");
            AddressFound = true;
            if (addressInt == -1) return;
            MemOffset = FormatHandler.getHexString8(addressInt);
        }
    }
}
