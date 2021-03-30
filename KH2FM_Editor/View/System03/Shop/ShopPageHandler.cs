using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KH2FM_Editor.Model.System03.Shop;
using KH2FM_Editor.View.Common;

namespace KH2FM_Editor.View.System03.Shop
{
    class ShopPageHandler : memoryLoadFile
    {
        public ShopFile ShopFileLoaded { get; set; }
        public ObservableCollection<ShopItem> ShopFileShops { get; set; }
        public ObservableCollection<InventoryItem> ShopFileInventories { get; set; }
        public ObservableCollection<ProductItem> ShopFileProducts { get; set; }

        public ShopPageHandler(ShopFile file)
        {
            MemOffsetFallback = "21CE1630"; // PCSX2 CCZ's eng patch
            MemOffset = MemOffsetFallback;
            stringToFind = "shop";

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
            writeFileToProcess(fileToWrite);
            Console.WriteLine("DEBUG > ShopPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (ShopFileLoaded == null) return;
            Console.WriteLine("DEBUG > ShopPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > ShopPageHandler > Finished saving!");
        }
    }
}
