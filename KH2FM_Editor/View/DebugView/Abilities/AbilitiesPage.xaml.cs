using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.DebugView.Abilities
{
    /// <summary>
    /// Interaction logic for InventoryPage.xaml
    /// </summary>
    public partial class AbilitiesPage : Page
    {
        public AbilitiesPageHandler handler { get; set; }

        public AbilitiesPage()
        {
            //Console.WriteLine("DEBUG > InventoryPage > Filepath: " + filepath);
            handler = new AbilitiesPageHandler();
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
