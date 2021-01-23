using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Pref.Plyr
{
    public class PlyrItem : Str_EntryItem
    {
        public static readonly int entrySize = 116;
        public static readonly int floatSize = 4;
        // Data Location
        public int
            AttackYOfsOffset = 0,
            AttackRadiusOffset = 4,
            AttackMinHOffset = 8,
            AttackMaxHOffset = 12,
            AttackVAngleOffset = 16,
            AttackVRangeOffset = 20,
            AttackSRangeOffset = 24,
            AttackHAngleOffset = 28,
            AttackUMinHOffset = 32,
            AttackUMaxHOffset = 36,
            AttackURangeOffset = 40,
            AttackJFrontOffset = 44,
            AttackAirMinHOffset = 48,
            AttackAirMaxHOffset = 52,
            AttackAirBigHOfsOffset = 56,
            AttackUV0Offset = 60,
            AttackJV0Offset = 64,
            AttackFirstV0Offset = 68,
            AttackComboV0Offset = 72,
            AttackFinishV0Offset = 76,
            BlowRecovHOffset = 80,
            BlowRecovVOffset = 84,
            BlowRecovTimeOffset = 88,
            AutoLockOnRangeOffset = 92,
            AutoLockOnMinHOffset = 96,
            AutoLockOnMaxHOffset = 100,
            AutoLockOnTimeOffset = 104,
            AutoLockOnHAdjustOffset = 108,
            AutoLockOnInnerAdjustOffset = 112;

        public PlyrItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public PlyrItem(List<byte> rawData) : base(rawData)
        {
        }

        public float AttackYOfs
        {
            get { return DataAccess.readFloat(raw, AttackYOfsOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackYOfsOffset, floatSize); }
        }
        public float AttackRadius
        {
            get { return DataAccess.readFloat(raw, AttackRadiusOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackRadiusOffset, floatSize); }
        }
        public float AttackMinH
        {
            get { return DataAccess.readFloat(raw, AttackMinHOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackMinHOffset, floatSize); }
        }
        public float AttackMaxH
        {
            get { return DataAccess.readFloat(raw, AttackMaxHOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackMaxHOffset, floatSize); }
        }
        public float AttackVAngle
        {
            get { return DataAccess.readFloat(raw, AttackVAngleOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackVAngleOffset, floatSize); }
        }
        public float AttackVRange
        {
            get { return DataAccess.readFloat(raw, AttackVRangeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackVRangeOffset, floatSize); }
        }
        public float AttackSRange
        {
            get { return DataAccess.readFloat(raw, AttackSRangeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackSRangeOffset, floatSize); }
        }
        public float AttackHAngle
        {
            get { return DataAccess.readFloat(raw, AttackHAngleOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackHAngleOffset, floatSize); }
        }
        public float AttackUMinH
        {
            get { return DataAccess.readFloat(raw, AttackUMinHOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackUMinHOffset, floatSize); }
        }
        public float AttackUMaxH
        {
            get { return DataAccess.readFloat(raw, AttackUMaxHOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackUMaxHOffset, floatSize); }
        }
        public float AttackURange
        {
            get { return DataAccess.readFloat(raw, AttackURangeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackURangeOffset, floatSize); }
        }
        public float AttackJFront
        {
            get { return DataAccess.readFloat(raw, AttackJFrontOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackJFrontOffset, floatSize); }
        }
        public float AttackAirMinH
        {
            get { return DataAccess.readFloat(raw, AttackAirMinHOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackAirMinHOffset, floatSize); }
        }
        public float AttackAirMaxH
        {
            get { return DataAccess.readFloat(raw, AttackAirMaxHOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackAirMaxHOffset, floatSize); }
        }
        public float AttackAirBigHOfs
        {
            get { return DataAccess.readFloat(raw, AttackAirBigHOfsOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackAirBigHOfsOffset, floatSize); }
        }
        public float AttackUV0
        {
            get { return DataAccess.readFloat(raw, AttackUV0Offset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackUV0Offset, floatSize); }
        }
        public float AttackJV0
        {
            get { return DataAccess.readFloat(raw, AttackJV0Offset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackJV0Offset, floatSize); }
        }
        public float AttackFirstV0
        {
            get { return DataAccess.readFloat(raw, AttackFirstV0Offset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackFirstV0Offset, floatSize); }
        }
        public float AttackComboV0
        {
            get { return DataAccess.readFloat(raw, AttackComboV0Offset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackComboV0Offset, floatSize); }
        }
        public float AttackFinishV0
        {
            get { return DataAccess.readFloat(raw, AttackFinishV0Offset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AttackFinishV0Offset, floatSize); }
        }
        public float BlowRecovH
        {
            get { return DataAccess.readFloat(raw, BlowRecovHOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, BlowRecovHOffset, floatSize); }
        }
        public float BlowRecovV
        {
            get { return DataAccess.readFloat(raw, BlowRecovVOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, BlowRecovVOffset, floatSize); }
        }
        public float BlowRecovTime
        {
            get { return DataAccess.readFloat(raw, BlowRecovTimeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, BlowRecovTimeOffset, floatSize); }
        }
        public float AutoLockOnRange
        {
            get { return DataAccess.readFloat(raw, AutoLockOnRangeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AutoLockOnRangeOffset, floatSize); }
        }
        public float AutoLockOnMinH
        {
            get { return DataAccess.readFloat(raw, AutoLockOnMinHOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AutoLockOnMinHOffset, floatSize); }
        }
        public float AutoLockOnMaxH
        {
            get { return DataAccess.readFloat(raw, AutoLockOnMaxHOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AutoLockOnMaxHOffset, floatSize); }
        }
        public float AutoLockOnTime
        {
            get { return DataAccess.readFloat(raw, AutoLockOnTimeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AutoLockOnTimeOffset, floatSize); }
        }
        public float AutoLockOnHAdjust
        {
            get { return DataAccess.readFloat(raw, AutoLockOnHAdjustOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AutoLockOnHAdjustOffset, floatSize); }
        }
        public float AutoLockOnInnerAdjust
        {
            get { return DataAccess.readFloat(raw, AutoLockOnInnerAdjustOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AutoLockOnInnerAdjustOffset, floatSize); }
        }
    }
}
