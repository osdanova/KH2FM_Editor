using KH2FM_Editor.Model.System03.Rcct;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Rcct
{
    /// <summary>
    /// Interaction logic for RcctPage.xaml
    /// </summary>
    public partial class RcctPage : Page
    {
        RcctPageHandler handler;

        public RcctPage()
        {
            InitializeComponent();
        }
        public RcctPage(RcctFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new RcctPageHandler(file);
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
