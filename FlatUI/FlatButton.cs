using System;
using Android.Content;
using Android.Util;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;


namespace FlatUI
{
	public class FlatButton : Button
	{
		const int DEFAULT_RADIUS = 5;
		const int DEFAULT_PADDING = 10;
		const bool DEFAULT_ISFULLFLAT = false;

		FlatTheme theme = FlatUI.DefaultTheme;

		int radius = DEFAULT_RADIUS;
		int padding = DEFAULT_PADDING;
		bool isFullFlat = DEFAULT_ISFULLFLAT;
		FlatUI.FlatFontFamily fontFamily = FlatUI.DefaultFontFamily;
		FlatUI.FlatFontWeight fontWeight = FlatUI.DefaultFontWeight;
		FlatUI.FlatTextAppearance textAppearance = FlatUI.DefaultTextAppearance;

		public FlatButton(Context context) : base(context)
		{
			init(null);
		}

		public FlatButton(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			init(attrs);
		}

		public FlatButton(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
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

				padding = a.GetDimensionPixelSize(Resource.Styleable.FlatUI_textPadding, padding);
				radius = a.GetDimensionPixelSize(Resource.Styleable.FlatUI_cornerRadius, radius);
				isFullFlat = a.GetBoolean(Resource.Styleable.FlatUI_isFullFlat, isFullFlat);

				Enum.TryParse<FlatUI.FlatTextAppearance> (
					a.GetInt(Resource.Styleable.FlatUI_textAppearance, (int)textAppearance).ToString(), out textAppearance);
				Enum.TryParse<FlatUI.FlatFontFamily>(
					a.GetInt(Resource.Styleable.FlatUI_fontFamily, (int)fontFamily).ToString(), out fontFamily);
				Enum.TryParse<FlatUI.FlatFontWeight>(
					a.GetInt(Resource.Styleable.FlatUI_fontWeight, (int)fontWeight).ToString(), out fontWeight);

				a.Recycle();
			}

			SetTheme (this, theme, textAppearance, fontFamily, fontWeight, isFullFlat, padding, radius);
		}

		public static void SetTheme(Button button, FlatTheme theme)
		{
			SetTheme (button, theme, FlatUI.DefaultTextAppearance, FlatUI.DefaultFontFamily, FlatUI.DefaultFontWeight, 
				DEFAULT_ISFULLFLAT, DEFAULT_PADDING, DEFAULT_RADIUS);
		}

		public static void SetTheme(Button button, FlatTheme theme, FlatUI.FlatTextAppearance textAppearance,
			FlatUI.FlatFontFamily fontFamily, FlatUI.FlatFontWeight fontWeight, bool isFullFlat, int padding, int radius)
		{
			var bottom = 5;

			float[] outerR = {radius, radius, radius, radius, radius, radius, radius, radius};

			// creating normal state drawable
			var normalFront = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			normalFront.Paint.Color = theme.LightAccentColor;
			normalFront.SetPadding(padding, padding, padding, padding);

			var normalBack = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			normalBack.Paint.Color = theme.BackgroundColor;

			if (isFullFlat) 
				bottom = 0;

			normalBack.SetPadding(0, 0, 0, bottom);

			Drawable[] d = {normalBack, normalFront};
			var normal = new LayerDrawable(d);

			// creating pressed state drawable
			var pressedFront = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			pressedFront.Paint.Color = theme.BackgroundColor;

			var pressedBack = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			pressedBack.Paint.Color = theme.DarkAccentColor;

			if (!isFullFlat) 
				pressedBack.SetPadding(0, 0, 0, 3);

			Drawable[] d2 = {pressedBack, pressedFront};
			var pressed = new LayerDrawable(d2);

			// creating disabled state drawable
			var disabledFront = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			disabledFront.Paint.Color = theme.VeryLightAccentColor;

			var disabledBack = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			disabledBack.Paint.Color = theme.LightAccentColor;
			if (!isFullFlat) disabledBack.SetPadding(0, 0, 0, padding);

			Drawable[] d3 = {disabledBack, disabledFront};
			var disabled = new LayerDrawable(d3);

			var states = new StateListDrawable();

			states.AddState(new []{ Android.Resource.Attribute.StatePressed, Android.Resource.Attribute.StateEnabled }, pressed);
			states.AddState(new []{ Android.Resource.Attribute.StateFocused, Android.Resource.Attribute.StateEnabled }, pressed);
			states.AddState(new []{ Android.Resource.Attribute.StateEnabled }, normal);
			states.AddState(new []{-Android.Resource.Attribute.StateEnabled}, disabled);

			button.SetBackgroundDrawable (states);

			if (textAppearance == FlatUI.FlatTextAppearance.Dark) 
				button.SetTextColor(theme.DarkAccentColor);
			else if (textAppearance == FlatUI.FlatTextAppearance.Light) 
				button.SetTextColor(theme.VeryLightAccentColor);
			else 
				button.SetTextColor(Android.Graphics.Color.White);

			var typeface = FlatUI.GetFont(button.Context, fontFamily, fontWeight);
			if (typeface != null)
				button.SetTypeface(typeface, Android.Graphics.TypefaceStyle.Normal);
		}
	}
}

