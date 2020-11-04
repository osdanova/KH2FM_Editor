using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.Bar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KH2FM_Editor.Model.System03.Shop
{
    class ShopFile : BarSubFile
    {
        // Contains a list of programs
        public String Name { get; set; }
        public List<byte> Header { get; set; }
        public ObservableCollection<ShopItem> Shops { get; set; }
        public ObservableCollection<InventoryItem> Inventories { get; set; }
        public ObservableCollection<ProductItem> Products { get; set; }

        // Data Location
        int shopSize = 24, inventorySize = 8, productSize = 2;
        protected int headerOffset = 0, headerSize = 16;
        protected int shopCountOffset = 6, shopCountSize = 2;

        public ShopFile(String name, List<byte> raw)
        {
            Console.WriteLine("DEBUG >>> Found Shop file: " + name);
            this.Name = name;
            processFile(raw);
        }

        public ushort ShopCount
        {
            get { return DataAccess.readUShort(Header, shopCountOffset, shopCountSize); }
            set { DataAccess.writeUShort(Header, value, shopCountOffset, shopCountSize); }
        }

        public void processFile(List<byte> raw)
        {
            processHeader(raw);
            // Shops
            processShops(raw, headerSize);
            // Inventories
            int inventoryStartOffset = headerSize + (int)(Shops.Count * shopSize);
            processInventories(raw, inventoryStartOffset);
            // Products
            int productStartOffset = inventoryStartOffset + (int)(Inventories.Count * inventorySize);
            processProducts(raw, productStartOffset);
        }

        public void processHeader(List<byte> raw)
        {
            Header = raw.GetRange(headerOffset, headerSize);
        }

        public void processShops(List<byte> raw, int offset)
        {
            Shops = new ObservableCollection<ShopItem>();
            int currentOffset = offset;

            for (int i = 0; i < ShopCount; i++)
            {
                Shops.Add(new ShopItem(raw.GetRange(currentOffset, shopSize)));
                currentOffset += shopSize;
            }
        }
        public void processInventories(List<byte> raw, int offset)
        {
            Inventories = new ObservableCollection<InventoryItem>();
            int currentOffset = offset;

            // GET THE AMOUNT OF ITEMS FROM THE SHOPS

            for (int i = 0; i < Shops.Count; i++)
            {
                for(int j = 0; j < ((ShopItem)Shops[i]).InventoryCount; j++)
                {
                    Inventories.Add(new InventoryItem(raw.GetRange(currentOffset, inventorySize)));
                    currentOffset += inventorySize;
                }
            }
        }
        public void processProducts(List<byte> raw, int offset)
        {
            Products = new ObservableCollection<ProductItem>();
            int currentOffset = offset;
            int totalEntries = (raw.Count - offset) / productSize;

            for (int i = 0; i < totalEntries; i++)
            {
                Products.Add(new ProductItem(raw.GetRange(currentOffset, productSize)));
                currentOffset += productSize;
            }
        }

        public void recalcEntryCount()
        {
            ShopCount = (ushort)Shops.Count;
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            List<byte> data = new List<byte>();

            recalcEntryCount();

            // Header
            data.AddRange(Header);
            // Shops
            foreach (ShopItem shop in Shops)
            {
                data.AddRange(shop.getAsByteList());
            }
            // Inventories
            foreach (InventoryItem inventory in Inventories)
            {
                data.AddRange(inventory.getAsByteList());
            }
            // Products
            foreach (ProductItem product in Products)
            {
                data.AddRange(product.getAsByteList());
            }

            return data;
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}
