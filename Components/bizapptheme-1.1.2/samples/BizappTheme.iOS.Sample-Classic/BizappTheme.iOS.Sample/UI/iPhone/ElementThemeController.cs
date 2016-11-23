using System;
using System.Drawing;
#if __UNIFIED__
using UIKit;
#else
using MonoTouch.UIKit;
#endif
using Xamarin.Themes;

namespace ThemeSample.UI {
	public partial class ElementThemeController : UIViewController {
		public ElementThemeController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			if (UIDevice.CurrentDevice.CheckSystemVersion (7, 0)) 
				EdgesForExtendedLayout = UIRectEdge.None;

			View.BackgroundColor = UIColor.Black;
			
			AddButtonAtLocation (new RectangleF (17, 90, 287, 47), ButtonOptions.ConfirmBig, "Larger Confirm Button", 20f);
			AddButtonAtLocation (new RectangleF (17, 145, 287, 47), ButtonOptions.CancelBig, "Large Cancel Button", 20f);
			AddButtonAtLocation (new RectangleF (17, 200, 287, 47), ButtonOptions.Standart, "Large Standard Button", 20f);

			AddButtonAtLocation (new RectangleF (17, 255, 142, 47), ButtonOptions.CancelSmall, "Small Cancel", 16f);
			AddButtonAtLocation (new RectangleF (162, 255, 142, 47), ButtonOptions.ConfirmSmall, "Small Confirm", 16f);
			AddButtonAtLocation (new RectangleF (17, 310, 142, 47), ButtonOptions.LightSmall, "Small Cancel", 16f);
			AddButtonAtLocation (new RectangleF (162, 310, 142, 47), ButtonOptions.LightSmall, "Small Confirm", 16f);

			CustomizeLabel ();
			CustomizeTextField ();
			AddSlider ();

			Xamarin.Themes.BizappTheme.Apply (View);
			
			base.ViewDidLoad ();
			// Do any additional setup after loading the view from its nib.
		}

		void Back ()
		{
			#if __UNIFIED__
			NavigationController.PopViewController (true);
			#else
			NavigationController.PopViewControllerAnimated (true);
			#endif
		}

		void CustomizeLabel ()
		{
			UILabel textLabel = new UILabel (new RectangleF (22, 10, 200, 30));

			textLabel.Font = UIFont.BoldSystemFontOfSize (20);
			
			textLabel.Text = "Label";
			Xamarin.Themes.BizappTheme.Apply (textLabel);

			View.AddSubview (textLabel);
		}

		void CustomizeTextField ()
		{
			Xamarin.Themes.BizappTheme.Apply (textField);
			textField.ShouldReturn = delegate {
				textField.ResignFirstResponder ();
				return true;
			
			};
			
		}

		void AddSlider ()
		{
			UISlider slider = new UISlider (new RectangleF (17, 370, 287, 10));
			
			slider.SetValue (0.5f, false);
			View.AddSubview (slider);
		}

		void AddButtonAtLocation (RectangleF location, ButtonOptions options, string title, float size)
		{
			UIButton button = new UIButton (location);
			
			Xamarin.Themes.BizappTheme.Apply (button, options);
			
			button.SetTitle (title, UIControlState.Normal);
			button.TitleLabel.Font = UIFont.BoldSystemFontOfSize (size);
			
			View.AddSubview (button);
		}

		bool TextFieldShouldReturn (UITextField aTextField)
		{
			aTextField.ResignFirstResponder ();
			return true;
		}

		[Obsolete ("Deprecated in iOS 6.0", false)]
		public override void ViewDidUnload ()
		{
			textField = null;
			base.ViewDidUnload ();
		}

		[Obsolete ("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation")]
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return YES for supported orientations
			return (toInterfaceOrientation == UIInterfaceOrientation.Portrait);
		}
	}
}
