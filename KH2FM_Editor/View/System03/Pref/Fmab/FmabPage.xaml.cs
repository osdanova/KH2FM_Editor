using KH2FM_Editor.Model.System03.Pref.Fmab;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Fmab
{
    /// <summary>
    /// Interaction logic for FmabPage.xaml
    /// </summary>
    public partial class FmabPage : Page
    {
        FmabPageHandler handler;

        public FmabPage()
        {
            InitializeComponent();
        }
        public FmabPage(FmabFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new FmabPageHandler(file);
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
