using System;
using Android.Graphics;

namespace FlatUI
{
	public class FlatTheme
	{
		public Color DarkAccentColor { get;set; }
		public Color BackgroundColor { get;set; }
		public Color LightAccentColor { get;set; }
		public Color VeryLightAccentColor { get;set; }

		public static FlatTheme Sand()
		{
			return new FlatTheme() { 
				DarkAccentColor = Color.ParseColor("#ad843d"),
				BackgroundColor = Color.ParseColor("#d4a14a"),
				LightAccentColor = Color.ParseColor("#fbbf58"),
				VeryLightAccentColor = Color.ParseColor("#fae8c8")
			};
		}

		public static FlatTheme Orange()
		{
			return new FlatTheme() { 
				DarkAccentColor = Color.ParseColor("#994628"),
				BackgroundColor = Color.ParseColor("#cc5d35"),
				LightAccentColor = Color.ParseColor("#ff7342"),
				VeryLightAccentColor = Color.ParseColor("#ffbfa8")
			};
		}

		public static FlatTheme Candy()
		{
			return new FlatTheme() { 
				DarkAccentColor = Color.ParseColor("#80363c"),
				BackgroundColor = Color.ParseColor("#bf505a"),
				LightAccentColor = Color.ParseColor("#f56773"),
				VeryLightAccentColor = Color.ParseColor("#f5c4c8")
			};
		}

		public static FlatTheme Blossom()
		{
			return new FlatTheme() { 
				DarkAccentColor = Color.ParseColor("#8f5e76"),
				BackgroundColor = Color.ParseColor("#b57795"),
				LightAccentColor = Color.ParseColor("#e898bf"),
				VeryLightAccentColor = Color.ParseColor("#e8d1dc")
			};
		}

		public static FlatTheme Grape()
		{
			return new FlatTheme() { 
				DarkAccentColor = Color.ParseColor("#362f4a"),
				BackgroundColor = Color.ParseColor("#4f456b"),
				LightAccentColor = Color.ParseColor("#695b8e"),
				VeryLightAccentColor = Color.ParseColor("#b1a2db")
			};
		}

		public static FlatTheme Sky()
		{
			return new FlatTheme() { 
				DarkAccentColor = Color.ParseColor("#0b6978"),
				BackgroundColor = Color.ParseColor("#0e8b9e"),
				LightAccentColor = Color.ParseColor("#13b7d2"),
				VeryLightAccentColor = Color.ParseColor("#b9e4eb")
			};
		}

		public static FlatTheme Sea()
		{
			return new FlatTheme() { 
				DarkAccentColor = Color.ParseColor("#1a3b6c"),
				BackgroundColor = Color.ParseColor("#1c52a2"),
				LightAccentColor = Color.ParseColor("#2d72d9"),
				VeryLightAccentColor = Color.ParseColor("#d5e3f7")
			};
		}

		public static FlatTheme Grass()
		{
			return new FlatTheme() { 
				DarkAccentColor = Color.ParseColor("#124c38"),
				BackgroundColor = Color.ParseColor("#1e7d5b"),
				LightAccentColor = Color.ParseColor("#2ab081"),
				VeryLightAccentColor = Color.ParseColor("#a8e3ce")
			};
		}

		public static FlatTheme Dark()
		{
			return new FlatTheme() { 
				DarkAccentColor = Color.ParseColor("#050505"),
				BackgroundColor = Color.ParseColor("#202020"),
				LightAccentColor = Color.ParseColor("#454545"),
				VeryLightAccentColor = Color.ParseColor("#a3a3a3")
			};
		}

		public static FlatTheme Snow()
		{
			return new FlatTheme() { 
				DarkAccentColor = Color.ParseColor("#c8c8c8"),
				BackgroundColor = Color.ParseColor("#dddddd"),
				LightAccentColor = Color.ParseColor("#e8e8e8"),
				VeryLightAccentColor = Color.ParseColor("#fafafa")
			};
		}

		public static FlatTheme Blood()
		{
			return new FlatTheme() { 
				DarkAccentColor = Color.ParseColor("#732219"),
				BackgroundColor = Color.ParseColor("#a63124"),
				LightAccentColor = Color.ParseColor("#d94130"),
				VeryLightAccentColor = Color.ParseColor("#f2b6ae")
			};
		}

		public static FlatTheme Deep()
		{
			return new FlatTheme() { 
				DarkAccentColor = Color.ParseColor("#232b35"),
				BackgroundColor = Color.ParseColor("#2d3845"),
				LightAccentColor = Color.ParseColor("#455569"),
				VeryLightAccentColor = Color.ParseColor("#c7dbf4")
			};
		}
	}
}

