using KH2FM_Editor.Model.System03.Evtp;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Evtp
{
    /// <summary>
    /// Interaction logic for EvtpPage.xaml
    /// </summary>
    public partial class EvtpPage : Page
    {
        EvtpPageHandler handler;

        public EvtpPage()
        {
            InitializeComponent();
        }
        public EvtpPage(EvtpFile file)
        {
            //Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new EvtpPageHandler(file);
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
