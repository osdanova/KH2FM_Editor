using KH2FM_Editor.Model.Battle.Stop;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Stop
{
    /// <summary>
    /// Interaction logic for StopPage.xaml
    /// </summary>
    public partial class StopPage : Page
    {
        StopPageHandler handler;

        public StopPage()
        {
            InitializeComponent();
        }
        public StopPage(StopFile file)
        {
            //Console.WriteLine("DEBUG > StopPage > Filepath: " + filepath);
            handler = new StopPageHandler(file);
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
