using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FlatUI;

namespace Sample
{
	[Activity (Label = "FlatUI Sample", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			FlatUI.FlatUI.DefaultTheme = FlatUI.FlatTheme.Sky ();

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
		}
	}
}


