﻿using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.Bar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.Model.Battle.Lvup
{
    public class LvupFile : BarSubFile
    {
        public String Name { get; set; }
        public List<byte> Header { get; set; }
        public List<uint> CharacterPointers { get; set; }
        public ObservableCollection<LvupCharacter> Characters { get; set; }

        // Data Location
        int headerSize = 8, charPointerSize = 4;
        protected int typeOffset = 0, typeSize = 4;
        protected int charPointerCountOffset = 4, charPointerCountSize = 4;

        public LvupFile(String name, List<byte> raw)
        {
            Console.WriteLine("DEBUG >>> Found Lvup file: " + name);
            this.Name = name;
            processHeader(raw);
            processCharPointers(raw);
            processCharacters(raw);
            //copyLevels();
        }

        public string Type
        {
            get
            {
                return DataAccess.readHexString(Header, typeOffset, typeSize);
            }
            set
            {
                DataAccess.writeHexString(Header, value, typeOffset, typeSize);
            }
        }
        public uint CharPointerCount
        {
            get
            {
                return DataAccess.readUInt(Header, charPointerCountOffset, charPointerCountSize);
            }
            set
            {
                DataAccess.writeUInt(Header, value, charPointerCountOffset, charPointerCountSize);
            }
        }

        public void processHeader(List<byte> raw)
        {
            Header = raw.GetRange(0, headerSize);
        }

        public void processCharPointers(List<byte> raw)
        {
            int currentOffset = headerSize;

            CharacterPointers = new List<uint>();

            for (int i = 0; i < CharPointerCount; i++)
            {
                CharacterPointers.Add(DataAccess.readUInt(raw, currentOffset, charPointerSize));
                currentOffset += charPointerSize;
            }
        }

        public void processCharacters(List<byte> raw)
        {
            Characters = new ObservableCollection<LvupCharacter>();

            for (int i = 0; i < CharacterPointers.Count; i++)
            {
                if (i == 0) continue; // Padding entry
                Characters.Add(new LvupCharacter(getCharacterName(i), raw.GetRange((int)CharacterPointers[i]*4, (4 + 99*LvupItem.entrySize))));
            }
        }
        
        private string getCharacterName (int id)
        {
            if (id == 1) return "Sora/Roxas";
            if (id == 2) return "Donald";
            if (id == 3) return "Goofy";
            if (id == 4) return "Mickey";
            if (id == 5) return "Auron";
            if (id == 6) return "Ping/Mulan";
            if (id == 7) return "Aladdin";
            if (id == 8) return "Sparrow";
            if (id == 9) return "Beast";
            if (id == 10) return "Jack";
            if (id == 11) return "Simba";
            if (id == 12) return "Tron";
            if (id == 13) return "Riku";
            else return null;
        }

        private void copyLevels()
        {
            for(int i = 0; i < CharacterPointers.Count-1; i++)
            {
                if (i >= 4)
                {
                    Console.WriteLine("Copying exp to " + getCharacterName(i+1));
                    for(int j = 0; j < 99; j++)
                    {
                        Characters[i].Entries[j].raw.RemoveRange(0, 4);
                        Characters[i].Entries[j].raw.InsertRange(0, Characters[i-1].Entries[j].raw.GetRange(0, 4));
                    }
                }
            }
        }

        // Returns the object as a byte list
        public List<byte> getAsByteList()
        {
            List<byte> data = new List<byte>();

            // Header
            data.AddRange(Header);
            // Character pointers
            foreach(uint pointer in CharacterPointers)
            {
                data.AddRange(BitConverter.GetBytes(pointer));
            }
            // Characters
            foreach (LvupCharacter character in Characters)
            {
                data.AddRange(character.getAsByteList());
            }

            return data;
        }

        public List<byte> getSubFileAsByteList()
        {
            return getAsByteList();
        }
    }
}
