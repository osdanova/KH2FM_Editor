using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH2FM_Editor_WPF.FileTypes.GENERIC
{
    public class BaseEntry
    {
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
