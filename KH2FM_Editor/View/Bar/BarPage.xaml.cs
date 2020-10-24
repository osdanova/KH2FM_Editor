using System;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Bar
{
    /// <summary>
    /// Interaction logic for BarPage.xaml
    /// </summary>
    public partial class BarPage : Page
    {
        BarPageHandler handler;

        public BarPage()
        {
            InitializeComponent();
        }
        public BarPage(String filepath)
        {
            Console.WriteLine("DEBUG > BarPage > Filepath: " + filepath);
            handler = new BarPageHandler(filepath);
            DataContext = handler;

            InitializeComponent();
        }
    }
}
