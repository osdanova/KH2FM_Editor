using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KH2FM_Editor.Model.DebugModel
{
    public class AbilitiesFile
    {
        public ObservableCollection<Ability> Abilities { get; set; }
        public static int abilityCount = 96;

        public AbilitiesFile()
        {
            Abilities = new ObservableCollection<Ability>();
        }

        public void readData(List<byte> data, int count)
        {
            Console.WriteLine("DELETE DEBUG > Reading "+count+" abilities");
            Console.WriteLine("DELETE DEBUG > data size: " + data.Count);
            abilityCount = count;
            Abilities = new ObservableCollection<Ability>();
            for(int i = 0; i < abilityCount; i++)
            {
                Abilities.Add(new Ability(data.GetRange(i*2,2)));
            }
        }

        public List<byte> getData()
        {
            List<byte> data = new List<byte>();
            foreach (Ability abi in Abilities)
            {
                data.AddRange(abi.getAsByteList());
            }
            return data;
        }


        public class Ability : Str_EntryItem
        {
            public Ability(List<byte> rawData) : base(rawData)
            {
            }

            public string AbilityName
            {
                get { return Items.getValue(AbilityId); }
            }
            public ushort AbilityId
            {
                get { return DataAccess.readUShort(raw, 0, 2); }
                set { DataAccess.writeUShort(raw, value, 0, 2); NotifyPropertyChanged(nameof(AbilityName)); }
            }
        }
    }
}
