using KH2FM_Editor.FileTypes;
using KH2FM_Editor.Libs.FileHandler;
using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.Battle.Atkp;
using KH2FM_Editor.Model.Battle.Bons;
using KH2FM_Editor.Model.Battle.Btlv;
using KH2FM_Editor.Model.Battle.Enmp;
using KH2FM_Editor.Model.Battle.Fmlv;
using KH2FM_Editor.Model.Battle.Limt;
using KH2FM_Editor.Model.Battle.Lvpm;
using KH2FM_Editor.Model.Battle.Magc;
using KH2FM_Editor.Model.Battle.Patn;
using KH2FM_Editor.Model.Battle.Plrp;
using KH2FM_Editor.Model.Battle.Przt;
using KH2FM_Editor.Model.Battle.Stop;
using KH2FM_Editor.Model.Battle.Sumn;
using KH2FM_Editor.Model.Battle.Vtbl;
using KH2FM_Editor.Model.Jiminy;
using KH2FM_Editor.Model.Jiminy.Puzz;
using KH2FM_Editor.Model.Jiminy.Worl;
using KH2FM_Editor.Model.Mixdata;
using KH2FM_Editor.Model.Mixdata.Cond;
using KH2FM_Editor.Model.Mixdata.Leve;
using KH2FM_Editor.Model.Mixdata.Reci;
using KH2FM_Editor.View.Battle.Atkp;
using KH2FM_Editor.View.Battle.Bons;
using KH2FM_Editor.View.Battle.Btlv;
using KH2FM_Editor.View.Battle.Enmp;
using KH2FM_Editor.View.Battle.Fmlv;
using KH2FM_Editor.View.Battle.Limt;
using KH2FM_Editor.View.Battle.Lvpm;
using KH2FM_Editor.View.Battle.Magc;
using KH2FM_Editor.View.Battle.Patn;
using KH2FM_Editor.View.Battle.Plrp;
using KH2FM_Editor.View.Battle.Przt;
using KH2FM_Editor.View.Battle.Stop;
using KH2FM_Editor.View.Battle.Sumn;
using KH2FM_Editor.View.Battle.Vtbl;
using KH2FM_Editor.View.Jiminy.Puzz;
using KH2FM_Editor.View.Jiminy.Worl;
using KH2FM_Editor.View.Mixdata.Cond;
using KH2FM_Editor.View.Mixdata.Leve;
using KH2FM_Editor.View.Mixdata.Reci;
using System;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace KH2FM_Editor.View.Bar
{
    class BarPageHandler
    {
        // DATA
        String FileName { get; set; }
        String FilePath { get; set; }
        public BarFile BarFileLoaded { get; set; }

        public BarPageHandler(String parentName, String filepath)
        {
            Console.WriteLine("DEBUG > BarPageHandler > Processing file...");
            processFile(parentName, filepath);
            Console.WriteLine("DEBUG > BarPageHandler > File processed!");
        }


        public void act_export()
        {
            if (BarFileLoaded == null) return;
            Console.WriteLine("DEBUG > BarPageHandler > Exporting...");
            FileHandler.saveFile(FileName, BarFileLoaded.getAsByteList());
            Console.WriteLine("DEBUG > BarPageHandler > Export saving!");
        }


        public void processFile(String parentName, String filePath)
        {
            Console.WriteLine("DEBUG > BarPageHandler > Getting file info...");
            // Get file data
            this.FilePath = filePath;
            FileName = Path.GetFileName(this.FilePath);

            Console.WriteLine("DEBUG > BarPageHandler > Reading " + FileName + "...");

            // MIXDATA
            if (FileHandler.getFileType(FileName) == FileTypesEnum.MIXDATA)
            {
                BarFileLoaded = new MixdataFile(FileName, File.ReadAllBytes(filePath).ToList());
            }
            // JIMINY
            if (FileHandler.getFileType(FileName) == FileTypesEnum.JIMINY)
            {
                BarFileLoaded = new JiminyFile(FileName, File.ReadAllBytes(filePath).ToList());
            }
            // BATTLE
            if (FileHandler.getFileType(FileName) == FileTypesEnum.BATTLE)
            {
                BarFileLoaded = new BattleFile(FileName, File.ReadAllBytes(filePath).ToList());
            }
        }

        public void loadFile(Frame loadFrame, BarItem entry)
        {
            //BarFileLoaded.Items.IndexOf(entry);

            Console.WriteLine("DEBUG > BarPageHandler > Opening: " + entry.Name);

            if (FileHandler.getFileType(FileName) == FileTypesEnum.MIXDATA)
            {
                if (entry.Name == "reci")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as ReciFile));
                    loadFrame.Navigate(new ReciPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as ReciFile));
                }
                else if (entry.Name == "cond")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as CondFile));
                    loadFrame.Navigate(new CondPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as CondFile));
                }
                else if (entry.Name == "leve")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as LeveFile));
                    loadFrame.Navigate(new LevePage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as LeveFile));
                }
            }
            else if (FileHandler.getFileType(FileName) == FileTypesEnum.JIMINY)
            {
                if (entry.Name == "worl")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as WorlFile));
                    loadFrame.Navigate(new WorlPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as WorlFile));
                }
                else if (entry.Name == "puzz")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as PuzzFile));
                    loadFrame.Navigate(new PuzzPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as PuzzFile));
                }
            }
            else if (FileHandler.getFileType(FileName) == FileTypesEnum.BATTLE)
            {
                if (entry.Name == "atkp")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as AtkpFile));
                    loadFrame.Navigate(new AtkpPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as AtkpFile));
                }
                /*else if (entry.Name == "ptya")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as PtyaFile));
                    loadFrame.Navigate(new PtyaPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as PtyaFile));
                }*/
                else if (entry.Name == "przt")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as PrztFile));
                    loadFrame.Navigate(new PrztPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as PrztFile));
                }
                else if (entry.Name == "vtbl")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as VtblFile));
                    loadFrame.Navigate(new VtblPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as VtblFile));
                }
                /*else if (entry.Name == "lvup")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as LvupFile));
                    loadFrame.Navigate(new LvupPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as LvupFile));
                }*/
                else if (entry.Name == "bons")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as BonsFile));
                    loadFrame.Navigate(new BonsPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as BonsFile));
                }
                else if (entry.Name == "btlv")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as BtlvFile));
                    loadFrame.Navigate(new BtlvPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as BtlvFile));
                }
                else if (entry.Name == "lvpm")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as LvpmFile));
                    loadFrame.Navigate(new LvpmPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as LvpmFile));
                }
                else if (entry.Name == "enmp")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as EnmpFile));
                    loadFrame.Navigate(new EnmpPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as EnmpFile));
                }
                else if (entry.Name == "patn")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as PatnFile));
                    loadFrame.Navigate(new PatnPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as PatnFile));
                }
                else if (entry.Name == "plrp")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as PlrpFile));
                    loadFrame.Navigate(new PlrpPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as PlrpFile));
                }
                else if (entry.Name == "limt")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as LimtFile));
                    loadFrame.Navigate(new LimtPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as LimtFile));
                }
                else if (entry.Name == "sumn")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as SumnFile));
                    loadFrame.Navigate(new SumnPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as SumnFile));
                }
                else if (entry.Name == "magc")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as MagcFile));
                    loadFrame.Navigate(new MagcPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as MagcFile));
                }
                /*else if (entry.Name == "vbrt")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as VbrtFile));
                    loadFrame.Navigate(new VbrtPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as VbrtFile));
                }*/
                else if (entry.Name == "fmlv")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as FmlvFile));
                    loadFrame.Navigate(new FmlvPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as FmlvFile));
                }
                else if (entry.Name == "stop")
                {
                    Console.WriteLine("DEBUG > BarPageHandler > Opening File: " + (BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as StopFile));
                    loadFrame.Navigate(new StopPage(BarFileLoaded.SubFiles[BarFileLoaded.Items.IndexOf(entry)] as StopFile));
                }
            }


            /*
            switch (FileHandler.getFileType((file as SimpleFileNode).Name))
            {
                case FileTypesEnum.OBJENTRY:
                    //loadFrame.Navigate(new ObjentryPage((file as SimpleFileNode).FilePath)); // newPage(File)
                    break;
                case FileTypesEnum.MIXDATA:
                    loadFrame.Navigate(new BarPage((file as SimpleFileNode).FilePath));
                    break;
                default:
                    break;
            }*/
        }
    }
}
