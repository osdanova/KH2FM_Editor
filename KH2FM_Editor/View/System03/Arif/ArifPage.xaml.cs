using KH2FM_Editor.Model.System03.Arif;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Arif
{
    /// <summary>
    /// Interaction logic for ArifPage.xaml
    /// </summary>
    public partial class ArifPage : Page
    {
        ArifPageHandler handler;

        public ArifPage()
        {
            InitializeComponent();
        }
        public ArifPage(ArifFile file)
        {
            //Console.WriteLine("DEBUG > ArifPage > Filepath: " + filepath);
            handler = new ArifPageHandler(file);
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
