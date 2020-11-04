using KH2FM_Editor.Model.System03.Cmd;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Cmd
{
    /// <summary>
    /// Interaction logic for CmdPage.xaml
    /// </summary>
    public partial class CmdPage : Page
    {
        CmdPageHandler handler;

        public CmdPage()
        {
            InitializeComponent();
        }
        public CmdPage(CmdFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new CmdPageHandler(file);
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
