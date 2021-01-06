using KH2FM_Editor.Model.Mixdata.Exp;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Mixdata.Exp
{
    /// <summary>
    /// Interaction logic for ExpPage.xaml
    /// </summary>
    public partial class ExpPage : Page
    {
        ExpPageHandler handler;

        public ExpPage()
        {
            InitializeComponent();
        }
        public ExpPage(ExpFile file)
        {
            handler = new ExpPageHandler(file);
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
