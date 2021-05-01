using KH2FM_Editor.Libs.FileHandler;
using KH2FM_Editor.Libs.TreeView;
using KH2FM_Editor.View.About;
using KH2FM_Editor.View.Bar;
using KH2FM_Editor.View.DebugView.Abilities;
using KH2FM_Editor.View.DebugView.Inventory;
using KH2FM_Editor.View.DebugView.Stats;
using KH2FM_Editor.View.Objentry;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Main
{
    class MainWindowHandler
    {
        // Clears the treeview and loads a new one given the root path
        public static void loadTreeView(TreeView fileTreeview, string filePath)
        {
            fileTreeview.Items.Clear();
            TreeViewHandler.loadFileTree(filePath);
            fileTreeview.Items.Add(TreeViewHandler.fileTreeRoot);
        }

        // Opens the specified file
        public static void openPage(Frame loadFrame, string page)
        {
            switch (page)
            {
                case "Inventory":
                    loadFrame.Navigate(new InventoryPage());
                    break;
                case "Stats":
                    loadFrame.Navigate(new StatsPage());
                    break;
                case "Abilities":
                    loadFrame.Navigate(new AbilitiesPage());
                    break;
                case "About":
                    loadFrame.Navigate(new AboutPage());
                    break;
            }
        }


        // Given a SimpleFileNode object, loads the file
        public static void loadFile(Frame loadFrame,  object file)
        {
            switch(FileHandler.getFileType((file as SimpleFileNode).Name))
            {
                case FileTypesEnum.OBJENTRY:
                    loadFrame.Navigate(new ObjentryPage((file as SimpleFileNode).FilePath));
                    break;
                case FileTypesEnum.MIXDATA:
                    loadFrame.Navigate(new BarPage(null, (file as SimpleFileNode).FilePath));
                    break;
                case FileTypesEnum.JIMINY:
                    loadFrame.Navigate(new BarPage(null, (file as SimpleFileNode).FilePath));
                    break;
                case FileTypesEnum.BATTLE:
                    loadFrame.Navigate(new BarPage(null, (file as SimpleFileNode).FilePath));
                    break;
                case FileTypesEnum.SYSTEM:
                    loadFrame.Navigate(new BarPage(null, (file as SimpleFileNode).FilePath));
                    break;
                case FileTypesEnum.ARD:
                    loadFrame.Navigate(new BarPage(null, (file as SimpleFileNode).FilePath));
                    break;
                default:
                    break;
            }
        }
    }
}