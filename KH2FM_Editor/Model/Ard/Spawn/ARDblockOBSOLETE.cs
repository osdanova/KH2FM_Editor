using System;
using System.Collections.Generic;

namespace KH2FM_Editor.FileTypes
{
    class ARDblock
    {/*
        // Data
        List<Byte> header;
        public List<Spawn> entitySpawns = new List<Spawn>();
        public List<Spawn> eventSpawns = new List<Spawn>();
        public List<WalkPath> walkPathSpawns = new List<WalkPath>();
        public List<ByteList> unk16Spawns = new List<ByteList>();
        public List<ByteList> unk8Spawns = new List<ByteList>();

        // Data Location
        int typeOffset = 0, typeSize = 2;
        int IdOffset = 2, IdSize = 2;
        int entityCountOffset = 4, entityCountSize = 2;
        int eventCountOffset = 6, eventCountSize = 2;
        int walkPathCountOffset = 8, walkPathCountSize = 2;
        int unk16CountOffset = 10, unk16CountSize = 2;
        int unk8CountOffset = 12, unk8CountSize = 2;

        public ARDblock(List<Byte> rawHeader)
        {
            header = rawHeader;
        }

        public String getType()
        {
            return Utils.byteList2HEXstring(header.GetRange(typeOffset, typeSize));
        }
        public String getID()
        {
            return Utils.byteList2HEXstring(header.GetRange(IdOffset, IdSize));
        }
        public int getEntityCount()
        {
            return Utils.byteList2Int(header.GetRange(entityCountOffset, entityCountSize));
        }
        public void setEntityCount(int value)
        {
            header.RemoveRange(entityCountOffset, entityCountSize);
            header.InsertRange(entityCountOffset, Utils.short2ByteList(value));
        }
        public int getEventCount()
        {
            return Utils.byteList2Int(header.GetRange(eventCountOffset, eventCountSize));
        }
        public void setEventCount(int value)
        {
            header.RemoveRange(eventCountOffset, eventCountSize);
            header.InsertRange(eventCountOffset, Utils.short2ByteList(value));
        }
        public int getWalkPathCount()
        {
            return Utils.byteList2Int(header.GetRange(walkPathCountOffset, walkPathCountSize));
        }
        public void setWalkPathCount(int value)
        {
            header.RemoveRange(walkPathCountOffset, walkPathCountSize);
            header.InsertRange(walkPathCountOffset, Utils.short2ByteList(value));
        }
        public int getUnk16Count()
        {
            return Utils.byteList2Int(header.GetRange(unk16CountOffset, unk16CountSize));
        }
        public void setUnk16Count(int value)
        {
            header.RemoveRange(unk16CountOffset, unk16CountSize);
            header.InsertRange(unk16CountOffset, Utils.short2ByteList(value));
        }
        public int getUnk8Count()
        {
            return Utils.byteList2Int(header.GetRange(unk8CountOffset, unk8CountSize));
        }
        public void setUnk8Count(int value)
        {
            header.RemoveRange(unk8CountOffset, unk8CountSize);
            header.InsertRange(unk8CountOffset, Utils.short2ByteList(value));
        }

        void recalcPointCount()
        {
            Console.WriteLine("DGP >> entityCount: " + getEntityCount());
            setEntityCount(entitySpawns.Count);
            Console.WriteLine("DGP >> entityCount after: " + getEntityCount());
            Console.WriteLine("DGP >> eventCount: " + getEntityCount());
            setEventCount(eventSpawns.Count);
            Console.WriteLine("DGP >> eventCount after: " + getEntityCount());
            setWalkPathCount(walkPathSpawns.Count);
            setUnk16Count(unk16Spawns.Count);
            setUnk8Count(unk8Spawns.Count);
        }

        // Generate the item for saving
        public List<byte> generateItem()
        {
            recalcPointCount();

            List<byte> rawItem = new List<byte>();
            // Header
            rawItem.AddRange(header);
            // Entity spawns
            foreach(Spawn sp in entitySpawns) rawItem.AddRange(sp.generateItem());
            // Event spawns
            foreach (Spawn sp in eventSpawns) rawItem.AddRange(sp.generateItem());
            // Walk Path spawns
            foreach (WalkPath wp in walkPathSpawns) rawItem.AddRange(wp.generateItem());
            // Unknown16 spawns
            foreach (ByteList unk16 in unk16Spawns) rawItem.AddRange(unk16.generateItem());
            // Unknown8 spawns
            foreach (ByteList unk8 in unk8Spawns) rawItem.AddRange(unk8.generateItem());

            return rawItem;
        }

        public Control getTabControl()
        {
            // TabControl
            TabControl tabControl = new TabControl();
            tabControl.AutoSize = true;
            tabControl.Dock = DockStyle.Fill;
            TabPage tab;
            String tabName;

            // ENTITIES
            tabName = "Entities";
            tab = new TabPage(tabName);
            tab.Name = tabName;
            tabControl.TabPages.Add(tab);
            tabControl.TabPages[tabName].Controls.Add(Spawn.getDataGrid(entitySpawns));

            // EVENTS
            tabName = "Events";
            tab = new TabPage(tabName);
            tab.Name = tabName;
            tabControl.TabPages.Add(tab);
            tabControl.TabPages[tabName].Controls.Add(Spawn.getDataGrid(eventSpawns));

            // WALK PATH
            if(walkPathSpawns.Count > 0)
            {
                tabName = "Walk Paths";
                tab = new TabPage(tabName);
                tab.Name = tabName;
                tabControl.TabPages.Add(tab);
                tabControl.TabPages[tabName].Controls.Add(WalkPath.getTabControl(walkPathSpawns));
            }

            // UNK16
            tabName = "Unk16";
            tab = new TabPage(tabName);
            tab.Name = tabName;
            tabControl.TabPages.Add(tab);
            tabControl.TabPages[tabName].Controls.Add(ByteList.getDataGrid(unk16Spawns));
            // UNK8
            tabName = "Unk8";
            tab = new TabPage(tabName);
            tab.Name = tabName;
            tabControl.TabPages.Add(tab);
            tabControl.TabPages[tabName].Controls.Add(ByteList.getDataGrid(unk8Spawns));

            return tabControl;
        }*/
    }
}
