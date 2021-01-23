using KH2FM_Editor.Model.System03.Pref.Sstm;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Sstm
{
    /// <summary>
    /// Interaction logic for SstmPage.xaml
    /// </summary>
    public partial class SstmPage : Page
    {
        SstmPageHandler handler;

        public SstmPage()
        {
            InitializeComponent();
        }
        public SstmPage(SstmFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new SstmPageHandler(file);
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
