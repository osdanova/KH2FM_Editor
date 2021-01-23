using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.Bar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.Model.System03.Pref.Sstm
{
    public class SstmFile : BarSubFile
    {
        public static readonly int headerSize = 8;
        public static readonly int preferencesSize = 380;

        public String Name { get; set; }
        public List<byte> Header;
        public ObservableCollection<SstmItem> SystemPrefs { get; set; }

        public SstmFile(String name, List<byte> raw)
        {
            Console.WriteLine("DEBUG >>> Found Sstm file: " + name);
            Header = new List<byte>();
            SystemPrefs = new ObservableCollection<SstmItem>();
            processFile(raw);
        }

        public void processFile(List<byte> raw)
        {
            Header.AddRange(raw.GetRange(0, headerSize));
            SystemPrefs.Add(new SstmItem(raw.GetRange(headerSize, preferencesSize)));
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            List<byte> data = new List<byte>();

            // Header
            data.AddRange(Header);
            // Preferences
            foreach (SstmItem pref in SystemPrefs)
            {
                data.AddRange(pref.getAsByteList());
            }

            return data;
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}