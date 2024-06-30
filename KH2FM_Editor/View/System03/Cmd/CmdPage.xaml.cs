using KH2FM_Editor.Model.System03.Cmd;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.System03.Cmd
{
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
        public void btn_search(object sender, RoutedEventArgs e)
        {
            handler.act_search();
        }

        public void AddEntry(object sender, RoutedEventArgs e)
        {
            if (CmdGrid.SelectedItem != null)
            {
                handler.CmdFileItems.Add(new CmdItem());
                handler.act_search();
            }
        }
        public void RemoveEntry(object sender, RoutedEventArgs e)
        {
            if (CmdGrid.SelectedItem != null)
            {
                CmdItem item = (CmdItem)CmdGrid.SelectedItem;
                handler.CmdFileItems.Remove(item);
                handler.act_search();
            }
        }
    }
}
