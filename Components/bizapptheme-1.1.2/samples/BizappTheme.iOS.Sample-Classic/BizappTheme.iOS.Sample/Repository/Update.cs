using System;

#if __UNIFIED__
using UIKit;
using Foundation;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif

namespace ThemeSample.Models {
	public enum UpdateType
	{		
		TwitterUpdate, 		
		FacebookUpdate
	};

	public class Update {
		public String title;
		public String author;
		public String updateText;
		public UIImage avatar;
		public UIImage updateTypeImage;

		public Update (string theTitle, string theAuthor, UIImage theAvatar, UpdateType theType, string theText)
		{
			title = theTitle;
			author = theAuthor;
			avatar = theAvatar;
			updateText = theText;

			string picture = string.Format ("{0}.png", theType == UpdateType.FacebookUpdate ? "fb" : "tweet");

			updateTypeImage = UIImage.FromFile (picture);

		}
	}
}

