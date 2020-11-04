using KH2FM_Editor.Model.System03.Wmst;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Wmst
{
    /// <summary>
    /// Interaction logic for WmstPage.xaml
    /// </summary>
    public partial class WmstPage : Page
    {
        WmstPageHandler handler;

        public WmstPage()
        {
            InitializeComponent();
        }
        public WmstPage(WmstFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new WmstPageHandler(file);
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
