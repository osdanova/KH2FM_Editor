using KH2FM_Editor.Model.Mixdata.Reci;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Mixdata.Reci
{
    /// <summary>
    /// Interaction logic for LevePage.xaml
    /// </summary>
    public partial class ReciPage : Page
    {
        ReciPageHandler handler;

        public ReciPage()
        {
            InitializeComponent();
        }
        public ReciPage(ReciFile file)
        {
            handler = new ReciPageHandler(file);
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
