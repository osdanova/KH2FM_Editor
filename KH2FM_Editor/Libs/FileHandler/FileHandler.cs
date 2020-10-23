using KH2FM_Editor_WPF.FileTypes.Objentry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KH2FM_Editor.Libs.FileHandler
{
    class FileHandler
    {

        static String fileName;
        static String filePath;

        static ObjentryFile objentryFile;
        List<String> knownFileExtensions = new List<string> { ".ard", "battle.bin", "objentry.bin", "system.bin", "jiminy.bar", "mixdata.bar", ".mdlx", ".a.fm", ".mset" };

        public Boolean isKnownFileExtension(String fileName)
        {
            foreach (String extension in knownFileExtensions)
            {
                if (fileName.EndsWith(extension)) return true;
            }
            return false;
        }

        public void readFile()
        {
            clearFiles();

            if (fileName.EndsWith("objentry.bin"))
            {
                Console.WriteLine("Reading objentry file...");
                objentryFile = new ObjentryFile(fileName, File.ReadAllBytes(filePath).ToList());
                //addControlTabs(tabData, new List<Tuple<String, Control>> { objentryFile.getControl() });
                Console.WriteLine("Objentry file > " + fileName);
            }
        }

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

        public void clearFiles()
        {
            objentryFile = null;
        }
    }
}
