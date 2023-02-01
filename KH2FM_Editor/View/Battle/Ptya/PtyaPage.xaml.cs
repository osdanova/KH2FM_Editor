using KH2FM_Editor.Model.Battle.Ptya;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        // Move the selected entry above or below
        public void key_up(object sender,KeyEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;

            TabControl mtc = (TabControl)this.FindName("MyTabControl");
            int selectedSet = mtc.SelectedIndex;

            PtyaSet set = handler.PtyaFileLoaded.PtyaSets[selectedSet];

            int selectedRow = dg.SelectedIndex;
            if (e.Key == Key.Up)
            {
                if (selectedRow < 0 || selectedRow >= set.Entries.Count - 1)
                {
                    return;
                }
                selectedRow++;
            }
            else if (e.Key == Key.Down)
            {
                if (selectedRow >= set.Entries.Count)
                {
                    return;
                }
                selectedRow--;
            }

            PtyaItem item = set.Entries[selectedRow];
            if (e.Key == Key.Up)
            {
                set.Entries.Move(selectedRow, selectedRow - 1);
                dg.SelectedIndex--;
                dg.CurrentItem = item;
                dg.SelectedItem = item;
            }
            else if(e.Key == Key.Down)
            {
                set.Entries.Move(selectedRow, selectedRow + 1);
                dg.SelectedIndex++;
                dg.CurrentItem = item;
                dg.SelectedItem = item;
            }
        }
    }
}
