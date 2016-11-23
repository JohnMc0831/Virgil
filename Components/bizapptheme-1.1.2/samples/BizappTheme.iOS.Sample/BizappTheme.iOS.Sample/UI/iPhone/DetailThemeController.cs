using System;
#if __UNIFIED__
using UIKit;
#else
using MonoTouch.UIKit;
#endif
using ThemeSample.Models;

namespace ThemeSample.UI {
	public partial class DetailThemeController : UIViewController {
		public Model model;

		public DetailThemeController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			if (UIDevice.CurrentDevice.CheckSystemVersion (7, 0)) 
				EdgesForExtendedLayout = UIRectEdge.None;

			this.Title = "Detail";
			titleLabel.Text = model.webContentTitle;
			articleContentView.LoadHtmlString (model.webContent, null);
			articleImageView.Image = model.webContentImage;
			metaLabel.Text = model.name;
			
			scrollView.ContentSize = new System.Drawing.SizeF (320, 700);
			
			base.ViewDidLoad ();
		}
			
	}
}
