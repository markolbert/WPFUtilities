
// Copyright (c) 2017 Mark A. Olbert some rights reserved
//
// This software is licensed under the terms of the MIT License
// (https://opensource.org/licenses/MIT)

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Olbert.JumpForJoy.Wpf
{
    public class EmptyStringToVisibilityConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            if( targetType != typeof(Visibility))
                throw new ArgumentOutOfRangeException(nameof(targetType), @"target Type is not boolean");

            if( value is string text )
                return String.IsNullOrEmpty( text ) ? Visibility.Collapsed : Visibility.Visible;

            return Visibility.Collapsed;
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    }
}
