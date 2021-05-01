using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Model.DEBUG;
using System;
using System.Collections.ObjectModel;
using static KH2FM_Editor.Model.DEBUG.InventoryFile;

namespace KH2FM_Editor.View.DebugView.Inventory
{
    class InventoryPageHandler
    {
        // DATA
        public InventoryFile InventoryFileLoaded { get; set; }
        public ObservableCollection<Item> InventoryFileItems { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }
        public string ItemCount { get; set; }
        public string NameFilter { get; set; }

        public InventoryPageHandler()
        {
            Pcsx2Memory.findProcess();
            if (Pcsx2Memory.process_current_Type == Enum.ProcessType.PCSX2)
            {
                MemOffset = "2032F0B0";
            }
            else if (Pcsx2Memory.process_current_Type == Enum.ProcessType.EGS)
            {
                MemOffset = (Pcsx2Memory.startingAddressEGS + 0x9AA5F0).ToString("X12");
            }

            ItemCount = "312";
            NameFilter = "";
            InventoryFileItems = new ObservableCollection<Item>();
            Console.WriteLine("DEBUG > InventoryPageHandler > Processing file...");
            InventoryFileLoaded = new InventoryFile();
            loadList();
            Console.WriteLine("DEBUG > InventoryPageHandler > File processed!");
        }

        public void loadList()
        {
            InventoryFileItems.Clear();
            if (NameFilter != "")
            {
                foreach(Item item in InventoryFileLoaded.Items)
                {
                    if (item.Name.Contains(NameFilter)) InventoryFileItems.Add(item);
                }
            }
            else
            {
                foreach (Item item in InventoryFileLoaded.Items)
                {
                    InventoryFileItems.Add(item);
                }
            }
        }

        public void act_read()
        {
            if (InventoryFileLoaded == null) return;
            Console.WriteLine("DEBUG > InventoryPageHandler > Reading...");
            InventoryFileLoaded.readData(Pcsx2Memory.readPcsx2(long.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), Int32.Parse(ItemCount)), Int32.Parse(ItemCount));
            loadList();
            Console.WriteLine("DEBUG > InventoryPageHandler > Finished reading!");
        }

        public void act_write()
        {
            Console.WriteLine("DEBUG > InventoryPageHandler > Writing to Pcsx2...");
            Pcsx2Memory.writePcsx2(long.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), Int32.Parse(ItemCount), InventoryFileLoaded.getData());
            Console.WriteLine("DEBUG > InventoryPageHandler > Finished writing!");
        }

        public void act_filter()
        {
            Console.WriteLine("DEBUG > InventoryPageHandler > Filtering...");
            loadList();
            Console.WriteLine("DEBUG > InventoryPageHandler > Finished filtering!");
        }
    }
}
