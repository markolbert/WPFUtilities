
// Copyright (c) 2017 Mark A. Olbert some rights reserved
//
// This software is licensed under the terms of the MIT License
// (https://opensource.org/licenses/MIT)

using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Olbert.JumpForJoy.Wpf
{
    /// <summary>
    /// Formats a TimeSpan objectd as a string referencing the number of days, hours and minutes in the
    /// TimeSpan
    /// </summary>
    public class TimeSpanFormatter : IValueConverter
    {
        /// <summary>
        /// Formats a TimeSpan object as a string referencing the number of days, hours and minutes in the
        /// TimeSpan
        /// </summary>
        /// <param name="toConv">the TimeSpan object to convert</param>
        /// <returns>if the value being converted is TimeSpan.MaxValue, returns "Other"; otherwise, returns
        /// a string formatted as number of days, number of hours and number of minutes (elements with zero
        /// value are ignored)</returns>
        public static string Format( TimeSpan toConv )
        {
            if( toConv.Equals( TimeSpan.MaxValue ) ) return "Other";

            StringBuilder retVal = new StringBuilder();

            if( toConv.Days > 0 )
                retVal.Append( $"{toConv.Days} day" + ( toConv.Days == 1 ? String.Empty : "s" ) );

            if( toConv.Hours > 0 )
            {
                if( retVal.Length > 0 ) retVal.Append( " " );
                retVal.Append( $"{toConv.Hours} hour" + ( toConv.Hours == 1 ? String.Empty : "s" ) );
            }

            if( toConv.Minutes > 0 )
            {
                if (retVal.Length > 0) retVal.Append(" ");
                retVal.Append( $"{toConv.Minutes} minute" + ( toConv.Minutes == 1 ? String.Empty : "s" ) );
            }

            return retVal.ToString();
        }

        /// <summary>
        /// Converts a TimeSpan object to a string referencing the number of days, hours and minutes in the
        /// TimeSpan
        /// </summary>
        /// <param name="value">the TimeSpan object to convert; if null, String.Empty is returned; if not a
        /// TimeSpan object, "not a TimeSpan object" is returned</param>
        /// <param name="targetType">not used</param>
        /// <param name="parameter">not used</param>
        /// <param name="culture">not used</param>
        /// <returns>a string referencing the number of days, hours and minutes in the
        /// TimeSpan</returns>
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            if( value == null ) return String.Empty;

            if( value is TimeSpan timeSpan )
                return Format( timeSpan );

            return "not a TimeSpan object";
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
