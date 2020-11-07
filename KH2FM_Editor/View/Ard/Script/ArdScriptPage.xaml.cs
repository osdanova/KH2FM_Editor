using KH2FM_Editor.Model.Ard.Script;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Ard.Script
{
    /// <summary>
    /// Interaction logic for ArdScriptPage.xaml
    /// </summary>
    public partial class ArdScriptPage : Page
    {
        ArdScriptPageHandler handler;

        public ArdScriptPage()
        {
            InitializeComponent();
        }
        public ArdScriptPage(ArdScriptFile file)
        {
            //Console.WriteLine("DEBUG > ArdScriptPage > Filepath: " + filepath);
            handler = new ArdScriptPageHandler(file);
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
