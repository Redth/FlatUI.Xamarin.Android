using System;
using Android.Content;
using Android.Util;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Graphics;


namespace FlatUI
{
	public class FlatRadioButton : RadioButton
	{
		FlatTheme theme = FlatUI.DefaultTheme;
		const int DEFAULT_RADIUS = 3;
		const int DEFAULT_BORDER = 5;
		const int DEFAULT_SIZE = 34;

		FlatUI.FlatFontFamily fontFamily = FlatUI.DefaultFontFamily;
		FlatUI.FlatFontWeight fontWeight = FlatUI.DefaultFontWeight;
		int radius = DEFAULT_RADIUS;
		int border = DEFAULT_BORDER;
		int size = DEFAULT_SIZE;

		public FlatRadioButton(Context context) : base(context)
		{
			init(null);
		}

		public FlatRadioButton(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			init(attrs);
		}

		public FlatRadioButton(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
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

				radius = a.GetDimensionPixelSize (Resource.Styleable.FlatUI_cornerRadius, radius);
				size = a.GetDimensionPixelSize (Resource.Styleable.FlatUI_size, size);

				Enum.TryParse<FlatUI.FlatFontFamily> (
					a.GetInt (Resource.Styleable.FlatUI_fontFamily, (int)fontFamily).ToString (), out fontFamily);
				Enum.TryParse<FlatUI.FlatFontWeight> (
					a.GetInt (Resource.Styleable.FlatUI_fontWeight, (int)fontWeight).ToString (), out fontWeight);

				a.Recycle ();
			}

			SetTheme (this, theme, fontFamily, fontWeight, radius, size, border);
		}

		public static void SetTheme(RadioButton radioButton, FlatTheme theme)
		{
			SetTheme(radioButton, theme, FlatUI.DefaultFontFamily, FlatUI.DefaultFontWeight, DEFAULT_RADIUS, DEFAULT_SIZE, DEFAULT_BORDER);
		}

		public static void SetTheme(RadioButton radioButton, FlatTheme theme, 
			FlatUI.FlatFontFamily fontFamily, FlatUI.FlatFontWeight fontWeight,	int radius, int size, int border)
		{

			// creating unchecked-enabled state drawable
			GradientDrawable uncheckedEnabled = new GradientDrawable();
			uncheckedEnabled.SetCornerRadius(radius);
			uncheckedEnabled.SetSize(size, size);
			uncheckedEnabled.SetColor(Color.Transparent);
			uncheckedEnabled.SetStroke(border, theme.LightAccentColor);

			// creating checked-enabled state drawable
			GradientDrawable checkedOutside = new GradientDrawable();
			checkedOutside.SetCornerRadius(radius);
			checkedOutside.SetSize(size, size);
			checkedOutside.SetColor(Color.Transparent);
			checkedOutside.SetStroke(border, theme.LightAccentColor);

			PaintDrawable checkedCore = new PaintDrawable(theme.LightAccentColor);
			checkedCore.SetCornerRadius(radius);
			checkedCore.SetIntrinsicHeight(size);
			checkedCore.SetIntrinsicWidth(size);
			var checkedInside = new InsetDrawable(checkedCore, border + 2, border + 2, border + 2, border + 2);

			Drawable[] checkedEnabledDrawable = {checkedOutside, checkedInside};
			LayerDrawable checkedEnabled = new LayerDrawable(checkedEnabledDrawable);

			// creating unchecked-enabled state drawable
			GradientDrawable uncheckedDisabled = new GradientDrawable();
			uncheckedDisabled.SetCornerRadius(radius);
			uncheckedDisabled.SetSize(size, size);
			uncheckedDisabled.SetColor(Color.Transparent);
			uncheckedDisabled.SetStroke(border, theme.VeryLightAccentColor);

			// creating checked-disabled state drawable
			GradientDrawable checkedOutsideDisabled = new GradientDrawable();
			checkedOutsideDisabled.SetCornerRadius(radius);
			checkedOutsideDisabled.SetSize(size, size);
			checkedOutsideDisabled.SetColor(Color.Transparent);
			checkedOutsideDisabled.SetStroke(border, theme.VeryLightAccentColor);

			PaintDrawable checkedCoreDisabled = new PaintDrawable(theme.VeryLightAccentColor);
			checkedCoreDisabled.SetCornerRadius(radius);
			checkedCoreDisabled.SetIntrinsicHeight(size);
			checkedCoreDisabled.SetIntrinsicWidth(size);
			InsetDrawable checkedInsideDisabled = new InsetDrawable(checkedCoreDisabled, border + 2, border + 2, border + 2, border + 2);

			Drawable[] checkedDisabledDrawable = {checkedOutsideDisabled, checkedInsideDisabled};
			LayerDrawable checkedDisabled = new LayerDrawable(checkedDisabledDrawable);


			StateListDrawable states = new StateListDrawable();
			states.AddState(new int[]{-Android.Resource.Attribute.StateChecked, Android.Resource.Attribute.StateEnabled}, uncheckedEnabled);
			states.AddState(new int[]{Android.Resource.Attribute.StateChecked, Android.Resource.Attribute.StateEnabled}, checkedEnabled);
			states.AddState(new int[]{-Android.Resource.Attribute.StateChecked, -Android.Resource.Attribute.StateEnabled}, uncheckedDisabled);
			states.AddState(new int[]{Android.Resource.Attribute.StateChecked, -Android.Resource.Attribute.StateEnabled}, checkedDisabled);
			radioButton.SetButtonDrawable(states);

			// setting padding for avoiding text to be appear on icon
			radioButton.SetPadding(size / 4 * 5, 0, 0, 0);
			radioButton.SetTextColor(theme.LightAccentColor);

			var typeface = FlatUI.GetFont(radioButton.Context, fontFamily, fontWeight);
			if (typeface != null) 
				radioButton.SetTypeface(typeface, TypefaceStyle.Normal);
		}
	}
}

