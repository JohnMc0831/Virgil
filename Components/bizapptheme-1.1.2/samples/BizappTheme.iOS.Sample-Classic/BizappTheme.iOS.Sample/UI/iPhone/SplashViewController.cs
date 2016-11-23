using System;
#if __UNIFIED__
using UIKit;
using Foundation;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
using System.Drawing;

namespace ThemeSample.UI {
	public partial class SplashViewController : UIViewController {
		public SplashViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			if (UIDevice.CurrentDevice.CheckSystemVersion (7, 0)) 
				EdgesForExtendedLayout = UIRectEdge.None;

			logoLabel.ShadowColor = UIColor.Black;
			logoLabel.ShadowOffset = new SizeF (0, 1);

			logoLabel.ShadowBlur = 0.5f;
			logoLabel.GradientStartColor = new UIColor (163/255f, 203 / 255f, 222 / 255f, 0.9f);
			logoLabel.GradientEndColor = UIColor.White;

			callUsButt.TouchUpInside += (sender, e) => CallNumber ();
			directionsButton.TouchUpInside += (sender, e) => OpenMap ();

			base.ViewDidLoad ();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		void CallNumber ()
		{
			UIApplication app = UIApplication.SharedApplication;
			app.OpenUrl (NSUrl.FromString (string.Format (@"tel:130-032-2837"))); 
		}

		void OpenMap ()
		{
			UIApplication app = UIApplication.SharedApplication;
			app.OpenUrl (NSUrl.FromString ("http://maps.google.com/maps?q=Paris")); 
		}

		[Obsolete ("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation")]
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return YES for supported orientations
			return (toInterfaceOrientation == UIInterfaceOrientation.Portrait);
		}


	}
}
