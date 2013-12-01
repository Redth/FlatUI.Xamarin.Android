###Getting Started###

To use FlatUI, all you need to do is replace some of your normal widgets with the FlatUI version

Your normal button:

```xml
<Button
  android:id="@+id/buttonBlock"
  android:layout_width="wrap_content"
  android:layout_height="wrap_content" />
```

Now becomes:

```xml
<FlatUI.FlatButton
  android:id="@+id/buttonBlock"
  android:layout_width="wrap_content"
  android:layout_height="wrap_content" />
```


**NOTE:** FlatUI only works on Android 4.x+!

###Changing Themes###

You can set the theme a number of ways:

 - Call `FlatUI.SetActivityTheme(FlatTheme.Sky());` to theme all controls the same in the activity
 - Set the attribute on the widget in the layout file: `flatui:theme="sky"`
 - Programmatically set each widget's theme: `myFlatButton.Theme = FlatTheme.Sky();`

###FlatUI Widgets###

There are a number of 'flat' versions of android widgets available that inherit from their normal counterparts:


 - FlatEditText
 - FlatTextView
 - FlatToggleButton
 - FlatRadioButton
 - FlatCheckBox
 - FlatSeekBar
 - FlatButton
 

###Custom Themes###

It's very easy to make custom themes:

```csharp
//Create a custom theme very easily!
var customJabbrTheme = new FlatUI.FlatTheme () {
    DarkAccentColor = Android.Graphics.Color.ParseColor("#00103f"),
    BackgroundColor = Android.Graphics.Color.ParseColor("#003259"),
    LightAccentColor = Android.Graphics.Color.ParseColor("#005191"),
    VeryLightAccentColor = Android.Graphics.Color.ParseColor("#719fc3")
};

//Set your theme programmatically
FlatUI.SetActivityTheme(this, customJabbrTheme);
```


###ActionBar###

Finally, the ActionBar can also be themed:

```csharp
FlatUI.FlatUI.SetActionBarTheme (this, FlatUI.FlatUI.DefaultTheme, false);
```

