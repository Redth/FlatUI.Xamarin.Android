using System;
using Android.Content;
using Android.Util;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Graphics;


namespace FlatUI
{
	public class FlatCheckBox : CheckBox
	{
		int fontId = (int)FlatUI.DefaultFontFamily;
		int fontWeight = (int)FlatUI.DefaultFontWeight;
		FlatTheme theme = FlatUI.DefaultTheme;
		int radius = 3;
		int border = 5;
		int size = 34;

		public FlatCheckBox(Context context) : base(context)
		{
			init(null);
		}

		public FlatCheckBox(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			init(attrs);
		}

		public FlatCheckBox(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
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

				radius = a.GetDimensionPixelSize(Resource.Styleable.FlatUI_cornerRadius, radius);
				size = a.GetDimensionPixelSize(Resource.Styleable.FlatUI_size, size);

				fontId = a.GetInt(Resource.Styleable.FlatUI_fontFamily, fontId);
				fontWeight = a.GetInt(Resource.Styleable.FlatUI_fontWeight, fontWeight);

				a.Recycle();
			}

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
			InsetDrawable checkedInside = new InsetDrawable(checkedCore, border + 2, border + 2, border + 2, border + 2);

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
			SetButtonDrawable(states);

			// setting padding for avoiding text to be appear on icon
			SetPadding(size / 4 * 5, 0, 0, 0);
			SetTextColor(theme.LightAccentColor);

			var typeface = FlatUI.GetFont(Context, fontId, fontWeight);
			if (typeface != null) 
				SetTypeface(typeface, TypefaceStyle.Normal);
		}
	}
}

