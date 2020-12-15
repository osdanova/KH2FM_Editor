using KH2FM_Editor.Model.Bar;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        public BarPage(String parentName, String filepath)
        {
            Console.WriteLine("DEBUG > BarPage > Filepath: " + filepath);
            handler = new BarPageHandler(parentName, filepath);
            DataContext = handler;

            if (parentName != null) hideExportForSubfile();

            InitializeComponent();
        }
        public BarPage(String parentName, BarFile file)
        {
            Console.WriteLine("DEBUG > BarPage > Subfile: " + file.Name);
            handler = new BarPageHandler(parentName, file);
            DataContext = handler;

            if (parentName != null) hideExportForSubfile();

            InitializeComponent();
        }

        public void hideExportForSubfile()
        {
            if(barActions != null)
            barActions.Visibility = System.Windows.Visibility.Collapsed;
        }

        public void btn_export(object sender, RoutedEventArgs e)
        {
            handler.act_export();
        }

        public void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            handler.loadFile(load_frame, (((ListViewItem)sender).Content as BarItem));
        }

        public void btn_testData(object sender, RoutedEventArgs e)
        {
            handler.act_testData();
        }
    }
}
