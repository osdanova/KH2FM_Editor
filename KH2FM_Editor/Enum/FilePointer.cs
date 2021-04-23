namespace KH2FM_Editor.Enum
{
    enum FilePointer : long
    {
        KH2_03SYSTEM_PCSX2 = 0x01C61AF8,
        KH2_00BATTLE_PCSX2 = 0x01C61AFC,
        KH2_00OBJENTRY_PCSX2 = 0x01D5BA10,
        KH2_JIMINY_PCSX2 = 0x004F7590, // Dinamically assigned, this one doesn't work
        KH2_MIXDATA_PCSX2 = 0x00382684,

        KH2_03SYSTEM_EGS = 0x2AE3510,
        KH2_00BATTLE_EGS = 0x2AE3518,
        KH2_00OBJENTRY_EGS = 0x2A226F0,
        //KH2_JIMINY_EGS = 0x004F7590, // Dinamically assigned, this one doesn't work
        KH2_MIXDATA_EGS = 0x29F2FC8
    }
}
