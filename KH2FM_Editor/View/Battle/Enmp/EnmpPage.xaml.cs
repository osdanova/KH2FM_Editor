using KH2FM_Editor.Model.Battle.Enmp;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Enmp
{
    /// <summary>
    /// Interaction logic for EnmpPage.xaml
    /// </summary>
    public partial class EnmpPage : Page
    {
        EnmpPageHandler handler;

        public EnmpPage()
        {
            InitializeComponent();
        }
        public EnmpPage(EnmpFile file)
        {
            //Console.WriteLine("DEBUG > EnmpPage > Filepath: " + filepath);
            handler = new EnmpPageHandler(file);
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
            if (EnmpGrid.SelectedItem != null)
            {
                handler.EnmpFileItems.Add(new EnmpItem());
                handler.act_search();
            }
        }
        public void RemoveEntry(object sender, RoutedEventArgs e)
        {
            if (EnmpGrid.SelectedItem != null)
            {
                EnmpItem item = (EnmpItem)EnmpGrid.SelectedItem;
                handler.EnmpFileItems.Remove(item);
                handler.act_search();
            }
        }
    }
}
