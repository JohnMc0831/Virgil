
using System;
using System.Collections.Generic;
using System.Linq;

#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
using MonoTouch.Dialog;
using System.Drawing;

namespace ThemeSample.iOS
{
	public partial class DirectionsCell : UITableViewCell
	{
		UILabel descriptionLabel;
		UIImageView countImageView;

		public UILabel CountLabel { get; private set; }

		public override UILabel DetailTextLabel {
			get { return descriptionLabel; }
		}

		public DirectionsCell () : base (UITableViewCellStyle.Default, RecipiesCell.Key)
		{
			InitSubviews();
			ApplyStyles();
		}

		void InitSubviews() 
		{
			descriptionLabel = new UILabel(new RectangleF(55, 5, 440, 20)){
				BackgroundColor = UIColor.Clear,
				Font = UIFont.FromName("HelveticaNeue-Medium", 12),
				TextColor = UIColor.FromRGB(135, 147, 159),
				LineBreakMode = UILineBreakMode.WordWrap,
				ShadowColor = UIColor.White,
				Lines = 0
			};

			CountLabel = new UILabel(new RectangleF(17, 6, 20, 20)){
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Center,
				Font = UIFont.FromName("HelveticaNeue-CondensedBold", 14),
				TextColor = UIColor.White
			};

			countImageView = new UIImageView(new RectangleF(17, 6, 20, 20)){
				Image = UIImage.FromFile("recipe_detail_dot.png")
			};

			AddSubviews (descriptionLabel, countImageView, CountLabel);
		}

		void ApplyStyles() 
		{
			BackgroundColor = UIColor.Clear;
			SelectionStyle = UITableViewCellSelectionStyle.None;
		}
	}
}
