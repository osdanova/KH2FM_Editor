using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Pref.Prty
{
    public class PrtyItem : Str_EntryItem
    {
        public static readonly int entrySize = 52;
        public int position = -1;
        // Data Location
        public int walkSpeedffset = 0, walkSpeedSize = 4;
        public int runSpeedOffset = 4, runSpeedSize = 4;
        public int jumpHeightOffset = 8, jumpHeightSize = 4;
        public int turnSpeedOffset = 12, turnSpeedSize = 4;
        public int hangHeightOffset = 16, hangHeightSize = 4;
        public int hangMarginOffset = 20, hangMarginSize = 4;
        public int stunTimeOffset = 24, stunTimeSize = 4;
        public int mpDriveOffset = 28, mpDriveSize = 4;
        public int upDownSpeedOffset = 32, upDownSpeedSize = 4;
        public int dashSpeedOffset = 36, dashSpeedSize = 4;
        public int accelOffset = 40, accelSize = 4;
        public int brakeOffset = 44, brakeSize = 4;
        public int subjectiveOffset = 48, subjectiveSize = 4;

        public PrtyItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public PrtyItem(List<byte> rawData) : base(rawData)
        {
        }
        public PrtyItem(int position, List<byte> rawData) : base(rawData)
        {
            this.position = position;
        }

        public string Entity
        {
            get { return PrefsDictionary.getPrty(position); }
        }
        public float WalkSpeed
        {
            get { return DataAccess.readFloat(raw, walkSpeedffset, walkSpeedSize); }
            set { DataAccess.writeFloat(raw, value, walkSpeedffset, walkSpeedSize); }
        }
        public float RunSpeed
        {
            get { return DataAccess.readFloat(raw, runSpeedOffset, runSpeedSize); }
            set { DataAccess.writeFloat(raw, value, runSpeedOffset, runSpeedSize); }
        }
        public float JumpHeight
        {
            get { return DataAccess.readFloat(raw, jumpHeightOffset, jumpHeightSize); }
            set { DataAccess.writeFloat(raw, value, jumpHeightOffset, jumpHeightSize); }
        }
        public float TurnSpeed
        {
            get { return DataAccess.readFloat(raw, turnSpeedOffset, turnSpeedSize); }
            set { DataAccess.writeFloat(raw, value, turnSpeedOffset, turnSpeedSize); }
        }
        public float HangHeight
        {
            get { return DataAccess.readFloat(raw, hangHeightOffset, hangHeightSize); }
            set { DataAccess.writeFloat(raw, value, hangHeightOffset, hangHeightSize); }
        }
        public float HangMargin
        {
            get { return DataAccess.readFloat(raw, hangMarginOffset, hangMarginSize); }
            set { DataAccess.writeFloat(raw, value, hangMarginOffset, hangMarginSize); }
        }
        public float StunTime
        {
            get { return DataAccess.readFloat(raw, stunTimeOffset, stunTimeSize); }
            set { DataAccess.writeFloat(raw, value, stunTimeOffset, stunTimeSize); }
        }
        public float MPDrive
        {
            get { return DataAccess.readFloat(raw, mpDriveOffset, mpDriveSize); }
            set { DataAccess.writeFloat(raw, value, mpDriveOffset, mpDriveSize); }
        }
        public float UpDownSpeed
        {
            get { return DataAccess.readFloat(raw, upDownSpeedOffset, upDownSpeedSize); }
            set { DataAccess.writeFloat(raw, value, upDownSpeedOffset, upDownSpeedSize); }
        }
        public float DashSpeed
        {
            get { return DataAccess.readFloat(raw, dashSpeedOffset, dashSpeedSize); }
            set { DataAccess.writeFloat(raw, value, dashSpeedOffset, dashSpeedSize); }
        }
        public float Accel
        {
            get { return DataAccess.readFloat(raw, accelOffset, accelSize); }
            set { DataAccess.writeFloat(raw, value, accelOffset, accelSize); }
        }
        public float Brake
        {
            get { return DataAccess.readFloat(raw, brakeOffset, brakeSize); }
            set { DataAccess.writeFloat(raw, value, brakeOffset, brakeSize); }
        }
        public float Subjective
        {
            get { return DataAccess.readFloat(raw, subjectiveOffset, subjectiveSize); }
            set { DataAccess.writeFloat(raw, value, subjectiveOffset, subjectiveSize); }
        }
    }
}
