using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Rcct
{
    public class RcctItem : Str_EntryItem
    {
        public static readonly int entrySize = 12;
        // Data Location
        public int idOffset = 0, idSize = 2;
        public int command1Offset = 2, command1Size = 2;
        public int command2Offset = 4, command2Size = 2;
        public int command3Offset = 6, command3Size = 2;
        public int command4Offset = 8, command4Size = 2;
        public int command5Offset = 10, command5Size = 2;

        public RcctItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public RcctItem(List<byte> rawData) : base(rawData)
        {
        }

        public ushort Id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); }
        }
        public string Command1Value
        {
            get { return Commands.getValue(Command1); }
        }
        public ushort Command1
        {
            get { return DataAccess.readUShort(raw, command1Offset, command1Size); }
            set { DataAccess.writeUShort(raw, value, command1Offset, command1Size); NotifyPropertyChanged(nameof(Command1Value)); }
        }
        public string Command2Value
        {
            get { return Commands.getValue(Command2); }
        }
        public ushort Command2
        {
            get { return DataAccess.readUShort(raw, command2Offset, command2Size); }
            set { DataAccess.writeUShort(raw, value, command2Offset, command2Size); NotifyPropertyChanged(nameof(Command2Value)); }
        }
        public string Command3Value
        {
            get { return Commands.getValue(Command3); }
        }
        public ushort Command3
        {
            get { return DataAccess.readUShort(raw, command3Offset, command3Size); }
            set { DataAccess.writeUShort(raw, value, command3Offset, command3Size); NotifyPropertyChanged(nameof(Command3Value)); }
        }
        public string Command4Value
        {
            get { return Commands.getValue(Command4); }
        }
        public ushort Command4
        {
            get { return DataAccess.readUShort(raw, command4Offset, command4Size); }
            set { DataAccess.writeUShort(raw, value, command4Offset, command4Size); NotifyPropertyChanged(nameof(Command4Value)); }
        }
        public string Command5Value
        {
            get { return Commands.getValue(Command5); }
        }
        public ushort Command5
        {
            get { return DataAccess.readUShort(raw, command5Offset, command5Size); }
            set { DataAccess.writeUShort(raw, value, command5Offset, command5Size); NotifyPropertyChanged(nameof(Command5Value)); }
        }
    }
}
