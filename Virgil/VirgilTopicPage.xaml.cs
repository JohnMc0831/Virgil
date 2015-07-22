using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Virgil
{
	public partial class VirgilTopicPage : ContentPage
	{
		public VirgilTopicPage ()
		{
			
		}

	    public VirgilTopicPage(Topic topic)
	    {
            InitializeComponent();
            //Bind the topic to the view using a WebView component to render the HTML.
	        Title = topic.Title;
            var webView = new WebView();
            var htmlSource = new HtmlWebViewSource();
	        htmlSource.Html = topic.Body;
            webView.Source = htmlSource;
	        this.Content = webView;
	    }
	}
}

