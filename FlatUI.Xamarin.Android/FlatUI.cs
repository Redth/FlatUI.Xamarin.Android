using System;
using Android.App;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Content;
using System.Collections.Generic;

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
			DefaultFontWeight = FlatUIFontWeight.Regular;
			DefaultFontFamily = FlatUIFontFamily.Roboto;
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
		public static FlatUIFontWeight DefaultFontWeight { get; set; }
		public static FlatUIFontFamily DefaultFontFamily { get;set; }

		public static void SetActionBarTheme(Activity context, FlatTheme theme, bool dark)
		{
			var color1 = theme.Color3;
			var color2 = theme.Color2;

			if (dark) 
			{
				color1 = theme.Color2;
				color2 = theme.Color1;
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

		public static Typeface GetFont(Context context, int fontId, int weight)
		{
			var fontName = string.Empty;
			var fontWeight = string.Empty;

			if (fontId != 0) {

				if (fontId == 1) fontName = "opensans";
				else if (fontId == 2) fontName = "roboto";
				else if (fontId == 3) fontName = "comfortaa";

				switch (weight) {
					case 0:
						fontWeight = "extralight.ttf";
						break;
					case 1:
						fontWeight = "light.ttf";
						break;
					case 2:
						fontWeight = "regular.ttf";
						break;
					case 3:
						fontWeight = "bold.ttf";
						break;
					case 4:
						fontWeight = "extrabold.ttf";
						break;
				}
				return Typeface.CreateFromAsset(context.Assets, "fonts/" + fontName + "_" + fontWeight);
			}
			return null;
		}

		public enum FlatUIFontWeight
		{
			ExtraLight = 0,
			Light = 1, 
			Regular = 2,
			Bold = 3,
			ExtraBold = 4
		}

		public enum FlatUITextAppearance
		{
			None = 0,
			Dark = 1,
			Light = 2
		}

		public enum FlatUIFontFamily
		{
			DroidSans = 0,
			OpenSans = 1,
			Roboto = 2,
			Comfortaa = 3
		}
	}
}

