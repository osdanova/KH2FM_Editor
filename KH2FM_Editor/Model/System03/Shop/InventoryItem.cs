using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Shop
{
    public class InventoryItem : Str_EntryItem
    {
        public static readonly int entrySize = 8;
        // Data Location
        public int unlockEventOffset = 0, unlockEventSize = 2;
        public int productCountOffset = 2, productCountSize = 2;
        public int productOfstOffset = 4, productOfstSize = 2;
        public int paddingOffset = 6, paddingSize = 2;

        public InventoryItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public InventoryItem(List<byte> rawData) : base(rawData)
        {
        }

        public string UnlockEvent
        {
            get { return DataAccess.readHexString(raw, unlockEventOffset, unlockEventSize); }
            set { DataAccess.writeHexString(raw, value, unlockEventOffset, unlockEventSize); }
        }
        public ushort ProductCount
        {
            get { return DataAccess.readUShort(raw, productCountOffset, productCountSize); }
            set { DataAccess.writeUShort(raw, value, productCountOffset, productCountSize); }
        }
        public ushort ProductOfst
        {
            get { return DataAccess.readUShort(raw, productOfstOffset, productOfstSize); }
            set { DataAccess.writeUShort(raw, value, productOfstOffset, productOfstSize); }
        }
    }
}
