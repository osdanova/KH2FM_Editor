using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KH2FM_Editor.Enum;
using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Libs.Utils;

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

        // Filetree
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

        // Tools
        private void tool_Inventory(object sender, EventArgs e)
        {
            MainWindowHandler.openPage(load_frame, "Inventory");
        }
        private void tool_Stats(object sender, EventArgs e)
        {
            MainWindowHandler.openPage(load_frame, "Stats");
        }
        private void tool_Abilities(object sender, EventArgs e)
        {
            MainWindowHandler.openPage(load_frame, "Abilities");
        }
        private void about_Open(object sender, EventArgs e)
        {
            MainWindowHandler.openPage(load_frame, "About");
        }

        // Debug
        private void menuDebugBreakpoint(object sender, EventArgs e)
        {
            Console.WriteLine("MENU >>> DEBUG >>> BREAKPOINT");
        }
        private void findPCSX2(object sender, EventArgs e)
        {
            Pcsx2Memory.findPCSX2();
        }
        private void findKH1(object sender, EventArgs e)
        {
            Pcsx2Memory.findKH1();
        }
        private void findKH2(object sender, EventArgs e)
        {
            Pcsx2Memory.findKH2();
        }
        private void findKH3(object sender, EventArgs e)
        {
            Pcsx2Memory.findKH3();
        }
        private void findKHProcesses(object sender, EventArgs e)
        {
            Pcsx2Memory.findProcessContainingString("KINGDOM");
        }
        private void findFileOffset(object sender, EventArgs e)
        {
            Console.WriteLine("DEBUG > 03system Offset: " + FormatHandler.getHexString(Pcsx2Memory.getFileOffset(Enum.FileType.KH2_03SYSTEM), ProcessType.PCSX2));
            //Console.WriteLine("DEBUG > 00battle Offset: " + Pcsx2Memory.getFileOffset(Enum.FileType.KH2_00BATTLE));
            //Console.WriteLine("DEBUG > 00objentry Offset: " + Pcsx2Memory.getFileOffset(Enum.FileType.KH2_00OBJENTRY));
            //Console.WriteLine("DEBUG > jiminy Offset: " + Pcsx2Memory.getFileOffset(Enum.FileType.KH2_JIMINY));
            //Console.WriteLine("DEBUG > mixdata Offset: " + Pcsx2Memory.getFileOffset(Enum.FileType.KH2_MIXDATA));
            //Console.WriteLine("DEBUG > SUBBAR: " + Pcsx2Memory.getOffsetOfSubBar(0x20000000 + Pcsx2Memory.getFileOffset(Enum.FileType.KH2_03SYSTEM), "cmd\0"));
            //Console.WriteLine("DEBUG > SUBSUBBAR: " + FormatHandler.getHexString(Pcsx2Memory.getAddressOfSubSubBar(Enum.FileType.KH2_03SYSTEM, "pref", "magi"), ProcessType.PCSX2));
        }

    }
}
