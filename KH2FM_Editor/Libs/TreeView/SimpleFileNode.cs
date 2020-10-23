using System;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.Libs.TreeView
{
    // Simple data for a directory or file
    class SimpleFileNode
    {
        public String Name { get; set; }
        public String path;
        public Boolean isDirectory;
        public ObservableCollection<SimpleFileNode> children { get; set; }

        public SimpleFileNode()
        {
            this.children = new ObservableCollection<SimpleFileNode>();
        }


    }
}
