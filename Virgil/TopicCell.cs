using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Virgil
{
    class TopicCell : ViewCell
    {
        public string Text { get; set; }
        public TopicCell()
        {
            var appIcon = new Image
            {
                HorizontalOptions = LayoutOptions.Start,
                Source = ImageSource.FromFile("waypoint.png"),
                HeightRequest = 40
            };

            var title = new Label();
            title.SetBinding(Label.TextProperty, "Title");

            var topicLayout = CreateTopicLayout();

            var viewLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = { appIcon, topicLayout }
            };
            View = viewLayout;
            Text = title.Text;
            
        }

        static StackLayout CreateTopicLayout()
        {           
            var titleLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            titleLabel.SetBinding(Label.TextProperty, "Title");
            titleLabel.TextColor = Color.Default;

            var detailLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                FontSize = Device.OnPlatform(10f, 10f, 10f),
                TextColor = Color.Gray
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
