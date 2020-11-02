using KH2FM_Editor.Model.Battle.Lvpm;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Lvpm
{
    /// <summary>
    /// Interaction logic for LvpmPage.xaml
    /// </summary>
    public partial class LvpmPage : Page
    {
        LvpmPageHandler handler;

        public LvpmPage()
        {
            InitializeComponent();
        }
        public LvpmPage(LvpmFile file)
        {
            //Console.WriteLine("DEBUG > LvpmPage > Filepath: " + filepath);
            handler = new LvpmPageHandler(file);
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
