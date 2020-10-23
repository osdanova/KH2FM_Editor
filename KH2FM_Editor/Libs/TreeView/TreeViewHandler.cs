using System;
using System.IO;

namespace KH2FM_Editor.Libs.TreeView
{
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
            SimpleFileNode fileTreeNode = new SimpleFileNode();
            fileTreeNode.path = path;
            fileTreeNode.Name = Path.GetFileName(path);
            fileTreeNode.isDirectory = isDirectory(path);

            // CHILDREN
            if (fileTreeNode.isDirectory)
            {
                // DIRECTORIES
                foreach (String childDir in Directory.GetDirectories(path))
                {
                    fileTreeNode.children.Add(loadFileTreeNode(childDir));
                }
                // FILES
                foreach (String childFile in Directory.GetFiles(path))
                {
                    fileTreeNode.children.Add(loadFileTreeNode(childFile));
                }
            }

            return fileTreeNode;
        }

        // Returns true if the path given is from a directory
        public static Boolean isDirectory(string path)
        {
            FileAttributes attr = File.GetAttributes(path);
            if (attr.HasFlag(FileAttributes.Directory))
                return true;
            else
                return false;
        }
    }
    
}
