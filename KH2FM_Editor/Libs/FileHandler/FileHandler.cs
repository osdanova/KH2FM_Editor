using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;

namespace KH2FM_Editor.Libs.FileHandler
{
    public class FileHandler
    {
        public static FileTypesEnum getFileType(String fileName)
        {
            if (fileName.EndsWith(".ard")) return FileTypesEnum.ARD;
            if (fileName.EndsWith("battle.bin")) return FileTypesEnum.BATTLE;
            if (fileName.EndsWith("objentry.bin")) return FileTypesEnum.OBJENTRY;
            if (fileName.EndsWith("system.bin")) return FileTypesEnum.SYSTEM;
            if (fileName.EndsWith("jiminy.bar")) return FileTypesEnum.JIMINY;
            if (fileName.EndsWith("mixdata.bar")) return FileTypesEnum.MIXDATA;
            if (fileName.EndsWith(".mdlx")) return FileTypesEnum.MDLX;
            if (fileName.EndsWith(".a.fm")) return FileTypesEnum.AFM;
            if (fileName.EndsWith(".mset")) return FileTypesEnum.MSET;
            return FileTypesEnum.UNKNOWN;
        }

        public static void saveFile(String name, List<byte> fileAsBytes)
        {
            if (fileAsBytes == null || fileAsBytes.Count == 0) return;

            SaveFileDialog sfd;
            sfd = new SaveFileDialog();
            sfd.Title = "Save file";
            sfd.FileName = name;
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                File.WriteAllBytes(sfd.FileName, fileAsBytes.ToArray());
            }
        }

        // LEGACY ---------------------------------------------------------------------

        /*
    public void processFile(String filePathIn)
    {
        Console.WriteLine("Checking file...");

        // Check if the file is valid
        if (!isKnownFileExtension(Path.GetFileName(filePathIn)))
        {
            Console.WriteLine("ERROR > Not a valid file");
            return;
        }

        // Get file data
        filePath = filePathIn;
        fileName = Path.GetFileName(filePath);

        readFile();
    }

    public void readFile()
    {
        if (fileName.EndsWith("objentry.bin"))
        {
            Console.WriteLine("Reading objentry file...");
            //objentryFile = new ObjentryFile(fileName, File.ReadAllBytes(filePath).ToList());
            //addControlTabs(tabData, new List<Tuple<String, Control>> { objentryFile.getControl() });
            Console.WriteLine("Objentry file > " + fileName);
        }
    }*/
    }
}
