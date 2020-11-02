using KH2FM_Editor.Model.Jiminy.Puzz;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Jiminy.Puzz
{
    /// <summary>
    /// Interaction logic for PuzzPage.xaml
    /// </summary>
    public partial class PuzzPage : Page
    {
        PuzzPageHandler handler;

        public PuzzPage()
        {
            InitializeComponent();
        }
        public PuzzPage(PuzzFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new PuzzPageHandler(file);
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
