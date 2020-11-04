using KH2FM_Editor.Model.System03.Trsr;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Trsr
{
    /// <summary>
    /// Interaction logic for TrsrPage.xaml
    /// </summary>
    public partial class TrsrPage : Page
    {
        TrsrPageHandler handler;

        public TrsrPage()
        {
            InitializeComponent();
        }
        public TrsrPage(TrsrFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new TrsrPageHandler(file);
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
