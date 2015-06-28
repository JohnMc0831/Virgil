﻿using System;

using Xamarin.Forms;

namespace Virgil
{
	public class App : Application
	{
	    private static TopicManager topicService;
		public App ()
		{
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome, I am Virgil.  Let me be your guide..."
						}
					}
				}
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

	    public static TopicManager GetTopicManager()
	    {
	        if (topicService != null)
	        {
	            topicService = new TopicManager(new Uri("http://virgil.ftltech.org"));
	        }
	        return topicService;
	    }
	}
}

