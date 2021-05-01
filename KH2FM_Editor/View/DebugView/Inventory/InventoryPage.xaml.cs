using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.DebugView.Inventory
{
    /// <summary>
    /// Interaction logic for InventoryPage.xaml
    /// </summary>
    public partial class InventoryPage : Page
    {
        InventoryPageHandler handler;

        public InventoryPage()
        {
            //Console.WriteLine("DEBUG > InventoryPage > Filepath: " + filepath);
            handler = new InventoryPageHandler();
            DataContext = handler;

            InitializeComponent();
        }

        public void btn_read(object sender, RoutedEventArgs e)
        {
            handler.act_read();
        }

        public void btn_write(object sender, RoutedEventArgs e)
        {
            handler.act_write();
        }

        public void btn_filter(object sender, RoutedEventArgs e)
        {
            handler.act_filter();
        }
    }
}
