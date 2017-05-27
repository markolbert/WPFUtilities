
// Copyright (c) 2017 Mark A. Olbert some rights reserved
//
// This software is licensed under the terms of the MIT License
// (https://opensource.org/licenses/MIT)

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Olbert.JumpForJoy.Wpf
{
    /// <summary>
    /// Converts a string to a Visibility value; an empty or null string means 'Collapsed', while a non-null
    /// string means 'Visible'.
    /// 
    /// If a non-string value is supplied, the return value is 'Collapsed'
    /// </summary>
    public class EmptyStringToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a string to a Visibility value; an empty or null string means 'Collapsed', while a non-null
        /// string means 'Visible'.
        /// 
        /// If a non-string value is supplied, the return value is 'Collapsed'
        /// </summary>
        /// <param name="value">the value to convert</param>
        /// <param name="targetType">the Type to convert to; must be Visibility, or an exception is thrown</param>
        /// <param name="parameter">ignored</param>
        /// <param name="culture">ignored</param>
        /// <returns>Visible for non-null strings, Collapsed otherwise</returns>
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            if( targetType != typeof(Visibility))
                throw new ArgumentOutOfRangeException(nameof(targetType), @"target Type is not boolean");

            if( value is string text )
                return String.IsNullOrEmpty( text ) ? Visibility.Collapsed : Visibility.Visible;

            return Visibility.Collapsed;
        }

        /// <summary>
        /// Not implemented; throws a NotImplementedException
        /// </summary>
        /// <param name="value">the value to convert</param>
        /// <param name="targetType">the Type to convert to; must be Visibility, or an exception is thrown</param>
        /// <param name="parameter">ignored</param>
        /// <param name="culture">ignored</param>
        /// <returns>throws a NotImplementedException</returns>
        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    }
}
