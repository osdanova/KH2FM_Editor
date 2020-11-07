using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Model.Ard.Script;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Ard.Script
{
    class ArdScriptPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public ArdScriptFile ArdScriptFileLoaded { get; set; }
        //public ObservableCollection<ArdScriptItem> ArdScriptFileItemsSoraRoxas { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }

        public ArdScriptPageHandler(ArdScriptFile file)
        {
            MemOffset = "00000000";
            Console.WriteLine("DEBUG > ArdScriptPageHandler > Processing file...");
            ArdScriptFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > ArdScriptPageHandler > File processed!");
        }
        public void processFile()
        {/*
            Console.WriteLine("DEBUG > ArdScriptPageHandler > Getting file info...");

            ArdScriptFileItemsSoraRoxas = new ObservableCollection<ArdScriptItem>();

            foreach (ArdScriptCharacter character in ArdScriptFileLoaded.Characters)
            {
                foreach (ArdScriptItem entry in character.Entries)
                {
                    if (character.Name == "Sora/Roxas")
                    {
                        ArdScriptFileItemsSoraRoxas.Add(entry);
                    }
                }
            }*/
        }

        public void insertDataToFile()
        {/*
            foreach (ArdScriptCharacter character in ArdScriptFileLoaded.Characters)
            {
                if (character.Name == "Sora/Roxas")
                {
                    character.Entries = new ObservableCollection<Str_EntryItem>();
                    foreach (ArdScriptItem entry in ArdScriptFileItemsSoraRoxas)
                    {
                        character.Entries.Add(entry);
                    }
                }
            }*/
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > ArdScriptPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = ArdScriptFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > ArdScriptPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (ArdScriptFileLoaded == null) return;
            Console.WriteLine("DEBUG > ArdScriptPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > ArdScriptPageHandler > Finished saving!");
        }
    }
}
