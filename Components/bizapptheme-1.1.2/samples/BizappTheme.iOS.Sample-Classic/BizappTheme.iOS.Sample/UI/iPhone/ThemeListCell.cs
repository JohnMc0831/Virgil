using System;
#if __UNIFIED__
using UIKit;
using CoreGraphics;
#else
using MonoTouch.UIKit;
using CGRect = global::System.Drawing.RectangleF;
#endif
using System.Drawing;

namespace ThemeSample.UI {
	public partial class ThemeListCell : UITableViewCell {
		bool roundedEdgesDone;

		public ThemeListCell (IntPtr handle) : base (handle)
		{
		}

		public void MakeRoundedEdges ()
		{
			if (!roundedEdgesDone) {
				avatarImageView.Layer.CornerRadius = 5f;
				avatarImageView.Layer.MasksToBounds = true;
				
				avatarImageView.Frame = new CGRect (avatarImageView.Frame.X, avatarImageView.Frame.Y, 54, 54); 
				
				roundedEdgesDone = true;
			}
		}

		public void UpdateTitle(String Title)
		{
			titleLabel.Text = Title;
		}

		public void UpdateAuthor(String Text)
		{
			authorLabel.Text = Text;
		}

		public void UpdateLabel(String Text)
		{
			updateLabel.Text = Text;
		}

		/// <summary>
		/// Gets or sets the label frame.
		/// </summary>
		/// <value>The label frame.</value>
		public CGRect LabelFrame
		{
			get 
			{
				return updateLabel.Frame;
			}
			set 
			{
				updateLabel.Frame = value;
			}
		}

		public void SetAvatarImage(UIImage Image)
		{
			avatarImageView.Image = Image;
		}

		public void SetTypeImage(UIImage Image)
		{
			updateTypeImageview.Image = Image;
		}
	}
}
