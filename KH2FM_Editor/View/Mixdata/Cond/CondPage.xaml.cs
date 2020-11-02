using KH2FM_Editor.Model.Mixdata.Cond;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Mixdata.Cond
{
    /// <summary>
    /// Interaction logic for CondPage.xaml
    /// </summary>
    public partial class CondPage : Page
    {
        CondPageHandler handler;

        public CondPage()
        {
            InitializeComponent();
        }
        public CondPage(CondFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new CondPageHandler(file);
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
