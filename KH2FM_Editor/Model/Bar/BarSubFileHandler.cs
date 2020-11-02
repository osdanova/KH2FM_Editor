using KH2FM_Editor.Model.Mixdata.Cond;
using KH2FM_Editor.Libs.FileHandler;
using KH2FM_Editor.Model.Mixdata;
using System.Collections.Generic;
using KH2FM_Editor.Model.Mixdata.Leve;
using KH2FM_Editor.Model.Mixdata.Reci;
using KH2FM_Editor.Model.Jiminy;
using KH2FM_Editor.Model.Jiminy.Worl;
using KH2FM_Editor.Model.Jiminy.Puzz;
using KH2FM_Editor.FileTypes;
using KH2FM_Editor.Model.Battle.Atkp;
using KH2FM_Editor.Model.Battle.Magc;
using KH2FM_Editor.Model.Battle.Lvup;
using KH2FM_Editor.Model.Battle.Btlv;
using KH2FM_Editor.Model.Battle.Enmp;
using KH2FM_Editor.Model.Battle.Fmlv;
using KH2FM_Editor.Model.Battle.Limt;
using KH2FM_Editor.Model.Battle.Lvpm;
using KH2FM_Editor.Model.Battle.Patn;
using KH2FM_Editor.Model.Battle.Plrp;
using KH2FM_Editor.Model.Battle.Przt;
using KH2FM_Editor.Model.Battle.Stop;
using KH2FM_Editor.Model.Battle.Sumn;
using KH2FM_Editor.Model.Battle.Vtbl;
using KH2FM_Editor.Model.Battle.Bons;

namespace KH2FM_Editor.Model.Bar
{
    class BarSubFileHandler
    {
        public static BarSubFile handleSubFile(string parentBar, string name, List<byte> raw)
        {
            // MIXDATA
            if (FileHandler.getFileType(name) == FileTypesEnum.MIXDATA) return new MixdataFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.MIXDATA && name == "cond") return new CondFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.MIXDATA && name == "leve") return new LeveFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.MIXDATA && name == "reci") return new ReciFile(name, raw);

            // JIMINY
            if (FileHandler.getFileType(name) == FileTypesEnum.JIMINY) return new JiminyFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.JIMINY && name == "worl") return new WorlFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.JIMINY && name == "puzz") return new PuzzFile(name, raw);

            // BATTLE
            if (FileHandler.getFileType(name) == FileTypesEnum.BATTLE) return new BattleFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.BATTLE && name == "atkp") return new AtkpFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.BATTLE && name == "bons") return new BonsFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.BATTLE && name == "btlv") return new BtlvFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.BATTLE && name == "enmp") return new EnmpFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.BATTLE && name == "fmlv") return new FmlvFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.BATTLE && name == "limt") return new LimtFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.BATTLE && name == "lvpm") return new LvpmFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.BATTLE && name == "lvup") return new LvupFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.BATTLE && name == "magc") return new MagcFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.BATTLE && name == "patn") return new PatnFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.BATTLE && name == "plrp") return new PlrpFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.BATTLE && name == "przt") return new PrztFile(name, raw);
            //if (FileHandler.getFileType(parentBar) == FileTypesEnum.BATTLE && name == "ptya") return new PtyaFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.BATTLE && name == "stop") return new StopFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.BATTLE && name == "sumn") return new SumnFile(name, raw);
            //if (FileHandler.getFileType(parentBar) == FileTypesEnum.BATTLE && name == "vbrt") return new VbrtFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.BATTLE && name == "vtbl") return new VtblFile(name, raw);

            return new RawSubFile(raw);
        }
    }
}
