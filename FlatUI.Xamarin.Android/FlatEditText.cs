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
		int fontId = (int)FlatUI.DefaultFontFamily;
		int fontWeight = (int)FlatUI.DefaultFontWeight;
		FlatTheme theme = FlatUI.DefaultTheme;
		int radius = 5;
		int padding = 10;
		int border = 3;
		int style = 0;
		int textAppearance = 0;

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

		void init(IAttributeSet attrs) 
		{
			if (attrs != null) 
			{
				var a = Context.ObtainStyledAttributes(attrs, Resource.Styleable.FlatUI);

				var themeName = a.GetString (Resource.Styleable.FlatUI_theme) ?? string.Empty;

				theme = FlatUI.GetTheme (themeName);

				style = a.GetInt(Resource.Styleable.FlatUI_fieldStyle, 0);
				radius = a.GetDimensionPixelSize(Resource.Styleable.FlatUI_cornerRadius, radius);
				padding = a.GetDimensionPixelSize(Resource.Styleable.FlatUI_textPadding, padding);
				textAppearance = a.GetInt(Resource.Styleable.FlatUI_textAppearance, textAppearance);

				fontId = a.GetInt(Resource.Styleable.FlatUI_fontFamily, fontId);
				fontWeight = a.GetInt(Resource.Styleable.FlatUI_fontWeight, fontWeight);

				a.Recycle();
			}

			float[] outerR = new float[]{radius, radius, radius, radius, radius, radius, radius, radius};

			// creating normal state drawable
			var normalFront = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			normalFront.SetPadding(padding, padding, padding, padding);

			var normalBack = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			normalBack.SetPadding(border, border, border, border);

			if (style == 0) {             // flat
				normalFront.Paint.Color = Color.Transparent;
				normalBack.Paint.Color = theme.Color3;
				SetTextColor(theme.Color4);

			} else if (style == 1) {      // box
				normalFront.Paint.Color = Color.White;
				normalBack.Paint.Color = theme.Color3;
				SetTextColor(theme.Color2);

			} else if (style == 2) {      // transparent
				normalFront.Paint.Color = Color.Transparent;
				normalBack.Paint.Color = Color.Transparent;
				SetTextColor(theme.Color2);
			}

			Drawable[] d = {normalBack, normalFront};
			LayerDrawable normal = new LayerDrawable(d);

			SetBackgroundDrawable(normal);

			SetHintTextColor(theme.Color4);

			if (textAppearance == 1) SetTextColor(theme.Color1);
			else if (textAppearance == 2) SetTextColor(theme.Color4);

			var typeface = FlatUI.GetFont(Context, fontId, fontWeight);
			if (typeface != null)
				SetTypeface(typeface);
		}
	}
}

