using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KH2FM_Editor.View.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void fileTreeview_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                MainWindowHandler.loadTreeView(fileTreeview, files[0]);
            }
        }

        private void OnItemMouseDoubleClick(object sender, MouseButtonEventArgs args)
        {
            // Makes sure the code only executes once
            if (sender is TreeViewItem) {
                if (!((TreeViewItem)sender).IsSelected) {
                    return;
                }
            }
            MainWindowHandler.loadFile(load_frame, fileTreeview.SelectedItem);
        }

        private void menuDebugBreakpoint(object sender, EventArgs e)
        {
            Console.WriteLine("MENU >>> DEBUG >>> BREAKPOINT");
        }

    }
}
