using KH2FM_Editor.DataDictionary;
using KH2FM_Editor.Libs.Binary;
using KH2FM_Editor.Libs.Utils;
using KH2FM_Editor.Model.COMMON;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.System03.Memt
{
    class MemtItem : Str_EntryItem
    {
        public static readonly int entrySize = 52;
        // Data Location
        public static readonly int worldIdOffset = 0, worldIdSize = 1;
        public static readonly int unk2Offset = 1, unk2Size = 15;
        public static readonly int playerOffset = 16, playerSize = 2;
        public static readonly int party1Offset = 18, party1Size = 2;
        public static readonly int party2Offset = 20, party2Size = 2;
        public static readonly int party3Offset = 22, party3Size = 2;
        public static readonly int playerValorOffset = 24, playerValorSize = 2;
        public static readonly int playerWisdomOffset = 26, playerWisdomSize = 2;
        public static readonly int playerLimitOffset = 28, playerLimitSize = 2;
        public static readonly int playerMasterOffset = 30, playerMasterSize = 2;
        public static readonly int playerFinalOffset = 32, playerFinalSize = 2;
        public static readonly int playerAntiOffset = 34, playerAntiSize = 2;
        public static readonly int playerMickeyOffset = 36, playerMickeySize = 2;
        public static readonly int playerHPOffset = 38, playerHPSize = 2;
        public static readonly int playerValorHPOffset = 40, playerValorHPSize = 2;
        public static readonly int playerWisdomHPOffset = 42, playerWisdomHPSize = 2;
        public static readonly int playerLimitHPOffset = 44, playerLimitHPSize = 2;
        public static readonly int playerMasterHPOffset = 46, playerMasterHPSize = 2;
        public static readonly int playerFinalHPOffset = 48, playerFinalHPSize = 2;
        public static readonly int playerHP2Offset = 50, playerHP2Size = 2;

        public MemtItem()
        {
            raw = FormatHandler.getByteListOfSize(entrySize);
        }
        public MemtItem(List<byte> rawData) : base(rawData)
        {
        }

        public string World
        {
            get { return Worlds.getValue(WorldId); }
        }
        public byte WorldId
        {
            get { return DataAccess.readByte(raw, worldIdOffset); }
            set { DataAccess.writeByte(raw, value, worldIdOffset); NotifyPropertyChanged(nameof(World)); }
        }
        public string Unk2
        {
            get { return DataAccess.readHexString(raw, unk2Offset, unk2Size); }
            set { DataAccess.writeHexString(raw, value, unk2Offset, unk2Size); }
        }
        public string Player
        {
            get { return Entities.getValue(PlayerId); }
        }
        public ushort PlayerId
        {
            get { return DataAccess.readUShort(raw, playerOffset, playerSize); }
            set { DataAccess.writeUShort(raw, value, playerOffset, playerSize); NotifyPropertyChanged(nameof(Player)); }
        }
        public string Party1
        {
            get { return Entities.getValue(Party1Id); }
        }
        public ushort Party1Id
        {
            get { return DataAccess.readUShort(raw, party1Offset, party1Size); }
            set { DataAccess.writeUShort(raw, value, party1Offset, party1Size); NotifyPropertyChanged(nameof(Party1)); }
        }
        public string Party2
        {
            get { return Entities.getValue(Party2Id); }
        }
        public ushort Party2Id
        {
            get { return DataAccess.readUShort(raw, party2Offset, party2Size); }
            set { DataAccess.writeUShort(raw, value, party2Offset, party2Size); NotifyPropertyChanged(nameof(Party2)); }
        }
        public string Party3
        {
            get { return Entities.getValue(Party3Id); }
        }
        public ushort Party3Id
        {
            get { return DataAccess.readUShort(raw, party3Offset, party3Size); }
            set { DataAccess.writeUShort(raw, value, party3Offset, party3Size); NotifyPropertyChanged(nameof(Party3)); }
        }
        public string PlayerValor
        {
            get { return Entities.getValue(PlayerValorId); }
        }
        public ushort PlayerValorId
        {
            get { return DataAccess.readUShort(raw, playerValorOffset, playerValorSize); }
            set { DataAccess.writeUShort(raw, value, playerValorOffset, playerValorSize); NotifyPropertyChanged(nameof(PlayerValor)); }
        }
        public string PlayerWisdom
        {
            get { return Entities.getValue(PlayerWisdomId); }
        }
        public ushort PlayerWisdomId
        {
            get { return DataAccess.readUShort(raw, playerWisdomOffset, playerWisdomSize); }
            set { DataAccess.writeUShort(raw, value, playerWisdomOffset, playerWisdomSize); NotifyPropertyChanged(nameof(PlayerWisdom)); }
        }
        public string PlayerLimit
        {
            get { return Entities.getValue(PlayerLimitId); }
        }
        public ushort PlayerLimitId
        {
            get { return DataAccess.readUShort(raw, playerLimitOffset, playerLimitSize); }
            set { DataAccess.writeUShort(raw, value, playerLimitOffset, playerLimitSize); NotifyPropertyChanged(nameof(PlayerLimit)); }
        }
        public string PlayerMaster
        {
            get { return Entities.getValue(PlayerMasterId); }
        }
        public ushort PlayerMasterId
        {
            get { return DataAccess.readUShort(raw, playerMasterOffset, playerMasterSize); }
            set { DataAccess.writeUShort(raw, value, playerMasterOffset, playerMasterSize); NotifyPropertyChanged(nameof(PlayerMaster)); }
        }
        public string PlayerFinal
        {
            get { return Entities.getValue(PlayerFinalId); }
        }
        public ushort PlayerFinalId
        {
            get { return DataAccess.readUShort(raw, playerFinalOffset, playerFinalSize); }
            set { DataAccess.writeUShort(raw, value, playerFinalOffset, playerFinalSize); NotifyPropertyChanged(nameof(PlayerFinal)); }
        }
        public string PlayerAnti
        {
            get { return Entities.getValue(PlayerAntiId); }
        }
        public ushort PlayerAntiId
        {
            get { return DataAccess.readUShort(raw, playerAntiOffset, playerAntiSize); }
            set { DataAccess.writeUShort(raw, value, playerAntiOffset, playerAntiSize); NotifyPropertyChanged(nameof(PlayerAnti)); }
        }
        public string PlayerMickey
        {
            get { return Entities.getValue(PlayerMickeyId); }
        }
        public ushort PlayerMickeyId
        {
            get { return DataAccess.readUShort(raw, playerMickeyOffset, playerMickeySize); }
            set { DataAccess.writeUShort(raw, value, playerMickeyOffset, playerMickeySize); NotifyPropertyChanged(nameof(PlayerMickey)); }
        }
        public string PlayerHP
        {
            get { return Entities.getValue(PlayerHPId); }
        }
        public ushort PlayerHPId
        {
            get { return DataAccess.readUShort(raw, playerHPOffset, playerHPSize); }
            set { DataAccess.writeUShort(raw, value, playerHPOffset, playerHPSize); NotifyPropertyChanged(nameof(PlayerHP)); }
        }
        public string PlayerValorHP
        {
            get { return Entities.getValue(PlayerValorHPId); }
        }
        public ushort PlayerValorHPId
        {
            get { return DataAccess.readUShort(raw, playerValorHPOffset, playerValorHPSize); }
            set { DataAccess.writeUShort(raw, value, playerValorHPOffset, playerValorHPSize); NotifyPropertyChanged(nameof(PlayerValorHP)); }
        }
        public string PlayerWisdomHP
        {
            get { return Entities.getValue(PlayerWisdomHPId); }
        }
        public ushort PlayerWisdomHPId
        {
            get { return DataAccess.readUShort(raw, playerWisdomHPOffset, playerWisdomHPSize); }
            set { DataAccess.writeUShort(raw, value, playerWisdomHPOffset, playerWisdomHPSize); NotifyPropertyChanged(nameof(PlayerWisdomHP)); }
        }
        public string PlayerLimitHP
        {
            get { return Entities.getValue(PlayerLimitHPId); }
        }
        public ushort PlayerLimitHPId
        {
            get { return DataAccess.readUShort(raw, playerLimitHPOffset, playerLimitHPSize); }
            set { DataAccess.writeUShort(raw, value, playerLimitHPOffset, playerLimitHPSize); NotifyPropertyChanged(nameof(PlayerLimitHP)); }
        }
        public string PlayerMasterHP
        {
            get { return Entities.getValue(PlayerMasterHPId); }
        }
        public ushort PlayerMasterHPId
        {
            get { return DataAccess.readUShort(raw, playerMasterHPOffset, playerMasterHPSize); }
            set { DataAccess.writeUShort(raw, value, playerMasterHPOffset, playerMasterHPSize); NotifyPropertyChanged(nameof(PlayerMasterHP)); }
        }
        public string PlayerFinalHP
        {
            get { return Entities.getValue(PlayerFinalHPId); }
        }
        public ushort PlayerFinalHPId
        {
            get { return DataAccess.readUShort(raw, playerFinalHPOffset, playerFinalHPSize); }
            set { DataAccess.writeUShort(raw, value, playerFinalHPOffset, playerFinalHPSize); NotifyPropertyChanged(nameof(PlayerFinalHP)); }
        }
        public string PlayerHP2
        {
            get { return Entities.getValue(PlayerHP2Id); }
        }
        public ushort PlayerHP2Id
        {
            get { return DataAccess.readUShort(raw, playerHP2Offset, playerHP2Size); }
            set { DataAccess.writeUShort(raw, value, playerHP2Offset, playerHP2Size); NotifyPropertyChanged(nameof(PlayerHP2)); }
        }
    }
}
