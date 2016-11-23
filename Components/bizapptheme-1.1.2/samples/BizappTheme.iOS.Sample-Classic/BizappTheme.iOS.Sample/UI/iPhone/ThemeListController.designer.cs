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
	[Register ("ThemeListController")]
	partial class ThemeListController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tableListView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (tableListView != null) {
				tableListView.Dispose ();
				tableListView = null;
			}
		}
	}
}
