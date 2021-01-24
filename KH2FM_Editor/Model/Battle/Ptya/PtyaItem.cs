using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Battle.Ptya
{
    public class PtyaItem : Str_EntryItem
    {
        public static readonly int entrySize = 68;
        // Data Location
        public int idOffset = 0, idSize = 1;
        public int typeOffset = 1, typeSize = 1;
        public int subOffset = 2, subSize = 1;
        public int comboOfstOffset = 3, comboOfstSize = 1;
        public int flagOffset = 4, flagSize = 4;
        public int motionOffset = 8, motionSize = 2;
        public int nextMotionOffset = 10, nextMotionSize = 2;
        public int jumpOffset = 12, jumpSize = 4;
        public int jumpMaxOffset = 16, jumpMaxSize = 4;
        public int jumpMinOffset = 20, jumpMinSize = 4;
        public int speedMinOffset = 24, speedMinSize = 4;
        public int speedMaxOffset = 28, speedMaxSize = 4;
        public int nearOffset = 32, nearSize = 4;
        public int farOffset = 36, farSize = 4;
        public int lowOffset = 40, lowSize = 4;
        public int highOffset = 44, highSize = 4;
        public int innerMinOffset = 48, innerMinSize = 4;
        public int innerMaxOffset = 52, innerMaxSize = 4;
        public int blendTimeOffset = 56, blendTimeSize = 4;
        public int distanceAdjustOffset = 60, distanceAdjustSize = 4;
        public int abilityOffset = 64, abilitySize = 2;
        public int scoreOffset = 66, scoreSize = 2;

        public PtyaItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public PtyaItem(List<byte> rawData) : base(rawData)
        {
        }

        public byte Id
        {
            get { return DataAccess.readByte(raw, idOffset); }
            set { DataAccess.writeByte(raw, value, idOffset); }
        }
        public byte Type
        {
            get { return DataAccess.readByte(raw, typeOffset); }
            set { DataAccess.writeByte(raw, value, typeOffset); }
        }
        public sbyte Sub
        {
            get { return DataAccess.readSByte(raw, subOffset); }
            set { DataAccess.writeSByte(raw, value, subOffset); }
        }
        public sbyte ComboOffset
        {
            get { return DataAccess.readSByte(raw, comboOfstOffset); }
            set { DataAccess.writeSByte(raw, value, comboOfstOffset); }
        }
        public uint Flag
        {
            get { return DataAccess.readUInt(raw, flagOffset, flagSize); }
            set { DataAccess.writeUInt(raw, value, flagOffset, flagSize); }
        }
        public string MotionName
        {
            get { return Animations.getSoraAnimation((ushort)(Motion * 4)); }
        }
        public string MotionValue
        {
            get { return "" + Motion * 4; }
        }
        public ushort Motion
        {
            get { return DataAccess.readUShort(raw, motionOffset, motionSize); }
            set { DataAccess.writeUShort(raw, value, motionOffset, motionSize); NotifyPropertyChanged(nameof(MotionValue)); }
        }
        public string NextMotionName
        {
            get { return Animations.getSoraAnimation((ushort)(NextMotion * 4)); }
        }
        public string NextMotionValue
        {
            get { return "" + NextMotion * 4; }
        }
        public ushort NextMotion
        {
            get { return DataAccess.readUShort(raw, nextMotionOffset, nextMotionSize); }
            set { DataAccess.writeUShort(raw, value, nextMotionOffset, nextMotionSize); NotifyPropertyChanged(nameof(NextMotionValue)); }
        }
        public float Jump
        {
            get { return DataAccess.readFloat(raw, jumpOffset, jumpSize); }
            set { DataAccess.writeFloat(raw, value, jumpOffset, jumpSize); }
        }
        public float JumpMax
        {
            get { return DataAccess.readFloat(raw, jumpMaxOffset, jumpMaxSize); }
            set { DataAccess.writeFloat(raw, value, jumpMaxOffset, jumpMaxSize); }
        }
        public float JumpMin
        {
            get { return DataAccess.readFloat(raw, jumpMinOffset, jumpMinSize); }
            set { DataAccess.writeFloat(raw, value, jumpMinOffset, jumpMinSize); }
        }
        public float SpeedMin
        {
            get { return DataAccess.readFloat(raw, speedMinOffset, speedMinSize); }
            set { DataAccess.writeFloat(raw, value, speedMinOffset, speedMinSize); }
        }
        public float SpeedMax
        {
            get { return DataAccess.readFloat(raw, speedMaxOffset, speedMaxSize); }
            set { DataAccess.writeFloat(raw, value, speedMaxOffset, speedMaxSize); }
        }
        public float Near
        {
            get { return DataAccess.readFloat(raw, nearOffset, nearSize); }
            set { DataAccess.writeFloat(raw, value, nearOffset, nearSize); }
        }
        public float Far
        {
            get { return DataAccess.readFloat(raw, farOffset, farSize); }
            set { DataAccess.writeFloat(raw, value, farOffset, farSize); }
        }
        public float Low
        {
            get { return DataAccess.readFloat(raw, lowOffset, lowSize); }
            set { DataAccess.writeFloat(raw, value, lowOffset, lowSize); }
        }
        public float High
        {
            get { return DataAccess.readFloat(raw, highOffset, highSize); }
            set { DataAccess.writeFloat(raw, value, highOffset, highSize); }
        }
        public float InnerMin
        {
            get { return DataAccess.readFloat(raw, innerMinOffset, innerMinSize); }
            set { DataAccess.writeFloat(raw, value, innerMinOffset, innerMinSize); }
        }
        public float InnerMax
        {
            get { return DataAccess.readFloat(raw, innerMaxOffset, innerMaxSize); }
            set { DataAccess.writeFloat(raw, value, innerMaxOffset, innerMaxSize); }
        }
        public float BlendTime
        {
            get { return DataAccess.readFloat(raw, blendTimeOffset, blendTimeSize); }
            set { DataAccess.writeFloat(raw, value, blendTimeOffset, blendTimeSize); }
        }
        public float DistanceAdjust
        {
            get { return DataAccess.readFloat(raw, distanceAdjustOffset, distanceAdjustSize); }
            set { DataAccess.writeFloat(raw, value, distanceAdjustOffset, distanceAdjustSize); }
        }
        public string AbilityValue
        {
            get { return Abilities.getValue(Ability); }
        }
        public ushort Ability
        {
            get { return DataAccess.readUShort(raw, abilityOffset, abilitySize); }
            set { DataAccess.writeUShort(raw, value, abilityOffset, abilitySize); NotifyPropertyChanged(nameof(AbilityValue)); }
        }
        public ushort Score
        {
            get { return DataAccess.readUShort(raw, scoreOffset, scoreSize); }
            set { DataAccess.writeUShort(raw, value, scoreOffset, scoreSize); }
        }
    }
}
