using System;
using System.Windows;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Objentry
{
    /// <summary>
    /// Interaction logic for ObjentryPage.xaml
    /// </summary>
    public partial class ObjentryPage : Page
    {
        ObjentryPageHandler handler;

        public ObjentryPage()
        {
            InitializeComponent();
        }
        public ObjentryPage(String filepath)
        {
            Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new ObjentryPageHandler(filepath);
            DataContext = handler;

            InitializeComponent();
        }

        public void btn_testData(object sender, RoutedEventArgs e)
        {
            handler.act_testData();
        }

        public void btn_search(object sender, RoutedEventArgs e)
        {
            handler.act_search();
        }

        public void btn_save(object sender, RoutedEventArgs e)
        {
            handler.act_save();
        }

        public void btn_export(object sender, RoutedEventArgs e)
        {
            handler.act_export();
        }
    }
}
