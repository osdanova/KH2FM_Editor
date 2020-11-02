using KH2FM_Editor.Model.Battle.Patn;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Patn
{
    /// <summary>
    /// Interaction logic for PatnPage.xaml
    /// </summary>
    public partial class PatnPage : Page
    {
        PatnPageHandler handler;

        public PatnPage()
        {
            InitializeComponent();
        }
        public PatnPage(PatnFile file)
        {
            //Console.WriteLine("DEBUG > PatnPage > Filepath: " + filepath);
            handler = new PatnPageHandler(file);
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
