using KH2FM_Editor.Model.Ard.Spawn;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Ard.Spawn
{
    /// <summary>
    /// Interaction logic for ArdSpawnPage.xaml
    /// </summary>
    public partial class ArdSpawnPage : Page
    {
        ArdSpawnPageHandler handler;

        public ArdSpawnPage()
        {
            InitializeComponent();
        }
        public ArdSpawnPage(SpawnFile file)
        {
            //Console.WriteLine("DEBUG > ArdSpawnPage > Filepath: " + filepath);
            handler = new ArdSpawnPageHandler(file);
            DataContext = handler;

            InitializeComponent();
        }

        public void btn_testData(object sender, RoutedEventArgs e)
        {
            //handler.act_testData();
        }

        public void btn_save(object sender, RoutedEventArgs e)
        {
            //handler.act_save();
        }
    }
}
