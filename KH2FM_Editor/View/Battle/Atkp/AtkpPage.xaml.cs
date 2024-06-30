using KH2FM_Editor.Model.Battle.Atkp;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Battle.Atkp
{
    public partial class AtkpPage : Page
    {
        AtkpPageHandler handler {  get; set; }

        public AtkpPage()
        {
            InitializeComponent();
        }
        public AtkpPage(AtkpFile file)
        {
            InitializeComponent();
            //Console.WriteLine("DEBUG > AtkpPage > Filepath: " + filepath);
            handler = new AtkpPageHandler(file);
            DataContext = handler;
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
            if (AtkpGrid.SelectedItem != null)
            {
                handler.AtkpFileItems.Add(new AtkpItem());
                handler.act_search();
            }
        }
        public void RemoveEntry(object sender, RoutedEventArgs e)
        {
            if (AtkpGrid.SelectedItem != null)
            {
                AtkpItem item = (AtkpItem)AtkpGrid.SelectedItem;
                handler.AtkpFileItems.Remove(item);
                handler.act_search();
            }
        }
    }
}
