using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Jiminy.Worl
{
    class WorlItem : Str_EntryItem
    {
        public static readonly int entrySize = 16;
        // Data Location
        public int idOffset = 0, idSize = 1;
        public int worldIdOffset = 1, worldIdSize = 2;
        public int pad03Offset = 3, pad03Size = 1;
        public int textTitleOffset = 4, textTitleSize = 2;
        public int textMenuOffset = 6, textMenuSize = 2;
        public int storyFlagOffset = 8, storyFlagSize = 2;
        public int textTitle2Offset = 10, textTitle2Size = 2;
        public int textMenu2Offset = 12, textMenu2Size = 2;
        public int storyFlag2Offset = 14, storyFlag2Size = 2;

        public WorlItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public WorlItem(List<byte> rawData) : base(rawData)
        {
        }

        public byte Id
        {
            get { return DataAccess.readByte(raw, idOffset); }
            set { DataAccess.writeByte(raw, value, idOffset); }
        }
        public string WorldId
        {
            get { return DataAccess.readString(raw, worldIdOffset, worldIdSize); }
            set { DataAccess.writeString(raw, value, worldIdOffset, worldIdSize); }
        }
        public ushort TextTitle
        {
            get { return DataAccess.readUShort(raw, textTitleOffset, textTitleSize); }
            set { DataAccess.writeUShort(raw, value, textTitleOffset, textTitleSize); }
        }
        public ushort TextMenu
        {
            get { return DataAccess.readUShort(raw, textMenuOffset, textMenuSize); }
            set { DataAccess.writeUShort(raw, value, textMenuOffset, textMenuSize); }
        }
        public ushort StoryFlag
        {
            get { return DataAccess.readUShort(raw, storyFlagOffset, storyFlagSize); }
            set { DataAccess.writeUShort(raw, value, storyFlagOffset, storyFlagSize); }
        }
        public ushort TextTitle2
        {
            get { return DataAccess.readUShort(raw, textTitle2Offset, textTitle2Size); }
            set { DataAccess.writeUShort(raw, value, textTitle2Offset, textTitle2Size); }
        }
        public ushort TextMenu2
        {
            get { return DataAccess.readUShort(raw, textMenu2Offset, textMenu2Size); }
            set { DataAccess.writeUShort(raw, value, textMenu2Offset, textMenu2Size); }
        }
        public ushort StoryFlag2
        {
            get { return DataAccess.readUShort(raw, storyFlag2Offset, storyFlag2Size); }
            set { DataAccess.writeUShort(raw, value, storyFlag2Offset, storyFlag2Size); }
        }
    }
}
