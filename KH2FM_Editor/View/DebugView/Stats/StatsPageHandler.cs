using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Pcsx2;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.View.DebugView.Stats
{
    class StatsPageHandler
    {
        // OPTIONS
        public int HP_Max { get; set; }
        public string HP_Max_MEM { get; set; }
        public int HP_Max_Size = 4;
        public int HP_Current { get; set; }
        public string HP_Current_MEM { get; set; }
        public int HP_Current_Size = 4;
        public int MP_Max { get; set; }
        public string MP_Max_MEM { get; set; }
        public int MP_Max_Size = 4;
        public int MP_Current { get; set; }
        public string MP_Current_MEM { get; set; }
        public int MP_Current_Size = 4;
        public byte Drive_Max { get; set; }
        public string Drive_Max_MEM { get; set; }
        public int Drive_Max_Size = 1;
        public byte Drive_Current { get; set; }
        public string Drive_Current_MEM { get; set; }
        public int Drive_Current_Size = 1;
        public int Munny { get; set; }
        public string Munny_MEM { get; set; }
        public int Munny_Size = 4;
        public byte AP_Boost { get; set; }
        public string AP_Boost_MEM { get; set; }
        public int AP_Boost_Size = 1;
        public ushort Strength { get; set; }
        public string Strength_MEM { get; set; }
        public int Strength_Size = 2;
        public byte Strength_Boost { get; set; }
        public string Strength_Boost_MEM { get; set; }
        public int Strength_Boost_Size = 1;
        public string Magic_MEM { get; set; }
        public ushort Magic { get; set; }
        public int Magic_Size = 2;
        public byte Magic_Boost { get; set; }
        public string Magic_Boost_MEM { get; set; }
        public int Magic_Boost_Size = 1;
        public ushort Defense { get; set; }
        public string Defense_MEM { get; set; }
        public int Defense_Size = 2;
        public byte Defense_Boost { get; set; }
        public string Defense_Boost_MEM { get; set; }
        public int Defense_Boost_Size = 1;
        public byte PhysRes { get; set; }
        public string PhysRes_MEM { get; set; }
        public int PhysRes_Size = 1;
        public byte FireRes { get; set; }
        public string FireRes_MEM { get; set; }
        public int FireRes_Size = 1;
        public byte BlizRes { get; set; }
        public string BlizRes_MEM { get; set; }
        public int BlizRes_Size = 1;
        public byte ThunRes { get; set; }
        public string ThunRes_MEM { get; set; }
        public int ThunRes_Size = 1;
        public byte DarkRes { get; set; }
        public string DarkRes_MEM { get; set; }
        public int DarkRes_Size = 1;
        public byte NeutRes { get; set; }
        public string NeutRes_MEM { get; set; }
        public int NeutRes_Size = 1;
        public byte GeneRes { get; set; }
        public string GeneRes_MEM { get; set; }
        public int GeneRes_Size = 1;


        public StatsPageHandler()
        {
            Pcsx2Memory.findProcess();
            if(Pcsx2Memory.process_current_Type == Enum.ProcessType.PCSX2)
            {
                // HP_Before_Hit = "21ADE8A8";
                HP_Max_MEM = "21C6C754";
                HP_Current_MEM = "21C6C750";
                MP_Max_MEM = "21C6C8D4";
                MP_Current_MEM = "21C6C8D0";
                Drive_Max_MEM = "21C6C902";
                Drive_Current_MEM = "21C6C901";
                Munny_MEM = "2032DF70";
                AP_Boost_MEM = "2032E028";
                Strength_MEM = "21C6C8D8";
                Strength_Boost_MEM = "2032E029";
                Magic_MEM = "21C6C8DA";
                Magic_Boost_MEM = "2032E02A";
                Defense_MEM = "21C6C8DC";
                Defense_Boost_MEM = "2032E02B";
                PhysRes_MEM = "21C6C8F8";
                FireRes_MEM = "21C6C8F9";
                BlizRes_MEM = "21C6C8FA";
                ThunRes_MEM = "21C6C8FB";
                DarkRes_MEM = "21C6C8FC";
                NeutRes_MEM = "21C6C8FD";
                GeneRes_MEM = "21C6C8FE";
            }
            else if (Pcsx2Memory.process_current_Type == Enum.ProcessType.EGS)
            {
                // HP_Before_Hit = "21ADE8A8";
                HP_Max_MEM = (Pcsx2Memory.startingAddressEGS + 0x2A20C5C).ToString("X12");
                HP_Current_MEM = (Pcsx2Memory.startingAddressEGS + 0x2A20C58).ToString("X12");
                MP_Max_MEM = (Pcsx2Memory.startingAddressEGS + 0x2A20DDC).ToString("X12");
                MP_Current_MEM = (Pcsx2Memory.startingAddressEGS + 0x2A20DD8).ToString("X12");
                Drive_Max_MEM = (Pcsx2Memory.startingAddressEGS + 0x2A20E0A).ToString("X12");
                Drive_Current_MEM = (Pcsx2Memory.startingAddressEGS + 0x2A20E09).ToString("X12");
                Munny_MEM = (Pcsx2Memory.startingAddressEGS + 0x9A94B0).ToString("X12");
                AP_Boost_MEM = (Pcsx2Memory.startingAddressEGS + 0x10E2530).ToString("X12");
                Strength_MEM = (Pcsx2Memory.startingAddressEGS + 0x2A20DE0).ToString("X12");
                Strength_Boost_MEM = (Pcsx2Memory.startingAddressEGS + 0x10E2531).ToString("X12");
                Magic_MEM = (Pcsx2Memory.startingAddressEGS + 0x2A20DE2).ToString("X12");
                Magic_Boost_MEM = (Pcsx2Memory.startingAddressEGS + 0x10E2532).ToString("X12");
                Defense_MEM = (Pcsx2Memory.startingAddressEGS + 0x2A20DE4).ToString("X12");
                Defense_Boost_MEM = (Pcsx2Memory.startingAddressEGS + 0x10E2533).ToString("X12");
                PhysRes_MEM = (Pcsx2Memory.startingAddressEGS + 0x2A20E00).ToString("X12");
                FireRes_MEM = (Pcsx2Memory.startingAddressEGS + 0x2A20E01).ToString("X12");
                BlizRes_MEM = (Pcsx2Memory.startingAddressEGS + 0x2A20E02).ToString("X12");
                ThunRes_MEM = (Pcsx2Memory.startingAddressEGS + 0x2A20E03).ToString("X12");
                DarkRes_MEM = (Pcsx2Memory.startingAddressEGS + 0x2A20E04).ToString("X12");
                NeutRes_MEM = (Pcsx2Memory.startingAddressEGS + 0x2A20E05).ToString("X12");
                GeneRes_MEM = (Pcsx2Memory.startingAddressEGS + 0x2A20E06).ToString("X12");
            }
            act_read();
        }

        public void act_read()
        {
            Console.WriteLine("DEBUG > StatsPageHandler > Reading...");
            HP_Max = BinaryHandler.bytesAsInt(Pcsx2Memory.readPcsx2(long.Parse(HP_Max_MEM, System.Globalization.NumberStyles.HexNumber), HP_Max_Size));
            HP_Current = BinaryHandler.bytesAsInt(Pcsx2Memory.readPcsx2(long.Parse(HP_Current_MEM, System.Globalization.NumberStyles.HexNumber), HP_Current_Size));
            MP_Max = BinaryHandler.bytesAsInt(Pcsx2Memory.readPcsx2(long.Parse(MP_Max_MEM, System.Globalization.NumberStyles.HexNumber), MP_Max_Size));
            MP_Current = BinaryHandler.bytesAsInt(Pcsx2Memory.readPcsx2(long.Parse(MP_Current_MEM, System.Globalization.NumberStyles.HexNumber), MP_Current_Size));
            Drive_Max = Pcsx2Memory.readPcsx2(long.Parse(Drive_Max_MEM, System.Globalization.NumberStyles.HexNumber), Drive_Max_Size)[0];
            Drive_Current = Pcsx2Memory.readPcsx2(long.Parse(Drive_Current_MEM, System.Globalization.NumberStyles.HexNumber), Drive_Current_Size)[0];
            Munny = BinaryHandler.bytesAsInt(Pcsx2Memory.readPcsx2(long.Parse(Munny_MEM, System.Globalization.NumberStyles.HexNumber), Munny_Size));
            AP_Boost = Pcsx2Memory.readPcsx2(long.Parse(AP_Boost_MEM, System.Globalization.NumberStyles.HexNumber), AP_Boost_Size)[0];
            Strength = BinaryHandler.bytesAsUShort(Pcsx2Memory.readPcsx2(long.Parse(Strength_MEM, System.Globalization.NumberStyles.HexNumber), Strength_Size));
            Strength_Boost = Pcsx2Memory.readPcsx2(long.Parse(Strength_Boost_MEM, System.Globalization.NumberStyles.HexNumber), Strength_Boost_Size)[0];
            Magic = BinaryHandler.bytesAsUShort(Pcsx2Memory.readPcsx2(long.Parse(Magic_MEM, System.Globalization.NumberStyles.HexNumber), Magic_Size));
            Magic_Boost = Pcsx2Memory.readPcsx2(long.Parse(Magic_Boost_MEM, System.Globalization.NumberStyles.HexNumber), Magic_Boost_Size)[0];
            Defense = BinaryHandler.bytesAsUShort(Pcsx2Memory.readPcsx2(long.Parse(Defense_MEM, System.Globalization.NumberStyles.HexNumber), Defense_Size));
            Defense_Boost = Pcsx2Memory.readPcsx2(long.Parse(Defense_Boost_MEM, System.Globalization.NumberStyles.HexNumber), Defense_Boost_Size)[0];
            PhysRes = Pcsx2Memory.readPcsx2(long.Parse(PhysRes_MEM, System.Globalization.NumberStyles.HexNumber), PhysRes_Size)[0];
            FireRes = Pcsx2Memory.readPcsx2(long.Parse(FireRes_MEM, System.Globalization.NumberStyles.HexNumber), FireRes_Size)[0];
            BlizRes = Pcsx2Memory.readPcsx2(long.Parse(BlizRes_MEM, System.Globalization.NumberStyles.HexNumber), BlizRes_Size)[0];
            ThunRes = Pcsx2Memory.readPcsx2(long.Parse(ThunRes_MEM, System.Globalization.NumberStyles.HexNumber), ThunRes_Size)[0];
            DarkRes = Pcsx2Memory.readPcsx2(long.Parse(DarkRes_MEM, System.Globalization.NumberStyles.HexNumber), DarkRes_Size)[0];
            NeutRes = Pcsx2Memory.readPcsx2(long.Parse(NeutRes_MEM, System.Globalization.NumberStyles.HexNumber), NeutRes_Size)[0];
            GeneRes = Pcsx2Memory.readPcsx2(long.Parse(GeneRes_MEM, System.Globalization.NumberStyles.HexNumber), GeneRes_Size)[0];
            Console.WriteLine("DEBUG > StatsPageHandler > Finished reading!");
        }

        public void act_write()
        {
            Console.WriteLine("DEBUG > StatsPageHandler > Writing to Pcsx2...");
            Pcsx2Memory.writePcsx2(long.Parse(HP_Max_MEM, System.Globalization.NumberStyles.HexNumber), HP_Max_Size, BinaryHandler.intAsBytes(HP_Max));
            Pcsx2Memory.writePcsx2(long.Parse(HP_Current_MEM, System.Globalization.NumberStyles.HexNumber), HP_Current_Size, BinaryHandler.intAsBytes(HP_Current));
            Pcsx2Memory.writePcsx2(long.Parse(MP_Max_MEM, System.Globalization.NumberStyles.HexNumber), MP_Max_Size, BinaryHandler.intAsBytes(MP_Max));
            Pcsx2Memory.writePcsx2(long.Parse(MP_Current_MEM, System.Globalization.NumberStyles.HexNumber), MP_Current_Size, BinaryHandler.intAsBytes(MP_Current));
            Pcsx2Memory.writePcsx2(long.Parse(Drive_Max_MEM, System.Globalization.NumberStyles.HexNumber), Drive_Max_Size, new List<byte>(new byte[] { Drive_Max }));
            Pcsx2Memory.writePcsx2(long.Parse(Drive_Current_MEM, System.Globalization.NumberStyles.HexNumber), Drive_Current_Size, new List<byte>(new byte[] { Drive_Current }));
            Pcsx2Memory.writePcsx2(long.Parse(Munny_MEM, System.Globalization.NumberStyles.HexNumber), Munny_Size, BinaryHandler.intAsBytes(Munny));
            Pcsx2Memory.writePcsx2(long.Parse(AP_Boost_MEM, System.Globalization.NumberStyles.HexNumber), AP_Boost_Size, new List<byte>(new byte[] { AP_Boost }));
            Pcsx2Memory.writePcsx2(long.Parse(Strength_MEM, System.Globalization.NumberStyles.HexNumber), Strength_Size, BinaryHandler.ushortAsBytes(Strength));
            Pcsx2Memory.writePcsx2(long.Parse(Strength_Boost_MEM, System.Globalization.NumberStyles.HexNumber), Strength_Boost_Size, new List<byte>(new byte[] { Strength_Boost }));
            Pcsx2Memory.writePcsx2(long.Parse(Magic_MEM, System.Globalization.NumberStyles.HexNumber), Magic_Size, BinaryHandler.ushortAsBytes(Magic));
            Pcsx2Memory.writePcsx2(long.Parse(Magic_Boost_MEM, System.Globalization.NumberStyles.HexNumber), Magic_Boost_Size, new List<byte>(new byte[] { Magic_Boost }));
            Pcsx2Memory.writePcsx2(long.Parse(Defense_MEM, System.Globalization.NumberStyles.HexNumber), Defense_Size, BinaryHandler.ushortAsBytes(Defense));
            Pcsx2Memory.writePcsx2(long.Parse(Defense_Boost_MEM, System.Globalization.NumberStyles.HexNumber), Defense_Boost_Size, new List<byte>(new byte[] { Defense_Boost }));
            Pcsx2Memory.writePcsx2(long.Parse(PhysRes_MEM, System.Globalization.NumberStyles.HexNumber), PhysRes_Size, new List<byte>(new byte[] { PhysRes }));
            Pcsx2Memory.writePcsx2(long.Parse(FireRes_MEM, System.Globalization.NumberStyles.HexNumber), FireRes_Size, new List<byte>(new byte[] { FireRes }));
            Pcsx2Memory.writePcsx2(long.Parse(BlizRes_MEM, System.Globalization.NumberStyles.HexNumber), BlizRes_Size, new List<byte>(new byte[] { BlizRes }));
            Pcsx2Memory.writePcsx2(long.Parse(ThunRes_MEM, System.Globalization.NumberStyles.HexNumber), ThunRes_Size, new List<byte>(new byte[] { ThunRes }));
            Pcsx2Memory.writePcsx2(long.Parse(DarkRes_MEM, System.Globalization.NumberStyles.HexNumber), DarkRes_Size, new List<byte>(new byte[] { DarkRes }));
            Pcsx2Memory.writePcsx2(long.Parse(NeutRes_MEM, System.Globalization.NumberStyles.HexNumber), NeutRes_Size, new List<byte>(new byte[] { NeutRes }));
            Pcsx2Memory.writePcsx2(long.Parse(GeneRes_MEM, System.Globalization.NumberStyles.HexNumber), GeneRes_Size, new List<byte>(new byte[] { GeneRes }));
            Console.WriteLine("DEBUG > StatsPageHandler > Finished writing!");
        }
    }
}
