using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Ptya
{
    public class PtyaItem : Str_EntryItem
    {
        public static readonly int entrySize = 68;
        // Data Location
        public int rawOffset = 0, rawSize = 68;
        public int unk0Offset = 0, unk0Size = 8;
        public int animationOffset = 8, animationSize = 2;
        public int unk10Offset = 10, unk10Size = 58;

        public PtyaItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public PtyaItem(List<byte> rawData) : base(rawData)
        {
        }

        public string Raw
        {
            get { return DataAccess.readHexString(raw, rawOffset, rawSize); }
            set { DataAccess.writeHexString(raw, value, rawOffset, rawSize); }
        }
        public string Unk0
        {
            get { return DataAccess.readHexString(raw, unk0Offset, unk0Size); }
            set { DataAccess.writeHexString(raw, value, unk0Offset, unk0Size); }
        }
        public string AnimationName
        {
            get { return Animations.getSoraAnimation((ushort)(Animation * 4)); }
        }
        public string AnimationValue
        {
            get { return "" + Animation * 4; }
        }
        public ushort Animation
        {
            get { return DataAccess.readUShort(raw, animationOffset, animationSize); }
            set { DataAccess.writeUShort(raw, value, animationOffset, animationSize); NotifyPropertyChanged(nameof(AnimationValue)); }
        }
        public string Unk10
        {
            get { return DataAccess.readHexString(raw, unk10Offset, unk10Size); }
            set { DataAccess.writeHexString(raw, value, unk10Offset, unk10Size); }
        }
    }
}
