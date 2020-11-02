using KH2FM_Editor.Model.Battle.Sumn;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Sumn
{
    /// <summary>
    /// Interaction logic for SumnPage.xaml
    /// </summary>
    public partial class SumnPage : Page
    {
        SumnPageHandler handler;

        public SumnPage()
        {
            InitializeComponent();
        }
        public SumnPage(SumnFile file)
        {
            //Console.WriteLine("DEBUG > SumnPage > Filepath: " + filepath);
            handler = new SumnPageHandler(file);
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
