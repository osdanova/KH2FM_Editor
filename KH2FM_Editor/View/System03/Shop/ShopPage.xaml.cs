using KH2FM_Editor.Model.System03.Shop;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Shop
{
    /// <summary>
    /// Interaction logic for ShopPage.xaml
    /// </summary>
    public partial class ShopPage : Page
    {
        ShopPageHandler handler;

        public ShopPage()
        {
            InitializeComponent();
        }
        public ShopPage(ShopFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new ShopPageHandler(file);
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
