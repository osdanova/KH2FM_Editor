using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Enmp
{
    public class EnmpItem : Str_EntryItem
    {
        public static readonly int entrySize = 92;
        // Data Location
        public static readonly int idOffset = 0, idSize = 2;
        public static readonly int levelOffset = 2, levelSize = 2; // Forced battle level
        public static readonly int hpOffset = 4, hpSize = 2;
        public static readonly int hp1Offset = 6, hp1Size = 2;
        public static readonly int hp2Offset = 8, hp2Size = 2;
        public static readonly int hp3Offset = 10, hp3Size = 2;
        public static readonly int hp4Offset = 12, hp4Size = 2;
        public static readonly int hp5Offset = 14, hp5Size = 2;
        public static readonly int hp6Offset = 16, hp6Size = 2;

        public static readonly int unk18Offset = 18, unk18Size = 2;
        public static readonly int unk20Offset = 20, unk20Size = 2;
        public static readonly int unk22Offset = 22, unk22Size = 2;
        public static readonly int unk24Offset = 24, unk24Size = 2;
        public static readonly int unk26Offset = 26, unk26Size = 2;
        public static readonly int unk28Offset = 28, unk28Size = 2;
        public static readonly int unk30Offset = 30, unk30Size = 2;
        public static readonly int unk32Offset = 32, unk32Size = 2;
        public static readonly int unk34Offset = 34, unk34Size = 2;
        public static readonly int unk36Offset = 36, unk36Size = 2;
        public static readonly int unk38Offset = 38, unk38Size = 2;
        public static readonly int unk40Offset = 40, unk40Size = 2;
        public static readonly int unk42Offset = 42, unk42Size = 2;
        public static readonly int unk44Offset = 44, unk44Size = 2;
        public static readonly int unk46Offset = 46, unk46Size = 2;
        public static readonly int unk48Offset = 48, unk48Size = 2;
        public static readonly int unk50Offset = 50, unk50Size = 2;
        public static readonly int unk52Offset = 52, unk52Size = 2;
        public static readonly int unk54Offset = 54, unk54Size = 2;
        public static readonly int unk56Offset = 56, unk56Size = 2;
        public static readonly int unk58Offset = 58, unk58Size = 2;
        public static readonly int unk60Offset = 60, unk60Size = 2;
        public static readonly int unk62Offset = 62, unk62Size = 2;
        public static readonly int unk64Offset = 64, unk64Size = 2;
        public static readonly int unk66Offset = 66, unk66Size = 2;

        public static readonly int maxDmgOffset = 68, maxDmgSize = 2;
        public static readonly int minDmgOffset = 70, minDmgSize = 2;
        public static readonly int physResOffset = 72, physResSize = 2;
        public static readonly int fireResOffset = 74, fireResSize = 2;
        public static readonly int blizResOffset = 76, blizResSize = 2;
        public static readonly int thunResOffset = 78, thunResSize = 2;
        public static readonly int darkResOffset = 80, darkResSize = 2;
        public static readonly int neutralResOffset = 82, neutralResSize = 2;
        public static readonly int generalResOffset = 84, generalResSize = 2;
        public static readonly int expOffset = 86, expSize = 2;
        public static readonly int prizeOffset = 88, prizeSize = 2;
        public static readonly int bonusLevelOffset = 90, bonusLevelSize = 2;

        public EnmpItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public EnmpItem(List<byte> rawData) : base(rawData)
        {
        }

        public string EnemyValue
        {
            get { return Enemy.getValue(Id); }
        }
        public ushort Id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); }
        }
        public ushort Level
        {
            get { return DataAccess.readUShort(raw, levelOffset, levelSize); }
            set { DataAccess.writeUShort(raw, value, levelOffset, levelSize); }
        }
        public ushort Hp
        {
            get { return DataAccess.readUShort(raw, hpOffset, hpSize); }
            set { DataAccess.writeUShort(raw, value, hpOffset, hpSize); }
        }
        public ushort MaxDmg
        {
            get { return DataAccess.readUShort(raw, maxDmgOffset, maxDmgSize); }
            set { DataAccess.writeUShort(raw, value, maxDmgOffset, maxDmgSize); }
        }
        public ushort MinDmg
        {
            get { return DataAccess.readUShort(raw, minDmgOffset, minDmgSize); }
            set { DataAccess.writeUShort(raw, value, minDmgOffset, minDmgSize); }
        }
        public ushort PhysRes
        {
            get { return DataAccess.readUShort(raw, physResOffset, physResSize); }
            set { DataAccess.writeUShort(raw, value, physResOffset, physResSize); }
        }
        public ushort FireRes
        {
            get { return DataAccess.readUShort(raw, fireResOffset, fireResSize); }
            set { DataAccess.writeUShort(raw, value, fireResOffset, fireResSize); }
        }
        public ushort BlizzardRes
        {
            get { return DataAccess.readUShort(raw, blizResOffset, blizResSize); }
            set { DataAccess.writeUShort(raw, value, blizResOffset, blizResSize); }
        }
        public ushort ThunderRes
        {
            get { return DataAccess.readUShort(raw, thunResOffset, thunResSize); }
            set { DataAccess.writeUShort(raw, value, thunResOffset, thunResSize); }
        }
        public ushort DarkRes
        {
            get { return DataAccess.readUShort(raw, darkResOffset, darkResSize); }
            set { DataAccess.writeUShort(raw, value, darkResOffset, darkResSize); }
        }
        public ushort NeutralRes
        {
            get { return DataAccess.readUShort(raw, neutralResOffset, neutralResSize); }
            set { DataAccess.writeUShort(raw, value, neutralResOffset, neutralResSize); }
        }
        public ushort GeneralRes
        {
            get { return DataAccess.readUShort(raw, generalResOffset, generalResSize); }
            set { DataAccess.writeUShort(raw, value, generalResOffset, generalResSize); }
        }
        public ushort Exp
        {
            get { return DataAccess.readUShort(raw, expOffset, expSize); }
            set { DataAccess.writeUShort(raw, value, expOffset, expSize); }
        }
        public ushort Prize
        {
            get { return DataAccess.readUShort(raw, prizeOffset, prizeSize); }
            set { DataAccess.writeUShort(raw, value, prizeOffset, prizeSize); }
        }
        public ushort BonusLevel
        {
            get { return DataAccess.readUShort(raw, bonusLevelOffset, bonusLevelSize); }
            set { DataAccess.writeUShort(raw, value, bonusLevelOffset, bonusLevelSize); }
        }
        public ushort Hp1
        {
            get { return DataAccess.readUShort(raw, hp1Offset, hp1Size); }
            set { DataAccess.writeUShort(raw, value, hp1Offset, hp1Size); }
        }
        public ushort Hp2
        {
            get { return DataAccess.readUShort(raw, hp2Offset, hp2Size); }
            set { DataAccess.writeUShort(raw, value, hp2Offset, hp2Size); }
        }
        public ushort Hp3
        {
            get { return DataAccess.readUShort(raw, hp3Offset, hp3Size); }
            set { DataAccess.writeUShort(raw, value, hp3Offset, hp3Size); }
        }
        public ushort Hp4
        {
            get { return DataAccess.readUShort(raw, hp4Offset, hp4Size); }
            set { DataAccess.writeUShort(raw, value, hp4Offset, hp4Size); }
        }
        public ushort Hp5
        {
            get { return DataAccess.readUShort(raw, hp5Offset, hp5Size); }
            set { DataAccess.writeUShort(raw, value, hp5Offset, hp5Size); }
        }
        public ushort Hp6
        {
            get { return DataAccess.readUShort(raw, hp6Offset, hp6Size); }
            set { DataAccess.writeUShort(raw, value, hp6Offset, hp6Size); }
        }
    }
}
