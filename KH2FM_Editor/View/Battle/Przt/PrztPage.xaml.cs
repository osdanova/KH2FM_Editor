using KH2FM_Editor.Model.Battle.Przt;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Przt
{
    /// <summary>
    /// Interaction logic for PrztPage.xaml
    /// </summary>
    public partial class PrztPage : Page
    {
        PrztPageHandler handler;

        public PrztPage()
        {
            InitializeComponent();
        }
        public PrztPage(PrztFile file)
        {
            //Console.WriteLine("DEBUG > PrztPage > Filepath: " + filepath);
            handler = new PrztPageHandler(file);
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
    }
}
