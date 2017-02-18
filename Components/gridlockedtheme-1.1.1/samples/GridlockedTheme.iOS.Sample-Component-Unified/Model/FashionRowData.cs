using System;
using System.Collections.Generic;
#if __UNIFIED__
using UIKit;
#else
using MonoTouch.UIKit;
#endif


namespace ThemeSample.iOS
{
	public class FashionRowData
	{
		public UIImage Image { get; private set; }
		public int Likes { get; private set; }
		public int Comments { get; private set; }
		public List<KeyValuePair<string, string>> Mentions { get; private set; }

		public FashionRowData(string imageName, int likes, int comments)
		{
			Image = UIImage.FromFile(imageName);
			Likes = likes;
			Comments = comments;

			Mentions = new List<KeyValuePair<string, string>>();
		}

		public void AddMention(string author, string mention)
		{
			Mentions.Add(new KeyValuePair<string, string>(author, mention));
		}
	}
}

