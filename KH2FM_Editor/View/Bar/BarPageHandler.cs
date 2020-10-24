using KH2FM_Editor.Model.Bar;
using System;
using System.IO;
using System.Linq;

namespace KH2FM_Editor.View.Bar
{
    class BarPageHandler
    {
        // DATA
        String FileName { get; set; }
        String FilePath { get; set; }
        public BarFile BarFileLoaded { get; set; }

        public BarPageHandler(String filepath)
        {
            Console.WriteLine("DEBUG > BarPageHandler > Processing file...");
            processFile(filepath);
            Console.WriteLine("DEBUG > BarPageHandler > File processed!");
        }

        public void processFile(String filePath)
        {
            Console.WriteLine("DEBUG > BarPageHandler > Getting file info...");
            // Get file data
            this.FilePath = filePath;
            FileName = Path.GetFileName(this.FilePath);

            Console.WriteLine("DEBUG > BarPageHandler > Reading " + FileName + "...");
            BarFileLoaded = new BarFile(FileName, File.ReadAllBytes(filePath).ToList());
        }
    }
}
