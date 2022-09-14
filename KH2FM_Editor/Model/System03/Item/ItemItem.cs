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
        public int visibilityOffset = 3, visibilitySize = 1;
        public int subIdOffset = 4, subIdSize = 1;
        public int rankOffset = 5, rankSize = 1;
        public int statusOffset = 6, statusSize = 1;
        public int apcostOffset = 7, apcostSize = 1;
        public int nameOffset = 8, nameSize = 2;
        public int descriptionOffset = 10, descriptionSize = 2;
        public int buyOffset = 12, buySize = 2;
        public int sellOffset = 14, sellSize = 2;
        public int commandOffset = 16, commandSize = 2;
        public int slotOffset = 18, slotSize = 2;
        public int imageOffset = 20, imageSize = 2;
        public int prizeBoxOffset = 22, prizeBoxSize = 1;
        public int iconOffset = 23, iconSize = 1;

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
            get { return ItemData.getCategory(Category); }
        }
        public byte Category
        {
            get { return DataAccess.readByte(raw, categoryOffset); }
            set { DataAccess.writeByte(raw, value, categoryOffset); NotifyPropertyChanged(nameof(CategoryValue)); }
        }
        public string VisibilityValue
        {
            get { return ItemData.getVisibility(Visibility); }
        }
        public byte Visibility
        {
            get { return DataAccess.readByte(raw, visibilityOffset); }
            set { DataAccess.writeByte(raw, value, visibilityOffset); NotifyPropertyChanged(nameof(Visibility)); }
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
        public byte Status
        {
            get { return DataAccess.readByte(raw, statusOffset); }
            set { DataAccess.writeByte(raw, value, statusOffset); }
        }
        public byte APCost
        {
            get { return DataAccess.readByte(raw, apcostOffset); }
            set { DataAccess.writeByte(raw, value, apcostOffset); }
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
        public string PrizeBoxValue
        {
            get { return ItemData.getPrizeBox(PrizeBox); }
        }
        public byte PrizeBox
        {
            get { return DataAccess.readByte(raw, prizeBoxOffset); }
            set { DataAccess.writeByte(raw, value, prizeBoxOffset); NotifyPropertyChanged(nameof(PrizeBoxValue)); }
        }
        public string IconValue
        {
            get { return ItemData.getIcon(Icon); }
        }
        public byte Icon
        {
            get { return DataAccess.readByte(raw, iconOffset); }
            set { DataAccess.writeByte(raw, value, iconOffset); NotifyPropertyChanged(nameof(IconValue)); }
        }
    }
}
