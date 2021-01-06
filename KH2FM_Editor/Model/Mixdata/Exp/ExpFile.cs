using KH2FM_Editor.Model.Bar;
using KH2FM_Editor.Model.COMMON;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Model.Mixdata.Exp
{
    public class ExpFile : Str_EntryFile, BarSubFile
    {
        List<byte> fileNameHeader;
        public static int fileNameHeaderSize = 4;

        public ExpFile(String name, List<byte> raw) : base(name, 4, 4, ExpItem.entrySize, raw.GetRange(fileNameHeaderSize, raw.Count - fileNameHeaderSize)) { }

        public override void processEntries(List<byte> raw)
        {
            fileNameHeader = raw.GetRange(0, fileNameHeaderSize);

            int currentOffset = headerSize;

            Console.WriteLine("ExpFile > raw count: " + raw.Count);
            Console.WriteLine("ExpFile > currentOffset: " + currentOffset);

            // Entries
            for (ulong i = 0; i < EntryCount; i++)
            {
                Entries.Add(new ExpItem(raw.GetRange(currentOffset, ExpItem.entrySize)));
                currentOffset += ExpItem.entrySize;
            }
        }

        public List<byte> getSubFileAsByteList()
        {
            List<byte> data = fileNameHeader;
            data.AddRange(getAsByteList());

            return data;
        }
    }
}
