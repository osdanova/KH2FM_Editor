using KH2FM_Editor.Libs.Utils;
using System;
using System.Collections.Generic;

namespace KH2FM_Editor.Libs.Binary
{
    class DataAccess
    {
        // READ
        public static String readHexString(List<byte> data, int offset, int size)
        {
            return BinaryHandler.bytesAsHexString(data.GetRange(offset, size));
        }
        public static String readString(List<byte> data, int offset, int size)
        {
            return BinaryHandler.bytesAsString(data.GetRange(offset, size));
        }
        public static ulong readULong(List<byte> data, int offset, int size)
        {
            return BinaryHandler.bytesAsULong(data.GetRange(offset, size));
        }
        public static uint readUInt(List<byte> data, int offset, int size)
        {
            return BinaryHandler.bytesAsUInt(data.GetRange(offset, size));
        }
        public static int readInt(List<byte> data, int offset, int size)
        {
            return BinaryHandler.bytesAsInt(data.GetRange(offset, size));
        }
        public static ushort readUShort(List<byte> data, int offset, int size)
        {
            return BinaryHandler.bytesAsUShort(data.GetRange(offset, size));
        }
        public static short readShort(List<byte> data, int offset, int size)
        {
            return BinaryHandler.bytesAsShort(data.GetRange(offset, size));
        }
        public static byte readByte(List<byte> data, int offset)
        {
            return data[offset];
        }
        public static float readFloat(List<byte> data, int offset, int size)
        {
            return BinaryHandler.bytesAsFloat(data.GetRange(offset, size));
        }

        // WRITE
        public static void writeHexString(List<byte> data, string input, int offset, int size)
        {
            Console.WriteLine("data.Count: " + data.Count);
            Console.WriteLine("offset + size: " + (offset + size));
            if (data.Count >= offset + size)
                data.RemoveRange(offset, size);
            else
                data.RemoveRange(offset, data.Count - offset);
            Console.WriteLine("BEFORE data.Count: " + data.Count);
            data.InsertRange(offset, BinaryHandler.HexStringAsBytes(input));
            Console.WriteLine("AFTER data.Count: " + data.Count);
        }
        public static void writeString(List<byte> data, string input, int offset, int size)
        {
            if(data.Count <= offset + size)
                data.RemoveRange(offset, size);
            else
                data.RemoveRange(offset, data.Count - offset);
            data.InsertRange(offset, BinaryHandler.stringAsBytes(FormatHandler.format32Chars(input)));
        }
        public static void writeString32(List<byte> data, string input, int offset, int size)
        {
            data.RemoveRange(offset, size);
            data.InsertRange(offset, BinaryHandler.stringAs32Bytes(FormatHandler.format32Chars(input)));
        }
        public static void writeULong(List<byte> data, ulong input, int offset, int size)
        {
            data.RemoveRange(offset, size);
            data.InsertRange(offset, BinaryHandler.ulongAsBytes(input));
        }
        public static void writeUInt(List<byte> data, uint input, int offset, int size)
        {
            data.RemoveRange(offset, size);
            data.InsertRange(offset, BinaryHandler.uintAsBytes(input));
        }
        public static void writeInt(List<byte> data, int input, int offset, int size)
        {
            data.RemoveRange(offset, size);
            data.InsertRange(offset, BinaryHandler.intAsBytes(input));
        }
        public static void writeUShort(List<byte> data, ushort input, int offset, int size)
        {
            data.RemoveRange(offset, size);
            data.InsertRange(offset, BinaryHandler.ushortAsBytes(input));
        }
        public static void writeShort(List<byte> data, short input, int offset, int size)
        {
            data.RemoveRange(offset, size);
            data.InsertRange(offset, BinaryHandler.shortAsBytes(input));
        }
        public static void writeByte(List<byte> data, byte input, int offset)
        {
            data.RemoveAt(offset);
            data.Insert(offset, input);
        }
        public static void writeFloat(List<byte> data, float input, int offset, int size)
        {
            data.RemoveRange(offset, size);
            data.InsertRange(offset, BinaryHandler.floateAsBytes(input));
        }
    }
}
