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
		int fontId = (int)FlatUI.DefaultFontFamily;
		int fontWeight = (int)FlatUI.DefaultFontWeight;
		FlatTheme theme = FlatUI.DefaultTheme;

		int textColor = 2;
		int backgroundColor = -1;
		int customBackgroundColor = -1;
		int cornerRadius = 5;

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
				var a = Context.ObtainStyledAttributes(attrs, Resource.Styleable.FlatUI);

				var themeName = a.GetString (Resource.Styleable.FlatUI_theme) ?? string.Empty;

				theme = FlatUI.GetTheme (themeName);

				textColor = a.GetInt(Resource.Styleable.FlatUI_textColor, textColor);
				backgroundColor = a.GetInt(Resource.Styleable.FlatUI_backgroundColor, backgroundColor);
				customBackgroundColor = a.GetInt(Resource.Styleable.FlatUI_customBackgroundColor, customBackgroundColor);
				cornerRadius = a.GetInt(Resource.Styleable.FlatUI_cornerRadius, cornerRadius);

				fontId = a.GetInt(Resource.Styleable.FlatUI_fontFamily, fontId);
				fontWeight = a.GetInt(Resource.Styleable.FlatUI_fontWeight, fontWeight);

				a.Recycle();
			}

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
				SetBackgroundDrawable(gradientDrawable);
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
				SetBackgroundDrawable(gradientDrawable);
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

			SetTextColor(txtColor);

			var typeface = FlatUI.GetFont(Context, fontId, fontWeight);
			if (typeface != null)
				SetTypeface(typeface, TypefaceStyle.Normal);
		}
	}
}

