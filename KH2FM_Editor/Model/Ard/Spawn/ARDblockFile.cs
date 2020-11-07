using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KH2FM_Editor.Model.Ard.Spawn
{
    public class ArdBlockFile
    {
        // Data
        List<Byte> Header { get; set; }
        public ObservableCollection<SpawnItem> EntitySpawns { get; set; }
        public ObservableCollection<SpawnItem> EventSpawns { get; set; }
        public ObservableCollection<WalkPathFile> WalkPathSpawns { get; set; }
        public ObservableCollection<Str_EntryItem> Unk16Spawns { get; set; }
        public ObservableCollection<Str_EntryItem> Unk8Spawns { get; set; }

        // Data Location
        public static readonly int headerOffset = 0, headerSize = 44;
        public static readonly int typeOffset = 0, typeSize = 2;
        public static readonly int IdOffset = 2, IdSize = 2;
        public static readonly int entityCountOffset = 4, entityCountSize = 2;
        public static readonly int eventCountOffset = 6, eventCountSize = 2;
        public static readonly int walkPathCountOffset = 8, walkPathCountSize = 2;
        public static readonly int unk16CountOffset = 10, unk16CountSize = 2;
        public static readonly int unk8CountOffset = 12, unk8CountSize = 2;
        public static readonly int unk14Offset = 14, unk14Size = 2;
        public static readonly int unk16Offset = 16, unk16Size = 4;
        public static readonly int unk20Offset = 20, unk20Size = 4;
        public static readonly int unk24Offset = 24, unk24Size = 4;
        public static readonly int worldIndexOffset = 28, worldIndexSize = 1;
        public static readonly int placeDoorOffset = 29, placeDoorSize = 1;
        public static readonly int worldIdOffset = 30, worldIdSize = 1;
        public static readonly int unk31Offset = 31, unk31Size = 1;
        public static readonly int unk32Offset = 32, unk32Size = 4;
        public static readonly int unk36Offset = 36, unk36Size = 4;
        public static readonly int unk40Offset = 40, unk40Size = 4;

        private ArdBlockFile() { }
        public ArdBlockFile(List<Byte> rawData)
        {
            Header = rawData.GetRange(headerOffset, headerSize);
            addData(rawData.GetRange(headerSize, rawData.Count - headerSize));
        }
        public static ArdBlockFile headerConstructor(List<Byte> rawHeader)
        {
            ArdBlockFile ardBlockFile = new ArdBlockFile();
            ardBlockFile.Header = rawHeader;
            return ardBlockFile;
        }

        public ushort Type
        {
            get { return DataAccess.readUShort(Header, typeOffset, typeSize); }
            set { DataAccess.writeUShort(Header, value, typeOffset, typeSize); }
        }
        public ushort Id
        {
            get { return DataAccess.readUShort(Header, IdOffset, IdSize); }
            set { DataAccess.writeUShort(Header, value, IdOffset, IdSize); }
        }
        public ushort EntityCount
        {
            get { return DataAccess.readUShort(Header, entityCountOffset, entityCountSize); }
            set { DataAccess.writeUShort(Header, value, entityCountOffset, entityCountSize); }
        }
        public ushort EventCount
        {
            get { return DataAccess.readUShort(Header, eventCountOffset, eventCountSize); }
            set { DataAccess.writeUShort(Header, value, eventCountOffset, eventCountSize); }
        }
        public ushort WalkPathCount
        {
            get { return DataAccess.readUShort(Header, walkPathCountOffset, walkPathCountSize); }
            set { DataAccess.writeUShort(Header, value, walkPathCountOffset, walkPathCountSize); }
        }
        public ushort Unk16Count
        {
            get { return DataAccess.readUShort(Header, unk16CountOffset, unk16CountSize); }
            set { DataAccess.writeUShort(Header, value, unk16CountOffset, unk16CountSize); }
        }
        public ushort Unk8Count
        {
            get { return DataAccess.readUShort(Header, unk8CountOffset, unk8CountSize); }
            set { DataAccess.writeUShort(Header, value, unk8CountOffset, unk8CountSize); }
        }
        public string Unk14
        {
            get { return DataAccess.readHexString(Header, unk14Offset, unk14Size); }
            set { DataAccess.writeHexString(Header, value, unk14Offset, unk14Size); }
        }
        public string Unk16
        {
            get { return DataAccess.readHexString(Header, unk16Offset, unk16Size); }
            set { DataAccess.writeHexString(Header, value, unk16Offset, unk16Size); }
        }
        public string Unk20
        {
            get { return DataAccess.readHexString(Header, unk20Offset, unk20Size); }
            set { DataAccess.writeHexString(Header, value, unk20Offset, unk20Size); }
        }
        public string Unk24
        {
            get { return DataAccess.readHexString(Header, unk24Offset, unk24Size); }
            set { DataAccess.writeHexString(Header, value, unk24Offset, unk24Size); }
        }
        public byte WorldIndex
        {
            get { return DataAccess.readByte(Header, worldIndexOffset); }
            set { DataAccess.writeByte(Header, value, worldIndexOffset); }
        }
        public byte PlaceDoor
        {
            get { return DataAccess.readByte(Header, placeDoorOffset); }
            set { DataAccess.writeByte(Header, value, placeDoorOffset); }
        }
        public byte WorldId
        {
            get { return DataAccess.readByte(Header, worldIdOffset); }
            set { DataAccess.writeByte(Header, value, worldIdOffset); }
        }
        public string Unk31
        {
            get { return DataAccess.readHexString(Header, unk31Offset, unk31Size); }
            set { DataAccess.writeHexString(Header, value, unk31Offset, unk31Size); }
        }
        public string Unk32
        {
            get { return DataAccess.readHexString(Header, unk32Offset, unk32Size); }
            set { DataAccess.writeHexString(Header, value, unk32Offset, unk32Size); }
        }
        public string Unk36
        {
            get { return DataAccess.readHexString(Header, unk36Offset, unk36Size); }
            set { DataAccess.writeHexString(Header, value, unk36Offset, unk36Size); }
        }
        public string Unk40
        {
            get { return DataAccess.readHexString(Header, unk40Offset, unk40Size); }
            set { DataAccess.writeHexString(Header, value, unk40Offset, unk40Size); }
        }

        public void addData(List<byte> rawData)
        {
            int currentOffset = headerSize;
            foreach (var i in Enumerable.Range(0, EntityCount))
            {
                EntitySpawns.Add(new SpawnItem(rawData.GetRange(currentOffset, SpawnItem.entrySize)));
                currentOffset += SpawnItem.entrySize;
            }
            foreach (var i in Enumerable.Range(0, EventCount))
            {
                EventSpawns.Add(new SpawnItem(rawData.GetRange(currentOffset, SpawnItem.entrySize)));
                currentOffset += SpawnItem.entrySize;
            }
            foreach (var i in Enumerable.Range(0, WalkPathCount))
            {
                // Header
                WalkPathFile walkPath = WalkPathFile.headerConstructor(rawData.GetRange(currentOffset, WalkPathFile.headerSize));
                currentOffset += WalkPathFile.headerSize;
                // Data
                walkPath.addData(rawData.GetRange(currentOffset, walkPath.ItemCount * WalkPathItem.entrySize));
                WalkPathSpawns.Add(walkPath);
                currentOffset += walkPath.ItemCount * WalkPathItem.entrySize;
            }
            foreach (var i in Enumerable.Range(0, Unk16Count))
            {
                Unk16Spawns.Add(new Str_EntryItem(rawData.GetRange(currentOffset, 16)));
                currentOffset += 16;
            }
            foreach (var i in Enumerable.Range(0, Unk8Count))
            {
                Unk8Spawns.Add(new Str_EntryItem(rawData.GetRange(currentOffset, 8)));
                currentOffset += 8;
            }
        }

        void recalcCounts()
        {
            EntityCount = (ushort)EntitySpawns.Count;
            EventCount = (ushort)EventSpawns.Count;
            WalkPathCount = (ushort)WalkPathSpawns.Count;
            Unk16Count = (ushort)Unk16Spawns.Count;
            Unk8Count = (ushort)Unk8Spawns.Count;
        }

        // Generate the item for saving
        public List<byte> getAsByteList()
        {
            recalcCounts();

            List<byte> rawItem = new List<byte>();
            // Header
            rawItem.AddRange(Header);
            // Entity spawns
            foreach(SpawnItem sp in EntitySpawns) rawItem.AddRange(sp.getAsByteList());
            // Event spawns
            foreach (SpawnItem sp in EventSpawns) rawItem.AddRange(sp.getAsByteList());
            // Walk Path spawns
            foreach (WalkPathFile wp in WalkPathSpawns) rawItem.AddRange(wp.getAsByteList());
            // Unknown16 spawns
            foreach (Str_EntryItem unk16 in Unk16Spawns) rawItem.AddRange(unk16.getAsByteList());
            // Unknown8 spawns
            foreach (Str_EntryItem unk8 in Unk8Spawns) rawItem.AddRange(unk8.getAsByteList());

            return rawItem;
        }
    }
}
