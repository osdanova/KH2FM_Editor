using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.Model.System03.Arif
{
    public class ArifBlock
    {
        // Data Location
        public ObservableCollection<ArifItem> Entries { get; set; }

        public ArifBlock(List<byte> rawData, int entryCount)
        {
            processEntries(rawData, entryCount);
        }

        public void processEntries(List<byte> raw, int entryCount)
        {
            Entries = new ObservableCollection<ArifItem>();
            int currentOffset = 0;

            for (int i = 0; i < entryCount; i++)
            {
                Entries.Add(new ArifItem(raw.GetRange(currentOffset, ArifItem.Size)));
                currentOffset += ArifItem.Size;
            }
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            List<byte> data = new List<byte>();

            foreach(ArifItem entry in Entries)
            {
                data.AddRange(entry.getAsByteList());
            }
            return data;
        }
    }
}
