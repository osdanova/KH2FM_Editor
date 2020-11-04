using KH2FM_Editor.Model.System03.Sklt;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Sklt
{
    /// <summary>
    /// Interaction logic for SkltPage.xaml
    /// </summary>
    public partial class SkltPage : Page
    {
        SkltPageHandler handler;

        public SkltPage()
        {
            InitializeComponent();
        }
        public SkltPage(SkltFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new SkltPageHandler(file);
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
