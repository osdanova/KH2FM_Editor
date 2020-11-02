using KH2FM_Editor.Model.Battle.Bons;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Bons
{
    /// <summary>
    /// Interaction logic for BonsPage.xaml
    /// </summary>
    public partial class BonsPage : Page
    {
        BonsPageHandler handler;

        public BonsPage()
        {
            InitializeComponent();
        }
        public BonsPage(BonsFile file)
        {
            //Console.WriteLine("DEBUG > BonsPage > Filepath: " + filepath);
            handler = new BonsPageHandler(file);
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
