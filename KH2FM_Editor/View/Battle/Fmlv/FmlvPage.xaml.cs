using KH2FM_Editor.Model.Battle.Fmlv;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Fmlv
{
    /// <summary>
    /// Interaction logic for FmlvPage.xaml
    /// </summary>
    public partial class FmlvPage : Page
    {
        FmlvPageHandler handler;

        public FmlvPage()
        {
            InitializeComponent();
        }
        public FmlvPage(FmlvFile file)
        {
            //Console.WriteLine("DEBUG > FmlvPage > Filepath: " + filepath);
            handler = new FmlvPageHandler(file);
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
