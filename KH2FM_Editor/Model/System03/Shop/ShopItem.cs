using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Shop
{
    class ShopItem : Str_EntryItem
    {
        public static readonly int entrySize = 24;
        // Data Location
        public int idOffset = 0, idSize = 2;
        public int unlockOffset = 2, unlockSize = 2;
        public int nameOffset = 4, nameSize = 2;
        public int entityOffset = 6, entitySize = 2;
        public int posXOffset = 8, posXSize = 2;
        public int posYOffset = 10, posYSize = 2;
        public int posZOffset = 12, posZSize = 2;
        public int soundOffset = 14, soundSize = 2;
        public int inventoryCountOffset = 16, inventoryCountSize = 2;
        public int unk18Offset = 18, unk18Size = 1;
        public int unk19Offset = 19, unk19Size = 1;
        public int inventoryOfstOffset = 20, inventoryOfstSize = 2;
        public int paddingOffset = 22, paddingSize = 2;

        public ShopItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public ShopItem(List<byte> rawData) : base(rawData)
        {
        }

        public ushort Id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); }
        }
        public string Unlock
        {
            get { return DataAccess.readHexString(raw, unlockOffset, unlockSize); }
            set { DataAccess.writeHexString(raw, value, unlockOffset, unlockSize); }
        }
        public string Name
        {
            get { return DataAccess.readHexString(raw, nameOffset, nameSize); }
            set { DataAccess.writeHexString(raw, value, nameOffset, nameSize); }
        }
        public string EntityValue
        {
            get { return Entities.getValue(Entity); }
        }
        public ushort Entity
        {
            get { return DataAccess.readUShort(raw, entityOffset, entitySize); }
            set { DataAccess.writeUShort(raw, value, entityOffset, entitySize); }
        }
        public ushort PosX
        {
            get { return DataAccess.readUShort(raw, posXOffset, posXSize); }
            set { DataAccess.writeUShort(raw, value, posXOffset, posXSize); }
        }
        public ushort PosY
        {
            get { return DataAccess.readUShort(raw, posYOffset, posYSize); }
            set { DataAccess.writeUShort(raw, value, posYOffset, posYSize); }
        }
        public ushort PosZ
        {
            get { return DataAccess.readUShort(raw, posZOffset, posZSize); }
            set { DataAccess.writeUShort(raw, value, posZOffset, posZSize); }
        }
        public string Sound
        {
            get { return DataAccess.readHexString(raw, soundOffset, soundSize); }
            set { DataAccess.writeHexString(raw, value, soundOffset, soundSize); }
        }
        public ushort InventoryCount
        {
            get { return DataAccess.readUShort(raw, inventoryCountOffset, inventoryCountSize); }
            set { DataAccess.writeUShort(raw, value, inventoryCountOffset, inventoryCountSize); }
        }
        public string ShopValue
        {
            get { return Shops.getValue(Unk18); }
        }
        public byte Unk18
        {
            get { return DataAccess.readByte(raw, unk18Offset); }
            set { DataAccess.writeByte(raw, value, unk18Offset); NotifyPropertyChanged(nameof(ShopValue)); }
        }
        public byte Unk20
        {
            get { return DataAccess.readByte(raw, unk19Offset); }
            set { DataAccess.writeByte(raw, value, unk19Offset); }
        }
        public string InventoryOfst
        {
            get { return DataAccess.readHexString(raw, inventoryOfstOffset, inventoryOfstSize); }
            set { DataAccess.writeHexString(raw, value, inventoryOfstOffset, inventoryOfstSize); }
        }
    }
}
