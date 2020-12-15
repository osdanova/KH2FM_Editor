using KH2FM_Editor.Model.System03.Pref.Plyr;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Plyr
{
    /// <summary>
    /// Interaction logic for PlyrPage.xaml
    /// </summary>
    public partial class PlyrPage : Page
    {
        PlyrPageHandler handler;

        public PlyrPage()
        {
            InitializeComponent();
        }
        public PlyrPage(PlyrFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new PlyrPageHandler(file);
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
