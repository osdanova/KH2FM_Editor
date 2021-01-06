using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Item
{
    class ItemItem : Str_EntryItem
    {
        public static readonly int entrySize = 24;
        // Data Location
        public int idOffset = 0, idSize = 2;
        public int categoryOffset = 2, categorySize = 1;
        public int unk3Offset = 3, unk3Size = 1;
        public int subIdOffset = 4, subIdSize = 1;
        public int rankOffset = 5, rankSize = 1;
        public int statusOffset = 6, statusSize = 2;
        public int nameOffset = 8, nameSize = 2;
        public int descriptionOffset = 10, descriptionSize = 2;
        public int buyOffset = 12, buySize = 2;
        public int sellOffset = 14, sellSize = 2;
        public int commandOffset = 16, commandSize = 2;
        public int slotOffset = 18, slotSize = 2;
        public int imageOffset = 20, imageSize = 2;
        public int unk22Offset = 22, unk22Size = 1;
        public int unk23Offset = 23, unk23Size = 1;

        public ItemItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public ItemItem(List<byte> rawData) : base(rawData)
        {
        }

        public string ItemValue
        {
            get { return Items.getValue(Id); }
        }
        public ushort Id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); NotifyPropertyChanged(nameof(ItemValue)); }
        }
        public string CategoryValue
        {
            get { return ItemCategories.getValue(Category); }
        }
        public byte Category
        {
            get { return DataAccess.readByte(raw, categoryOffset); }
            set { DataAccess.writeByte(raw, value, categoryOffset); NotifyPropertyChanged(nameof(CategoryValue)); }
        }
        public string Unk3
        {
            get { return DataAccess.readHexString(raw, unk3Offset, unk3Size); }
            set { DataAccess.writeHexString(raw, value, unk3Offset, unk3Size); }
        }
        public byte SubId
        {
            get { return DataAccess.readByte(raw, subIdOffset); }
            set { DataAccess.writeByte(raw, value, subIdOffset); }
        }
        public byte Rank
        {
            get { return DataAccess.readByte(raw, rankOffset); }
            set { DataAccess.writeByte(raw, value, rankOffset); }
        }
        public ushort Status
        {
            get { return DataAccess.readUShort(raw, statusOffset, statusSize); }
            set { DataAccess.writeUShort(raw, value, statusOffset, statusSize); }
        }
        public ushort Name
        {
            get { return DataAccess.readUShort(raw, nameOffset, nameSize); }
            set { DataAccess.writeUShort(raw, value, nameOffset, nameSize); }
        }
        public ushort Description
        {
            get { return DataAccess.readUShort(raw, descriptionOffset, descriptionSize); }
            set { DataAccess.writeUShort(raw, value, descriptionOffset, descriptionSize); }
        }
        public ushort Buy
        {
            get { return DataAccess.readUShort(raw, buyOffset, buySize); }
            set { DataAccess.writeUShort(raw, value, buyOffset, buySize); }
        }
        public ushort Sell
        {
            get { return DataAccess.readUShort(raw, sellOffset, sellSize); }
            set { DataAccess.writeUShort(raw, value, sellOffset, sellSize); }
        }
        public string CommandValue
        {
            get { return Commands.getValue(Command); }
        }
        public ushort Command
        {
            get { return DataAccess.readUShort(raw, commandOffset, commandSize); }
            set { DataAccess.writeUShort(raw, value, commandOffset, commandSize); NotifyPropertyChanged(nameof(CommandValue)); }
        }
        public ushort Slot
        {
            get { return DataAccess.readUShort(raw, slotOffset, slotSize); }
            set { DataAccess.writeUShort(raw, value, slotOffset, slotSize); }
        }
        public ushort Image
        {
            get { return DataAccess.readUShort(raw, imageOffset, imageSize); }
            set { DataAccess.writeUShort(raw, value, imageOffset, imageSize); }
        }
        public string Unk22
        {
            get { return DataAccess.readHexString(raw, unk22Offset, unk22Size); }
            set { DataAccess.writeHexString(raw, value, unk22Offset, unk22Size); }
        }
        public string Unk23
        {
            get { return DataAccess.readHexString(raw, unk23Offset, unk23Size); }
            set { DataAccess.writeHexString(raw, value, unk23Offset, unk23Size); }
        }
    }
}
