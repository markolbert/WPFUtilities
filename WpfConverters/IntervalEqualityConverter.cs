
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
    /// Compares a TimeSpan value and a number of minutes to determine if they are equal.
    /// </summary>
    public class IntervalEqualityConverter : IValueConverter
    {
        /// <summary>
        /// Compares a TimeSpan value and a number of minutes to determine if they are equal.
        /// </summary>
        /// <param name="value">the TimeSpan value to compare</param>
        /// <param name="targetType">the return type; an ArgumentException will be thrown if this is not bool/boolean</param>
        /// <param name="parameter">the number of minutes; if not an integer, the value of zero is assumed</param>
        /// <param name="culture">not used</param>
        /// <returns>true if the passed in value is a TimeSpan equivalent to a number of minutes defined by an integer
        /// value passed in as the parameter, false otherwise</returns>
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
