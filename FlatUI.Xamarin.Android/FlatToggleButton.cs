using System;
using Android.Content;
using Android.Util;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Graphics;


namespace FlatUI
{
	public class FlatToggleButton : ToggleButton
	{
		int fontId = (int)FlatUI.DefaultFontFamily;
		int fontWeight = (int)FlatUI.DefaultFontWeight;
		FlatTheme theme = FlatUI.DefaultTheme;

		int padding = 5;
		int size = 0;

		public FlatToggleButton(Context context) : base(context)
		{
			init(null);
		}

		public FlatToggleButton(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			init(attrs);
		}

		public FlatToggleButton(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
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

				size = a.GetDimensionPixelSize(Resource.Styleable.FlatUI_size, size);

				fontId = a.GetInt(Resource.Styleable.FlatUI_fontFamily, fontId);
				fontWeight = a.GetInt(Resource.Styleable.FlatUI_fontWeight, fontWeight);

				a.Recycle();
			}

			SetWidth(size * 5);
			SetHeight(size);

			//setTextOff("");
			//setTextOn("");

			int radius = size - 4;

			float[] outerR = new float[]{radius, radius, radius, radius, radius, radius, radius, radius};

			// creating unchecked-enabled state drawable
			var uncheckedEnabledFrontCore = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			uncheckedEnabledFrontCore.Paint.Color = theme.Color3;
			var uncheckedEnabledFront = new InsetDrawable(uncheckedEnabledFrontCore, 5);

			var uncheckedEnabledBack = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			uncheckedEnabledBack.Paint.Color = Color.ParseColor("#f2f2f2");
			uncheckedEnabledBack.SetPadding(0, 0, size / 2 * 5, 0);

			Drawable[] d1 = {uncheckedEnabledBack, uncheckedEnabledFront};
			var uncheckedEnabled = new LayerDrawable(d1);

			// creating checked-enabled state drawable
			var checkedEnabledFrontCore = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			checkedEnabledFrontCore.Paint.Color = theme.Color3;
			var checkedEnabledFront = new InsetDrawable(checkedEnabledFrontCore, 5);

			ShapeDrawable checkedEnabledBack = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			checkedEnabledBack.Paint.Color = theme.Color4;
			checkedEnabledBack.SetPadding(size / 2 * 5, 0, 0, 0);

			Drawable[] d2 = {checkedEnabledBack, checkedEnabledFront};
			LayerDrawable checkedEnabled = new LayerDrawable(d2);

			// creating unchecked-disabled state drawable
			ShapeDrawable uncheckedDisabledFrontCore = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			uncheckedDisabledFrontCore.Paint.Color = Color.ParseColor("#d2d2d2");
			InsetDrawable uncheckedDisabledFront = new InsetDrawable(uncheckedDisabledFrontCore, 5);

			ShapeDrawable uncheckedDisabledBack = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			uncheckedDisabledBack.Paint.Color = Color.ParseColor("#f2f2f2");
			uncheckedDisabledBack.SetPadding(0, 0, size / 2 * 5, 0);

			Drawable[] d3 = {uncheckedDisabledBack, uncheckedDisabledFront};
			LayerDrawable uncheckedDisabled = new LayerDrawable(d3);

			// creating checked-disabled state drawable
			ShapeDrawable checkedDisabledFrontCore = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			checkedDisabledFrontCore.Paint.Color = theme.Color4;
			InsetDrawable checkedDisabledFront = new InsetDrawable(checkedDisabledFrontCore, 5);

			ShapeDrawable checkedDisabledBack = new ShapeDrawable(new RoundRectShape(outerR, null, null));
			checkedDisabledBack.Paint.Color = Color.ParseColor("#f2f2f2");
			checkedDisabledBack.SetPadding(size / 2 * 5, 0, 0, 0);

			Drawable[] d4 = {checkedDisabledBack, checkedDisabledFront};
			LayerDrawable checkedDisabled = new LayerDrawable(d4);

			SetPadding(0, padding, 0, padding);

			PaintDrawable paintDrawable = new PaintDrawable(theme.Color2);
			paintDrawable.SetIntrinsicHeight(size);
			paintDrawable.SetIntrinsicWidth(size);
			paintDrawable.SetPadding(size, 0, 0, 0);

			StateListDrawable states = new StateListDrawable();

			states.AddState(new int[]{-Android.Resource.Attribute.StateChecked, Android.Resource.Attribute.StateEnabled},
				new InsetDrawable(uncheckedEnabled, padding * 2));
			states.AddState(new int[]{Android.Resource.Attribute.StateChecked, Android.Resource.Attribute.StateEnabled},
				new InsetDrawable(checkedEnabled, padding * 2));
			states.AddState(new int[]{-Android.Resource.Attribute.StateChecked, -Android.Resource.Attribute.StateEnabled},
				new InsetDrawable(uncheckedDisabled, padding * 2));
			states.AddState(new int[]{Android.Resource.Attribute.StateChecked, -Android.Resource.Attribute.StateEnabled},
				new InsetDrawable(checkedDisabled, padding * 2));

			SetBackgroundDrawable(states);

			SetTextSize(ComplexUnitType.Sp, 0);
		}
	}
}

