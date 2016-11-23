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
	[Register ("DetailThemeiPadController")]
	partial class DetailThemeiPadController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIWebView articleContentView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView articleImageView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem expandBarButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView gradientView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem likeBarButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView mainContainerView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel metaLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		 UIScrollView scrollView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem shareBarButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView subContainerView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel titleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		 UIToolbar toolbar { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (articleContentView != null) {
				articleContentView.Dispose ();
				articleContentView = null;
			}
			if (articleImageView != null) {
				articleImageView.Dispose ();
				articleImageView = null;
			}
			if (expandBarButton != null) {
				expandBarButton.Dispose ();
				expandBarButton = null;
			}
			if (gradientView != null) {
				gradientView.Dispose ();
				gradientView = null;
			}
			if (likeBarButton != null) {
				likeBarButton.Dispose ();
				likeBarButton = null;
			}
			if (mainContainerView != null) {
				mainContainerView.Dispose ();
				mainContainerView = null;
			}
			if (metaLabel != null) {
				metaLabel.Dispose ();
				metaLabel = null;
			}
			if (scrollView != null) {
				scrollView.Dispose ();
				scrollView = null;
			}
			if (shareBarButton != null) {
				shareBarButton.Dispose ();
				shareBarButton = null;
			}
			if (subContainerView != null) {
				subContainerView.Dispose ();
				subContainerView = null;
			}
			if (titleLabel != null) {
				titleLabel.Dispose ();
				titleLabel = null;
			}
			if (toolbar != null) {
				toolbar.Dispose ();
				toolbar = null;
			}
		}
	}
}
