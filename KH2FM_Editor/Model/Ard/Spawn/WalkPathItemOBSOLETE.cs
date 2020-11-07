namespace KH2FM_Editor.Model.Ard
{
    class WalkPath
    {/*
        // Data
        List<byte> header;
        public int headerSize = 8;
        public int walkPathPointSize = 12;
        public ObservableCollection<WalkPathPoint> walkPathPoints = new ObservableCollection<WalkPathPoint>();

        // Data location
        int walkPathPointCountOffset = 2, walkPathPointCountSize = 2;

        public WalkPath(List<byte> rawData)
        {
            // Header - 8 bytes
            header = rawData.GetRange(0, headerSize);
        }

        public short getWalkPathPointCount()
        {
            return Utils.byteList2Short(header.GetRange(walkPathPointCountOffset, walkPathPointCountSize));
        }
        public void setWalkPathPointCount(int value)
        {
            header.RemoveRange(walkPathPointCountOffset, walkPathPointCountSize);
            header.InsertRange(walkPathPointCountOffset, Utils.short2ByteList(value));
        }

        // Generate the item for saving
        public List<byte> generateItem()
        {
            recalcPointCount();
            
            List<byte> rawItem = new List<byte>();
            // Header
            rawItem.AddRange(header);
            // Walk Path Points
            foreach (WalkPathPoint wpp in walkPathPoints) rawItem.AddRange(wpp.generateItem());

            return rawItem;
        }

        void recalcPointCount()
        {
            setWalkPathPointCount(walkPathPoints.Count);
        }

        // Create Control to show data
        public static Control getTabControl(List<WalkPath> data)
        {
            // TabControl
            TabControl tabControl = new TabControl();
            tabControl.AutoSize = true;
            tabControl.Dock = DockStyle.Fill;
            TabPage tab;
            String tabName;

            for (int i = 0; i < data.Count; i++)
            {
                tabName = "WalkPath_" + i;
                tab = new TabPage(tabName);
                tab.Name = tabName;
                tabControl.TabPages.Add(tab);
                tabControl.TabPages[tabName].Controls.Add(WalkPathPoint.getDataGrid(data[i].walkPathPoints));
            }

            return tabControl;
        }*/
    }
}
