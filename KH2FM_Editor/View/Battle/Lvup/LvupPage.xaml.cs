using KH2FM_Editor.Model.Battle.Lvup;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Lvup
{
    /// <summary>
    /// Interaction logic for LvupPage.xaml
    /// </summary>
    public partial class LvupPage : Page
    {
        LvupPageHandler handler;

        public LvupPage()
        {
            InitializeComponent();
        }
        public LvupPage(LvupFile file)
        {
            //Console.WriteLine("DEBUG > LvupPage > Filepath: " + filepath);
            handler = new LvupPageHandler(file);
            DataContext = handler;

            InitializeComponent();
        }

        public void btn_testData(object sender, RoutedEventArgs e)
        {
            //handler.act_testData();
        }

        public void btn_save(object sender, RoutedEventArgs e)
        {
            //handler.act_save();
        }
    }
}
