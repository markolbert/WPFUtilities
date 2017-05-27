***J4JMessageBox Customizable Resources***

The J4JMessageBox control uses default button colors and a default bitmap image which
you can customize.

You do this by defining a specially-named DLL containing a ResourceDictionary that you include in your project. 

The resource DLL must be named ***Olbert.JumpForJoy.DefaultResources***.

The ResourceDictionary in the DLL must use the keys shown below:

<ResourceDictionary>
    <Color x:Key="J4JButton0Color">#bb911e</Color>
    <Color x:Key="J4JButton1Color">#252315</Color>
    <Color x:Key="J4JButton2Color">#bc513e</Color>
    <Color x:Key="J4JButtonHighlightColor">Orange</Color>
    <BitmapImage x:Key="J4JMessageBoxImage" UriSource="**uri to whatever image you want to use**" />
</ResourceDictionary>
