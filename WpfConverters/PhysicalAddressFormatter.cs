﻿
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
    public class PhysicalAddressFormatter : IValueConverter
    {
        public static string Format( PhysicalAddress macAddress )
        {
            if( macAddress == null ) return PhysicalAddress.None.ToString();

            return string.Join( ":", macAddress.GetAddressBytes()
                .Where( ( x, i ) => i < 6 )
                .Select( z => z.ToString( "X2" ) ) );
        }

        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            if( value == null ) return PhysicalAddress.None.ToString();

            if( value is PhysicalAddress macAddress )
                return Format( macAddress );

            return "not a PhysicalAddress object";
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    }
}
