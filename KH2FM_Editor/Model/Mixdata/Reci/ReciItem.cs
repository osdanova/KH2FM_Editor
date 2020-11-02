using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Mixdata.Reci
{
    class ReciItem : Str_EntryItem
    {
        public static readonly int entrySize = 32;
        // Data Location
        public static readonly int idOffset = 0, idSize = 2;
        public static readonly int unk02Offset = 2, unk02Size = 2;
        public static readonly int resultOffset = 4, resultSize = 2;
        public static readonly int upgradeOffset = 6, upgradeSize = 2;
        public static readonly int ingredient1Offset = 8, ingredient1Size = 2;
        public static readonly int count1Offset = 10, count1Size = 2;
        public static readonly int ingredient2Offset = 12, ingredient2Size = 2;
        public static readonly int count2Offset = 14, count2Size = 2;
        public static readonly int ingredient3Offset = 16, ingredient3Size = 2;
        public static readonly int count3Offset = 18, count3Size = 2;
        public static readonly int ingredient4Offset = 20, ingredient4Size = 2;
        public static readonly int count4Offset = 22, count4Size = 2;
        public static readonly int ingredient5Offset = 24, ingredient5Size = 2;
        public static readonly int count5Offset = 26, count5Size = 2;
        public static readonly int ingredient6Offset = 28, ingredient6Size = 2;
        public static readonly int count6Offset = 30, count6Size = 2;

        public ReciItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public ReciItem(List<byte> rawData) : base(rawData)
        {
        }

        public ushort Id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); }
        }
        public string Unk02
        {
            get { return DataAccess.readHexString(raw, unk02Offset, unk02Size); }
            set { DataAccess.writeHexString(raw, value, unk02Offset, unk02Size); }
        }
        public string ResultValue
        {
            get { return Items.getValue(Result); }
        }
        public ushort Result
        {
            get { return DataAccess.readUShort(raw, resultOffset, resultSize); }
            set { DataAccess.writeUShort(raw, value, resultOffset, resultSize); NotifyPropertyChanged(nameof(ResultValue)); }
        }
        public string UpgradeValue
        {
            get { return Items.getValue(Upgrade); }
        }
        public ushort Upgrade
        {
            get { return DataAccess.readUShort(raw, upgradeOffset, upgradeSize); }
            set { DataAccess.writeUShort(raw, value, upgradeOffset, upgradeSize); NotifyPropertyChanged(nameof(UpgradeValue)); }
        }
        public string Ingredient1Value
        {
            get { return Items.getValue(Ingredient1); }
        }
        public ushort Ingredient1
        {
            get { return DataAccess.readUShort(raw, ingredient1Offset, ingredient1Size); }
            set { DataAccess.writeUShort(raw, value, ingredient1Offset, ingredient1Size); NotifyPropertyChanged(nameof(Ingredient1Value)); }
        }
        public ushort Count1
        {
            get { return DataAccess.readUShort(raw, count1Offset, count1Size); }
            set { DataAccess.writeUShort(raw, value, count1Offset, count1Size); }
        }
        public string Ingredient2Value
        {
            get { return Items.getValue(Ingredient2); }
        }
        public ushort Ingredient2
        {
            get { return DataAccess.readUShort(raw, ingredient2Offset, ingredient2Size); }
            set { DataAccess.writeUShort(raw, value, ingredient2Offset, ingredient2Size); NotifyPropertyChanged(nameof(Ingredient2Value)); }
        }
        public ushort Count2
        {
            get { return DataAccess.readUShort(raw, count2Offset, count2Size); }
            set { DataAccess.writeUShort(raw, value, count2Offset, count2Size); }
        }
        public string Ingredient3Value
        {
            get { return Items.getValue(Ingredient3); }
        }
        public ushort Ingredient3
        {
            get { return DataAccess.readUShort(raw, ingredient3Offset, ingredient3Size); }
            set { DataAccess.writeUShort(raw, value, ingredient3Offset, ingredient3Size); NotifyPropertyChanged(nameof(Ingredient3Value)); }
        }
        public ushort Count3
        {
            get { return DataAccess.readUShort(raw, count3Offset, count3Size); }
            set { DataAccess.writeUShort(raw, value, count3Offset, count3Size); }
        }
        public string Ingredient4Value
        {
            get { return Items.getValue(Ingredient4); }
        }
        public ushort Ingredient4
        {
            get { return DataAccess.readUShort(raw, ingredient4Offset, ingredient4Size); }
            set { DataAccess.writeUShort(raw, value, ingredient4Offset, ingredient4Size); NotifyPropertyChanged(nameof(Ingredient4Value)); }
        }
        public ushort Count4
        {
            get { return DataAccess.readUShort(raw, count4Offset, count4Size); }
            set { DataAccess.writeUShort(raw, value, count4Offset, count4Size); }
        }
        public string Ingredient5Value
        {
            get { return Items.getValue(Ingredient5); }
        }
        public ushort Ingredient5
        {
            get { return DataAccess.readUShort(raw, ingredient5Offset, ingredient5Size); }
            set { DataAccess.writeUShort(raw, value, ingredient5Offset, ingredient5Size); NotifyPropertyChanged(nameof(Ingredient5Value)); }
        }
        public ushort Count5
        {
            get { return DataAccess.readUShort(raw, count5Offset, count5Size); }
            set { DataAccess.writeUShort(raw, value, count5Offset, count5Size); }
        }
        public string Ingredient6Value
        {
            get { return Items.getValue(Ingredient6); }
        }
        public ushort Ingredient6
        {
            get { return DataAccess.readUShort(raw, ingredient6Offset, ingredient6Size); }
            set { DataAccess.writeUShort(raw, value, ingredient6Offset, ingredient6Size); NotifyPropertyChanged(nameof(Ingredient6Value)); }
        }
        public ushort Count6
        {
            get { return DataAccess.readUShort(raw, count6Offset, count6Size); }
            set { DataAccess.writeUShort(raw, value, count6Offset, count6Size); }
        }
    }
}
