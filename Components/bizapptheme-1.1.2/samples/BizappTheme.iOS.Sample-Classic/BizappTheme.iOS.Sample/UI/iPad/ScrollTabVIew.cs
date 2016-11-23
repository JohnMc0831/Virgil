using System;
#if __UNIFIED__
using UIKit;
#else
using MonoTouch.UIKit;
#endif
using System.Drawing;

namespace ThemeSample.UI {
	public class ScrollTabView: UIControl {
		UIImageView tabMask;
		UIImageView image;
		UILabel label;

		public ScrollTabView () : base(new RectangleF(0, 0, 223, 168))
		{
			var fr = new RectangleF (7, 9, 209, 125);
			image = new UIImageView (UIImage.FromFile("service-1.png"));
			image.Frame = fr;
			Add (image);

			fr = new RectangleF (0, 0, 223, 168);
			tabMask = new UIImageView (UIImage.FromFile("ipad-tab-mask.png"));
			tabMask.AutoresizingMask = UIViewAutoresizing.All;
			tabMask.Frame = fr;
			Add (tabMask);

			fr = new RectangleF (13, 136, 190, 21);
			label = new UILabel (fr);
			label.BackgroundColor = UIColor.Clear;
			label.Font = UIFont.SystemFontOfSize (17);
			label.ShadowColor = UIColor.Clear;
			label.Text = "Conveyancing";
			Add (label);

		}

		public UIImage Image { 
			get { 
				return image.Image; 
			} 
			set { 
				image.Image = value; 
			} 
		}

		public string Text { 
			get { 
				return label.Text; 
			} 
			set { 
				label.Text = value; 
			} 
		}
	}
}

