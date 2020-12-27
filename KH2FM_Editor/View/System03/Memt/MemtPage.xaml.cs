using KH2FM_Editor.Model.System03.Memt;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Memt
{
    /// <summary>
    /// Interaction logic for MemtPage.xaml
    /// </summary>
    public partial class MemtPage : Page
    {
        MemtPageHandler handler;

        public MemtPage()
        {
            InitializeComponent();
        }
        public MemtPage(MemtFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new MemtPageHandler(file);
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
