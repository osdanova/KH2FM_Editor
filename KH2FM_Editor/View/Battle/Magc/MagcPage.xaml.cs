using KH2FM_Editor.Model.Battle.Magc;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Magc
{
    /// <summary>
    /// Interaction logic for MagcPage.xaml
    /// </summary>
    public partial class MagcPage : Page
    {
        MagcPageHandler handler;

        public MagcPage()
        {
            InitializeComponent();
        }
        public MagcPage(MagcFile file)
        {
            //Console.WriteLine("DEBUG > MagcPage > Filepath: " + filepath);
            handler = new MagcPageHandler(file);
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
