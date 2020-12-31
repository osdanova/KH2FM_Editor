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
        public static readonly int pierceOffset = 4, pierceSize = 1;
        public static readonly int damageReductionOffset = 5, damageReductionSize = 1;
        public static readonly int powerOffset = 6, powerSize = 2;
        public static readonly int targetOffset = 8, targetSize = 1;
        public static readonly int elementOffset = 9, elementSize = 1;
        public static readonly int knockbackOffset = 10, knockbackSize = 1;
        public static readonly int hitEffectOffset = 11, hitEffectSize = 1;
        public static readonly int knockbackStr1Offset = 12, knockbackStr1Size = 2;
        public static readonly int knockbackStr2Offset = 14, knockbackStr2Size = 2;
        public static readonly int unk16Offset = 16, unk16Size = 2;
        public static readonly int typeOffset = 18, typeSize = 1;
        public static readonly int unk19Offset = 19, unk19Size = 2;
        public static readonly int deflectedMotionOffset = 21, deflectedMotionSize = 1;
        public static readonly int unk22Offset = 22, unk22Size = 2;
        public static readonly int unk24Offset = 24, unk24Size = 2;
        public static readonly int unk26Offset = 26, unk26Size = 2;
        public static readonly int soundEffectOffset = 28, soundEffectSize = 4;
        public static readonly int unk32Offset = 32, unk32Size = 2;
        public static readonly int unk34Offset = 34, unk34Size = 1;
        public static readonly int unk35Offset = 35, unk35Size = 1;
        public static readonly int unk36Offset = 36, unk36Size = 1;
        public static readonly int unk37Offset = 37, unk37Size = 1;
        public static readonly int framesPerHitOffset = 38, framesPerHitSize = 1;
        public static readonly int unk39Offset = 39, unk39Size = 2;
        public static readonly int driveDrainOffset = 41, driveDrainSize = 1;
        public static readonly int revengeOffset = 42, revengeSize = 1;
        public static readonly int unk43Offset = 43, unk43Size = 1;
        public static readonly int unk44Offset = 44, unk44Size = 1;
        public static readonly int unk45Offset = 45, unk45Size = 1;
        public static readonly int unk46Offset = 46, unk46Size = 1;
        public static readonly int hpDrainOffset = 47, hpDrainSize = 1;

        public AtkpItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public AtkpItem(List<byte> rawData) : base(rawData)
        {
        }

        public string SubId
        {
            get { return DataAccess.readHexString(raw, subIdOffset, subIdSize); }
            set { DataAccess.writeHexString(raw, value, subIdOffset, subIdSize); }
        }
        public ushort Id
        {
            get { return DataAccess.readUShort(raw, idOffset, idSize); }
            set { DataAccess.writeUShort(raw, value, idOffset, idSize); }
        }
        public byte Pierce
        {
            get { return DataAccess.readByte(raw, pierceOffset); }
            set { DataAccess.writeByte(raw, value, pierceOffset); }
        }
        public byte DamageReduction
        {
            get { return DataAccess.readByte(raw, damageReductionOffset); }
            set { DataAccess.writeByte(raw, value, damageReductionOffset); }
        }
        public ushort Power
        {
            get { return DataAccess.readUShort(raw, powerOffset, powerSize); }
            set { DataAccess.writeUShort(raw, value, powerOffset, powerSize); }
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
        public byte Type
        {
            get { return DataAccess.readByte(raw, typeOffset); }
            set { DataAccess.writeByte(raw, value, typeOffset); }
        }
        public string Unk19
        {
            get { return DataAccess.readHexString(raw, unk19Offset, unk19Size); }
            set { DataAccess.writeHexString(raw, value, unk19Offset, unk19Size); }
        }
        public byte DeflectedMotion
        {
            get { return DataAccess.readByte(raw, deflectedMotionOffset); }
            set { DataAccess.writeByte(raw, value, deflectedMotionOffset); }
        }
        public string Unk22
        {
            get { return DataAccess.readHexString(raw, unk22Offset, unk22Size); }
            set { DataAccess.writeHexString(raw, value, unk22Offset, unk22Size); }
        }
        public string Unk24
        {
            get { return DataAccess.readHexString(raw, unk24Offset, unk24Size); }
            set { DataAccess.writeHexString(raw, value, unk24Offset, unk24Size); }
        }
        public string Unk26
        {
            get { return DataAccess.readHexString(raw, unk26Offset, unk26Size); }
            set { DataAccess.writeHexString(raw, value, unk26Offset, unk26Size); }
        }
        public string SoundEffect
        {
            get { return DataAccess.readHexString(raw, soundEffectOffset, soundEffectSize); }
            set { DataAccess.writeHexString(raw, value, soundEffectOffset, soundEffectSize); }
        }
        public string Unk32
        {
            get { return DataAccess.readHexString(raw, unk32Offset, unk32Size); }
            set { DataAccess.writeHexString(raw, value, unk32Offset, unk32Size); }
        }
        public string Unk34
        {
            get { return DataAccess.readHexString(raw, unk34Offset, unk34Size); }
            set { DataAccess.writeHexString(raw, value, unk34Offset, unk34Size); }
        }
        public string Unk35
        {
            get { return DataAccess.readHexString(raw, unk35Offset, unk35Size); }
            set { DataAccess.writeHexString(raw, value, unk35Offset, unk35Size); }
        }
        public string Unk36
        {
            get { return DataAccess.readHexString(raw, unk36Offset, unk36Size); }
            set { DataAccess.writeHexString(raw, value, unk36Offset, unk36Size); }
        }
        public string Unk37
        {
            get { return DataAccess.readHexString(raw, unk37Offset, unk37Size); }
            set { DataAccess.writeHexString(raw, value, unk37Offset, unk37Size); }
        }
        public byte FramesPerHit
        {
            get { return DataAccess.readByte(raw, framesPerHitOffset); }
            set { DataAccess.writeByte(raw, value, framesPerHitOffset); }
        }
        public string Unk39
        {
            get { return DataAccess.readHexString(raw, unk39Offset, unk39Size); }
            set { DataAccess.writeHexString(raw, value, unk39Offset, unk39Size); }
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
        public string Unk43
        {
            get { return DataAccess.readHexString(raw, unk43Offset, unk43Size); }
            set { DataAccess.writeHexString(raw, value, unk43Offset, unk43Size); }
        }
        public string Unk44
        {
            get { return DataAccess.readHexString(raw, unk44Offset, unk44Size); }
            set { DataAccess.writeHexString(raw, value, unk44Offset, unk44Size); }
        }
        public string Unk45
        {
            get { return DataAccess.readHexString(raw, unk45Offset, unk45Size); }
            set { DataAccess.writeHexString(raw, value, unk45Offset, unk45Size); }
        }
        public string Unk46
        {
            get { return DataAccess.readHexString(raw, unk46Offset, unk46Size); }
            set { DataAccess.writeHexString(raw, value, unk46Offset, unk46Size); }
        }
        public byte HpDrain
        {
            get { return DataAccess.readByte(raw, hpDrainOffset); }
            set { DataAccess.writeByte(raw, value, hpDrainOffset); }
        }
    }
}
