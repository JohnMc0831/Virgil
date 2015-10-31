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
            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            //Bind the topic to the view using a WebView component to render the HTML.
            Title = topic.Title;
            var webView = new WebView();
            var htmlSource = new HtmlWebViewSource();
	        string htmlBody = @"<!DOCTYPE html><html lang='en' xmlns='http://www.w3.org/1999/xhtml'>" +
	                          "<head><meta charset='utf-8' /><title></title>" +
	                          "<link rel='stylesheet' type='text/css' href='https://virgil.ftltech.org/Content/bootstrap.css'>" +
	                          "<link rel='stylesheet' type='text/css' href='https://virgil.ftltech.org/Content/flatty.css'>" +
	                          "</head><body>" + topic.Body +
	                          "</body></html>";
	        htmlSource.Html = htmlBody;
            webView.Source = htmlSource;
	        this.Content = webView;
	    }
	}
}

