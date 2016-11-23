using System;
using System.Drawing;
#if __UNIFIED__
using UIKit;
using Foundation;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
using ThemeSample.Models;

namespace ThemeSample.UI {
	public partial class GridViewController : UIViewController {
		Model[] services;
		int selIndex;
		GridViewCell[] cells;

		public GridViewController (IntPtr handle) : base (handle)
		{
			Title = "Services";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (UIDevice.CurrentDevice.CheckSystemVersion (7, 0)) 
				EdgesForExtendedLayout = UIRectEdge.None;

			services = DataLoader.LoadSampleData ();
			cells = new GridViewCell[services.Length];
			for (var col = 0; col < 2; col++) {
				for (var row = 0; row < 3; row++) {
					
					var cell = new GridViewCell (new RectangleF (160 * col, 123 * row, 160, 123));

					var index = col + row * 2;

					Model service = services [index];
			
					cell.Image = service.image;
					cell.Caption = service.name;
					cell.TouchUpInside += (sender, e) => {
						selIndex = index;
						PerformSegue ("detail", this);
					};

					cells [index] = cell;
					View.AddSubview (cell);
				}
			}

			Xamarin.Themes.BizappTheme.Apply (View);
		}

		void ReplaceCells (int cols, int rows, double duration)
		{
			UIView.Animate (duration, () => {
				for (int col=0; col <cols; col++) {
					for (int row = 0; row < rows; row++) {
						int index = row * cols + col;
						var cell = cells [index];

						var frame = cell.Frame;
						frame.X = 160 * col;
						frame.Y = 123 * row;

						cell.Frame = frame;
					}
				}
			});
		}

		public override void WillRotate (UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			base.WillRotate (toInterfaceOrientation, duration);

			if (toInterfaceOrientation == UIInterfaceOrientation.Portrait) {
				ReplaceCells (2, 3, duration);
			} else if (toInterfaceOrientation == UIInterfaceOrientation.LandscapeLeft || 
				toInterfaceOrientation == UIInterfaceOrientation.LandscapeRight) {
				ReplaceCells (3, 2, duration);
			}
		}

		public override void DidRotate (UIInterfaceOrientation fromInterfaceOrientation)
		{
			base.DidRotate (fromInterfaceOrientation);
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			var detailController = (DetailThemeController)segue.DestinationViewController;
			detailController.model = services [selIndex];
		}
			
	}
}
