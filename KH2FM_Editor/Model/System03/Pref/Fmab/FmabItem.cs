using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Pref.Fmab
{
    public class FmabItem : Str_EntryItem
    {
        public static readonly int entrySize = 68;
        public static readonly int floatSize = 4;
        // Data Location
        public int
            HighJumpHeightOffset = 0,
            AirDodgeHeightOffset = 4,
            AirDodgeSpeedOffset = 8,
            AirSlideTimeOffset = 12,
            AirSlideSpeedOffset = 16,
            AirSlideBrakeOffset = 20,
            AirSlideStopBrakeOffset = 24,
            AirSlideStarTimeOffset = 28,
            GlideSpeedOffset = 32,
            GlideFallRatioOffset = 36,
            GlideFallHeightOffset = 40,
            GlideFallMaxOffset = 44,
            GlideAccelOffset = 48,
            GlideStartHeightOffset = 52,
            GlideEndHeightOffset = 56,
            GlideTurnSpeedOffset = 60,
            DodgeRollStarTimeOffset = 64;

        public FmabItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public FmabItem(List<byte> rawData) : base(rawData)
        {
        }

        public float HighJumpHeight
        {
            get { return DataAccess.readFloat(raw, HighJumpHeightOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, HighJumpHeightOffset, floatSize); }
        }
        public float AirDodgeHeight
        {
            get { return DataAccess.readFloat(raw, AirDodgeHeightOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AirDodgeHeightOffset, floatSize); }
        }
        public float AirDodgeSpeed
        {
            get { return DataAccess.readFloat(raw, AirDodgeSpeedOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AirDodgeSpeedOffset, floatSize); }
        }
        public float AirSlideTime
        {
            get { return DataAccess.readFloat(raw, AirSlideTimeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AirSlideTimeOffset, floatSize); }
        }
        public float AirSlideSpeed
        {
            get { return DataAccess.readFloat(raw, AirSlideSpeedOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AirSlideSpeedOffset, floatSize); }
        }
        public float AirSlideBrake
        {
            get { return DataAccess.readFloat(raw, AirSlideBrakeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AirSlideBrakeOffset, floatSize); }
        }
        public float AirSlideStopBrake
        {
            get { return DataAccess.readFloat(raw, AirSlideStopBrakeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AirSlideStopBrakeOffset, floatSize); }
        }
        public float AirSlideStarTime
        {
            get { return DataAccess.readFloat(raw, AirSlideStarTimeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, AirSlideStarTimeOffset, floatSize); }
        }
        public float GlideSpeed
        {
            get { return DataAccess.readFloat(raw, GlideSpeedOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, GlideSpeedOffset, floatSize); }
        }
        public float GlideFallRatio
        {
            get { return DataAccess.readFloat(raw, GlideFallRatioOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, GlideFallRatioOffset, floatSize); }
        }
        public float GlideFallHeight
        {
            get { return DataAccess.readFloat(raw, GlideFallHeightOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, GlideFallHeightOffset, floatSize); }
        }
        public float GlideFallMax
        {
            get { return DataAccess.readFloat(raw, GlideFallMaxOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, GlideFallMaxOffset, floatSize); }
        }
        public float GlideAccel
        {
            get { return DataAccess.readFloat(raw, GlideAccelOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, GlideAccelOffset, floatSize); }
        }
        public float GlideStartHeight
        {
            get { return DataAccess.readFloat(raw, GlideStartHeightOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, GlideStartHeightOffset, floatSize); }
        }
        public float GlideEndHeight
        {
            get { return DataAccess.readFloat(raw, GlideEndHeightOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, GlideEndHeightOffset, floatSize); }
        }
        public float GlideTurnSpeed
        {
            get { return DataAccess.readFloat(raw, GlideTurnSpeedOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, GlideTurnSpeedOffset, floatSize); }
        }
        public float DodgeRollStarTime
        {
            get { return DataAccess.readFloat(raw, DodgeRollStarTimeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, DodgeRollStarTimeOffset, floatSize); }
        }

    }
}
