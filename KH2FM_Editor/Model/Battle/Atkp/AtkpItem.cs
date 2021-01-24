using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Atkp
{
    public class AtkpItem : Str_EntryItem
    {
        public static readonly int entrySize = 48;
        // Data Location
        public static readonly int subIdOffset = 0, subIdSize = 2;
        public static readonly int idOffset = 2, idSize = 2;
        public static readonly int typeOffset = 4, typeSize = 1;
        public static readonly int critAdjustOffset = 5, critAdjustSize = 1;
        public static readonly int powerOffset = 6, powerSize = 2;
        public static readonly int teamOffset = 8, teamSize = 1;
        public static readonly int elementOffset = 9, elementSize = 1;
        public static readonly int knockbackOffset = 10, knockbackSize = 1;
        public static readonly int hitEffectOffset = 11, hitEffectSize = 1;
        public static readonly int knockbackStr1Offset = 12, knockbackStr1Size = 2;
        public static readonly int knockbackStr2Offset = 14, knockbackStr2Size = 2;
        public static readonly int unk16Offset = 16, unk16Size = 2;
        public static readonly int flagOffset = 18, flagSize = 1;
        public static readonly int refactSelfOffset = 19, refactSelfSize = 1;
        public static readonly int refactOtherOffset = 20, refactOtherSize = 1;
        public static readonly int reflectMotionOffset = 21, reflectMotionSize = 1;
        public static readonly int reflectHitBackOffset = 22, reflectHitBackSize = 2;
        public static readonly int reflectActionOffset = 24, reflectActionSize = 4;
        public static readonly int soundEffectOffset = 28, soundEffectSize = 4;
        public static readonly int reflectRCOffset = 32, reflectRCSize = 2;
        public static readonly int reflectRangeOffset = 34, reflectRangeSize = 1;
        public static readonly int reflectAngleOffset = 35, reflectAngleSize = 1;
        public static readonly int damageEffectOffset = 36, damageEffectSize = 1;
        public static readonly int switchOffset = 37, switchSize = 1;
        public static readonly int framesPerHitOffset = 38, framesPerHitSize = 2;
        public static readonly int floorCheckOffset = 40, floorCheckSize = 1;
        public static readonly int driveDrainOffset = 41, driveDrainSize = 1;
        public static readonly int revengeOffset = 42, revengeSize = 1;
        public static readonly int trReactionOffset = 43, trReactionSize = 1;
        public static readonly int comboGroupOffset = 44, comboGroupSize = 1;
        public static readonly int randomEffectOffset = 45, randomEffectSize = 1;
        public static readonly int kindOffset = 46, kindSize = 1;
        public static readonly int hpDrainOffset = 47, hpDrainSize = 1;

        public AtkpItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public AtkpItem(List<byte> rawData) : base(rawData)
        {
        }

        public ushort SubId
        {
            get { return DataAccess.readUShort(raw, subIdOffset, subIdSize); }
            set { DataAccess.writeUShort(raw, value, subIdOffset, subIdSize); }
        }
        public ushort Id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); }
        }
        public byte Type
        {
            get { return DataAccess.readByte(raw, typeOffset); }
            set { DataAccess.writeByte(raw, value, typeOffset); }
        }
        public byte CritAdjust
        {
            get { return DataAccess.readByte(raw, critAdjustOffset); }
            set { DataAccess.writeByte(raw, value, critAdjustOffset); }
        }
        public ushort Power
        {
            get { return DataAccess.readUShort(raw, powerOffset, powerSize); }
            set { DataAccess.writeUShort(raw, value, powerOffset, powerSize); }
        }
        public byte Team
        {
            get { return DataAccess.readByte(raw, teamOffset); }
            set { DataAccess.writeByte(raw, value, teamOffset); }
        }
        public byte Element
        {
            get { return DataAccess.readByte(raw, elementOffset); }
            set { DataAccess.writeByte(raw, value, elementOffset); }
        }
        public byte Knockback
        {
            get { return DataAccess.readByte(raw, knockbackOffset); }
            set { DataAccess.writeByte(raw, value, knockbackOffset); }
        }
        public byte HitEffect
        {
            get { return DataAccess.readByte(raw, hitEffectOffset); }
            set { DataAccess.writeByte(raw, value, hitEffectOffset); }
        }
        public short KnockbackStr1
        {
            get { return DataAccess.readShort(raw, knockbackStr1Offset, knockbackStr1Size); }
            set { DataAccess.writeShort(raw, value, knockbackStr1Offset, knockbackStr1Size); }
        }
        public short KnockbackStr2
        {
            get { return DataAccess.readShort(raw, knockbackStr2Offset, knockbackStr2Size); }
            set { DataAccess.writeShort(raw, value, knockbackStr2Offset, knockbackStr2Size); }
        }
        public string Unk16
        {
            get { return DataAccess.readHexString(raw, unk16Offset, unk16Size); }
            set { DataAccess.writeHexString(raw, value, unk16Offset, unk16Size); }
        }
        public byte Flag
        {
            get { return DataAccess.readByte(raw, flagOffset); }
            set { DataAccess.writeByte(raw, value, flagOffset); }
        }
        public byte RefactSelf
        {
            get { return DataAccess.readByte(raw, refactSelfOffset); }
            set { DataAccess.writeByte(raw, value, refactSelfOffset); }
        }
        public byte RefactOther
        {
            get { return DataAccess.readByte(raw, refactOtherOffset); }
            set { DataAccess.writeByte(raw, value, refactOtherOffset); }
        }
        public byte ReflectMotion
        {
            get { return DataAccess.readByte(raw, reflectMotionOffset); }
            set { DataAccess.writeByte(raw, value, reflectMotionOffset); }
        }
        public short ReflectHitBack
        {
            get { return DataAccess.readShort(raw, reflectHitBackOffset, reflectHitBackSize); }
            set { DataAccess.writeShort(raw, value, reflectHitBackOffset, reflectHitBackSize); }
        }
        public int ReflectAction
        {
            get { return DataAccess.readInt(raw, reflectActionOffset, reflectActionSize); }
            set { DataAccess.writeInt(raw, value, reflectActionOffset, reflectActionSize); }
        }
        public int SoundEffect
        {
            get { return DataAccess.readInt(raw, soundEffectOffset, soundEffectSize); }
            set { DataAccess.writeInt(raw, value, soundEffectOffset, soundEffectSize); }
        }
        public ushort ReflectRC
        {
            get { return DataAccess.readUShort(raw, reflectRCOffset, reflectRCSize); }
            set { DataAccess.writeUShort(raw, value, reflectRCOffset, reflectRCSize); }
        }
        public byte ReflectRange
        {
            get { return DataAccess.readByte(raw, reflectRangeOffset); }
            set { DataAccess.writeByte(raw, value, reflectRangeOffset); }
        }
        public sbyte ReflectAngle
        {
            get { return DataAccess.readSByte(raw, reflectAngleOffset); }
            set { DataAccess.writeSByte(raw, value, reflectAngleOffset); }
        }
        public byte DamageEffect
        {
            get { return DataAccess.readByte(raw, damageEffectOffset); }
            set { DataAccess.writeByte(raw, value, damageEffectOffset); }
        }
        public byte Switch
        {
            get { return DataAccess.readByte(raw, switchOffset); }
            set { DataAccess.writeByte(raw, value, switchOffset); }
        }
        public ushort FramesPerHit
        {
            get { return DataAccess.readUShort(raw, framesPerHitOffset, framesPerHitSize); }
            set { DataAccess.writeUShort(raw, value, framesPerHitOffset, framesPerHitSize); }
        }
        public byte FloorCheck
        {
            get { return DataAccess.readByte(raw, switchOffset); }
            set { DataAccess.writeByte(raw, value, switchOffset); }
        }
        public byte DriveDrain
        {
            get { return DataAccess.readByte(raw, driveDrainOffset); }
            set { DataAccess.writeByte(raw, value, driveDrainOffset); }
        }
        public byte Revenge
        {
            get { return DataAccess.readByte(raw, revengeOffset); }
            set { DataAccess.writeByte(raw, value, revengeOffset); }
        }
        public byte TrReaction
        {
            get { return DataAccess.readByte(raw, trReactionOffset); }
            set { DataAccess.writeByte(raw, value, trReactionOffset); }
        }
        public byte ComboGroup
        {
            get { return DataAccess.readByte(raw, comboGroupOffset); }
            set { DataAccess.writeByte(raw, value, comboGroupOffset); }
        }
        public byte RandomEffect
        {
            get { return DataAccess.readByte(raw, randomEffectOffset); }
            set { DataAccess.writeByte(raw, value, randomEffectOffset); }
        }
        public byte Kind
        {
            get { return DataAccess.readByte(raw, kindOffset); }
            set { DataAccess.writeByte(raw, value, kindOffset); }
        }
        public byte HpDrain
        {
            get { return DataAccess.readByte(raw, hpDrainOffset); }
            set { DataAccess.writeByte(raw, value, hpDrainOffset); }
        }
    }
}
