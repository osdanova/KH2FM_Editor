using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Pref.Magi
{
    public class MagiItem : Str_EntryItem
    {
        public static readonly int entrySize = 124;
        public static readonly int floatSize = 4;
        public static readonly int intSize = 4;
        // Data Location
        public int
            fire_radiusOffset = 0,
            fire_heightOffset = 4,
            fire_timeOffset = 8,
            blizzard_fade_timeOffset = 12,
            blizzard_timeOffset = 16,
            blizzard_speedOffset = 20,
            blizzard_radiusOffset = 24,
            blizzard_hitbackOffset = 28,
            thunder_notarget_distOffset = 32,
            thunder_border_heightOffset = 36,
            thunder_notarget_heightOffset = 40,
            thunder_check_heightOffset = 44,
            thunder_burst_radiusOffset = 48,
            thunder_heightOffset = 52,
            thunder_radiusOffset = 56,
            thunder_attack_waitOffset = 60,
            thunder_timeOffset = 64,
            cure_rangeOffset = 68,
            magnet_min_yofsOffset = 72,
            magnet_large_timeOffset = 76,
            magnet_stay_timeOffset = 80,
            magnet_small_timeOffset = 84,
            magnet_radiusOffset = 88,
            reflect_radiusOffset = 92,
            reflect_laser_timeOffset = 96,
            reflect_finish_timeOffset = 100,
            reflect_lv1_radiusOffset = 104,
            reflect_lv1_heightOffset = 108,
            reflect_lv2_countOffset = 112,
            reflect_lv2_radiusOffset = 116,
            reflect_lv2_heightOffset = 120,
            reflect_lv3_countOffset = 124,
            reflect_lv3_radiusOffset = 128,
            reflect_lv3_heightOffset = 132;


        public MagiItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public MagiItem(List<byte> rawData) : base(rawData)
        {
        }

        public float fire_radius
        {
            get { return DataAccess.readFloat(raw, fire_radiusOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, fire_radiusOffset, floatSize); }
        }
        public float fire_height
        {
            get { return DataAccess.readFloat(raw, fire_heightOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, fire_heightOffset, floatSize); }
        }
        public float fire_time
        {
            get { return DataAccess.readFloat(raw, fire_timeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, fire_timeOffset, floatSize); }
        }
        public float blizzard_fade_time
        {
            get { return DataAccess.readFloat(raw, blizzard_fade_timeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, blizzard_fade_timeOffset, floatSize); }
        }
        public float blizzard_time
        {
            get { return DataAccess.readFloat(raw, blizzard_timeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, blizzard_timeOffset, floatSize); }
        }
        public float blizzard_speed
        {
            get { return DataAccess.readFloat(raw, blizzard_speedOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, blizzard_speedOffset, floatSize); }
        }
        public float blizzard_radius
        {
            get { return DataAccess.readFloat(raw, blizzard_radiusOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, blizzard_radiusOffset, floatSize); }
        }
        public float thunder_notarget_dist
        {
            get { return DataAccess.readFloat(raw, thunder_notarget_distOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, thunder_notarget_distOffset, floatSize); }
        }
        public float thunder_border_height
        {
            get { return DataAccess.readFloat(raw, thunder_border_heightOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, thunder_border_heightOffset, floatSize); }
        }
        public float thunder_notarget_height
        {
            get { return DataAccess.readFloat(raw, thunder_notarget_heightOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, thunder_notarget_heightOffset, floatSize); }
        }
        public float thunder_check_height
        {
            get { return DataAccess.readFloat(raw, thunder_check_heightOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, thunder_check_heightOffset, floatSize); }
        }
        public float thunder_burst_radius
        {
            get { return DataAccess.readFloat(raw, thunder_burst_radiusOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, thunder_burst_radiusOffset, floatSize); }
        }
        public float thunder_height
        {
            get { return DataAccess.readFloat(raw, thunder_heightOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, thunder_heightOffset, floatSize); }
        }
        public float thunder_radius
        {
            get { return DataAccess.readFloat(raw, thunder_radiusOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, thunder_radiusOffset, floatSize); }
        }
        public float thunder_attack_wait
        {
            get { return DataAccess.readFloat(raw, thunder_attack_waitOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, thunder_attack_waitOffset, floatSize); }
        }
        public float thunder_time
        {
            get { return DataAccess.readFloat(raw, thunder_timeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, thunder_timeOffset, floatSize); }
        }
        public float cure_range
        {
            get { return DataAccess.readFloat(raw, cure_rangeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, cure_rangeOffset, floatSize); }
        }
        public float magnet_min_yofs
        {
            get { return DataAccess.readFloat(raw, magnet_min_yofsOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, magnet_min_yofsOffset, floatSize); }
        }
        public float magnet_large_time
        {
            get { return DataAccess.readFloat(raw, magnet_large_timeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, magnet_large_timeOffset, floatSize); }
        }
        public float magnet_stay_time
        {
            get { return DataAccess.readFloat(raw, magnet_stay_timeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, magnet_stay_timeOffset, floatSize); }
        }
        public float magnet_small_time
        {
            get { return DataAccess.readFloat(raw, magnet_small_timeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, magnet_small_timeOffset, floatSize); }
        }
        public float magnet_radius
        {
            get { return DataAccess.readFloat(raw, magnet_radiusOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, magnet_radiusOffset, floatSize); }
        }
        public float reflect_radius
        {
            get { return DataAccess.readFloat(raw, reflect_radiusOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, reflect_radiusOffset, floatSize); }
        }
        public float reflect_laser_time
        {
            get { return DataAccess.readFloat(raw, reflect_laser_timeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, reflect_laser_timeOffset, floatSize); }
        }
        public float reflect_finish_time
        {
            get { return DataAccess.readFloat(raw, reflect_finish_timeOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, reflect_finish_timeOffset, floatSize); }
        }
        public float reflect_lv1_radius
        {
            get { return DataAccess.readFloat(raw, reflect_lv1_radiusOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, reflect_lv1_radiusOffset, floatSize); }
        }
        public float reflect_lv1_height
        {
            get { return DataAccess.readFloat(raw, reflect_lv1_heightOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, reflect_lv1_heightOffset, floatSize); }
        }
        public uint reflect_lv2_count
        {
            get { return DataAccess.readUInt(raw, reflect_lv2_countOffset, floatSize); }
            set { DataAccess.writeUInt(raw, value, reflect_lv2_countOffset, floatSize); }
        }
        public float reflect_lv2_radius
        {
            get { return DataAccess.readFloat(raw, reflect_lv2_radiusOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, reflect_lv2_radiusOffset, floatSize); }
        }/*
        public float reflect_lv2_height
        {
            get { return DataAccess.readFloat(raw, reflect_lv2_heightOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, reflect_lv2_heightOffset, floatSize); }
        }
        public uint reflect_lv3_count
        {
            get { return DataAccess.readUInt(raw, reflect_lv3_countOffset, intSize); }
            set { DataAccess.writeUInt(raw, value, reflect_lv3_countOffset, intSize); }
        }
        public float reflect_lv3_radius
        {
            get { return DataAccess.readFloat(raw, reflect_lv3_radiusOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, reflect_lv3_radiusOffset, floatSize); }
        }
        public float reflect_lv3_height
        {
            get { return DataAccess.readFloat(raw, reflect_lv3_heightOffset, floatSize); }
            set { DataAccess.writeFloat(raw, value, reflect_lv3_heightOffset, floatSize); }
        }*/
    }
}
