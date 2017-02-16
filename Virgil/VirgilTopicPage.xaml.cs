﻿using System;
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
            this.webView = new WebView();
            var htmlSource = new HtmlWebViewSource();
            //Adding banner image for Patient Safety Movement per customer request. 2/16/2017.  JRM
            string banner = "<a href='http://patientsafetymovement.org/'><img src='https://virgil.ftltech.org/Content/PatientSafetyMovement.png' style='margin:auto;display:block' alt='Patient Safety Movement' title='Patient Safety Movement'/></a>";

            string htmlBody = @"<!DOCTYPE html><html lang='en' xmlns='http://www.w3.org/1999/xhtml'>" +
	                          "<head><meta charset='utf-8' /><title></title>" +
                              "<link rel='stylesheet' type='text/css' href='https://virgil.ftltech.org/Content/bootstrap.css'>" +
	                          "<link rel='stylesheet' type='text/css' href='https://virgil.ftltech.org/Content/flatty.css'>" +
	                          "</head><body>" + banner + topic.Body +
	                          "</body></html>";
	        htmlSource.Html = htmlBody;
            this.webView.Source = htmlSource;
	        this.Content = webView;
	    }

        public WebView webView { get; set; }

        private void backClicked(object sender, EventArgs e)
        {
            // Check to see if there is anywhere to go back to
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
            else
            { // If not, leave the view
                Navigation.PopAsync();
            }
        }

        private void forwardClicked(object sender, EventArgs e)
        {
            if (webView.CanGoForward)
            {
                webView.GoForward();
            }
        }
    }
}

