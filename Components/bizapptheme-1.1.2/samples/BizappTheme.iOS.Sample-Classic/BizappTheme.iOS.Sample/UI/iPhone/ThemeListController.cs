using System;
using System.Drawing;
#if __UNIFIED__
using UIKit;
using Foundation;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using nfloat = global::System.Single;
#endif
using ThemeSample.Models;

namespace ThemeSample.UI {
	public partial class ThemeListController : UIViewController {
		Update[] updates;

		public ThemeListController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			this.updates = DataLoader.LoadSampleUpdates ();
			
			tableListView.WeakDelegate = this;
			tableListView.WeakDataSource = this;
			
			tableListView.BackgroundColor = UIColor.Clear;
			tableListView.SeparatorStyle = UITableViewCellSeparatorStyle.None;

			Xamarin.Themes.BizappTheme.Apply (View);
			
			Title = "Updates";
			
			base.ViewDidLoad ();
		}

		[Obsolete ("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation")]
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return YES for supported orientations
			return (toInterfaceOrientation == UIInterfaceOrientation.Portrait);
		}

		[Export ("tableView:cellForRowAtIndexPath:")]
		UITableViewCell CellForRow (UITableView tableView, NSIndexPath indexPath)
		{
			NSString CellIdentifier = new NSString ("ThemeListCellTop");
			
			if (indexPath.Row > 0 && indexPath.Row < updates.Length - 1) {
				CellIdentifier = new NSString ("ThemeListCellMiddle");
			} else if (indexPath.Row == updates.Length - 1) {
				CellIdentifier = new NSString ("ThemeListCellBottom");
			}
			
			ThemeListCell cell = (ThemeListCell)tableView.DequeueReusableCell (CellIdentifier);			
			cell.SelectionStyle = UITableViewCellSelectionStyle.None;
			cell.MakeRoundedEdges ();
			
			Update update = updates [indexPath.Row];
		
			cell.UpdateTitle(update.title);
			cell.UpdateAuthor (update.author); 
			cell.UpdateLabel (update.updateText);

			var updateFrame = cell.LabelFrame;
			updateFrame.Height = UIStringDrawing.StringSize (update.updateText, UIFont.SystemFontOfSize (12f), new SizeF (222, 1000)).Height;
			cell.LabelFrame = updateFrame;
			cell.SetAvatarImage (update.avatar);
			cell.SetTypeImage (update.updateTypeImage);
						
			return cell;
		}

		[Export ("tableView:heightForRowAtIndexPath:")]
		nfloat HeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			Update update = updates [indexPath.Row];			
			return 49 + UIStringDrawing.StringSize (update.updateText, UIFont.SystemFontOfSize (12f), new SizeF (222, 1000)).Height;
		}

		[Export ("tableView:numberOfRowsInSection:")]
		int NumberOfRows (UITableView tableView, int section)
		{
			return updates.Length;
		}

		[Export ("tableView:didSelectRowAtIndexPath:")]
		void DidSelectRow (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, true);
		}
			
	}
}
