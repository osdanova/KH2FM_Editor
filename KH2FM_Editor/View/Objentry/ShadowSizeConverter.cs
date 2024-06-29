﻿using KH2FM_Editor.DataDictionary;
using System;
using System.Collections.Generic;
using System.Windows.Data;

namespace KH2FM_Editor.View.Objentry
{
    internal class ShadowSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is byte byteValue)
            {
                if (ObjentryFlags.shadowSizes.TryGetValue(byteValue, out string stringValue))
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
                foreach (var kvp in ObjentryFlags.shadowSizes)
                {
                    if (kvp.Value == stringValue)
                    {
                        return kvp.Key;
                    }
                }
            }
            return value;

        }
    }
}
