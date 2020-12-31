using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.Model.System03.Memt
{
    public class MemtFile : Str_EntryFile, BarSubFile
    {
        public ObservableCollection<Str_EntryItem> MemtConfs { get; set; }

        public MemtFile(String name, List<byte> raw) : base(name, 4, 4, MemtItem.entrySize, raw) { }

        public override void processEntries(List<byte> raw)
        {
            int currentOffset = headerSize;

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new MemtItem(raw.GetRange(currentOffset, MemtItem.entrySize)));
                currentOffset += MemtItem.entrySize;
            }

            MemtConfs = new ObservableCollection<Str_EntryItem>();
            for (int i = 0; i < MemtConf.entryCount; i++)
            {
                MemtConfs.Add(new MemtConf(raw.GetRange(currentOffset, MemtConf.entrySize)));
                currentOffset += MemtConf.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            List<byte> data = getAsByteList();
            foreach (MemtConf mc in MemtConfs) data.AddRange(mc.getAsByteList());
            return data;
        }
    }
}