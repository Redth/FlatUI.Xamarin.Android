using System;
using Android.Content;
using Android.Util;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Graphics;


namespace FlatUI
{
	public class FlatEditText : EditText
	{
		FlatTheme theme = FlatUI.DefaultTheme;

		const int DEFAULT_RADIUS = 5;
		const int DEFAULT_PADDING = 10;
		const int DEFAULT_BORDER = 3;
		const int DEFAULT_STYLE = 0;

		FlatUI.FlatFontFamily fontFamily = FlatUI.DefaultFontFamily;
		FlatUI.FlatFontWeight fontWeight = FlatUI.DefaultFontWeight;
		FlatUI.FlatTextAppearance textAppearance = FlatUI.DefaultTextAppearance;

		int radius = DEFAULT_RADIUS;
		int padding = DEFAULT_PADDING;
		int border = DEFAULT_BORDER;
		int style = DEFAULT_STYLE;


		public FlatEditText(Context context) : base(context)
		{
			init(null);
		}

		public FlatEditText(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			init(attrs);
		}

		public FlatEditText(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
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

				style = a.GetInt (Resource.Styleable.FlatUI_fieldStyle, 0);
				radius = a.GetDimensionPixelSize (Resource.Styleable.FlatUI_cornerRadius, radius);
				padding = a.GetDimensionPixelSize (Resource.Styleable.FlatUI_textPadding, padding);

				Enum.TryParse<FlatUI.FlatTextAppearance> (
					a.GetInt (Resource.Styleable.FlatUI_textAppearance, (int)textAppearance).ToString (), out textAppearance);
				Enum.TryParse<FlatUI.FlatFontFamily> (
					a.GetInt (Resource.Styleable.FlatUI_fontFamily, (int)fontFamily).ToString (), out fontFamily);
				Enum.TryParse<FlatUI.FlatFontWeight> (
					a.GetInt (Resource.Styleable.FlatUI_fontWeight, (int)fontWeight).ToString (), out fontWeight);

				a.Recycle ();
			}

			SetTheme (this, theme, fontFamily, fontWeight, textAppearance, style, radius, padding, border);
		}

		public static void SetTheme(EditText editText, FlatTheme theme)
		{
			SetTheme (editText, theme, FlatUI.DefaultFontFamily, FlatUI.DefaultFontWeight, FlatUI.DefaultTextAppearance,
				DEFAULT_STYLE, DEFAULT_RADIUS, DEFAULT_PADDING, DEFAULT_BORDER);
		}

		public static void SetTheme(EditText editText, FlatTheme theme, 
			FlatUI.FlatFontFamily fontFamily, FlatUI.FlatFontWeight fontWeight, FlatUI.FlatTextAppearance textAppearance,
			int style, int radius, int padding, int border)
		{
			float[] outerR = new float[]{radius, radius, radius, radius, radius, radius, radius, radius};

			// creating normal state drawable
			var normalFront = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			normalFront.SetPadding(padding, padding, padding, padding);

			var normalBack = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			normalBack.SetPadding(border, border, border, border);

			if (style == 0) {             // flat
				normalFront.Paint.Color = Color.Transparent;
				normalBack.Paint.Color = theme.LightAccentColor;
				editText.SetTextColor(theme.VeryLightAccentColor);

			} else if (style == 1) {      // box
				normalFront.Paint.Color = Color.White;
				normalBack.Paint.Color = theme.LightAccentColor;
				editText.SetTextColor(theme.BackgroundColor);

			} else if (style == 2) {      // transparent
				normalFront.Paint.Color = Color.Transparent;
				normalBack.Paint.Color = Color.Transparent;
				editText.SetTextColor(theme.BackgroundColor);
			}

			Drawable[] d = {normalBack, normalFront};
			LayerDrawable normal = new LayerDrawable(d);

			editText.SetBackgroundDrawable(normal);

			editText.SetHintTextColor(theme.VeryLightAccentColor);

			if (textAppearance == FlatUI.FlatTextAppearance.Dark) editText.SetTextColor(theme.DarkAccentColor);
			else if (textAppearance == FlatUI.FlatTextAppearance.Light) editText.SetTextColor(theme.VeryLightAccentColor);

			var typeface = FlatUI.GetFont(editText.Context, fontFamily, fontWeight);
			if (typeface != null)
				editText.SetTypeface(typeface, TypefaceStyle.Normal);
		}
	}
}

