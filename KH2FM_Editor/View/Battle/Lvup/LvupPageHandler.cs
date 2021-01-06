using KH2FM_Editor.Libs.Pcsx2;
using KH2FM_Editor.Model.Battle.Lvup;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.View.Battle.Lvup
{
    class LvupPageHandler
    {
        // DATA
        //String FileName { get; set; }
        //String FilePath { get; set; }
        public LvupFile LvupFileLoaded { get; set; }
        public ObservableCollection<LvupItem> LvupFileItemsSoraRoxas { get; set; }
        public ObservableCollection<LvupItem> LvupFileItemsDonald { get; set; }
        public ObservableCollection<LvupItem> LvupFileItemsGoofy { get; set; }
        public ObservableCollection<LvupItem> LvupFileItemsMickey { get; set; }
        public ObservableCollection<LvupItem> LvupFileItemsAuron { get; set; }
        public ObservableCollection<LvupItem> LvupFileItemsPingMulan { get; set; }
        public ObservableCollection<LvupItem> LvupFileItemsAladdin { get; set; }
        public ObservableCollection<LvupItem> LvupFileItemsSparrow { get; set; }
        public ObservableCollection<LvupItem> LvupFileItemsBeast { get; set; }
        public ObservableCollection<LvupItem> LvupFileItemsJack { get; set; }
        public ObservableCollection<LvupItem> LvupFileItemsSimba { get; set; }
        public ObservableCollection<LvupItem> LvupFileItemsTron { get; set; }
        public ObservableCollection<LvupItem> LvupFileItemsRiku { get; set; }

        // OPTIONS
        public string MemOffset { get; set; }

        public LvupPageHandler(LvupFile file)
        {
            MemOffset = "21D0B6A4";
            Console.WriteLine("DEBUG > LvupPageHandler > Processing file...");
            LvupFileLoaded = file;
            processFile();
            Console.WriteLine("DEBUG > LvupPageHandler > File processed!");
        }
        public void processFile()
        {
            Console.WriteLine("DEBUG > LvupPageHandler > Getting file info...");

            LvupFileItemsSoraRoxas = new ObservableCollection<LvupItem>();
            LvupFileItemsDonald = new ObservableCollection<LvupItem>();
            LvupFileItemsGoofy = new ObservableCollection<LvupItem>();
            LvupFileItemsMickey = new ObservableCollection<LvupItem>();
            LvupFileItemsAuron = new ObservableCollection<LvupItem>();
            LvupFileItemsPingMulan = new ObservableCollection<LvupItem>();
            LvupFileItemsAladdin = new ObservableCollection<LvupItem>();
            LvupFileItemsSparrow = new ObservableCollection<LvupItem>();
            LvupFileItemsBeast = new ObservableCollection<LvupItem>();
            LvupFileItemsJack = new ObservableCollection<LvupItem>();
            LvupFileItemsSimba = new ObservableCollection<LvupItem>();
            LvupFileItemsTron = new ObservableCollection<LvupItem>();
            LvupFileItemsRiku = new ObservableCollection<LvupItem>();

            foreach (LvupCharacter character in LvupFileLoaded.Characters)
            {
                foreach(LvupItem entry in character.Entries)
                {
                    if(character.Name == "Sora/Roxas")
                    {
                        LvupFileItemsSoraRoxas.Add(entry);
                    }
                    if (character.Name == "Donald")
                    {
                        LvupFileItemsDonald.Add(entry);
                    }
                    if (character.Name == "Goofy")
                    {
                        LvupFileItemsGoofy.Add(entry);
                    }
                    if (character.Name == "Mickey")
                    {
                        LvupFileItemsMickey.Add(entry);
                    }
                    if (character.Name == "Auron")
                    {
                        LvupFileItemsAuron.Add(entry);
                    }
                    if (character.Name == "Ping/Mulan")
                    {
                        LvupFileItemsPingMulan.Add(entry);
                    }
                    if (character.Name == "Aladdin")
                    {
                        LvupFileItemsAladdin.Add(entry);
                    }
                    if (character.Name == "Sparrow")
                    {
                        LvupFileItemsSparrow.Add(entry);
                    }
                    if (character.Name == "Beast")
                    {
                        LvupFileItemsBeast.Add(entry);
                    }
                    if (character.Name == "Jack")
                    {
                        LvupFileItemsJack.Add(entry);
                    }
                    if (character.Name == "Simba")
                    {
                        LvupFileItemsSimba.Add(entry);
                    }
                    if (character.Name == "Tron")
                    {
                        LvupFileItemsTron.Add(entry);
                    }
                    if (character.Name == "Riku")
                    {
                        LvupFileItemsRiku.Add(entry);
                    }
                }
            }
        }

        public void insertDataToFile()
        {
            foreach (LvupCharacter character in LvupFileLoaded.Characters)
            {
                if (character.Name == "Sora/Roxas")
                {
                    character.Entries = new ObservableCollection<Str_EntryItem>();
                    foreach (LvupItem entry in LvupFileItemsSoraRoxas)
                    {
                        character.Entries.Add(entry);
                    }
                }
                if (character.Name == "Donald")
                {
                    character.Entries = new ObservableCollection<Str_EntryItem>();
                    foreach (LvupItem entry in LvupFileItemsDonald)
                    {
                        character.Entries.Add(entry);
                    }
                }
                if (character.Name == "Goofy")
                {
                    character.Entries = new ObservableCollection<Str_EntryItem>();
                    foreach (LvupItem entry in LvupFileItemsGoofy)
                    {
                        character.Entries.Add(entry);
                    }
                }
                if (character.Name == "Mickey")
                {
                    character.Entries = new ObservableCollection<Str_EntryItem>();
                    foreach (LvupItem entry in LvupFileItemsMickey)
                    {
                        character.Entries.Add(entry);
                    }
                }
                if (character.Name == "Auron")
                {
                    character.Entries = new ObservableCollection<Str_EntryItem>();
                    foreach (LvupItem entry in LvupFileItemsAuron)
                    {
                        character.Entries.Add(entry);
                    }
                }
                if (character.Name == "Ping/Mulan")
                {
                    character.Entries = new ObservableCollection<Str_EntryItem>();
                    foreach (LvupItem entry in LvupFileItemsPingMulan)
                    {
                        character.Entries.Add(entry);
                    }
                }
                if (character.Name == "Aladdin")
                {
                    character.Entries = new ObservableCollection<Str_EntryItem>();
                    foreach (LvupItem entry in LvupFileItemsAladdin)
                    {
                        character.Entries.Add(entry);
                    }
                }
                if (character.Name == "Sparrow")
                {
                    character.Entries = new ObservableCollection<Str_EntryItem>();
                    foreach (LvupItem entry in LvupFileItemsSparrow)
                    {
                        character.Entries.Add(entry);
                    }
                }
                if (character.Name == "Beast")
                {
                    character.Entries = new ObservableCollection<Str_EntryItem>();
                    foreach (LvupItem entry in LvupFileItemsBeast)
                    {
                        character.Entries.Add(entry);
                    }
                }
                if (character.Name == "Jack")
                {
                    character.Entries = new ObservableCollection<Str_EntryItem>();
                    foreach (LvupItem entry in LvupFileItemsJack)
                    {
                        character.Entries.Add(entry);
                    }
                }
                if (character.Name == "Simba")
                {
                    character.Entries = new ObservableCollection<Str_EntryItem>();
                    foreach (LvupItem entry in LvupFileItemsSimba)
                    {
                        character.Entries.Add(entry);
                    }
                }
                if (character.Name == "Tron")
                {
                    character.Entries = new ObservableCollection<Str_EntryItem>();
                    foreach (LvupItem entry in LvupFileItemsTron)
                    {
                        character.Entries.Add(entry);
                    }
                }
                if (character.Name == "Riku")
                {
                    character.Entries = new ObservableCollection<Str_EntryItem>();
                    foreach (LvupItem entry in LvupFileItemsRiku)
                    {
                        character.Entries.Add(entry);
                    }
                }
            }
        }

        public void act_testData()
        {
            Console.WriteLine("DEBUG > LvupPageHandler > Writing to Pcsx2...");
            // For whenever an entry is added
            //insertDataToFile();
            List<byte> fileToWrite = LvupFileLoaded.getAsByteList();
            Console.WriteLine("DEBUG > LvupPageHandler > Writing "+fileToWrite.Count+" bytes at address: " + int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber));
            Pcsx2Memory.writePcsx2(int.Parse(MemOffset, System.Globalization.NumberStyles.HexNumber), fileToWrite.Count, fileToWrite);
            Console.WriteLine("DEBUG > LvupPageHandler > Finished writing!");
        }

        public void act_save()
        {
            if (LvupFileLoaded == null) return;
            Console.WriteLine("DEBUG > LvupPageHandler > Saving...");
            insertDataToFile();
            Console.WriteLine("DEBUG > LvupPageHandler > Finished saving!");
        }
    }
}
