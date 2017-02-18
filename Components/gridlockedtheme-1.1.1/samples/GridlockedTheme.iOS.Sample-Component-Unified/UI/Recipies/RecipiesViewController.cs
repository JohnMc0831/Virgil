
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
	public partial class RecipiesViewController : UIViewController, IGridViewDelegate
	{
		GridView Grid { get; set; }

		public RecipiesViewController()
		{
			Title = "Recipies (tap on the tiles)";

			InitSubviews();
			ApplyStyles();
		}

		void InitSubviews()
		{
			Grid = new GridView((RectangleF)View.Bounds) {
				AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth,
				Delegate = this
			};
			
			Add (Grid);
			
			var data = Repository.LoadRecipiesData();
			
			foreach(var item in data)
				CreateRecipiesCell(item);
		}

		void ApplyStyles()
		{
			View.BackgroundColor = UIColor.FromPatternImage(GridlockTheme.SharedTheme.ViewBackground);
		}

		void CreateRecipiesCell(RecipiesRowData item)
		{
			var tile = new RecipiesCell();
			tile.Bind (item);

			Grid.AddTile(tile);
		}

		public void TileSelected(GridView gridView, int index)
		{
			var data = Repository.LoadRecipiesData();
			PresentViewController(new DetailsViewController(data[index]), true, null);
		}

		[Obsolete ("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation")]
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
	}
}

