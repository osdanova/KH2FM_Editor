using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Shop
{
    public class ProductItem : Str_EntryItem
    {
        public static readonly int entrySize = 2;
        // Data Location
        public int productOffset = 0, productSize = 2;

        public ProductItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public ProductItem(List<byte> rawData) : base(rawData)
        {
        }

        public string ProductValue
        {
            get { return Items.getValue(Product); }
        }
        public ushort Product
        {
            get { return DataAccess.readUShort(raw, productOffset, productSize); }
            set { DataAccess.writeUShort(raw, value, productOffset, productSize); NotifyPropertyChanged(nameof(ProductValue)); }
        }
    }
}
