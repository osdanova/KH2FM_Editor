using System;
using System.Collections.ObjectModel;
using System.IO;

namespace KH2FM_Editor.Libs.TreeView
{
    // Simple data for a directory or file
    class SimpleFileNode
    {
        public String Name { get; set; }
        public String FilePath { get; set; }
        public Boolean IsDirectory { get; set; }
        public ObservableCollection<SimpleFileNode> Children { get; set; }

        public SimpleFileNode() { }
        public SimpleFileNode(String path)
        {
            FilePath = path;
            Name = Path.GetFileName(path);
            IsDirectory = checkIsDirectory(path);
            this.Children = new ObservableCollection<SimpleFileNode>();
        }

        // Returns true if the given path is from a directory
        public static Boolean checkIsDirectory(string path)
        {
            FileAttributes attr = File.GetAttributes(path);
            if (attr.HasFlag(FileAttributes.Directory))
                return true;
            else
                return false;
        }
    }
}
