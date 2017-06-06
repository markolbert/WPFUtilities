This repository contains two projects:

- J4JUI, which holds some general-purpose UI elements
- WpfConverters, which holds some IValueConverters

**Usage**

You can either clone the source code and include it, or grab the nuget package from my [MyGet repository](https://www.myget.org/gallery/jump4joy).

# J4JUI

## J4JMessageBox

J4JMessageBox is a customizable replacement for the standard MessageBox, configurable
through a fluid interface.

It incorporates three buttons, which can be made visible or not, and whose 
appearance can be customized. The customizable features of the buttons are:

- visibility
- displayed text
- background color
- default status, indicated by a highlighted border

In addition, the overall control offers the following customizations:

- highlight color, used for when the mouse hovers over a button and to indicate
which button, if any, is the default
- logo or image
- displayed message

### Fluent API

`ButtonText( string btn0, string btn1 = null, string btn2 = null )` sets text for the buttons; *btn1* and *btn2*
are optional and, if not supplied, cause their respective buttons to be collapsed.

`ButtonNormalColors( btn0, btn1, btn2 )` sets the background colors for the
buttons; *btn1* and *btn2* are optional and, if not supplied, cause the default 
background colors to be used.

`ButtonHiliteColors( Color btn0, Color? btn1 = null, Color? btn2 = null )` sets the highlight color (the color
used when the mouse is hovering over the button) for the
buttons; *btn1* and *btn2* are optional and, if not supplied, cause the default 
highlight color to be used.

`ButtonVisibility( bool btn0, bool btn1, bool btn2 )` controls whether a button is visible
(true) or collapsed (false)

`DefaultButton( int btnNumber )` controls which button is the default; valid values
are 0, 1 or 2, with the buttons being numbered from left to right. Invalid values
are ignored.

`Title( string title )` sets the message box's title.

`Message( string message )` sets the message box's message.

`ShowMessageBox()` displays the message box, waits for the user, and returns
the number of the button (0, 1 or 2) that was pressed.

There are also three other fluent API methods which simultaneously set various
parameters of each button:

`Button0/1/2( string text, bool visible = true, Color? normalColor = null, Color? hiliteColor = null )` visible defaults to 
true, while normalColor and hiliteColor are optional and, if not supplied, leave
the default colors unchanged.

A typical example of using the fluent API might look like this:

```csharp
new J4JMessageBox().Title( "About Lan History Manager" )
    .Message( sb.ToString() )
    .ButtonText( "Okay" )
    .ShowMessageBox();
```

This would display a one-button message box using the default image and colors.
The return value is not saved since it is of no significance.

### Image and Default Colors

You can define the image on the left-hand side of the message box, and the
default colors, by creating a resource assembly and including it in the folder
where your executable is.

The resource assembly must be named `Olbert.J4JResources.dll`, and it must contain
a ResourceDictionary named `DefaultResources.xaml`. Here's an example:

```xml
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <BitmapImage x:Key="J4JMessageBoxImage" UriSource="assets/msgbox.png" />
    <BitmapImage x:Key="J4JWizardImage" UriSource="assets/wizard.png" />
    <Color x:Key="J4JButton0Color">#835434</Color>
    <Color x:Key="J4JButton1Color">#bb8149</Color>
    <Color x:Key="J4JButton2Color">#fa9599</Color>
    <Color x:Key="J4JButtonHighlightColor">Orange</Color>

</ResourceDictionary>
```

## WpfConverters

This project contains a variety of `IValueConverter` classes. Each of these converters
is one-way; their `ConvertBack` methods throw `NotImplementedException`.

`EmptyStringToVisibilityConverter` converts an empty/null string to `Visibility.Collapsed`.
It throws an exception if the target Type, the Type you're converting the string to,
is not `Visibility`.

`IntervalEqualityConverter` determines if a supplied `TimeSpan` object represents a
specified number of minutes, returning true if it does or false if it doesn't. The
number of minutes is specified through `ConverterParameter`. If no parameter is
supplied it defaults to 0. It throws an exception if the target Type, the Type you're converting the string to,
is not `bool`.

`NullableBooleanConverter` converts a nullable boolean to a true boolean, with
null values converted to false. It throws an exception if the target Type, the Type you're converting the string to,
is not `bool`.

`PhysicalAddressFormatter` converts a PhysicalAddress object to a text MAC address.
It also provides a static method, `PhysicalAddressFormatter.Format` which does
the same thing.

`TimeSpanFormatter` converts a TimeSpan object to text in the form *# days, # hours, # minutes*.
It also provides a static method, `TimeSpanFormatter.Format` which does
the same thing.






