using KH2FM_Editor.Model.Mixdata.Leve;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Mixdata.Leve
{
    /// <summary>
    /// Interaction logic for LevePage.xaml
    /// </summary>
    public partial class LevePage : Page
    {
        LevePageHandler handler;

        public LevePage()
        {
            InitializeComponent();
        }
        public LevePage(LeveFile file)
        {
            handler = new LevePageHandler(file);
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
