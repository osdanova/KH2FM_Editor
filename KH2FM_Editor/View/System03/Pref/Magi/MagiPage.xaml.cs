using KH2FM_Editor.Model.System03.Pref.Magi;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Magi
{
    /// <summary>
    /// Interaction logic for MagiPage.xaml
    /// </summary>
    public partial class MagiPage : Page
    {
        MagiPageHandler handler;

        public MagiPage()
        {
            InitializeComponent();
        }
        public MagiPage(MagiFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new MagiPageHandler(file);
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
