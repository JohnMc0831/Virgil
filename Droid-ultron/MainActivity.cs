using System;
//using Android;
using Android.App;
//using Android.Content;
using Android.Content.PM;
//using Android.Runtime;
//using global::Android.Views;
//using global::Android.Widget;
using Android.OS;

namespace Virgil.Droid
{
	[Activity (Label = "Virgil.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenLayout | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());
		}
	}
}

