
using System;
using System.Collections.Generic;
using System.Linq;

#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif

using MonoTouch.Dialog;

namespace ThemeSample.iOS
{
	public class RecipiesRowData
	{
		public int Duration { get; private set; }
		public string Title { get; private set; }
		public UIImage Image { get; private set; }
		public string Difficulty { get; private set; }
		public List<string> Directions { get; private set; }
		
		public RecipiesRowData(string title, int duration, string imageName)
		{
			Title = title;
			Duration = duration;
			Image = UIImage.FromFile(imageName);
		}

		public void SetParameters(List<string> directions, string difficulty)
		{
			Directions = directions;
			Difficulty = difficulty;
		}
	}
}
