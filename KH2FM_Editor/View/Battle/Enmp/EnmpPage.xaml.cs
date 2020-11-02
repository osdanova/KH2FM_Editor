using KH2FM_Editor.Model.Battle.Enmp;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Enmp
{
    /// <summary>
    /// Interaction logic for EnmpPage.xaml
    /// </summary>
    public partial class EnmpPage : Page
    {
        EnmpPageHandler handler;

        public EnmpPage()
        {
            InitializeComponent();
        }
        public EnmpPage(EnmpFile file)
        {
            //Console.WriteLine("DEBUG > EnmpPage > Filepath: " + filepath);
            handler = new EnmpPageHandler(file);
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
