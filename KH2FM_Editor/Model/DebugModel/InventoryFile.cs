using KH2FM_Editor.DataDictionary;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KH2FM_Editor.Model.DebugModel
{
    public class InventoryFile
    {
        public ObservableCollection<Item> Items { get; set; }
        public int itemCount = 312;

        public InventoryFile()
        {
            Items = new ObservableCollection<Item>();
            foreach (var i in Enumerable.Range(0, itemCount))
            {
                Items.Add(new Item((ushort)i, 0));
            }
        }

        public void readData(List<byte> data, int count)
        {
            itemCount = count;
            //Items = new ObservableCollection<Item>();
            Items.Clear();
            foreach (var i in Enumerable.Range(0, itemCount))
            {
                Items.Add(new Item((ushort)i, data[i]));
            }
        }

        public List<byte> getData()
        {
            List<byte> data = new List<byte>();
            foreach (var i in Enumerable.Range(0, itemCount))
            {
                data.Add(Items[i].Amount);
            }
            return data;
        }


        public class Item
        {
            public ushort Pos { get; set; }
            public byte Amount { get; set; }
            public string Name
            {
                get
                {
                    return DebugInventory.getValue(Pos);
                }
            }
            public Item(ushort pos, byte amount)
            {
                Pos = pos;
                Amount = amount;
            }
        }
    }
}
