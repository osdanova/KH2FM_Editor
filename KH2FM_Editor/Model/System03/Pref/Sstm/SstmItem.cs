using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Pref.Sstm
{
    public class SstmItem : Str_EntryItem
    {
        public static readonly int entrySize = 124;
        public static readonly int floatSize = 4;
        public static readonly int intSize = 4;
        // Data Location
        public int
            CeilingStopOffset = 0,
            CeilingDisableCommandTimeOffset = 4,
            HangRangeHOffset = 8,
            HangRangeLOffset = 12,
            HangRangeXZOffset = 16,
            FallMaxOffset = 20,
            BlowBrakeXZOffset = 24,
            BlowMinXZOffset = 28,
            BlowBrakeUpOffset = 32,
            BlowUpOffset = 36,
            BlowSpeedOffset = 40,
            BlowToHitBackOffset = 44,
            HitBackOffset = 48,
            HitBackSmallOffset = 52,
            HitBackToJumpOffset = 56,
            FlyBlowBrakeOffset = 60,
            FlyBlowStopOffset = 64,
            FlyBlowUpAdjustOffset = 68,
            MagicJumpOffset = 72,
            LockOnRangeOffset = 76,
            LockOnReleaseRangeOffset = 80,
            StunRecovOffset = 84,
            StunRecovHpOffset = 88,
            StunRelaxOffset = 92,
            DriveZakoOffset = 96,
            ChangeTimeZakoOffset = 100,
            DriveTimeOffset = 104,
            DriveTimeRelaxOffset = 108,
            ChangeTimeAddRateOffset = 112,
            ChangeTimeSubRateOffset = 116,
            MpDriveRateOffset = 120,
            MpToMpDriveOffset = 124,
            SummonTimeRelaxOffset = 128,
            SummonPrayTimeOffset = 132,
            SummonPrayTimeSkipOffset = 136,
            AntiFormDriveCountOffset = 140,
            AntiFormSubCountOffset = 144,
            AntiFormDamageRateOffset = 148,
            FinalFormRateOffset = 152,
            FinalFormMulRateOffset = 156,
            FinalFormMaxRateOffset = 160,
            FinalFormSubCountOffset = 164,
            AttackDistToSpeedOffset = 168,
            AlCarpetDashInnerOffset = 172,
            AlCarpetDashDelayOffset = 176,
            AlCarpetDashAccelOffset = 180,
            AlCarpetDashBrakeOffset = 184,
            LkDashDriftInnerOffset = 188,
            LkDashDriftTimeOffset = 192,
            LkDashAccelDriftOffset = 196,
            LkDashAccelStopOffset = 200,
            LkDashDriftSpeedOffset = 204,
            LkMagicJumpOffset = 208,
            MickeyChargeWaitOffset = 212,
            MickeyDownRateOffset = 216,
            MickeyMinRateOffset = 220,
            LmSwimSpeedOffset = 224,
            LmSwimControlOffset = 228,
            LmSwimAccelOffset = 232,
            LmDolphinAccelOffset = 236,
            LmDolphinSpeedMaxOffset = 240,
            LmDolphinSpeedMinOffset = 244,
            LmDolphinSpeedMaxDistOffset = 248,
            LmDolphinSpeedMinDistOffset = 252,
            LmDolphinRotMaxOffset = 256,
            LmDolphinRotDistOffset = 260,
            LmDolphinRotMaxDistOffset = 264,
            LmDolphinDistToTimeOffset = 268,
            LmDolphfloatimeMaxOffset = 272,
            LmDolphfloatimeMinOffset = 276,
            LmDolphinNearSpeedOffset = 280,
            DriveBerserkAttackOffset = 284,
            MpHasteOffset = 288,
            MpHasraOffset = 292,
            MpHasgaOffset = 296,
            DrawRangeOffset = 300,
            ComboDamageUpOffset = 304,
            ReactionDamageUpOffset = 308,
            DamageDriveOffset = 312,
            DriveBoostOffset = 316,
            FormBoostOffset = 320,
            ExpChanceOffset = 324,
            DefenderOffset = 328,
            ElementUpOffset = 332,
            DamageAspilOffset = 336,
            HyperHealOffset = 340,
            CombiBoostOffset = 344,
            PrizeUpOffset = 348,
            LuckUpOffset = 352,
            ItemUpOffset = 356,
            AutoHealOffset = 360,
            SummonBoostOffset = 364,
            DriveConvertOffset = 368,
            DefenceMasterOffset = 372,
            DefenceMasterRatioOffset = 376;


        public SstmItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public SstmItem(List<byte> rawData) : base(rawData)
        {
        }

        public float CeilingStop { get { return DataAccess.readFloat(raw, CeilingStopOffset, floatSize); } set { DataAccess.writeFloat(raw, value, CeilingStopOffset, floatSize); } }
        public float CeilingDisableCommandTime { get { return DataAccess.readFloat(raw, CeilingDisableCommandTimeOffset, floatSize); } set { DataAccess.writeFloat(raw, value, CeilingDisableCommandTimeOffset, floatSize); } }
        public float HangRangeH { get { return DataAccess.readFloat(raw, HangRangeHOffset, floatSize); } set { DataAccess.writeFloat(raw, value, HangRangeHOffset, floatSize); } }
        public float HangRangeL { get { return DataAccess.readFloat(raw, HangRangeLOffset, floatSize); } set { DataAccess.writeFloat(raw, value, HangRangeLOffset, floatSize); } }
        public float HangRangeXZ { get { return DataAccess.readFloat(raw, HangRangeXZOffset, floatSize); } set { DataAccess.writeFloat(raw, value, HangRangeXZOffset, floatSize); } }
        public float FallMax { get { return DataAccess.readFloat(raw, FallMaxOffset, floatSize); } set { DataAccess.writeFloat(raw, value, FallMaxOffset, floatSize); } }
        public float BlowBrakeXZ { get { return DataAccess.readFloat(raw, BlowBrakeXZOffset, floatSize); } set { DataAccess.writeFloat(raw, value, BlowBrakeXZOffset, floatSize); } }
        public float BlowMinXZ { get { return DataAccess.readFloat(raw, BlowMinXZOffset, floatSize); } set { DataAccess.writeFloat(raw, value, BlowMinXZOffset, floatSize); } }
        public float BlowBrakeUp { get { return DataAccess.readFloat(raw, BlowBrakeUpOffset, floatSize); } set { DataAccess.writeFloat(raw, value, BlowBrakeUpOffset, floatSize); } }
        public float BlowUp { get { return DataAccess.readFloat(raw, BlowUpOffset, floatSize); } set { DataAccess.writeFloat(raw, value, BlowUpOffset, floatSize); } }
        public float BlowSpeed { get { return DataAccess.readFloat(raw, BlowSpeedOffset, floatSize); } set { DataAccess.writeFloat(raw, value, BlowSpeedOffset, floatSize); } }
        public float BlowToHitBack { get { return DataAccess.readFloat(raw, BlowToHitBackOffset, floatSize); } set { DataAccess.writeFloat(raw, value, BlowToHitBackOffset, floatSize); } }
        public float HitBack { get { return DataAccess.readFloat(raw, HitBackOffset, floatSize); } set { DataAccess.writeFloat(raw, value, HitBackOffset, floatSize); } }
        public float HitBackSmall { get { return DataAccess.readFloat(raw, HitBackSmallOffset, floatSize); } set { DataAccess.writeFloat(raw, value, HitBackSmallOffset, floatSize); } }
        public float HitBackToJump { get { return DataAccess.readFloat(raw, HitBackToJumpOffset, floatSize); } set { DataAccess.writeFloat(raw, value, HitBackToJumpOffset, floatSize); } }
        public float FlyBlowBrake { get { return DataAccess.readFloat(raw, FlyBlowBrakeOffset, floatSize); } set { DataAccess.writeFloat(raw, value, FlyBlowBrakeOffset, floatSize); } }
        public float FlyBlowStop { get { return DataAccess.readFloat(raw, FlyBlowStopOffset, floatSize); } set { DataAccess.writeFloat(raw, value, FlyBlowStopOffset, floatSize); } }
        public float FlyBlowUpAdjust { get { return DataAccess.readFloat(raw, FlyBlowUpAdjustOffset, floatSize); } set { DataAccess.writeFloat(raw, value, FlyBlowUpAdjustOffset, floatSize); } }
        public float MagicJump { get { return DataAccess.readFloat(raw, MagicJumpOffset, floatSize); } set { DataAccess.writeFloat(raw, value, MagicJumpOffset, floatSize); } }
        public float LockOnRange { get { return DataAccess.readFloat(raw, LockOnRangeOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LockOnRangeOffset, floatSize); } }
        public float LockOnReleaseRange { get { return DataAccess.readFloat(raw, LockOnReleaseRangeOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LockOnReleaseRangeOffset, floatSize); } }
        public float StunRecov { get { return DataAccess.readFloat(raw, StunRecovOffset, floatSize); } set { DataAccess.writeFloat(raw, value, StunRecovOffset, floatSize); } }
        public float StunRecovHp { get { return DataAccess.readFloat(raw, StunRecovHpOffset, floatSize); } set { DataAccess.writeFloat(raw, value, StunRecovHpOffset, floatSize); } }
        public float StunRelax { get { return DataAccess.readFloat(raw, StunRelaxOffset, floatSize); } set { DataAccess.writeFloat(raw, value, StunRelaxOffset, floatSize); } }
        public float DriveZako { get { return DataAccess.readFloat(raw, DriveZakoOffset, floatSize); } set { DataAccess.writeFloat(raw, value, DriveZakoOffset, floatSize); } }
        public float ChangeTimeZako { get { return DataAccess.readFloat(raw, ChangeTimeZakoOffset, floatSize); } set { DataAccess.writeFloat(raw, value, ChangeTimeZakoOffset, floatSize); } }
        public float DriveTime { get { return DataAccess.readFloat(raw, DriveTimeOffset, floatSize); } set { DataAccess.writeFloat(raw, value, DriveTimeOffset, floatSize); } }
        public float DriveTimeRelax { get { return DataAccess.readFloat(raw, DriveTimeRelaxOffset, floatSize); } set { DataAccess.writeFloat(raw, value, DriveTimeRelaxOffset, floatSize); } }
        public float ChangeTimeAddRate { get { return DataAccess.readFloat(raw, ChangeTimeAddRateOffset, floatSize); } set { DataAccess.writeFloat(raw, value, ChangeTimeAddRateOffset, floatSize); } }
        public float ChangeTimeSubRate { get { return DataAccess.readFloat(raw, ChangeTimeSubRateOffset, floatSize); } set { DataAccess.writeFloat(raw, value, ChangeTimeSubRateOffset, floatSize); } }
        public float MpDriveRate { get { return DataAccess.readFloat(raw, MpDriveRateOffset, floatSize); } set { DataAccess.writeFloat(raw, value, MpDriveRateOffset, floatSize); } }
        public float MpToMpDrive { get { return DataAccess.readFloat(raw, MpToMpDriveOffset, floatSize); } set { DataAccess.writeFloat(raw, value, MpToMpDriveOffset, floatSize); } }
        public float SummonTimeRelax { get { return DataAccess.readFloat(raw, SummonTimeRelaxOffset, floatSize); } set { DataAccess.writeFloat(raw, value, SummonTimeRelaxOffset, floatSize); } }
        public float SummonPrayTime { get { return DataAccess.readFloat(raw, SummonPrayTimeOffset, floatSize); } set { DataAccess.writeFloat(raw, value, SummonPrayTimeOffset, floatSize); } }
        public float SummonPrayTimeSkip { get { return DataAccess.readFloat(raw, SummonPrayTimeSkipOffset, floatSize); } set { DataAccess.writeFloat(raw, value, SummonPrayTimeSkipOffset, floatSize); } }
        public uint AntiFormDriveCount { get { return DataAccess.readUInt(raw, AntiFormDriveCountOffset, floatSize); } set { DataAccess.writeUInt(raw, value, AntiFormDriveCountOffset, floatSize); } }
        public uint AntiFormSubCount { get { return DataAccess.readUInt(raw, AntiFormSubCountOffset, floatSize); } set { DataAccess.writeUInt(raw, value, AntiFormSubCountOffset, floatSize); } }
        public float AntiFormDamageRate { get { return DataAccess.readFloat(raw, AntiFormDamageRateOffset, floatSize); } set { DataAccess.writeFloat(raw, value, AntiFormDamageRateOffset, floatSize); } }
        public float FinalFormRate { get { return DataAccess.readFloat(raw, FinalFormRateOffset, floatSize); } set { DataAccess.writeFloat(raw, value, FinalFormRateOffset, floatSize); } }
        public float FinalFormMulRate { get { return DataAccess.readFloat(raw, FinalFormMulRateOffset, floatSize); } set { DataAccess.writeFloat(raw, value, FinalFormMulRateOffset, floatSize); } }
        public float FinalFormMaxRate { get { return DataAccess.readFloat(raw, FinalFormMaxRateOffset, floatSize); } set { DataAccess.writeFloat(raw, value, FinalFormMaxRateOffset, floatSize); } }
        public uint FinalFormSubCount { get { return DataAccess.readUInt(raw, FinalFormSubCountOffset, floatSize); } set { DataAccess.writeUInt(raw, value, FinalFormSubCountOffset, floatSize); } }
        public float AttackDistToSpeed { get { return DataAccess.readFloat(raw, AttackDistToSpeedOffset, floatSize); } set { DataAccess.writeFloat(raw, value, AttackDistToSpeedOffset, floatSize); } }
        public float AlCarpetDashInner { get { return DataAccess.readFloat(raw, AlCarpetDashInnerOffset, floatSize); } set { DataAccess.writeFloat(raw, value, AlCarpetDashInnerOffset, floatSize); } }
        public float AlCarpetDashDelay { get { return DataAccess.readFloat(raw, AlCarpetDashDelayOffset, floatSize); } set { DataAccess.writeFloat(raw, value, AlCarpetDashDelayOffset, floatSize); } }
        public float AlCarpetDashAccel { get { return DataAccess.readFloat(raw, AlCarpetDashAccelOffset, floatSize); } set { DataAccess.writeFloat(raw, value, AlCarpetDashAccelOffset, floatSize); } }
        public float AlCarpetDashBrake { get { return DataAccess.readFloat(raw, AlCarpetDashBrakeOffset, floatSize); } set { DataAccess.writeFloat(raw, value, AlCarpetDashBrakeOffset, floatSize); } }
        public float LkDashDriftInner { get { return DataAccess.readFloat(raw, LkDashDriftInnerOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LkDashDriftInnerOffset, floatSize); } }
        public float LkDashDriftTime { get { return DataAccess.readFloat(raw, LkDashDriftTimeOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LkDashDriftTimeOffset, floatSize); } }
        public float LkDashAccelDrift { get { return DataAccess.readFloat(raw, LkDashAccelDriftOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LkDashAccelDriftOffset, floatSize); } }
        public float LkDashAccelStop { get { return DataAccess.readFloat(raw, LkDashAccelStopOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LkDashAccelStopOffset, floatSize); } }
        public float LkDashDriftSpeed { get { return DataAccess.readFloat(raw, LkDashDriftSpeedOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LkDashDriftSpeedOffset, floatSize); } }
        public float LkMagicJump { get { return DataAccess.readFloat(raw, LkMagicJumpOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LkMagicJumpOffset, floatSize); } }
        public float MickeyChargeWait { get { return DataAccess.readFloat(raw, MickeyChargeWaitOffset, floatSize); } set { DataAccess.writeFloat(raw, value, MickeyChargeWaitOffset, floatSize); } }
        public float MickeyDownRate { get { return DataAccess.readFloat(raw, MickeyDownRateOffset, floatSize); } set { DataAccess.writeFloat(raw, value, MickeyDownRateOffset, floatSize); } }
        public float MickeyMinRate { get { return DataAccess.readFloat(raw, MickeyMinRateOffset, floatSize); } set { DataAccess.writeFloat(raw, value, MickeyMinRateOffset, floatSize); } }
        public float LmSwimSpeed { get { return DataAccess.readFloat(raw, LmSwimSpeedOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LmSwimSpeedOffset, floatSize); } }
        public float LmSwimControl { get { return DataAccess.readFloat(raw, LmSwimControlOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LmSwimControlOffset, floatSize); } }
        public float LmSwimAccel { get { return DataAccess.readFloat(raw, LmSwimAccelOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LmSwimAccelOffset, floatSize); } }
        public float LmDolphinAccel { get { return DataAccess.readFloat(raw, LmDolphinAccelOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LmDolphinAccelOffset, floatSize); } }
        public float LmDolphinSpeedMax { get { return DataAccess.readFloat(raw, LmDolphinSpeedMaxOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LmDolphinSpeedMaxOffset, floatSize); } }
        public float LmDolphinSpeedMin { get { return DataAccess.readFloat(raw, LmDolphinSpeedMinOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LmDolphinSpeedMinOffset, floatSize); } }
        public float LmDolphinSpeedMaxDist { get { return DataAccess.readFloat(raw, LmDolphinSpeedMaxDistOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LmDolphinSpeedMaxDistOffset, floatSize); } }
        public float LmDolphinSpeedMinDist { get { return DataAccess.readFloat(raw, LmDolphinSpeedMinDistOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LmDolphinSpeedMinDistOffset, floatSize); } }
        public float LmDolphinRotMax { get { return DataAccess.readFloat(raw, LmDolphinRotMaxOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LmDolphinRotMaxOffset, floatSize); } }
        public float LmDolphinRotDist { get { return DataAccess.readFloat(raw, LmDolphinRotDistOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LmDolphinRotDistOffset, floatSize); } }
        public float LmDolphinRotMaxDist { get { return DataAccess.readFloat(raw, LmDolphinRotMaxDistOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LmDolphinRotMaxDistOffset, floatSize); } }
        public float LmDolphinDistToTime { get { return DataAccess.readFloat(raw, LmDolphinDistToTimeOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LmDolphinDistToTimeOffset, floatSize); } }
        public float LmDolphfloatimeMax { get { return DataAccess.readFloat(raw, LmDolphfloatimeMaxOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LmDolphfloatimeMaxOffset, floatSize); } }
        public float LmDolphfloatimeMin { get { return DataAccess.readFloat(raw, LmDolphfloatimeMinOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LmDolphfloatimeMinOffset, floatSize); } }
        public float LmDolphinNearSpeed { get { return DataAccess.readFloat(raw, LmDolphinNearSpeedOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LmDolphinNearSpeedOffset, floatSize); } }
        public uint DriveBerserkAttack { get { return DataAccess.readUInt(raw, DriveBerserkAttackOffset, floatSize); } set { DataAccess.writeUInt(raw, value, DriveBerserkAttackOffset, floatSize); } }
        public float MpHaste { get { return DataAccess.readFloat(raw, MpHasteOffset, floatSize); } set { DataAccess.writeFloat(raw, value, MpHasteOffset, floatSize); } }
        public float MpHasra { get { return DataAccess.readFloat(raw, MpHasraOffset, floatSize); } set { DataAccess.writeFloat(raw, value, MpHasraOffset, floatSize); } }
        public float MpHasga { get { return DataAccess.readFloat(raw, MpHasgaOffset, floatSize); } set { DataAccess.writeFloat(raw, value, MpHasgaOffset, floatSize); } }
        public float DrawRange { get { return DataAccess.readFloat(raw, DrawRangeOffset, floatSize); } set { DataAccess.writeFloat(raw, value, DrawRangeOffset, floatSize); } }
        public uint ComboDamageUp { get { return DataAccess.readUInt(raw, ComboDamageUpOffset, floatSize); } set { DataAccess.writeUInt(raw, value, ComboDamageUpOffset, floatSize); } }
        public uint ReactionDamageUp { get { return DataAccess.readUInt(raw, ReactionDamageUpOffset, floatSize); } set { DataAccess.writeUInt(raw, value, ReactionDamageUpOffset, floatSize); } }
        public float DamageDrive { get { return DataAccess.readFloat(raw, DamageDriveOffset, floatSize); } set { DataAccess.writeFloat(raw, value, DamageDriveOffset, floatSize); } }
        public float DriveBoost { get { return DataAccess.readFloat(raw, DriveBoostOffset, floatSize); } set { DataAccess.writeFloat(raw, value, DriveBoostOffset, floatSize); } }
        public float FormBoost { get { return DataAccess.readFloat(raw, FormBoostOffset, floatSize); } set { DataAccess.writeFloat(raw, value, FormBoostOffset, floatSize); } }
        public float ExpChance { get { return DataAccess.readFloat(raw, ExpChanceOffset, floatSize); } set { DataAccess.writeFloat(raw, value, ExpChanceOffset, floatSize); } }
        public uint Defender { get { return DataAccess.readUInt(raw, DefenderOffset, floatSize); } set { DataAccess.writeUInt(raw, value, DefenderOffset, floatSize); } }
        public uint ElementUp { get { return DataAccess.readUInt(raw, ElementUpOffset, floatSize); } set { DataAccess.writeUInt(raw, value, ElementUpOffset, floatSize); } }
        public float DamageAspil { get { return DataAccess.readFloat(raw, DamageAspilOffset, floatSize); } set { DataAccess.writeFloat(raw, value, DamageAspilOffset, floatSize); } }
        public float HyperHeal { get { return DataAccess.readFloat(raw, HyperHealOffset, floatSize); } set { DataAccess.writeFloat(raw, value, HyperHealOffset, floatSize); } }
        public float CombiBoost { get { return DataAccess.readFloat(raw, CombiBoostOffset, floatSize); } set { DataAccess.writeFloat(raw, value, CombiBoostOffset, floatSize); } }
        public float PrizeUp { get { return DataAccess.readFloat(raw, PrizeUpOffset, floatSize); } set { DataAccess.writeFloat(raw, value, PrizeUpOffset, floatSize); } }
        public float LuckUp { get { return DataAccess.readFloat(raw, LuckUpOffset, floatSize); } set { DataAccess.writeFloat(raw, value, LuckUpOffset, floatSize); } }
        public uint ItemUp { get { return DataAccess.readUInt(raw, ItemUpOffset, floatSize); } set { DataAccess.writeUInt(raw, value, ItemUpOffset, floatSize); } }
        public float AutoHeal { get { return DataAccess.readFloat(raw, AutoHealOffset, floatSize); } set { DataAccess.writeFloat(raw, value, AutoHealOffset, floatSize); } }
        public float SummonBoost { get { return DataAccess.readFloat(raw, SummonBoostOffset, floatSize); } set { DataAccess.writeFloat(raw, value, SummonBoostOffset, floatSize); } }
        public float DriveConvert { get { return DataAccess.readFloat(raw, DriveConvertOffset, floatSize); } set { DataAccess.writeFloat(raw, value, DriveConvertOffset, floatSize); } }
        public float DefenceMaster { get { return DataAccess.readFloat(raw, DefenceMasterOffset, floatSize); } set { DataAccess.writeFloat(raw, value, DefenceMasterOffset, floatSize); } }
        public uint DefenceMasterRatio { get { return DataAccess.readUInt(raw, DefenceMasterRatioOffset, floatSize); } set { DataAccess.writeUInt(raw, value, DefenceMasterRatioOffset, floatSize); } }

    }
}
