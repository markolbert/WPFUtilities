
// Copyright (c) 2017 Mark A. Olbert some rights reserved
//
// This software is licensed under the terms of the MIT License
// (https://opensource.org/licenses/MIT)

using System;
using System.Globalization;
using System.Windows.Data;

namespace Olbert.JumpForJoy.Wpf
{
    /// <summary>
    /// Converts a nullable boolean value to a simple boolean, with null mapped to false
    /// </summary>
    public class NullableBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Converts a nullable boolean value to a simple boolean, with null mapped to false
        /// </summary>
        /// <param name="value">the nullable boolean value to convert</param>
        /// <param name="targetType">the return type; an ArgumentException will be thrown if this is not bool/boolean</param>
        /// <param name="parameter">not used</param>
        /// <param name="culture">not used</param>
        /// <returns>true if the passed in value is a nullable boolean whose value is true, false otherwise</returns>
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            if( targetType != typeof(bool))
                throw new ArgumentException($"{nameof(NullableBooleanConverter)}::Convert() -- {nameof(targetType)} is not a bool");

            bool? nb = value as bool?;

            if( !nb.HasValue ) return false;

            return nb.Value;
        }

        /// <summary>
        /// Not implemented; always throws a NotImplementedException
        /// </summary>
        /// <param name="value">ignored</param>
        /// <param name="targetType">ignored</param>
        /// <param name="parameter">ignored</param>
        /// <param name="culture">ignored</param>
        /// <returns>always throws a NotImplementedException</returns>
        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    }
}
