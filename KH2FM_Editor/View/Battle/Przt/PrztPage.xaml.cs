using KH2FM_Editor.Model.Battle.Przt;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Przt
{
    /// <summary>
    /// Interaction logic for PrztPage.xaml
    /// </summary>
    public partial class PrztPage : Page
    {
        PrztPageHandler handler;

        public PrztPage()
        {
            InitializeComponent();
        }
        public PrztPage(PrztFile file)
        {
            //Console.WriteLine("DEBUG > PrztPage > Filepath: " + filepath);
            handler = new PrztPageHandler(file);
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
            if (PrztGrid.SelectedItem != null)
            {
                handler.PrztFileItems.Add(new PrztItem());
                handler.act_search();
            }
        }
        public void RemoveEntry(object sender, RoutedEventArgs e)
        {
            if (PrztGrid.SelectedItem != null)
            {
                PrztItem item = (PrztItem)PrztGrid.SelectedItem;
                handler.PrztFileItems.Remove(item);
                handler.act_search();
            }
        }
    }
}
