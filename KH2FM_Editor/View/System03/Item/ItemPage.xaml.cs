using KH2FM_Editor.Model.System03.Item;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Item
{
    public partial class ItemPage : Page
    {
        ItemPageHandler handler;

        public ItemPage()
        {
            InitializeComponent();
        }
        public ItemPage(ItemFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new ItemPageHandler(file);
            DataContext = handler;

            InitializeComponent();
        }

        public void btn_testData(object sender, RoutedEventArgs e)
        {
            handler.act_testData();
        }

        public void btn_save(object sender, RoutedEventArgs e)
        {
            handler.act_save();
        }
        public void btn_search(object sender, RoutedEventArgs e)
        {
            handler.act_search();
        }

        public void AddItemEntry(object sender, RoutedEventArgs e)
        {
            if (ItemGrid.SelectedItem != null)
            {
                handler.ItemFileItems.Add(new ItemItem());
                handler.act_search();
            }
        }
        public void RemoveItemEntry(object sender, RoutedEventArgs e)
        {
            if (ItemGrid.SelectedItem != null)
            {
                ItemItem item = (ItemItem)ItemGrid.SelectedItem;
                handler.ItemFileItems.Remove(item);
                handler.act_search();
            }
        }

        public void AddEquipmentEntry(object sender, RoutedEventArgs e)
        {
            if (EquipmentGrid.SelectedItem != null)
            {
                handler.ItemFileEquipment.Add(new EquipmentItem());
                handler.act_search();
            }
        }
        public void RemoveEquipmentEntry(object sender, RoutedEventArgs e)
        {
            if (EquipmentGrid.SelectedItem != null)
            {
                EquipmentItem item = (EquipmentItem)EquipmentGrid.SelectedItem;
                handler.ItemFileEquipment.Remove(item);
                handler.act_search();
            }
        }
    }
}
