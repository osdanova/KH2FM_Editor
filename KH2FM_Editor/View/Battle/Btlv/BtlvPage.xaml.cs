using KH2FM_Editor.Model.Battle.Btlv;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Btlv
{
    /// <summary>
    /// Interaction logic for BtlvPage.xaml
    /// </summary>
    public partial class BtlvPage : Page
    {
        BtlvPageHandler handler;

        public BtlvPage()
        {
            InitializeComponent();
        }
        public BtlvPage(BtlvFile file)
        {
            //Console.WriteLine("DEBUG > BtlvPage > Filepath: " + filepath);
            handler = new BtlvPageHandler(file);
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
