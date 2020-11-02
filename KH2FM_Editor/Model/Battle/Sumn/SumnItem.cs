using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Sumn
{
    class SumnItem : Str_EntryItem
    {
        public static readonly int entrySize = 64;
        // Data Location
        public int unk0Offset = 0, unk0Size = 2;
        public int unk2Offset = 2, unk2Size = 2;
        public int unk4Offset = 4, unk4Size = 2;
        public int unk6Offset = 6, unk6Size = 2;
        public int unk8Offset = 8, unk8Size = 2;
        public int unk10Offset = 10, unk10Size = 2;
        public int unk12Offset = 12, unk12Size = 2;
        public int paddingOffset = 14, paddingSize = 50;

        public SumnItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public SumnItem(List<byte> rawData) : base(rawData)
        {
        }

        public ushort Unk0
        {
            get { return DataAccess.readUShort(raw, unk0Offset, unk0Size); }
            set { DataAccess.writeUShort(raw, value, unk0Offset, unk0Size); }
        }
        public ushort Unk2
        {
            get { return DataAccess.readUShort(raw, unk2Offset, unk2Size); }
            set { DataAccess.writeUShort(raw, value, unk2Offset, unk2Size); }
        }
        public ushort Unk4
        {
            get { return DataAccess.readUShort(raw, unk4Offset, unk4Size); }
            set { DataAccess.writeUShort(raw, value, unk4Offset, unk4Size); }
        }
        public ushort Unk6
        {
            get { return DataAccess.readUShort(raw, unk6Offset, unk6Size); }
            set { DataAccess.writeUShort(raw, value, unk6Offset, unk6Size); }
        }
        public ushort Unk8
        {
            get { return DataAccess.readUShort(raw, unk8Offset, unk8Size); }
            set { DataAccess.writeUShort(raw, value, unk8Offset, unk8Size); }
        }
        public ushort Unk10
        {
            get { return DataAccess.readUShort(raw, unk10Offset, unk10Size); }
            set { DataAccess.writeUShort(raw, value, unk10Offset, unk10Size); }
        }
        public ushort Unk12
        {
            get { return DataAccess.readUShort(raw, unk12Offset, unk12Size); }
            set { DataAccess.writeUShort(raw, value, unk12Offset, unk12Size); }
        }
    }
}
