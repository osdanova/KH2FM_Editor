using KH2FM_Editor.Model.Jiminy.Worl;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Jiminy.Worl
{
    /// <summary>
    /// Interaction logic for WorlPage.xaml
    /// </summary>
    public partial class WorlPage : Page
    {
        WorlPageHandler handler;

        public WorlPage()
        {
            InitializeComponent();
        }
        public WorlPage(WorlFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new WorlPageHandler(file);
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
