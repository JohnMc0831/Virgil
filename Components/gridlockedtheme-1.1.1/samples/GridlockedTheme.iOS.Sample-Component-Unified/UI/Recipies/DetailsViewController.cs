
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
	public partial class DetailsViewController : UIViewController
	{
		UIImageView backgroundImageView;
		UIBarButtonItem closeButton;
		UIImageView modelImageView;
		UIImageView modelBackgroundImageView;
		UIImageView lineImageView;
		UITextView ingredientsTextView;
		UILabel timeLabel;
		UILabel dificultyLabel;
		UITableView tableView;

		UIView contentView;

		RecipiesRowData data;

		public DetailsViewController (RecipiesRowData data)
		{
			this.data = data;

			ModalPresentationStyle = UIModalPresentationStyle.FormSheet;

			InitSubviews();
		}

		void InitSubviews()
		{
			var navigationBar = new UINavigationBar(new RectangleF(0, 0, 540, 44));
			
			Add(navigationBar);

			closeButton = new UIBarButtonItem() {
				Title = "Close"
			};

			closeButton.SetTitleTextAttributes(new UITextAttributes { TextShadowOffset = new UIOffset(0, 0)  }, UIControlState.Normal);

			closeButton.Clicked += CloseButtonTouched;

			navigationBar.Items = new [] { NavigationItem };
			
			NavigationItem.Title = data.Title;
			NavigationItem.SetRightBarButtonItem(closeButton, false);

			closeButton.SetBackgroundImage(GridlockTheme.SharedTheme.ColoredButtonImage, UIControlState.Normal, UIBarMetrics.Default);
			
			NavigationItem.SetRightBarButtonItem(closeButton, false);

			contentView = new UIView(new RectangleF(0, 46, 540, 586)) {
				BackgroundColor = UIColor.Red
			};

			Add(contentView);

			backgroundImageView = new UIImageView(new RectangleF(0, 0, 540, 586)) {
				Image = GridlockTheme.SharedTheme.ModalBackgroundImage,
				AutoresizingMask = UIViewAutoresizing.FlexibleDimensions
			};

			contentView.Add (backgroundImageView);

			modelImageView = new UIImageView(new RectangleF(23, 25, 237, 189)) {
				Image = data.Image,
				AutoresizingMask = UIViewAutoresizing.FlexibleDimensions
			};

			modelBackgroundImageView = new UIImageView(new RectangleF(13, 15, 257, 209)) {
				Image = UIImage.FromFile("recipe_detail_frame.png"),
				AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleBottomMargin
			};

			contentView.AddSubviews(modelBackgroundImageView, modelImageView);

			lineImageView = new UIImageView(new RectangleF(0, 227, 540, 11)) {
				Image = UIImage.FromFile("recipe_detail_liner.png"),
				ContentMode = UIViewContentMode.Center
			};

			contentView.Add (lineImageView);

			dificultyLabel = new UILabel(new RectangleF(357, 20, 99, 23)) {
				Text = data.Difficulty,
				BackgroundColor = UIColor.Clear,
				Font = UIFont.FromName("HelveticaNeue-Medium", 17),
				TextColor = UIColor.FromRGB(135, 147, 159),
			};

			var duration = TimeSpan.FromMinutes(data.Duration);

			timeLabel = new UILabel(new RectangleF(334, 45, 80, 22)) {
				Text = duration.Hours > 0 ? String.Format("{0}h{1}min", duration.Hours, duration.Minutes) : (duration.Minutes + "min"),
				BackgroundColor = UIColor.Clear,
				Font = UIFont.FromName("HelveticaNeue-Medium", 17),
				TextColor = UIColor.FromRGB(135, 147, 159),
			};

			contentView.AddSubviews(dificultyLabel, timeLabel);

			var dificultTextLabel = new UILabel(new RectangleF(278, 20, 71, 22)) {
				Text = "Dificulty:",
				BackgroundColor = UIColor.Clear,
				Font = UIFont.FromName("HelveticaNeue-Medium", 17),
				TextColor = UIColor.FromRGB(75, 91, 109),
			};

			var timeTextLabel = new UILabel(new RectangleF(278, 45, 48, 22)) {
				Text = "Time:",
				BackgroundColor = UIColor.Clear,
				Font = UIFont.FromName("HelveticaNeue-Medium", 17),
				TextColor = UIColor.FromRGB(75, 91, 109),
			};

			var ingredientsTextLabel = new UILabel(new RectangleF(278, 69, 93, 22)) {
				Text = "Ingredients:",
				BackgroundColor = UIColor.Clear,
				Font = UIFont.FromName("HelveticaNeue-Medium", 17),
				TextColor = UIColor.FromRGB(75, 91, 109),
			};

			ingredientsTextView = new UITextView(new RectangleF(268, 91, 266, 128)) {
				BackgroundColor = UIColor.Clear,
				Font = UIFont.FromName("HelveticaNeue-Medium", 11),
				TextColor = UIColor.FromRGB(135, 147, 159),
				Text = @"1/8 cup chopped dried cherries,  1/8 cup chopped dried mango, 1/4 cup dried cranberries
1/4 cup dried currants, 2 tablespoons chopped candied citron, 1/4 cup dark rum, 1/2 cup butter
1/4 cup packed brown sugar, 1 egg, 1/2 cup 
all-purpose flour, 1/8 teaspoon baking soda, 1/4 teaspoon salt, 1/4 teaspoon ground cinnamon
1/4 cup unsulfured molasses
2 tablespoons milk
1/4 cup chopped pecans
1/4 cup dark rum, divided"
			};

			contentView.AddSubviews(dificultTextLabel, timeTextLabel, ingredientsTextLabel, ingredientsTextView);

			tableView = new UITableView(new RectangleF(20, 284, 500, 303), UITableViewStyle.Plain) {
				Source = new RecipiesSource(data),
				BackgroundColor = UIColor.Clear,
				SeparatorStyle = UITableViewCellSeparatorStyle.None
			};

			Add (tableView);
		}

		void CloseButtonTouched (object sender, EventArgs e)
		{
			this.DismissViewController(true, null);
		}

		[Obsolete ("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation")]
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}

	}
}

