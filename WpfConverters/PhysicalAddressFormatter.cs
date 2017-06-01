
// Copyright (c) 2017 Mark A. Olbert some rights reserved
//
// This software is licensed under the terms of the MIT License
// (https://opensource.org/licenses/MIT)

using System;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Data;

namespace Olbert.JumpForJoy.Wpf
{
    /// <summary>
    /// Converts a PhysicalAddress to a string
    /// </summary>
    public class PhysicalAddressFormatter : IValueConverter
    {
        /// <summary>
        /// Converts the supplied PhysicalAddress object to a string, concatenating the first six elements of the
        /// physical address, formatted as hexadecimal strings and separated by ":"
        /// </summary>
        /// <param name="macAddress">the PhyiscalAddress to convert</param>
        /// <returns>concatenates the first six elements of the
        /// physical address, formatted as hexadecimal strings and separated by ":"; if macAddress is null, uses
        /// PhysicalAddress.None as the value to convert</returns>
        public static string Format( PhysicalAddress macAddress )
        {
            macAddress = macAddress ?? PhysicalAddress.None;

            return string.Join( ":", macAddress.GetAddressBytes()
                .Where( ( x, i ) => i < 6 )
                .Select( z => z.ToString( "X2" ) ) );
        }

        /// <summary>
        /// Converts a PhysicalAddress value to a string, concatenating the first six elements of the
        /// physical address, formatted as hexadecimal strings, and separated by ":"
        /// </summary>
        /// <param name="value">the PhysicalAddress object to convert; if not a PhysicalAddress object,
        /// the string "not a PhysicalAddress object" is returned; if null, PhysicalAddress.None is used</param>
        /// <param name="targetType">not used</param>
        /// <param name="parameter">not used</param>
        /// <param name="culture">not used</param>
        /// <returns>returns a string, concatenating the first six elements of the
        /// physical address, formatted as hexadecimal strings, and separated by ":"</returns>
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            value = value ?? PhysicalAddress.None;

            if( value is PhysicalAddress macAddress )
                return Format( macAddress );

            return "not a PhysicalAddress object";
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
