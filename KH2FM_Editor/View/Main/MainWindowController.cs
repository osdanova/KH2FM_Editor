using KH2FM_Editor.Libs.TreeView;
using KH2FM_Editor.View.Objentry;
using System;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Main
{
    class MainWindowController
    {
        // Clears the treeview and loads a new one given the root path
        public static void loadTreeView(TreeView fileTreeview, string filePath)
        {
            fileTreeview.Items.Clear();
            TreeViewHandler.loadFileTree(filePath);
            fileTreeview.Items.Add(TreeViewHandler.fileTreeRoot);
        }

        // Given a SimpleFileNode object, loads the file
        public static void loadFile(Frame loadFrame,  object file)
        {
            //FileHandler fh = new FileHandler();
            //fh.processFile((file as SimpleFileNode).path);
            Console.WriteLine("DEBUG >>> raw Object: " + file);
            Console.WriteLine("DEBUG >>> filename: " + (file as SimpleFileNode).Name);
            Console.WriteLine("DEBUG >>> path: " + (file as SimpleFileNode).path);

            // TEST OBJENTRY
            //loadFrame.Content = new ObjentryPage((file as SimpleFileNode).path);
            loadFrame.Navigate(new ObjentryPage((file as SimpleFileNode).path));
            Console.WriteLine("DEBUG >>> raw Object: " + file);
        }
    }
}
