
using System;
using System.Drawing;

#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif

namespace ThemeSample.iOS
{
	public class RecipiesSource : UITableViewSource
	{
		RecipiesRowData data;

		public RecipiesSource (RecipiesRowData data)
		{
			this.data = data;
		}

		#if __UNIFIED__
		public override nint NumberOfSections (UITableView tableView)
		#else
		public override int NumberOfSections (UITableView tableView)
		#endif
		{
			return 1;
		}

		#if __UNIFIED__
		public override nint RowsInSection (UITableView tableview, nint section)
		#else
		public override int RowsInSection (UITableView tableview, int section)
		#endif
		{
			return data.Directions.Count;
		}
		
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (RecipiesCell.Key) as DirectionsCell;
			if (cell == null)
				cell = new DirectionsCell ();

			var direction = data.Directions[indexPath.Row];

			cell.DetailTextLabel.Text = direction;
			cell.CountLabel.Text = indexPath.Row.ToString();

			var frame = cell.DetailTextLabel.Frame;
			frame.Height = GetHeight(direction);
			frame.Width -= 10;
			cell.DetailTextLabel.Frame = frame;

			return cell;
		}

		#if  __UNIFIED__
		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		#else
		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		#endif
		{
			var direction = data.Directions[indexPath.Row];

			return GetHeight(direction) + 10;
		}

		private float GetHeight(string input)
		{
			var size = (new NSString(input)).StringSize(UIFont.FromName("Helvetica Neue", 12), new SizeF(480, 303));

			return (float)size.Height;
		}
	}
}

