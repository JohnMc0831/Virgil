
using System;
using System.Drawing;

#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
using Xamarin.Themes;

namespace ThemeSample.iOS
{
	public partial class FashionViewController : UIViewController
	{
		GridView Grid { get; set; }

		public FashionViewController ()
		{
			Title = "Fashion";

			UIBarButtonItem barButton = new UIBarButtonItem();
			barButton.Title = "Recipies";
			barButton.Clicked += OnRecipiesClicked;

			NavigationItem.SetRightBarButtonItem(barButton, false);

			InitSubviews();
			ApplyStyles();
		}

		void OnRecipiesClicked (object sender, EventArgs e)
		{
			NavigationController.PushViewController(new RecipiesViewController(), true);
		}

		void InitSubviews()
		{
			Grid = new GridView((RectangleF)View.Bounds) {
				AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth
			};

			Add (Grid);

			var data = Repository.LoadFashioData();

			foreach(var item in data)
				CreateFashionCell(item);
		}

		void ApplyStyles()
		{
			View.BackgroundColor = UIColor.FromPatternImage(GridlockTheme.SharedTheme.ViewBackground);
		}

		void CreateFashionCell(FashionRowData source) 
	 	{
			var cell = new FashionCell();
			cell.Bind(source);

			Grid.AddTile(cell);
		}

		[Obsolete ("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation")]
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
	}
}

