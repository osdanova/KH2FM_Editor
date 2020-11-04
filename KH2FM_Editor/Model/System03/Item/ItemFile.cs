using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.Bar;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Item
{
    public class ItemFile : BarSubFile
    {
        public String Name { get; set; }
        public List<byte> Header { get; set; }
        public ItemTable Items { get; set; }
        public EquipmentTable Equipment { get; set; }

        // Data Location
        int itemsHeaderSize = 8;
        int equipHeaderSize = 8;

        public ItemFile(String name, List<byte> raw)
        {
            Console.WriteLine("DEBUG >>> Found Item file: " + name);
            this.Name = name;

            processItems(raw);
            processEquipment(raw);
        }

        public void processItems(List<byte> raw)
        {
            uint itemsCount = DataAccess.readUInt(raw, 4, 4);
            Items = new ItemTable("ItemTable", raw.GetRange(0, itemsHeaderSize + ((int)itemsCount * (int) ItemItem.entrySize)));
        }
        public void processEquipment(List<byte> raw)
        {
            int equipTableStart = itemsHeaderSize + ((int)Items.EntryCount * ItemItem.entrySize);
            uint equipCount = DataAccess.readUInt(raw, equipTableStart + 4, 4);
            Equipment = new EquipmentTable("ItemTable", raw.GetRange(equipTableStart, equipHeaderSize + ((int)equipCount * (int)EquipmentItem.entrySize)));
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            List<byte> data = new List<byte>();

            // Items
            data.AddRange(Items.getAsByteList());
            // Equipment
            data.AddRange(Equipment.getAsByteList());

            return data;
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}
