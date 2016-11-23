// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
#if __UNIFIED__
using UIKit;
using Foundation;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
using System.CodeDom.Compiler;

namespace ThemeSample.UI
{
	[Register ("ThemeListCell")]
	partial class ThemeListCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel authorLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView avatarImageView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel titleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel updateLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView updateTypeImageview { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (authorLabel != null) {
				authorLabel.Dispose ();
				authorLabel = null;
			}
			if (avatarImageView != null) {
				avatarImageView.Dispose ();
				avatarImageView = null;
			}
			if (titleLabel != null) {
				titleLabel.Dispose ();
				titleLabel = null;
			}
			if (updateLabel != null) {
				updateLabel.Dispose ();
				updateLabel = null;
			}
			if (updateTypeImageview != null) {
				updateTypeImageview.Dispose ();
				updateTypeImageview = null;
			}
		}
	}
}
