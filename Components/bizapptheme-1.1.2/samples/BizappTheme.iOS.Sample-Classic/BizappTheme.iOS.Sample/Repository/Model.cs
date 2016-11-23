using System;

#if __UNIFIED__
using UIKit;
using Foundation;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif

namespace ThemeSample.Models {
	public class Model {
		public string name { get; set; }

		public UIImage image;
		public string webContentTitle;
		public string webContent;
		public UIImage webContentImage;

		public Model (string theName, UIImage theImage, string theTitle, string theWebContent, UIImage theWebImage)
		{
			name = theName;
			image = theImage;
			webContent = theWebContent;
			webContentTitle = theTitle;
			webContentImage = theWebImage;
		}
	}
}

