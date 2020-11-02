using KH2FM_Editor.Model.Battle.Limt;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Limt
{
    /// <summary>
    /// Interaction logic for LimtPage.xaml
    /// </summary>
    public partial class LimtPage : Page
    {
        LimtPageHandler handler;

        public LimtPage()
        {
            InitializeComponent();
        }
        public LimtPage(LimtFile file)
        {
            //Console.WriteLine("DEBUG > LimtPage > Filepath: " + filepath);
            handler = new LimtPageHandler(file);
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
