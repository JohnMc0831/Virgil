using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Virgil
{
    public class TopicCell : ViewCell
    {
        public string Text { get; set; }

        public string ImageUri { get; set; }

        public TopicCell()
        {
            //ImageUri = "http://lorempixel.com/60/60/cats/";
            //var image = new Xamarin.Forms.Image()
            //{
            //    HorizontalOptions = LayoutOptions.Start,
            //    Source = new Uri(ImageUri)
            //};

            //image.WidthRequest = image.HeightRequest = 60;

            var title = new Label();
            title.SetBinding(Label.TextProperty, "Title");   
            var topicLayout = CreateTopicLayout();
            var viewLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = {topicLayout} 
            };
            View = viewLayout;
            Text = title.Text;
        }

        public static StackLayout CreateTopicLayout()
        {
            var titleLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            titleLabel.SetBinding(Label.TextProperty, "Title");
            //titleLabel.SetBinding(VisualElement.BackgroundColorProperty, "BackColor");
            //titleLabel.SetBinding(Label.TextColorProperty, "TextColor");

            var detailLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = Device.OnPlatform(10f, 10f, 10f),
                HeightRequest = 60f
            };
            detailLabel.SetBinding(Label.TextProperty, "Summary");

            var topicLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { titleLabel, detailLabel }
            };
            return topicLayout;
        }

    }
}
