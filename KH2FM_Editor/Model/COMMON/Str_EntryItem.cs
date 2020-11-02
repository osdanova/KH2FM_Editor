using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KH2FM_Editor.Model.COMMON
{
    /*
     * An entry stored as a list of bytes.
     */
    public class Str_EntryItem : INotifyPropertyChanged
    {
        // Entry as bytes
        public List<byte> raw;

        // Constructors
        public Str_EntryItem() { }
        public Str_EntryItem(List<byte> rawData)
        {
            raw = rawData;
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            return raw;
        }

        // Allows to update properties when a property changes
        //----------------------------------------------------------------------------------------
        // USE AS -> NotifyPropertyChanged(nameof(PROPERTY_NAME_TO_UPDATE));
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //----------------------------------------------------------------------------------------
    }
}