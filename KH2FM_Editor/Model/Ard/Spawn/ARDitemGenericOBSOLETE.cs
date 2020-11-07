namespace KH2FM_Editor.FileTypes
{
    class ARDitemGeneric //: FileTypes.FileItem
    {/*
        // Raw data
        string name;
        List<byte> rawData;

        // Files that add 00 at EoF
        public static List<String> EoFFiles = new List<string>
        {
            "1",
            "2"
        };

        public ARDitemGeneric(string nameIN, List<byte> raw)
        {
            name = nameIN;
            rawData = raw;
        }

        // Create Control to show data
        public override Tuple<String, Control> getControl()
        {
            RichTextBox output = new RichTextBox();
            output.AutoSize = true;
            output.Dock = DockStyle.Fill;
            output.Text = Utils.SpliceText(Utils.byteArrayToHEXstring(rawData.ToArray()), 64);
            return new Tuple<string, Control>(name, output);
        }

        // Generate the item for saving
        public override List<byte> generateItem()
        {
            if (EoFFiles.Contains(name.Substring(0, 1)))
            {
                List<byte> rawDataEoF = new List<byte>();
                rawDataEoF.AddRange(rawData);
                rawDataEoF.AddRange(Utils.HEXstringToByteList("00"));
                return rawDataEoF;
            }


            return rawData;
        }*/

    }
}
