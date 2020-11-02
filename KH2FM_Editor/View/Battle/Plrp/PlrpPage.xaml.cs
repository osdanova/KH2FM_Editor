using KH2FM_Editor.Model.Battle.Plrp;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Plrp
{
    /// <summary>
    /// Interaction logic for PlrpPage.xaml
    /// </summary>
    public partial class PlrpPage : Page
    {
        PlrpPageHandler handler;

        public PlrpPage()
        {
            InitializeComponent();
        }
        public PlrpPage(PlrpFile file)
        {
            //Console.WriteLine("DEBUG > PlrpPage > Filepath: " + filepath);
            handler = new PlrpPageHandler(file);
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
