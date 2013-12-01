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
		int fontId = (int)FlatUI.DefaultFontFamily;
		int fontWeight = (int)FlatUI.DefaultFontWeight;
		FlatTheme theme = FlatUI.DefaultTheme;
		int radius = 5;
		int bottom = 5;
		int padding = 10;
		int textAppearance = 1;
		bool isFullFlat = false;

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

		void init(IAttributeSet attrs) 
		{
			if (attrs != null) 
			{
				var a = Context.ObtainStyledAttributes(attrs, Resource.Styleable.FlatUI);

				var themeName = a.GetString (Resource.Styleable.FlatUI_theme) ?? string.Empty;

				theme = FlatUI.GetTheme (themeName);

				textAppearance = a.GetInt(Resource.Styleable.FlatUI_textAppearance, textAppearance);
				padding = a.GetDimensionPixelSize(Resource.Styleable.FlatUI_textPadding, padding);
				radius = a.GetDimensionPixelSize(Resource.Styleable.FlatUI_cornerRadius, radius);
				isFullFlat = a.GetBoolean(Resource.Styleable.FlatUI_isFullFlat, isFullFlat);

				fontId = a.GetInt(Resource.Styleable.FlatUI_fontFamily, fontId);
				fontWeight = a.GetInt(Resource.Styleable.FlatUI_fontWeight, fontWeight);

				a.Recycle();
			}

			float[] outerR = {radius, radius, radius, radius, radius, radius, radius, radius};

			// creating normal state drawable
			var normalFront = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			normalFront.Paint.Color = theme.Color3;
			normalFront.SetPadding(padding, padding, padding, padding);

			var normalBack = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			normalBack.Paint.Color = theme.Color2;

			if (isFullFlat) 
				bottom = 0;

			normalBack.SetPadding(0, 0, 0, bottom);

			Drawable[] d = {normalBack, normalFront};
			var normal = new LayerDrawable(d);

			// creating pressed state drawable
			var pressedFront = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			pressedFront.Paint.Color = theme.Color2;

			var pressedBack = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			pressedBack.Paint.Color = theme.Color1;

			if (!isFullFlat) 
				pressedBack.SetPadding(0, 0, 0, 3);

			Drawable[] d2 = {pressedBack, pressedFront};
			var pressed = new LayerDrawable(d2);

			// creating disabled state drawable
			var disabledFront = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			disabledFront.Paint.Color = theme.Color4;

			var disabledBack = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			disabledBack.Paint.Color = theme.Color3;
			if (!isFullFlat) disabledBack.SetPadding(0, 0, 0, padding);

			Drawable[] d3 = {disabledBack, disabledFront};
			var disabled = new LayerDrawable(d3);

			var states = new StateListDrawable();

			states.AddState(new []{ Android.Resource.Attribute.StatePressed, Android.Resource.Attribute.StateEnabled }, pressed);
			states.AddState(new []{ Android.Resource.Attribute.StateFocused, Android.Resource.Attribute.StateEnabled }, pressed);
			states.AddState(new []{ Android.Resource.Attribute.StateEnabled }, normal);
			states.AddState(new []{-Android.Resource.Attribute.StateEnabled}, disabled);

			SetBackgroundDrawable (states);

			if (textAppearance == 1) 
				SetTextColor(theme.Color1);
			else if (textAppearance == 2) 
				SetTextColor(theme.Color4);
			else 
				SetTextColor(Android.Graphics.Color.White);

			var typeface = FlatUI.GetFont(Context, fontId, fontWeight);
			if (typeface != null)
				SetTypeface(typeface, Android.Graphics.TypefaceStyle.Normal);
		}
	}
}

