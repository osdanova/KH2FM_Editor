using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Limt
{
    public class LimtItem : Str_EntryItem
    {
        public static readonly int entrySize = 64;
        // Data Location
        public int idOffset = 0, idSize = 1;
        public int characterOffset = 1, characterSize = 1;
        public int summonOffset = 2, summonSize = 1;
        public int groupOffset = 3, groupSize = 1;
        public int nameOffset = 4, nameSize = 32;
        public int unk36Offset = 36, unk36Size = 4;
        public int unk40Offset = 40, unk40Size = 4;
        public int unk44Offset = 44, unk44Size = 4;
        public int paddingOffset = 48, paddingSize = 16;

        public LimtItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public LimtItem(List<byte> rawData) : base(rawData)
        {
        }

        public byte Id
        {
            get { return DataAccess.readByte(raw, idOffset); }
            set { DataAccess.writeByte(raw, value, idOffset); }
        }
        public string CharacterValue
        {
            get { return Characters.getValue(Character); }
        }
        public byte Character
        {
            get { return DataAccess.readByte(raw, characterOffset); }
            set { DataAccess.writeByte(raw, value, characterOffset); NotifyPropertyChanged(nameof(CharacterValue)); }
        }
        public string SummonValue
        {
            get { return Characters.getValue(Summon); }
        }
        public byte Summon
        {
            get { return DataAccess.readByte(raw, summonOffset); }
            set { DataAccess.writeByte(raw, value, summonOffset); NotifyPropertyChanged(nameof(SummonValue)); }
        }
        public byte Group
        {
            get { return DataAccess.readByte(raw, groupOffset); }
            set { DataAccess.writeByte(raw, value, groupOffset); }
        }
        public string Name
        {
            get { return DataAccess.readString(raw, nameOffset, nameSize); }
            set { DataAccess.writeString32(raw, value, nameOffset, nameSize); }
        }
        public string Unk36
        {
            get { return DataAccess.readHexString(raw, unk36Offset, unk36Size); }
            set { DataAccess.writeHexString(raw, value, unk36Offset, unk36Size); }
        }
        public string Unk40
        {
            get { return DataAccess.readHexString(raw, unk40Offset, unk40Size); }
            set { DataAccess.writeHexString(raw, value, unk40Offset, unk40Size); }
        }
        public string Unk44
        {
            get { return DataAccess.readHexString(raw, unk44Offset, unk44Size); }
            set { DataAccess.writeHexString(raw, value, unk44Offset, unk44Size); }
        }
    }
}
