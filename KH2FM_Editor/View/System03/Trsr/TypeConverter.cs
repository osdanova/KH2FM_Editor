﻿using System;
using System.Collections.Generic;
using System.Windows.Data;

namespace KH2FM_Editor.View.System03.Trsr
{
    internal class TypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is byte byteValue)
            {
                if (TypeDictionary.TryGetValue(byteValue, out string stringValue))
                {
                    return stringValue;
                }
            }
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string stringValue && parameter is Dictionary<byte, string> dictionary)
            {
                foreach (var kvp in TypeDictionary)
                {
                    if (kvp.Value == stringValue)
                    {
                        return kvp.Key;
                    }
                }
            }
            return value;

        }

        public static Dictionary<byte, String> TypeDictionary = new Dictionary<byte, string>() {
            { 0 , "Chest" },
            { 1 , "Event" }
        };
    }
}
