using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Vtbl
{
    public class VtblItem : Str_EntryItem
    {
        public static readonly int entrySize = 14;

        // Data Location
        public int charOffset = 0, charSize = 1;
        public int actionOffset = 1, actionSize = 1;
        public int priorityOffset = 2, prioritySize = 1;
        public int unk03Offset = 3, unk03Size = 1;
        public int voice1Offset = 4, voice1Size = 1;
        public int voice1ChanceOffset = 5, voice1ChanceSize = 1;
        public int voice2Offset = 6, voice2Size = 1;
        public int voice2ChanceOffset = 7, voice2ChanceSize = 1;
        public int voice3Offset = 8, voice3Size = 1;
        public int voice3ChanceOffset = 9, voice3ChanceSize = 1;
        public int voice4Offset = 10, voice4Size = 1;
        public int voice4ChanceOffset = 11, voice4ChanceSize = 1;
        public int voice5Offset = 12, voice5Size = 1;
        public int voice5ChanceOffset = 13, voice5ChanceSize = 1;

        public VtblItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public VtblItem(List<byte> rawData) : base(rawData)
        {
        }

        public string CharValue
        {
            get { return Characters.getValue(Char); }
        }
        public byte Char
        {
            get { return DataAccess.readByte(raw, charOffset); }
            set { DataAccess.writeByte(raw, value, charOffset); NotifyPropertyChanged(nameof(CharValue)); }
        }
        public string Action
        {
            get { return DataAccess.readHexString(raw, actionOffset, actionSize); }
            set { DataAccess.writeHexString(raw, value, actionOffset, actionSize); }
        }
        public string Priority
        {
            get { return DataAccess.readHexString(raw, priorityOffset, prioritySize); }
            set { DataAccess.writeHexString(raw, value, priorityOffset, prioritySize); }
        }
        public string Unk03
        {
            get { return DataAccess.readHexString(raw, unk03Offset, unk03Size); }
            set { DataAccess.writeHexString(raw, value, unk03Offset, unk03Size); }
        }
        public byte Voice1
        {
            get { return DataAccess.readByte(raw, voice1Offset); }
            set { DataAccess.writeByte(raw, value, voice1Offset); }
        }
        public byte Voice1Chance
        {
            get { return DataAccess.readByte(raw, voice1ChanceOffset); }
            set { DataAccess.writeByte(raw, value, voice1ChanceOffset); }
        }
        public byte Voice2
        {
            get { return DataAccess.readByte(raw, voice2Offset); }
            set { DataAccess.writeByte(raw, value, voice2Offset); }
        }
        public byte Voice2Chance
        {
            get { return DataAccess.readByte(raw, voice2ChanceOffset); }
            set { DataAccess.writeByte(raw, value, voice2ChanceOffset); }
        }
        public byte Voice3
        {
            get { return DataAccess.readByte(raw, voice3Offset); }
            set { DataAccess.writeByte(raw, value, voice3Offset); }
        }
        public byte Voice3Chance
        {
            get { return DataAccess.readByte(raw, voice3ChanceOffset); }
            set { DataAccess.writeByte(raw, value, voice3ChanceOffset); }
        }
        public byte Voice4
        {
            get { return DataAccess.readByte(raw, voice4Offset); }
            set { DataAccess.writeByte(raw, value, voice4Offset); }
        }
        public byte Voice4Chance
        {
            get { return DataAccess.readByte(raw, voice4ChanceOffset); }
            set { DataAccess.writeByte(raw, value, voice4ChanceOffset); }
        }
        public byte Voice5
        {
            get { return DataAccess.readByte(raw, voice5Offset); }
            set { DataAccess.writeByte(raw, value, voice5Offset); }
        }
        public byte Voice5Chance
        {
            get { return DataAccess.readByte(raw, voice5ChanceOffset); }
            set { DataAccess.writeByte(raw, value, voice5ChanceOffset); }
        }
    }
}
