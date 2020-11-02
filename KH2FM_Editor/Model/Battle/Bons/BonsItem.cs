using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Bons
{
    public class BonsItem : Str_EntryItem
    {
        public static readonly int entrySize = 16;
        // Data Location
        public int idOffset = 0, idSize = 1;
        public int charOffset = 1, charSize = 1;
        public int hpOffset = 2, hpSize = 1;
        public int mpOffset = 3, mpSize = 1;
        public int driveOffset = 4, driveSize = 1;
        public int itemSlotOffset = 5, itemSlotSize = 1;
        public int accSlotOffset = 6, accSlotSize = 1;
        public int armorSlotOffset = 7, armorSlotSize = 1;
        public int item1Offset = 8, item1Size = 2;
        public int item2Offset = 10, item2Size = 2;
        public int paddingOffset = 12, paddingSize = 4;

        public BonsItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public BonsItem(List<byte> rawData) : base(rawData)
        {
        }

        public string EventValue
        {
            get { return BonsEvents.getValue(Id); }
        }
        public byte Id
        {
            get { return DataAccess.readByte(raw, idOffset); }
            set { DataAccess.writeByte(raw, value, idOffset); NotifyPropertyChanged(nameof(EventValue)); }
        }
        public string CharacterValue
        {
            get { return Characters.getValue(Character); }
        }
        public byte Character
        {
            get { return DataAccess.readByte(raw, charOffset); }
            set { DataAccess.writeByte(raw, value, charOffset); NotifyPropertyChanged(nameof(CharacterValue)); }
        }
        public byte Hp
        {
            get { return DataAccess.readByte(raw, hpOffset); }
            set { DataAccess.writeByte(raw, value, hpOffset); }
        }
        public byte Mp
        {
            get { return DataAccess.readByte(raw, mpOffset); }
            set { DataAccess.writeByte(raw, value, mpOffset); }
        }
        public byte Drive
        {
            get { return DataAccess.readByte(raw, driveOffset); }
            set { DataAccess.writeByte(raw, value, driveOffset); }
        }
        public byte ItemSlot
        {
            get { return DataAccess.readByte(raw, itemSlotOffset); }
            set { DataAccess.writeByte(raw, value, itemSlotOffset); }
        }
        public byte AccSlot
        {
            get { return DataAccess.readByte(raw, accSlotOffset); }
            set { DataAccess.writeByte(raw, value, accSlotOffset); }
        }
        public byte ArmorSlot
        {
            get { return DataAccess.readByte(raw, armorSlotOffset); }
            set { DataAccess.writeByte(raw, value, armorSlotOffset); }
        }
        public string Item1Value
        {
            get { return Items.getValue(Item1); }
        }
        public ushort Item1
        {
            get { return DataAccess.readUShort(raw, item1Offset, item1Size); }
            set { DataAccess.writeUShort(raw, value, item1Offset, item1Size); NotifyPropertyChanged(nameof(Item1Value)); }
        }
        public string Item2Value
        {
            get { return Items.getValue(Item2); }
        }
        public ushort Item2
        {
            get { return DataAccess.readUShort(raw, item2Offset, item2Size); }
            set { DataAccess.writeUShort(raw, value, item2Offset, item2Size); NotifyPropertyChanged(nameof(Item2Value)); }
        }
    }
}
