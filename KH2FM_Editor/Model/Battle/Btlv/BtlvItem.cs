﻿using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Btlv
{
    public class BtlvItem : Str_EntryItem
    {
        public static readonly int entrySize = 32;

        // Data Location
        public int rawOffset = 0, rawSize = 32;

        public BtlvItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public BtlvItem(List<byte> rawData) : base(rawData)
        {
        }

        public string Raw
        {
            get { return DataAccess.readHexString(raw, rawOffset, rawSize); }
            set { DataAccess.writeHexString(raw, value, rawOffset, rawSize); }
        }

    }
}
