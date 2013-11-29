using System;
using Android.Graphics;

namespace FlatUI
{
	public class FlatTheme
	{
		public Color Color1 { get;set; }
		public Color Color2 { get;set; }
		public Color Color3 { get;set; }
		public Color Color4 { get;set; }

		public static FlatTheme Sand()
		{
			return new FlatTheme() { 
				Color1 = Color.ParseColor("#ad843d"),
				Color2 = Color.ParseColor("#d4a14a"),
				Color3 = Color.ParseColor("#fbbf58"),
				Color4 = Color.ParseColor("#fae8c8")
			};
		}

		public static FlatTheme Orange()
		{
			return new FlatTheme() { 
				Color1 = Color.ParseColor("#994628"),
				Color2 = Color.ParseColor("#cc5d35"),
				Color3 = Color.ParseColor("#ff7342"),
				Color4 = Color.ParseColor("#ffbfa8")
			};
		}

		public static FlatTheme Candy()
		{
			return new FlatTheme() { 
				Color1 = Color.ParseColor("#80363c"),
				Color2 = Color.ParseColor("#bf505a"),
				Color3 = Color.ParseColor("#f56773"),
				Color4 = Color.ParseColor("#f5c4c8")
			};
		}

		public static FlatTheme Blossom()
		{
			return new FlatTheme() { 
				Color1 = Color.ParseColor("#8f5e76"),
				Color2 = Color.ParseColor("#b57795"),
				Color3 = Color.ParseColor("#e898bf"),
				Color4 = Color.ParseColor("#e8d1dc")
			};
		}

		public static FlatTheme Grape()
		{
			return new FlatTheme() { 
				Color1 = Color.ParseColor("#362f4a"),
				Color2 = Color.ParseColor("#4f456b"),
				Color3 = Color.ParseColor("#695b8e"),
				Color4 = Color.ParseColor("#b1a2db")
			};
		}

		public static FlatTheme Sky()
		{
			return new FlatTheme() { 
				Color1 = Color.ParseColor("#0b6978"),
				Color2 = Color.ParseColor("#0e8b9e"),
				Color3 = Color.ParseColor("#13b7d2"),
				Color4 = Color.ParseColor("#b9e4eb")
			};
		}

		public static FlatTheme Sea()
		{
			return new FlatTheme() { 
				Color1 = Color.ParseColor("#1a3b6c"),
				Color2 = Color.ParseColor("#1c52a2"),
				Color3 = Color.ParseColor("#2d72d9"),
				Color4 = Color.ParseColor("#d5e3f7")
			};
		}

		public static FlatTheme Grass()
		{
			return new FlatTheme() { 
				Color1 = Color.ParseColor("#124c38"),
				Color2 = Color.ParseColor("#1e7d5b"),
				Color3 = Color.ParseColor("#2ab081"),
				Color4 = Color.ParseColor("#a8e3ce")
			};
		}

		public static FlatTheme Dark()
		{
			return new FlatTheme() { 
				Color1 = Color.ParseColor("#050505"),
				Color2 = Color.ParseColor("#202020"),
				Color3 = Color.ParseColor("#454545"),
				Color4 = Color.ParseColor("#a3a3a3")
			};
		}

		public static FlatTheme Snow()
		{
			return new FlatTheme() { 
				Color1 = Color.ParseColor("#c8c8c8"),
				Color2 = Color.ParseColor("#dddddd"),
				Color3 = Color.ParseColor("#e8e8e8"),
				Color4 = Color.ParseColor("#fafafa")
			};
		}

		public static FlatTheme Blood()
		{
			return new FlatTheme() { 
				Color1 = Color.ParseColor("#732219"),
				Color2 = Color.ParseColor("#a63124"),
				Color3 = Color.ParseColor("#d94130"),
				Color4 = Color.ParseColor("#f2b6ae")
			};
		}

		public static FlatTheme Deep()
		{
			return new FlatTheme() { 
				Color1 = Color.ParseColor("#232b35"),
				Color2 = Color.ParseColor("#2d3845"),
				Color3 = Color.ParseColor("#455569"),
				Color4 = Color.ParseColor("#c7dbf4")
			};
		}
	}
}

