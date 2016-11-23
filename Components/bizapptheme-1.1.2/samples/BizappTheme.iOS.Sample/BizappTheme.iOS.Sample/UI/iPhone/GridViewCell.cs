using System;
#if __UNIFIED__
using UIKit;
#else
using MonoTouch.UIKit;
#endif
using System.Drawing;

namespace ThemeSample.UI {
	public class GridViewCell : UIControl {

		UIImageView tabMask;
		UIImageView image;
		UILabel label;

		public GridViewCell (RectangleF frame) : base(frame)
		{
			var fr = new RectangleF (9, 4, 142, 117);
			tabMask = new UIImageView (UIImage.FromFile("tab-mask.png"));
			tabMask.Frame = fr;
			Add (tabMask);

			fr = new RectangleF (13, 8, 135, 84);
			image = new UIImageView (UIImage.FromFile("service-1.png"));
			image.Frame = fr;
			Add (image);

			fr = new RectangleF (13, 92, 127, 21);
			label = new UILabel (fr);
			label.BackgroundColor = UIColor.Clear;
			label.Font = UIFont.SystemFontOfSize (14);
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

		public string Caption { 
			get { 
				return label.Text; 
			} 
			set { 
				label.Text = value; 
			} 
		}
	}
}

