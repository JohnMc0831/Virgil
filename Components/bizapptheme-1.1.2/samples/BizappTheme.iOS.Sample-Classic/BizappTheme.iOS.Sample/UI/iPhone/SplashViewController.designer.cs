// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
#if __UNIFIED__
using UIKit;
using Foundation;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif

using System.CodeDom.Compiler;

namespace ThemeSample.UI
{
	[Register ("SplashViewController")]
	partial class SplashViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton callUsButt { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton directionsButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		Xamarin.Controls.iOS.Label.FXLabel logoLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (callUsButt != null) {
				callUsButt.Dispose ();
				callUsButt = null;
			}
			if (directionsButton != null) {
				directionsButton.Dispose ();
				directionsButton = null;
			}
			if (logoLabel != null) {
				logoLabel.Dispose ();
				logoLabel = null;
			}
		}
	}
}
