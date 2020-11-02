﻿using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Lvpm
{
    class LvpmItem : Str_EntryItem
    {
        public static readonly int entrySize = 12;

        // Data Location
        public int hpOffset = 0, hpSize = 2;
        public int strOffset = 2, strSize = 2;
        public int defOffset = 4, defSize = 2;
        public int unk6Offset = 6, unk6Size = 2;
        public int unk8Offset = 8, unk8Size = 2;
        public int expOffset = 10, expSize = 2;


        public LvpmItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public LvpmItem(List<byte> rawData) : base(rawData)
        {
        }

        public ushort Hp
        {
            get { return DataAccess.readUShort(raw, hpOffset, hpSize); }
            set { DataAccess.writeUShort(raw, value, hpOffset, hpSize); }
        }
        public ushort Strength
        {
            get { return DataAccess.readUShort(raw, strOffset, strSize); }
            set { DataAccess.writeUShort(raw, value, strOffset, strSize); }
        }
        public ushort Defense
        {
            get { return DataAccess.readUShort(raw, defOffset, defSize); }
            set { DataAccess.writeUShort(raw, value, defOffset, defSize); }
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
        public ushort Exp
        {
            get { return DataAccess.readUShort(raw, expOffset, expSize); }
            set { DataAccess.writeUShort(raw, value, expOffset, expSize); }
        }
    }
}
