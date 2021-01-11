using KH2FM_Editor.Model.Battle.Ptya;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Ptya
{
    /// <summary>
    /// Interaction logic for PtyaPage.xaml
    /// </summary>
    public partial class PtyaPage : Page
    {
        PtyaPageHandler handler;

        public PtyaPage()
        {
            InitializeComponent();
        }
        public PtyaPage(PtyaFile file)
        {
            //Console.WriteLine("DEBUG > PtyaPage > Filepath: " + filepath);
            handler = new PtyaPageHandler(file);
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
