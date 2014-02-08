using System;
using System.Linq;
using Android.App;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Content;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;

namespace FlatUI
{
	public class FlatUI
	{
		public FlatUI ()
		{
		}

		static FlatUI()
		{
			DefaultTheme = FlatTheme.Blood();
			DefaultFontWeight = FlatFontWeight.Regular;
			DefaultFontFamily = FlatFontFamily.Roboto;
			DefaultTextAppearance = FlatTextAppearance.Light;
		}

		static Dictionary<string, FlatTheme> stockThemes = new Dictionary<string, FlatTheme>() {
			{ "blood", FlatTheme.Blood() },
			{ "blossom", FlatTheme.Blossom() },
			{ "candy", FlatTheme.Candy() },
			{ "dark", FlatTheme.Dark() },
			{ "deep", FlatTheme.Deep() },
			{ "grape", FlatTheme.Grape() },
			{ "grass", FlatTheme.Grass() },
			{ "orange", FlatTheme.Orange() },
			{ "sand", FlatTheme.Sand() },
			{ "sea", FlatTheme.Sea() },
			{ "sky", FlatTheme.Sky() },
			{ "snow", FlatTheme.Snow() },
		};

		static Dictionary<string, FlatTheme> customThemes = new Dictionary<string, FlatTheme> ();

		public static string[] GetThemeNames()
		{
			var names = new List<string> ();
			names.AddRange (from kvp in stockThemes
			               select kvp.Key);

			names.AddRange (from kvp in customThemes
				select kvp.Key);

			return names.ToArray();
		}

		public static void RegisterCustomTheme(string name, FlatTheme theme)
		{
			name = name.ToLower ();

			if (customThemes.ContainsKey (name))
				customThemes [name] = theme;
			else
				customThemes.Add (name, theme);
		}

		public static void UnregisterCustomTHeme(string name)
		{
			name = name.ToLower ();
			if (customThemes.ContainsKey (name))
				customThemes.Remove (name);
		}

		public static FlatTheme GetTheme(string name)
		{
			name = name.ToLower ();

			if (customThemes.ContainsKey (name))
				return customThemes [name];

			if (stockThemes.ContainsKey (name))
				return stockThemes [name];

			return DefaultTheme;
		}

		public static FlatTheme DefaultTheme { get; set; }
		public static FlatFontWeight DefaultFontWeight { get; set; }
		public static FlatFontFamily DefaultFontFamily { get;set; }
		public static FlatTextAppearance DefaultTextAppearance { get;set; }

		public static void SetActionBarTheme(Activity context, FlatTheme theme, bool dark)
		{
			var color1 = theme.LightAccentColor;
			var color2 = theme.BackgroundColor;

			if (dark) 
			{
				color1 = theme.BackgroundColor;
				color2 = theme.DarkAccentColor;
			}

			var front = new PaintDrawable(color1);
			var bottom = new PaintDrawable(color2);
			var d = new Drawable[] { bottom, front};
			var drawable = new LayerDrawable(d);
			drawable.SetLayerInset(1, 0, 0, 0, 3);

			var actionBar = context.ActionBar;
			actionBar.SetBackgroundDrawable(drawable);

			// invalidating action bar
			actionBar.Title = actionBar.Title;
		}

		public static void SetActivityTheme(Activity activity, FlatTheme theme) //, bool includeNormalViews)
		{
			ViewGroup vg = activity.FindViewById<View>(Android.Resource.Id.Content) as ViewGroup;

			if (vg == null)
				return;

			SetThemeOnChildren(vg, theme, false);

		}

		static void SetThemeOnChildren(ViewGroup parentViewGroup, FlatTheme theme, bool includeNormalViews)
		{

			for (int i = 0; i < parentViewGroup.ChildCount; i++)
			{
				var view = parentViewGroup.GetChildAt (i);

				
				var vtype = view.GetType ();

				if (view is FlatButton)
					(view as FlatButton).Theme = theme;
				else if (view is FlatCheckBox)
					(view as FlatCheckBox).Theme = theme;
				else if (view is FlatEditText)
					(view as FlatEditText).Theme = theme;
				else if (view is FlatRadioButton)
					(view as FlatRadioButton).Theme = theme;
				else if (view is FlatSeekBar)
					(view as FlatSeekBar).Theme = theme;
				else if (view is FlatTextView)
					(view as FlatTextView).Theme = theme;
				else if (view is FlatToggleButton)
					(view as FlatToggleButton).Theme = theme;

				//TODO: Need to add code for settheme static method
				if (includeNormalViews)
				{
					if (vtype == typeof(CheckBox))
						FlatCheckBox.SetTheme(view as CheckBox, theme);
					else if (vtype == typeof(RadioButton))
						FlatRadioButton.SetTheme(view as RadioButton, theme);
					else if (vtype == typeof(ToggleButton))
						FlatToggleButton.SetTheme(view as ToggleButton, theme);
					else if (vtype == typeof(EditText))
						FlatEditText.SetTheme(view as EditText, theme);
					else if (vtype == typeof(TextView))
						FlatTextView.SetTheme(view as TextView, theme);
					else if (vtype == typeof(SeekBar))
						FlatSeekBar.SetTheme(view as SeekBar, theme);
					else if (vtype == typeof(Button))
						FlatButton.SetTheme(view as Button, theme);
				}

				var childViewGroup = view as ViewGroup;

				if (childViewGroup != null)
					SetThemeOnChildren (childViewGroup, theme, includeNormalViews);
			}
		}

		public static Typeface GetFont(Context context, FlatFontFamily fontFamily, FlatFontWeight weight)
		{
			var fontName = string.Empty;
			var fontWeight = string.Empty;

			if (fontFamily != FlatFontFamily.DroidSans) {

				if (fontFamily == FlatFontFamily.OpenSans) fontName = "opensans";
				else if (fontFamily == FlatFontFamily.Roboto) fontName = "roboto";
				else if (fontFamily == FlatFontFamily.Comfortaa) fontName = "comfortaa";

				switch (weight) {
					case FlatFontWeight.ExtraLight:
						fontWeight = "extralight.ttf";
						break;
					case FlatFontWeight.Light:
						fontWeight = "light.ttf";
						break;
					case FlatFontWeight.Regular:
						fontWeight = "regular.ttf";
						break;
					case FlatFontWeight.Bold:
						fontWeight = "bold.ttf";
						break;
					case FlatFontWeight.ExtraBold:
						fontWeight = "extrabold.ttf";
						break;
				}

				var fname = fontName + "_" + fontWeight;

				return Typeface.CreateFromAsset(context.Assets, fname);
			}
			return null;
		}

		public enum FlatFontWeight
		{
			ExtraLight = 0,
			Light = 1, 
			Regular = 2,
			Bold = 3,
			ExtraBold = 4
		}

		public enum FlatTextAppearance
		{
			None = 0,
			Dark = 1,
			Light = 2
		}

		public enum FlatFontFamily
		{
			DroidSans = 0,
			OpenSans = 1,
			Roboto = 2,
			Comfortaa = 3
		}
	}
}

