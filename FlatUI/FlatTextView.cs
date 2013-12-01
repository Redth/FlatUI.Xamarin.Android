using System;
using Android.Content;
using Android.Util;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Graphics;


namespace FlatUI
{
	public class FlatTextView : TextView
	{
		FlatTheme theme = FlatUI.DefaultTheme;

		const int DEFAULT_TEXTCOLOR = 2;
		const int DEFAULT_BACKGROUNDCOLOR = -1;
		const int DEFAULT_CUSTOMBACKGROUNDCOLOR = -1;
		const int DEFAULT_CORNERRADIUS = 5;

		FlatUI.FlatFontFamily fontFamily = FlatUI.DefaultFontFamily;
		FlatUI.FlatFontWeight fontWeight = FlatUI.DefaultFontWeight;

		int textColor = DEFAULT_TEXTCOLOR;
		int backgroundColor = DEFAULT_BACKGROUNDCOLOR;
		int customBackgroundColor = DEFAULT_CUSTOMBACKGROUNDCOLOR;
		int cornerRadius = DEFAULT_CORNERRADIUS;


		public FlatTextView(Context context) : base(context)
		{
			init(null);
		}

		public FlatTextView(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			init(attrs);
		}

		public FlatTextView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
		{
			init(attrs);
		}

		public FlatTheme Theme
		{
			get { return theme; }
			set { theme = value; init (null); }
		}

		void init(IAttributeSet attrs)
		{
			if (attrs != null)
			{
				var a = Context.ObtainStyledAttributes (attrs, Resource.Styleable.FlatUI);

				var themeName = a.GetString (Resource.Styleable.FlatUI_theme) ?? string.Empty;

				theme = FlatUI.GetTheme (themeName);

				textColor = a.GetInt (Resource.Styleable.FlatUI_textColor, textColor);
				backgroundColor = a.GetInt (Resource.Styleable.FlatUI_backgroundColor, backgroundColor);
				customBackgroundColor = a.GetInt (Resource.Styleable.FlatUI_customBackgroundColor, customBackgroundColor);
				cornerRadius = a.GetInt (Resource.Styleable.FlatUI_cornerRadius, cornerRadius);

				Enum.TryParse<FlatUI.FlatFontFamily> (
					a.GetInt (Resource.Styleable.FlatUI_fontFamily, (int)fontFamily).ToString (), out fontFamily);
				Enum.TryParse<FlatUI.FlatFontWeight> (
					a.GetInt (Resource.Styleable.FlatUI_fontWeight, (int)fontWeight).ToString (), out fontWeight);

				a.Recycle ();
			}

			SetTheme (this, theme, fontFamily, fontWeight, textColor, backgroundColor, customBackgroundColor, cornerRadius);

		}

		public static void SetTheme(TextView textView, FlatTheme theme)
		{
			SetTheme (textView, theme, FlatUI.DefaultFontFamily, FlatUI.DefaultFontWeight,
				DEFAULT_TEXTCOLOR, DEFAULT_BACKGROUNDCOLOR, DEFAULT_CUSTOMBACKGROUNDCOLOR, DEFAULT_CORNERRADIUS);
		}

		public static void SetTheme(TextView textView, FlatTheme theme,
			FlatUI.FlatFontFamily fontFamily, FlatUI.FlatFontWeight fontWeight, int textColor, int backgroundColor,
			int customBackgroundColor, int cornerRadius)
		{

			if (backgroundColor != -1)
			{
				var bgColor = theme.DarkAccentColor;

				if (backgroundColor == 0)
					bgColor = theme.DarkAccentColor;
				else if (backgroundColor == 1)
					bgColor = theme.BackgroundColor;
				else if (backgroundColor == 2)
					bgColor = theme.LightAccentColor;
				else if (backgroundColor == 3)
					bgColor = theme.VeryLightAccentColor;

				GradientDrawable gradientDrawable = new GradientDrawable();
				gradientDrawable.SetColor(bgColor);
				gradientDrawable.SetCornerRadius(cornerRadius);
				textView.SetBackgroundDrawable(gradientDrawable);
			} 
			else if (customBackgroundColor != -1) 
			{
				var bgColor = theme.DarkAccentColor;

				if (customBackgroundColor == 0)
					bgColor = theme.DarkAccentColor;
				else if (customBackgroundColor == 1)
					bgColor = theme.BackgroundColor;
				else if (customBackgroundColor == 2)
					bgColor = theme.LightAccentColor;
				else if (customBackgroundColor == 3)
					bgColor = theme.VeryLightAccentColor;

				GradientDrawable gradientDrawable = new GradientDrawable();
				gradientDrawable.SetColor(bgColor);
				gradientDrawable.SetCornerRadius(cornerRadius);
				textView.SetBackgroundDrawable(gradientDrawable);
			}

			var txtColor = theme.VeryLightAccentColor;
			if (textColor == 0)
				txtColor = theme.DarkAccentColor;
			if (textColor == 1)
				txtColor = theme.BackgroundColor;
			if (textColor == 2)
				txtColor = theme.LightAccentColor;
			if (textColor == 3)
				txtColor = theme.VeryLightAccentColor;

			textView.SetTextColor(txtColor);

			var typeface = FlatUI.GetFont(textView.Context, fontFamily, fontWeight);
			if (typeface != null)
				textView.SetTypeface(typeface, TypefaceStyle.Normal);
		}
	}
}

