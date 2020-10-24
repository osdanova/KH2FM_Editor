using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KH2FM_Editor_WPF.FileTypes.GENERIC
{
    public class BaseEntry : INotifyPropertyChanged
    {
        //----------------------------------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        // NotifyPropertyChanged(nameof(PROPERTY_NAME_TO_UPDATE));
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //----------------------------------------------------------------------------------------

        // Entry data as bytes
        protected List<byte> raw;

        public BaseEntry() {}
        public BaseEntry(List<byte> rawData)
        {
            raw = rawData;
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            return raw;
        }

        /*
        // Returns an editable datagrid of the given list of entries
        public virtual Control getDataGrid(List<BaseEntry> data)
        {
            RichTextBox output = new RichTextBox();
            output.AutoSize = true;
            output.Dock = DockStyle.Fill;
            String dataText = "";
            dataText += "Entry count: " + data.Count + Environment.NewLine;
            dataText += "Entry size (bytes): " + raw.Count + Environment.NewLine;
            foreach (BaseEntry entry in data)
            {
                dataText += Utils.byteList2HEXstring(entry.generateItem()) + Environment.NewLine;
            }
            output.Text = dataText;
            return output;
        }
        */
    }
}
