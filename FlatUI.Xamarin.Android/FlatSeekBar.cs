using System;
using Android.Content;
using Android.Util;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Graphics;
using Android.Views;


namespace FlatUI
{
	public class FlatSeekBar : SeekBar
	{
		FlatTheme theme = FlatUI.DefaultTheme;

		public FlatSeekBar(Context context) : base(context)
		{
			init(null);
		}

		public FlatSeekBar(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			init(attrs);
		}

		public FlatSeekBar(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
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

				a.Recycle();
			}

			// setting thumb
			var thumb = new PaintDrawable(theme.Color1);
			thumb.SetCornerRadius(15);
			thumb.SetIntrinsicWidth(30);
			thumb.SetIntrinsicHeight(30);
			SetThumb(thumb);

			// progress
			var progress = new PaintDrawable(theme.Color2);
			progress.SetCornerRadius(10);
			progress.SetIntrinsicHeight(10);
			progress.SetIntrinsicWidth(5);
			progress.SetDither(true);
			var progressClip = new ClipDrawable(progress, GravityFlags.Left, ClipDrawableOrientation.Horizontal);

			// secondary progress
			var secondary = new PaintDrawable(theme.Color3);
			secondary.SetCornerRadius(10);
			secondary.SetIntrinsicHeight(10);
			var secondaryProgressClip = new ClipDrawable(secondary, GravityFlags.Left, ClipDrawableOrientation.Horizontal);

			// background
			PaintDrawable background = new PaintDrawable(theme.Color4);
			background.SetCornerRadius(10);
			background.SetIntrinsicHeight(10);

			// applying drawable
			LayerDrawable ld = (LayerDrawable) ProgressDrawable;
			ld.SetDrawableByLayerId(Android.Resource.Id.Background, background);
			ld.SetDrawableByLayerId(Android.Resource.Id.Progress, progressClip);
			ld.SetDrawableByLayerId(Android.Resource.Id.SecondaryProgress, secondaryProgressClip);
		}
	}
}

