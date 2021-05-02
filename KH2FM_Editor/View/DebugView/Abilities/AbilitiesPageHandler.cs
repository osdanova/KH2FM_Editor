using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Model.DebugModel;
using System;
using System.Collections.ObjectModel;
using static KH2FM_Editor.Model.DebugModel.AbilitiesFile;

namespace KH2FM_Editor.View.DebugView.Abilities
{
    public class AbilitiesPageHandler
    {
        // DATA
        public AbilitiesFile AbilityFileLoaded { get; set; }
        public ObservableCollection<Ability> AbilitiesCopy { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }
        public string AbilityCount { get; set; }

        public AbilitiesPageHandler()
        {
            Pcsx2Memory.findProcess();
            if (Pcsx2Memory.process_current_Type == Enum.ProcessType.PCSX2)
            {
                MemOffset = "2032E074";
            }
            else if (Pcsx2Memory.process_current_Type == Enum.ProcessType.EGS)
            {
                MemOffset = (Pcsx2Memory.startingAddressEGS + 0x9A95B4).ToString("X12");
            }

            AbilityCount = "96";
            Console.WriteLine("DEBUG > AbilitiesPageHandler > Processing file...");
            AbilityFileLoaded = new AbilitiesFile();
            act_read();
            Console.WriteLine("DEBUG > AbilitiesPageHandler > File processed!");
        }

        public void act_read()
        {
            if (AbilityFileLoaded == null) return;
            Console.WriteLine("DEBUG > AbilitiesPageHandler > Reading...");
            AbilityFileLoaded.readData(Pcsx2Memory.readPcsx2(long.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), Int32.Parse(AbilityCount) * 2), Int32.Parse(AbilityCount));
            AbilitiesCopy = AbilityFileLoaded.Abilities;
            Console.WriteLine("DEBUG > AbilitiesPageHandler > Finished reading!");
        }

        public void act_write()
        {
            Console.WriteLine("DEBUG > AbilitiesPageHandler > Writing to Pcsx2...");
            Pcsx2Memory.writePcsx2(long.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), Int32.Parse(AbilityCount) * 2, AbilityFileLoaded.getData());
            Console.WriteLine("DEBUG > AbilitiesPageHandler > Finished writing!");
        }
    }
}
