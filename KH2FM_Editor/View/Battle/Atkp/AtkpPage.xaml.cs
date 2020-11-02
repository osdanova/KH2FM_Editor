using KH2FM_Editor.Model.Battle.Atkp;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Atkp
{
    /// <summary>
    /// Interaction logic for AtkpPage.xaml
    /// </summary>
    public partial class AtkpPage : Page
    {
        AtkpPageHandler handler;

        public AtkpPage()
        {
            InitializeComponent();
        }
        public AtkpPage(AtkpFile file)
        {
            //Console.WriteLine("DEBUG > AtkpPage > Filepath: " + filepath);
            handler = new AtkpPageHandler(file);
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
