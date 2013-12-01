using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FlatUI;

namespace Sample
{
	[Activity (Label = "FlatUI.Xamarin Sample", MainLauncher = true)]
	public class MainActivity : Activity
	{
		FlatEditText edittextFlat;
		FlatEditText edittextFlat2;
		FlatSeekBar seekbar;
		FlatButton buttonBlock;
		FlatButton buttonFlat;
		FlatCheckBox checkboxUncheckedEnabled;
		FlatRadioButton radioUncheckedDisabled;
		FlatToggleButton toggleUncheckedEnabled;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			//Ask for action bar to show
			Window.RequestFeature (WindowFeatures.ActionBar);

			//Setup our action bar title and icon
			ActionBar.Title = "FlatUI.Xamarin Sample";
			ActionBar.SetIcon (Android.Resource.Drawable.IcMenuInfoDetails);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			//Wire up our flatui views
			edittextFlat = FindViewById<FlatEditText> (Resource.Id.edittextFlat);
			edittextFlat2 = FindViewById<FlatEditText> (Resource.Id.edittextFlat2);
			seekbar = FindViewById<FlatSeekBar> (Resource.Id.seekbar);
			buttonBlock = FindViewById<FlatButton> (Resource.Id.buttonBlock);
			buttonFlat = FindViewById<FlatButton> (Resource.Id.buttonFlat);
			checkboxUncheckedEnabled = FindViewById<FlatCheckBox> (Resource.Id.checkboxUncheckedEnabled);
			radioUncheckedDisabled = FindViewById<FlatRadioButton> (Resource.Id.radioUncheckedDisabled);
			toggleUncheckedEnabled = FindViewById<FlatToggleButton> (Resource.Id.toggleUncheckedEnabled);


			//Create a custom theme very easily!
			var customJabbrTheme = new FlatUI.FlatTheme () {
				DarkAccentColor = Android.Graphics.Color.ParseColor("#00103f"),
				BackgroundColor = Android.Graphics.Color.ParseColor("#003259"),
				LightAccentColor = Android.Graphics.Color.ParseColor("#005191"),
				VeryLightAccentColor = Android.Graphics.Color.ParseColor("#719fc3")
			};

			//Register the them so it will show up when we ask FlatUI for all the available themes
			FlatUI.FlatUI.RegisterCustomTheme ("jabbr", customJabbrTheme);

			//Change the theme to our custom one by default
			ChangeTheme (customJabbrTheme);
		}

		void ChangeTheme(FlatTheme theme)
		{
			//Set default them
			FlatUI.FlatUI.DefaultTheme = theme;
			//Change the action bar
			FlatUI.FlatUI.SetActionBarTheme (this, FlatUI.FlatUI.DefaultTheme, false);

			//Set the theme on all existing controls
			edittextFlat.Theme = theme;
			edittextFlat2.Theme = theme;
			seekbar.Theme = theme;
			buttonBlock.Theme = theme;
			buttonFlat.Theme = theme;
			checkboxUncheckedEnabled.Theme = theme;
			radioUncheckedDisabled.Theme = theme;
			toggleUncheckedEnabled.Theme = theme;
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			//Change theme button for the action bar
			var action_item = menu.Add (new Java.Lang.String ("Change Theme"));
			action_item.SetShowAsAction (ShowAsAction.Always);
			action_item.SetIcon (Android.Resource.Drawable.IcMenuGallery);

			return true;
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			//Show a list of theme choices to pick from 
			var adBuilder = new AlertDialog.Builder (this);
			adBuilder.SetTitle ("Change Theme");

			var themeNames = FlatUI.FlatUI.GetThemeNames ();

			adBuilder.SetItems (themeNames, (sender, e) =>
			{
				var newThemeName = themeNames[e.Which];
				var newTheme = FlatUI.FlatUI.GetTheme(newThemeName);

				ChangeTheme(newTheme);
			});

			adBuilder.Create ().Show ();

			return true;
		}
	}
}


