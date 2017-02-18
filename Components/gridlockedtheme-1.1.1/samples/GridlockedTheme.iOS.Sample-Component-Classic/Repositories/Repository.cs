using System;
using System.Collections.Generic;
#if __UNIFIED__
using UIKit;
#else
using MonoTouch.UIKit;
#endif

namespace ThemeSample.iOS
{
	public static class Repository
	{
		public static List<FashionRowData> LoadFashioData()
		{
			var f1 = new FashionRowData("dress0.png", 8, 0);

			var f2 = new FashionRowData("dress1.png", 6, 2);
			f2.AddMention("John Doe", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud");
			f2.AddMention("John Zoe", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud");

			var f3 = new FashionRowData("dress2.png", 8, 1);
			f3.AddMention("John Doe", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud");

			var f4 = new FashionRowData("dress1.png", 7, 0);

			var f5 = new FashionRowData("dress0.png", 3, 2);
			f5.AddMention("John Doe", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud");
			f5.AddMention("John Zoe", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud");
			
			var f6 = new FashionRowData("dress2.png", 1, 4);
			f6.AddMention("John Aoe", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud");
			f6.AddMention("John Boe", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud");
			f6.AddMention("John Doe", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud");
			f6.AddMention("John Coe", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud");

			var f7 = new FashionRowData("dress1.png", 2, 2);
			f7.AddMention("John Boe", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud");
			f7.AddMention("John Doe", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud");

			return new List<FashionRowData> { f1, f2, f3, f4, f5, f6, f7 };
		}

		public static List<RecipiesRowData> LoadRecipiesData()
		{
			var instructions = new List<string> {
				"Soak cherries, mango, cranberries, currants, and citron in 1/4 cup rum for at least 24 hours. Cover tightly, and store at room temperature.",
				"Preheat oven to 325 degrees F (165 degrees C). Butter a 6x3 inch round pan, and line with parchment paper.",
				"In a large bowl, cream together butter and brown sugar until fluffy. Beat in egg. Whisk together flour, baking soda, salt, and cinnamon; mix into butter and sugar in three batches, alternating with molasses and milk. Stir in soaked fruit and chopped nuts. Scrape batter into prepared pan.",
				"Bake in preheated oven for 40 to 45 minutes. Cool in the pan for 10 minutes, then sprinkle with 2 tablespoons rum.",
				"Cut out one piece parchment paper and one piece cheesecloth, each large enough to wrap around the cake. Moisten cheesecloth with 1 tablespoon rum. Arrange cheesecloth on top of parchment paper, and unmold cake onto it. Sprinkle top and sides of cake with remaining rum."
			};

			var r1 = new RecipiesRowData("Cherry Cake", 90 ,"recipe0.png");
			r1.SetParameters(instructions, "Intermediate");

			var r2 = new RecipiesRowData("Decorated Dish", 30 ,"recipe1.png");
			r2.SetParameters(instructions, "Beginner");

			var r3 = new RecipiesRowData("Beef Stake", 135 ,"recipe2.png");
			r3.SetParameters(instructions, "Intermediate");

			var r4 = new RecipiesRowData("Fruit Salad", 70 ,"recipe3.png");
			r4.SetParameters(instructions, "Beginner");

			var r5 = new RecipiesRowData("Cherry Cake", 105 ,"recipe4.png");
			r5.SetParameters(instructions, "Advanced");

			var r6 = new RecipiesRowData("Fruit Salad", 70 ,"recipe3.png");
			r6.SetParameters(instructions, "Beginner");

			var r7 = new RecipiesRowData("Cherry Cake", 90 ,"recipe0.png");
			r7.SetParameters(instructions, "Intermediate");

			var r8 = new RecipiesRowData("Cherry Cake", 105 ,"recipe4.png");
			r8.SetParameters(instructions, "Advanced");

			var r9 = new RecipiesRowData("Cherry Cake", 90 ,"recipe0.png");
			r9.SetParameters(instructions, "Intermediate");

			var r10 = new RecipiesRowData("Decorated Dish", 30 ,"recipe1.png");
			r10.SetParameters(instructions, "Beginner");

			var r11 = new RecipiesRowData("Beef Stake", 135 ,"recipe2.png");
			r11.SetParameters(instructions, "Intermediate");

			var r12 = new RecipiesRowData("Decorated Dish", 30 ,"recipe1.png");
			r12.SetParameters(instructions, "Beginner");

			return new List<RecipiesRowData> { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12 };			
		}
	}
}

