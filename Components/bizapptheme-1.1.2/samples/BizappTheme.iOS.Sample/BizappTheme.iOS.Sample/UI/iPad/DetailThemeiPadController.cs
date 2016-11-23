using System;
using System.Collections.Generic;
using System.Drawing;

#if __UNIFIED__
using UIKit;
using Foundation;
using CoreGraphics;
using CoreAnimation;

#else
using MonoTouch.CoreAnimation;
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using CGRect = global::System.Drawing.RectangleF;
using CGPoint = global::System.Drawing.PointF;
using CGSize = global::System.Drawing.SizeF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif


using ThemeSample.Models;

namespace ThemeSample.UI {
	public partial class DetailThemeiPadController : UIViewController {
		Model[] models;
		int leftMargin;
		int padding;
		List<UIView> scrollTabs;
		CAGradientLayer gradientLayer;

		public DetailThemeiPadController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLayoutSubviews ()
		{
			base.ViewDidLayoutSubviews ();

			gradientLayer.Frame = gradientView.Bounds;

		}

		public override void ViewDidLoad ()
		{
			LoadDetailViewDesign ();
			LoadDetailViewInformation ();

			if (UIDevice.CurrentDevice.CheckSystemVersion (7, 0)) {
				//fix the toolbar
				var tbarFrame = toolbar.Frame;
				tbarFrame.Height = (tbarFrame.Height + 20);
				toolbar.Frame = tbarFrame;
			}


			base.ViewDidLoad ();
		}

		void LoadDetailViewInformation ()
		{
			models = DataLoader.LoadSampleData ();
			
			Model model = models [0];
			
			
			LoadContentFromModel (model);
			
			leftMargin = 20;
			padding = 20;
			int index = 0;
			
			scrollTabs = new List<UIView> ();
			foreach (Model m in models) {
				this.AddTabToSubContainer (index, m);
				index++;
			}
			
			UIView tabView = scrollTabs [0]; 

			int width = leftMargin + (int)(tabView.Frame.Width * models.Length) + (padding * models.Length);
			scrollView.ContentSize = new CGSize (width, scrollView.Frame.Height); 
			
		}

		void LoadDetailViewDesign ()
		{
			Xamarin.Themes.BizappTheme.Apply (shareBarButton);
			Xamarin.Themes.BizappTheme.Apply (likeBarButton);
			Xamarin.Themes.BizappTheme.Apply (expandBarButton);
			Xamarin.Themes.BizappTheme.Apply (subContainerView);

			gradientLayer = new CAGradientLayer ();
			gradientLayer.Frame = gradientView.Bounds;

			UIColor lightColor = UIColor.Black.ColorWithAlpha (0);
			UIColor darkColor = UIColor.Black.ColorWithAlpha (0.5f);

			gradientLayer.Colors = new CGColor[] { darkColor.CGColor, lightColor.CGColor };
			gradientView.Layer.InsertSublayer (gradientLayer, 0);
		}

		void AddTabToSubContainer (int indexOfContainer, Model model)
		{
			ScrollTabView tabView = new ScrollTabView ();
			tabView.Text = model.name;
			tabView.Image = model.image;
			
			int xPosition = leftMargin + (int)(tabView.Frame.Width * indexOfContainer) + (padding * indexOfContainer);

			tabView.Frame = new CGRect (xPosition, 20, tabView.Frame.Width, tabView.Frame.Height);

			scrollView.AddSubview (tabView);

			tabView.TouchUpInside += (sender, e) => {
				LoadTabContent (sender as UIView);
			};

			scrollTabs.Add (tabView);
		}

		void LoadTabContent (UIView tabView)
		{
			int index = scrollTabs.IndexOf (tabView);
			
			Model m = models [index];
			
			LoadContentFromModel (m);
		}

		void LoadContentFromModel (Model model)
		{
			titleLabel.Text = model.webContentTitle;
			articleContentView.LoadHtmlString (model.webContent, null);
			articleImageView.Image = model.webContentImage;
			metaLabel.Text = model.name;
		}
	}
}
