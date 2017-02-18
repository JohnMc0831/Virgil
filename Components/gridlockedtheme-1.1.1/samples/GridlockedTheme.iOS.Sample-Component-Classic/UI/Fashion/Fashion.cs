
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ThemeSample.iOS
{
	public partial class Fashion : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("Fashion", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("Fashion");
		
		public Fashion (IntPtr handle) : base (handle)
		{
		}
		
		public static Fashion Create ()
		{
			return (Fashion)Nib.Instantiate (null, null) [0];
		}
	}
}

