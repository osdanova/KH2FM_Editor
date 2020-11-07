using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Model.Ard.Spawn;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Ard.Spawn
{
    class ArdSpawnPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public SpawnFile ArdSpawnFileLoaded { get; set; }
        //public ObservableCollection<ArdSpawnItem> ArdSpawnFileItemsSoraRoxas { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }

        public ArdSpawnPageHandler(SpawnFile file)
        {
            MemOffset = "00000000";
            Console.WriteLine("DEBUG > ArdSpawnPageHandler > Processing file...");
            ArdSpawnFileLoaded = file;
            //processFile();
            Console.WriteLine("DEBUG > ArdSpawnPageHandler > File processed!");
        }
        public void processFile()
        {/*
            Console.WriteLine("DEBUG > ArdSpawnPageHandler > Getting file info...");

            ArdSpawnFileItemsSoraRoxas = new ObservableCollection<ArdSpawnItem>();

            foreach (ArdSpawnCharacter character in ArdSpawnFileLoaded.Characters)
            {
                foreach (ArdSpawnItem entry in character.Entries)
                {
                    if (character.Name == "Sora/Roxas")
                    {
                        ArdSpawnFileItemsSoraRoxas.Add(entry);
                    }
                }
            }*/
        }

        public void insertDataToFile()
        {/*
            foreach (ArdSpawnCharacter character in ArdSpawnFileLoaded.Characters)
            {
                if (character.Name == "Sora/Roxas")
                {
                    character.Entries = new ObservableCollection<Str_EntryItem>();
                    foreach (ArdSpawnItem entry in ArdSpawnFileItemsSoraRoxas)
                    {
                        character.Entries.Add(entry);
                    }
                }
            }*/
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > ArdSpawnPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = ArdSpawnFileLoaded.getAsByteList();
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > ArdSpawnPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (ArdSpawnFileLoaded == null) return;
            Console.WriteLine("DEBUG > ArdSpawnPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > ArdSpawnPageHandler > Finished saving!");
        }
    }
}
