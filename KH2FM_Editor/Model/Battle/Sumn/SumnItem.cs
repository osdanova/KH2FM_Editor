using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Sumn
{
    class SumnItem : Str_EntryItem
    {
        public static readonly int entrySize = 64;
        // Data Location
        public int commandOffset = 0, commandSize = 2;
        public int itemOffset = 2, itemSize = 2;
        public int entityOffset = 4, entitySize = 4;
        public int entity2Offset = 8, entity2Size = 4;
        public int limitOffset = 12, limitSize = 2;
        public int paddingOffset = 14, paddingSize = 50;

        public SumnItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public SumnItem(List<byte> rawData) : base(rawData)
        {
        }

        public string Command
        {
            get { return Commands.getValue(CommandId); }
        }
        public ushort CommandId
        {
            get { return DataAccess.readUShort(raw, commandOffset, commandSize); }
            set { DataAccess.writeUShort(raw, value, commandOffset, commandSize); NotifyPropertyChanged(nameof(Command)); }
        }
        public string Item
        {
            get { return Items.getValue(ItemId); }
        }
        public ushort ItemId
        {
            get { return DataAccess.readUShort(raw, itemOffset, itemSize); }
            set { DataAccess.writeUShort(raw, value, itemOffset, itemSize); NotifyPropertyChanged(nameof(Item)); }
        }
        public string Entity
        {
            get { return Entities.getValue((ushort)EntityId); }
        }
        public uint EntityId
        {
            get { return DataAccess.readUInt(raw, entityOffset, entitySize); }
            set { DataAccess.writeUInt(raw, value, entityOffset, entitySize); NotifyPropertyChanged(nameof(Entity)); }
        }
        public string Entity2
        {
            get { return Entities.getValue((ushort)Entity2Id); }
        }
        public uint Entity2Id
        {
            get { return DataAccess.readUInt(raw, entity2Offset, entity2Size); }
            set { DataAccess.writeUInt(raw, value, entity2Offset, entity2Size); NotifyPropertyChanged(nameof(Entity2)); }
        }
        public string Limit
        {
            get { return Commands.getValue(LimitId); }
        }
        public ushort LimitId
        {
            get { return DataAccess.readUShort(raw, limitOffset, limitSize); }
            set { DataAccess.writeUShort(raw, value, limitOffset, limitSize); NotifyPropertyChanged(nameof(Limit)); }
        }
    }
}
