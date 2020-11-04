using KH2FM_Editor.Model.System03.Item;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Item
{
    /// <summary>
    /// Interaction logic for ItemPage.xaml
    /// </summary>
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
    }
}
