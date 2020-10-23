using KH2FM_Editor_WPF.FileTypes.GENERIC;
using KH2FM_Editor_WPF.FileTypes.Objentry;
using System;
using System.Collections.ObjectModel;
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
            Console.WriteLine("DEBUG > ObjentryPage > Objentry file page");
            Console.WriteLine("DEBUG > ObjentryPage > Filepath: " + filepath);
            handler = new ObjentryPageHandler(filepath);
            DataContext = handler;

            InitializeComponent();
        }

        public void btn_testData(object sender, RoutedEventArgs e)
        {
            handler.testData();
        }

        public void btn_search(object sender, RoutedEventArgs e)
        {
            handler.search();
        }
    }
}
