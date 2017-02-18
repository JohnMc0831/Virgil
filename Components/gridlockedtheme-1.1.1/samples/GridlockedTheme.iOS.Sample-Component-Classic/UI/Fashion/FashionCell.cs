
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
	public class FashionCell : UITableViewCell
	{
		int dataCount;
		const float RowHeight = 110f;

		UIView StatusView { get; set; }
		UIImageView ModelImageView { get; set; }
		UIImageView BackgroundImageView { get; set; }		
		UITableView TableView { get; set; }
		UILabel LikesLabel { get; set; }
		UILabel CommentsLabel { get; set; }
		UILabel TitleLabel { get; set; }

		UIButton LikeButton { get; set; }
		UIButton ShareButton { get; set; }

		UIImageView LikesView { get; set; }
		UIImageView CommentsView { get; set; }

		FashionRowData data;

		public static readonly NSString Key = new NSString ("FasionCell");
		
		public FashionCell () : base (UITableViewCellStyle.Default, Key)
		{
			InitSubviews();
			ApplyStyles();
		}

		void InitSubviews()
		{
			ModelImageView = new UIImageView(new RectangleF(5, 5, 231, 200));
			BackgroundView = new UIImageView(new RectangleF(0, 0, 241, 549));
			
			AddSubviews(BackgroundView, ModelImageView);
			
			StatusView = new UIView(new RectangleF(0, 213, 241, 71));
			
			TitleLabel = new UILabel(new RectangleF(8, 5, 224, 22));

			LikesLabel = new UILabel(new RectangleF(182, 42, 21, 21)) {
				TextColor = UIColor.DarkGray,
				Font = UIFont.FromName("HelveticaNeue-Medium", 16)				
			};

			CommentsLabel = new UILabel(new RectangleF(223, 42, 16, 21)) {
				TextColor = UIColor.DarkGray,
				Font = UIFont.FromName("HelveticaNeue-Medium", 16)	
			};
			
			var dotLabel = new UILabel(new RectangleF(38, 38, 17, 21)) {
				Text = ".",
				Font = UIFont.FromName("HelveticaNeue-CondensedBold", 17),
				TextAlignment = UITextAlignment.Center,
				TextColor = UIColor.DarkGray,
				BaselineAdjustment = UIBaselineAdjustment.AlignCenters
			};
			
			LikeButton = new UIButton() {
				Frame = new RectangleF(3, 40, 44, 25),
				Font = UIFont.FromName("HelveticaNeue-Medium", 15)
			};
			
			LikeButton.SetTitle("Like", UIControlState.Normal);
			LikeButton.SetTitleColor(UIColor.FromRGB(107, 162, 233), UIControlState.Normal);			
			
			ShareButton = new UIButton(){
				Frame = new RectangleF(52, 40, 47, 25),
				Font = UIFont.FromName("HelveticaNeue-Medium", 15)
				
			};
			
			ShareButton.SetTitle("Share", UIControlState.Normal);
			ShareButton.SetTitleColor(UIColor.FromRGB(107, 162, 233), UIControlState.Normal);
			
			LikesView = new UIImageView(new RectangleF(155, 40, 25, 25)) {
				Image = GridlockTheme.SharedTheme.LikesIcon,
				ContentMode = UIViewContentMode.Center
			};
			
			CommentsView = new UIImageView(new RectangleF(197, 40, 25, 25)) {
				Image = GridlockTheme.SharedTheme.CommentsIcon,
				ContentMode = UIViewContentMode.Center
			};

			BackgroundImageView = new UIImageView(UIImage.FromFile("card-details.png"));

			StatusView.AddSubviews(TitleLabel, LikesLabel, CommentsLabel, LikeButton, dotLabel, ShareButton, LikesView, CommentsView);

			TableView = new UITableView(new RectangleF(2, 283, 237, 266), UITableViewStyle.Plain) {
				SeparatorStyle = UITableViewCellSeparatorStyle.SingleLineEtched,
				ScrollEnabled = false
			};

			Add (StatusView);
			Add (TableView);
		}

		void ApplyStyles()
		{
			BackgroundColor = UIColor.White;
		}

		public void Bind(FashionRowData data)
		{
			dataCount = data.Mentions.Count;

			this.data = data;

			TitleLabel.Text = "Spring 2012 Collection";
			CommentsLabel.Text = data.Comments.ToString();
			LikesLabel.Text = data.Likes.ToString();

			TableView.Source = new FashionSource(data.Mentions);
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

			TableView.ReloadData();

			var tableFrame = TableView.Frame;
			tableFrame.Y = statusFrame.Y + statusFrame.Height;
			tableFrame.Height = dataCount * RowHeight;
			TableView.Frame = Rectangle.Round((RectangleF)tableFrame);

			var cellFrame = Frame;
			cellFrame.Height = tableFrame.Y + tableFrame.Height + (tableFrame.Height > 0 ? 5 : 2);
			cellFrame.Width = 241;
			Frame = Rectangle.Round((RectangleF)cellFrame);

			Superview.Superview.LayoutSubviews();
		}
	}
}

