using KH2FM_Editor.Model.Mixdata.Cond;
using KH2FM_Editor.Libs.FileHandler;
using KH2FM_Editor.Model.Mixdata;
using System.Collections.Generic;
using KH2FM_Editor.Model.Mixdata.Leve;
using KH2FM_Editor.Model.Mixdata.Reci;
using KH2FM_Editor.Model.Jiminy;
using KH2FM_Editor.Model.Jiminy.Worl;
using KH2FM_Editor.Model.Jiminy.Puzz;
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
using KH2FM_Editor.Model.Battle;
using KH2FM_Editor.Model.System03;
using KH2FM_Editor.Model.System03.Cmd;
using KH2FM_Editor.Model.System03.Wmst;
using KH2FM_Editor.Model.System03.Item;
using KH2FM_Editor.Model.System03.Trsr;
using KH2FM_Editor.Model.System03.Shop;
using KH2FM_Editor.Model.System03.Sklt;
using KH2FM_Editor.Model.System03.Evtp;
using KH2FM_Editor.Model.Ard;
using KH2FM_Editor.Model.Ard.Script;
using KH2FM_Editor.Model.Ard.Spawn;
using KH2FM_Editor.Model.System03.Went;
using KH2FM_Editor.Model.System03.Pref.Fmab;
using KH2FM_Editor.Model.System03.Pref.Plyr;
using KH2FM_Editor.Model.System03.Pref.Prty;
using KH2FM_Editor.Model.System03.Pref.Magi;

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

            // SYSTEM
            if (FileHandler.getFileType(name) == FileTypesEnum.SYSTEM) return new SystemFile(name, raw);
            //if (FileHandler.getFileType(parentBar) == FileTypesEnum.SYSTEM && name == "rcct") return new RcctFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.SYSTEM && name == "cmd\0") return new CmdFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.SYSTEM && name == "went") return new WentFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.SYSTEM && name == "wmst") return new WmstFile(name, raw);
            //if (FileHandler.getFileType(parentBar) == FileTypesEnum.SYSTEM && name == "arif") return new ArifFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.SYSTEM && name == "item") return new ItemFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.SYSTEM && name == "trsr") return new TrsrFile(name, raw);
            //if (FileHandler.getFileType(parentBar) == FileTypesEnum.SYSTEM && name == "memt") return new MemtFile(name, raw);
            //if (FileHandler.getFileType(parentBar) == FileTypesEnum.SYSTEM && name == "ftst") return new FtstFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.SYSTEM && name == "shop") return new ShopFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.SYSTEM && name == "sklt") return new SkltFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.SYSTEM && name == "pref") return new BarFile(name, raw);
                if (parentBar == "pref" && name == "plyr") return new PlyrFile(name, raw);
                if (parentBar == "pref" && name == "fmab") return new FmabFile(name, raw);
                //if (parentBar == "pref" && name == "prty") return new PrtyFile(name, raw);
                if (parentBar == "pref" && name == "magi") return new MagiFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.SYSTEM && name == "evtp") return new EvtpFile(name, raw);
            //if (FileHandler.getFileType(parentBar) == FileTypesEnum.SYSTEM && name == "ipic") return new IpicFile(name, raw);

            // ARD
            if (FileHandler.getFileType(name) == FileTypesEnum.ARD) return new ArdFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.ARD && name == "map\0") return new ArdScriptFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.ARD && name.StartsWith("m_")) return new SpawnFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.ARD && name == "btl\0") return new ArdScriptFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.ARD && name.StartsWith("b_")) return new SpawnFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.ARD && name.StartsWith("s_")) return new SpawnFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.ARD && name.StartsWith("z_")) return new SpawnFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.ARD && name == "evt\0") return new ArdScriptFile(name, raw);
            if (FileHandler.getFileType(parentBar) == FileTypesEnum.ARD && name.StartsWith("e_")) return new SpawnFile(name, raw);
            //if (FileHandler.getFileType(parentBar) == FileTypesEnum.ARD && name == "number") return new SceneFile(name, raw);

            return new RawSubFile(name, raw);
        }
    }
}
