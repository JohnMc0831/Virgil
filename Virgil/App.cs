using System;

using Xamarin.Forms;

namespace Virgil
{
	public class App : Application
	{
	    private static TopicManager topicService;
		public App ()
		{
			// root page 
		    MainPage = new NavigationPage(new VirgilContentPage());
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
	        return topicService ?? (topicService = new TopicManager(new Uri("http://virgil.ftltech.org/")));
	    }
	}
}

