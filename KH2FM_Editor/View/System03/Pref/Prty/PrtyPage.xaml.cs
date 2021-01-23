using KH2FM_Editor.Model.System03.Pref.Prty;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Prty
{
    /// <summary>
    /// Interaction logic for PrtyPage.xaml
    /// </summary>
    public partial class PrtyPage : Page
    {
        PrtyPageHandler handler;

        public PrtyPage()
        {
            InitializeComponent();
        }
        public PrtyPage(PrtyFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new PrtyPageHandler(file);
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
