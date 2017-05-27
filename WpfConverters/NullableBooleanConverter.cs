
// Copyright (c) 2017 Mark A. Olbert some rights reserved
//
// This software is licensed under the terms of the MIT License
// (https://opensource.org/licenses/MIT)

using System;
using System.Globalization;
using System.Windows.Data;

namespace Olbert.JumpForJoy.Wpf
{
    public class NullableBooleanConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            if( targetType != typeof(bool))
                throw new ArgumentException($"{nameof(NullableBooleanConverter)}::Convert() -- {nameof(targetType)} is not a bool");

            bool? nb = value as bool?;

            if( !nb.HasValue ) return false;

            return nb.Value;
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    }
}
