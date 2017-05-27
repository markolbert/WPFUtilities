
// Copyright (c) 2017 Mark A. Olbert some rights reserved
//
// This software is licensed under the terms of the MIT License
// (https://opensource.org/licenses/MIT)

using System;
using System.Globalization;
using System.Windows.Data;

namespace Olbert.JumpForJoy.Wpf
{
    public class IntervalEqualityConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            if( targetType != typeof(bool))
                throw new ArgumentException($"{nameof(IntervalEqualityConverter)}::Convert() -- {nameof(targetType)} is not bool");

            bool retVal = false;

            int minutes = 0;

            if ( parameter is int )
                minutes = (int) parameter;

            if( value is TimeSpan )
                retVal = value.Equals( TimeSpan.FromMinutes( minutes ) );

            return retVal;
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    }
}
