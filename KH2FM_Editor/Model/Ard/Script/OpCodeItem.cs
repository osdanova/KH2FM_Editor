using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Ard.Script
{
    public class OpcodeItem : Str_EntryItem
    {
        // Size without params
        public static readonly int entrySize = 4;
        // Data location
        public static readonly int typeOffset = 0, typeSize = 2;
        public static readonly int paramCountOffset = 2, paramCountSize = 2;
        public static readonly int paramOffset = 4, paramSize = 4;

        public OpcodeItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public OpcodeItem(List<byte> rawData) : base(rawData)
        {
        }

        public string TypeValue
        {
            get { return ArdOpcodes.getValue(Type); }
        }
        public ushort Type
        {
            get { return DataAccess.readUShort(raw, typeOffset, typeSize); }
            set { DataAccess.writeUShort(raw, value, typeOffset, typeSize); NotifyPropertyChanged(nameof(TypeValue)); }
        }
        public ushort ParamCount
        {
            get { return DataAccess.readUShort(raw, paramCountOffset, paramCountSize); }
            set { DataAccess.writeUShort(raw, value, paramCountOffset, paramCountSize); }
        }
        public string ParamText
        {
            get { return DataAccess.readString(raw, paramOffset, ParamCount*4); }
            set { recalcParamCount(value); DataAccess.writeString(raw, value, paramOffset, value.Length); NotifyPropertyChanged(nameof(ParamCount)); }
        }
        public string ParamHex
        {
            get { return DataAccess.readHexString(raw, paramOffset, ParamCount * 4); }
            set { recalcParamCount(value); DataAccess.writeHexString(raw, value, paramOffset, value.Length); NotifyPropertyChanged(nameof(ParamCount)); }
        }

        private void recalcParamCount(string param)
        {
            ParamCount = (ushort) param.Length;
        }
    }
}
