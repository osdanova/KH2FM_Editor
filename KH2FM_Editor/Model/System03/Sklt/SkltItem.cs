using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Sklt
{
    class SkltItem : Str_EntryItem
    {
        public static readonly int entrySize = 8;
        // Data Location
        public int characterOffset = 0, characterSize = 4;
        public int bone1Offset = 4, bone1Size = 2;
        public int bone2Offset = 6, bone2Size = 2;

        public SkltItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public SkltItem(List<byte> rawData) : base(rawData)
        {
        }

        public string CharacterValue
        {
            get { return Characters.getValue((ushort)Character); }
        }
        public uint Character
        {
            get { return DataAccess.readUInt(raw, characterOffset, characterSize); }
            set { DataAccess.writeUInt(raw, value, characterOffset, characterSize); NotifyPropertyChanged(nameof(CharacterValue)); }
        }
        public short Bone1
        {
            get { return DataAccess.readShort(raw, bone1Offset, bone1Size); }
            set { DataAccess.writeShort(raw, value, bone1Offset, bone1Size); }
        }
        public short Bone2
        {
            get { return DataAccess.readShort(raw, bone2Offset, bone2Size); }
            set { DataAccess.writeShort(raw, value, bone2Offset, bone2Size); }
        }
    }
}
