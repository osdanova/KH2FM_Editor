using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.DebugView.Stats
{
    /// <summary>
    /// Interaction logic for StatsPage.xaml
    /// </summary>
    public partial class StatsPage : Page
    {
        StatsPageHandler handler;

        public StatsPage()
        {
            //Console.WriteLine("DEBUG > InventoryPage > Filepath: " + filepath);
            handler = new StatsPageHandler();
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
    }
}
