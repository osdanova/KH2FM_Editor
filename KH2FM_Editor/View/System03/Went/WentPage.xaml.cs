using KH2FM_Editor.Model.System03.Went;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Went
{
    /// <summary>
    /// Interaction logic for WentPage.xaml
    /// </summary>
    public partial class WentPage : Page
    {
        WentPageHandler handler;

        public WentPage()
        {
            InitializeComponent();
        }
        public WentPage(WentFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new WentPageHandler(file);
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
