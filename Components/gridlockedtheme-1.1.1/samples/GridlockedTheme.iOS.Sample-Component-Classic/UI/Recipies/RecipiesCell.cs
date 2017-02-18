
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
	public class RecipiesCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("RecipiesCell");

		RecipiesRowData data;
		int dataCount;

		UIView StatusView { get; set; }

		UIImageView ModelImageView { get; set; }
		UIImageView ClockImageView { get; set; }
		UIImageView BackgroundImageView { get; set; }
		UIImageView DetailsBackgroundImageView { get; set; }

		UILabel TitleLabel { get; set; }
		UILabel DurationLabel { get; set; }
		
		public RecipiesCell () : base (UITableViewCellStyle.Default, Key)
		{
			InitSubviews();
			ApplyStyles();
		}

		void InitSubviews()
		{
			StatusView = new UIView(new RectangleF(0, 213, 241, 71));

			ModelImageView = new UIImageView(new RectangleF(5, 5, 231, 200));
			ClockImageView = new UIImageView(new RectangleF(8, 45, 19, 19));
			BackgroundImageView = new UIImageView(new RectangleF(0, 0, 241, 285));
			DetailsBackgroundImageView = new UIImageView(new RectangleF(0, 0, 241, 71));

			TitleLabel = new UILabel(new RectangleF(8, 5, 224, 22)) {
				TextColor = UIColor.DarkGray,
				Font = UIFont.FromName("HelveticaNeue-Bold", 17),
				BackgroundColor = UIColor.Clear
			};

			DurationLabel = new UILabel(new RectangleF(30, 44, 60, 21)) {
				TextColor = UIColor.DarkGray,
				Font = UIFont.FromName("HelveticaNeue", 15),
				BackgroundColor = UIColor.Clear
			};

			BackgroundImageView = new UIImageView(new RectangleF(0, 0, 241, 285)) {
				Image = GridlockTheme.SharedTheme.TileBackgroundImage
			};

			StatusView.AddSubviews(DetailsBackgroundImageView, TitleLabel, ClockImageView, DurationLabel);

			AddSubviews(BackgroundImageView, ModelImageView, StatusView);
		}

		void ApplyStyles()
		{

		}

		public void Bind(RecipiesRowData data)
		{			
			dataCount = data.Directions.Count;

			this.data = data;

			var duration = TimeSpan.FromMinutes(data.Duration);
			
			TitleLabel.Text = data.Title;
			DurationLabel.Text = String.Format("{0}h{1}min", duration.Hours, duration.Minutes);
			ModelImageView.Image = data.Image;

			DetailsBackgroundImageView.Image = UIImage.FromFile("card-details.png");
			ClockImageView.Image = UIImage.FromFile("clock.png");
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			var imageFrame = ModelImageView.Frame;
			imageFrame.Size = data.Image.Size;
			ModelImageView.Frame = imageFrame;
			ModelImageView.Image = data.Image;

			var statusFrame = StatusView.Frame;
			statusFrame.Y = 2 * imageFrame.Y + imageFrame.Height;
			StatusView.Frame = Rectangle.Round((RectangleF)statusFrame);

			var frame = Frame;
			frame.Height = statusFrame.Y + statusFrame.Height;
			frame.Width = 241;
			Frame = Rectangle.Round((RectangleF)frame);

			var backgroundFrame = BackgroundImageView.Frame;
			backgroundFrame.Height = frame.Height;
			BackgroundImageView.Frame = backgroundFrame;

			Superview.Superview.LayoutSubviews();
		}
	}
}

