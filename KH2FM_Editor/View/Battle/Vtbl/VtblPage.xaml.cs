using KH2FM_Editor.Model.Battle.Vtbl;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Vtbl
{
    /// <summary>
    /// Interaction logic for VtblPage.xaml
    /// </summary>
    public partial class VtblPage : Page
    {
        VtblPageHandler handler;

        public VtblPage()
        {
            InitializeComponent();
        }
        public VtblPage(VtblFile file)
        {
            //Console.WriteLine("DEBUG > VtblPage > Filepath: " + filepath);
            handler = new VtblPageHandler(file);
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
