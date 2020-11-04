using System;
using System.IO;

namespace KH2FM_Editor.Libs.TreeView
{
    /*
     * Loads the File tree given a folder or file
     */
    class TreeViewHandler
    {
        public static SimpleFileNode fileTreeRoot;

        // Loads the file tree of the given path to fileTreeRoot
        public static void loadFileTree(String rootPath)
        {
            // ROOT
            fileTreeRoot = loadFileTreeNode(rootPath);
        }

        // Returns a SimpleFileNode with all its children given the file/dir path
        public static SimpleFileNode loadFileTreeNode(String path)
        {
            SimpleFileNode fileTreeNode = new SimpleFileNode(path);

            //Console.WriteLine("TreeViewHandler > node: " + path);

            // CHILDREN
            if (fileTreeNode.IsDirectory)
            {
                // DIRECTORIES
                foreach (String childDir in Directory.GetDirectories(path))
                {
                    fileTreeNode.Children.Add(loadFileTreeNode(childDir));
                }
                // FILES
                foreach (String childFile in Directory.GetFiles(path))
                {
                    fileTreeNode.Children.Add(loadFileTreeNode(childFile));
                }
            }

            return fileTreeNode;
        }
    }
    
}
