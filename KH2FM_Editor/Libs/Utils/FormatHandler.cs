using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KH2FM_Editor.Libs.Utils
{
    class FormatHandler
    {
        // Splices the text in lines of the given length
        public static string SpliceText(string text, int lineLength)
        {
            return Regex.Replace(text, "(.{" + lineLength + "})", "$1" + Environment.NewLine);
        }
        // Formats strings to 32 characters, cropping to 32 chars and filling with \0s if lacking length
        public static string format32Chars(string text)
        {
            if (text.Length > 32) text = text.Substring(0, 32);
            if (text.Length < 32)
            {
                for (int i = text.Length; i < 32; i++)
                {
                    text += "\0";
                }
            }
            return text;
        }

        // Returns a byte list of 0s of the given size
        public static List<byte> getByteListOfSize(int size)
        {
            Byte[] array = new Byte[size];
            Array.Clear(array, 0, array.Length);
            return array.ToList();
        }

        // Returns the hex string of 8 digits of the given value
        public static string getHexString8(int value)
        {
            return value.ToString("X8");
        }
    }
}
