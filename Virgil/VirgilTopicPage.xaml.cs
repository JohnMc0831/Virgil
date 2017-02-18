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
            this.webView = new WebView();
            var htmlSource = new HtmlWebViewSource();
            //Adding banner image for Patient Safety Movement per customer request. 2/16/2017.  JRM
            string banner = string.Empty;
            //Waiting on new banner art from customer.  2/18/17.  JRM
            if(Device.Idiom == TargetIdiom.Phone)
            {

                // Accomodate iPhone status bar.
                this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
                //construct banner tag
                banner = "<a href='http://patientsafetymovement.org/'><img src='https://virgil.ftltech.org/Content/PatientSafetyMovement-phone.png' style='margin:auto;display:block' alt='Patient Safety Movement' title='Patient Safety Movement'/></a>";
            }
            else  //tablet et alia
            {
                banner = "<a href='http://patientsafetymovement.org/'><img src='https://virgil.ftltech.org/Content/PatientSafetyMovement-tablet.png' style='margin:auto;display:block' alt='Patient Safety Movement' title='Patient Safety Movement'/></a>";
            }

            //Po' man's language detection mechanism 1.0
            var currLanguage = Helpers.Settings.Language;
            string body = string.Empty;
            switch (currLanguage)
            {
                case "Deutsch":
                    body = topic.BodyGerman;
                    break;
                case "English":
                    body = topic.Body;
                    break;
                default:
                    body = topic.Body;
                    break;
            }
            
            string htmlBody = @"<!DOCTYPE html><html lang='en' xmlns='http://www.w3.org/1999/xhtml'>" +
	                          "<head><meta charset='utf-8' /><title></title>" +
                              "<link rel='stylesheet' type='text/css' href='https://virgil.ftltech.org/Content/bootstrap.css'>" +
	                          "<link rel='stylesheet' type='text/css' href='https://virgil.ftltech.org/Content/flatty.css'>" +
	                          "</head><body>" + banner + body + "</body></html>";
	        htmlSource.Html = htmlBody;
            this.webView.Source = htmlSource;
	        this.Content = webView;
	    }

        public WebView webView { get; set; }
    }
}

